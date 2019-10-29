using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _MGR_UI : MonoBehaviour
{
    private static _MGR_UI p_instance = null;
    public static _MGR_UI Instance { get { return p_instance; } }

    private Text m_UI_timeLeft;
    private Text m_UI_score;
    private Text m_UI_PopUp_Text;

    private GameObject m_UI_PausePannel;
    private GameObject m_UI_PopUpPannel;
    private GameObject m_UI_RessourcesPannel;

    private bool isInitialized = false;


    void Awake()
    {
        if (p_instance == null)
            p_instance = this;
        else if (p_instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        if (isInitialized)
        {
            if (Input.GetKeyDown(KeyCode.Tab) && m_UI_RessourcesPannel != null)
                ShowRessources();

            if (Input.GetKeyDown(KeyCode.Escape) && m_UI_PausePannel != null)
                Pause();

            updateTimeLeft();
            updateScore();
        }
    }

    public void SetUp(Text UI_timeLeft, 
                    Text UI_score, 
                    GameObject UI_PausePannel, 
                    GameObject UI_PopUpPannel, 
                    GameObject UI_RessourcesPannel)
    {
        m_UI_timeLeft = UI_timeLeft;
        m_UI_score = UI_score;
        m_UI_PausePannel = UI_PausePannel;
        m_UI_PopUpPannel = UI_PopUpPannel;
        m_UI_RessourcesPannel = UI_RessourcesPannel;

        m_UI_PopUp_Text = m_UI_PopUpPannel.GetComponentInChildren<Text>();

        isInitialized = true;
    }

    private void updateTimeLeft()
    {
        int timeLeft = (int)(_MGR_TimeLine.Instance.dureeMax - _MGR_TimeLine.Instance.chrono);
        m_UI_timeLeft.text = (timeLeft / 60).ToString() + ":" + (timeLeft % 60).ToString();
    }

    private void updateScore()
    {
        m_UI_score.text = _MGR_GamePlay.Instance.score.ToString();
    }


    public void ShowPopUp(string content)
    {
        _MGR_GamePlay.Instance.player.LockCursor(false);
        m_UI_PopUp_Text.text = content;
        m_UI_PopUpPannel.SetActive(true);
        _MGR_TimeLine.Instance.Pause();
    }

    public void ClosePopUp()
    {
        _MGR_GamePlay.Instance.player.LockCursor(true);
        m_UI_PopUpPannel.SetActive(false);
        m_UI_PopUp_Text.text = "";
        _MGR_TimeLine.Instance.Resume();
    }

    public void ShowRessources()
    {
        m_UI_RessourcesPannel.GetComponent<InventoryMenu>().Actualize();
        print("Salut");

        _MGR_GamePlay.Instance.player.LockCursor(false);
        m_UI_RessourcesPannel.SetActive(true);
        _MGR_TimeLine.Instance.Pause();
    }

    public void CloseRessources()
    {
        _MGR_GamePlay.Instance.player.LockCursor(true);
        m_UI_RessourcesPannel.SetActive(false);
        _MGR_TimeLine.Instance.Resume();
    }

    public void BackToMainMenu()
    {
        _MGR_SceneManager.Instance.Reboot();
    }

    public void Pause()
    {
        _MGR_GamePlay.Instance.player.LockCursor(false);
        m_UI_PausePannel.SetActive(true);
        _MGR_TimeLine.Instance.Pause();
    }

    public void Resume()
    {
        _MGR_GamePlay.Instance.player.LockCursor(true);
        m_UI_PausePannel.SetActive(false);
        _MGR_TimeLine.Instance.Resume();
    }
}
