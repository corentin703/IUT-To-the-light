using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MGR_Ressources : MonoBehaviour
{
    // Singleton
    private static _MGR_Ressources p_instance = null;
    public static _MGR_Ressources Instance { get { return p_instance; } }

    [HideInInspector]
    public List<Ressource> lRessources { get; private set; }

    [HideInInspector]
    private Ressource m_ressourceInUse;
    //public Ressource ressourceInUse { get; private set; }

    void Awake()
    {
        // Singleton manager
        if (p_instance == null)
            p_instance = this;
        else if (p_instance != this)
            Destroy(gameObject);
    }

    public bool IsUsingRessource(out Ressource ressource)
    {
        if (m_ressourceInUse)
        {
            ressource = m_ressourceInUse;
            return true;
        }
        else
        {
            ressource = null;
            return false;
        }
    }

    public bool IsHavingRessource(Ressource ressource)
    {
        if (lRessources.Contains(ressource))
            return true;
        else
            return false;
    }

    public void AddRessource(Ressource ressource)
    {
        lRessources.Add(ressource);
    }

    public void DeleteRessource(Ressource ressource)
    {
        lRessources.Remove(ressource);

        Destroy(ressource);
    }


}
