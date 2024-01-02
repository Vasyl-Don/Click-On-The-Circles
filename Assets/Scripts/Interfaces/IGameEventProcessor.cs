namespace Interfaces
{
    public interface IGameEventProcessor
    {
        public void OnAwake();
        public void OnStartPlaying();
        public void OnGameOver();
    }
}