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

            
            // enabled = false; // Désactive le script pour éviter d'appeler Update en boucle

            if(mancheManager.mancheFinish)
            {
                Debug.Log("azujkndaeiojgauignazgiu");
                mancheManager.ReloadCurrentScene(); // Recharge la scène actuelle pour passer à la manche suivante
            }
            
        }
    }

    // Méthode pour réinitialiser et relancer le fondu
    public void StartFade(bool fadeOut)
    {
        FadeOut = fadeOut; // Définit la direction du fondu
        transparence = fadeOut ? 0 : 1; // Réinitialise la transparence
        enabled = true; // Réactive le script
        
        
    }
}

