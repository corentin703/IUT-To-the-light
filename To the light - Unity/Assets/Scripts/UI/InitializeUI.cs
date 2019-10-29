using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeUI : MonoBehaviour
{
    [SerializeField]
    private Text UI_timeLeft;

    [SerializeField]
    private Text UI_score;

    [SerializeField]
    private GameObject UI_PausePannel;

    [SerializeField]
    private GameObject UI_PopUpPannel;

    [SerializeField]
    private GameObject UI_RessourcesPannel;

    // Start is called before the first frame update
    void Start()
    {
        _MGR_UI.Instance.SetUp(UI_timeLeft, 
                                UI_score, 
                                UI_PausePannel, 
                                UI_PopUpPannel, 
                                UI_RessourcesPannel
                            );
    }
}
