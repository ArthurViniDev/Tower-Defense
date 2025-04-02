using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject currentWeaponSelected;
    public int money = 100;

    public static PlayerController playerControllerSingleton;
    
    public GameObject[] weapons;
    public LayerMask nodeLayer;
    [SerializeField] private Vector3 weaponOffset;

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, nodeLayer))
            {
                GameObject hitObject = hit.collider.gameObject;
                Instantiate(currentWeaponSelected, hitObject.transform.position + weaponOffset, Quaternion.identity);
            }
        }
    }
}
