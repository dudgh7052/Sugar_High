using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 m_shootDir; // 방향

    float m_moveSpeed; // 속도
    float m_damage; // 데미지

    public void Initialize(Vector3 argShootDir, float argSpeed, float argDamage, float argDisableTime)
    {
        m_moveSpeed = argSpeed;
        m_damage = argDamage;
        m_shootDir = argShootDir;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, argShootDir);
        Destroy(gameObject, argDisableTime);
    }

    void Update()
    {
        transform.position += m_shootDir * m_moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.g_enemyTag))
        {
            Destroy(this.gameObject);
        }
    }
}
