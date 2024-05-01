using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class ThirdEyeAction : IAction
    {
        private UnitController m_ActorUnit;
        private UnitController m_TargetUnit;
        private bool m_IsSuccessful;
        public TargetType TargetType => TargetType.Self;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            m_ActorUnit = actorUnit;
            m_TargetUnit = targetUnit;
            m_IsSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.BerserkAttack, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            if (m_IsSuccessful)
            {
                int healthToConvert = (int)(m_TargetUnit.CurrentHealth * 0.25f);
                m_TargetUnit.TakeDamage(healthToConvert);
                m_TargetUnit.CurrentPower += healthToConvert;
            }
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}