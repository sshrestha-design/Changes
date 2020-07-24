using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour
{
   [SerializeField] private GameObject Heart;
   [SerializeField] private GameObject Heart2;
   [SerializeField] private GameObject Heart3;
   
   public Renderer Players;
   public Settings settings;
    void Start()
    {
     Heart.SetActive(true);
    Heart2.SetActive(true);   
     Heart3.SetActive(true);
     settings.health=3;
    }
    private void  OnTriggerEnter2D(Collider2D trap)
    {
         
             if(trap.gameObject.tag == "Player")
            {
                 settings.health--;
                {
                     if(settings.health==2)
                 {
    Heart3.SetActive(false);
    Players.material.color=Color.red;
                 }
                  if(settings.health==1)
                 {
     Heart2.SetActive(false);
     Players.material.color=Color.red;
                 }
            
             if(settings.health==0)
                 {
                     SceneManager.LoadScene(1);
                       }}
            }
            
    }
private void OnTriggerExit2D(Collider2D other)
 {
    Players.material.color=Color.white;
}
}
