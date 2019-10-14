using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeStelle : Action_Scenario_Etape
{
    private static EnigmeStelle p_instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public static EnigmeStelle Instance { get { return p_instance; } }

    [SerializeField]
    private GameObject GOToDeleteOnComplete;

    void Awake()
    {
        if (p_instance == null)

            p_instance = this;
        else if (p_instance != this)
            Destroy(gameObject);
    }

    public override void Update()
    {
        return;
    }

    override public void Declencher_Etape_Suivante_Du_Scenario()
    {
        Destroy(GOToDeleteOnComplete);

        base.Declencher_Etape_Suivante_Du_Scenario();
    }






}
