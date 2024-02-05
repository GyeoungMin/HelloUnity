using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCatchItemGenerator : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject gameDirectorGo;

    private Coroutine coroutine;
    private bool timeUp;
    // Start is called before the first frame update
    void Start()
    {
        timeUp = false;
        coroutine = StartCoroutine(CoGenerate(() =>
        {
            StopCoroutine(coroutine);
        }));
    }

    IEnumerator CoGenerate(System.Action callback)
    {
        while (true)
        {
            timeUp = gameDirectorGo.GetComponent<AppleCatchGameDirector>().timeUp;
            if (timeUp)
            {
                break;
            }
            ItemInstantiate(applePrefab);
            ItemInstantiate(bombPrefab);
            for (int i = 0; i < 60; i++)
            {
                yield return null;
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
