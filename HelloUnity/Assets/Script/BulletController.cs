using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{


    [SerializeField] private float bulletMaxSpeed = 5f;
    [SerializeField] private float damage;

    private Coroutine coroutine;
    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        this.coroutine = StartCoroutine(CoHitBullet(() =>
        {
            this.StopCoroutine(this.coroutine);
            Destroy(this.gameObject);
        }));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator CoHitBullet(System.Action callback)
    {
        while (true)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * bulletMaxSpeed, Space.Self);
            if (this.hit)
            {
                break;
            }
            if (this.transform.position.y >= 6.25f)
            {
                break;
            }

            yield return null;
        }
        callback();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Hit");
            //collider.GetComponent<EnemyController>().Hit(damage);
            Debug.Log(this.damage);
            this.hit = true;
        }
    }

    public float Damage { get { return this.damage; } set { } }
}
