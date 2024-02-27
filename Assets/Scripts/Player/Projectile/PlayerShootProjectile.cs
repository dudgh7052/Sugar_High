using UnityEngine;

public class PlayerShootProjectile : MonoBehaviour
{
    // 나중에 컴포넌트를 여러개 만들어서 무기별로 관리하게 하면 될듯
    // 그리고 업그레이드를 하거나 할때 한꺼번에 관리하기 위한 컴포넌트도 필요할듯

    // ScriptableObject로 딜레이, 이동속도, 프리팹, 데미지, Destroy시간 가져오기
    [SerializeField] Transform m_projectilePrefab;

    /// <summary>
    /// 타겟 트랜스폼 - 나중에 제일 가까운 적 찾는 스크립트 만들기
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
    /// 발사체 생성 및 발사
    /// </summary>
    void Fire()
    {
        // 생성
        Transform _projectileTrans = Instantiate(m_projectilePrefab, transform.position, Quaternion.identity);

        // 타겟 위치 - 현재 위치(무기 발사위치) -> 발사 방향
        Vector3 _shootDir = m_targetPos.position - transform.position;
        _shootDir = _shootDir.normalized;
        _shootDir.Normalize();

        _projectileTrans.GetComponent<Projectile>().SetUp(_shootDir);
    }
}
