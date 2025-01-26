using UnityEngine;

public class ParticleCircle : MonoBehaviour
{
    public new ParticleSystem particleSystem; // Référence au Particle System
    public float radius = 2f;             // Rayon du cercle

    void Start()
    {
        // Récupère toutes les particules du système
        var particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        int count = particleSystem.GetParticles(particles);

        // Place chaque particule sur le bord du cercle
        for (int i = 0; i < count; i++)
        {
            float angle = (i * Mathf.PI * 2) / count; // Calcule l'angle pour chaque particule
            particles[i].position = new Vector3(
                Mathf.Cos(angle) * radius,  // Position X sur le cercle
                Mathf.Sin(angle) * radius,  // Position Y sur le cercle
                0                           // Position Z (2D)
            );
            particles[i].remainingLifetime = particleSystem.main.startLifetime.constant; // Réinitialise la durée de vie
        }

        // Applique les modifications au système
        particleSystem.SetParticles(particles, count);
    }
}
