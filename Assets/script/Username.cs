using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class user{
    public string name;
    public string Address;
    public string id;
    public string SSID;
    public string Phone;
    public user(string name, string Address,string id, string SSID, string Phone){
        this.name = name;
        this.Address = Address;
        this.id= id;
        this.SSID = SSID;
        this.Phone = Phone;
    }
}
public class Username : MonoBehaviour
{
    public TMP_InputField Name;
    public TMP_InputField Address;
    public TMP_InputField Phonenum;
    public TMP_InputField ID;
    public TMP_InputField SSID;

    public user ReturnClass(){
        return new user(Name.text, Address.text, Phonenum.text, ID.text, SSID.text);

    }
    public void SetUi(user user1){
        Name.text = user1.name;
        Address.text = user1.Address;
        Phonenum.text = user1.Phone;
        ID.text = user1.id;
        SSID.text = user1.SSID;

    }
}
