using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ObjetARamasser : MonoBehaviour
{
    public virtual void ActionObjetRamasse()
    {
        _MGR_Son_Musique.Instance.PlaySound(gameObject.tag);
        Destroy(gameObject);
    }
    public void ActionObjetRamasse(float _delai) { Invoke("ActionObjetRamasse", _delai); }
}
