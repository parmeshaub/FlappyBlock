using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public GameObject pipe;

    [Header("Movement Variables")]
    public float moveSpeed;
    private float minY = -2.19f;
    private float maxY = 4.28f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPosition = pipe.transform.position;
        newPosition.y = Random.Range(minY, maxY);

        pipe.transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(pipe.transform.position.x >= -14)
        {
            Vector3 newPosition = pipe.transform.position;
            newPosition.x -= moveSpeed * Time.deltaTime;

            pipe.transform.position = newPosition;
        }
        else
        {
            Vector3 newPosition = pipe.transform.position;
            newPosition.y = Random.Range(minY, maxY);
            newPosition.x = 14;

            pipe.transform.position = newPosition;
        }
    }
}
