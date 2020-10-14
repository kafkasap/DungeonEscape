using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Abstracts.StatesMachines
{
    public interface IState 
    {
        void Tick();
        void OnEnter();
        void OnExit();



    }

}
