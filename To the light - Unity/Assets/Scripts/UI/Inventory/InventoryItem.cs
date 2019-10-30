using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    //[SerializeField] Image icon;
    [SerializeField] private Text itemName;
    [SerializeField] private Text description;
    [SerializeField] private Text number;


    //public InventoryItem(string sName, string sDescription, int iNumber, Sprite icon)
    //{
    //    this.icon.sprite = icon;
    //    itemName.text = sName;
    //    description.text = sDescription;
    //    number.text = iNumber.ToString();
    //}

    public void SetItemInfos(string sName, string sDescription, int iNumber)
    {
        //this.icon.sprite = icon;
        itemName.text = sName + " x" + iNumber.ToString();
        description.text = sDescription;
        number.text = iNumber.ToString();
    }

}
