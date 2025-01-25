using UnityEngine;
using System.Collections.Generic;

public class Student : MonoBehaviour
{
    public bool isBubbling;
    Animator animator;
    public int Row ;
    float chrono;
    
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
            if (chrono > 3) 
            {
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
        animator.SetTrigger("Pop");
        isBubbling = false;
        if (isLethal)
        {
            return;
        }

    }


}
