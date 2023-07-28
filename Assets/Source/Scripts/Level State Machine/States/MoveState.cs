using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    public MoveState(List<Transition> transitions) : base(transitions)
    {
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position,
        //                                        Target.transform.position,
        //                                        _speed * Time.deltaTime); 
    }
}
