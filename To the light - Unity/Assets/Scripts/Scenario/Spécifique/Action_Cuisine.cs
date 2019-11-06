using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Cuisine : Action_Scenario_Etape
{
    [SerializeField]
    private Ressource m_key;

    [SerializeField]
    private Door m_door;

    [SerializeField]
    private Knife m_knife;

    private float m_chrono = 0f;

    private void Start()
    {
        m_door.IsLocked = true;
    }

    public override void Update()
    {
        if (_MGR_Ressources.Instance.lRessources.Contains(m_key))
            m_door.IsLocked = false;

        if (m_door.IsOpened)
        {
            if (m_chrono == 0f)
            {
                m_chrono = _MGR_TimeLine.Instance.chrono;
            }
            else
            {
                if ((_MGR_TimeLine.Instance.chrono - m_chrono) > 1.8f && !m_knife.HasBeenThrowed)
                {
                    m_knife.Throw();

                    m_chrono = _MGR_TimeLine.Instance.chrono;
                }

                if (m_knife.HasBeenThrowed)
                    Declencher_Etape_Suivante_Du_Scenario();
            }   
        }
    }

    public override void Declencher_Etape_Suivante_Du_Scenario()
    {
        m_door.IsLocked = false;
        base.Declencher_Etape_Suivante_Du_Scenario();
    }
}
