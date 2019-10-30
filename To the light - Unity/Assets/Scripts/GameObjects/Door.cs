using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Door : MonoBehaviour
{
    [SerializeField] private float pickDistance = 5;
    private LayerMask layerMask;

    private Animator animator;

    // TODO: Mettre le système d'objet(s) nécéssaire(s) (genre des clés) au point quand l'inventaire sera finalisé
    [HideInInspector] // À supprimer lors de cette mise en place afin de permettre l'édition
    public List<Ressource> gameObjectsNeeded = new List<Ressource>();

    [HideInInspector]
    public bool isOpened = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        isOpened = animator.GetBool("isOpened");

        layerMask = LayerMask.GetMask("Toggable");
        gameObject.layer = layerMask;
    }

    void Update()
    {
        if (gameObjectsNeeded.Count == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo = new RaycastHit();

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, pickDistance, layerMask))
                {
                    if (hitInfo.transform.gameObject == gameObject)
                    {
                        //Debug.Log("Opening a door");
                        isOpened = !isOpened;
                        animator.SetBool("isOpened", isOpened);
                    }
                }
            }
        }
        else
        {
            foreach (Ressource ressource in gameObjectsNeeded)
            {
                if (_MGR_Ressources.Instance.lRessources.Contains(ressource))
                    gameObjectsNeeded.Remove(ressource);
            }
        }
    }
}
