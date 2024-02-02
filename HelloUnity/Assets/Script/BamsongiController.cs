using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    private Rigidbody rbody;
    private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<Rigidbody>();

        this.rbody = this.GetComponent<Rigidbody>();
        this.particleSystem = this.GetComponent<ParticleSystem>();
        this.Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("OnCollisionEnter : {0} ",collision.gameObject.name);
        this.rbody.isKinematic = true;
        particleSystem.Play();
    }


    public void Shoot()
    {
        //this.rbody.AddForce(new Vector3(0, 200, 2000));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        this.rbody.AddForce(ray.direction * 2000f);
    }
}
