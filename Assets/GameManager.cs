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
    public GameState state;
    
    public static GameManager Instance { get; private set; }
    
    
    public Body[] bodies;
    public int currentBodyIndex = -1;
    public Body CurrentBody => bodies[currentBodyIndex];
    public int CurrentLuminosity;
    public int[] CurrentBrightnessCurve = new int[10];
    public int[] CurrentLightQuality = new int[10];
    [SerializeField] private int noiseMax = 5;

    public ObjectViewer viewer;

    private HashSet<int> _visitedBodies = new HashSet<int>();

    public CurveRenderer lightCurveRenderer;
    public CurveRenderer spectralRenderer;
    
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
        int iters = 100;
        do
        {
            newBodyIndex = Random.Range(0, bodies.Length);
            if(++iters > 100) {
                break;
            }
        } while (currentBodyIndex == newBodyIndex && _visitedBodies.Contains(newBodyIndex));
        
        _visitedBodies.Add(newBodyIndex);
        currentBodyIndex = newBodyIndex;
        
        CalculateNoisyValues();
        
        viewer.onBodyChange(CurrentBody);
        lightCurveRenderer.curve = CurrentBody.brightnessCurve;
        lightCurveRenderer.setPoints();
        spectralRenderer.curve = CurrentBody.lightQuality;
        spectralRenderer.setPoints();

        state = GameState.Playing;
    }

    void CalculateNoisyValues()
    {
        if (CurrentBody.brightnessCurve == null)
        {
            throw new System.Exception("CurrentBody has no brightness curve");
        }
        else
        {
            int sumBrightness = 0;
            for (int i = 0; i < CurrentBody.brightnessCurve.values.Length; i++)
            {
                CurrentBrightnessCurve[i] = CurrentBody.brightnessCurve.values[i] + Random.Range(-noiseMax, noiseMax);;
                sumBrightness += CurrentBrightnessCurve[i];
            }
            CurrentLuminosity = sumBrightness;
        }
        
        if (CurrentBody.lightQuality == null)
        {
            throw new System.Exception("CurrentBody has no brightness curve");
        }
        else
        {
            for (int i = 0; i < CurrentBody.lightQuality.values.Length; i++)
            {
                CurrentLightQuality[i] = CurrentBody.lightQuality.values[i] + Random.Range(-noiseMax, noiseMax);;
            }
        }
    }
}
