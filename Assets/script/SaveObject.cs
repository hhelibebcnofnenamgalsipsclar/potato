using System;
[System.Serializable]

public class SaveObject //User
{
    public string userName;
    public string password;
    public string SSID1;
    public bool firstTime;
    public int phoneNum;
    public float netIncome;

    public bool SSIDbool;

    public SaveObject(string un, string pw, string SSID, bool ft, int phone, float netInc, bool SB)
    {
        userName = un;
        password = pw;
        SSID1 = SSID;
        firstTime = ft;
        phoneNum = phone;
        netIncome = netInc;
        SSIDbool = SB;
    }
    //Changes info from Save Object:
    public void Changepw(string x)
    {
        password = x;
    }
    public void changeFirst(bool x)
    {
        firstTime = x;
    }
    public void addSSID(string x)
    {
        SSID1 = x;
    }
    public void changePhone(int x)
    {
        phoneNum = x;
    }
    public void netInc(float x)
    {
        netIncome = x;
    }
    public void setSSIDbool(bool x)
    {
        SSIDbool = x;
    }


    // get information from Saveobject:
    public string getUsername()
    {
        return userName;
    }

    public string getPassword()
    {
        return password;
    }

    public bool getboolFirst()
    {
        return firstTime;
    }
    public string getSSID()
    {
        return SSID1;
    }
    public int getPhone()
    {
        return phoneNum;
    }
    public float getNetIncome()
    {
        return netIncome;
    }
    public bool getSSIDbool()
    {
        return SSIDbool;
    }



    // public SaveObject(string un, string pw)
    // {
    //     userName = un;
    //     password = pw;
    //     SSID = null;
    // }
}