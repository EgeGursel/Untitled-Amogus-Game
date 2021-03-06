using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public ParticleSystem impactPS;
    int attackDamage = 40;
    public float speed = 20f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Collectable"))
        {
            return;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            try
            {
                collision.GetComponent<Enemy>().Damage(Mathf.RoundToInt(attackDamage * PlayerPrefs.GetFloat("AttackDamage")));
            }
            catch
            {
                collision.GetComponent<Boss>().Damage(Mathf.RoundToInt(attackDamage * PlayerPrefs.GetFloat("AttackDamage")));
            }
        }
        Instantiate(impactPS, transform.position, transform.rotation);
        AudioManager.instance.Play("projectilehit");
        CameraShake.Instance.Shake(2.5f, .16f);
        Destroy(gameObject);
    }
}
