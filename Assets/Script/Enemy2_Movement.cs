using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // I made them faster than the first enemy
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 4f);

        //made it so they destroy themselves after they are ourised the screen 
        if (transform.position.x < -12f)
        {
            Destroy(this.gameObject);
        }
    }
}
