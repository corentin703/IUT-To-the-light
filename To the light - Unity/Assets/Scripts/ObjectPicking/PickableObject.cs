using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickableObject : MonoBehaviour
{
    [SerializeField]
    private bool isPickableByClick = true;

    [SerializeField]
    private bool isPickableByObjectPicker = true;

    public bool IsPickableByClick()
    {
        return isPickableByClick;
    }

    public bool IsPickableByObjectPicker()
    {
        return isPickableByObjectPicker;
    }

    void Update()
    {
        if (isPickableByClick && testMousePicking())
            print("");
            
        
    }

    public void Pick()
    {
        PickAction();
    }

    protected virtual void PickAction()
    {
        Destroy(gameObject);
    }

    public void Pick(float _delai)
    {
        Invoke("ActionObjetRamasse", _delai);
    }

    private bool testMousePicking()
    {
        if (isPickableByClick)
        {
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, pickDistance, layer_mask))
            {
                if (hitInfo.transform.parent.gameObject == gameObject)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
