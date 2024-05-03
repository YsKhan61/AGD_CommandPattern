using Command.Input;
using Command.Main;
using System;
using UnityEngine.SceneManagement;

namespace Command.UI
{
    public class BattleEndUIController : IUIController
    {
        private BattleEndUIView battleEndView;

        public BattleEndUIController(BattleEndUIView battleEndView)
        {
            this.battleEndView = battleEndView;
            battleEndView.SetController(this);
        }

        public void Show() => battleEndView.EnableView();

        public void Hide() => battleEndView.DisableView();

        public void SetWinner(int winnerId) => battleEndView.SetResultText($"Player {winnerId} Won!");

        public void OnHomeButtonClicked() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        internal void OnReplayButtonClicked()
        {
            GameService.Instance.ReplayService.SetReplayState(Replay.ReplayState.ACTIVE);
            GameService.Instance.InputService.SetInputState(InputState.INACTIVE);
            GameService.Instance.EventService.OnReplayButtonClicked.InvokeEvent();
            GameService.Instance.ReplayService.StartReplay();
        }
    }
}