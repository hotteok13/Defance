using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{

    public float speed;
    private float saveSpeed;
    public int health = 100;
    Animator animator;
    public LayerMask [] layemask;
    public int attack;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        saveSpeed = speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (health <= 0)
        {
            Destroy(gameObject);
        }


        RaycastHit hit;
        Ray ray = new Ray(transform.position,transform.forward);



        if (Physics.Raycast(ray, out hit, 2.0f, layemask[0]))
        {

            
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
            {
                // 현재 애니메이션의 진행도가 1보다 크거나 같다면 User Interface를 비활성화하도록 설계하였습니다.
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    animator.Rebind();
                    hit.transform.GetComponent<Control>().health -= attack;
                }
            }
            speed = 0.0f;
            animator.SetBool("Attack", true);


        }
        else if (Physics.Raycast(ray, out hit, 2.0f, layemask[1]))
        {
            speed = 0.0f;
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", true);
        }
        else
        {
            speed = saveSpeed;
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", false);
        }

        Debug.DrawRay(transform.position, transform.forward * 1.5f);
    }

   
  
    


}
