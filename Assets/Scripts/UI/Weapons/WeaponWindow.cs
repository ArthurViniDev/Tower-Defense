using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWindow : MonoBehaviour
{
    [Header("Base Weapon Screen")]
    [HideInInspector] public GameObject currentNode;
    [SerializeField] private Button sellButton;
    private GameObject weaponScreen;
    private BaseWeapon _baseWeapon;
    private bool isWeaponScreenOpen;

    private void Awake()
    {
        _baseWeapon = GetComponent<BaseWeapon>();
        weaponScreen = transform.GetChild(1).gameObject;
        isWeaponScreenOpen = false;
        sellButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Refund (${_baseWeapon.refundValue})";
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !isWeaponScreenOpen && PlayerController.instance.weaponsWindowsOpenend == 0)
        {
            weaponScreen.SetActive(true);
            PlayerController.instance.weaponsWindowsOpenend++;
        }
    }

    public void CloseWindow()
    {
        weaponScreen.SetActive(false);
        isWeaponScreenOpen = false;
        PlayerController.instance.weaponsWindowsOpenend--;
    }

    public void SellTurret()
    {
        PlayerController.instance.money += _baseWeapon.refundValue;
        currentNode.GetComponent<Nodes>().isBusyNode = false;
        DestroyImmediate(gameObject);
    }

    public void UpgradeTurret()
    {
        // Upgrade logic
    }
}
