using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InitialiserGamePlayEtDemarrerPartie : MonoBehaviour
{
    [SerializeField]
    private FirstPersonController player;

    //Awake is always called before any Start functions
    void Awake(){
        // _MGR_GamePlay....... initialisations nécessaires dans awake
     }

    void Start()
    {
        _MGR_GamePlay.Instance.SetPlayer(player);
        _MGR_GamePlay.Instance.StartPlay();
    }

}

