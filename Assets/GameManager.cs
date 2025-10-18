using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Paused = 0,
        Playing = 1,
        ChoosingBody = 2,
    }

    public GameState state;
    
    public Body[] bodies;
    public int currentBodyIndex = -1;

    private HashSet<int> _visitedBodies;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bodies == null || bodies.Length == 0)
        {
            throw new System.Exception("GameManager has no bodies");
        }

        state = GameState.ChoosingBody;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GameState.ChoosingBody:
                ChooseBody();
                break;
            case GameState.Playing:
                break;
            default:
                return;
        }
        
        

    }

    void ChooseBody()
    {
        int newBodyIndex = -1;
        do
        {
            newBodyIndex = Random.Range(0, bodies.Length);
        } while (currentBodyIndex == newBodyIndex);
        
        currentBodyIndex = newBodyIndex;
        state = GameState.Playing;
    }
}
