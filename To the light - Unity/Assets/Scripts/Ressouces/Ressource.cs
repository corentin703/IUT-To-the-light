﻿using UnityEngine;

public class Ressource : PickableObject
{
    [SerializeField]
    private string resName;
    [SerializeField]
    private string resDescription;

    [SerializeField]
    private int resNumber = 1;

    //[SerializeField]
    //private Sprite resIcon;
    
    public string GetName()
    {
        return resName;
    }

    public string GetDescription()
    {
        return resDescription;
    }

    public int GetNumber()
    {
        return resNumber;
    }

    //public Sprite GetIcon()
    //{
    //    return resIcon;
    //}

    public void Add(int num = 1)
    {
        resNumber += num;
    }

    public override void Pick()
    {
        _MGR_Ressources.Instance.AddRessource(this);
        base.Pick();
    }
}
