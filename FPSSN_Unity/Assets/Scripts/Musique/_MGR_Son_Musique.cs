using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class _MGR_Son_Musique : MonoBehaviour
{
    private static _MGR_Son_Musique p_instance = null;
    public static _MGR_Son_Musique Instance { get { return p_instance; } }
    [System.Serializable]
    public struct Son
    {
        public string nom;
        public AudioClip son;
    }
    // tous les sons à utiliser dans le jeu
    // seront initialisés à la création du manager, dans la scène _preload
    public Son[] sons;
    // tous les audio source prêts à jouer un son
    // plusieurs peuvent être nécessaires car plusieurs sons simultanés possible (e.g. musique+son FX)
    private List<AudioSource> p_listAudioSource;
    // un dictionnaire pour stocker et accéder aux sons du jeu depuis leur nom
    private Dictionary<string, AudioClip> p_sons;
    // initialisation du manager
    void Awake()
    { // à compléter //

      // ===>> SingletonMAnager

        //Check if instance already exists
        if (p_instance == null)
            //if not, set instance to this
            p_instance = this;
        //If instance already exists and it's not this:
        else if (p_instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    // jouer un son du jeu
    // vérifier que le son existe
    // trouver un lecteur libre (audioSource) ou en ajouter un s'ils sont tous en lecture
    // jouer le son sur le lecteur libre (avec le délai fourni)
    public void PlaySound(string __nom, float __delay = 0)
    { // à compléter //

        if (p_sons.ContainsKey(__nom))
        {
            foreach (AudioSource audioSource in p_listAudioSource)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = p_sons[__nom];
                    audioSource.PlayDelayed(__delay);

                    return;
                }
            }
            AudioSource audioSourceEnPlus = gameObject.AddComponent<AudioSource>();
            audioSourceEnPlus.clip = p_sons[__nom];
            audioSourceEnPlus.PlayDelayed(__delay);
        }

    }
}