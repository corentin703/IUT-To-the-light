using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickableObject : MonoBehaviour
{
    public virtual void Pick()
    {
        Destroy(gameObject);
    }
    public void Pick(float _delai)
    {
        Invoke("ActionObjetRamasse", _delai);
    }

}
