using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bullet2Prefab;
    [SerializeField] private GameObject player;

    //private List<GameObject> list = new List<GameObject>();
    private Transform firePoint;
    private Coroutine coroutine;
    private Coroutine removeCoroutine;
    private float bulletDamage = 1f;
    private GameObject presentBullet;
    // Start is called before the first frame update
    void Start()
    {
        this.presentBullet = this.bulletPrefab;
        this.coroutine = this.StartCoroutine(CoFire());
        //this.removeCoroutine = this.StartCoroutine(CoDestroyBullet());
        this.firePoint = player.transform.Find("FirePoint");
    }
    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator CoFire()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //this.firePos = new Vector2(this.player.transform.position.x, this.player.transform.position.y + 0.7f);
                //this.bulletPrefab.transform.position = this.firePoint.position;
                Debug.Log("발사");
                //GameObject bullet = this.SetPower();
                //bullet.transform.position = this.firePoint.position;
                //Instantiate(bullet);
                //this.list.Add(Instantiate(bullet));
                this.presentBullet.transform.position = this.firePoint.position;
                Instantiate(presentBullet);
            }
            yield return null;
        }
    }
    //GameObject SetPower(float power)
    public void PowerUp()
    {
        this.bulletDamage += 1f;
        switch(this.bulletDamage)
        {
            case 1: this.presentBullet = this.bulletPrefab; break;
            case 2: this.presentBullet = this.bullet2Prefab; break;
            case 3: break;
            default: break;
        }
    }
    //public void Fire(Transform firepoint)
    //{
    //    Debug.Log("발사");
    //    this.list.Add(Instantiate(this.bulletPrefab, firepoint));
    //}
    //IEnumerator CoDestroyBullet()
    //{
    //    foreach (GameObject go in this.list)
    //    {
    //        if (go.transform.position.y >= 6.25f)
    //        {
    //            Destroy(go);
    //        }
    //        list.Remove(go);
    //        yield return null;
    //    }
    //}
}
