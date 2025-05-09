using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainHub.Modules.SharedModule.Scripts
{
    public class EventDataObserver : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
    {
        public event Action<PointerEventData> PointerDowned, PointerUped, BeganDrag, Draged;
        public event Action PointerDownedWithoutArgs, PointerUpedWithoutArgs, BeganDragWithoutArgs, DragedWithoutArgs;
        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDowned?.Invoke(eventData);
            PointerDownedWithoutArgs?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUped?.Invoke(eventData);
            PointerUpedWithoutArgs?.Invoke();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            BeganDrag?.Invoke(eventData);
            BeganDragWithoutArgs?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Draged?.Invoke(eventData);
            DragedWithoutArgs?.Invoke();
        }
    }
}