using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public GameObject currentWeaponSelected;
    public GameObject[] weapons;
    public int money = 100;

    [Header("Weapon Selection/Placement")]
    [SerializeField] private Vector3 weaponOffset;
    public bool isMouseOverUI = false;
    public LayerMask nodeLayer;

    [Space]
    private Camera _camera;

    private const string TurretName = "weapon-turret";
    private const string CannonName = "weapon-cannon";

    public static PlayerController instance; // Singleton instance

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
        if (isMouseOverUI || !currentWeaponSelected) return;
        placeWeapons();
    }

    private void placeWeapons()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // se apertar o botão direito do mouse:
            if (currentWeaponSelected.GetComponent<BaseWeapon>().price > money)
            {
                currentWeaponSelected = null; // se o player não tiver dinheiro suficiente, deseleciona a arma
                return;
            }

            if (!_camera) return; // se não houver um MainCamera na cena

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, nodeLayer))
            {
                var hitNode = hit.collider.gameObject;
                Debug.Log(hitNode.gameObject.layer, hitNode.gameObject);

                if (hit.collider.gameObject) hitNode.GetComponent<Nodes>().PositionWeapon(currentWeaponSelected, weaponOffset);
            }
        }
        else if (Input.GetMouseButtonUp(1) && currentWeaponSelected.GetComponent<BaseWeapon>().price > money)
        {
            currentWeaponSelected = null; // se o player não tiver dinheiro suficiente, deseleciona a arma
        }
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
