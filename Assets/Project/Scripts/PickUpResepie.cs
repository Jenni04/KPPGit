using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpResepie : MonoBehaviour
{
   [SerializeField] ScoreManager scoreManager;

   private void OnTriggerEnter2D(Collider2D collision){

   if (collision.CompareTag("Player")){
            AudioManager.instance.Play("PickupResepie");
   scoreManager.AddResepie();
   Destroy(gameObject);

   }
   }
}
