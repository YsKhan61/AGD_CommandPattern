using Command.Actions;
using Command.Main;

namespace Command.Commands
{
    public class AttackCommand : UnitCommand
    {
        private bool m_HasHitTarget;

        public AttackCommand(CommandData commandData)
        {
            m_CommandData = commandData;
            m_HasHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            IAction action = GameService.Instance.ActionService.GetActionByType(CommandType.Attack);
            action.PerformAction(m_ActorUnit, m_TargetUnit, m_HasHitTarget);
        }

        public override bool WillHitTarget() => true;
    }
}