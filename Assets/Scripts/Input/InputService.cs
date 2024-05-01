using Command.Main;
using Command.Player;
using Command.Actions;
using Command.Commands;

namespace Command.Input
{
    public class InputService
    {
        private MouseInputHandler m_MouseInputHandler;

        private InputState m_CurrentState;
        private CommandType m_SelectedCommandType;
        private TargetType m_TargetType;

        public InputService()
        {
            m_MouseInputHandler = new MouseInputHandler(this);
            SetInputState(InputState.INACTIVE);
            SubscribeToEvents();
        }

        public void SetInputState(InputState inputStateToSet) => m_CurrentState = inputStateToSet;

        private void SubscribeToEvents() => GameService.Instance.EventService.OnActionSelected.AddListener(OnActionSelected);

        public void UpdateInputService()
        {
            if(m_CurrentState == InputState.SELECTING_TARGET)
                m_MouseInputHandler.HandleTargetSelection(m_TargetType);
        }

        public void OnActionSelected(CommandType selectedActionType)
        {
            this.m_SelectedCommandType = selectedActionType;
            SetInputState(InputState.SELECTING_TARGET);
            TargetType targetType = SetTargetType(selectedActionType);
            ShowTargetSelectionUI(targetType);
        }

        private void ShowTargetSelectionUI(TargetType selectedTargetType)
        {
            int playerID = GameService.Instance.PlayerService.ActivePlayerID;
            GameService.Instance.UIService.ShowTargetOverlay(playerID, selectedTargetType);
        }

        private TargetType SetTargetType(CommandType selectedActionType) => m_TargetType = GameService.Instance.ActionService.GetTargetTypeForAction(selectedActionType);

        public void OnTargetSelected(UnitController targetUnit)
        {
            SetInputState(InputState.EXECUTING_INPUT);
            UnitCommand commandToProcess = CreateUnitCommand(targetUnit);

            // GameService.Instance.ProcessUnitCommand(commandToProcess);
        }

        private UnitCommand CreateUnitCommand(UnitController targetUnit)
        {
            CommandData commandData = CreateCommandData(targetUnit);

            switch (m_SelectedCommandType)
            {
                case CommandType.Attack:
                    return new AttackCommand(commandData);
                case CommandType.Heal:
                    return new HealCommand(commandData);
                case CommandType.AttackStance:
                    return new AttackStanceCommand(commandData);
                case CommandType.Cleanse:
                    return new CleanseCommand(commandData);
                case CommandType.BerserkAttack:
                    return new BerserkAttackCommand(commandData);
                case CommandType.Meditate:
                    return new MeditateCommand(commandData);
                case CommandType.ThirdEye:
                    return new ThirdEyeCommand(commandData);
                default:
                    // If the selectedCommandType is not recognized, throw an exception.
                    throw new System.Exception($"No Command found of type: {m_SelectedCommandType}");
            }
        }

        private CommandData CreateCommandData(UnitController targetUnit) => new CommandData(
                GameService.Instance.PlayerService.ActiveUnitID, 
                targetUnit.UnitID,
                GameService.Instance.PlayerService.ActivePlayerID,
                targetUnit.Owner.PlayerID);
    }
}