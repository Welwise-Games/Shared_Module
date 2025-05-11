using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Observers
{
    public class EventDataObserver : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IPointerEnterHandler
    {
        public event Action<PointerEventData> PointerDowned, PointerUped, BeganDrag, Draged, PointerEntered;
        public event Action PointerDownedWithoutArgs, PointerUpedWithoutArgs, BeganDragWithoutArgs, DragedWithoutArgs, PointerEnteredWithoutArgs;
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
    }
}