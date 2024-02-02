using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletMaxSpeed = 5f;

    private bool hasCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoDestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * bulletMaxSpeed, Space.Self);
    }

    IEnumerator CoDestroyBullet()
    {
        while (true)
        {
            if (this.transform.position.y >= 6.25f)
            {
                Destroy(this.gameObject);
            }
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollider)
        {
            return;
        }
        Debug.Log("Hit");
        Destroy (this.gameObject);
        hasCollider = true;
    }
}
