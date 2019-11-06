using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Knife : MonoBehaviour
{
    [SerializeField]
    private bool negativeX = false;

    public bool HasBeenThrowed { get; private set; } = false;

    void Awake()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    public void Throw()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().AddForce((negativeX) ? -1000f : 1000f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().useGravity = true;

        HasBeenThrowed = true;
    }

    private void OnTriggerEnter(Collider Collision)
    {
        if (Collision.tag == "Player")
        {
            _MGR_TimeLine.Instance.FinDePartie();
            _MGR_SceneManager.Instance.FinDePartie(_MGR_SceneManager.FIN_DE_PARTIE.PERDU_CHUTE);
        }
        else
            gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

}
