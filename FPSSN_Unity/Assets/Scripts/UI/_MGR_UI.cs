
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class _MGR_UI : MonoBehaviour
{
    private static _MGR_UI p_instance = null;
    public static _MGR_UI Instance { get { return p_instance; } }

    public FirstPersonController player;

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
    //[SerializeField]
    //private Canvas UI_RessourcesViewportContent;

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
        if (Input.GetKeyDown(KeyCode.Tab))
            ShowRessources();

        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();

        updateTimeLeft();
        updateScore();
    }

    public void ShowPopUp(string content)
    {
        player.LockCursor(false);
        UI_PopUp_Text.text = content;
        UI_PopUpPannel.SetActive(true);
        _MGR_TimeLine.Instance.Pause();
    }

    public void ClosePopUp()
    {
        player.LockCursor(true);
        UI_PopUpPannel.SetActive(false);
        UI_PopUp_Text.text = "";
        _MGR_TimeLine.Instance.Resume();
    }

    public void ShowRessources()
    {
        player.LockCursor(false);
        UI_RessourcesPannel.SetActive(true);
        _MGR_TimeLine.Instance.Pause();
    }

    public void CloseRessources()
    {
        player.LockCursor(true);
        UI_RessourcesPannel.SetActive(false);
        _MGR_TimeLine.Instance.Resume();
    }

    public void ReturnToMainMenu()
    {
        _MGR_SceneManager.Instance.Reboot();
    }

    public void Pause()
    {
        player.LockCursor(false);
        UI_PausePannel.SetActive(true);
        _MGR_TimeLine.Instance.Pause();
    }

    public void Resume()
    {
        player.LockCursor(true);
        UI_PausePannel.SetActive(false);
        _MGR_TimeLine.Instance.Resume();
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
