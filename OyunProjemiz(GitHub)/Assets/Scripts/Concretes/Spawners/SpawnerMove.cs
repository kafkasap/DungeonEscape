using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.Inputs;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Inputs;
using OyunProjemiz.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMove : MonoBehaviour,IEntityController
{
    IPlayerInput _input;
    IMover _mover;

    [SerializeField] float movespeed;

    float _horizontal;

    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _input = new PcInput();
        _mover = new Mover(this, movespeed);
        _rigidbody = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        _horizontal = _input.Horizontal;
    }
    private void FixedUpdate()
    {
        _mover.Tick(_horizontal);
    }

}
