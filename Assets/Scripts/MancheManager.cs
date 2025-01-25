using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestionnaire des manches du jeux
/// </summary>
public class MancheManager : MonoBehaviour
{

    public MancheObject mancheObject; // ScriptableObject pour stocker les informations de la manche

    public int MancheWindow = 0; // Numéro de la manche où la fenêtre s'ouvre

    public bool mancheWin = true; // Définit si la manche est gagnée ou perdue (à modifier dans le script qui gère la défaite et victoire)

    public bool mancheFinish = false; // Définit si la manche est terminée

    [Range(0, 16)]
    public int NumberSudentsFirstManche = 0; // Nombre d'étudiants à gérer

    public Fade fade;  // Script pour gérer le fondu

    public TimerManche timerManche; // Script pour gérer le minuteur

    public float durationInMinutes = 2f; // Durée du minuteur en minutes

    public GameObject EcranVictoire; // Ecran de victoire

    public GameObject EcranDefaite; // Ecran de défaite

    public Scoring scoring; // Script pour gérer le score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(mancheObject != null) // Vérifie si le ScriptableObject est assigné
        {
            if(mancheObject.MancheNumber == 0) // Vérifie si c'est la première manche
            {
                FirstManche(); // Initialise la première manche
            }
        }
    }

    void Start()
    {
        timerManche.StartTimer(durationInMinutes); // Démarre le minuteur
    }

    void Update()
    {
        //Si le score est à 0 alors 
        if(scoring.score == 0)
        {
            mancheFinish = true;
            ResetMancheObjet();
            EcranDefaite.SetActive(true);
        }

        //Si le minuteur est fini alors
        if(timerManche.isCompleted)
        {
            mancheFinish = true;

            //Si le score est au dessus de 10  
            if(scoring.score >= 10)
            {
                NextManche();
                EcranVictoire.SetActive(true);
            }
            else
            {
                ResetMancheObjet();
                EcranDefaite.SetActive(true);
            }   
        }

        //Si élèves tué 
            // ResetManche
            // Ecran de défaite


        //Si le score en dessous de 10
        if(scoring.score < 10)
        {
            mancheWin = false;
        }
            
        //Si mancheWin == false && mancheWin >= 10
        if(mancheWin == false && scoring.score >= 10)
        {
            mancheWin = true;
        }
    }   


    /// <summary>
    /// Initialise la première manche
    /// </summary>
    void FirstManche()
    {
        // Initialisation de la première manche
        mancheObject.MancheNumber = 1;
        mancheObject.NumberSudents = NumberSudentsFirstManche;
        mancheObject.CanWindowOpen = false;
    }

    /// <summary>
    /// Passe à la manche suivante
    /// </summary>
    public void NextManche()
    {
        mancheObject.MancheNumber++;
        mancheObject.NumberSudents += 1;

        if(mancheObject.MancheNumber == MancheWindow)
        {
            mancheObject.CanWindowOpen = true;
        }
        else
        {
            mancheObject.CanWindowOpen = false;
        }

        
    }

    /// <summary>
    /// Réinitialise les informations de la manche
    /// </summary>
    public void ResetMancheObjet()
    {
        mancheObject.MancheNumber = 0;
        mancheObject.NumberSudents = 0;
        mancheObject.CanWindowOpen = false;
        
    }


    /// <summary>
    /// Fonction pour gagner une manche
    /// </summary>
    [ContextMenu("Win Manche")]
    public void WinManche()
    {
        Debug.Log("Manche gagnée !");
        fade.StartFade(true); // Lance le fondu qui va ensuite appeler NextManche()
    }

    /// <summary>
    /// Fonction pour perdre une manche
    /// </summary>
    [ContextMenu("Lose Manche")]
    public void LoseManche()
    {
        Debug.Log("Manche perdue !");
        fade.StartFade(true); // Lance le fondu qui va ensuite appeler NextManche()
        
    }

    /// <summary>
    /// Fonction pour reset le scriptableObject si l'on quitte le jeu
    /// </summary>
    public void OnApplicationQuit()
    {
        ResetMancheObjet();
    }

    /// <summary>
    /// Recharge la scène actuelle
    /// </summary>
    public void ReloadCurrentScene()
    {
        // Obtenir le nom ou l'index de la scène actuelle
        string currentSceneName = SceneManager.GetActiveScene().name;

        // mancheFinish = false; // Réinitialise l'état de la manche
        // Recharger la scène
        SceneManager.LoadScene(currentSceneName);

        
    }
}
