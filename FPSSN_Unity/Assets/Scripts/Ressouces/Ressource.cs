using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ressource : MonoBehaviour
{
    public string ressourceName { get; private set; }
    public string description { get; private set; }

    public int number { get; private set; }

    public Sprite icon { get; private set; }

    public void Add(int num = 1)
    {
        number += num;
    }
}
