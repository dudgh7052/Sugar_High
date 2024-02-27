using UnityEngine;

public class PlayerShootProjectile : MonoBehaviour
{
    // ���߿� ������Ʈ�� ������ ���� ���⺰�� �����ϰ� �ϸ� �ɵ�
    // �׸��� ���׷��̵带 �ϰų� �Ҷ� �Ѳ����� �����ϱ� ���� ������Ʈ�� �ʿ��ҵ�

    // ScriptableObject�� ������, �̵��ӵ�, ������, ������, Destroy�ð� ��������
    [SerializeField] Transform m_projectilePrefab;

    /// <summary>
    /// Ÿ�� Ʈ������ - ���߿� ���� ����� �� ã�� ��ũ��Ʈ �����
    /// </summary>
    [SerializeField] Transform m_targetPos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    /// <summary>
    /// �߻�ü ���� �� �߻�
    /// </summary>
    void Fire()
    {
        // ����
        Transform _projectileTrans = Instantiate(m_projectilePrefab, transform.position, Quaternion.identity);

        // Ÿ�� ��ġ - ���� ��ġ(���� �߻���ġ) -> �߻� ����
        Vector3 _shootDir = m_targetPos.position - transform.position;
        _shootDir = _shootDir.normalized;
        _shootDir.Normalize();

        _projectileTrans.GetComponent<Projectile>().SetUp(_shootDir);
    }
}
