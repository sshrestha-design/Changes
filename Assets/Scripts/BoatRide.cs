using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRide : MonoBehaviour
{[SerializeField] private GameObject Player;
[SerializeField] private  GameObject boat;
[SerializeField] private  GameObject boatButton;
Rigidbody2D boatRb, PlayerRb;
public static  bool PlayerNearTheboatDoor;
bool inboat;
float horizontalMove,runSpeed;
public Transform boatDoor;
void Start()
{
   boatRb = boat.GetComponent<Rigidbody2D> ();
		PlayerRb = Player.GetComponent<Rigidbody2D> ();
     
}
    // Start is called before the first frame update
  


void Update()
{
		if (PlayerNearTheboatDoor || inboat)
			
            boatButton.SetActive(true);
		else
			
                	boatButton.SetActive(false);
}
	void FixedUpdate()
	{
		if (inboat)
			boatRb.velocity = new Vector2 (horizontalMove, boatRb.velocity.y);
		else
			PlayerRb.velocity = new Vector2 (horizontalMove, PlayerRb.velocity.y);
	}
    public void EnterExitboat()
	{
		if (!inboat) {
			Player.gameObject.SetActive (false);
             horizontalMove= Input.GetAxisRaw("Horizontal")*runSpeed;
		}

		if (inboat) {
			Player.gameObject.SetActive (true);
			Player.transform.position = new Vector2 (boatDoor.position.x, boatDoor.position.y);
		}

		inboat = !inboat;
	}
}
