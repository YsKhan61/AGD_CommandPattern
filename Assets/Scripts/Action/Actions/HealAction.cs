using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class HealAction : IAction
    {
        private UnitController m_ActorUnit;
        private UnitController m_TargetUnit;
        private bool m_IsSuccessful;
        public TargetType TargetType => TargetType.Friendly;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            m_ActorUnit = actorUnit;
            m_TargetUnit = targetUnit;
            m_IsSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.Heal, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.HEAL);

            if (m_IsSuccessful)
                m_TargetUnit.RestoreHealth(m_ActorUnit.CurrentPower);
        }


        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}