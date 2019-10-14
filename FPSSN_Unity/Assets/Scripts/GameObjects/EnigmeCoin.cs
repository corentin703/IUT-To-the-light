using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeCoin : Coin
{
    public override void Pick()
    {
        EnigmePieces.Instance.Object_Picked(gameObject);
        base.Pick();
    }
}
