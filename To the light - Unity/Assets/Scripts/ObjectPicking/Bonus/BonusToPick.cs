using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusToPick : PickableObject
{
    public override void Pick()
    {
        base.Pick();
        _MGR_GamePlay.Instance.IncreaseScore(this.gameObject.tag);

        print(_MGR_GamePlay.Instance.score);
    }
}
