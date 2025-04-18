using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // Singleton instance
    private const string TurretName = "weapon-turret";
    private const string CannonName = "weapon-cannon";

    [Header("Player Settings")]
    public GameObject currentWeaponSelected;
    public GameObject[] weapons;
    public int money = 100;

    [Header("Weapon Selection/Placement")]
    [SerializeField] private Vector3 weaponOffset;
    public bool isMouseOverUI = false;
    public LayerMask nodeLayer;

    [HideInInspector] public int weaponsWindowsOpenend;
    private Camera _camera;


    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else DestroyImmediate(gameObject);
    }

    private void Update()
    {
        Debug.Log(weaponsWindowsOpenend);
        if (isMouseOverUI || !currentWeaponSelected) return;
        placeWeapons();
    }

    private void placeWeapons()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (currentWeaponSelected.GetComponent<BaseWeapon>().price > money)
            {
                currentWeaponSelected = null;
                return;
            }

            if (!_camera) return;

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, nodeLayer))
            {
                var hitNode = hit.collider.gameObject;

                if (hit.collider.gameObject) hitNode.GetComponent<Nodes>().PositionWeapon(currentWeaponSelected, weaponOffset);
            }
        }
        else if (Input.GetMouseButtonUp(1) && currentWeaponSelected.GetComponent<BaseWeapon>().price > money) currentWeaponSelected = null;
    }

    public void SelectWeapon(string weaponName)
    {
        if (currentWeaponSelected && currentWeaponSelected.gameObject.name == weaponName)
        {
            currentWeaponSelected = null;
            return;
        }
        foreach (var weapon in weapons)
        {
            if (weapon.gameObject.name == weaponName)
            {
                currentWeaponSelected = weapon;
                return;
            }
        }
    }
    public void SelectCannon()
    {
        SelectWeapon(CannonName);
    }

    public void SelectTurret()
    {
        SelectWeapon(TurretName);
    }

    public void MouseOverButtons()
    {
        isMouseOverUI = !isMouseOverUI;
    }
}
