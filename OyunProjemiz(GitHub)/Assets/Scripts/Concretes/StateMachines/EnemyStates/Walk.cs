using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Abstracts.StatesMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.StateMachines.EnemyStates
{

    public class Walk : IState
    {
        IMover _mover;
        IMyAnimations _animation;
        IFlip _flip;
        IEntityController _entityController;


        int _patrolIndex = 0;
        float _direction ;
        Transform[] _patrols;
        Transform _currentPatrol;

        public bool IsWalking { get; private set; }

        public Walk(IEntityController entityController,IMover mover, IMyAnimations animation,IFlip flip,  params Transform[] patrols)
        {
            _mover = mover;
            _animation = animation;
            _flip = flip;
            _patrols = patrols;
            _entityController = entityController;
        }

        public void OnEnter()
        {
            if (_patrols.Length < 1) return; // Eğer patrol gelmezse OnEnter çalışmasın.(bu sayede istersen düşmana sadece takip özelliği yüklersin)

            _currentPatrol = _patrols[_patrolIndex]; //Hangi Patrolda olduğunu belirtiyor.

            Vector3 leftOfRight = _currentPatrol.position - _entityController.transform.position; //Patrolsun yerini hesaplıyor.

            if (leftOfRight.x>0f)               //Rota sağda mı kalıyor solda mı.
            {
                //Sağ
                _flip.FlipCharacter(1f);
            }
            else
            {
                //Sol
                _flip.FlipCharacter(-1f);
            }

            _direction = _entityController.transform.localScale.x;

            _animation.MoveAnimations(1f);//Yürüme Animasyonunu çalıştırıyor.

            IsWalking = true; //State Machine'de burada kalmasını sağlıyor.
        }

        public void OnExit()
        {
            
            _animation.MoveAnimations(0f);//Çıkarken Animator'a 0(Idle) değeri gönderiyor

            _patrolIndex++;

            if (_patrolIndex>=_patrols.Length) //Dizi boyutu aşmaması için index sıfırlayıcı.
            {
                _patrolIndex = 0;
            }

            

        }

        public void Tick()
        {
            if (_currentPatrol == null) return; //Patrols gelmezse buraya girme. 

            if (Vector2.Distance(_entityController.transform.position,_currentPatrol.position)<=0.2f) //Enemy pozisyonun patrola olan uzaklığı <= 2f ise.
            {
                IsWalking = false;  //State Machine'den çıkmasını sağlıyor.
                return;
            }

            _mover.Tick(_direction); //Mover'a yürüyeceği yönü gönderiyor.
        }
    }

}

