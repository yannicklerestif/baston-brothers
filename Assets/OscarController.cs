using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarController : MonoBehaviour
{
    private static readonly float GroundMargin = 0.01f;
    
    public float speed;
    public float vSpeed;
    public Rigidbody2D body;

    public GameObject bullet;
    
    private Collider2D _collider2D;

    public Animator animator;

    public float HealthPoints = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var bottomX = _collider2D.bounds.center.x;
        var bottomY = _collider2D.bounds.center.y - _collider2D.bounds.extents.y;
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(new Vector2(bottomX, bottomY),
            new Vector2(GroundMargin, -GroundMargin), 0);
        bool isGrounded = collider2Ds.Length == 2;

       
        float h = Input.GetKey(KeyCode.Z) ? -1 : Input.GetKey(KeyCode.C) ? 1 : 0;
        float v = Input.GetKey(KeyCode.X) ? -1 : Input.GetKey(KeyCode.S) ? 1 : 0;

        float vSpeed_ = body.velocity.y;
        float hSpeed_ = speed * h;

        if (isGrounded && v > 0)
        {
            vSpeed_ = v * vSpeed;
        }
        
        bool isCrouched = v < 0 && isGrounded;
        animator.SetBool("crouched", isCrouched);
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            var x = _collider2D.bounds.max.x + 1.25f;
            var y = _collider2D.bounds.min.y + (isCrouched ? 1.73f : 2.5f);
            Instantiate(bullet, new Vector3(x, y, 0), Quaternion.identity);
        }

        body.velocity = new Vector2(hSpeed_, vSpeed_);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        HealthPoints -= 0.05f;
    }
}
