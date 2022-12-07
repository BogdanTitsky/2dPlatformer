using UnityEngine;

public class Run : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;

    [SerializeField] private float speed;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        float HorizontalImput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalImput * speed, body.velocity.y);

        if(HorizontalImput > 0.1f)
            transform.localScale = Vector3.one;
        else if(HorizontalImput < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);

        anim.SetBool("run", HorizontalImput != 0);
    }
}
