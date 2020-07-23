using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingTrigger : MonoBehaviour
{
     [SerializeField] private GameObject FishingMechn;


void Start()
    {
     FishingMechn.SetActive(false);
        }

 private void  OnTriggerStay2D(Collider2D other)
{
      if(other.gameObject.tag == "Player")
  {  FishingMechn.SetActive(true);
         }}
         

     private void  OnTriggerExit2D(Collider2D exit)
     {
         FishingMechn.SetActive(false);
     }

}
    
