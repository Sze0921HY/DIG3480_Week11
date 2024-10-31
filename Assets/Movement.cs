using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed;


    // Start is called before the first frame update
    void Start(){
        speed = 6f;
    }
    // Update is called once per frame
    void Update(){
        Moving();
    }

    void Moving(){
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) *
        Time.deltaTime * speed);

        if (transform.position.x > 11.5f || transform.position.x <= -11.5f){
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y > 0){
            transform.position = new Vector3(transform.position.x, transform.position.y * 0, 0);
        }
        if (transform.position.y <= -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }
    }
}
