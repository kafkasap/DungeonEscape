using OyunProjemiz.Abstracts.StatesMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OyunProjemiz.StateMachines
{
    public class StateTransision 
    {
        IState _from;
        IState _to;
        System.Func<bool> _condition;

        public IState From => _from;
        public IState To => _to;
        public System.Func<bool> Condition => _condition;

        public StateTransision(IState from, IState to, System.Func<bool> condition)
        {
            _from = from;
            _to = to;
            _condition = condition;
        }

    }

}
