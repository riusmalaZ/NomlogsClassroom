using UnityEngine;

public class Dandiner : MonoBehaviour
{
    public float rotationAngle = 30f; // Angle maximal de la rotation (en degrés)
    public float speed = 2f;          // Vitesse de l'oscillation (plus c'est élevé, plus c'est rapide)

    private float targetAngle;        // L'angle cible de la rotation
    private bool rotatingRight = true; // Direction actuelle de la rotation

    void Update()
    {
        // Calculer l'angle de rotation
        float angle = Mathf.PingPong(Time.time * speed, rotationAngle * 2) - rotationAngle;

        // Appliquer la rotation autour de l'axe Z
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
