using UnityEngine;

public class Nodes : MonoBehaviour
{
    private Material _onHoverMaterial;
    [SerializeField] private Color onHoverColor;
    [HideInInspector] public bool isBusyBode = false;
    
    [SerializeField] private GameObject preTurret;
    [SerializeField] private Vector3 preTurretPositionOffset;
    private GameObject _preTurretInstance;
    
    private bool _hasPreTurret = false;

    private void Awake()
    {
        _onHoverMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (PlayerController.playerControllerSingleton.isMouseOverUI) OnMouseExit();
    }

    private void OnMouseOver()
    {
        if (PlayerController.playerControllerSingleton.isMouseOverUI) return;
        _onHoverMaterial.color = onHoverColor;

        if (PlayerController.playerControllerSingleton.currentWeaponSelected.gameObject.name == "weapon-turret" && !_hasPreTurret)
        {
            _preTurretInstance = Instantiate(preTurret, transform.position + preTurretPositionOffset, Quaternion.identity);
            _hasPreTurret = true;
        }
    }

    private void OnMouseExit()
    {
        _onHoverMaterial.color = Color.white;
        _hasPreTurret = false;
        DestroyImmediate(_preTurretInstance);
        _preTurretInstance = null;
    }

    public void PositionWeapon(GameObject weapon, Vector3 offset)
    {
        if (isBusyBode) return;
        Instantiate(weapon, transform.position + offset, Quaternion.identity);
        isBusyBode = true;
    }
}
