using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject currentWeaponSelected;
    public int money = 100;

    public static PlayerController playerControllerSingleton;
    
    public GameObject[] weapons;
    public LayerMask nodeLayer;
    [SerializeField] private Vector3 weaponOffset;
    private Camera _camera;
    
    private const string TurretName = "weapon-turret";
    private const string CannonName = "weapon-cannon";
    
    public bool isMouseOverUI = false;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        currentWeaponSelected = weapons[1];
        if (playerControllerSingleton == null)
        {
            playerControllerSingleton = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Update()
    {
        if (isMouseOverUI) return;
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

        if (!_camera) return; // se houver um MainCamera na cena
        
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
            
        if (!Physics.Raycast(ray, out var hit, nodeLayer)) return;
            
        var hitNode = hit.collider.gameObject;
        if (!hit.collider.gameObject) Debug.Log("No hit");
        hitNode.GetComponent<Nodes>().PositionWeapon(currentWeaponSelected, weaponOffset);
    }

    public void SelectCannon()
    {
        Debug.Log("Select cannon");
        foreach (var weapon in weapons)
        {
            if (weapon.gameObject.name == CannonName)
            {
                currentWeaponSelected = weapon;
            }
        }
    }
    public void SelectTurret()
    {
        Debug.Log("Select turret");
        foreach (var weapon in weapons)
        {
            if (weapon.gameObject.name == TurretName)
            {
                currentWeaponSelected = weapon;
            }
        }
    }

    public void MouseOverButtons()
    {
        isMouseOverUI = !isMouseOverUI;
    }
}
