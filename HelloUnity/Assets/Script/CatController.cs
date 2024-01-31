using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody;
    [SerializeField] private float jumpForce = 680f;
    [SerializeField] private float moveForce = 3f;
    [SerializeField] private ClimbCloudGameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = 0f;
        
        if(Input.GetKeyDown(KeyCode.Space))
        //점프
        this.rbody.AddForce(this.transform.up * this.jumpForce);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionX = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            directionX = 1f;
        }
        if (directionX != 0f)
        {
            this.transform.localScale = new Vector3(directionX, 1f, 1f);
        }
        
        //도전 ! : 속도를 제한하자
        if (Mathf.Abs(this.rbody.velocity.x) < 3f)
        {
            this.rbody.AddForce(directionX * this.transform.right * moveForce);
        }
        
        this.gameDirector.UpdateVelocityText(this.rbody.velocity);
    }
}
