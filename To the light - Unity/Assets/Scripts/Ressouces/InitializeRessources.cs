using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeRessources : MonoBehaviour
{
    public List<_MGR_Ressources.RessourceInfo> ressoucesInfos = new List<_MGR_Ressources.RessourceInfo>();

    public static bool IsInitialized { get; private set; } = false;
    void Awake()
    {
        if (_MGR_Ressources.Instance && ressoucesInfos != null)
        {
            _MGR_Ressources.Instance.SetUp(ressoucesInfos);

            IsInitialized = true;
        }
    }
}
