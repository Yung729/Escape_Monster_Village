using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private Transform player;

    public GameObject keyPrompt = default;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
        if (ItemCollecter.getKey() == 1)
        {
            keyPrompt.SetActive(true);
        }
        else if (ItemCollecter.getKey() == 0)
        {
            keyPrompt.SetActive(false);
        }
    }


}
