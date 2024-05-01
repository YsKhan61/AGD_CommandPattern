using Command.Player;
using Command.Input;
using Command.Main;
using UnityEngine;

namespace Command.Actions
{
    public class AttackStanceAction : IAction
    {
        private UnitController m_ActorUnit;
        private UnitController m_TargetUnit;
        private bool m_IsSuccessful;
        TargetType IAction.TargetType { get => TargetType.Self; }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            m_ActorUnit = actorUnit;
            m_TargetUnit = targetUnit;
            m_IsSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.AttackStance, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.ATTACK_STANCE);

            if (m_IsSuccessful)
                m_TargetUnit.CurrentPower += (int)(m_TargetUnit.CurrentPower * 0.2f);
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}