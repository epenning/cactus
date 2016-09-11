using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerObjectController : MonoBehaviour {



    public float speed = 0f;
    public Rigidbody2D rbody;


    public int playerNum;

    public List<GameObject> cactiBalls;

    public GameObject cactiBallPrefab;

    public Vector3 startPos;

    public string hAxis;
    public string vAxis;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        Spawn();
    }

    void Spawn()
    {
        cactiBalls.Clear();
        transform.position = startPos;
        GameObject newCactiBall = GameObject.Instantiate(cactiBallPrefab);
        newCactiBall.transform.parent = transform;
        newCactiBall.transform.localPosition = Vector3.zero;
        cactiBalls.Add(newCactiBall);
    }

    // Update is called once per frame
    void Update () {
        // Movement
        var vx = Input.GetAxis(hAxis);
        var vy = Input.GetAxis(vAxis);




        var velocity = new Vector2(vx, vy);
        if (velocity.magnitude > 1)
            velocity.Normalize();

        rbody.velocity = velocity * speed;


        // Spike Extending
        if (Input.GetKeyDown("space"))
        {
            foreach(GameObject cactiBall in cactiBalls)
            {
                cactiBall.GetComponent<CactusController>().ExtendSpikes();
            }
        }
    }
}
