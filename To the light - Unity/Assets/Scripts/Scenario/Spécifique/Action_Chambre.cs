using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Chambre : Action_Scenario_Etape
{
    [SerializeField]
    private Ressource m_key;

    [SerializeField]
    private Ressource m_torche;

    [SerializeField]
    private Door m_door;

    private void Start()
    {
        m_door.IsLocked = true;
    }

    public override void Update()
    {
        if (_MGR_Ressources.Instance.lRessources.Contains(m_torche) &&
        _MGR_Ressources.Instance.lRessources.Contains(m_key))
            Declencher_Etape_Suivante_Du_Scenario();
    }

    public override void Declencher_Etape_Suivante_Du_Scenario()
    {
        m_door.IsLocked = false;
        base.Declencher_Etape_Suivante_Du_Scenario();
    }
}
