using UnityEngine;

public abstract class Ressource : PickableObject, IScenarioInteractable
{
    public abstract string Name { get; set; }
    public abstract string Descrition { get; set; }
    public abstract uint unitNumber { get; set; }

    //public static uint Number { get; protected set; } = 0;

    //[SerializeField]
    //public abstract Sprite resIcon { get; set; }

    protected void Start()
    {
        //Ressource.Number += unitNumber;
        if (Name == null || Name == "")
            Name = name;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetDescription()
    {
        return Descrition;
    }

    public abstract uint GetPickedNumber();

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
