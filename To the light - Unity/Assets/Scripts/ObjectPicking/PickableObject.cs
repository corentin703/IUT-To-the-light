using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickableObject : MonoBehaviour
{
    [SerializeField]
    private bool isPickableByClick = true;
    [SerializeField]
    private float clickPickDistance = 5;

    [SerializeField]
    private bool isPickableByObjectPicker = true;

    private LayerMask layerMask;

    public bool IsPickableByClick()
    {
        return isPickableByClick;
    }

    public bool IsPickableByObjectPicker()
    {
        return isPickableByObjectPicker;
    }

    void Start()
    {
        string layerName = "L_PickableObject";

        gameObject.layer = LayerMask.NameToLayer(layerName);
        layerMask = LayerMask.GetMask(layerName);
    }

    void Update()
    {
        if (isPickableByClick && Input.GetKeyDown(KeyCode.Mouse0) && testMousePicking())
            PickAction();
    }

    public void Pick()
    {
        if (isPickableByObjectPicker)
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

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, clickPickDistance, layerMask))
            {
                if (hitInfo.transform.gameObject == gameObject)
                {
                    return true;
                }
            }
        }

        return false;
    }

}
