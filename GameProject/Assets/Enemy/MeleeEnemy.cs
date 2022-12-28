using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    //"Header" kýsaca gruplandýrmaya yarýyor.
    [Header ("Attack Parameters")]
    //Private deðiþkenleri "[SerializeField]" aracýlýðýyla unity'de tanýmlýyoruz. Böyle yapmamýzýn sebebi de public yapýldýðý zaman oluþan güvenlik sorunu. Private o yüzden daha güvenli.
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


    //Normalde "GetComponent" ile unity'de animasyon atamasýný yaptýðým saldýrýlarýn karakterimizi görünce farkedip vurmasý gerek ama bunu yapmýyor sebebini þimdilik çözemedim.

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


    //Saldýrý bekleme süresini ayarlar.
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Sadece oyuncu görüþ alanýndaysa saldýrýr.
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


    //Saldýrý menzili ve onun hitbox menzilini ayarlayan kodlar.
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),0,Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    //Yudarýda yazmýþ olduðumuz hitbox ve saldýðý menzilinin sýnýrlarýný unity üzerinde görebilmek için Gizmoz'u kullandýk.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
