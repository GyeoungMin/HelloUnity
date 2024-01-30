using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //프리팹 에셋을 가지고 프리팹 인스턴스를 만든다.
    [SerializeField] private GameObject arrowPrefab;

    private CatEscapeGameDirector gameDirector;

    private float delta;    //경과된 시간 변수

    // Start is called before the first frame update
    void Start()
    {
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;    //이전 프레임과 현재 프레임 사이 시간
        //Debug.Log(delta);
        if (delta > 3 && gameDirector.GetHp() != 0f)  //3초보다 크다면
        {
            //위치 재 설정
            float randX = Random.Range(-8, 9);
            this.arrowPrefab.transform.position = new Vector3(randX, arrowPrefab.transform.position.y, arrowPrefab.transform.position.z);
            //생성
            List<GameObject> arrow = new List<GameObject>();
            arrow.Add(Object.Instantiate(this.arrowPrefab));
            //GameObject go = Object.Instantiate(this.arrowPrefab);
            //go.transform.position = new Vector3(randX, go.transform.position.y, go.transform.position.z);
            delta = 0; //경과 시간을 초기화
        }
    }
}
