using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRide1 : MonoBehaviour
{[SerializeField] private GameObject Hero1;
[SerializeField] private  GameObject Camera1;
[SerializeField] private  GameObject Flag;



     

    // Start is called before the first frame update
  private void  OnTriggerEnter2D(Collider2D other1)
	{
		if (other1.gameObject.tag == "Player")
		{
			Flag.SetActive(false);
			Hero1.SetActive(true);
            Camera1.SetActive(false);
     
           

		}
	}


    // Update is called once per frame
    void Update()
    {
        
    }
}
