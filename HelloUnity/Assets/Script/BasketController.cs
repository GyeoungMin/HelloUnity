using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField] private AudioClip appleSfx;
    [SerializeField] private AudioClip bombSfx;

    private Coroutine coroutine;
    private AudioSource audioSource;
    private float score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coroutine = StartCoroutine(CoMove());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray.origin, ray.direction, out hit, 20f))
                {
                    int x = Mathf.RoundToInt(hit.point.x);
                    int z = Mathf.RoundToInt(hit.point.z);

                    this.transform.position = new Vector3(x, 0, z);
                }
            }
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Apple")
        {
            Debug.Log("µÊ¡°");
            score += 100f;
            audioSource.PlayOneShot(appleSfx);
        }
        else if (other.CompareTag("Bomb"))
        {
            Debug.Log("∞®¡°");
            score *= 0.5f;
            audioSource.PlayOneShot(bombSfx);
        }
        Destroy(other.gameObject);
    }
    public float Score { get { return score; } }
}
