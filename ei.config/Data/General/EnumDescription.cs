using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace EI.Config
{
    /// <summary>
    /// Not used.
    /// </summary>
    public class EnumDescription : Attribute
    {
        public string Text;
        public EnumDescription(string text)
        {
            Text = text;
        }
        public static string GetDescription(Enum item)
        {
            Type type = item.GetType();
            MemberInfo[] memberInfo = type.GetMember(item.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (attrs != null && attrs.Length > 0)
                    return ((EnumDescription)attrs[0]).Text;
            }
            return item.ToString();
        }
    }
}
