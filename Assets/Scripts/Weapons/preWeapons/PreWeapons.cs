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
        if (PlayerController.playerControllerSingleton.currentWeaponSelected == null) return;
        if (PlayerController.playerControllerSingleton.money < PlayerController.playerControllerSingleton.currentWeaponSelected.GetComponent<BaseWeapon>().price)
        {
            _thisMaterial.color = Color.red;
        }
        else
        {
            _thisMaterial.color = Color.green;
        }
    }
}
