using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWindow : MonoBehaviour
{
    [Header("Base Weapon Screen")]
    private bool isWeaponScreenOpen;
    private GameObject weaponScreen;
    private BaseWeapon _baseWeapon;
    [SerializeField] private Button refundButton;

    private void Awake()
    {
        _baseWeapon = GetComponent<BaseWeapon>();
        weaponScreen = transform.GetChild(1).gameObject;
        isWeaponScreenOpen = false;
        refundButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Refund (${_baseWeapon.refundValue})";
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
