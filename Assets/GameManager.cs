using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Paused = 0,
        Playing = 1,
        ChoosingBody = 2,
        CheckingAnswer = 3,
    }

    public static GameManager Instance {  get; private set; }
    
    public GameState state;
    
    public Body[] bodies;
    public int currentBodyIndex = -1;
    public Body CurrentBody => bodies[currentBodyIndex];

    public UnityEvent<Body> onBodyChosen;
    
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
            case GameState.CheckingAnswer:
                break;
            case GameState.Playing:
                break;
            case GameState.Paused:
            default:
                return;
        }
        

    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
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
        onBodyChosen.Invoke(bodies[currentBodyIndex]);
        state = GameState.Playing;
    }
}
