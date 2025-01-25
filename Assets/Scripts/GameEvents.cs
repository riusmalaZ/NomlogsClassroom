using UnityEngine;
using System.Collections.Generic;

public class GameEvents : MonoBehaviour
{
    public static List<Student> Students = new ();
    float chrono;
    public float Tick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountTick();
    }

    void CountTick()
    {
        chrono += Time.deltaTime;
        if (chrono >= Tick)
        {
            ChooseStudents();
            chrono = 0;
        }
    }

    void ChooseStudents()
    {
        bool canBubble = false;
        foreach (Student student in Students)
        {
            if (!student.isBubbling) canBubble = true;
        }

        if (!canBubble) return;
        
        int nMax = Students.Count / 2;
        int n = Random.Range(1, nMax);

        for (int i = 0; i < n; i++)
        {
            bool newBubble = false;

            while (!newBubble)
            {
                int x = Random.Range(0, Students.Count);

                if (!Students[x].isBubbling)
                {
                    Students[x].Bubble();
                    newBubble = true;
                }
            }
        }
    }
}
