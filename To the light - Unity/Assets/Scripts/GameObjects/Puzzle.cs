using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : PickableObject
{
    [HideInInspector]
    public bool IsCompleted { get; private set; } = false;

    [SerializeField]
    private GameObject m_puzzleCube;

    [SerializeField]
    private GameObject m_puzzleCylinder;

    void Awake()
    { 
        if (!m_puzzleCube || !m_puzzleCylinder)
            throw new System.Exception("Error in \"Action_Puzzle\" inspector settings");

        m_puzzleCube.SetActive(false);
        m_puzzleCylinder.SetActive(false);
    }

    protected override void PickAction()
    {
        bool temp = false;

        foreach (Ressource ressource in _MGR_Ressources.Instance.lRessources)
        {
            if (_MGR_Ressources.Instance.lRessources.Contains(ressource))
            {
                if (ressource.GetType() == typeof(PuzzleCube))
                {
                    m_puzzleCube.SetActive(true);
                    temp = true;
                }
                else if(ressource.GetType() == typeof(PuzzleCylinder))
                {
                    m_puzzleCylinder.SetActive(true);

                    if (temp)
                    {
                        IsCompleted = true;
                        return;
                    }
                }
            }
        }
    }
}
