using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_02_Anim : MonoBehaviour
{
    public void EndAttack()
    {
        GetComponentInParent<EnemyController>().EndAttack();
        GetComponentInParent<BossBehavior_02>().CurrentStateToZero();
    }
    public void EndStance()
    {
        GetComponent<Animator>().SetBool("isStance", false);
    }

    public void EndHurt()
    {
        GetComponentInParent<EnemyController>().EndHurt();
    }

    public void DestroyEnemy()
    {
        GetComponentInParent<EnemyController>().EnemyDestroy();
    }

    public void EndTransDash()
    {
        GetComponent<Animator>().SetBool("transDash", false);
        GetComponentInParent<BossBehavior_02>().SetCurrentState(5);
        GetComponentInParent<BoxCollider2D>().offset = new Vector2(-0.26f, -0.36f);
        GetComponentInParent<BoxCollider2D>().size = new Vector2(0.74f, 1.9f);
    }

    public void StartTransDash()
    {
        GetComponentInParent<BoxCollider2D>().offset = new Vector2(-1.3f, -0.3f);
        GetComponentInParent<BoxCollider2D>().size = new Vector2(2f, 1f);
    }
}
