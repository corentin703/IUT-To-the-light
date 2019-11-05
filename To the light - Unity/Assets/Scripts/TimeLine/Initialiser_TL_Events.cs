
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialiser_TL_Events : MonoBehaviour
{

    public Event_TL[] TL_Events;

    public static bool IsInitialized { get; private set; } = false;

    void Awake()
    {
        if (_MGR_TimeLine.Instance)
        {
            _MGR_TimeLine.Instance.Configurer(TL_Events);

            IsInitialized = true;
        } 
    }

}
