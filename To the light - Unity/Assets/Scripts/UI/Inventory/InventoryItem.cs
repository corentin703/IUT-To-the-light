using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    //[SerializeField] Image icon;
    [SerializeField] private Text itemName;
    [SerializeField] private Text description;

    public void SetItemInfos(string sName, string sDescription, uint iNumber)
    {
        //this.icon.sprite = icon;
        itemName.text = sName + " x" + iNumber.ToString();
        description.text = sDescription;
    }
}
