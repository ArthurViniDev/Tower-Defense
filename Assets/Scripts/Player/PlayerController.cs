using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public int money = 100;
    public GameObject[] weapons;
    public GameObject currentWeaponSelected;

    [Header("Weapon Selection/Placement")]
    public bool isMouseOverUI = false;
    public LayerMask nodeLayer;
    [SerializeField] private Vector3 weaponOffset;

    [Space]
    private Camera _camera;

    private const string TurretName = "weapon-turret";
    private const string CannonName = "weapon-cannon";

    public static PlayerController instance;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        //currentWeaponSelected = weapons[1];
        if (instance == null) instance = this;
        else DestroyImmediate(gameObject);
    }

    private void Update()
    {
        if (isMouseOverUI || !currentWeaponSelected) return;
        placeWeapons();
    }

    private void placeWeapons()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        // se apertar o botão direito do mouse:
        if (currentWeaponSelected.GetComponent<BaseWeapon>().price > money)
        {
            Debug.Log("No enough money");
            return;
        }

        if (!_camera) return; // se não houver um MainCamera na cena

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit, nodeLayer)) return;

        var hitNode = hit.collider.gameObject;
        if (!hit.collider.gameObject) Debug.Log("No hit");
        hitNode.GetComponent<Nodes>().PositionWeapon(currentWeaponSelected, weaponOffset);
    }

    public void SelectWeapon(string weaponName)
    {
        if (currentWeaponSelected && currentWeaponSelected.gameObject.name == weaponName) // se o player clicar no mesmo botão novamente, deseleciona a arma
        {
            currentWeaponSelected = null;
            return;
        }
        foreach (var weapon in weapons)
        {
            if (!currentWeaponSelected && weapon.gameObject.name == weaponName)
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
