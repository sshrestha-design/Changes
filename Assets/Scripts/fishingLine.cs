using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fishingLine : MonoBehaviour
{

    [SerializeField]private GameObject bait;
    [SerializeField]private GameObject quest;
	[SerializeField] private TMP_Text fishCountUI;

    private LineRenderer lineRenderer;
    [SerializeField]private Vector3 start = new Vector3(0,0,0);
    [SerializeField]private Vector3 end = new Vector3(0,-1.0f,0);
    // Start is called before the first frame update
    [SerializeField]private float lineSpeed = 0.03f;
    [SerializeField]private float upperLimit = -0.3f;
    [SerializeField]private float lowerLimit = -1.5f;
    [SerializeField]private int fishToCatch = 2;
    private float baitPosition = 0f;
    private int fishCaught = 0;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; 

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(0,end);

        baitPosition = bait.transform.position.y + 0;

        fishCountUI.text = "" + fishCaught + "/" + fishToCatch;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            if (end.y > lowerLimit){
                end.y -= lineSpeed;
                baitPosition -= lineSpeed;
            }
        }  

        if(Input.GetKey(KeyCode.X))
        {
            if (end.y < upperLimit){
                end.y += lineSpeed;
                baitPosition += lineSpeed;
            }else{
                bait.GetComponent<BoxCollider2D>().enabled = true;
                foreach (Transform child in bait.transform) {
                        fishCaught++;
                        Destroy(child.gameObject);
                        if (fishCaught == fishToCatch){
                            quest.gameObject.GetComponent<Quest>().gotItem = true;
                        }
                        fishCountUI.text = "" + fishCaught + "/" + fishToCatch;
                }
            }
        }   

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(0,end);

        bait.transform.position = new Vector2(bait.transform.position.x,baitPosition);
    }
}
