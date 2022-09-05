using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<PlayerControl>();
        player.ApplyParallelGravity = true;
        player.ApplyGravity = false;
        player.orbit = gameObject;
        other.gameObject.transform.rotation = gameObject.transform.rotation;
    }
    private void OnTriggerExit(Collider other)
    {
        player = other.gameObject.GetComponent<PlayerControl>();
        player.ApplyGravity = true;
        player.ApplyParallelGravity = false;
        player.orbit = GameObject.Find("Planet");
    }
}
