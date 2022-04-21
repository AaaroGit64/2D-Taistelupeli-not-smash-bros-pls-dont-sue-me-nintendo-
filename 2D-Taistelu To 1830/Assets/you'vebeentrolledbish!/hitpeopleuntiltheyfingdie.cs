using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitpeopleuntiltheyfingdie : MonoBehaviour
{
    public float punchDamage = 3f;

    public float kickDamage = 4;

    public bool blockCheck = false;
    public Transform punchCheck;
    public Transform kickCheck;

    public float range = 1.5f;

    public LayerMask enemyLayer;
    public float cooldown = 0.20f;

    private float cooldownTimer;

    private bool hit = false;
    private bool ifpunchhappen = false;
    private int chooser;
    helnth healthsoyoudonotdie;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        healthsoyoudonotdie = GetComponent<helnth>();
        animator = GetComponent<Animator>();
    
    }


    // Update is called once per frame
    void Update()
    {
        if (!healthsoyoudonotdie.isHit)
        {
            return;


        }
        if (!blockCheck && !ifpunchhappen && cooldownTimer <= 0)
        {
            if (healthsoyoudonotdie.isDummy)
            {
                return;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Punch();

            }
            if (Input.GetButtonDown("Fire2"))
            {
                Kick();

            }


            if (Input.GetButtonDown("Fire3"))
            {
                Block();

            }
            if (Input.GetButtonUp("Fire3"))
            {
                BlockEnd();

            }
            if (hit)
            {
                if (cooldownTimer > 0)
                {
                    cooldownTimer = -Time.deltaTime;

                }
                else
                {
                    ifpunchhappen = false;
                }

            }
        }
    }

        void Attack(Transform check, float damage)
        {
            Collider2D[] enemyHit = Physics2D.OverlapCircleAll(check.position, range, enemyLayer);
            if (enemyHit != null)
            {

                foreach (Collider2D enemy in enemyHit)
                {
                    if (hit == false)
                    {
                        if (enemy.gameObject != this.gameObject)
                        {
                            Debug.Log("Take Damage");
                            enemy.GetComponent<helnth>().GetSmashedIntoOblivion(damage);
                            hit = true;
                        }

                    }

                }
                hit = false;
            }
            ifpunchhappen = true;
            cooldownTimer = cooldown;
        }
    }
    private void Kick()
    {
        if (healthsoyoudonotdie.isDummy)
        {
            return;
        }
        //cope
        animator.SetTrigger("Keft");
        Attack(kickCheck, kickDamage);

    }

    private void Punch()
    {
        if (healthsoyoudonotdie.isDummy)
        {
            return;
        }
        //harder
        animator.SetTrigger("Peft");
        Attack(punchCheck, punchDamage);

    }
    private void Block()
    {
        if (healthsoyoudonotdie.isDummy)
        {
            return;
        }
    
        blockCheck = true;

    }
    private void BlockEnd()
    {
        if (healthsoyoudonotdie.isDummy)
        {
            return;
        }
        blockCheck = false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(punchCheck.position,range);
        Gizmos.DrawWireSphere(kickCheck.position,range);
    }
}
