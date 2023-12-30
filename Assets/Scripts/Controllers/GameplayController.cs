using System.Collections;
using Interfaces;
using UnityEngine;

public class GameplayController : MonoBehaviour, IGameController
{
    private int _score;
    [SerializeField] private int _secondsToPlay;
    private int _secondsPlayed;
    
    public void OnStartPlaying()
    {
        StartCoroutine(SpawningCirclesCoroutine());
        
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void OnGameOver()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator SpawningCirclesCoroutine()
    {
        yield break;
    }
}
