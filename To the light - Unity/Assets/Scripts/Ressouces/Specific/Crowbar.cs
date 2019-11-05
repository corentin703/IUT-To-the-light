using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : Ressource
{
    private bool m_isPicked = false;

    public override void Add(uint num = 1)
    {
        if (!m_isPicked)
            m_isPicked = true;
        else
            throw new System.Exception("Player can't have more than 1 crowbar");
    }
}
