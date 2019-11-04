using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiserScenario : MonoBehaviour
{
    public Scenario_Etape[] etapes_du_scenario;

    public AudioClip defaultEndStepSound = null;

    //Awake is always called before any Start functions
    void Awake(){
        if (_MGR_ScenarioManager.Instance) {
            _MGR_ScenarioManager.Instance.Configurer(etapes_du_scenario, defaultEndStepSound);


            if (InitializeRessources.IsInitialized &&
                Initialiser_TL_Events.IsInitialized &&
                InitializeUI.IsInitialized &&
                InitialiserGamePlayEtDemarrerPartie.IsInitialized)
            {
                _MGR_ScenarioManager.Instance.Demarrer();
            }
            else
                throw new System.Exception("Error during initialization");
        }
     }

}

