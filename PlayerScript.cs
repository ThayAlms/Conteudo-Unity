using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    private Animator anim_c;
    private Rigidbody2D rb2d;
    public float speed = 2f;
    private float h;
    public bool isJumping, aux, onTheFloor;
    public Vector2 jumpHeight;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim_c = GetComponent<Animator>();
        isJumping = false;
        aux = false;
    }

    void Update()
    {
        GetAxis();
        MovementAnimationManager();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(JumpSystem());
        }
    }

    void FixedUpdate()
    {
        ApplyingPhysics();
    }

    void GetAxis()
    {
        h = Input.GetAxisRaw("Horizontal") * speed;
    }

    void ApplyingPhysics()
    {
        rb2d.MovePosition(rb2d.position + new Vector2(h * Time.fixedDeltaTime, 0.0f));
    }

    void MovementAnimationManager()
    {
        if (h > 0 && !isJumping)
        {
            anim_c.SetInteger("state", 3);
        }
        else if (h < 0 && !isJumping)
        {
            anim_c.SetInteger("state", 2);
        }
        else if (h == 0 && !isJumping)
        {
            anim_c.SetInteger("state", 0);
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("floor"))
        {
            onTheFloor = true;
            rb2d.gravityScale = 1;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("floor"))
        {
            rb2d.gravityScale = 15;
            onTheFloor = false;
        }
    }

    IEnumerator JumpSystem()
    {
        if (!isJumping && !aux)
        {
            isJumping = true;
            anim_c.SetInteger("state", 1);
            rb2d.AddForce(jumpHeight, ForceMode2D.Impulse);
            aux = true;
            yield return new WaitForSeconds(0.8f);
            aux = false;
            isJumping = false;
        }
    }

    public void DisableJump()
    {
        isJumping = false;
    }
}
