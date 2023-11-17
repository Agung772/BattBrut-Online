using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable", menuName = "Scriptable Object/Projectile")]
public class DataProjectile : ScriptableObject
{
    public Sprite icon;
    public float cooldownTime;
    public GameObject projectilePrefab;

}
