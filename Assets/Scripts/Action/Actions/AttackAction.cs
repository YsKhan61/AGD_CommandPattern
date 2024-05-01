using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class AttackAction : IAction
    {
        private UnitController m_ActorUnit;
        private UnitController m_TargetUnit;
        private bool m_IsSuccessful;
        public TargetType TargetType => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            m_ActorUnit = actorUnit;
            m_TargetUnit = targetUnit;
            m_IsSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.Attack, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted() 
        {
            PlayAttackSound();

            if (m_IsSuccessful)
                m_TargetUnit.TakeDamage(m_ActorUnit.CurrentPower);
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();

        private void PlayAttackSound()
        {
            switch(m_ActorUnit.UnitType)
            {
                case UnitType.WIZARD:
                    GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.MAGIC_BALL);
                    break;
                case UnitType.SWORD_MASTER:
                    GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.KNIFE_SLASH);
                    break;
                case UnitType.MAGE:
                    GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.FIRE_ATTACK);
                    break;
                case UnitType.BERSERKER:
                    GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.SWORD_SLASH);
                    break;
                default:
                    break;
            }
        }
    }
}