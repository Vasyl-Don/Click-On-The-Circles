namespace Interfaces
{
    public interface IGameController
    {
        public void OnStartPlaying();
        public void OnUpdate();
        public void OnGameOver();
    }
}