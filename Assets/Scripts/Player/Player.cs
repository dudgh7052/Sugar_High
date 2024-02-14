using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 입력 핸들러
    /// </summary>
    [SerializeField] InputHandler m_inputHandler;

    /// <summary>
    /// 이동속도
    /// </summary>
    [SerializeField] float m_moveSpeed;

    void Update()
    {
        Vector2 _moveDir = Vector2.zero;
        _moveDir.x = m_inputHandler.Movement.x;
        _moveDir.y = m_inputHandler.Movement.y;

        transform.Translate(_moveDir * m_moveSpeed * Time.deltaTime);
    }
}
