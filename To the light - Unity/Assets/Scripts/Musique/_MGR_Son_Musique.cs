using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class _MGR_Son_Musique : MonoBehaviour
{
    private static _MGR_Son_Musique p_instance = null;
    public static _MGR_Son_Musique Instance { get { return p_instance; } }

    private List<AudioClip> m_backgroundAaudioClips;

    [SerializeField]
    private int MaximumNAudioSource = 0; // Infinit si = 0

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
    private List<AudioSource> p_listAudioSource = new List<AudioSource>();
    // un dictionnaire pour stocker et accéder aux sons du jeu depuis leur nom
    private Dictionary<string, AudioClip> p_sons = new Dictionary<string, AudioClip>();
    // initialisation du manager
    void Awake()
    {
        if (p_instance == null)
            p_instance = this;
        else if (p_instance != this)
            Destroy(gameObject);

        // Initialisation du Dictionaire
        foreach (Son son in sons)
        {
            p_sons.Add(son.nom, son.son);
        }
    }

    void Start()
    {
        if (p_sons.ContainsKey("backgroundSound"))
            PlaySound("backgroundSound");
    }

    // jouer un son du jeu
    // vérifier que le son existe
    // trouver un lecteur libre (audioSource) ou en ajouter un s'ils sont tous en lecture
    // jouer le son sur le lecteur libre (avec le délai fourni)
    public void PlaySound(string __nom, float __delay = 0)
    {
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

            if (MaximumNAudioSource == 0 || p_listAudioSource.Count <= MaximumNAudioSource)
            {
                // Création d'un nouveau GO contenant un AudioSource
                GameObject go = new GameObject("AudioSource" + (p_listAudioSource.Count + 1));
                AudioSource newAudioSource = go.AddComponent<AudioSource>();
                //Instantiate(newAudioSource); // Instancie un "clone" du GameObject, il est déjà instancé précedemment
                newAudioSource.clip = p_sons[__nom];
                newAudioSource.PlayDelayed(__delay);

                p_listAudioSource.Add(newAudioSource);
            }
            else
                Debug.Log("To many AudioSources in use !");
        }

        Debug.Log("Song not found");
    }
}