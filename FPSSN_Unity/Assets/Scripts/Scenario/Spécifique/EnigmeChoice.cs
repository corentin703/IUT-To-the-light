using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeChoice : Action_Scenario_Etape
{
    private static EnigmeChoice p_instance = null;       
    public static EnigmeChoice Instance { get { return p_instance; } }

    [SerializeField]
    private List<Choice> lChoices = new List<Choice>();

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

    public void Verify(GameObject gameObject)
    {
        foreach (Choice element in lChoices)
        {
            if (element.gameObject == gameObject)
            {
                if (element.isRightChoice)
                {
                    Debug.Log("Vous avez fait le bon choix");
                    Declencher_Etape_Suivante_Du_Scenario();
                }
                else
                {
                    _MGR_TimeLine.Instance.FinDePartie();
                    _MGR_SceneManager.Instance.FinDePartie(_MGR_SceneManager.FIN_DE_PARTIE.PERDU_BAD_CHOICE);
                }
            }
        }
    }

    public override void Declencher_Etape_Suivante_Du_Scenario()
    {
        Destroy(GOToDeleteOnComplete);

        base.Declencher_Etape_Suivante_Du_Scenario();
    }
}
