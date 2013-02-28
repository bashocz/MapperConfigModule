using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace EI.Config
{
    public class DrawProperty
    {
        private Font font;
        private Color foreColor;
        private Color backColor;
        private string nameItem;
        private string variableName;
        private DrawPropertyType type;

        public DrawProperty()
        {
            VariableName = "selectedDieGrid";
            nameItem = "Selected die";
            font = new Font("Microsoft Sans Serif", 8);
            foreColor = Color.Black;
            backColor = Color.White;
        }

        public DrawProperty(string variableName, string nameItem, Font font, Color backColor, Color foreColor)
        {
            this.VariableName = variableName;
            this.nameItem = nameItem;
            this.font = font;
            this.backColor = backColor;
            this.foreColor = foreColor;
        }

        public DrawProperty Copy()
        {
            DrawProperty displayProperties = new DrawProperty();
            displayProperties.backColor = this.backColor;
            displayProperties.font = this.font;
            displayProperties.foreColor = this.foreColor;
            displayProperties.nameItem = this.nameItem;
            displayProperties.variableName = this.variableName;
            displayProperties.type = this.type;
            return displayProperties;
        }

        public Font Font
        {
            get { return font; }
            set {  font = value; }
        }

        public Color ForeColor
        {
            get { return foreColor; }
            set { foreColor = value; }
        }

        public Color BackColor
        {
            get { return backColor; }
            set {  backColor = value; }
        }

        public string NameItem
        {
            get { return nameItem; }
            set { nameItem = value; }
        }

        public DrawPropertyType Type
        {
            get { return type; }
        }

        public string VariableName
        {
            get { return variableName; }
            set
            {
                variableName = value;
                switch (variableName)
                {
                    case "waferBackground":
                        type = DrawPropertyType.WaferBackground;
                        break;
                    case "waferCircle":
                        type = DrawPropertyType.WaferCircle;
                        break;
                    case "waferGrig":
                        type = DrawPropertyType.WaferGrid;
                        break;
                    case "nullDie":
                        type = DrawPropertyType.NullDie;
                        break;
                    case "skippedDie":
                        type = DrawPropertyType.SkipDie;
                        break;
                    case "edgeDie":
                        type = DrawPropertyType.EdgeDie;
                        break;
                    case "inkFixedEdgeDie":
                        type = DrawPropertyType.InkFixedEdgeDie;
                        break;
                    case "inkRadialEdgeDie":
                        type = DrawPropertyType.InkRadialEdgeDie;
                        break;
                    case "sampleDie":
                        type = DrawPropertyType.SampleDie;
                        break;
                    case "untestedDie":
                        type = DrawPropertyType.UntestedDie;
                        break;
                    case "goodBin":
                        type = DrawPropertyType.GoodDie;
                        break;
                    case "failBin":
                        type = DrawPropertyType.FailDie;
                        break;
                    case "selectedDieGrid":
                        type = DrawPropertyType.SelectedDie;
                        break;
                    case "selectedSiteGrid":
                        type = DrawPropertyType.SelectedSite;
                        break;
                    case "firstTestedDie":
                        type = DrawPropertyType.FirstSite;
                        break;
                    case "otherTestedDie":
                        type = DrawPropertyType.OtherSite;
                        break;
                    case "lblMapperVersion":
                        type = DrawPropertyType.MapperVersion;
                        break;
                    case "lblProbeId":
                        type = DrawPropertyType.ProberId;
                        break;
                    case "lblTesterId":
                        type = DrawPropertyType.TesterId;
                        break;
                    case "lblProbingMode":
                        type = DrawPropertyType.ProbingMode;
                        break;
                    case "defaultGoodDie":
                        type = DrawPropertyType.DefaultGoodDie;
                        break;
                    case "defaultFailDie":
                        type = DrawPropertyType.DefaultFailDie;
                        break;
                }
            }
        }
    }
}
