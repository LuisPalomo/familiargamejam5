using System;
using UnityEngine;

public class TaperControl : MonoBehaviour
{
    private Animator animator;

    // Use this for initialization
    private void Awake()
    {
        this.animator = this.GetComponent<Animator>();
    }
    /*
    private void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
            this.OpenTaper();

        if (Input.GetKey(KeyCode.C))
            this.CloseTaper();
         
    }
    */
    public void OpenTaper()
    {
        this.animator.SetBool("Abierto", true);
    }

    public void CloseTaper()
    {
        this.animator.SetBool("Abierto", false);
    }
}
