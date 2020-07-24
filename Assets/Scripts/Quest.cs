using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{[SerializeField] private GameObject Quests;

public bool gotItem = false;
      
    // Start is called before the first frame update
    void Start()
    {
     Quests.SetActive(false);
 
    }
private void  OnTriggerExit2D(Collider2D other)
    {if(other.gameObject.tag == "Player")
            {
                 Quests.SetActive(true);
            }
    }
    
}
