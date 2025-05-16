using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Observers
{
    public class EventDataObserver : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<PointerEventData> PointerDowned, PointerUped, BeganDrag, Draged, PointerEntered, PointerExited;
        public event Action PointerDownedWithoutArgs, PointerUpedWithoutArgs, BeganDragWithoutArgs, DragedWithoutArgs, PointerEnteredWithoutArgs, PointerExitedWithoutArgs;
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

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEntered?.Invoke(eventData);
            PointerEnteredWithoutArgs?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExited?.Invoke(eventData);
            PointerExitedWithoutArgs?.Invoke();
        }
    }
}