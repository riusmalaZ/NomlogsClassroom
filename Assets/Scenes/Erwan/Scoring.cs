using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private TextMeshProUGUI scoreText; // Texte principal pour le score en jeu
    private float score = 1.0f;
    private const float maxScore = 20.0f;
    private const float minScore = 0.0f;

    [Header("Result Panels")]
    [SerializeField] private GameObject victoirePanel; // Panel pour la victoire
    [SerializeField] private GameObject defaitePanel;  // Panel pour la défaite
    [SerializeField] private TextMeshProUGUI victoireScoreText; // Texte du panel victoire
    [SerializeField] private TextMeshProUGUI defaiteScoreText;  // Texte du panel défaite

    void Start()
    {
        UpdateScoreUI();
    }

    // Méthodes pour gérer les modifications du score
    public void ChangeScore(float amount)
    {
        score += amount;
        score = Mathf.Clamp(score, minScore, maxScore);
        UpdateScoreUI();
    }

    // Met à jour le texte du score principal
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
        else
        {
            Debug.LogWarning("Le champ 'scoreText' n'est pas assigné !");
        }
    }

    // Met à jour les textes des panels de récapitulatif
    private void UpdateRecapPanels()
    {
        if (victoireScoreText != null)
        {
            victoireScoreText.text = score.ToString("0.0") + "/20";
        }
        if (defaiteScoreText != null)
        {
            defaiteScoreText.text = score.ToString("0.0") + "/20";
        }
    }

    // Affiche le panel approprié en fonction du score
    public void AfficherResultat()
    {
        // Désactive les deux panels pour commencer
        victoirePanel.SetActive(false);
        defaitePanel.SetActive(false);

        // Met à jour les textes des panels
        UpdateRecapPanels();

        // Active le panel correspondant
        if (score >= 10.0f)
        {
            victoirePanel.SetActive(true);
        }
        else
        {
            defaitePanel.SetActive(true);
        }
    }
}
