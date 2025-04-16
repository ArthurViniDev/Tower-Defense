using UnityEngine;

public class WeaponWindow : MonoBehaviour
{
    private BaseWeapon _baseWeapon;
    private bool isWeaponScreenOpen;
    [SerializeField] private GameObject weaponScreen;

    private void Awake()
    {
        _baseWeapon = GetComponent<BaseWeapon>();
        weaponScreen = transform.GetChild(1).gameObject;
        isWeaponScreenOpen = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !isWeaponScreenOpen)
        {
            weaponScreen.SetActive(true);
        }
    }

    public void CloseWindow()
    {
        weaponScreen.SetActive(false);
        isWeaponScreenOpen = false;
    }
}
