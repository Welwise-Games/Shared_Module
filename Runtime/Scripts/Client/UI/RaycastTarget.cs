using UnityEngine.UI;

namespace WelwiseSharedModule.Runtime.Scripts.Client.UI
{
    public class RaycastTarget : Graphic
    {
        public override void SetMaterialDirty() { return; }
        public override void SetVerticesDirty() { return; }
    }
}