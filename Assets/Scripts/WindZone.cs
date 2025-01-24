using UnityEngine;

public class WindZone : MonoBehaviour
{
    [Header("Wind Settings")]
    public Vector3 windDirection = new Vector3(1f, 0f, 0f); // Direction du vent
    public float windStrength = 5f; // Force du vent

    private void OnTriggerStay(Collider other)
    {
        // Vérifie si l'objet possède un Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Applique une force constante dans la direction du vent
            rb.AddForce(windDirection.normalized * windStrength, ForceMode.Force);
        }
    }

    private void OnDrawGizmos()
    {
        // Dessine la zone de vent
        Gizmos.color = new Color(0.5f, 0.8f, 1f, 0.3f); // Couleur semi-transparente pour la zone
        Gizmos.DrawCube(transform.position, transform.localScale);

        // Dessine la direction du vent
        Gizmos.color = Color.blue;
        Vector3 start = transform.position;
        Vector3 end = start + windDirection.normalized * windStrength;

        // Flèche pour visualiser la direction
        Gizmos.DrawLine(start, end);
        Gizmos.DrawSphere(end, 0.1f); // Pointe de la flèche
    }
}
