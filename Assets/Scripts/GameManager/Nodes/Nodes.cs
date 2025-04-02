using UnityEngine;

public class Nodes : MonoBehaviour
{
    [SerializeField] private Material onHoverMaterial;
    [SerializeField] private Color onHoverColor;
    [HideInInspector] public bool isBusyBode = false;

    private void Awake()
    {
        onHoverMaterial = GetComponent<Renderer>().material;
    }

    private void OnMouseOver()
    {
        onHoverMaterial.color = onHoverColor;
    }

    private void OnMouseExit()
    {
        onHoverMaterial.color = Color.white;
    }

    public void PositionWeapon(GameObject weapon, Vector3 offset)
    {
        if (isBusyBode) return;
        Instantiate(weapon, transform.position + offset, Quaternion.identity);
        isBusyBode = true;
    }
}
