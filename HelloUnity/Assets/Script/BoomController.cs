using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    [SerializeField] Animator anim;

    private GameObject[] aGo;
    private GameObject[] bGo;
    private GameObject[] cGo;
    private GameObject[] bulletGo;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        this.aGo = GameObject.FindGameObjectsWithTag("EnemyA");
        this.bGo = GameObject.FindGameObjectsWithTag("EnemyB");
        this.cGo = GameObject.FindGameObjectsWithTag("EnemyC");
        this.bulletGo = GameObject.FindGameObjectsWithTag("EnemyBullet");
        this.coroutine = this.StartCoroutine(this.CoBoom(() =>
        {
            this.StopCoroutine(coroutine);
            Destroy(this.gameObject);
        }));
    }

    IEnumerator CoBoom(System.Action callback)
    {
        while (true)
        {

            this.DestroyAllObject();
            for (int i = 0; i < 15; i++)
            {
                yield return null;
            }
            break;
        }
        callback();
    }
    void DestroyAllObject()
    {
        for (int i = 0; i < aGo.Length; i++)
        {
            Destroy(aGo[i]);
        }
        for (int i = 0; i < bGo.Length; i++)
        {
            Destroy(bGo[i]);
        }
        for (int i = 0; i < cGo.Length; i++)
        {
            Destroy(cGo[i]);
        }
        for (int i = 0; i < bulletGo.Length; i++)
        {
            Destroy(bulletGo[i]);
        }
    }
}
