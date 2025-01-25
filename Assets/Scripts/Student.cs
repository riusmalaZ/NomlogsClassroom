using UnityEngine;
using System.Collections.Generic;

public class Student : MonoBehaviour
{
    public bool isBubbling = false ;
    Animator animator;
    public int Row ;
    float chrono;
    public Scoring scoring;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chrono = 0;
        animator = GetComponentInChildren<Animator>();
        isBubbling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBubbling)
        {
            chrono += Time.deltaTime;
            if (chrono > 6) 
            {
                scoring.ChangeScore(-1);
                isBubbling = false;
            }
        }
    }

    public void Bubble()
    {
        animator.SetTrigger("StartBubble");
        chrono = 0;
        isBubbling = true;
    }

    public void Pop(bool isLethal)
    {
        animator.SetTrigger("PopBubble");
        isBubbling = false;
        if (isLethal)
        {
            scoring.ChangeScore(-5);
        }
        else
        {
            if (chrono < 4.5f ) scoring.ChangeScore(0.5f);
            else scoring.ChangeScore(1);
        }

    }


}
