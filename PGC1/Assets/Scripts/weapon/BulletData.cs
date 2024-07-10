using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBullet", menuName = "Bullets/BulletData")]
public class BulletData : ScriptableObject
{
    public float damage;
    public float speed;
    //public Color color;
    //public GameObject hitEffect;
}
