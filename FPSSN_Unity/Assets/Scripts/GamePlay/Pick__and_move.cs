using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=JtflOvhOO1Y

[RequireComponent(typeof(Rigidbody))]
public class Pick__and_move : MonoBehaviour
{
    public GameObject guide;

    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = guide.transform.transform.position;
        transform.rotation = guide.transform.transform.rotation;
        transform.parent = guide.transform;
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        transform.position = guide.transform.position;
    }
}
