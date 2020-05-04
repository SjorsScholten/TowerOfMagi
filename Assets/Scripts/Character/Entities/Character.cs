using System;
using Character.ScriptableObjects;
using Character.States;
using UnityEngine;
using UnityEngine.EventSystems;
using Util;
using Util.StatePattern;
using Util.Variables;
using CharacterController = Character.Controllers.CharacterController;

namespace Character.Entities {
    public class Character {
        
        private readonly PullResetValue<bool> jumpRequest = new PullResetValue<bool>(false);
        
        private readonly CharacterData _data;
        public CharacterController Controller { get;}
        public StateMachine StateMachine { get; }

        public Character(CharacterController controller, CharacterData data){
            this.Controller = controller;
            this._data = data;
            
            StateMachine = new StateMachine();
            
            //initialize states
            var idle = new Idle(this);
            var walk = new Walk(this);
            var run = new Running(this);

            void AT(IState from, IState to, Func<bool> condition) => StateMachine.AddTransition(from, to, condition);
            
            //Add Transitions
            AT(idle, walk, StartMoving());
            AT(walk, idle, StopMoving());
            
            //Conditions
            Func<bool> StartMoving() => () => MoveForce > 0f;
            Func<bool> StopMoving() => () => MoveForce < 0.01f;
            
            StateMachine.ChangeState(idle);
        }

        public void Move(Vector2 input, float initialSpeed, float time, float finalSpeed = 0) {
            if (input == Vector2.zero) {
                MoveForce = 0;
                MoveDirection = Vector3.zero;
                return;
            }
            
            var speed = 5;
            var acceleration = (speed - initialSpeed) / time;
            
            MoveForce = acceleration * _data.Mass;
            MoveDirection = input.ToDirection();
        }

        public void Jump(float height = 0) {
            //TODO: add downwards velocity of lifter sphere
            if (!IsGrounded) return;
            
            var jumpHeight = height < 0.01 ? _data.Stats.Dexterity : height; //TODO: jump height is modified by velocity
            
            JumpForce = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) * _data.Mass;
            jumpRequest.Value = true;
        }

        public void LightAttack() { }


        public float JumpForce { get; private set; }
        public bool JumpRequest => jumpRequest.Value;

        public float MoveForce { get; private set; }
        public Vector3 MoveDirection { get; private set; }
        
        public bool IsGrounded { get; set; }
    }
}