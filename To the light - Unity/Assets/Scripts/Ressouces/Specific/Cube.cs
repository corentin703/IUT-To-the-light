using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Ressource
{
    [SerializeField]
    private string m_name = "Cube";
    public override string Name 
    { 
        get { return m_name; } 
        set { m_name = value; } 
    }

    [SerializeField]
    private string m_description = "Un très jolie cube";
    public override string Descrition 
    {
        get { return m_description; }
        set { m_description = value; }
    }

    [SerializeField]
    private uint m_number = 1;
    public override uint unitNumber
    {
        get { return m_number; }
        set { m_number = value; }
    }

    [HideInInspector]
    public static uint PickedNumber { get; set; } = 0;

    public override uint GetPickedNumber() { return PickedNumber; }
    public override void Add(uint num = 1)
    {
        PickedNumber += num;
    }

    //void Update()
    //{

    //    Debug.Log("Unit " + unitNumber.ToString());
    //    Debug.Log("N " + Number.ToString());
    //}
}
