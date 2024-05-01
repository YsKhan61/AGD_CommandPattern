using Command.Actions;
using Command.Main;
using UnityEngine;

namespace Command.Commands
{
    public class BersekAttackCommand : UnitCommand
    {
        private const float HIT_CHANCE = 0.66f;
        private bool m_HasHitTarget;

        public BersekAttackCommand(CommandData commandData)
        {
            m_CommandData = commandData;
            m_HasHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            IAction action = GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack);
            action.PerformAction(m_ActorUnit, m_TargetUnit, m_HasHitTarget);
        }

        public override bool WillHitTarget() => Random.value <= HIT_CHANCE;
    }
}