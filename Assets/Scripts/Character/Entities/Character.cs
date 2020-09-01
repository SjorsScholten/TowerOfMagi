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

        public bool CanWalk { get; set; } = false;

        public Character(CharacterController controller, CharacterData data){
            this.Controller = controller;
            this._data = data;
            
            StateMachine = new StateMachine();
        }

        public void Move(Vector2 input, float initialSpeed, float time, float finalSpeed = 0) {
            if(!CanWalk) {
                MoveForce = Vector3.zero; //cant add force
                return;
            };
            
            var acceleration = (finalSpeed - initialSpeed) * time;
            MoveForce = input.ToDirection() * acceleration * _data.Mass;
            Controller.ProcessForce(MoveForce);
        }

        /*
        public void Jump(float height = 0) {
            //TODO: add downwards velocity of lifter sphere
            if (!IsGrounded) return;
            
            var jumpHeight = height < 0.01 ? _data.Stats.Dexterity : height; //TODO: jump height is modified by velocity
            
            JumpForce = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) * _data.Mass;
            jumpRequest.Value = true;
        }
        */

        public void LightAttack() { }

        /*
        public float JumpForce { get; private set; }
        public bool JumpRequest => jumpRequest.Value;
        */

        public Vector3 MoveForce { get; private set; }
        
        public bool IsGrounded { get; set; }
    }
}