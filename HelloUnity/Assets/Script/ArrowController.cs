using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float arrowDamage = 5f;
    //�������� �����Ǵ� �ִ� ���� �ִ°� Assign �� �� ����.

    private PlayerController player;
    //private CatEscapeGameDirector gameDirector;
    
    private GameObject playerGo;
    // Start is called before the first frame update
    void Start()
    {
        //�̸����� ���ӿ�����Ʈ�� ã�´�.
        this.playerGo = GameObject.Find("player");    

        //Ÿ������ ������Ʈ�� ã�´�.
        //this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
        
        this.player = GameObject.FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //���� * �ӵ� * �ð�
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        this.transform.Translate(movement);
        //Debug.LogFormat("y : {0}", this.transform.position.y);

        //���� y ��ǥ�� -3���� �۾������� ������ �����Ѵ�.
        if (this.transform.position.y <= -3f)
        {
            //Debug.LogError("����!");
            //Destroy(this);    => ������Ʈ�� ���� �ȴ�.
            Destroy(this.gameObject);   //���ӿ�����Ʈ�� ������ ����
        }
        Vector2 p1 = this.transform.position;
        Vector2 p2 = playerGo.transform.position;
        Vector2 dir = p1 - p2;  //����
        float distance = dir.magnitude; //�Ÿ�
        //float distance = Vecotr2.Distance(p1, p2);

        float r1 = this.radius;
        float r2 = this.playerGo.GetComponent<PlayerController>().radius;
        float sumRadius = (r1 + r2) * 0.85f;

        if(distance < sumRadius)    //�浹��
        {
            //Debug.LogFormat("�浹�� : {0}, {1}", distance, sumRadius);
            Destroy(this.gameObject);

            this.player.Hit(this.arrowDamage);
            //this.gameDirector.DecreaseHp();
        }
        if (player.GetHp() == 0f)
        {
            Destroy(this.gameObject);
        }

    }
    //�̺�Ʈ �Լ�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
}
