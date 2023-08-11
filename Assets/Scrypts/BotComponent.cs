using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;


namespace TechDesignTestProject
{
    public class BotComponent : MonoBehaviour
    {
        private Animator _animator;
        protected Rigidbody _rigidBody;
        private AudioSource _audioSource;

        public bool InAnimation { get; private set; }
        public float Mass => _rigidBody.mass;

        protected void Start()
        {
            OnValidate();
        }

        protected void OnMove(Vector3 direction)
        {
            _animator.SetFloat("Forward_Move", direction.z);
            _animator.SetFloat("Right_Move", direction.x);
        }
        public Vector3 GetVelocity(IgnoreAxisType ignore = IgnoreAxisType.Y)
        {
            return IgnoreAxisUpdate(ignore, _rigidBody.velocity);
        }

        private Vector3 IgnoreAxisUpdate(IgnoreAxisType ignore, Vector3 velocity)
        {
            if (ignore == IgnoreAxisType.None) return velocity;
            if ((ignore & IgnoreAxisType.X) == IgnoreAxisType.X) velocity.x = 0f;
            if ((ignore & IgnoreAxisType.Y) == IgnoreAxisType.Y) velocity.y = 0f;
            if ((ignore & IgnoreAxisType.Z) == IgnoreAxisType.Z) velocity.z = 0f;

            return velocity;
        }

        public void SetVelocity(Vector3 velocity, IgnoreAxisType ignore = IgnoreAxisType.None)
        {
            OnMove(velocity);

            //todo пока что персонаж резко поворачиваетс€ в сторону движени€
            //transform.LookAt(Target.GetPoint);

            _rigidBody.velocity = IgnoreAxisUpdate(ignore, velocity);
        }

        protected void OnValidate()
        {
            _rigidBody = FindComponent<Rigidbody>();
            _animator = FindComponent<Animator>();
            _audioSource = FindComponent<AudioSource>();

            _audioSource.playOnAwake = false;
            _audioSource.loop = false;

        }

        private T FindComponent<T>() where T : Component
        {
            var component = GetComponentInChildren<T>(true) ?? GetComponentInParent<T>();

            if (component == null)
            {
                Debug.Log($"” {name} не обнаружен компонент {typeof(T)}");
            }

            return component;
        }

        public enum IgnoreAxisType : byte
        {
            None = 0,
            X = 1,
            Y = 2,
            Z = 4
        }

    }
}

