// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.XSkillData
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using UnityEngine;

namespace XUtliPoolLib
{
    [Serializable]
    public class XSkillData
    {
        public static readonly string[] Skills = new string[4]
        {
      "XJAComboSkill",
      "XArtsSkill",
      "XUltraSkill",
      "XCombinedSkill"
        };
        public static readonly string[] JA_Command = new string[16]
        {
      "ToSkill",
      "ToJA_1_0",
      "ToJA_2_0",
      "ToJA_3_0",
      "ToJA_4_0",
      "ToJA_0_1",
      "ToJA_0_2",
      "ToJA_1_1",
      "ToJA_1_2",
      "ToJA_2_1",
      "ToJA_2_2",
      "ToJA_3_1",
      "ToJA_3_2",
      "ToJA_4_1",
      "ToJA_4_2",
      "ToJA_QTE"
        };
        public static readonly string[] Combined_Command = new string[10]
        {
      "ToPhase",
      "ToPhase1",
      "ToPhase2",
      "ToPhase3",
      "ToPhase4",
      "ToPhase5",
      "ToPhase6",
      "ToPhase7",
      "ToPhase8",
      "ToPhase9"
        };
        public static readonly string[] JaOverrideMap = new string[16]
        {
      "A",
      "AA",
      "AAA",
      "AAAA",
      "AAAAA",
      "AB",
      "ABB",
      "AAB",
      "AABB",
      "AAAB",
      "AAABB",
      "AAAAB",
      "AAAABB",
      "AAAAAB",
      "AAAAABB",
      "QTE"
        };
        public static readonly string[] CombinedOverrideMap = new string[10]
        {
      "Phase0",
      "Phase1",
      "Phase2",
      "Phase3",
      "Phase4",
      "Phase5",
      "Phase6",
      "Phase7",
      "Phase8",
      "Phase9"
        };
        public static readonly string[] MultipleAttackOverrideMap = new string[8]
        {
      "Forward",
      "RightForward",
      "Right",
      "RightBack",
      "LeftForward",
      "Left",
      "LeftBack",
      "Back"
        };
        [XmlIgnore]
        public string Prefix = (string)null;
        [SerializeField]
        public string Name;
        [SerializeField]
        [DefaultValue(1)]
        public int TypeToken;
        [SerializeField]
        public string ClipName;
        [SerializeField]
        [DefaultValue(0)]
        public int SkillPosition;
        [SerializeField]
        [DefaultValue(false)]
        public bool IgnoreCollision;
        [SerializeField]
        [DefaultValue(true)]
        public bool NeedTarget;
        [SerializeField]
        [DefaultValue(false)]
        public bool OnceOnly;
        [SerializeField]
        [DefaultValue(false)]
        public bool ForCombinedOnly;
        [SerializeField]
        [DefaultValue(false)]
        public bool MultipleAttackSupported;
        [SerializeField]
        [DefaultValue(0.75f)]
        public float BackTowardsDecline;
        [SerializeField]
        public string PVP_Script_Name;
        [SerializeField]
        public List<XResultData> Result;
        [SerializeField]
        public List<XChargeData> Charge;
        [SerializeField]
        public List<XJAData> Ja;
        [SerializeField]
        public List<XHitData> Hit;
        [SerializeField]
        public List<XManipulationData> Manipulation;
        [SerializeField]
        public List<XFxData> Fx;
        [SerializeField]
        public List<XAudioData> Audio;
        [SerializeField]
        public List<XCameraEffectData> CameraEffect;
        [SerializeField]
        public List<XWarningData> Warning;
        [SerializeField]
        public List<XCombinedData> Combined;
        [SerializeField]
        public List<XMobUnitData> Mob;
        [SerializeField]
        public XScriptData Script;
        [SerializeField]
        public XLogicalData Logical;
        [SerializeField]
        public XCameraMotionData CameraMotion;
        [SerializeField]
        public XCameraPostEffectData CameraPostEffect;
        [SerializeField]
        public XCastChain Chain;
        [SerializeField]
        [DefaultValue(1f)]
        public float CoolDown;
        [SerializeField]
        [DefaultValue(0.0f)]
        public float Time;
        [SerializeField]
        [DefaultValue(false)]
        public bool Cast_Range_Rect;
        [SerializeField]
        [DefaultValue(0.0f)]
        public float Cast_Range_Upper;
        [SerializeField]
        [DefaultValue(0.0f)]
        public float Cast_Range_Lower;
        [SerializeField]
        [DefaultValue(0.0f)]
        public float Cast_Offset_X;
        [SerializeField]
        [DefaultValue(0.0f)]
        public float Cast_Offset_Z;
        [SerializeField]
        [DefaultValue(0.0f)]
        public float Cast_Scope;
        [SerializeField]
        [DefaultValue(0.0f)]
        public float Cast_Scope_Shift;
        [SerializeField]
        [DefaultValue(1f)]
        public float CameraTurnBack;
        public static bool PreLoad = false;

