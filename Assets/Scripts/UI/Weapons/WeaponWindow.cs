using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWindow : MonoBehaviour
{
    [Header("Base Weapon Screen")]
    [HideInInspector] public GameObject currentNode;
    [SerializeField] private Button sellButton;
    private GameObject _weaponScreen;
    private BaseWeapon _baseWeapon;
    private DisplayRange _displayRange;
    private bool _isWeaponScreenOpen;

    private void Awake()
    {
        _displayRange = GetComponent<DisplayRange>();
        _baseWeapon = GetComponent<BaseWeapon>();
        _weaponScreen = transform.GetChild(1).gameObject;
        _isWeaponScreenOpen = false;
        sellButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Refund (${_baseWeapon.refundValue})";
    }

    private void Update()
    {
        _displayRange.drawGizmos = _weaponScreen.activeSelf;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !_isWeaponScreenOpen && PlayerController.Instance.weaponsWindowsOpened == 0)
        {
            _weaponScreen.SetActive(true);
            PlayerController.Instance.weaponsWindowsOpened++;
        }
    }

    public void CloseWindow()
    {
        _weaponScreen.SetActive(false);
        _isWeaponScreenOpen = false;
        PlayerController.Instance.weaponsWindowsOpened--;
    }

    public void SellTurret()
    {
        PlayerController.Instance.money += _baseWeapon.refundValue;
        currentNode.GetComponent<Nodes>().isBusyNode = false;
        DestroyImmediate(gameObject);
    }

    public void UpgradeTurret()
    {
        // Upgrade logic
    }
}
