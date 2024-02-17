using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

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

    public Animator m_animator;
    public SpriteRenderer m_spriteRenderer;
    public SpriteLibrary m_spriteLibrary;
    public SpriteLibraryAsset[] m_spriteLibraryAssets;
    public int m_index = 0;

    void Update()
    {
        if (m_inputHandler.Movement == Vector2.zero)
        {
            m_animator.SetBool("IsMove", false);
            return;
        }

        Vector2 _moveDir = Vector2.zero;
        _moveDir.x = m_inputHandler.Movement.x;
        _moveDir.y = m_inputHandler.Movement.y;

        m_spriteRenderer.flipX = m_inputHandler.Movement.x > 0 ? false : true; // x �Է¿� ���� flipX ���ֱ�

        m_animator.SetBool("IsMove", true); // Animator�� Parameter ����
        transform.Translate(_moveDir * m_moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_index = (m_index + 1) % m_spriteLibraryAssets.Length;
        m_spriteLibrary.spriteLibraryAsset = m_spriteLibraryAssets[m_index];
    }
}
