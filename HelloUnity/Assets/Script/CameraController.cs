using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = this.transform.position;

        cameraPos.y = this.player.transform.position.y;
        if (cameraPos.y < 1f)
        {
            cameraPos.y = 1f;
        }
        this.transform.position = cameraPos;
    }
}
