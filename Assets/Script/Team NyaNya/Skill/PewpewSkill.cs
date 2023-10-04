using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu]
    public class PewpewSkill : Skill
    {
        [SerializeField] GameObject _bullet;
        PlayerController player;


        public override void Activate(GameObject parent)
        {
            player = parent.GetComponentInChildren<PlayerController>();
            GameObject bllt = Instantiate(_bullet, parent.transform);
            bllt.GetComponent<PlayerBullet>().BulletDir = player.Cursor.position - parent.transform.position;
        }
    }
}
