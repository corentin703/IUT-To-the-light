using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpEvents : MonoBehaviour
{
    public void PressBtnClose()
    {
        _MGR_UI.Instance.ClosePopUp();
    }
}
