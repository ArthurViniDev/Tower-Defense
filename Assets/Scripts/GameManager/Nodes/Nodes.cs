using UnityEngine;

public class Nodes : MonoBehaviour
{
    [SerializeField] private Material onHoverMaterial;
    [SerializeField] private Color onHoverColor;

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
}
