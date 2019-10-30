using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    private Dictionary<Ressource, InventoryItem> m_dInventoryItem = new Dictionary<Ressource, InventoryItem>();
    private Scrollbar m_scrollbar;
    
    [SerializeField]
    private GameObject templateItem;

    [SerializeField]
    private GameObject viewport;

    void Awake()
    {
        m_scrollbar = GetComponentInChildren<Scrollbar>();
    }


    public void Actualize()
    {
        foreach (Ressource ressource in _MGR_Ressources.Instance.lRessources)
        {
            if (!m_dInventoryItem.ContainsKey(ressource))
            {
                GameObject item = Instantiate(templateItem, viewport.transform);
                m_dInventoryItem.Add(ressource, item.GetComponent<InventoryItem>());
            }

            m_dInventoryItem[ressource].SetItemInfos(ressource.GetName(), ressource.GetDescription(), ressource.GetNumber());
        }

        m_scrollbar.numberOfSteps = m_dInventoryItem.Count;
    }

    public void Close()
    {
        _MGR_UI.Instance.CloseRessources();
    }
}
