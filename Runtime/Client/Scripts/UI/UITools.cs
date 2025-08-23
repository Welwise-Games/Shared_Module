using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WelwiseSharedModule.Runtime.Client.Scripts.UI
{
    public static class UITools
    {
        public static List<RaycastResult> GetPointerEventRaycastResults()
        {
            var eventDataCurrentPosition = new PointerEventData(EventSystem.current)
            {
                position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
            };
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results;
        }
        
        public static bool IsInteractWithUI() => Input.GetKey(KeyCode.Mouse0) && (EventSystem.current.currentSelectedGameObject || IsPointerOverUIObject());
        
        private static bool IsPointerOverUIObject()
        {
            var eventDataCurrentPosition = new PointerEventData(EventSystem.current)
            {
                position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
            };
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }
}