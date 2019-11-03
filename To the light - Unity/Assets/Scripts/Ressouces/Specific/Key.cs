using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Ressource
{
    public override void Add(uint num = 1)
    {
        PickedNumber += num;
    }
}
