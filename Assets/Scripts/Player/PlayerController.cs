using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance; // Singleton instance
    private const string TURRET_NAME = "weapon-turret";
    private const string CANNON_NAME = "weapon-cannon";

    [Header("Player Settings")]
    public GameObject currentWeaponSelected;
    public GameObject[] weapons;
    public int money = 100;

    [Header("Weapon Selection/Placement")]
    [SerializeField] private Vector3 weaponOffset;
    public bool isMouseOverUI = false;
    public LayerMask nodeLayer;

    [HideInInspector] public int weaponsWindowsOpened;
    private Camera _camera;


    private void Start() => _camera = Camera.main;
    

    private void Awake()
    {
        if (!Instance) Instance = this;
        else DestroyImmediate(gameObject);
    }

    private void Update()
    {
        if (isMouseOverUI || !currentWeaponSelected) return;
        PlaceWeapons();
    }

    private void PlaceWeapons()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!currentWeaponSelected) return;

            var weaponScript = currentWeaponSelected.GetComponent<BaseWeapon>();
            if (!weaponScript) return;

            if (weaponScript.price > money)
            {
                currentWeaponSelected = null;
                return;
            }

            if (!_camera) return;

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, nodeLayer))
            {
                var hitNode = hit.collider.gameObject;
                var nodeScript = hitNode.GetComponent<Nodes>();
                if (nodeScript) nodeScript.PositionWeapon(currentWeaponSelected, weaponOffset);
            }
        }
    }


    private void SelectWeapon(string weaponName)
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
    public void SelectCannon() => SelectWeapon(CANNON_NAME);
    

    public void SelectTurret() => SelectWeapon(TURRET_NAME);
    

    public void MouseOverButtons() => isMouseOverUI = !isMouseOverUI;
}
