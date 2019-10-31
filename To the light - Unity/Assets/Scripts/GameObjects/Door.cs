using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Door : MonoBehaviour, IScenarioInteractable
{
    [SerializeField] private float pickDistance = 5;
    private LayerMask layerMask;

    private Animator animator;

    public List<Ressource> lGameObjectsNeeded = new List<Ressource>();

    [HideInInspector]
    public bool isOpened = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        isOpened = animator.GetBool("isOpened");

        layerMask = LayerMask.GetMask("Toggable");
        gameObject.layer = layerMask;

        // Vérifie qu'il n'y ai pas deux objets identiques
        List<Ressource> temp = new List<Ressource>();

        foreach (Ressource res in lGameObjectsNeeded)
        {
            foreach (Ressource res2 in temp)
            {
                if (res2.GetName() == res.GetName())
                    throw new System.Exception("You can't unlock a door with 2 same objects !");
            }

            temp.Add(res);
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, pickDistance, layerMask))
            {
                if (hitInfo.transform.gameObject == gameObject)
                {
                    if (lGameObjectsNeeded.Count == 0)
                    {
                        _MGR_Son_Musique.Instance.PlaySound(gameObject.tag);
                        
                        isOpened = !isOpened;
                        animator.SetBool("isOpened", isOpened);
                    }
                    else
                    {
                        foreach (Ressource ressource in lGameObjectsNeeded)
                        {
                            if (_MGR_Ressources.Instance.lRessources.Contains(ressource))
                                lGameObjectsNeeded.Remove(ressource);
                        }
                    }
                }
            }
        }
    }

    public bool IsValidated()
    {
        return isOpened;
    }
}
