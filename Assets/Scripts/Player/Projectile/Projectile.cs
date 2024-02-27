using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// 이동 방향
    /// </summary>
    [SerializeField] Vector3 m_shootDir;

    /// <summary>
    /// 이동 속도
    /// </summary>
    [SerializeField] float m_moveSpeed;

    [SerializeField] float m_destroyTime;

    public void SetUp(Vector3 argShootDir)
    {
        m_shootDir = argShootDir;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, argShootDir);
        Destroy(gameObject, m_destroyTime);
    }

    void Update()
    {
        transform.position += m_shootDir * m_moveSpeed * Time.deltaTime;
    }
}
