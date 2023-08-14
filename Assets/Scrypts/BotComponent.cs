using UnityEngine;

namespace TechDesignTestProject
{
    public class BotComponent : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        protected Rigidbody _rigidBody;

        public bool InAnimation { get; private set; }
        public float Mass => _rigidBody.mass;

        
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

            _rigidBody.velocity = IgnoreAxisUpdate(ignore, velocity);
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

