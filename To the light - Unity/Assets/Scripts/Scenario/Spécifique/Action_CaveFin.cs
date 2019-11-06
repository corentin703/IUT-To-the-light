using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_CaveFin : Action_Scenario_Etape
{
    [SerializeField]
    private Key m_caveKey;

    [SerializeField]
    private Door m_caveDoor;

    [SerializeField]
    private Crowbar m_crowbar;

    [SerializeField]
    private Door m_exitDoor;

    void Awake()
    {
        m_caveKey.gameObject.GetComponent<Rigidbody>().useGravity = false;
        m_caveDoor.IsLocked = true;
        m_exitDoor.IsLocked = true;
    }

    public override void Update()
    {
        if (!m_caveKey.gameObject.GetComponent<Rigidbody>().useGravity)
            m_caveKey.gameObject.GetComponent<Rigidbody>().useGravity = true;

        if (_MGR_Ressources.Instance.lRessources.Contains(m_caveKey))
            m_caveDoor.IsLocked = false;

        if (_MGR_Ressources.Instance.lRessources.Contains(m_crowbar))
            m_exitDoor.IsLocked = false;

        if (m_exitDoor.IsOpened)
            Declencher_Etape_Suivante_Du_Scenario();
    }
}
