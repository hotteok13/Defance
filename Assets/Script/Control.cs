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
        // �ִϸ����� ��Ʈ�ѷ����� ���� �ִϸ������� ������ �̸��̡�close���� �� 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            // ���� �ִϸ��̼��� ���൵�� 1���� ũ�ų� ���ٸ� User Interface�� ��Ȱ��ȭ�ϵ��� �����Ͽ����ϴ�.
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
