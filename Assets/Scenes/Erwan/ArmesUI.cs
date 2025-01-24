using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ArmeUI : MonoBehaviour
{
    public Image armeActuelle;
    public Image armeSuivante;

    public List<Sprite> armes = new List<Sprite>();

    private int currentIndex = 0;

    void Start()
    {
        if (armes.Count > 0)
        {
            currentIndex = Random.Range(0, armes.Count);
            armeActuelle.sprite = armes[currentIndex];

            int nextIndex;
            do
            {
                nextIndex = Random.Range(0, armes.Count);
            } while (nextIndex == currentIndex);

            armeSuivante.sprite = armes[nextIndex];
        }

        Button bouton = GetComponent<Button>();
        bouton.onClick.AddListener(CliqueGauche);
    }

    void CliqueGauche()
    {
        currentIndex = (currentIndex + 1) % armes.Count;

        armeActuelle.sprite = armeSuivante.sprite;

        int nextIndex;
        do
        {
            nextIndex = Random.Range(0, armes.Count);
        } while (nextIndex == currentIndex);

        armeSuivante.sprite = armes[nextIndex];
    }
}