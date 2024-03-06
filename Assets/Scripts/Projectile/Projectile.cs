using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 m_shootDir; // 방향

    float m_moveSpeed; // 속도
    float m_damage; // 데미지

    void Update()
    {
        transform.position += m_shootDir * m_moveSpeed * Time.deltaTime;
    }

    private void OnDisable()
    {
        PoolManager.Return(gameObject);
    }

    public void Initialize(Vector3 argShootDir, float argSpeed, float argDamage, float argDisableTime)
    {
        m_moveSpeed = argSpeed;
        m_damage = argDamage;
        m_shootDir = argShootDir;
        //Destroy(gameObject, argDisableTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.g_enemyTag))
        {
            gameObject.SetActive(false);
        }
    }
}
