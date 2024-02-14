using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// �Է� �ڵ鷯
    /// </summary>
    [SerializeField] InputHandler m_inputHandler;

    /// <summary>
    /// �̵��ӵ�
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
