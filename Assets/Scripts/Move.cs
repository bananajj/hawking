using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    float rx = -1;
    float rxt = 0;
    float lxt = 0;
    float lx = 1;
    bool enableLeft = false;
    bool enableRight = false;
    bool forward = false;

    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame 

    public void enLift()
    {
        forward = false;
        enableLeft = true;
        enableRight = false;
    }

    public void enRight()
    {
        forward = false;
        enableLeft = false;
        enableRight = true;
    }
    public void enforward()
    {
        forward = true;
    }
    void Update()
    {
        if (enableLeft == true)
        {
            Left();
        }
        if (enableRight == true)
        {
            Right();
        }


        if (forward == true)
        {
            Forward();
        }

    }

    private void Left()
    {

        lxt += 1f;

        if (lxt < 90)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + lx, transform.rotation.eulerAngles.z);

        }
        else
        {
            enableLeft = false;
            lxt = 0;
        }
    }
    private void Right()
    {


        rxt -= 1f;


        if (rxt > -90)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rx, transform.rotation.eulerAngles.z);
        }
        else
        {
            enableRight = false;
            rxt = 0;
        }
    }

    private void Forward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}