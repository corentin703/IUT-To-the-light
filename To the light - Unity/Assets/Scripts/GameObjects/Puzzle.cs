using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : PickableObject
{
    [HideInInspector]
    public bool HasBeenPressed = false;
    protected override void PickAction()
    {
        //_MGR_Son_Musique.Instance.PlaySound(gameObject.tag);
        HasBeenPressed = true;
    }
}
