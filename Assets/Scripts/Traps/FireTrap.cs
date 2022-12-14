using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;
    private bool active;

    private Health player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFireTrap());

            player = collision.GetComponent<Health>();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
    }

    private void FixedUpdate()
    {
        if (active && player != null)
            player.TakeDamage(damage);
    }

    private IEnumerator ActivateFireTrap()
    {
        //?????? ????? ???? ????????? ?? ?????????, ???? ??????? ?????????? ???????
        triggered= true;
        spriteRend.color = Color.red;

        //??????? ????????, ?????? ???????????, ????? ??????????
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        //???, ?????? ?????? ???? ??????????, ????? ???? ???????????
        yield return new WaitForSeconds(activeTime);
        triggered= false;
        active = false;
        anim.SetBool("activated", false);
    }

}
