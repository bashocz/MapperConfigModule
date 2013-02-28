using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class ColorPropertyListData : ValueListData<ColorPropertyData>
    //{
    //    #region private fields

    //    private readonly ColorPropertyData waferBackground;
    //    private readonly ColorPropertyData waferCircle;
    //    private readonly ColorPropertyData waferGrid;
    //    private readonly ColorPropertyData selectedDie;
    //    private readonly ColorPropertyData selectedSite;
    //    private readonly ColorPropertyData testedDie;
    //    private readonly ColorPropertyData testedSite;
    //    private readonly ColorPropertyData nullDie;
    //    private readonly ColorPropertyData skippedDie;
    //    private readonly ColorPropertyData edgeDie;
    //    private readonly ColorPropertyData untestedDie;
    //    private readonly ColorPropertyData sampleDie;
    //    private readonly ColorPropertyData defaultGoodBin;
    //    private readonly ColorPropertyData[] goodBin;
    //    private readonly ColorPropertyData defaultFailBin;
    //    private readonly ColorPropertyData[] failBin;

    //    private readonly ColorPropertyData mapperVersion;
    //    private readonly ColorPropertyData proberId;
    //    private readonly ColorPropertyData testerId;
    //    private readonly ColorPropertyData probingMode;

    //    #endregion

    //    #region constructors

    //    public ColorPropertyListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription)
    //    {
    //        waferBackground = NewColorPropertyData("waferBackground", "Wafer background", "Microsoft Sans Serif", 8, false, "Custom;236;233;216", "Custom;24;128;54");
    //        waferCircle = NewColorPropertyData("waferCircle", "Wafer circle", "Microsoft Sans Serif", 8, false, "White", "Black");
    //        waferGrid = NewColorPropertyData("waferGrig", "Wafer grid", "Microsoft Sans Serif", 8, false, "White", "Gray");
    //        selectedDie = NewColorPropertyData("selectedDieGrid", "Selected die", "Microsoft Sans Serif", 8, false, "White", "Black");
    //        selectedSite = NewColorPropertyData("selectedSiteGrid", "Selected site", "Microsoft Sans Serif", 8, false, "White", "Gray");
    //        testedDie = NewColorPropertyData("firstTestedDie", "First site", "Microsoft Sans Serif", 8, false, "White", "LightGreen");
    //        testedSite = NewColorPropertyData("otherTestedDie", "Other site", "Microsoft Sans Serif", 8, false, "White", "Yellow");
    //        nullDie = NewColorPropertyData("nullDie", "Null die", "Microsoft Sans Serif", 8, false, "Gray", "Yellow");
    //        skippedDie = NewColorPropertyData("skippedDie", "Skip die", "Microsoft Sans Serif", 8, false, "Custom;0;255;255", "Yellow");
    //        edgeDie = NewColorPropertyData("edgeDie", "Edge die", "Microsoft Sans Serif", 8, false, "Custom;0;255;255", "Yellow");
    //        untestedDie = NewColorPropertyData("untestedDie", "Untested die", "Microsoft Sans Serif", 8, false, "White", "Yellow");
    //        sampleDie = NewColorPropertyData("sampleDie", "Sample die", "Microsoft Sans Serif", 8, false, "Lime", "Yellow");
    //        defaultGoodBin = NewColorPropertyData("defaultGoodDie", "Good die all bins", "Microsoft Sans Serif", 8, false, "Blue", "White");
    //        goodBin = new ColorPropertyData[32];
    //        goodBin[0] = NewColorPropertyData("goodBin", "Good die BIN 0", "Microsoft Sans Serif", 8, false, "Blue", "White");
    //        goodBin[1] = NewColorPropertyData("goodBin", "Good die BIN 1", "Microsoft Sans Serif", 8, false, "Custom;0;128;255", "White");
    //        goodBin[2] = NewColorPropertyData("goodBin", "Good die BIN 2", "Microsoft Sans Serif", 8, false, "Custom;0;128;192", "White");
    //        goodBin[3] = NewColorPropertyData("goodBin", "Good die BIN 3", "Microsoft Sans Serif", 8, false, "Custom;128;128;255", "White");
    //        goodBin[4] = NewColorPropertyData("goodBin", "Good die BIN 4", "Microsoft Sans Serif", 8, false, "Custom;0;0;160", "White");
    //        goodBin[5] = NewColorPropertyData("goodBin", "Good die BIN 5", "Microsoft Sans Serif", 8, false, "Custom;128;255;255", "White");
    //        goodBin[6] = NewColorPropertyData("goodBin", "Good die BIN 6", "Microsoft Sans Serif", 8, false, "Aqua", "White");
    //        goodBin[7] = NewColorPropertyData("goodBin", "Good die BIN 7", "Microsoft Sans Serif", 8, false, "Custom;0;64;128", "White");
    //        goodBin[8] = NewColorPropertyData("goodBin", "Good die BIN 8", "Microsoft Sans Serif", 8, false, "Custom;128;128;192", "White");
    //        goodBin[9] = NewColorPropertyData("goodBin", "Good die BIN 9", "Microsoft Sans Serif", 8, false, "Custom;128;0;255", "White");
    //        goodBin[10] = NewColorPropertyData("goodBin", "Good die BIN 10", "Microsoft Sans Serif", 8, false, "Custom;64;0;128", "White");
    //        goodBin[11] = NewColorPropertyData("goodBin", "Good die BIN 11", "Microsoft Sans Serif", 8, false, "Custom;96;0;191", "White");
    //        goodBin[12] = NewColorPropertyData("goodBin", "Good die BIN 12", "Microsoft Sans Serif", 8, false, "Custom;131;6;255", "White");
    //        goodBin[13] = NewColorPropertyData("goodBin", "Good die BIN 13", "Microsoft Sans Serif", 8, false, "Custom;186;117;255", "White");
    //        goodBin[14] = NewColorPropertyData("goodBin", "Good die BIN 14", "Microsoft Sans Serif", 8, false, "Custom;120;120;252", "White");
    //        goodBin[15] = NewColorPropertyData("goodBin", "Good die BIN 15", "Microsoft Sans Serif", 8, false, "Custom;116;181;252", "White");
    //        goodBin[16] = NewColorPropertyData("goodBin", "Good die BIN 16", "Microsoft Sans Serif", 8, false, "Blue", "White");
    //        goodBin[17] = NewColorPropertyData("goodBin", "Good die BIN 17", "Microsoft Sans Serif", 8, false, "Custom;0;128;255", "White");
    //        goodBin[18] = NewColorPropertyData("goodBin", "Good die BIN 18", "Microsoft Sans Serif", 8, false, "Custom;0;128;192", "White");
    //        goodBin[19] = NewColorPropertyData("goodBin", "Good die BIN 19", "Microsoft Sans Serif", 8, false, "Custom;128;128;255", "White");
    //        goodBin[20] = NewColorPropertyData("goodBin", "Good die BIN 20", "Microsoft Sans Serif", 8, false, "Custom;0;0;160", "White");
    //        goodBin[21] = NewColorPropertyData("goodBin", "Good die BIN 21", "Microsoft Sans Serif", 8, false, "Custom;128;255;255", "White");
    //        goodBin[22] = NewColorPropertyData("goodBin", "Good die BIN 22", "Microsoft Sans Serif", 8, false, "Aqua", "White");
    //        goodBin[23] = NewColorPropertyData("goodBin", "Good die BIN 23", "Microsoft Sans Serif", 8, false, "Custom;0;64;128", "White");
    //        goodBin[24] = NewColorPropertyData("goodBin", "Good die BIN 24", "Microsoft Sans Serif", 8, false, "Custom;128;128;192", "White");
    //        goodBin[25] = NewColorPropertyData("goodBin", "Good die BIN 25", "Microsoft Sans Serif", 8, false, "Custom;128;0;255", "White");
    //        goodBin[26] = NewColorPropertyData("goodBin", "Good die BIN 26", "Microsoft Sans Serif", 8, false, "Custom;64;0;128", "White");
    //        goodBin[27] = NewColorPropertyData("goodBin", "Good die BIN 27", "Microsoft Sans Serif", 8, false, "Custom;96;0;191", "White");
    //        goodBin[28] = NewColorPropertyData("goodBin", "Good die BIN 28", "Microsoft Sans Serif", 8, false, "Custom;131;6;255", "White");
    //        goodBin[29] = NewColorPropertyData("goodBin", "Good die BIN 29", "Microsoft Sans Serif", 8, false, "Custom;186;117;255", "White");
    //        goodBin[30] = NewColorPropertyData("goodBin", "Good die BIN 30", "Microsoft Sans Serif", 8, false, "Custom;120;120;252", "White");
    //        goodBin[31] = NewColorPropertyData("goodBin", "Good die BIN 31", "Microsoft Sans Serif", 8, false, "Custom;116;181;252", "White");
    //        defaultFailBin = NewColorPropertyData("defaultFailDie", "Fail die all bins", "Microsoft Sans Serif", 8, false, "Custom;255;128;128", "White");
    //        failBin = new ColorPropertyData[32];
    //        failBin[0] = NewColorPropertyData("failBin", "Fail die BIN 0", "Microsoft Sans Serif", 8, false, "Custom;255;128;128", "White");
    //        failBin[1] = NewColorPropertyData("failBin", "Fail die BIN 1", "Microsoft Sans Serif", 8, false, "Custom;100;0;0", "White");
    //        failBin[2] = NewColorPropertyData("failBin", "Fail die BIN 2", "Microsoft Sans Serif", 8, false, "Custom;150;0;0", "White");
    //        failBin[3] = NewColorPropertyData("failBin", "Fail die BIN 3", "Microsoft Sans Serif", 8, false, "Custom;200;0;0", "White");
    //        failBin[4] = NewColorPropertyData("failBin", "Fail die BIN 4", "Microsoft Sans Serif", 8, false, "Custom;250;0;0", "White");
    //        failBin[5] = NewColorPropertyData("failBin", "Fail die BIN 5", "Microsoft Sans Serif", 8, false, "Custom;100;100;0", "White");
    //        failBin[6] = NewColorPropertyData("failBin", "Fail die BIN 6", "Microsoft Sans Serif", 8, false, "Custom;150;150;0", "White");
    //        failBin[7] = NewColorPropertyData("failBin", "Fail die BIN 7", "Microsoft Sans Serif", 8, false, "Custom;200;200;0", "White");
    //        failBin[8] = NewColorPropertyData("failBin", "Fail die BIN 8", "Microsoft Sans Serif", 8, false, "Custom;250;250;0", "White");
    //        failBin[9] = NewColorPropertyData("failBin", "Fail die BIN 9", "Microsoft Sans Serif", 8, false, "Custom;100;0;100", "White");
    //        failBin[10] = NewColorPropertyData("failBin", "Fail die BIN 10", "Microsoft Sans Serif", 8, false, "Custom;150;0;150", "White");
    //        failBin[11] = NewColorPropertyData("failBin", "Fail die BIN 11", "Microsoft Sans Serif", 8, false, "Custom;200;0;200", "White");
    //        failBin[12] = NewColorPropertyData("failBin", "Fail die BIN 12", "Microsoft Sans Serif", 8, false, "Custom;250;0;250", "White");
    //        failBin[13] = NewColorPropertyData("failBin", "Fail die BIN 13", "Microsoft Sans Serif", 8, false, "Custom;100;30;30", "White");
    //        failBin[14] = NewColorPropertyData("failBin", "Fail die BIN 14", "Microsoft Sans Serif", 8, false, "Custom;150;60;60", "White");
    //        failBin[15] = NewColorPropertyData("failBin", "Fail die BIN 15", "Microsoft Sans Serif", 8, false, "Custom;200;90;90", "White");
    //        failBin[16] = NewColorPropertyData("failBin", "Fail die BIN 16", "Microsoft Sans Serif", 8, false, "Custom;255;128;128", "White");
    //        failBin[17] = NewColorPropertyData("failBin", "Fail die BIN 17", "Microsoft Sans Serif", 8, false, "Custom;100;0;0", "White");
    //        failBin[18] = NewColorPropertyData("failBin", "Fail die BIN 18", "Microsoft Sans Serif", 8, false, "Custom;150;0;0", "White");
    //        failBin[19] = NewColorPropertyData("failBin", "Fail die BIN 19", "Microsoft Sans Serif", 8, false, "Custom;200;0;0", "White");
    //        failBin[20] = NewColorPropertyData("failBin", "Fail die BIN 20", "Microsoft Sans Serif", 8, false, "Custom;250;0;0", "White");
    //        failBin[21] = NewColorPropertyData("failBin", "Fail die BIN 21", "Microsoft Sans Serif", 8, false, "Custom;100;100;0", "White");
    //        failBin[22] = NewColorPropertyData("failBin", "Fail die BIN 22", "Microsoft Sans Serif", 8, false, "Custom;150;150;0", "White");
    //        failBin[23] = NewColorPropertyData("failBin", "Fail die BIN 23", "Microsoft Sans Serif", 8, false, "Custom;200;200;0", "White");
    //        failBin[24] = NewColorPropertyData("failBin", "Fail die BIN 24", "Microsoft Sans Serif", 8, false, "Custom;250;250;0", "White");
    //        failBin[25] = NewColorPropertyData("failBin", "Fail die BIN 25", "Microsoft Sans Serif", 8, false, "Custom;100;0;100", "White");
    //        failBin[26] = NewColorPropertyData("failBin", "Fail die BIN 26", "Microsoft Sans Serif", 8, false, "Custom;150;0;150", "White");
    //        failBin[27] = NewColorPropertyData("failBin", "Fail die BIN 27", "Microsoft Sans Serif", 8, false, "Custom;200;0;200", "White");
    //        failBin[28] = NewColorPropertyData("failBin", "Fail die BIN 28", "Microsoft Sans Serif", 8, false, "Custom;250;0;250", "White");
    //        failBin[29] = NewColorPropertyData("failBin", "Fail die BIN 29", "Microsoft Sans Serif", 8, false, "Custom;100;30;30", "White");
    //        failBin[30] = NewColorPropertyData("failBin", "Fail die BIN 30", "Microsoft Sans Serif", 8, false, "Custom;150;60;60", "White");
    //        failBin[31] = NewColorPropertyData("failBin", "Fail die BIN 31", "Microsoft Sans Serif", 8, false, "Custom;200;90;90", "White");
    //        mapperVersion = NewColorPropertyData("lblMapperVersion", "Mapper version", "Microsoft Sans Serif", 14, false, "LightGreen", "Black");
    //        proberId = NewColorPropertyData("lblProbeId", "Probe ID", "Microsoft Sans Serif", 14, false, "NavajoWhite", "Black");
    //        testerId = NewColorPropertyData("lblTesterId", "Tester ID", "Microsoft Sans Serif", 14, false, "DeepSkyBlue", "Black");
    //        probingMode = NewColorPropertyData("lblProbingMode", "Probing mode", "Microsoft Sans Serif", 14, false, "Pink", "Black");

    //        currentValueList.Clear();
    //        currentValueList.Add(waferBackground);
    //        currentValueList.Add(waferCircle);
    //        currentValueList.Add(waferGrid);
    //        currentValueList.Add(selectedDie);
    //        currentValueList.Add(selectedSite);
    //        currentValueList.Add(testedDie);
    //        currentValueList.Add(testedSite);
    //        currentValueList.Add(nullDie);
    //        currentValueList.Add(skippedDie);
    //        currentValueList.Add(edgeDie);
    //        currentValueList.Add(untestedDie);
    //        currentValueList.Add(sampleDie);
    //        currentValueList.Add(defaultGoodBin);
    //        for (int idx = 0; idx < goodBin.Length; idx++)
    //            currentValueList.Add(goodBin[idx]);
    //        currentValueList.Add(defaultFailBin);
    //        for (int idx = 0; idx < failBin.Length; idx++)
    //            currentValueList.Add(failBin[idx]);
    //        currentValueList.Add(mapperVersion);
    //        currentValueList.Add(proberId);
    //        currentValueList.Add(testerId);
    //        currentValueList.Add(probingMode);
    //        CurrentAsDefault();
    //    }

    //    #endregion

    //    #region private methods

    //    private ColorPropertyData NewColorPropertyData(string variableName, string name, string fontName, int fontSize, bool fontBold, string foreground, string background)
    //    {
    //        ColorPropertyData colorProperty = new ColorPropertyData(configType, itemPrefix, "Item", itemDescription, "");
    //        colorProperty.ChangeItem(variableName, name, fontName, fontSize, fontBold, foreground, background);
    //        return colorProperty;
    //    }

    //    private void ChangeDrawProperty(List<ColorPropertyData> valueList)
    //    {
    //        BeginChange();

    //        for (int readIdx = 0; readIdx < valueList.Count; readIdx++)
    //        {
    //            for (int idx = 0; idx < currentValueList.Count; idx++)
    //            {
    //                if (string.Compare(currentValueList[idx].VariableName, valueList[readIdx].VariableName) == 0)
    //                {
    //                    if ((string.Compare(currentValueList[idx].Font.Name, valueList[readIdx].Font.Name, true) != 0) ||
    //                        (string.Compare(currentValueList[idx].ForeColor.Name, valueList[readIdx].ForeColor.Name, true) != 0) ||
    //                        (string.Compare(currentValueList[idx].BackColor.Name, valueList[readIdx].BackColor.Name, true) != 0))
    //                    {
    //                        currentValueList[idx].ChangeItem(valueList[readIdx].Font, valueList[readIdx].ForeColor, valueList[readIdx].BackColor);
    //                    }
    //                }
    //            }
    //        }

    //        EndChange();
    //        DataChanged();
    //    }

    //    #endregion

    //    #region protected methods

    //    protected override ColorPropertyData GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if (xmlElement != null)
    //        {
    //            ColorPropertyData colorData = new ColorPropertyData(ConfigType.All, prefix, "", "", "");
    //            colorData.SetData(xmlElement);

    //            if (colorData.WasRead)
    //                return colorData;
    //        }
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //        //string result = string.Empty;
    //        //result += offset + "<Item name=\"" + prefix + "Item\" datatype=\"struct\" description=\"" + description + "\">";

    //        //result += offset + "  <Item name=\"" + prefix + "VariableName\" datatype=\"string\" description=\"Color variable name\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Name\" datatype=\"string\" description=\"Color name\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Font\" datatype=\"string\" description=\"Font name\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Size\" datatype=\"integer\" description=\"Font size\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Bold\" datatype=\"boolean\" description=\"Bold\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Foreground\" datatype=\"string\" description=\"Foreground color\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Background\" datatype=\"string\" description=\"Background color\" />";
    //        //result += offset + "</Item>";
    //        //return result;
    //    }

    //    protected override string GetItemData(string offset, string prefix, ColorPropertyData item)
    //    {
    //        //string result = string.Empty;
    //        //result += offset + "<Item name=\"" + prefix + "Item\" value=\"\">";
    //        //result += offset + "  <Item name=\"" + prefix + "VariableName\" value=\"" + item.VariableName + "\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Name\" value=\"" + item.Name + "\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Font\" value=\"" + item.Font.Name + "\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Size\" value=\"" + item.Font.Size.ToString() + "\" />";
    //        //result += offset + "  <Item name=\"" + prefix + "Bold\" value=\"" + item.Font.Bold.ToString() + "\" />";
    //        //if (item.ForeColor.Name.ToLower().StartsWith("ff"))
    //        //    result += offset + "  <Item name=\"" + prefix + "Foreground\" value=\"Custom;" + item.ForeColor.R.ToString() + ";" + item.ForeColor.G.ToString() + ";" + item.ForeColor.B.ToString() + "\" />";
    //        //else
    //        //    result += offset + "  <Item name=\"" + prefix + "Foreground\" value=\"" + item.ForeColor.Name.ToString() + "\" />";
    //        //if (item.BackColor.Name.ToLower().StartsWith("ff"))
    //        //    result += offset + "  <Item name=\"" + prefix + "Background\" value=\"Custom;" + item.BackColor.R.ToString() + ";" + item.BackColor.G.ToString() + ";" + item.BackColor.B.ToString() + "\" />";
    //        //else
    //        //    result += offset + "  <Item name=\"" + prefix + "Background\" value=\"" + item.BackColor.Name.ToString() + "\" />";
    //        //result += offset + "</Item>";
    //        //return result;
    //    }

    //    #endregion

    //    #region public methods

    //    // hide derived method
    //    private new void ClearList() { }

    //    // hide derived method
    //    private new void ShakeList() { }

    //    // hide derived method
    //    private new void AddToList(ColorPropertyData value) { }

    //    // hide derived method
    //    private new void AddRangeToList(List<ColorPropertyData> valueList) { }

    //    // hide derived method
    //    private new void UpdateList(List<ColorPropertyData> valueList) { }

    //    public override void SetData(XmlDocument xmlDoc)
    //    {
    //        try
    //        {
    //            wasRead = false;
    //            List<ColorPropertyData> readValueList;
    //            if (GetValue(xmlDoc, out readValueList))
    //            {
    //                ChangeDrawProperty(readValueList);
    //                wasRead = true;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            LogIt.Error("Exception during reading '" + FullName + "': ", ex);
    //        }
    //    }

    //    #endregion

    //    #region public properties

    //    public ColorPropertyData WaferBackground
    //    {
    //        get { return waferBackground; }
    //    }

    //    public ColorPropertyData WaferCircle
    //    {
    //        get { return waferCircle; }
    //    }

    //    public ColorPropertyData WaferGrid
    //    {
    //        get { return waferGrid; }
    //    }

    //    public ColorPropertyData SelectedDie
    //    {
    //        get { return selectedDie; }
    //    }

    //    public ColorPropertyData SelectedSite
    //    {
    //        get { return selectedSite; }
    //    }

    //    public ColorPropertyData TestedDie
    //    {
    //        get { return testedDie; }
    //    }

    //    public ColorPropertyData TestedSite
    //    {
    //        get { return testedSite; }
    //    }

    //    public ColorPropertyData NullDie
    //    {
    //        get { return nullDie; }
    //    }

    //    public ColorPropertyData SkippedDie
    //    {
    //        get { return skippedDie; }
    //    }

    //    public ColorPropertyData EdgeDie
    //    {
    //        get { return edgeDie; }
    //    }

    //    public ColorPropertyData UntestedDie
    //    {
    //        get { return untestedDie; }
    //    }

    //    public ColorPropertyData SampleDie
    //    {
    //        get { return sampleDie; }
    //    }

    //    public ColorPropertyData DefaultGoodBin
    //    {
    //        get { return defaultGoodBin; }
    //    }

    //    public ColorPropertyData[] GoodBin
    //    {
    //        get { return goodBin; }
    //    }

    //    public ColorPropertyData DefaultFailBin
    //    {
    //        get { return defaultFailBin; }
    //    }

    //    public ColorPropertyData[] FailBin
    //    {
    //        get { return failBin; }
    //    }

    //    public ColorPropertyData MapperVersion
    //    {
    //        get { return mapperVersion; }
    //    }

    //    public ColorPropertyData ProberId
    //    {
    //        get { return proberId; }
    //    }

    //    public ColorPropertyData TesterId
    //    {
    //        get { return testerId; }
    //    }

    //    public ColorPropertyData ProbingMode
    //    {
    //        get { return probingMode; }
    //    }

    //    #endregion
    //}
}
