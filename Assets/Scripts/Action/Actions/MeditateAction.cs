using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class MeditateAction : IAction
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

            actorUnit.PlayBattleAnimation(CommandType.Meditate, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.MEDITATE);

            if (m_IsSuccessful)
            {
                var healthToIncrease = (int)(m_TargetUnit.CurrentMaxHealth * 0.2f);
                m_TargetUnit.CurrentMaxHealth += healthToIncrease;
                m_TargetUnit.RestoreHealth(healthToIncrease);
            }
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}