using System.Collections.Generic;
using UnityEngine;

public class StudentGenerator : MonoBehaviour
{

    public GameObject[] Emplacement = new GameObject[16];

    [Range(0, 16)]
    public int NombreEtudiant;

    public MancheObject mancheObject;
    public GameObject studentPrefab;

    public MancheManager mancheManager;

    public GameObject EmplacementWindow;

    public Student studentWindow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NombreEtudiant = mancheObject.NumberSudents;
        Debug.Log(NombreEtudiant+" & "+studentPrefab.name);
        GameEvents.Students = new ();
        GenerateStudent(NombreEtudiant, studentPrefab, System.Array.IndexOf(Emplacement, EmplacementWindow));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generate a random number of students
    public void GenerateStudent(int NombreEtudiant, GameObject Prefab, int SpecialEmplacementIndex)
{
    List<int> randomList = new List<int>();

    // Vérifie qu'il y a suffisamment d'emplacements
    if (NombreEtudiant > Emplacement.Length)
    {
        Debug.LogError("Pas assez d'emplacements pour générer autant d'étudiants !");
        return;
    }

    if(mancheManager.mancheObject.CanWindowOpen)
    {
        // Génère l'élève spécial à l'emplacement précis
        if (SpecialEmplacementIndex >= 0 && SpecialEmplacementIndex < Emplacement.Length)
        {
            GameObject specialStudent = Instantiate(Prefab, Emplacement[SpecialEmplacementIndex].transform.position, Quaternion.Euler(0, 0, 0));
            studentWindow = specialStudent.GetComponent<Student>();
            specialStudent.transform.SetParent(this.transform);
            GameEvents.Students.Add(specialStudent.GetComponent<Student>());
            randomList.Add(SpecialEmplacementIndex); // Ajoute cet emplacement comme occupé

            // Assigne une rangée à l'élève spécial
            if (SpecialEmplacementIndex >= 0 && SpecialEmplacementIndex < 4) specialStudent.GetComponent<Student>().Row = 1;
            else if (SpecialEmplacementIndex >= 4 && SpecialEmplacementIndex < 8) specialStudent.GetComponent<Student>().Row = 2;
            else if (SpecialEmplacementIndex >= 8 && SpecialEmplacementIndex < 12) specialStudent.GetComponent<Student>().Row = 3;
            else if (SpecialEmplacementIndex >= 12 && SpecialEmplacementIndex < 16) specialStudent.GetComponent<Student>().Row = 4;
        }
        else
        {
            Debug.LogError("L'indice d'emplacement pour l'élève spécial est invalide !");
            return;
        }
    }
    

    // Génère les autres élèves
    for (int i = 0; i < NombreEtudiant - 1; i++) // -1 car l'élève spécial est déjà généré
    {
        int random = Random.Range(0, Emplacement.Length);

        // Trouve une position aléatoire unique
        while (randomList.Contains(random))
        {
            random = Random.Range(0, Emplacement.Length);
        }

        // Instancie l'élève à la position trouvée
        if (!randomList.Contains(random))
        {
            GameObject student = Instantiate(Prefab, Emplacement[random].transform.position, Quaternion.Euler(0, 0, 0));
            student.transform.SetParent(this.transform);
            GameEvents.Students.Add(student.GetComponent<Student>());
            randomList.Add(random); // Marque l'emplacement comme utilisé

            // Assigne une rangée à l'élève
            if (random >= 0 && random < 4) student.GetComponent<Student>().Row = 1;
            else if (random >= 4 && random < 8) student.GetComponent<Student>().Row = 2;
            else if (random >= 8 && random < 12) student.GetComponent<Student>().Row = 3;
            else if (random >= 12 && random < 16) student.GetComponent<Student>().Row = 4;
        }
    }
}

}
