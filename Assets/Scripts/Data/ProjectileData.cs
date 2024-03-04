using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "ScriptableObject/New Projectile Data", order = 1)]
public class ProjectileData : ScriptableObject
{
    [Header("Projectile Spawner Info")]
    public Transform m_projectilePrefab;
    public float m_coolTime;

    [Header("Projectile Info")]
    public float m_speed;
    public float m_damage;
    public float m_disableTime;
}
