namespace Interfaces
{
    public interface IGameController
    {
        public void OnStart();
        public void OnStartPlaying();
        public void OnUpdate();
        public void OnGameOver();
    }
}