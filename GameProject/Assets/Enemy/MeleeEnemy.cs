using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    //"Header" k�saca grupland�rmaya yar�yor.
    [Header ("Attack Parameters")]
    //Private de�i�kenleri "[SerializeField]" arac�l���yla unity'de tan�ml�yoruz. B�yle yapmam�z�n sebebi de public yap�ld��� zaman olu�an g�venlik sorunu. Private o y�zden daha g�venli.
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;

    [Header("Collider Parameters")]
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    private EnemyPatrol enemyPatrol;


    //Normalde "GetComponent" ile unity'de animasyon atamas�n� yapt���m sald�r�lar�n karakterimizi g�r�nce farkedip vurmas� gerek ama bunu yapm�yor sebebini �imdilik ��zemedim.

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


    //Sald�r� bekleme s�resini ayarlar.
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Sadece oyuncu g�r�� alan�ndaysa sald�r�r.
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {

                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = PlayerInSight();
    }


    //Sald�r� menzili ve onun hitbox menzilini ayarlayan kodlar.
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),0,Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    //Yudar�da yazm�� oldu�umuz hitbox ve sald��� menzilinin s�n�rlar�n� unity �zerinde g�rebilmek i�in Gizmoz'u kulland�k.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
