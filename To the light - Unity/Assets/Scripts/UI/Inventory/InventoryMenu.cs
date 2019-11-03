using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour, IScrollHandler
{
    //private Dictionary<Ressource, InventoryItem> m_dInventoryItem = new Dictionary<Ressource, InventoryItem>();
    private Dictionary<string, InventoryItem> m_dInventoryItem = new Dictionary<string, InventoryItem>();
    private Scrollbar m_scrollbar;

    private RectTransform TransRef;
    private ScrollRect ScrollRef;
    private RectTransform ContentRef;

    private float MinScroll = 0;
    private float MaxScroll;

    [SerializeField]
    private GameObject templateItem;

    [SerializeField]
    private GameObject viewport;

    [SerializeField]
    private float ScrollSpeed = 100;


    void Awake()
    {
        m_scrollbar = GetComponentInChildren<Scrollbar>();
        TransRef = GetComponent<RectTransform>();
        ScrollRef = GetComponent<ScrollRect>();
        ContentRef = ScrollRef.content;
    }

    public void Actualize()
    {
        Dictionary<string, Ressource> dRessoucesByName = new Dictionary<string, Ressource>();

        foreach (Ressource ressource in _MGR_Ressources.Instance.lRessources)
        {
            if (!dRessoucesByName.ContainsKey(ressource.GetName()))
                dRessoucesByName.Add(ressource.GetName(), ressource);
        }

        foreach (string resName in dRessoucesByName.Keys)
        {
            if (!m_dInventoryItem.ContainsKey(resName))
            {
                GameObject item = Instantiate(templateItem, viewport.transform);
                m_dInventoryItem.Add(resName, item.GetComponent<InventoryItem>());
            }

            m_dInventoryItem[resName].SetItemInfos(dRessoucesByName[resName].GetName(), dRessoucesByName[resName].GetDescription(), dRessoucesByName[resName].GetPickedNumber());
        }

        MaxScroll = ContentRef.rect.height - TransRef.rect.height;
        m_scrollbar.numberOfSteps = m_dInventoryItem.Count;
    }

    public void Close()
    {
        _MGR_UI.Instance.CloseRessources();
    }

    public void OnScroll(PointerEventData eventData)
    {
        Vector2 ScrollDelta = eventData.scrollDelta;

        ContentRef.anchoredPosition += new Vector2(0, -ScrollDelta.y * ScrollSpeed);

        if (ContentRef.anchoredPosition.y < MinScroll)
            ContentRef.anchoredPosition = new Vector2(0, MinScroll);
        else if (ContentRef.anchoredPosition.y > MaxScroll)
            ContentRef.anchoredPosition = new Vector2(0, MaxScroll);
    }
}
