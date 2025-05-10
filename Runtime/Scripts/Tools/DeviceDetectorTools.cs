using System.Runtime.InteropServices;

namespace Tools
{
    public static class DeviceDetectorTools
    {
        [DllImport("__Internal")]
        private static extern int IsMobileDevice();

        public static bool IsMobile()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        return IsMobileDevice() == 1;
#else
            return false;
#endif
        }
    }
}