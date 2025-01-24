using System;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private float transparence;
    public bool FadeOut; // Définit si le fondu va vers 0 (FadeIn) ou 1 (FadeOut)
    public float Step = 0.1f; // Vitesse du fondu

    public Action OnFadeComplete; // Callback à appeler lorsque le fondu est terminé

    public MancheManager mancheManager;

    void Start()
    {
        transparence = FadeOut ? 0 : 1; // Initialise la transparence
        GetComponent<CanvasGroup>().alpha = transparence;
    }

    void Update()
    {
        transparence = Mathf.Clamp01(transparence); // Clamp la transparence entre 0 et 1

        if (FadeOut)
        {
            transparence += Step * Time.deltaTime; // Incrémente la transparence pour FadeOut
        }
        else
        {
            transparence -= Step * Time.deltaTime; // Décrémente la transparence pour FadeIn
        }

        GetComponent<CanvasGroup>().alpha = transparence; // Applique la transparence

        // Vérifie si le fondu est terminé
        if ((FadeOut && transparence >= 1))
        {

            if(mancheManager.mancheWin == true) // Vérifie si la manche est gagnée
            {
                mancheManager.NextManche(); // Passe à la manche suivante
            }
            else // Si la manche est perdue
            {
                mancheManager.ResetMancheObjet(); // Réinitialise la manche
            }
            enabled = false; // Désactive le script pour éviter d'appeler Update en boucle
        }
    }

    // Méthode pour réinitialiser et relancer le fondu
    public void StartFade(bool fadeOut, Action callback = null)
    {
        FadeOut = fadeOut; // Définit la direction du fondu
        transparence = fadeOut ? 0 : 1; // Réinitialise la transparence
        enabled = true; // Réactive le script
        
        
    }
}

