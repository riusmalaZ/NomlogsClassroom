using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Gestionnaire des manches du jeux
/// </summary>
public class MancheManager : MonoBehaviour
{

    public MancheObject mancheObject; // ScriptableObject pour stocker les informations de la manche

    public int MancheWindow = 5; // Numéro de la manche où la fenêtre s'ouvre

    public float TimingActivationWindow = 90f; // Temps avant l'activation de la fenêtre

    public float TimingDesactivationWindow = 30f; // Temps avant l'activation de la fenêtre

    public GameObject Window; // Fenêtre à ouvrir

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

    public bool isReloading = false;

    private bool actionEffectuee = false; // Permet de s'assurer que l'action est exécutée une seule fois

    public TextMeshProUGUI MancheNumberTextWin; // Texte pour afficher

    public TextMeshProUGUI MancheNumberTextLose; // Texte pour afficher
    public AimAndLaunch aimAndLaunch;

    public StudentGenerator studentGenerator;

    public bool WindowOpen = false;

    public Animator WindowLeft;

    public Animator WindowRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        MancheNumberTextLose.text = "Manche " + mancheObject.MancheNumber.ToString() + " perdue";

        MancheNumberTextWin.text = "Manche " + mancheObject.MancheNumber.ToString() + " réussie";
        
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

        TimingActivationWindow = durationInMinutes * 60f - TimingActivationWindow;

        TimingDesactivationWindow = durationInMinutes * 60f - TimingDesactivationWindow;
    }

    void Update()
    {
        // Si le score est à 0 alors 
        if (scoring.score == 0 && !actionEffectuee)
        {
            actionEffectuee = true; // Marque l'action comme effectuée
            mancheFinish = true;
            ResetMancheObjet();
            EcranDefaite.SetActive(true);
            DestroyEndScreen();
            scoring.UpdateRecapPanels();
        }

        // Si le minuteur est fini alors
        if (timerManche.isCompleted && !actionEffectuee)
        {
            actionEffectuee = true; // Marque l'action comme effectuée
            mancheFinish = true;

            // Si le score est au-dessus de 10  
            if (scoring.score >= 10)
            {
                NextManche(); 
                EcranVictoire.SetActive(true);
                DestroyEndScreen();
                scoring.UpdateRecapPanels();
            }
            else
            {
                ResetMancheObjet();
                EcranDefaite.SetActive(true);
                DestroyEndScreen();
                scoring.UpdateRecapPanels();
            }
        }

        if(mancheObject.CanWindowOpen)
        {
            if(timerManche.timeRemaining <= TimingActivationWindow && timerManche.timeRemaining >= TimingDesactivationWindow)
            {
                Window.SetActive(true);
                if(WindowOpen == false)
                {
                    studentGenerator.studentWindow.AnimationOpenWindow();

                    WindowLeft.SetBool("Open", true);
                    WindowRight.SetBool("Open", true);

                }
                    WindowOpen = true;
                }
            if(timerManche.timeRemaining <= TimingDesactivationWindow)
            {
                WindowLeft.SetBool("Open", false);
                WindowRight.SetBool("Open", false);
                Window.SetActive(false);
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

        if(mancheObject.MancheNumber == MancheWindow)
        {
            mancheObject.CanWindowOpen = true;
        }
        else
        {
            mancheObject.CanWindowOpen = false;
        }

        MancheNumberTextLose.text = "Manche " + mancheObject.MancheNumber.ToString() + " perdue";

        MancheNumberTextWin.text = "Manche " + mancheObject.MancheNumber.ToString() + " réussie";
    }

    /// <summary>
    /// Passe à la manche suivante
    /// </summary>
    public void NextManche()
    {
        mancheObject.MancheNumber++;
        if (mancheObject.NumberSudents < 16) mancheObject.NumberSudents += 1;

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

        if (isReloading) return; // Évite plusieurs appels
        isReloading = true;
        // Obtenir le nom ou l'index de la scène actuelle
        string currentSceneName = SceneManager.GetActiveScene().name;

        // mancheFinish = false; // Réinitialise l'état de la manche
        // Recharger la scène
        SceneManager.LoadScene(currentSceneName);

        
    }

    void DestroyEndScreen()
    {
        foreach (Student student in GameEvents.Students)
        {
            Destroy(student.gameObject);
            GetComponent<GameEvents>().enabled = false;
            GetComponent<TimerManche>().enabled = false;
            aimAndLaunch.enabled = false;
        }
    }
}
