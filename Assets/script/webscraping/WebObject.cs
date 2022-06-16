using System;
using System.Collections.Generic;

[System.Serializable]
public class WebObject
{
    // Start is called before the first frame update
    public string hd;
    public string des;
    public List<string> cat = new List<string>();
    public List<string> req = new List<string>();
    public string instructions;
    public WebObject(string header, string description, List<string> category, List<string> requirements, string intstruct)
    {
        hd = header;
        des = description;
        cat = category;
        req = requirements;
        instructions = intstruct;
    }
    public string getHeader()
    {
        return hd;
    }
}
