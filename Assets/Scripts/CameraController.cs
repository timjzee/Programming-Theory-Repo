using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 8, -10);

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
    }
}