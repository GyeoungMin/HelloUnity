using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Vector2 dir;
    private float speed;
    private Coroutine coroutine;
    private bool getItem = false;

    // Start is called before the first frame update
    void Start()
    {
        this.dir = Random.insideUnitCircle;
        this.speed = Random.Range(3f, 5f);
        //this.player = 
        this.coroutine = this.StartCoroutine(CoMove(() =>
        {
            this.StopCoroutine(this.coroutine);
            Destroy(this.gameObject);
        }));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            //Debug.Log(this.gameObject.ToString());
            this.getItem = true;
        }
    }

    IEnumerator CoMove(System.Action callback)
    {
        while (true)
        {
            if (getItem)
            {
                break;
            }
            Vector3 pos = this.transform.position;

            //������ �̵����� �� �ӵ� �Ҵ� �� �̵�
            if (pos.x == -2.55f || pos.x == 2.55f)
            {
                this.dir.x = -dir.x;
            }
            if (pos.y == -3.8f || pos.y == 5.8f)
            {
                this.dir.y = -dir.y;
            }
            this.transform.Translate(this.dir * this.speed * Time.deltaTime);

            //�������� ������ �ȳ����� �����
            float clampX = Mathf.Clamp(this.transform.position.x, -2.55f, 2.55f);
            float clampY = Mathf.Clamp(this.transform.position.y, -3.8f, 5.8f);
            this.transform.position = new Vector2(clampX, clampY);
            yield return null;
        }
        callback();
    }
}
