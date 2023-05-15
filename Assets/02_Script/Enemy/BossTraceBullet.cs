
using UnityEngine;

public class BossTraceBullet : MonoBehaviour
{
    public float moveSpeed = 5f;
    PlayerMove player;
    int bulletHp=3;
    public int bulletHpMax = 3;
    int randomSeed=0;
    Vector3 randomDir=Vector3.zero;

    private void OnEnable()
    {
        bulletHp = bulletHpMax;
        player = FindObjectOfType<PlayerMove>();
        if (Random.Range(0f, 1f) > 0.5f)
            randomSeed = 1;
        else
            randomSeed = 0;
    }
    private void Update()
    {
        if(player!=null)
            LookTarget(player.transform);

        if (randomSeed == 0)
            randomDir = transform.up;
        else
            randomDir = -transform.up;

        transform.Translate(moveSpeed * Time.deltaTime * (transform.right + randomDir) , Space.Self);
    }

    void LookTarget(Transform target)
    {
        Vector3 lookDirection = target.position - transform.position;
        lookDirection.z = 0f;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            bulletHp--;
            if(bulletHp<1)
                gameObject.SetActive(false);
        }
        else if (collision.CompareTag("KillZone") || collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
