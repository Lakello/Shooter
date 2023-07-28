using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class State : IState
{
    [SerializeField] private List<Transition> _transitions;

    public State(List<Transition> transitions)
    {
        _transitions = transitions;
    }

    public void Enter()
    {
        //if (enabled == false)
        //{
        //    Target = target;

        //    enabled = true;

        //    foreach (var transition in _transitions)
        //    {
        //        transition.enabled = true;
        //        transition.Init(Target);
        //    }
        //}
    }

    public void Exit()
    {
        //if (enabled == true)
        //{
        //    foreach (var transition in _transitions)
        //        transition.enabled = false;

        //    enabled = false;
        //}
    }

    public State GetNextState()
    {
        //foreach (var transition in _transitions)
        //{
        //    if (transition.NeedTransit)
        //        return transition.TargetState;
        //}

        return null;
    }
}
