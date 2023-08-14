using Spine.Unity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TechDesignTestProject
{
    public class SpineBoyComponent : MonoBehaviour, IPointerClickHandler
    {
        private SkeletonAnimation skeletonAnimation;

        #region Inspector
        public AnimationReferenceAsset walk;
        public AnimationReferenceAsset gungrab;
        public AnimationReferenceAsset gunkeep;
        #endregion

        private void Start()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            skeletonAnimation.AnimationState.SetAnimation(0, "run", true);


        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (skeletonAnimation.AnimationName == "run") skeletonAnimation.ClearState(); 
            else skeletonAnimation.AnimationState.SetAnimation(0, "run", true);
        }
    }
}
