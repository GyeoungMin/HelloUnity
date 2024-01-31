using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClimbCloudGameDirector : MonoBehaviour
{
    [SerializeField] private Text velocityText;

    public void UpdateVelocityText(Vector2 velocity)
    {
       this.velocityText.text = velocity.ToString();
    }

    void Update()
    {
        

    }
}
