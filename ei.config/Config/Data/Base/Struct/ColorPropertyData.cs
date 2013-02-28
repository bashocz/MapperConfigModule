using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class ColorPropertyData : StructData
    {
        #region private fields

        private StringData variableName;
        private StringData propertyName;
        private StringData fontName;
        private IntegerData fontSize;
        private BooleanData fontBold;
        private StringData foreground;
        private StringData background;

        private Font font;
        private Color foreColor;
        private Color backColor;

        #endregion

        #region constructors

        public ColorPropertyData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            this.variableName = new StringData(configType, prefix + name, "VariableName", "Color variable name", "", "waferBackground");
            AddChild(this.variableName);

            this.propertyName = new StringData(configType, prefix + name, "Name", "Color name", "", "Wafer background");
            AddChild(this.propertyName);

            this.fontName = new StringData(configType, prefix + name, "FontName", "Font name", "", "Microsoft Sans Serif");
            AddChild(this.fontName);

            this.fontSize = new IntegerData(configType, prefix + name, "FontSize", "Font size", "", 8);
            AddChild(this.fontSize);

            this.fontBold = new BooleanData(configType, prefix + name, "FontBold", "Font bold", "", false);
            AddChild(this.fontBold);

            this.foreground = new StringData(configType, prefix + name, "Foreground", "Foreground color", "", "White");
            AddChild(this.foreground);

            this.background = new StringData(configType, prefix + name, "Background", "Background color", "", "White");
            AddChild(this.background);

            NewFont();
            NewForeColor();
            NewBackColor();
        }

        #endregion

        #region private methods

        private void NewFont()
        {
            if (fontBold.Value)
                font = new Font(fontName.Value, fontSize.Value, FontStyle.Bold);
            else
                font = new Font(fontName.Value, fontSize.Value, FontStyle.Regular);
        }

        private Color NewColor(string colorName)
        {
            string[] colorArr = colorName.Split(';');
            if (string.Compare(colorArr[0], "Custom", true) != 0)
                return Color.FromName(colorArr[0]);
            return Color.FromArgb(Convert.ToInt32(colorArr[1]), Convert.ToInt32(colorArr[2]), Convert.ToInt32(colorArr[3]));
        }

        private void NewForeColor()
        {
            foreColor = NewColor(foreground.Value);
        }

        private void NewBackColor()
        {
            backColor = NewColor(background.Value);
        }

        private string NewGround(Color color)
        {
            if (color.Name.ToLower().StartsWith("ff"))
                return "Custom;" + color.R.ToString() + ";" + color.G.ToString() + ";" + color.B.ToString();
            return color.Name.ToString();
        }

        private void NewForeground()
        {
            foreground.Value = NewGround(foreColor);
        }

        private void NewBackground()
        {
            background.Value = NewGround(backColor);
        }

        #endregion

        #region public methods

        public void ChangeItem(string variableName, string name, string fontName, int fontSize, bool fontBold, string foreground, string background)
        {
            //BeginChange();

            this.variableName.Value = variableName;
            this.propertyName.Value = name;
            this.fontName.Value = fontName;
            this.fontSize.Value = fontSize;
            this.fontBold.Value = fontBold;
            this.foreground.Value = foreground;
            this.background.Value = background;

            NewFont();
            NewForeColor();
            NewBackColor();

            //EndChange();
            DataChanged();
        }

        public void ChangeItem(string fontName, int fontSize, bool fontBold, string foreground, string background)
        {
            //BeginChange();

            this.fontName.Value = fontName;
            this.fontSize.Value = fontSize;
            this.fontBold.Value = fontBold;
            this.foreground.Value = foreground;
            this.background.Value = background;

            NewFont();
            NewForeColor();
            NewBackColor();

            //EndChange();
            DataChanged();
        }

        public void ChangeItem(Font font, Color foreColor, Color backColor)
        {
            //BeginChange();

            this.font = font;
            this.fontName.Value = font.Name;
            this.fontSize.Value = (int)Math.Round(font.Size);
            this.fontBold.Value = font.Bold;
            this.foreColor = foreColor;
            this.backColor = backColor;

            NewForeground();
            NewBackground();

            //EndChange();
            DataChanged();
        }

        #endregion

        #region public properties

        public string VariableName
        {
            get { return variableName.Value; }
        }

        public string PropertyName
        {
            get { return propertyName.Value; }
        }

        public Font Font
        {
            get { return font; }
        }

        public Color ForeColor
        {
            get { return foreColor; }
        }

        public Color BackColor
        {
            get { return backColor; }
        }

        #endregion
    }
}
