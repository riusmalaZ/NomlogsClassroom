using System;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private float transparence;
    public bool FadeOut;
    public float Step = 0.1f;

    void Start()
    {
        transparence=1;
    }
    void Update()
    {
        transparence=Mathf.Clamp(transparence,0,1);

        if (FadeOut)
        {
            transparence += Step;
        }
        else
        {
            transparence -= Step;
        }
        GetComponent<CanvasGroup>().alpha=transparence;
    }
    
}
