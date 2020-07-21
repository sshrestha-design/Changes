using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoaScript : MonoBehaviour
{
    [SerializeField] private GameObject Hero;
[SerializeField] private  GameObject Boat;


void Start()
    {
        Boat.SetActive(false);
        }
private void  OnTriggerEnter2D(Collider2D other)
{
      if(other.gameObject.tag == "Player")
    {
        Boat.SetActive(true);
        Hero.SetActive(false);
    }
    
    }
 private void  OnTriggerExit2D(Collider2D other)
{
      if(other.gameObject.tag == "Player")
    {
        Boat.SetActive(false);
        Hero.SetActive(true);
    }
    
    }
 


}

