using UnityEngine;

namespace WelwiseSharedModule.Editor.Scripts
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