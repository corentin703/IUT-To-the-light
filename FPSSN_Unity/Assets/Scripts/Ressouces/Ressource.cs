using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ressource : MonoBehaviour
{
    public string ressourceName { get; private set; }
    public string description { get; private set; }

    public Image icon { get; private set; }
}
