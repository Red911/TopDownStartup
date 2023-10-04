using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "DashSkill")]
    public class DashSkill : Skill
    {
        public float dashVelocity;

        public override void Activate(GameObject parent)
        {
            Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

            rb.AddForce(parent.transform.position * dashVelocity, ForceMode2D.Impulse);
        }

        public override void BeginCooldown(GameObject parent)
        {
            Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

            rb.velocity = Vector2.zero;
        }
    }
}
