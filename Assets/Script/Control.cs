using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    public float speed=3.0f;
    public int health = 100;
    Animator animator;
    public LayerMask [] layemask;
    public int attack = 10;
    private int count = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        // 애니메이터 컨트롤러에서 현재 애니메이터의 상태의 이름이“close”일 때 
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        RaycastHit hit;
        Ray ray = new Ray(transform.position,transform.forward);

        
        
        if (Physics.Raycast(ray, out hit, 2.0f, layemask[0]))
        {

            speed = 0.0f;
            animator.SetBool("Attack", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
            {
                // 현재 애니메이션의 진행도가 1보다 크거나 같다면 User Interface를 비활성화하도록 설계하였습니다.
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.98)
                {
                    count++;
                    hit.transform.GetComponent<MonsterControl>().health -= 10;
                }
            }
            
        }
        else if (Physics.Raycast(ray,out hit, 2.0f, layemask[1]))
        {
            speed = 0.0f;
            animator.SetBool("Attack", false);
        }
        else
        {
            speed = 3.0f;
            animator.SetBool("Attack", false); 
        }

        Debug.DrawRay(transform.position, transform.forward * 1.5f);
    }

  
    


}
