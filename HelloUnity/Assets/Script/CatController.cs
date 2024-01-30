using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float force = 680f;
    
    private float rlForce = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0f;
        
        if(Input.GetKeyDown(KeyCode.Space))
        //มกวม
        this.rbody.AddForce(this.transform.up * this.force);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1f;
        }
        this.rbody.AddForce(direction * this.transform.right * rlForce);
    }
}
