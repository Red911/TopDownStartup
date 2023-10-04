using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SkillHolder : MonoBehaviour
    {
        enum SkillState
        {
            Ready,
            Active,
            Cooldown
        }

        private SkillState _skillState = SkillState.Ready;
        public KeyCode key;
        
        public Skill skill;
        private float _cooldDown;
        private float _activeTime;

        
        void Update()
        {
            switch (_skillState)
            {
                case SkillState.Ready :
                    if (Input.GetKey(key))
                    {
                        //Active Skill
                        skill.Activate(gameObject);
                        _skillState = SkillState.Active;
                        _activeTime = skill.activeTime;
                    }
                    break;
                case SkillState.Active :
                    if (_activeTime > 0)
                    {
                        _activeTime -= +Time.deltaTime;
                    }
                    else
                    {
                        skill.BeginCooldown(gameObject);
                        _skillState = SkillState.Cooldown;
                        _cooldDown = skill.cooldownTime;
                    }
                    break;
                case SkillState.Cooldown :
                    if (_cooldDown > 0)
                        _cooldDown -= +Time.deltaTime;
                    else
                        _skillState = SkillState.Ready;  
                    break;
            }
            if (Input.GetKey(key))
            {
                //Active Skill
            }
        }
    }
}
