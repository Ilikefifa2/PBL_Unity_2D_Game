using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator animator;
    public int maxHealthPoint;
    public int currentHealthPoint;
    public int attackDamage;
    public float attackSpeed = 1;
    public bool attacked = false;
    public Image currentHealthBar;

    //MonoBehaviour - It means that Player Class can use Functions or variables that provided by Unity
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        maxHealthPoint = 50;
        currentHealthPoint = 50;
        attackDamage = 10;
        SetAttackSpeed(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0.0f;
        currentHealthBar.fillAmount = (float)currentHealthPoint / (float)maxHealthPoint;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f;
            transform.localScale = new Vector2(-horizontal, 1);
            animator.SetBool("moving", true);
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;
            transform.localScale = new Vector2(-horizontal, 1);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        if(Keyboard.current.zKey.isPressed && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack"); 
        }

        Vector2 position = transform.position;
        //Vector2 localScale = transform.localScale;
        position.x = position.x + 0.01f * horizontal;
        //localScale.x = localScale.x + 0.1f * horizontal;
        transform.position = position;

     
       

        ////transform.position = new Vector2(0, 1);
        ////Input.GetAxis ? function that uses Input Manager Axes
        //float h = Input.GetAxis("Horizontal");
        //Debug.Log("Horizontal: " + h);
        ////if I press left arrow key, h -> 1
        //if(h > 0)
        //{
        //    //transform.localScale ? change current object's scale
        //    transform.localScale = new Vector2(-1, 1);
        //    animator.SetBool("moving", true);
        //    animator.SetFloat("move", h);
        //}

        ////if I press right arrow key, h -> -1
        //else if (h < 0)
        //{
        //    transform.localScale = new Vector2(1, 1);
        //    animator.SetBool("moving", true);
        //    animator.SetFloat("move", h);
        //}
        //else
        //{
        //    animator.SetBool("moving", false);
        //    animator.SetFloat("move", h);
        //}

        ////Translate ? function that it can move indicate path
        ////Time.deltaTime ? time per 1 frame
        //transform.Translate(new Vector2(h,0) * Time.deltaTime);
    }

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }
    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        attackSpeed = speed;
    }
}
