﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusToPick : PickableObject
{
    protected override void PickAction()
    {
        _MGR_GamePlay.Instance.IncreaseScore(this.gameObject.tag);

        print(_MGR_GamePlay.Instance.score);

        base.PickAction();
    }
}
