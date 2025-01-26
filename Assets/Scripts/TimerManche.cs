using System;
using UnityEngine;
using TMPro;

public class TimerManche : MonoBehaviour
{
    
    public float timeRemaining; // Temps restant
    private bool isRunning = false; // Indique si le minuteur est en cours
    public bool isCompleted = false; // Indique si le minuteur est terminé

    [Header("UI")]
    public TextMeshProUGUI timerText; // Référence au composant TMP pour afficher le temps restant

    void Start()
    {
        // // Exemple : démarrer le minuteur
        // StartTimer(durationInMinutes);
    }

    void Update()
    {
        if (isRunning)
        {
            // Réduire le temps restant
            timeRemaining -= Time.deltaTime;

            // Mettre à jour l'affichage
            UpdateTimerDisplay();

            // Si le temps est écoulé
            if (timeRemaining <= 0f)
            {
                timeRemaining = 0f; // Assure qu'il ne descend pas en dessous de 0
                isRunning = false; // Arrête le minuteur
                isCompleted = true; // Le minuteur est terminé
                GetComponent<AudioSource>().enabled = false;

                Debug.Log("Le minuteur est terminé !");
            }
        }
    }

    /// <summary>
    /// Démarre le minuteur avec une durée donnée en minutes.
    /// </summary>
    /// <param name="minutes">Durée en minutes.</param>
    public void StartTimer(float minutes)
    {
        // durationInMinutes = minutes;
        timeRemaining = minutes * 60f; // Convertir en secondes
        isRunning = true; // Lancer le minuteur
        isCompleted = false; // Réinitialiser l'état terminé
        UpdateTimerDisplay(); // Mettre à jour l'affichage immédiatement
        Debug.Log($"Minuteur lancé pour {minutes} minute(s).");
    }

    /// <summary>
    /// Arrête le minuteur en cours.
    /// </summary>
    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("Minuteur arrêté.");
    }

    /// <summary>
    /// Vérifie si le minuteur est actif.
    /// </summary>
    /// <returns>Retourne vrai si le minuteur est en cours.</returns>
    public bool IsTimerRunning()
    {
        return isRunning;
    }

    /// <summary>
    /// Retourne le temps restant sous forme de texte formaté (mm:ss).
    /// </summary>
    /// <returns>Temps restant au format mm:ss.</returns>
    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        return $"{minutes:D2}:{seconds:D2}";
    }

    /// <summary>
    /// Met à jour l'affichage du minuteur.
    /// </summary>
    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = GetFormattedTime();
        }
    }
}




