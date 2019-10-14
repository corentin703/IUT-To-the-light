using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        CommonDevTools.DEBUG("Objet touché : " + other.name + " objet source : " + gameObject.name);
        PickableObject __o = other.gameObject.GetComponent<PickableObject>();

        if (__o == null)
            CommonDevTools.ERROR("erreur sur objet à ramasser ! ", other.gameObject);
        else
            __o.Pick();
    }
}