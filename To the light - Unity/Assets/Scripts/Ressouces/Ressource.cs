using UnityEngine;

public class Ressource : PickableObject, IScenarioInteractable
{
    [SerializeField]
    private string resName;
    [SerializeField]
    private string resDescription;

    [SerializeField]
    private int resNumber = 1;

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

    public int GetNumber()
    {
        return resNumber;
    }

    //public Sprite GetIcon()
    //{
    //    return resIcon;
    //}

    public void Add(int num = 1)
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
