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
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 3f);
        if (transform.position.x < -8f)
        {
            Destroy(this.gameObject);
        }
    }
}