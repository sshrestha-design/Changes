using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingTrigger1 : MonoBehaviour
{
     [SerializeField] private GameObject FishingMechn;


void Start()
    {
     FishingMechn.SetActive(false);
        }

 private void  OnTriggerEnter2D(Collider2D other)
{
      if(other.gameObject.tag == "Player")
  {  FishingMechn.SetActive(true);
         }}
         

   
}
    
