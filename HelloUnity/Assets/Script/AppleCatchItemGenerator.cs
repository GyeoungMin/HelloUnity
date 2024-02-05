using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCatchItemGenerator : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject bombPrefab;

    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(CoGenerate(() =>
        {
            StopCoroutine(coroutine);
        }));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator CoGenerate(System.Action callback)
    {
        while (true)
        {
            ItemInstantiate(applePrefab);
            ItemInstantiate(bombPrefab);
            for (int i = 0; i < 60; i++)
            {
                yield return null;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
        }
        callback();
    }

    private void SetPrefabPosition(GameObject prefab)
    {
        int x = Random.Range(-1, 2);
        int z = Random.Range(-1, 2);

        prefab.transform.position = new Vector3(x, 3, z);

    }
    private void ItemInstantiate(GameObject prefab)
    {
        SetPrefabPosition(prefab);
        Instantiate(prefab);
    }
}
