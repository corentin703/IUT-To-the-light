using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class __LaunchGame : MonoBehaviour
{


    void Start()        // est appelé apres les awake d'initialisation 
    {
        //_MGR_SceneManager.Instance.LoadScene("Scene_Menu");

        // TODO: Bogue : arrêt du temps lors de première partie quand on supprime cette ligne 
        Time.timeScale = 1f;

        _MGR_SceneManager.Instance.LoadScene(0);
    }
}


