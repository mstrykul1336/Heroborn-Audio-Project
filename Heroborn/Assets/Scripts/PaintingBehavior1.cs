using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingBehavior1 : MonoBehaviour
{
    public GameBehavior gameManager;
    public AudioSource m_cat_scratch;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        m_cat_scratch = GameObject.Find("Catscratch").GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            gameManager.Paintings += 1;
            m_cat_scratch.Play();
        }

    }
}
