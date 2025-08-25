using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

     private int resepieAmmount;

     [SerializeField]
     private Text resepieCounterText;

     private void Awake(){
     resepieAmmount = 0;

     }

    // Update is called once per frame
    void Update()
    {
        resepieCounterText.text = resepieAmmount.ToString() + " / 4";
    }

    public void AddResepie(){
        resepieAmmount++;
    }
}
