﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OyunProjemiz.Abstracts.Combats
{
    public interface IAttacker 
    {

        void Attack(ITakeHit takeHit);
        int Damage { get; }



    }



}
