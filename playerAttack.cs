﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    private Animator anim;
    private bool activeTimeToReset;

    private float defaultComboTimer = .2f, currentComboTimer;

    private int combo;

    public Transform attackPos;
    public LayerMask enemyLayer;

    float attackRange;
    public int daimage;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Punch();
        ResetComboState();
    }



    void Punch()
    {
        if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (combo < 2)
            {
                anim.SetBool("Punch", true);
                activeTimeToReset = true;
                currentComboTimer = defaultComboTimer;

                Collider2D[] attackEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);

                for (int i = 0; i < attackEnemies.Length; i++)
                {
             
                    print("hit");
                }

            }
            else
            {
                anim.SetBool("Punch", false);
            }
        }
    }

    //Ye function combo ++

    public void IncreasComboNumber()
    {
        combo++;
    }
    //ye FuncN combo ko 0 IF no action\combo++
    public void ResetCombo()
    {
        combo = 0;
    }
    // ye function is for reset combo if no markatt
    void ResetComboState()
    {
        if(activeTimeToReset)
        {
            currentComboTimer -= Time.deltaTime;
            if(currentComboTimer <= 0)
            {
                anim.SetBool("Punch", false);
                activeTimeToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}