using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 1.0f;
    private const float maxScore = 20.0f;
    private const float minScore = 0.0f;

    void Start()
    {
        UpdateScoreUI();
    }

    public void BulleEclatee(float amount)
    {
        amount = 0.5f;
        score += amount;
        score = Mathf.Clamp(score, minScore, maxScore);
        UpdateScoreUI();
    }

    public void GrosseBulleEclatee(float amount)
    {
        amount = 1;
        score += amount;
        score = Mathf.Clamp(score, minScore, maxScore);
        UpdateScoreUI();
    }
    public void BulleRatee(float amount)
    {
        amount = 1;
        score -= amount;
        score = Mathf.Clamp(score, minScore, maxScore);
        UpdateScoreUI();
    }
    public void TirInnocent(float amount)
    {
        amount = 2;
        score -= amount;
        score = Mathf.Clamp(score, minScore, maxScore);
        UpdateScoreUI();
    }
    public void TirLetal(float amount)
    {
        amount = 5;
        score -= amount;
        score = Mathf.Clamp(score, minScore, maxScore);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString("0.0") + "/20";
    }
}
