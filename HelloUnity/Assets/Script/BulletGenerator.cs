using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject player;

    private List<GameObject> list = new List<GameObject>();
    private Vector2 firePos;
    private Coroutine coroutine;
    //private Coroutine removeCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        this.coroutine = this.StartCoroutine(CoFire());
        //this.removeCoroutine = this.StartCoroutine(CoDestroyBullet());
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
                this.firePos = new Vector2(this.player.transform.position.x, this.player.transform.position.y + 0.7f);
                this.bulletPrefab.transform.position = this.firePos;
                Debug.Log("น฿ป็");
                this.list.Add(Instantiate(this.bulletPrefab));
            }
            yield return null;
        }
    }
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
