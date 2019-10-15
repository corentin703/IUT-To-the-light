using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MGR_GamePlay : MonoBehaviour {

    [System.Serializable]
    public class Bonus
    {
        public string nom;
        public int bonus;
    }

    private static _MGR_GamePlay p_instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public static _MGR_GamePlay Instance { get { return p_instance; } }

    public uint score { get; private set; }
    public Bonus[] tabBonus;
    Dictionary<string, int> p_dicBonus;

    // Use this for initialization
    void Awake()
    {
        // ===>> SingletonMAnager

        //Check if instance already exists
        if (p_instance == null)
            //if not, set instance to this
            p_instance = this;
        //If instance already exists and it's not this:
        else if (p_instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene
        // DontDestroyOnLoad(gameObject);   par nécessaire ici car déja fait par script __DDOL sur l'objet _EGO_app qui recueille tous les mgr

        p_dicBonus = new Dictionary<string, int>();

        foreach (Bonus _bonus in tabBonus)
            p_dicBonus.Add(_bonus.nom, _bonus.bonus);
    }

    public void StartPlay()
    {
        _MGR_TimeLine.Instance.StartChrono();
    }

    public uint IncreaseScore(int _bonus)
    {
        //return (score = (score - _bonus > 0) ? (uint)(score - _bonus) : 0);
        return (score = (score + _bonus > 0) ? (uint)(score + _bonus) : 0);
    }

    public uint IncreaseScore(string _strBonus)
    {
        int __bonus;

        if (!p_dicBonus.ContainsKey(_strBonus))
        {
            CommonDevTools.ERROR("type de bonus non défini : " + _strBonus, this.gameObject);
            __bonus = 0;
        }
        else
            __bonus = p_dicBonus[_strBonus];

        return IncreaseScore(__bonus);
    }
}
