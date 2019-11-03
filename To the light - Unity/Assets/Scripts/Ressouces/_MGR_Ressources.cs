using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MGR_Ressources : MonoBehaviour
{
    // Singleton
    private static _MGR_Ressources p_instance = null;
    public static _MGR_Ressources Instance { get { return p_instance; } }

    [HideInInspector]
    public List<Ressource> lRessources { get; private set; } = new List<Ressource>();

    private Ressource m_ressourceInUse;

    [System.Serializable]
    public struct RessourceInfo
    {
        public string uniqueIdentifier;
        public string name;
        public string description;

        public RessourceInfo(string uniqueIdentifier, string name, string description)
        {
            this.uniqueIdentifier = uniqueIdentifier;
            this.name = name;
            this.description = description;
        }
    }

    private Dictionary<string, RessourceInfo> dRessourcesInfos = new Dictionary<string, RessourceInfo>();

    void Awake()
    {
        // Singleton manager
        if (p_instance == null)
            p_instance = this;
        else if (p_instance != this)
            Destroy(gameObject);
    }

    public void SetUp(List<RessourceInfo> lRessoucesInfos)
    {
        foreach (RessourceInfo ressourceInfo in lRessoucesInfos)
            dRessourcesInfos.Add(ressourceInfo.uniqueIdentifier, ressourceInfo);
    }

    public RessourceInfo GetRessourceInfo(string uniqueIdentifier)
    {
        if (dRessourcesInfos.Count == 0)
            throw new System.Exception("Ressources manager is not set up correctly");
        else if (dRessourcesInfos.ContainsKey(uniqueIdentifier))
            return dRessourcesInfos[uniqueIdentifier];
        //else if (uniqueIdentifier == "undefined")
        //    return new RessourceInfo(uniqueIdentifier, "Undefined name", "Undefined description");
        else
            throw new System.Exception("No ressource corresponding with the given id");
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

    public void AddRessource(Ressource ressource)
    {
        // Si c'est la première du nom a avoir été prise, on l'ajoute à la liste
        lRessources.Add(ressource);
    }

    public void DeleteRessource(Ressource ressource)
    {
        lRessources.Remove(ressource);

        Destroy(ressource);
    }


}
