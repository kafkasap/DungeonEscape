﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Abstracts.Inputs
{
    public interface IPlayerInput 
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool JumpButtonDown { get; }

        bool AttackButtonDown { get; }
    }
}

