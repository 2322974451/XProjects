

using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
    public class XAnimator
    {
        private short m_LoadStatus = 0;
        public XGameObject xGameObject = (XGameObject)null;
        private Animator m_Ator = (Animator)null;
        private AnimatorOverrideController m_overrideController = (AnimatorOverrideController)null;
        private AnimatorCullingMode m_cullingMode = AnimatorCullingMode.CullUpdateTransforms;
        private bool m_delayPlay = false;
        private bool m_crossFade = false;
        private string m_stateName = "";
        private int m_playLayer = 0;
        private float m_normalizedTime = float.NegativeInfinity;
        private float m_value = 0.0f;
        private string m_triggerName = "";
        private float m_speed = 1f;
        private bool m_enable = true;
        private Dictionary<string, float> m_FloatCache = (Dictionary<string, float>)null;
        private int m_LoadFinishCbFlag = 0;
        private static AnimLoadCallback SyncTriggerCmd = new AnimLoadCallback(XAnimator.SyncTrigger);
        private static AnimLoadCallback SyncSetFloatCmd = new AnimLoadCallback(XAnimator.SyncSetFloat);
        private static AnimLoadCallback SyncSpeedCmd = new AnimLoadCallback(XAnimator.SyncSpeed);
        private static AnimLoadCallback SyncEnableCmd = new AnimLoadCallback(XAnimator.SyncEnable);
        private static AnimLoadCallback[] loadCallbacks = (AnimLoadCallback[])null;
        private Dictionary<string, XAnimator.AminInfo> m_Clips = new Dictionary<string, XAnimator.AminInfo>();
        public static bool debug = false;

        public XAnimator()
        {
            if (XAnimator.loadCallbacks != null)
                return;
            XAnimator.loadCallbacks = new AnimLoadCallback[4]
            {
        XAnimator.SyncEnableCmd,
        XAnimator.SyncSpeedCmd,
        XAnimator.SyncTriggerCmd,
        XAnimator.SyncSetFloatCmd
            };
        }

        public bool IsLoaded => this.m_LoadStatus == (short)2;

        private bool IsInLoadFinish => this.m_LoadStatus == (short)1;

        public float speed
        {
            get => this.m_speed;
            set
            {
                this.m_speed = value;
                if (this.IsLoaded)
                    XAnimator.SyncSpeed(this);
                else
                    this.SetCbFlag(XAnimator.ECallbackCmd.ESyncSpeed, true);
            }
        }

        public bool enabled
        {
            get => this.m_enable;
            set
            {
                this.m_enable = value;
                if (this.IsLoaded)
                    XAnimator.SyncEnable(this);
                else
                    this.SetCbFlag(XAnimator.ECallbackCmd.ESyncEnable, true);
            }
        }

        public string StateName => this.m_stateName;

        public AnimatorCullingMode cullingMode
        {
            set
            {
                this.m_cullingMode = value;
                if (!this.IsLoaded)
                    return;
                XAnimator.SyncAnimationCullingMode(this);
            }
        }

        private void SetCbFlag(XAnimator.ECallbackCmd cmd, bool add)
        {
            int num = XFastEnumIntEqualityComparer<XAnimator.ECallbackCmd>.ToInt(cmd);
            if (add)
                this.m_LoadFinishCbFlag |= num;
            else
                this.m_LoadFinishCbFlag &= ~num;
        }

        private bool IsCbFlag(int index) => (uint)(this.m_LoadFinishCbFlag & 1 << index) > 0U;

        private void CacheFloatValue(string name, float value)
        {
            if (this.m_FloatCache == null)
                this.m_FloatCache = DictionaryPool<string, float>.Get();
            this.m_FloatCache[name] = value;
        }

        public void Init(GameObject gameObject)
        {
            this.m_LoadStatus = (short)1;
            this.m_Ator = (Object)gameObject != (Object)null ? gameObject.GetComponent<Animator>() : (Animator)null;
            if ((Object)this.m_Ator != (Object)null)
            {
                this.m_Ator.enabled = true;
                if (this.m_Ator.runtimeAnimatorController is AnimatorOverrideController)
                {
                    this.m_overrideController = this.m_Ator.runtimeAnimatorController as AnimatorOverrideController;
                }
                else
                {
                    this.m_overrideController = new AnimatorOverrideController();
                    this.m_overrideController.runtimeAnimatorController = this.m_Ator.runtimeAnimatorController;
                    this.m_Ator.runtimeAnimatorController = (RuntimeAnimatorController)this.m_overrideController;
                }
                Dictionary<string, XAnimator.AminInfo>.Enumerator enumerator = this.m_Clips.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    XAnimator.AminInfo aminInfo = enumerator.Current.Value;
                    if ((Object)aminInfo.xclip != (Object)null)
                        this.SyncOverrideAnim(aminInfo.clipKey, aminInfo.xclip);
                }
                this.m_Ator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
                this.m_Ator.Rebind();
                for (int index = 0; index < XAnimator.loadCallbacks.Length; ++index)
                {
                    if (this.IsCbFlag(index))
                        XAnimator.loadCallbacks[index](this);
                }
            }
            this.m_LoadFinishCbFlag = 0;
            this.m_LoadStatus = (short)2;
        }

        public bool IsSame(Animator ator) => (Object)this.m_Ator == (Object)ator;

        public bool IsAnimStateValid() => this.IsLoaded && !string.IsNullOrEmpty(this.m_stateName);

        public void Reset()
        {
            if ((Object)this.m_Ator != (Object)null)
            {
                this.m_Ator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
                this.m_Ator.enabled = false;
                this.m_Ator = (Animator)null;
            }
            if ((Object)this.m_overrideController != (Object)null)
            {
                foreach (AnimationClipPair clip in this.m_overrideController.clips)
                {
                    if ((Object)clip.overrideClip != (Object)null)
                        this.m_overrideController[clip.originalClip.name] = (AnimationClip)null;
                }
                this.m_overrideController = (AnimatorOverrideController)null;
            }
            Dictionary<string, XAnimator.AminInfo>.Enumerator enumerator = this.m_Clips.GetEnumerator();
            while (enumerator.MoveNext())
            {
                XAnimator.AminInfo aminInfo = enumerator.Current.Value;
                if ((Object)aminInfo.xclip != (Object)null)
                    XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(aminInfo.clipPath, ".anim", (Object)aminInfo.xclip);
            }
            this.m_Clips.Clear();
            this.m_cullingMode = AnimatorCullingMode.CullUpdateTransforms;
            this.m_delayPlay = false;
            this.m_stateName = "";
            this.m_value = -1f;
            this.m_playLayer = -1;
            this.m_normalizedTime = float.NegativeInfinity;
            this.m_triggerName = "";
            this.m_LoadStatus = (short)0;
            this.m_LoadFinishCbFlag = 0;
            this.xGameObject = (XGameObject)null;
        }

        public void SetStateMachine(IAnimStateMachine stateMachine)
        {
        }

        private void SyncOverrideAnim(string key, XAnimationClip xclip)
        {
            if (!((Object)this.m_Ator != (Object)null))
                return;
            if (XAnimator.debug)
                XSingleton<XDebug>.singleton.AddWarningLog2("GO:{0} OverrideAnim {1}", (object)this.xGameObject.Name, (object)key);
            this.m_overrideController[key] = (Object)xclip != (Object)null ? xclip.clip : (AnimationClip)null;
        }

        public void OverrideAnim(
          string key,
          string clipPath,
          OverrideAnimCallback overrideAnim = null,
          bool forceOverride = false)
        {
            if (clipPath == null)
                clipPath = "";
            if ((Object)this.m_Ator == (Object)null && this.IsLoaded)
                return;
            XAnimator.AminInfo aminInfo;
            if (this.m_Clips.TryGetValue(key, out aminInfo))
            {
                if (aminInfo.clipPath == clipPath)
                {
                    if (forceOverride && this.IsLoaded)
                        this.SyncOverrideAnim(key, aminInfo.xclip);
                    if (overrideAnim == null)
                        return;
                    overrideAnim(aminInfo.xclip);
                    return;
                }
                if ((Object)aminInfo.xclip != (Object)null)
                {
                    XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource("", ".anim", (Object)aminInfo.xclip);
                    aminInfo.xclip = (XAnimationClip)null;
                }
            }
            else
                aminInfo.clipKey = key;
            aminInfo.clipPath = clipPath;
            aminInfo.xclip = string.IsNullOrEmpty(clipPath) ? (XAnimationClip)null : XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(clipPath);
            this.m_Clips[key] = aminInfo;
            if (this.IsLoaded)
                this.SyncOverrideAnim(key, aminInfo.xclip);
            if (overrideAnim == null)
                return;
            overrideAnim(aminInfo.xclip);
        }

        public void SetAnimLoadCallback(string key, OverrideAnimCallback overrideAnim)
        {
            XAnimator.AminInfo aminInfo;
            if ((Object)this.m_Ator == (Object)null && this.IsLoaded || overrideAnim == null || !this.m_Clips.TryGetValue(key, out aminInfo) || !((Object)aminInfo.xclip != (Object)null))
                return;
            overrideAnim(aminInfo.xclip);
        }

        public static void SyncAnimationCullingMode(XAnimator ator)
        {
            if (ator == null || !((Object)ator.m_Ator != (Object)null))
                return;
            ator.m_Ator.cullingMode = ator.m_cullingMode;
        }

        private static void SyncTrigger(XAnimator ator)
        {
            if (ator == null || !((Object)ator.m_Ator != (Object)null) || string.IsNullOrEmpty(ator.m_triggerName))
                return;
            if (XAnimator.debug)
                XSingleton<XDebug>.singleton.AddWarningLog2("GO:{0} trigger {1}", (object)ator.xGameObject.Name, (object)ator.m_triggerName);
            ator.m_Ator.SetTrigger(ator.m_triggerName);
        }

        private static void SyncSetFloat(XAnimator ator)
        {
            if (ator == null || !((Object)ator.m_Ator != (Object)null) || ator.m_FloatCache == null)
                return;
            Dictionary<string, float>.Enumerator enumerator = ator.m_FloatCache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (XAnimator.debug)
                    XSingleton<XDebug>.singleton.AddWarningLog2("GO:{0} SetFloat {1}", (object)ator.xGameObject.Name, (object)enumerator.Current.Key);
                ator.m_Ator.SetFloat(enumerator.Current.Key, enumerator.Current.Value);
            }
            DictionaryPool<string, float>.Release(ator.m_FloatCache);
            ator.m_FloatCache = (Dictionary<string, float>)null;
        }

        private static void SyncSpeed(XAnimator ator)
        {
            if (ator == null || !((Object)ator.m_Ator != (Object)null))
                return;
            ator.m_Ator.speed = ator.m_speed;
        }

        private static void SyncEnable(XAnimator ator)
        {
            if (ator == null || !((Object)ator.m_Ator != (Object)null))
                return;
            ator.m_Ator.enabled = ator.m_enable;
        }

        public static void Update(XAnimator ator)
        {
            XAnimator.SyncAnimationCullingMode(ator);
            if (!ator.m_delayPlay)
                return;
            ator.RealPlay();
        }

        public void RealPlay()
        {
            this.m_delayPlay = false;
            if (!((Object)this.m_Ator != (Object)null))
                return;
            if (this.m_crossFade)
            {
                if (XAnimator.debug)
                    XSingleton<XDebug>.singleton.AddWarningLog2("GO:{0} crossFade {1} {2}", (object)this.xGameObject.Name, (object)this.m_stateName, (object)this.m_Ator.IsInTransition(0));
                this.m_Ator.CrossFade(this.m_stateName, this.m_value, this.m_playLayer, this.m_normalizedTime);
            }
            else
            {
                if (XAnimator.debug)
                    XSingleton<XDebug>.singleton.AddWarningLog2("GO:{0} play {1}", (object)this.xGameObject.Name, (object)this.m_stateName);
                this.m_Ator.Play(this.m_stateName, this.m_playLayer, this.m_normalizedTime);
            }
        }

        public void Play(string stateName, int layer, float normalizedTime)
        {
            this.m_stateName = stateName;
            this.m_playLayer = layer;
            this.m_normalizedTime = normalizedTime;
            this.m_crossFade = false;
            if (this.IsAnimStateValid())
                this.RealPlay();
            else
                this.m_delayPlay = true;
        }

        public void Play(string stateName, int layer)
        {
            this.m_stateName = stateName;
            this.m_playLayer = layer;
            this.m_normalizedTime = float.NegativeInfinity;
            this.m_crossFade = false;
            if (this.IsAnimStateValid())
                this.RealPlay();
            else
                this.m_delayPlay = true;
        }

        public void CrossFade(
          string stateName,
          float transitionDuration,
          int layer,
          float normalizedTime)
        {
            this.m_stateName = stateName;
            this.m_value = transitionDuration;
            this.m_playLayer = layer;
            this.m_normalizedTime = normalizedTime;
            this.m_crossFade = true;
            if (this.IsAnimStateValid())
                this.RealPlay();
            else
                this.m_delayPlay = true;
        }

        public void SetTrigger(string name)
        {
            this.m_triggerName = name;
            if (this.IsLoaded)
                XAnimator.SyncTrigger(this);
            else
                this.SetCbFlag(XAnimator.ECallbackCmd.ESyncTrigger, true);
        }

        public void ResetTrigger()
        {
            if (this.IsLoaded)
                XAnimator.SyncTrigger(this);
            else
                this.SetCbFlag(XAnimator.ECallbackCmd.ESyncTrigger, true);
        }

        public bool IsInTransition(int layerIndex) => !((Object)this.m_Ator == (Object)null) && this.m_Ator.IsInTransition(layerIndex);

        public void SetFloat(string name, float value)
        {
            if (this.IsLoaded)
            {
                if (!((Object)this.m_Ator != (Object)null))
                    return;
                this.m_Ator.SetFloat(name, value);
            }
            else
            {
                this.CacheFloatValue(name, value);
                this.SetCbFlag(XAnimator.ECallbackCmd.ESyncSetFloat, true);
            }
        }

        public void EnableRootMotion(bool enable)
        {
            if (!((Object)this.m_Ator != (Object)null))
                return;
            this.m_Ator.applyRootMotion = enable;
        }

        private enum ECallbackCmd
        {
            ESyncEnable = 1,
            ESyncSpeed = 2,
            ESyncTrigger = 4,
            ESyncSetFloat = 8,
        }

        private struct AminInfo
        {
            public XAnimationClip xclip;
            public string clipKey;
            public string clipPath;
        }
    }
}
