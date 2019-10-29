using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Ressource : MonoBehaviour
{
    public string sName { get; private set; }
    public string sDescription { get; private set; }

    public int iNumber { get; private set; }

    public Sprite icon { get; private set; }
    

    public Ressource(string sName, string sDescription, int iNumber, Sprite icon)
    {
        this.sName = sName;
        this.sDescription = sDescription;
        this.iNumber = iNumber;
        this.icon = icon;
    }

    public void Add(int num = 1)
    {
        iNumber += num;
    }
}
