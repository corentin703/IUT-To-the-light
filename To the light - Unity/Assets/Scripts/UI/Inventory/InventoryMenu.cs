using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour, IScrollHandler
{
    private Dictionary<Ressource, InventoryItem> m_dInventoryItem = new Dictionary<Ressource, InventoryItem>();
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


    void Start()
    {
        m_scrollbar = GetComponentInChildren<Scrollbar>();
        TransRef = GetComponent<RectTransform>();
        ScrollRef = GetComponentInChildren<ScrollRect>();
        ContentRef = ScrollRef.content;
    }

    public void Actualize()
    {
        foreach (Ressource ressource in _MGR_Ressources.Instance.lRessources)
        {
            Debug.Log("1");
            if (!m_dInventoryItem.ContainsKey(ressource))
            {
                Debug.Log("2");
                GameObject item = Instantiate(templateItem, viewport.transform);
                m_dInventoryItem.Add(ressource, item.GetComponent<InventoryItem>());
                Debug.Log("3");
            }

            m_dInventoryItem[ressource].SetItemInfos(ressource.GetName(), ressource.GetDescription(), ressource.GetNumber());
        }

        MaxScroll = ContentRef.rect.height - TransRef.rect.height;

        m_scrollbar.numberOfSteps = m_dInventoryItem.Count;
        //m_scrollbar.size = 1 / m_dInventoryItem.Count;
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
