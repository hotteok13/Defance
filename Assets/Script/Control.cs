using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Walk,
    Attack,
    Idle,

}

public class Control : MonoBehaviour
{
    State state;
    public float speed;
    private float saveSpeed;
    public int health = 100;
    Animator animator;
    public LayerMask [] layemask;
    public int attack;
    private int count = 1;

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

            speed = 0.0f;
            animator.SetBool("Attack", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
            {
                // ���� �ִϸ��̼��� ���൵�� 1���� ũ�ų� ���ٸ� User Interface�� ��Ȱ��ȭ�ϵ��� �����Ͽ����ϴ�.
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    animator.Rebind();
                    hit.transform.GetComponent<MonsterControl>().health -= attack;
                }
            }
            
        }
        else if (Physics.Raycast(ray,out hit, 2.0f, layemask[1]))
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
