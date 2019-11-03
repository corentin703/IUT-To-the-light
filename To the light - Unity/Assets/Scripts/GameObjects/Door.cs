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

    private bool m_isOpened = false;
    public bool IsOpened
    {
        get { return m_isOpened; }
        set
        {
            m_isOpened = value;

            animator.SetBool("isOpened", m_isOpened);

            if (m_isOpened)
                _MGR_Son_Musique.Instance.PlaySound(gameObject.tag);
        }
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        m_isOpened = animator.GetBool("isOpened");

        string layerName = "Toggable";

        layerMask = LayerMask.GetMask(layerName);
        gameObject.layer = LayerMask.NameToLayer(layerName);

        // Vérifie qu'il n'y ai pas deux objets identiques
        List<Ressource> temp = new List<Ressource>();

        foreach (Ressource res in lGameObjectsNeeded)
        {
            if (temp.Contains(res))
                throw new System.Exception("You can't unlock a door with 2 same objects !");

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
                        IsOpened = !IsOpened;
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
        return IsOpened;
    }

}
