using UnityEngine;

public class MenuItemCollapser : MonoBehaviour
{
    public GameObject Target;

    public void Collapse()
    {
        Target.SetActive(!Target.activeInHierarchy);
    }	
}
