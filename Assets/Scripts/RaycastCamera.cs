using UnityEngine;
using System.Collections;

public class RaycastCamera : MonoBehaviour {
    public GameObject player;
    private bool castingForce;
    private GameObject selectedObject;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
       /* if (Camera.current)
        {
            Vector3 fwd = Camera.current.transform.forward;

            RaycastHit theHit;
            Physics.Raycast(Camera.current.transform.position, fwd, out theHit, 10);
            GameObject theHitedObject = theHit.collider.gameObject;

            if (selectedObject != theHitedObject)
            {
                Debug.Log(theHit.distance);
                if (selectedObject != null)
                {
                    selectedObject.GetComponent<Renderer>().material.color = Color.white;
                }
                selectedObject = theHit.collider.gameObject;
                if (selectedObject)
                {
                    selectedObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }*/
        
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * 4f, Color.yellow);

        RaycastHit info;
        if (Physics.Raycast(transform.position, transform.forward, out info, 4f))
        {
            GameObject gObg = info.collider.gameObject;
            Debug.Log(info.collider.gameObject);

            Debug.Log(info.distance);
            if (gObg.name == "Forward") {
                player.GetComponent<Move>().enforward();
            }
            if (gObg.name == "Left")
            {
                player.GetComponent<Move>().enLift();
            }
            if (gObg.name == "Right")
            {
                player.GetComponent<Move>().enRight();
            }
        }
    }
}
