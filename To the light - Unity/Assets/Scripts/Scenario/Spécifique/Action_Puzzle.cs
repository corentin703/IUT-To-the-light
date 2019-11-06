using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Puzzle : Action_Scenario_Etape
{
    [SerializeField]
    private GameObject m_puzzleCube;

    [SerializeField]
    private GameObject m_puzzleCylinder;

    [SerializeField]
    private Puzzle m_puzzle;

    [SerializeField]
    private Ressource[] m_ressources;

    void Awake()
    {
        if (m_ressources.Length == 0 || !m_puzzleCube || !m_puzzleCylinder)
            throw new System.Exception("Error in \"Action_Puzzle\" inspector settings");

        m_puzzleCube.SetActive(false);
        m_puzzleCylinder.SetActive(false);

        foreach (Ressource ressource in m_ressources)
        {
            Debug.LogWarning(ressource.GetType());
        }
    }

    public override void Update()
    {
        if (m_puzzle.HasBeenPressed)
        {
            m_puzzle.HasBeenPressed = false;
            foreach (Ressource ressource in m_ressources)
            {
                if (_MGR_Ressources.Instance.lRessources.Contains(ressource))
                {
                    if (ressource.GetType() == typeof(PuzzleCube))
                        m_puzzleCube.SetActive(true);
                        
                    if (ressource.GetType() == typeof(PuzzleCylinder))
                        m_puzzleCylinder.SetActive(true);
                }
                else
                    return;
            }

            Declencher_Etape_Suivante_Du_Scenario();
        } 
    }
}
