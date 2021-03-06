using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 15;
	public int enragedAttackDamage = 30;

	public Vector3 attackOffset;
	public float attackRange = 0.7f;
	public LayerMask attackMask;

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<Player>().TakeDamage(attackDamage);
		}
	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<Player>().TakeDamage(enragedAttackDamage);
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
			collision.gameObject.GetComponent<Player>().TakeDamage(enragedAttackDamage);
		}
    }
}