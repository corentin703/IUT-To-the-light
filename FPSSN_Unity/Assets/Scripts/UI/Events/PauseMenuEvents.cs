using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuEvents : MonoBehaviour
{
    public void PressBtnResume()
    {
        _MGR_UI.Instance.Resume();
    }

    public void PressBtnBackToMainMenu()
    {
        _MGR_UI.Instance.BackToMainMenu();
    }
}
