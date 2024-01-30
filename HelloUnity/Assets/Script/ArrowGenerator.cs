using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    //������ ������ ������ ������ �ν��Ͻ��� �����.
    [SerializeField] private GameObject arrowPrefab;

    private CatEscapeGameDirector gameDirector;

    private float delta;    //����� �ð� ����

    // Start is called before the first frame update
    void Start()
    {
        this.gameDirector = GameObject.FindObjectOfType<CatEscapeGameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;    //���� �����Ӱ� ���� ������ ���� �ð�
        //Debug.Log(delta);
        if (delta > 3 && gameDirector.GetHp() != 0f)  //3�ʺ��� ũ�ٸ�
        {
            //��ġ �� ����
            float randX = Random.Range(-8, 9);
            this.arrowPrefab.transform.position = new Vector3(randX, arrowPrefab.transform.position.y, arrowPrefab.transform.position.z);
            //����
            List<GameObject> arrow = new List<GameObject>();
            arrow.Add(Object.Instantiate(this.arrowPrefab));
            //GameObject go = Object.Instantiate(this.arrowPrefab);
            //go.transform.position = new Vector3(randX, go.transform.position.y, go.transform.position.z);
            delta = 0; //��� �ð��� �ʱ�ȭ
        }
    }
}
