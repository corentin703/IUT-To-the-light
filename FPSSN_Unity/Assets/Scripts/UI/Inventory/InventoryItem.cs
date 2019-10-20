using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private Text m_Name;
    [SerializeField] private Text m_Description;
    [SerializeField] private Text m_Number;

    //void Awake()
    //{
    //    m_icon = GetComponentInChildren<Image>();
    //    m_Name = GetComponentInChildren<Text>();
    //    m_Description = GetComponentInChildren<Text>();
    //    m_Number = GetComponentInChildren<Text>();
    //}

    public InventoryItem(string sName, string sDescription, int iNumber, Sprite icon)
    {
        m_icon.sprite = icon;
        m_Name.text = sName;
        m_Description.text = sDescription;
        m_Number.text = iNumber.ToString();
    }

    //public void MakeUp(Sprite icon, string sName, string sDescription, int iNumber)
    //{
    //    m_icon.sprite = icon;
    //    m_Name.text = sName;
    //    m_Description.text = sDescription;
    //    m_Number.text = iNumber.ToString();
    //}




}
