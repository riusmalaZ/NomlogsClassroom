using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Méthode pour quitter le jeu
    public void Quit()
    {
        Debug.Log("Le jeu se ferme !"); // Vérification dans l'éditeur
        Application.Quit(); // Ferme le jeu (ne fonctionne que dans un build)
    }
}
