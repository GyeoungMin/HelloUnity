using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bamsongiPrefab;

    private Coroutine coroutine;
    private List<GameObject> bamsongi = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        this.coroutine = this.StartCoroutine(CoBamsongiGenertor(() =>
        {
            this.StopCoroutine(coroutine);
            this.bamsongi.Clear();
            Debug.Log(bamsongi.Count);
        }));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoBamsongiGenertor(System.Action callback)
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //bamsongiPrefab.transform.position = ray.origin;
                
                this.bamsongi.Add(Instantiate(bamsongiPrefab));
            }
            else if (Input.GetMouseButtonDown(1))
            {
                break;
            }
            yield return null;
        }
        callback();
    }
}
