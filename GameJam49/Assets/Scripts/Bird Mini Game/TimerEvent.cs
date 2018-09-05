using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for a Timer, can be used in any script.
/// </summary>
public class TimerEvent : MonoBehaviour
{
    #region events and delegates
    /// <summary>
    /// Delegate for the extra Invokable Event
    /// </summary>
    public delegate void InvokableEventAction();
    /// <summary>
    /// The extra event that will happen when the button is pressed
    /// </summary>
    public InvokableEventAction InvokableEvent;
    #endregion events and delegates

    #region public variables
    /// <summary>
    /// The current time of the timer in seconds, can be used to fill an img or display a timer on screen
    /// </summary>
    public float TimerTime;
    #endregion public variables

    #region public methods
    public void StartTimer(float MaxTime)
    {
        StartCoroutine(RunTimer(MaxTime));
    }

    /// <summary>
    /// What should happen while the timer is running
    /// </summary>
    public virtual void TimerInbetweenActions()
    {
        //nothing yet
    }

    /// <summary>
    /// Perform timer finish actions, and Invokes the InvokableEvent, the method that has been assigned to that delegate.
    /// </summary>
    public virtual void TimerFinishedActions()
    {
        InvokableEvent.Invoke();
        //Empty InvokableEvent after usage
        EmptyInvokableEvent();
    }
    #endregion public methods

    #region private methods
    /// <summary>
    /// Runs a timer for MaxTime seconds
    /// </summary>
    /// <param name="MaxTime">How long the timer will run</param>
    /// <returns></returns>
    private IEnumerator RunTimer(float MaxTime)
    {
        float duration = MaxTime;
        float normalizedTime = 0;

        while (normalizedTime <= 1f)
        {
            TimerInbetweenActions();
            TimerTime += Time.deltaTime;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        if (normalizedTime > 1f)
        {
            TimerFinishedActions();
        }
    }

    /// <summary>
    /// Unsubscribes all events from the InvokableEvent
    /// To make sure events/methods arent called more times than needed
    /// </summary>
    private void EmptyInvokableEvent()
    {
        if (InvokableEvent != null)
        {
            foreach (Delegate d in InvokableEvent.GetInvocationList())
            {
                InvokableEvent -= (InvokableEventAction)d;
            }
        }
    }
    #endregion private methods
}
