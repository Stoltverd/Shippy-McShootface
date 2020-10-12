using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Request
{
    public float timer;
    public Action action;
    public bool unscaled;

    public Request(float timer, Action action, bool unscaled)
    {
        this.timer = timer;
        this.action = action;
        this.unscaled = unscaled;
    }

    public void SetTimer(float value)
    {
        timer = value;
    }
}

public class Timer : MonoBehaviour
{
    [SerializeField]
    private List<Request> requests = new List<Request>();

    #region Singleton

    private static Timer instance = null;
    public static Timer Instance
    {
        get
        {
            if (instance == null)
            {
                Timer sceneResult = FindObjectOfType<Timer>();
                if (sceneResult != null)
                {
                    instance = sceneResult;
                }
                else
                {
                    instance = new GameObject($"{instance.GetType().ToString()}_Instance", typeof(Timer)).GetComponent<Timer>();
                }
            }

            return instance;
        }
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    #endregion

    private void Update()
    {
        TimerManagement();
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    private void TimerManagement()
    {
        for (int i = 0; i < requests.Count; i++)
        {
            float timer = requests[i].timer;

            if (requests[i].unscaled)
            {
                ReduceCooldownUnscaled(ref timer, requests[i].action);
            }
            else
            {
                ReduceCooldown(ref timer, requests[i].action);
            }

            requests[i].SetTimer(timer);
        }

        for (int i = requests.Count - 1; i >= 0; i--)
        {
            if (requests[i].timer <= 0)
            {
                requests.RemoveAt(i);
            }
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    #region Static Methods

    /// <summary> Call a Method or a piece of code after a period of time. </summary>

    public static void CallOnDelay(Action action, float delay)
    {
        if (Instance.requests == null)
        {
            Instance.requests = new List<Request>();
        }

        Instance.requests.Add(new Request(delay, action, false));
    }

    public static void CallOnDelayUnscaled(Action action, float delay)
    {
        if (Instance.requests == null)
        {
            Instance.requests = new List<Request>();
        }

        Instance.requests.Add(new Request(delay, action, true));
    }

    /// <summary> Reduce a variable over time and call a Method or piece of code if reaches 0. </summary>

    public static void ReduceCooldown(ref float value, Action endingAction = null)
    {
        if (value > 0)
        {
            value -= Time.deltaTime;
            if (value <= 0)
            {
                value = 0;
                endingAction?.Invoke();
            }
        }
        else if (value < 0)
        {
            value = 0;
        }
    }

    public static void ReduceCooldownUnscaled(ref float value, Action endingAction = null)
    {
        if (value > 0)
        {
            value -= Time.unscaledDeltaTime;
            if (value <= 0)
            {
                value = 0;
                endingAction?.Invoke();
            }
        }
        else if (value < 0)
        {
            value = 0;
        }
    }

    #endregion

}
