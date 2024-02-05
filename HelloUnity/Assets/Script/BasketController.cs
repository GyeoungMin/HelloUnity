using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BasketController : MonoBehaviour
{
    [SerializeField] private AudioClip appleSfx;
    [SerializeField] private AudioClip bombSfx;
    [SerializeField] private GameObject gameDirectorGo;
    private Coroutine coroutine;
    private AudioSource audioSource;
    public float score { get; private set; }
    private int appleCount;
    private int bombCount;
    private bool timeUp;
    // Start is called before the first frame update
    void Start()
    {
        timeUp = false;
        appleCount = 0;
        bombCount = 0;
        score = 0;
        audioSource = GetComponent<AudioSource>();
        coroutine = StartCoroutine(CoMove(()=>
        {
            StopCoroutine(coroutine);
            AppleCatchGameManager.AppleCatchResult(score, appleCount, bombCount);
        }));
    }

    IEnumerator CoMove(System.Action callback)
    {
        while (true)
        {
            if (timeUp = gameDirectorGo.GetComponent<AppleCatchGameDirector>().timeUp)
            {
                break;
            }
            if (Input.GetMouseButtonDown(0))
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
        callback();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Apple")
        {
            appleCount++;
            score += 100f;
            audioSource.PlayOneShot(appleSfx);
        }
        else if (other.CompareTag("Bomb"))
        {
            bombCount++;
            score *= 0.5f;
            audioSource.PlayOneShot(bombSfx);
        }
        Destroy(other.gameObject);
    }
}