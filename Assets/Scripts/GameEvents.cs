using UnityEngine;
using System.Collections.Generic;

public class GameEvents : MonoBehaviour
{
    public static List<Student> Students;
    float chrono;
    public float Tick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Students = new ();
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

        int nMax = Students.Count / 2 + 1;
        int n = Random.Range(1, nMax);
        print(n);
        for (int i = 0; i < n; i++)
        {
            bool newBubble = false;
            int trys = 0;
            while (!newBubble)
            {
                trys++;
                if (trys == 100)
                {
                    newBubble = true;
                    print("pb");
                }
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
