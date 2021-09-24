

using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
    public class XFxMgr : XSingleton<XFxMgr>
    {
        private Dictionary<int, XFx> _fxs = new Dictionary<int, XFx>();
        private XTimerMgr.ElapsedEventHandler _innerDestroyFxCb = (XTimerMgr.ElapsedEventHandler)null;
        public int CameraLayerMask = -1;
        public static bool EmptyFx = false;
        public static bool FilterFarFx = false;
        public static float FilterFxDis0 = 200f;
        public static float FilterFxDis1 = 300f;
        public static float FilterFxDis2 = 500f;
        public static float FilterFxDis4 = 1600f;
        public static int maxBehitFx = 3;
        public static int currentBeHitFx = 0;
        public static float minBehitFxTime = 0.1f;
        public static float lastBehitFxTime = 0.0f;
        public static int MaxParticelCount = -1;

        public XFxMgr() => this._innerDestroyFxCb = new XTimerMgr.ElapsedEventHandler(this.InnerDestroyFx);

        public XFx CreateFx(string prefab_location, LoadCallBack loadFinish = null, bool async = true)
        {
            XFx xfx = XFx.CreateXFx(prefab_location, loadFinish, async);
            this._fxs.Add(xfx._instanceID, xfx);
            return xfx;
        }

        public XFx CreateAndPlay(
          string location,
          XGameObject parent,
          Vector3 offset,
          Vector3 scale,
          float speed_ratio = 1f,
          bool follow = false,
          float duration = -1f,
          bool async = true)
        {
            XFx fx = this.CreateFx(location, async: async);
            fx.Play(parent, offset, scale, speed_ratio, follow);
            fx.DelayDestroy = duration;
            XSingleton<XFxMgr>.singleton.DestroyFx(fx, false);
            return fx;
        }

        public XFx CreateAndPlay(
          string location,
          Transform parent,
          Vector3 offset,
          Vector3 scale,
          float speed_ratio = 1f,
          bool follow = false,
          float duration = -1f,
          bool async = true)
        {
            XFx fx = this.CreateFx(location, async: async);
            fx.Play(parent, offset, scale, speed_ratio, follow);
            fx.DelayDestroy = duration;
            XSingleton<XFxMgr>.singleton.DestroyFx(fx, false);
            return fx;
        }

        public XFx CreateUIFx(string location, Transform parent, bool processMesh = false) => this.CreateUIFx(location, parent, Vector3.one, processMesh);

        public XFx CreateUIFx(string location, Transform parent, Vector3 scale, bool processMesh = false)
        {
            XFx fx = this.CreateFx(location, processMesh ? XFx._ProcessMesh : (LoadCallBack)null);
            int layer = LayerMask.NameToLayer("UI");
            fx.SetRenderLayer(layer);
            fx.Play(parent, Vector3.zero, scale, follow: true);
            fx.RefreshUIRenderQueue();
            return fx;
        }

        public void DestroyFx(XFx fx, bool bImmediately = true)
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(fx.Token);
            if (bImmediately || (double)fx.DelayDestroy <= 0.0)
                this.InnerDestroyFx((object)fx);
            else
                fx.Token = XSingleton<XTimerMgr>.singleton.SetTimer(fx.DelayDestroy, this._innerDestroyFxCb, (object)fx);
        }

        public void OnLeaveScene() => this.Clear();

        public void OnLeaveStage() => this.Clear();

        public void PostUpdate()
        {
            Dictionary<int, XFx>.Enumerator enumerator = this._fxs.GetEnumerator();
            while (enumerator.MoveNext())
                enumerator.Current.Value?.StickToGround();
        }

        private void InnerDestroyFx(object o)
        {
            if (!(o is XFx fx))
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Destroy Fx error: ", o.ToString());
            }
            else
            {
                this._fxs.Remove(fx._instanceID);
                XFx.DestroyXFx(fx);
            }
        }

        public void Clear()
        {
            Dictionary<int, XFx>.Enumerator enumerator = this._fxs.GetEnumerator();
            while (enumerator.MoveNext())
                XFx.DestroyXFx(enumerator.Current.Value, false);
            this._fxs.Clear();
        }
    }
}
