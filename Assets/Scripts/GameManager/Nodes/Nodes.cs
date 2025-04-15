using UnityEngine;

public class Nodes : MonoBehaviour
{
    [HideInInspector] public bool isBusyBode = false;
    [SerializeField] private Vector3 preTurretPositionOffset;
    [SerializeField] private GameObject[] preWeapon;
    [SerializeField] private Color onHoverColor;

    private GameObject _preTurretInstance;
    private Material _onHoverMaterial;
    private bool _hasPreTurret;

    private void Awake()
    {
        _onHoverMaterial = GetComponent<Renderer>().material;
    }

    private void OnMouseOver()
    {
        if (PlayerController.instance.isMouseOverUI)
        {
            OnMouseExit();
            return;
        }

        _onHoverMaterial.color = onHoverColor;

        if (_hasPreTurret || !PlayerController.instance.currentWeaponSelected) return;

        string weaponName = PlayerController.instance.currentWeaponSelected.gameObject.name;
        int weaponIndex = GetWeaponIndexByName(weaponName);

        if (weaponIndex != -1)
        {
            _preTurretInstance = Instantiate(preWeapon[weaponIndex], transform.position + preTurretPositionOffset, Quaternion.identity);
            _hasPreTurret = true;
        }
    }

    private void OnMouseExit()
    {
        _onHoverMaterial.color = Color.white;
        _hasPreTurret = false;
        DestroyImmediate(_preTurretInstance);
    }

    private int GetWeaponIndexByName(string weaponName)
    {
        switch (weaponName)
        {
            case "weapon-turret":
                return 0;
            case "weapon-cannon":
                return 1;
            default:
                return -1; // Retorna -1 se o nome da arma não for encontrado
        }
    }

    public void PositionWeapon(GameObject weapon, Vector3 offset)
    {
        if (isBusyBode) return;
        Instantiate(weapon, transform.position + offset, Quaternion.identity);
        isBusyBode = true;
    }
}
