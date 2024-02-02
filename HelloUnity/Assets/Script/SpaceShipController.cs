using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 3f;

    private Coroutine moveCoroutine;
    private Coroutine shootCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        this.moveCoroutine = this.StartCoroutine(CoMove());
        this.shootCoroutine = this.StartCoroutine(CoMove());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Jump"));
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            this.transform.Translate(Input.GetAxisRaw("Horizontal") * Vector3.right * maxSpeed * Time.deltaTime);
            this.transform.Translate(Input.GetAxisRaw("Vertical") * Vector3.up * maxSpeed * Time.deltaTime);
            float clampX = Mathf.Clamp(this.transform.position.x, -2.3f, 2.3f);
            float clampY = Mathf.Clamp(this.transform.position.y, -3.5f, 5.45f);
            Vector3 pos = this.transform.position;
            pos.x = clampX;
            pos.y = clampY;
            this.transform.position = pos;
            yield return null;
        }
    }


}
