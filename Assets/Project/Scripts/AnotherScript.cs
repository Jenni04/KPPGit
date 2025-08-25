using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherScript : MonoBehaviour
{
    Animator animator;

   

    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();

        Please();
    }

    public void Please()
    {
     int A = PlayerPrefs.GetInt("Seeing");



        animator.SetInteger("See", A);
    }
}
