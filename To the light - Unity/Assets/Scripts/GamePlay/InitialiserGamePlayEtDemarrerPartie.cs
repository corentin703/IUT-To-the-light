using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InitialiserGamePlayEtDemarrerPartie : MonoBehaviour
{
    [SerializeField]
    private FirstPersonController player;

    public static bool IsInitialized { get; private set; } = false;

    void Awake()
    {
        if (_MGR_GamePlay.Instance)
        {
            _MGR_GamePlay.Instance.SetPlayer(player);

            IsInitialized = true;
        }
    }

    void Start()
    {
        _MGR_GamePlay.Instance.StartPlay();
    }

}

