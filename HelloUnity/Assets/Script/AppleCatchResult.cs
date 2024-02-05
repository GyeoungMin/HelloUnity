using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCatchResult : MonoBehaviour
{
    [SerializeField] Text appleText;
    [SerializeField] Text bombText;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        int[] result = AppleCatchGameManager.GetResult();
        appleText.text = result[0].ToString();
        bombText.text = result[1].ToString();
        scoreText.text = result[2].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
