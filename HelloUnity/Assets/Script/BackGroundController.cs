using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform[] backGrounds;

    private float backGroundY;
    private float topPos;
    private float bottomPos;
    // Start is called before the first frame update
    void Start()
    {
        this.backGroundY = Camera.main.orthographicSize * 2 + 2f;
        this.topPos = backGroundY * backGrounds.Length;
        this.bottomPos = -backGroundY;
        //Debug.Log(this.backGroundY);
        this.StartCoroutine(this.CoMove());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            for (int i = 0; i < backGrounds.Length; i++)
            {
                this.transform.Translate(Vector2.down * this.speed * Time.deltaTime);
                if (backGrounds[i].position.y < bottomPos)
                {
                    Vector3 nextPos = backGrounds[i].position;
                    nextPos = new Vector3(nextPos.x, nextPos.y + topPos, nextPos.z);
                    backGrounds[i].position = nextPos;
                    Debug.Log(this.transform.position.y);
                }
                yield return null;
            }
        }
    }
}
