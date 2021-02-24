using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamilleController : MonoBehaviour
{
    private static readonly float GroundMargin = 0.01f;
    
    public float speed;
    public float vSpeed;
    public Rigidbody2D body;

    public GameObject soundWave;
    
    private Collider2D _collider2D;

    public Animator animator;
    
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

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float vSpeed_ = body.velocity.y;
        float hSpeed_ = speed * h;

        if (isGrounded && v > 0)
        {
            vSpeed_ = v * vSpeed;
        }

        if (v < 0)
        {
            animator.SetBool("crouched", true);
        }

        if (!isGrounded || v >= 0)
        {
            animator.SetBool("crouched", false);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            var x = _collider2D.bounds.min.x;
            var y = _collider2D.bounds.min.y + 2.71f;
            Instantiate(soundWave, new Vector3(x, y, 0), Quaternion.identity);
        }
        
        body.velocity = new Vector2(hSpeed_, vSpeed_);
    }
}
