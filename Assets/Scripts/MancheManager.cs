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

    public bool mancheWin = false; // Définit si la manche est gagnée ou perdue (à modifier dans le script qui gère la défaite et victoire)

    public Fade fade;  // Script pour gérer le fondu
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

    /// <summary>
    /// Initialise la première manche
    /// </summary>
    void FirstManche()
    {
        // Initialisation de la première manche
        mancheObject.MancheNumber = 1;
        mancheObject.NumberSudents = 5;
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

        ReloadCurrentScene(); // Recharge la scène actuelle pour passer à la manche suivante
    }

    /// <summary>
    /// Réinitialise les informations de la manche
    /// </summary>
    public void ResetMancheObjet()
    {
        mancheObject.MancheNumber = 0;
        mancheObject.NumberSudents = 0;
        mancheObject.CanWindowOpen = false;
        ReloadCurrentScene();
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

        // Recharger la scène
        SceneManager.LoadScene(currentSceneName);
    }
}
