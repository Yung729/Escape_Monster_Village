using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform camTransform;
    public float parallaxEffect;
    private float length, startpos;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (camTransform.position.x - startpos) * (1 - parallaxEffect);
        transform.position = new Vector2(startpos + distance, transform.position.y);

        if (distance > length)
        {
            startpos += length;
        }
        else if (distance < -length)
        {
            startpos -= length;
        }
    }
}
