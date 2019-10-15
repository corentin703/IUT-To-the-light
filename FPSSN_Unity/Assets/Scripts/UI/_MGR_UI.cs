
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class _MGR_UI : MonoBehaviour
{
    private static _MGR_UI p_instance = null;
    public static _MGR_UI Instance { get { return p_instance; } }

    public GameObject player;

    [SerializeField]
    private Text UI_timeLeft;

    [SerializeField]
    private Text UI_score;

    [SerializeField]
    private GameObject UI_PopUpPannel;

    private Text UI_PopUp_Text;

    void Awake()
    {
        if (p_instance == null)
            p_instance = this;
        else if (p_instance != this)
            Destroy(gameObject);

        UI_PopUp_Text = UI_PopUpPannel.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        updateTimeLeft();
        updateScore();
    }

    public void ShowPopUp(string content)
    {
        player.GetComponent<FirstPersonController>().LockCursor(false);
        UI_PopUp_Text.text = content;
        UI_PopUpPannel.SetActive(true);
    }

    public void ClosePopUp()
    {
        player.GetComponent<FirstPersonController>().LockCursor(true);
        UI_PopUpPannel.SetActive(false);
        UI_PopUp_Text.text = "";
    }

    private void updateTimeLeft()
    {
        int timeLeft = (int)(_MGR_TimeLine.Instance.dureeMax - _MGR_TimeLine.Instance.chrono);

        UI_timeLeft.text = (timeLeft / 60).ToString() + ":" + (timeLeft % 60).ToString();
    }

    private void updateScore()
    {
        UI_score.text = _MGR_GamePlay.Instance.score.ToString();
    }

}
