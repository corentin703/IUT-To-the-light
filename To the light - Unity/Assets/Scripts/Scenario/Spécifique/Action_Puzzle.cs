using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Puzzle : Action_Scenario_Etape
{
    [SerializeField]
    private Puzzle m_puzzle;

    public override void Update()
    {
        if (m_puzzle.IsCompleted)
        {
            Declencher_Etape_Suivante_Du_Scenario();
        } 
    }
}
