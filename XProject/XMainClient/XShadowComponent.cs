// Decompiled with JetBrains decompiler
// Type: XMainClient.XShadowComponent
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XShadowComponent : XComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(Shadow));
        private XGameObject _shadow = (XGameObject)null;
        private bool _showRealTimeShadow = false;
        private static CommandCallback _initCb = new CommandCallback(XShadowComponent._Init);

        public override uint ID => XShadowComponent.uuID;

        private XGameObject Shadow => this._shadow;

        private static void _Init(XGameObject gameObject, object o, int commandID)
        {
            XShadowComponent xshadowComponent = o as XShadowComponent;
            GameObject mainGo = gameObject.Get();
            Renderer componentInChildren = mainGo.GetComponentInChildren<Renderer>();
            componentInChildren.enabled = !xshadowComponent.Entity.IsDisappear && xshadowComponent.Entity.IsVisible;
            componentInChildren.gameObject.layer = xshadowComponent._entity.DefaultLayer;
            XRenderComponent.AddShadowObj(xshadowComponent._entity, mainGo, componentInChildren);
        }

        private void LoadShadow()
        {
            if (this._shadow != null)
                return;
            this._shadow = XGameObject.CreateXGameObject("Prefabs/Shadow");
            this._shadow.SetParent(this._entity.MoveObj);
            this._shadow.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, Vector3.one, false);
            this._shadow.CallCommand(XShadowComponent._initCb, (object)this);
        }

        private void ProcessRealtimeShadow()
        {
            this._showRealTimeShadow = false;
            if (this._entity == null)
                return;
            this._showRealTimeShadow = this._entity.ProcessRealTimeShadow();
        }

        private void ProcessFakeShadow()
        {
            bool flag = !XEntity.ValideEntity(this._entity.Transformee) ? this._entity.CastFakeShadow() : this._entity.Transformee.CastFakeShadow();
            bool enable = !this._showRealTimeShadow & flag;
            if (!this._showRealTimeShadow & flag)
                this.LoadShadow();
            if (this._shadow == null)
                return;
            this._shadow.SetActive(enable);
        }

        public void ProcessShadow()
        {
            this.ProcessRealtimeShadow();
            this.ProcessFakeShadow();
        }

        protected override void EventSubscribe()
        {
            this.RegisterEvent(XEventDefine.XEvent_OnMounted, new XComponent.XEventHandler(this.OnMountEvent));
            this.RegisterEvent(XEventDefine.XEvent_OnUnMounted, new XComponent.XEventHandler(this.OnMountEvent));
        }

        public override void Attached()
        {
            base.Attached();
            this.ProcessShadow();
            if (this._showRealTimeShadow || this._shadow == null)
                return;
            this._shadow.LocalScale = Vector3.one * this._entity.Radius * 2.5f;
        }

        public override void OnDetachFromHost()
        {
            if (this._shadow != null)
            {
                XRenderComponent.RemoveObj(this._entity, this._shadow.Get());
                XGameObject.DestroyXGameObject(this._shadow);
                this._shadow = (XGameObject)null;
            }
            base.OnDetachFromHost();
        }

        protected bool OnMountEvent(XEventArgs e)
        {
            if (this._showRealTimeShadow || this._shadow == null)
                return true;
            this._shadow.SetParent(this._entity.MoveObj);
            this._shadow.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, Vector3.one, e is XOnUnMountedEventArgs);
            return true;
        }

        public override void PostUpdate(float fDeltaT)
        {
            if (this._showRealTimeShadow || this._shadow == null)
                return;
            Vector3 zero = Vector3.zero;
            Vector3 position = this._entity.MoveObj.Position;
            zero.y = (float)((this._entity.StandOn ? 0.0 : (double)XSingleton<XScene>.singleton.TerrainY(position) - (double)position.y) / (double)this._entity.Scale + 0.025000000372529);
            this._shadow.SetLocalPRS(zero, true, XSingleton<XCommon>.singleton.RotateToGround(position, Vector3.forward), true, Vector3.one, false);
        }

        public void SetActive(bool active)
        {
            if (this._shadow == null)
                return;
            this._shadow.SetActive(active);
        }
    }
}
