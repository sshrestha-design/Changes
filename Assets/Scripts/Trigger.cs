using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
[SerializeField] private GameObject Object;
[SerializeField] private GameObject trash;
[SerializeField] private GameObject Hint;
[SerializeField] private GameObject Dialoguetips;
[SerializeField] private GameObject Achievements;

[SerializeField] private GameObject quest;

public  bool objectobtain=true;
public float s=1f;

void Start()
    {
     Hint.SetActive(false);
        }

 private void  OnTriggerStay2D(Collider2D other)
{Hint.SetActive(true);
      if(other.gameObject.tag == "Player")
    {if(SimpleInput.GetButtonDown("Inspect"))
       {
           Object.SetActive(false);
        
         
         objectobtain=false;
         Achievements.SetActive(true);
         s=1;

         Achievement();
         if (quest != null){
             quest.gameObject.GetComponent<Quest>().gotItem = true;
         }
         }
         
      
    if(objectobtain==false)
    {
        Hint.SetActive(false);
        Dialoguetips.SetActive(false);
    }
  
     } }
     private void OnTriggerExit2D(Collider2D other) {
          Hint.SetActive(false);
      }

   void Achievement()
    {
       StartCoroutine(RemoveAfterSeconds(2,Achievements));
       IEnumerator RemoveAfterSeconds (int seconds, GameObject Achievements)
       {
           yield return new WaitForSeconds(2);
           Achievements.SetActive(false);

       }
    }
    

}
    
