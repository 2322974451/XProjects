

using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XCameraCollisonComponent : XComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Camera_Basic_Collison");
        private XCameraEx _camera_host = (XCameraEx)null;
        private float _collision_radius = 0.2f;
        private Vector3 _real_pos = Vector3.zero;
        private float _tdis = 0.0f;
        private List<SceneMat> _invisible = new List<SceneMat>();
        private List<Collider> _hit_collider = new List<Collider>();
        private List<Collider> _last_hit_collider = new List<Collider>();
        private int _layer_mask = 0;
        private Vector3 _hit_normal = Vector3.zero;
        private static int _transparent_frequence = 10;
        private int _transparent_update_count = 0;

        public override uint ID => XCameraCollisonComponent.uuID;

        public Vector3 HitNormal => this._hit_normal;

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            this._camera_host = host as XCameraEx;
            this._transparent_update_count = 0;
        }

        public override void OnDetachFromHost()
        {
            base.OnDetachFromHost();
            this._camera_host = (XCameraEx)null;
        }

        private void InvisibleOn()
        {
            bool quality = XQualitySetting.GetQuality(EFun.ESceneFade);
            if (this._invisible == null)
                return;
            for (int index = 0; index < this._invisible.Count; ++index)
            {
                SceneMat sceneMat = this._invisible[index];
                if (quality)
                {
                    sceneMat.Fade(true);
                    this._invisible[index] = sceneMat;
                }
                else
                    sceneMat.render.gameObject.layer = 31;
            }
        }

        private void InvisibleOff()
        {
            bool quality = XQualitySetting.GetQuality(EFun.ESceneFade);
            if (this._invisible != null)
            {
                int index = 0;
                for (int count = this._invisible.Count; index < count; ++index)
                {
                    SceneMat sceneMat = this._invisible[index];
                    if ((Object)sceneMat.render != (Object)null)
                    {
                        if (quality)
                            sceneMat.Fade(false);
                        else
                            sceneMat.render.gameObject.layer = 0;
                    }
                }
            }
            this._invisible.Clear();
        }

        public override void PostUpdate(float fDeltaT)
        {
            this.UpdateCamera(fDeltaT);
            this.UpdateSceneTransparent();
        }

        protected void UpdateCamera(float fDeltaT)
        {
            this._hit_normal = Vector3.zero;
            this._real_pos = this._camera_host.CameraTrans.position;
            Vector3 vector3 = this._real_pos - this._camera_host.Anchor;
            float magnitude = vector3.magnitude;
            this._layer_mask = 513;
            if (XSingleton<XOperationData>.singleton.OperationMode == XOperationMode.X25D)
                this._layer_mask |= 4096;
            RaycastHit hitInfo;
            if (Physics.SphereCast(this._camera_host.Anchor, this._collision_radius, vector3.normalized, out hitInfo, magnitude, this._layer_mask))
            {
                switch (XSingleton<XOperationData>.singleton.OperationMode)
                {
                    case XOperationMode.X25D:
                        if (hitInfo.collider.gameObject.layer == 0 && XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall && !Physics.SphereCast(this._camera_host.Anchor, this._collision_radius, vector3.normalized, out hitInfo, magnitude, 512))
                        {
                            this._tdis = Mathf.Max((this._camera_host.Anchor - this._real_pos).magnitude, magnitude);
                            this._camera_host.Offset += (this._tdis - this._camera_host.Offset) * Mathf.Min(1f, fDeltaT * 4f);
                            break;
                        }
                        this._real_pos = hitInfo.point + hitInfo.normal * this._collision_radius;
                        this._camera_host.Offset = Mathf.Min((this._camera_host.Anchor - this._real_pos).magnitude, magnitude);
                        this._hit_normal = hitInfo.normal;
                        break;
                    case XOperationMode.X3D:
                    case XOperationMode.X3D_Free:
                        this._real_pos = hitInfo.point + hitInfo.normal * this._collision_radius;
                        this._camera_host.Offset = Mathf.Min((this._camera_host.Anchor - this._real_pos).magnitude, magnitude);
                        this._hit_normal = hitInfo.normal;
                        break;
                }
            }
            else
            {
                this._tdis = magnitude;
                this._camera_host.Offset += (this._tdis - this._camera_host.Offset) * Mathf.Min(1f, fDeltaT * 4f);
            }
            this._camera_host.CameraTrans.position = this._camera_host.Anchor - this._camera_host.CameraTrans.forward * this._camera_host.Offset;
            if (!this._camera_host.IsLookAt)
                return;
            this._camera_host.LookAtTarget();
        }

        protected void UpdateSceneTransparent()
        {
            if (this._transparent_update_count <= 0)
            {
                this._transparent_update_count = XCameraCollisonComponent._transparent_frequence;
                this._layer_mask = 1 << LayerMask.NameToLayer("45Transparent");
                this._real_pos = this._camera_host.Anchor - this._camera_host.CameraTrans.forward * this._camera_host.TargetOffset;
                Vector3 vector3 = this._real_pos - this._camera_host.Anchor;
                RaycastHit[] raycastHitArray = Physics.SphereCastAll(this._camera_host.Anchor, this._collision_radius, vector3.normalized, vector3.magnitude, this._layer_mask);
                if (raycastHitArray.Length != 0 && !XSingleton<XCutScene>.singleton.IsPlaying)
                {
                    this._hit_collider.Clear();
                    for (int index = 0; index < raycastHitArray.Length; ++index)
                    {
                        if (raycastHitArray[index].collider.gameObject.layer == LayerMask.NameToLayer("45Transparent"))
                            this._hit_collider.Add(raycastHitArray[index].collider);
                    }
                    if (!this.IsColliderSetEqual(this._hit_collider, this._last_hit_collider))
                    {
                        this.InvisibleOff();
                        for (int index = 0; index < this._hit_collider.Count; ++index)
                        {
                            if (this._hit_collider[index].gameObject.GetComponent("XColliderRenderLinker") is IColliderRenderLinker component7)
                            {
                                foreach (Renderer r in component7.GetLinkedRender())
                                {
                                    if ((Object)r != (Object)null && !this.InVisibleContains(r))
                                    {
                                        SceneMat sceneMat = new SceneMat();
                                        sceneMat.InitRender(r);
                                        this._invisible.Add(sceneMat);
                                    }
                                }
                            }
                        }
                        this.InvisibleOn();
                    }
                    this.CloneColliderSet(this._last_hit_collider, this._hit_collider);
                }
                else
                {
                    this.InvisibleOff();
                    this._last_hit_collider.Clear();
                }
            }
            else
                --this._transparent_update_count;
        }

        private bool InVisibleContains(Renderer r)
        {
            for (int index = 0; index < this._invisible.Count; ++index)
            {
                if ((Object)this._invisible[index].render == (Object)r)
                    return true;
            }
            return false;
        }

        private bool IsColliderSetEqual(List<Collider> s, List<Collider> t)
        {
            if (s.Count != t.Count)
                return false;
            for (int index = 0; index < s.Count; ++index)
            {
                if (!t.Contains(s[index]))
                    return false;
            }
            return true;
        }

        private void CloneColliderSet(List<Collider> s, List<Collider> t)
        {
            s.Clear();
            for (int index = 0; index < t.Count; ++index)
                s.Add(t[index]);
        }
    }
}
