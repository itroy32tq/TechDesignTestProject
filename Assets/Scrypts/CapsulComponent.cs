using UnityEngine;
using UnityEngine.EventSystems;

namespace TechDesignTestProject 
{
    public class CapsulComponent : MonoBehaviour, IPointerClickHandler
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            _animator.SetTrigger("start_trigger");
        }
    }
}

