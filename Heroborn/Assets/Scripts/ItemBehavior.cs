using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    public AudioSource m_cat_crunch;
   

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        m_cat_crunch = GameObject.Find("Catscrunch").GetComponent<AudioSource>();
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            m_cat_crunch.Play();
            Destroy(this.transform.parent.gameObject);
            gameManager.Items += 1;
            
        }
    }
}
