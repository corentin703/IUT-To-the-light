using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceBar : MonoBehaviour
{
    //[System.Serializable]
    //private struct Slot
    //{
    //    public Image image;
    //    public bool isCurrent;

    //    public Slot(Image paramimage, bool paramIsCurrent) { image = paramimage; isCurrent = paramIsCurrent; }
    //}

    //[SerializeField]
    //private Slot[] slots;
    private Image[] slots;

    private int activeSlotIndex = -1;

    void Start()
    {
        if (slots == null)
            throw new System.Exception("Inventory slots have not been given");
        else if ((slots.Length % 2) == 0)
            throw new System.Exception("Inventory slots must be odd");

        foreach (Image image in slots)
        {
            image.color = new Color(0, 0, 0, 0);
            image.sprite = null;
        }
    }

    void Update()
    {
        //if (Input.GetAxis("Mouse ScrollWheel"))
        //{
            
        //}
    }

    private void SpriteAssign(Image image, Sprite sprite)
    {
        image.sprite = sprite;
        image.color = new Color(255, 255, 255, 255);
    }
    
}
