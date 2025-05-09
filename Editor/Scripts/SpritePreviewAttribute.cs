using UnityEngine;

namespace MainHub.Modules.SharedModule.Scripts.Tools
{
    public class SpritePreviewAttribute : PropertyAttribute
    {
        public float height;

        public SpritePreviewAttribute(float height = 100f)
        {
            this.height = height;
        }
    }
}