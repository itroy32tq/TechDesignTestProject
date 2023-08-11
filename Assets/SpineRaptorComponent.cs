using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TechDesignTestProject
{
    public class SpineRaptorComponent : MonoBehaviour, IPointerClickHandler
    {
        private Animator _anmator;

        SkeletonAnimation skeletonAnimation;
        #region Inspector
        public AnimationReferenceAsset walk;
        public AnimationReferenceAsset gungrab;
        public AnimationReferenceAsset gunkeep;
        #endregion

        private void Start()
        {
            _anmator = GetComponent<Animator>();
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            StartCoroutine(GunGrabRoutine());
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(_anmator);
            _anmator.SetTrigger("Jump");   
        }

        IEnumerator GunGrabRoutine()
        {
            // Play the walk animation on track 0.
            skeletonAnimation.AnimationState.SetAnimation(0, walk, true);

            // Repeatedly play the gungrab and gunkeep animation on track 1.
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 3f));
                skeletonAnimation.AnimationState.SetAnimation(1, gungrab, false);

                yield return new WaitForSeconds(Random.Range(0.5f, 3f));
                skeletonAnimation.AnimationState.SetAnimation(1, gunkeep, false);
            }

        }

    }
}
