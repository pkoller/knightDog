using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    Animator anim;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    public float moveSpeed = 1;
    public float rotateSpeed = 1;
    public float jumpHeight = 200;
    
    public float c = 0;
    public bool shiftpressed;
    // Update is called once per frame
    void Update()
    {

        bool mouseRight = Input.GetMouseButtonUp(0);

        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis
        shiftpressed = Input.GetKey(KeyCode.LeftShift);
        
        transform.Translate(new Vector3(0, 0, verticalInput) * (shiftpressed ? moveSpeed*2 : moveSpeed) * Time.deltaTime);
        transform.Rotate(new Vector3(0, horizontalInput,0) * rotateSpeed* Time.deltaTime);
        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.

        //if (anim.GetInteger("attack") > 0)  // reset attack
        //    anim.SetInteger("attack", 0);

        c = verticalInput;
        if (Mathf.Abs(verticalInput) > 0)
        {
            anim.SetInteger("speed", 1);
            if (shiftpressed)
                anim.SetInteger("speed", 2);

        }
        else
            anim.SetInteger("speed", 0);

        if (mouseRight)
            anim.SetTrigger("attack");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(new Vector3(0, jumpHeight, 0));
        }

    }

}
