using UnityEngine;
using System.Collections.Generic;

public class GameEvents : MonoBehaviour
{
    public static List<Student> Students;
    public MancheObject mancheObject;
    float chrono;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Students = new ();
    }

    // Update is called once per frame
    void Update()
    {
        print(5 / 2);
        Count2s();
    }

    void Count2s()
    {
        chrono += Time.deltaTime;
        if (chrono >= 2)
        {
            ChooseStudents();
        }
    }

    void ChooseStudents()
    {
        int nMax = mancheObject.NumberSudents / 2 + 1;
        int n = Random.Range(0, nMax);
        for (int i = 0; i < n; i++)
        {
            bool newBubble = false;
            int trys = 0;
            while (!newBubble)
            {
                trys++;
                if (trys >= 100)
                {
                    print("ayyyy");
                    newBubble = true;
                }
                int x = Random.Range(0, Students.Count);
                if (!Students[x].isBubbling)
                {
                    print(trys);
                    Students[x].Bubble();
                    newBubble = true;
                }
            }
        }
    }
}
