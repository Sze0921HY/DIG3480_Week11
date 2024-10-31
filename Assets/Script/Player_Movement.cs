using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private int lives;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start(){
        speed = 6f;
        lives = 3;
    }
    // Update is called once per frame
    void Update(){
        Moving();
        Shooting();
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

    void Shooting()
    {
        //if SPACE key is pressed create a bullet; what is a bullet?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet object at my position with my rotation
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0),Quaternion.identity);
        }
    }
}
