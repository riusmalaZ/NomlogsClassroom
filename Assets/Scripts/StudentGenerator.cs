using System.Collections.Generic;
using UnityEngine;

public class StudentGenerator : MonoBehaviour
{

    public GameObject[] Emplacement = new GameObject[16];

    [Range(0, 16)]
    public int NombreEtudiant;

    public MancheObject mancheObject;
    public GameObject studentPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NombreEtudiant = mancheObject.NumberSudents;
        Debug.Log(NombreEtudiant+" & "+studentPrefab.name);
        GenerateStudent(NombreEtudiant, studentPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generate a random number of students
    public void GenerateStudent(int NombreEtudiant, GameObject Prefab)
    {
        List<int> randomList = new List<int>();

        for (int i = 0; i < NombreEtudiant; i++)
        {
            
            int random = Random.Range(0, 16);

            while(randomList.Contains(random))
            {
                random = Random.Range(0, 16);
            }

            if(!randomList.Contains(random))
            {
                GameObject student = Instantiate(Prefab, Emplacement[random].transform.position, Quaternion.Euler(0, 0, 90));
                student.transform.SetParent(this.transform);
                GameEvents.Students.Add(student.GetComponent<Student>());
                randomList.Add(random);
                
            }

            
        }
    }
}
