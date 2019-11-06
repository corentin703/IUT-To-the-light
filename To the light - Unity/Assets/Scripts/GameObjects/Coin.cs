using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Ressource
{
    private static uint m_pickedNumber = 0;
    public override uint PickedNumber
    {
        get { return m_pickedNumber; }
        protected set { m_pickedNumber = value; }
    }
    public override void Add(uint num = 1)
    {
        PickedNumber += num;
    }
}
