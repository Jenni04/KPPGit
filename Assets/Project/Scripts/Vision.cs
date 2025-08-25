using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public int number = 0;
    

    // Start is called before the first frame update
    // Update is called once per frame
    public void Blind()
    {
        number = 2;

        PlayerPrefs.SetInt("Seeing", number);
    }

    public void BlindNone()
    {
        number = 1;

        PlayerPrefs.SetInt("Seeing", number);
    }

    public void BlindXtra()
    {
        number = 3;

        PlayerPrefs.SetInt("Seeing", number);
    }

  


}
