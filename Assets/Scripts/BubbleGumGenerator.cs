using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BubbleGumGenerator : MonoBehaviour
{
    public GameObject bubbleGumPrefab;

    [Header("Growth Settings")]
    public Vector3 maxScale = new Vector3(5f, 5f, 1f); // Taille maximale
    public float growthDuration = 2f; // Temps pour atteindre la taille maximale
    public float minWaitTime = 1f; // Temps minimum avant de recommencer
    public float maxWaitTime = 5f; // Temps maximum avant de recommencer

    private Vector3 initialScale; // Taille de départ

    void Start()
    {
        // Initialisation de l'échelle à zéro
        initialScale = Vector3.zero;
        transform.localScale = initialScale;

        // Lancement de la boucle de croissance
        StartCoroutine(WaitAndGrow());
    }

    private IEnumerator WaitAndGrow()
    {
        while (true)
        {
            // Temps d'attente avant de recommencer à grossir
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);

            // Croissance progressive jusqu'à la taille maximale
            yield return StartCoroutine(GrowToMaxScale());

            // Réinitialisation de la taille
            ResetScale();
        }
    }

    private IEnumerator GrowToMaxScale()
    {
        float elapsedTime = 0f;

        while (elapsedTime < growthDuration)
        {
            // Interpolation linéaire entre l'échelle initiale et l'échelle maximale
            transform.localScale = Vector3.Lerp(initialScale, maxScale, elapsedTime / growthDuration);

            elapsedTime += Time.deltaTime;

            // Attend la fin de la frame avant de continuer
            yield return null;
        }

        // S'assure que l'échelle finale est exactement la taille maximale
        transform.localScale = maxScale;
    }

    /// <summary>
    /// Réinitialise l'échelle de l'objet à sa taille initiale.
    /// </summary>
    public void ResetScale()
    {
        transform.localScale = initialScale;
    }
}
