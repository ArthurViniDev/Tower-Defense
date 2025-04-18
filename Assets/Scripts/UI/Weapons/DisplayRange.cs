using UnityEngine;

public class DisplayRange : MonoBehaviour
{
    public float radius;
    public int segments = 100;
    private BaseWeapon baseWeapon;

    private void Awake()
    {
        baseWeapon = GetComponent<BaseWeapon>();
        if (baseWeapon == null)
        {
            Debug.LogWarning("BaseWeapon component not found on the GameObject.");
            enabled = false; // Disable this script if BaseWeapon is not found
        }
        radius = baseWeapon.range;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 lastPos = transform.position + Vector3.right * radius;

        for (int i = 1; i <= segments; i++)
        {
            float angulo = i * Mathf.PI * 2f / segments;
            Vector3 posNova = transform.position + new Vector3(Mathf.Cos(angulo), 0, Mathf.Sin(angulo)) * radius;
            Gizmos.DrawLine(lastPos, posNova);
            lastPos = posNova;
        }
    }
}
