using UnityEngine;

public class PlayerShootProjectile : MonoBehaviour
{
    // ���߿� ������Ʈ�� ������ ���� ���⺰�� �����ϰ� �ϸ� �ɵ�
    // �׸��� ���׷��̵带 �ϰų� �Ҷ� �Ѳ����� �����ϱ� ���� ������Ʈ�� �ʿ��ҵ�
    [SerializeField] ProjectileData m_data; // ������
    [SerializeField] Transform m_targetPos; // Ÿ�� Ʈ������ - ���߿� ���� ����� �� ã�� ��ũ��Ʈ �����

    public float m_timer; // Ÿ�̸�
    public float m_coolTime; // �߻� ��Ÿ��

    void Awake()
    {
        m_coolTime = m_data.m_coolTime;
    }

    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer > m_coolTime)
        {
            m_timer = default;
            Fire();
        }
    }

    /// <summary>
    /// �߻�ü ���� �� �߻�
    /// </summary>
    void Fire()
    {
        // ����
        //Transform _projectileTrans = Instantiate(m_data.m_projectilePrefab, transform.position, Quaternion.identity);
        GameObject _projectile = PoolManager.Get(m_data.m_projectilePrefab);

        _projectile.transform.position = transform.position;

        // Ÿ�� ��ġ - ���� ��ġ(���� �߻���ġ) -> �߻� ����
        Vector3 _shootDir = m_targetPos.position - transform.position;
        _shootDir = _shootDir.normalized;
        _projectile.transform.rotation = Quaternion.FromToRotation(Vector3.up, _shootDir);
        _shootDir.Normalize();

        _projectile.GetComponent<Projectile>().Initialize(_shootDir, m_data.m_speed, m_data.m_damage, m_data.m_disableTime);
    }
}
