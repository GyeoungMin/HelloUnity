using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerMaxHp = 120;

    private float playerHp;
    public float radius = 1f;
    private CatEscapeGameDirector gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = playerMaxHp;
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        //float move = 0f;
        if (playerHp > 0)
        {
            //키보드 입력을 받는 코드 작성
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("왼쪽으로 2유닛만큼 이동");
                if (this.transform.position.x == -8)
                {
                    Debug.Log("더이상 진행 불가능합니다.");
                }
                else
                {
                    this.transform.Translate(-2, 0, 0);
                }
                //move = -2f;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("오른쪽으로 2유닛만큼 이동");
                if (this.transform.position.x == 8)
                {
                    Debug.Log("더이상 진행 불가능합니다.");
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
        //이벤트 함수
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
    }
