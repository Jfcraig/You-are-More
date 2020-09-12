using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


    /// <summary>
    /// Just by implementing IPointerClickHandler like any UI, you can click on objects
    /// </summary>
    public class Interactable : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent OnClick;
        public Vector3 hitPoint;
        public Vector3 hitPointNorm;

        public void OnPointerClick(PointerEventData eventData)
        {
            hitPoint = eventData.pointerPressRaycast.worldPosition;
            hitPointNorm = eventData.pointerPressRaycast.worldNormal;
            OnClick.Invoke();
        }
    }
