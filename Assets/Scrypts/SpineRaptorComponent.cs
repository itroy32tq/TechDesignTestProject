using Spine.Unity;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TechDesignTestProject
{
    public class SpineRaptorComponent : MonoBehaviour, IPointerClickHandler
    {
        private SkeletonAnimation skeletonAnimation;
        private bool isStopCoriutine = true;

        #region Inspector
        public AnimationReferenceAsset walk;
        public AnimationReferenceAsset gungrab;
        public AnimationReferenceAsset gunkeep;
        #endregion

        private void Start()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            StartCoroutine(GunGrabRoutine());
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isStopCoriutine)
            {
                isStopCoriutine = false;
                StopCoroutine(GunGrabRoutine());
                skeletonAnimation.ClearState();
            }
            else
            {
                StartCoroutine(GunGrabRoutine());
                isStopCoriutine = true;
            }

        }

        IEnumerator GunGrabRoutine()
        {
            // Play the walk animation on track 0.
            skeletonAnimation.AnimationState.SetAnimation(0, walk, true);

            // Repeatedly play the gungrab and gunkeep animation on track 1.
            while (isStopCoriutine)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 3f));

                if (!isStopCoriutine) yield break;

                skeletonAnimation.AnimationState.SetAnimation(1, gungrab, false);

                yield return new WaitForSeconds(Random.Range(0.5f, 3f));

                if (!isStopCoriutine) yield break;

                skeletonAnimation.AnimationState.SetAnimation(1, gunkeep, false);
                
            }
            yield break;

        }

    }
}
