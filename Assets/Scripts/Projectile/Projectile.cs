using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 m_shootDir; // ����

    float m_moveSpeed; // �ӵ�
    float m_damage; // ������

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