        public XSkillData()
        {
            this.TypeToken = 1;
            this.NeedTarget = true;
            this.BackTowardsDecline = 0.75f;
            this.CameraTurnBack = 1f;
            this.CoolDown = 1f;
        }

        public static XSkillData PreLoadSkillForTemp(
          string skillprefix,
          string name,
          bool force = false)
        {
            XSkillData data = XSingleton<XResourceLoaderMgr>.singleton.GetData<XSkillData>(skillprefix + name, ".txt");
            data.Prefix = skillprefix;
            if (((Application.platform == RuntimePlatform.WindowsEditor ? 1 : (Application.platform == RuntimePlatform.OSXEditor ? 1 : 0)) | (force ? 1 : 0)) != 0)
                XSkillData.PreLoadSkillResEx(data, 1);
            else
                XSkillData.PreLoadSkillRes(data, 1);
            return data;
        }

        public static void PreLoadSkillRes(XSkillData data, int count)
        {
            if (!string.IsNullOrEmpty(data.ClipName))
                XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName);
            if (data.Fx != null)
            {
                for (int index = 0; index < data.Fx.Count; ++index)
                    XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Fx[index].Fx, count, ECreateHideType.DisableParticleRenderer);
            }
            if (data.Result == null)
                return;
            for (int index = 0; index < data.Result.Count; ++index)
            {
                if (data.Result[index].LongAttackEffect)
                {
                    XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Result[index].LongAttackData.End_Fx, count, ECreateHideType.DisableParticleRenderer);
                    XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Result[index].LongAttackData.Prefab, count, ECreateHideType.DisableParticleRenderer);
                }
            }
        }

        public static void PreLoadSkillResEx(XSkillData data, int count)
        {
            if (!string.IsNullOrEmpty(data.ClipName))
            {
                XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName);
                if (data.MultipleAttackSupported)
                {
                    XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName + "_right_forward");
                    XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName + "_right");
                    XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName + "_right_back");
                    XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName + "_left_forward");
                    XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName + "_left");
                    XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName + "_left_back");
                    XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.ClipName + "_back");
                }
            }
            if (data.Fx != null)
            {
                for (int index = 0; index < data.Fx.Count; ++index)
                    XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Fx[index].Fx, count, ECreateHideType.DisableParticleRenderer);
            }
            if (data.Hit != null && data.Hit.Count > 0)
                XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Hit[0].Fx, 1, ECreateHideType.DisableParticleRenderer);
            if (data.Warning != null)
            {
                for (int index = 0; index < data.Warning.Count; ++index)
                    XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Warning[index].Fx, count, ECreateHideType.DisableParticleRenderer);
            }
            if (data.Result != null)
            {
                for (int index = 0; index < data.Result.Count; ++index)
                {
                    if (data.Result[index].LongAttackEffect)
                    {
                        XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Result[index].LongAttackData.End_Fx, count, ECreateHideType.DisableParticleRenderer);
                        XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(data.Result[index].LongAttackData.Prefab, count, ECreateHideType.DisableParticleRenderer);
                    }
                }
            }
            if (data.CameraMotion == null || string.IsNullOrEmpty(data.CameraMotion.Motion))
                return;
            XSingleton<XResourceLoaderMgr>.singleton.GetXAnimation(data.CameraMotion.Motion);
        }
    }
}
