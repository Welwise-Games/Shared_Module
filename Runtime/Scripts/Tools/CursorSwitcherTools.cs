using UnityEngine;

namespace Tools
{
    public static class CursorSwitcherTools
    {
        public static bool IsCursorEnabled = true;

        public static void SwitchCursor()
        {
            IsCursorEnabled = !IsCursorEnabled;
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
        }

        public static void DisableCursor()
        {
            IsCursorEnabled = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public static void EnableCursor()
        {
            IsCursorEnabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}