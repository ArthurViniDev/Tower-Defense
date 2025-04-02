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

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Awake()
    {
        currentWeaponSelected = weapons[0];
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
        if (Input.GetMouseButtonDown(1))
        {
            if (currentWeaponSelected.GetComponent<BaseWeapon>().price > money)
            {
                Debug.Log("No enough money");
                return;
            }
            if (_camera)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, nodeLayer))
                {
                    GameObject hitNode = hit.collider.gameObject;
                    hitNode.GetComponent<Nodes>().PositionWeapon(currentWeaponSelected, weaponOffset);
                    
                }
            }
        }
    }
}

