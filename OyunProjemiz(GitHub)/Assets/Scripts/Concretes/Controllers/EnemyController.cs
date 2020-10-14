using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Abstracts.Combats;
using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Animations;
using OyunProjemiz.Movements;
using OyunProjemiz.StateMachines;
using OyunProjemiz.StateMachines.EnemyStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Controllers
{
    public class EnemyController : MonoBehaviour , IEntityController 
    {
        [Header("Movements")]
        [SerializeField] float moveSpeed = 2f;
        [SerializeField] Transform[] patrols;

        [Header("Attacks")]
        [SerializeField] float chaseDistance = 3f;
        [SerializeField] float attackDistance = 1f;
        [SerializeField] float maxAttackTime = 1f;

        [Header("Scores")]
        [SerializeField] ScoreController scorePrefab;
        [SerializeField] int currentChanse ;
        [SerializeField] int maxChanse = 70;
        [SerializeField] int minChanse = 30;

        public bool _canDestroy;

     
        StateMachine _stateMachine;
        IEntityController _player;
       

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();
        }
    
        private IEnumerator Start()
        {

            currentChanse = Random.Range(minChanse, maxChanse);

            IMover _mover = new Mover(this, moveSpeed);
            IMyAnimations _animation = new CharacterAnimation(GetComponent<Animator>());
            IFlip _flip = new FlipWithTranform(this);            
            IHealth _health = GetComponent<IHealth>();           
            IAttacker _attacker = GetComponent<IAttacker>();

            Idle idle = new Idle(_mover,_animation);
            Walk walk = new Walk(this,_mover,_animation,_flip,patrols);
            ChasePlayer chasePlayer = new ChasePlayer(_mover,_flip,_animation,IsPlayerRightSide);
            Attack attack = new Attack(_player.transform.GetComponent<IHealth>(),_flip,_animation,_attacker,maxAttackTime,IsPlayerRightSide);
            TakeHit takeHit = new TakeHit(_health,_animation);
            Dead dead = new Dead(this,_animation,()=> 
            {
                if (currentChanse>Random.Range(0,100))
                {
                    Instantiate(scorePrefab, transform.position, Quaternion.identity);

                } 

            });



            _stateMachine.AddTransision(idle, walk, () => idle.IsIdle==false); //Idle'dan Walk'a IsIdle == false ise geç.
            _stateMachine.AddTransision(idle, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance); //Idle'dan ChasePlayer'a methoddan dönen değer chaseDistance'dan küçük ise geç.
            _stateMachine.AddTransision(walk, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);//Walk'dan ChasePlayer'a methoddan dönen değer chaseDistance'dan küçük ise geç.
            _stateMachine.AddTransision(chasePlayer, attack, () => DistanceFromMeToPlayer() < attackDistance);//ChasePlayer'dan Attack'a methoddan dönen değer attackDistance'dan küçük ise geç.
            //Ters İşlemler
            _stateMachine.AddTransision(walk, idle, () => !walk.IsWalking);
            _stateMachine.AddTransision(chasePlayer, idle, () => DistanceFromMeToPlayer() > chaseDistance);
            _stateMachine.AddTransision(attack, chasePlayer, () => DistanceFromMeToPlayer() > attackDistance);

            _stateMachine.AddAnyState(dead, () => _health.IsDead);//Kalan can 1'den küçük ise dead state çalıştır.
            _stateMachine.AddAnyState(takeHit, () => takeHit.IsTakeHit); //isTakeHit true dönerse takeHit çalıştır.

            _stateMachine.AddTransision(takeHit, chasePlayer, () => takeHit.IsTakeHit == false);
            _stateMachine.SetState(idle);

            yield return null;
        }
     
        private void Update()
        {
            _stateMachine.Tick();

            if (!_canDestroy)
            {
                if (DistanceFromMeToPlayer() >= 50f)
                {
                    Destroy(this.gameObject);
                }
            }
            
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();              
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

        private float DistanceFromMeToPlayer()
        {
            return Vector2.Distance(transform.position, _player.transform.position); //enemy ile player arası uzaklığı hesaplar.
        }

        private bool IsPlayerRightSide() //Player ne tarafta kalıyor.
        {
            Vector3 result = _player.transform.position - this.transform.position;
            if (result.x>0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }



}
