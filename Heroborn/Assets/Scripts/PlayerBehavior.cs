using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    private float vInput;
    private float hInput;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public float multi;
    private GameBehavior _gameManager;
    public AudioSource m_bullet;
   

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        
    }

    void Update()
    {
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation) as GameObject;
            m_bullet.Play();
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            
        }

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);

    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

    }

    private bool IsGrounded() 
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.x);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Item")
        {
            jumpVelocity = jumpVelocity * 1.1f;
            moveSpeed = moveSpeed * 1.25f;
            rotateSpeed = rotateSpeed * 1.25f;
            multi = 1.3f;
            this.transform.localScale = new Vector3(transform.localScale.x * multi, transform.localScale.y*multi, transform.localScale.z*multi);
        }

        if(collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }

}
