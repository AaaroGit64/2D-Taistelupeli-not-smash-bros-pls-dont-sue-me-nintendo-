using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helnth : MonoBehaviour
{
    public float maxhealth = 100;

    public float health;

    public float HitTimer = 0.15f;

    public bool isHit = false;

    public Rigidbody2D myRigidbody;
    scripts4scrubslikeme moveScript;
    hitpeopleuntiltheyfingdie fightingScript;


    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<scripts4scrubslikeme>();
        fightingScript = GetComponent<hitpeopleuntiltheyfingdie>();
        health = maxhealth;

    }

    // Update is called once per frame
    void Update()
    {
       if (health <= 0);
       {
            Die();

       }
       
    }

    private void Die()
    {
        // make hurt
    }

    public void GetSmashedIntoOblivion(float philSwift)
    {
        if(!isHit)
        {
            // fuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuck
            // fuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuck
            // fuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuck
            // fuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuck
            // fuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuck
            // fuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuck
            // fuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuck
            // fuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuckfuck
            if (fightingScript.blockCheck)
            {
                health -= philSwift / 2;

            }
            else
            {
                // now that's a lotta damage
                health -= philSwift;
                StartCoroutine(Knockback());
            }

        }
       
        

    }

    IEnumerator Knockback()
    {
        //Käskyt välittömästi
        isHit = true;
        myRigidbody.velocity = new Vector2(moveScript.facing * -2.5f, 2.5f);
        //kalkulator
        yield return new WaitForSeconds(HitTimer);
        //Ajastimen jälkeen tapahtuvat käskyt
        isHit = false;

    }

}
