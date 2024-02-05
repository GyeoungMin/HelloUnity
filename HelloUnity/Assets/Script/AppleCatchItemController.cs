using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AppleCatchItemController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(CoDrop(() =>
        {
            StopCoroutine(coroutine);
            Destroy(gameObject);
        }));
    }

    IEnumerator CoDrop(System.Action callback)
    {
        while (true)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (transform.position.y < 0)
            {
                break;
            }
            yield return null;
        }
        callback();
    }
}
