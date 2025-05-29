using UnityEngine;

public class PreWeapons : MonoBehaviour
{
    private Material _thisMaterial;

    private void Awake()
    {
        _thisMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (PlayerController.Instance.currentWeaponSelected == null) return;
        if (PlayerController.Instance.money < PlayerController.Instance.currentWeaponSelected.GetComponent<BaseWeapon>().price)
        {
            _thisMaterial.color = Color.red;
        }
        else
        {
            _thisMaterial.color = Color.green;
        }
    }
}
