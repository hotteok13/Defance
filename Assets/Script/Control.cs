using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    float speed = 1.0f;
    int damage = 10;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // 애니메이터 컨트롤러에서 현재 애니메이터의 상태의 이름이“close”일 때 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            // 현재 애니메이션의 진행도가 1보다 크거나 같다면 User Interface를 비활성화하도록 설계하였습니다.
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                animator.Rebind();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            speed = 0.0f;
            animator.SetBool("Attack", true);
            
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Exit")
        {
            animator.SetBool("Attack", false);
            speed = 1.0f;
        }
    }


}
