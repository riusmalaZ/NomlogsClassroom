using UnityEngine;
using System.Collections.Generic;

public class Student : MonoBehaviour
{
    public bool isBubbling;
    Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        isBubbling = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bubble()
    {
        animator.SetTrigger("StartBubble");
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
