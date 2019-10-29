using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    //private List<InventoryItem> m_lInventoryItems;
    private Dictionary<Ressource, InventoryItem> m_dInventoryItem;
    private Scrollbar m_scrollbar;


    void Awake()
    {
        //m_lInventoryItems = new List<InventoryItem>();
        m_dInventoryItem = new Dictionary<Ressource, InventoryItem>();
        m_scrollbar = GetComponentInChildren<Scrollbar>();
    }


    public void Actualize()
    {
        print("1");
        foreach (Ressource ressource in _MGR_Ressources.Instance.lRessources)
        {
            print("2");
            if (m_dInventoryItem.ContainsKey(ressource))
            {
                print("OK");
                GameObject item = GameObject.Find("RessourceItem");
                m_dInventoryItem.Add(ressource, item.GetComponent<InventoryItem>());
                Instantiate(item, gameObject.transform);
            }

            m_dInventoryItem[ressource].SetItemInfos(ressource.name, ressource.sDescription, ressource.iNumber, ressource.icon);
        }

        m_scrollbar.numberOfSteps = m_dInventoryItem.Count;
    }
}
