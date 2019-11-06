using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : Ressource
{
    private static uint m_pickedNumber = 0;
    public override uint PickedNumber 
    {
        get { return m_pickedNumber; }
        protected set { m_pickedNumber = value; }
    }

    public override void Add(uint num = 1)
    {
        if (PickedNumber == 0)
            PickedNumber = 1;
        else
            throw new System.Exception("Player can't have more than 1 crowbar");
    }
}
