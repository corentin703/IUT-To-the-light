using UnityEngine;

public class Ressource : PickableObject, IScenarioInteractable
{
    [SerializeField]
    private string resName;
    [SerializeField]
    private string resDescription;

    [SerializeField]
    private uint resNumber = 1;

    //[SerializeField]
    //private Sprite resIcon;
    
    public string GetName()
    {
        return resName;
    }

    public string GetDescription()
    {
        return resDescription;
    }

    public uint GetNumber()
    {
        return resNumber;
    }

    public void SetNumber(uint number)
    {
        resNumber = number;
    }

    //public Sprite GetIcon()
    //{
    //    return resIcon;
    //}

    public void Add(uint num = 1)
    {
        resNumber += num;
    }

    protected override void PickAction()
    {
        _MGR_Ressources.Instance.AddRessource(this);
        gameObject.SetActive(false);
    }

    public bool IsValidated()
    {
        if (_MGR_Ressources.Instance.lRessources.Contains(this))
            return true;
        else
            return false;
    }
}
