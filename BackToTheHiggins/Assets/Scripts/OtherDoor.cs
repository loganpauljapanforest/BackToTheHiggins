using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherDoor : MonoBehaviour
{
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "LastDoor" && GameManager.Divergence != 0)
            {
                Destroy(gameObject);
            }
            else
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}


