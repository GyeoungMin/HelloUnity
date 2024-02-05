using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisakiController : MonoBehaviour
{
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 20))
            {
                Vector3 tpos = new Vector3(hit.point.x, 0, hit.point.z);
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                coroutine = StartCoroutine(CoMove(tpos));
            }

            IEnumerator CoMove(Vector3 tpos)
            {
                while (true)
                {
                    transform.LookAt(tpos);
                    transform.Translate(Vector3.forward * Time.deltaTime * 1f);
                    float distance = (tpos - transform.position).magnitude;
                    if (distance < 1f)
                    {
                        break;
                    }
                    yield return null;
                }
            }

        }
    }

}
