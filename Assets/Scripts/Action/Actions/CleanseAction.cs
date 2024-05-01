using Command.Input;
using Command.Player;
using Command.Main;
using UnityEngine;

namespace Command.Actions
{
    public class CleanseAction : IAction
    {     
        private UnitController m_ActorUnit;
        private UnitController m_TargetUnit;
        private bool m_IsSuccessful;
        public TargetType TargetType  => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit, bool isSuccessful)
        {
            this.m_ActorUnit = actorUnit;
            this.m_TargetUnit = targetUnit;
            this.m_IsSuccessful = isSuccessful;

            actorUnit.PlayBattleAnimation(CommandType.Cleanse, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.CLEANSE);

            if (m_IsSuccessful)
                m_TargetUnit.ResetStats();
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}
