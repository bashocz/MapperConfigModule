using System;
using System.Xml;
using System.Collections.Generic;

namespace EI.Config
{
    /// <summary>
    /// Reads and writes hierarchy of <code>XmlNodes</code>, its values, default values and tracks its value's state.
    /// </summary>
    public abstract class SelfManagedXmlNode
    {
        #region private fields

        /// <summary>
        /// The name of the node.
        /// </summary>
        protected readonly string name;

        /// <summary>
        /// The name of the element including the names of the parent elements.
        /// </summary>
        protected string path;

        /// <summary>
        /// Determines whether the value was changed against the XML document it was read from.
        /// When the node was not found and default value was used, it is also <code>true</code>.
        /// </summary>
        private bool outOfSync = false;

        private bool keepSync = true;

        /// <summary>
        /// The children of this node, can be <code>null</code> if no children.
        /// Synchronize every access by the <code>childrenLock</code> lock.
        /// </summary>
        private List<SelfManagedXmlNode> children;

        /// <summary>
        /// For synchronization of the <code>children</code> field.
        /// </summary>
        private readonly object childrenLock = new object();

        #endregion

        #region constructors

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="name">The name of this node.</param>
        protected SelfManagedXmlNode(string name)
        {
            this.name = name;
            this.path = name;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Creates/updates the XML elements for this node and all of its children recursively.
        /// </summary>
        /// <param name="parent">The parent node where to create the XML elements.</param>
        public void WriteTree(XmlNode parent)
        {
            XmlNode ourNode = WriteTo(parent);
            lock (childrenLock)
            {
                if (children != null)
                    foreach (SelfManagedXmlNode child in children)
                        child.WriteTree(ourNode);
            }
        }

        /// <summary>
        /// Reads the values (or default values) from this node and all of its children recursively.
        /// </summary>
        /// <param name="parent">The parent node where to read the values from.</param>
        public void ReadTree(XmlNode parent)
        {
            XmlNode ourNode = ReadFrom(parent);
            lock (childrenLock)
            {
                if (children != null)
                    foreach (SelfManagedXmlNode child in children)
                        child.ReadTree(ourNode);
            }
        }

        /// <summary>
        /// Determines whether the value of the node or some of its children nodes is changed against
        /// the state of the XML it was read from.
        /// </summary>
        /// <returns>The value <code>true</code> if changed, <code>false</code> otherwise.</returns>
        public bool IsTreeOutOfSync()
        {
            if (OutOfSync)
            {
                return true;
            }
            lock (childrenLock)
            {
                if (children != null)
                    foreach (SelfManagedXmlNode child in children)
                        if (child.IsTreeOutOfSync())
                            return true;
            }
            return false;
        }

        /// <summary>
        /// (Re)sets whether the value of the node or its children nodes is changed against
        /// the state of the XML it was read from.
        /// </summary>
        /// <param name="outOfSync">The value <code>true</code> if changed, <code>false</code> otherwise.</param>
        public void SetTreeOutOfSync(bool outOfSync)
        {
            OutOfSync = outOfSync;
            lock (childrenLock)
            {
                if (children != null)
                    children.ForEach(delegate(SelfManagedXmlNode target)
                    {
                        target.SetTreeOutOfSync(outOfSync);
                    });
            }
        }

        /// <summary>
        /// Updates this node XML value or creates it if it is missing.
        /// </summary>
        /// <param name="parent">The parent node where the XML representation of this instance belongs to.</param>
        /// <returns>XML representation of this node.</returns>
        public abstract XmlNode WriteTo(XmlNode parent);

        /// <summary>
        /// Reads this node's value from XML or uses the default value if it is missing in XML.
        /// </summary>
        /// <param name="parent">The parent node where the XML representation of this instance belongs to.</param>
        /// <returns>XML representation of this node.</returns>
        public abstract XmlNode ReadFrom(XmlNode parent);

        /// <summary>
        /// Adds child to this node.
        /// Can throw <code>InvalidOperationException</code>
        /// when the type of the instance does not support adding children.
        /// </summary>
        /// <param name="child">The child node to add.</param>
        public virtual void AddChild(SelfManagedXmlNode child)
        {
            lock (childrenLock)
            {
                if (children == null)
                    children = new List<SelfManagedXmlNode>();
                children.Add(child);
                child.path = this.path + "/" + child.path;
            }
        }

        /// <summary>
        /// Returns human readable representation of the instance.
        /// </summary>
        /// <returns>The instance's string representation.</returns>
        public override string ToString()
        {
            return GetType().FullName + "{ name: " + name + " }";
        }

        #endregion

        #region properties

        /// <summary>
        /// Determines whether the value was changed against the XML document it was read from.
        /// When the node was not found and default value was used, it is also <code>true</code>.
        /// </summary>
        public bool OutOfSync
        {
            get { return outOfSync; }
            protected set
            {
                if (keepSync)
                    outOfSync = value;
            }
        }

        public bool KeepSync
        {
            set { keepSync = value; }
        }

        #endregion

    }
}
