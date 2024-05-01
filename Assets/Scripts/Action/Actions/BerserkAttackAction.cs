using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class BerserkAttackAction : IAction
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

            actorUnit.PlayBattleAnimation(CommandType.BerserkAttack, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.BERSERK_ATTACK);

            if (m_IsSuccessful)
                m_TargetUnit.TakeDamage(m_ActorUnit.CurrentPower * 2);
            else
            {
                m_ActorUnit.TakeDamage(m_ActorUnit.CurrentPower * 2);
                Debug.Log("actor unit must be hit now.");
            }
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}