using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private List<InventoryItem> m_lInventoryItems;

    public void Actualize()
    {
        m_lInventoryItems.Clear();

        foreach (Ressource ressource in _MGR_Ressources.Instance.lRessources)
            m_lInventoryItems.Add(new InventoryItem(ressource.name, ressource.description, ressource.number, ressource.icon));
    }
}
