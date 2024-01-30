using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float arrowDamage = 5f;
    //동적으로 생성되는 애는 씬에 있는거 Assign 할 수 없다.

    private PlayerController player;
    //private CatEscapeGameDirector gameDirector;
    
    private GameObject playerGo;
    // Start is called before the first frame update
    void Start()
    {
        //이름으로 게임오브젝트를 찾는다.
        this.playerGo = GameObject.Find("player");    

        //타입으로 컴포넌트를 찾는다.
        //this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
        
        this.player = GameObject.FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //방향 * 속도 * 시간
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        this.transform.Translate(movement);
        //Debug.LogFormat("y : {0}", this.transform.position.y);

        //현재 y 좌표가 -3보다 작아졌을때 씬에서 제거한다.
        if (this.transform.position.y <= -3f)
        {
            //Debug.LogError("제거!");
            //Destroy(this);    => 컴포넌트가 제거 된다.
            Destroy(this.gameObject);   //게임오브젝트를 씬에서 제거
        }
        Vector2 p1 = this.transform.position;
        Vector2 p2 = playerGo.transform.position;
        Vector2 dir = p1 - p2;  //방향
        float distance = dir.magnitude; //거리
        //float distance = Vecotr2.Distance(p1, p2);

        float r1 = this.radius;
        float r2 = this.playerGo.GetComponent<PlayerController>().radius;
        float sumRadius = (r1 + r2) * 0.85f;

        if(distance < sumRadius)    //충돌함
        {
            //Debug.LogFormat("충돌함 : {0}, {1}", distance, sumRadius);
            Destroy(this.gameObject);

            this.player.Hit(this.arrowDamage);
            //this.gameDirector.DecreaseHp();
        }
        if (player.GetHp() == 0f)
        {
            Destroy(this.gameObject);
        }

    }
    //이벤트 함수
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
