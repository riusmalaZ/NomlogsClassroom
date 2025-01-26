using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{
    public Image UIArmeActuelle;
    public GameObject ArmeActuelle;
    public Image UIArmeSuivante;
    public GameObject ArmeSuivante;

    public List<GameObject> WeaponsPrefabs = new ();

    private int currentIndex = 0;

    void Start()
    {
        if (WeaponsPrefabs.Count > 0)
        {
            currentIndex = Random.Range(0, WeaponsPrefabs.Count);
            ArmeActuelle = WeaponsPrefabs[currentIndex];
            UIArmeActuelle.sprite = ArmeActuelle.GetComponentInChildren<SpriteRenderer>().sprite;

            int nextIndex;
            do
            {
                nextIndex = Random.Range(0, WeaponsPrefabs.Count);
            } while (nextIndex == currentIndex);

            ArmeSuivante = WeaponsPrefabs[nextIndex];
            UIArmeSuivante.sprite = ArmeSuivante.GetComponentInChildren<SpriteRenderer>().sprite;
        }

    }

    public GameObject RandomizeWeapon()
    {
        currentIndex = (currentIndex +1 ) % WeaponsPrefabs.Count;

        ArmeActuelle = ArmeSuivante;
        UIArmeActuelle.sprite = UIArmeSuivante.sprite;

        int nextIndex;
        do
        {
            nextIndex = Random.Range(0, WeaponsPrefabs.Count);
        } while (nextIndex == currentIndex);

        ArmeSuivante = WeaponsPrefabs[nextIndex];
        UIArmeSuivante.sprite = ArmeSuivante.GetComponentInChildren<SpriteRenderer>().sprite;

        return ArmeActuelle;
    }
}