using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerMaxHp = 120;
    [SerializeField] private Button btnLeft;
    [SerializeField] private Button btnRight;

    private float playerHp;
    public float radius = 1f;
    private CatEscapeGameDirector gameDirector;

    public void Awake()
    {
        playerHp = playerMaxHp;
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //this.btnLeft.onClick.AddListener(this.LeftButtonClick);
        //this.btnRight.onClick.AddListener(this.RightButtonClick);
        this.btnLeft.onClick.AddListener(() => {
            Debug.Log("���� ȭ��ǥ ��ư Ŭ��");
            this.transform.Translate(-2, 0, 0);
            float clampX = Mathf.Clamp(this.transform.position.x, -8f, 8f);
            Vector3 pos = this.transform.position;
            pos.x = clampX;
            this.transform.position = pos;
        });
        this.btnRight.onClick.AddListener(() => {
            Debug.Log("������ ȭ��ǥ ��ư Ŭ��");
            this.transform.Translate(2, 0, 0);
            float clampX = Mathf.Clamp(this.transform.position.x, -8f, 8f);
            Vector3 pos = this.transform.position;
            pos.x = clampX;
            this.transform.position = pos;
        });

    }

    // Update is called once per frame
    void Update()
    {
        //float move = 0f;
        if (playerHp > 0)
        {
            //Ű���� �Է��� �޴� �ڵ� �ۼ�
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("�������� 2���ָ�ŭ �̵�");
                if (this.transform.position.x == -8)
                {
                    Debug.Log("���̻� ���� �Ұ����մϴ�.");
                }
                else
                {
                    this.transform.Translate(-2, 0, 0);
                }
                //move = -2f;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("���������� 2���ָ�ŭ �̵�");
                if (this.transform.position.x == 8)
                {
                    Debug.Log("���̻� ���� �Ұ����մϴ�.");
                }
                else
                {
                    this.transform.Translate(2, 0, 0);
                }
                //move = 2f;
            }
            //float moveX += this.transform.position.x + move;
            //float x = Mathf.Clamp(this.transform.position.x + move, -8, 8);

            //if (this.transform.position.x < 8 || this.transform.position.x > -8)
            //{
            //    this.transform.Translate(move, 0, 0);
            //}
        }
    }
    //�̺�Ʈ �Լ�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);
    }
    public void Hit(float arrowdamage)
    {
        playerHp -= arrowdamage;
        //Debug.Log(playerHp / playerMaxHp);
        gameDirector.DecreaseHp(playerHp / playerMaxHp);
    }

    public float GetHp()
    {
        return playerHp;
    }

    public void LeftButtonClick()
    {
        Debug.Log("LeftButtonClick");
    }
    public void RightButtonClick()
    {
        Debug.Log("RightButtonClick");
    }
}
