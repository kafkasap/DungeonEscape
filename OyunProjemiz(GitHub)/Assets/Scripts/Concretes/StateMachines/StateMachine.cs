using OyunProjemiz.Abstracts.StatesMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OyunProjemiz.StateMachines
{
    public class StateMachine 
    {
        List<StateTransision> _stateTransisions = new List<StateTransision>();
        List<StateTransision> _anyStateTransisions = new List<StateTransision>();

        IState _currentState;

        public void SetState(IState state)
        {
            if (state == _currentState) return;

            _currentState?.OnExit();


            _currentState = state;

            _currentState.OnEnter();

        }

        public void Tick()
        {
            StateTransision stateTransision = CheckForTransition();

            if (stateTransision!=null)
            {
                SetState(stateTransision.To);
            }

            _currentState.Tick();
        }

        private StateTransision CheckForTransition()
        {
            foreach (StateTransision anyStateTransision in _anyStateTransisions)
            {
                if (anyStateTransision.Condition.Invoke()) return anyStateTransision;
                {

                }
            }

            foreach (StateTransision stateTransision in _stateTransisions)
            {
                if (stateTransision.Condition() && stateTransision.From==_currentState)
                {
                    return stateTransision;
                }

            }
            return null;
        }

        public void AddTransision(IState from, IState to, System.Func<bool> contidion)
        {
            StateTransision stateTransision = new StateTransision(from, to, contidion);
            _stateTransisions.Add(stateTransision);
        }

        public void AddAnyState(IState to, System.Func<bool> condition)
        {
            StateTransision anyStateTransision = new StateTransision(null, to, condition);
            _anyStateTransisions.Add(anyStateTransision);
             

        }





    }

}
