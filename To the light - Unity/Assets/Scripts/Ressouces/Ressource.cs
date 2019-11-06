using UnityEngine;

public abstract class Ressource : PickableObject, IScenarioInteractable
{
    [SerializeField]
    protected string UniqueIdentifier;
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public virtual uint unitNumber { get; protected set; } = 1;

    //public static uint PickedNumber { get; protected set; } = 0;    
    public abstract uint PickedNumber { get; protected set; }

    //[SerializeField]
    //public abstract Sprite resIcon { get; set; }

    protected void Awake()
    {
        // Si on a pas défini l'identifiant, on prend le tag (la présence de l'identifiant unique est une volonté de ne pas surcharger les tags)
        if (UniqueIdentifier == null)
            UniqueIdentifier = gameObject.tag;
    }

    protected void Start()
    {
        base.Start();

        _MGR_Ressources.RessourceInfo infos = _MGR_Ressources.Instance.GetRessourceInfo(UniqueIdentifier);
        Name = infos.name;
        Description = infos.description;
    }

    public uint GetPickedNumber() { return PickedNumber; }

    //public Sprite GetIcon()
    //{
    //    return resIcon;
    //}

    public abstract void Add(uint num = 1);

    protected override void PickAction()
    {
        Add(unitNumber);
        _MGR_Ressources.Instance.AddRessource(this);
        gameObject.SetActive(false);
    }

    public bool IsValidated()
    {
        return _MGR_Ressources.Instance.lRessources.Contains(this);
    }
}
