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

    private int chooser;
    helnth healthsoyoudonotdie;
    // Start is called before the first frame update
    void Start()
    {
        healthsoyoudonotdie = GetComponent<helnth>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack(Transform check, float damage)
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(check.position,range,enemyLayer);
        if(enemyHit != null)
        {

            foreach(Collider2D enemy in enemyHit)
            {
                if (enemy.gameObject != this.gameObject)
                    enemy.GetComponent<helnth>().GetSmashedIntoOblivion(damage);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(punchCheck.position,range);
        Gizmos.DrawWireSphere(kickCheck.position,range);
    }
}
