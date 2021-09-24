

using KKSG;
using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	public class XQualitySetting
	{
		private static XQualitySetting.XSetting[] _settings = new XQualitySetting.XSetting[4]
		{
	  new XQualitySetting.XSetting(),
	  new XQualitySetting.XSetting(),
	  new XQualitySetting.XSetting(),
	  new XQualitySetting.XSetting()
		};
		private static float[] _hallLayerculldistance = new float[32];
		private static float[] _layerculldistance = new float[32];
		public static Light mainLight = (Light)null;
		public static IFxPro fxPro = (IFxPro)null;
		public static int VisibleRoleCountPerLevel = 5;
		private static int _VisibleRoleCount = 20;
		private static int _QualityLevel = -1;
		private static int _HardwareQualityLevel = -1;
		private static bool _IsPcOrSimulator = false;
		private static XQualitySetting.XSetting _CurrentSetting = (XQualitySetting.XSetting)null;
		public static bool _InHall = false;
		public static bool _CastShadow = false;
		public static float _FadeDistance = 81f;
		private static int _flag = 0;
		private static IEnvSetting _envSet;
		public static int width = 1136;
		public static int height = 640;
		public static float maxResolution = 640f;
		public static int _InvisiblityLayerOffset = 0;
		public static int _QualityHighLayerOffset = 0;
		public static int _QualityNormalLayerOffset = 0;
		public static int _UILayerOffset = 0;
		public static int _DefaultLayerOffset = 0;
		public static int InVisiblityLayer = 31;
		public static int UILayer = 5;
		public static int TerrainLayer = 9;
		public static float _WindSpeedFactor = 1f;
		public static int lowLevel = XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.ELow);
		public static int normalLevel = XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.ENormal);
		public static int heighLevel = XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.EHeigh);
		public static int veryHighLevel = XQualitySetting.heighLevel + 1;
		public static int numLevel = XFastEnumIntEqualityComparer<XQualitySetting.ESetting>.ToInt(XQualitySetting.ESetting.ENum);
		public static int lowResolution = XFastEnumIntEqualityComparer<XQualitySetting.EResolution>.ToInt(XQualitySetting.EResolution.ELow);
		public static int normalResolution = XFastEnumIntEqualityComparer<XQualitySetting.EResolution>.ToInt(XQualitySetting.EResolution.ENormal);
		public static int heighResolution = XFastEnumIntEqualityComparer<XQualitySetting.EResolution>.ToInt(XQualitySetting.EResolution.EHeigh);

		public static void Init()
		{
			XQualitySetting._InvisiblityLayerOffset = 1 << LayerMask.NameToLayer("InVisiblity");
			XQualitySetting._QualityHighLayerOffset = 1 << LayerMask.NameToLayer("QualityHigh");
			XQualitySetting._QualityNormalLayerOffset = 1 << LayerMask.NameToLayer("QualityNormal");
			XQualitySetting._UILayerOffset = 1 << LayerMask.NameToLayer("UI");
			XQualitySetting._DefaultLayerOffset = 1 << LayerMask.NameToLayer("Default");
			XQualitySetting.XSetting setting1 = XQualitySetting._settings[0];
			setting1._bloom = false;
			setting1._CameraHall = 130f;
			setting1._CameraWorld = 80f;
			setting1.bw = BlendWeights.OneBone;
			setting1._CullMask = ~(XQualitySetting._QualityHighLayerOffset | XQualitySetting._QualityNormalLayerOffset);
			setting1._EnableFog = false;
			setting1._ShaderLod = 100;
			setting1._MaxParticelCount = 3;
			XQualitySetting.XSetting setting2 = XQualitySetting._settings[1];
			setting2._bloom = false;
			setting2._CameraHall = 140f;
			setting2._CameraWorld = 80f;
			setting2.bw = BlendWeights.TwoBones;
			setting2._CullMask = ~XQualitySetting._QualityHighLayerOffset | XQualitySetting._QualityNormalLayerOffset;
			setting2._EnableFog = true;
			setting2._ShaderLod = 200;
			setting2._MaxParticelCount = 6;
			XQualitySetting.XSetting setting3 = XQualitySetting._settings[2];
			setting3._bloom = false;
			setting3._CameraHall = 150f;
			setting3._CameraWorld = 90f;
			setting3.bw = BlendWeights.TwoBones;
			setting3._CullMask = XQualitySetting._QualityHighLayerOffset | XQualitySetting._QualityNormalLayerOffset;
			setting3._EnableFog = true;
			setting3._ShaderLod = 600;
			setting3._MaxParticelCount = 50;
			XQualitySetting.XSetting setting4 = XQualitySetting._settings[3];
			setting4._bloom = true;
			setting4._CameraHall = 150f;
			setting4._CameraWorld = 90f;
			setting4.bw = BlendWeights.FourBones;
			setting4._CullMask = XQualitySetting._QualityHighLayerOffset | XQualitySetting._QualityNormalLayerOffset;
			setting4._EnableFog = true;
			setting4._ShaderLod = 600;
			setting4._MaxParticelCount = 50;
			XQualitySetting._hallLayerculldistance[LayerMask.NameToLayer("Npc")] = 35f;
			XQualitySetting._hallLayerculldistance[LayerMask.NameToLayer("Resources")] = 35f;
			XQualitySetting._hallLayerculldistance[LayerMask.NameToLayer("QualityHigh")] = 80f;
			XQualitySetting._hallLayerculldistance[LayerMask.NameToLayer("QualityNormal")] = 50f;
			XQualitySetting._hallLayerculldistance[LayerMask.NameToLayer("QualityCullDistance")] = 20f;
			XQualitySetting._hallLayerculldistance[LayerMask.NameToLayer("Dummy")] = 25f;
			XQualitySetting._layerculldistance[LayerMask.NameToLayer("Npc")] = 40f;
			XQualitySetting._layerculldistance[LayerMask.NameToLayer("Role")] = 40f;
			XQualitySetting._layerculldistance[LayerMask.NameToLayer("Enemy")] = 40f;
			XQualitySetting._layerculldistance[LayerMask.NameToLayer("BigGuy")] = 60f;
			XQualitySetting._layerculldistance[LayerMask.NameToLayer("QualityHigh")] = 60f;
			XQualitySetting._layerculldistance[LayerMask.NameToLayer("QualityNormal")] = 40f;
			XQualitySetting._layerculldistance[LayerMask.NameToLayer("QualityCullDistance")] = 20f;
		}

		public static void SetQuality(int level, bool init = false)
		{
			if (level < 0)
				return;
			if (init)
			{
				QualitySettings.SetQualityLevel(2);
				XQualitySetting._IsPcOrSimulator = level > XQualitySetting.veryHighLevel;
				XQualitySetting._HardwareQualityLevel = level;
				if (XQualitySetting._HardwareQualityLevel == XQualitySetting.lowLevel)
				{
					QualitySettings.pixelLightCount = 0;
					QualitySettings.masterTextureLimit = 1;
					QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
				}
				else
				{
					QualitySettings.pixelLightCount = 1;
					QualitySettings.masterTextureLimit = 0;
					QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
				}
				QualitySettings.particleRaycastBudget = 2;
			}
			int num = level > XQualitySetting.veryHighLevel ? XQualitySetting.veryHighLevel : level;
			XQualitySetting.XSetting setting;
			if (XQualitySetting._QualityLevel != num)
			{
				XQualitySetting._QualityLevel = num;
				setting = XQualitySetting._settings[XQualitySetting._QualityLevel];
				QualitySettings.blendWeights = setting.bw;
			}
			else
				setting = XQualitySetting._settings[XQualitySetting._QualityLevel];
			XQualitySetting._CurrentSetting = setting;
		}

		public static void InitResolution()
		{
			XQualitySetting.width = Screen.width;
			XQualitySetting.height = Screen.height;
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			if (specificDocument == null)
				return;
			XQualitySetting.SetResolution((XQualitySetting.EResolution)specificDocument.GetValue(XOptionsDefine.OD_RESOLUTION), true);
		}

		public static void SetResolution(XQualitySetting.EResolution resolution, bool force = false)
		{
			if (!(XQualitySetting._InHall | force) || Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
				return;
			int num1 = XFastEnumIntEqualityComparer<XQualitySetting.EResolution>.ToInt(resolution);
			if (num1 == XQualitySetting.heighResolution)
			{
				XQualitySetting.maxResolution = (float)XQualitySetting.height;
				Screen.SetResolution(XQualitySetting.width, XQualitySetting.height, true);
			}
			else
			{
				XQualitySetting.maxResolution = num1 != XQualitySetting.normalResolution ? 720f : 1080f;
				float num2 = XQualitySetting.maxResolution / (float)XQualitySetting.height;
				if ((double)num2 > 0.75)
					num2 = 0.75f;
				if ((double)num2 < 0.699999988079071)
					num2 = 0.7f;
				Screen.SetResolution((int)((double)XQualitySetting.width * (double)num2), (int)((double)XQualitySetting.height * (double)num2), true);
			}
		}

		public static int GetDefalutResolution() => XQualitySetting.width > 1920 ? XQualitySetting.normalResolution : XQualitySetting.heighResolution;

		public static int SetVisibleRoleLevel(int level)
		{
			if (level < 0)
				level = 0;
			else if (level > XQualitySetting.veryHighLevel)
				level = XQualitySetting.veryHighLevel;
			XQualitySetting._VisibleRoleCount = level * XQualitySetting.VisibleRoleCountPerLevel + XQualitySetting.VisibleRoleCountPerLevel;
			return XQualitySetting._VisibleRoleCount;
		}

		public static int GetDefalutVisibleRoleLevel() => XQualitySetting._HardwareQualityLevel == XQualitySetting.veryHighLevel ? XQualitySetting.veryHighLevel : XQualitySetting._HardwareQualityLevel + 1;

		public static void GetDefalutVisibleRoleCount(out int min, out int max)
		{
			min = XQualitySetting.VisibleRoleCountPerLevel;
			max = 4 * XQualitySetting.VisibleRoleCountPerLevel;
		}

		public static int GetVisibleRoleCount() => XQualitySetting._VisibleRoleCount;

		public static void PostSetQuality()
		{
			XQualitySetting._flag = 0;
			XQualitySetting.SetQuality(EFun.ECamera, XQualitySetting._QualityLevel >= XQualitySetting.heighLevel);
			XQualitySetting.SetQuality(EFun.ENpcShadow, XQualitySetting._QualityLevel >= XQualitySetting.heighLevel);
			XQualitySetting.SetQuality(EFun.ERoleShadow, XQualitySetting._QualityLevel >= XQualitySetting.normalLevel);
			XQualitySetting.SetQuality(EFun.EEnemyShadow, XQualitySetting._QualityLevel >= XQualitySetting.normalLevel);
			XQualitySetting.SetQuality(EFun.ERealTimeShadow, XQualitySetting._QualityLevel >= XQualitySetting.heighLevel && XQualitySetting._HardwareQualityLevel >= XQualitySetting.veryHighLevel && Application.platform != RuntimePlatform.Android);
			XQualitySetting.SetQuality(EFun.EFxPro, XQualitySetting._QualityLevel == XQualitySetting.veryHighLevel && XQualitySetting._HardwareQualityLevel >= XQualitySetting.veryHighLevel);
			XQualitySetting.SetQuality(EFun.ESceneFade, XQualitySetting._QualityLevel >= XQualitySetting.normalLevel);
			XQualitySetting.SetQuality(EFun.EFadeInOut, XQualitySetting._QualityLevel >= XQualitySetting.normalLevel);
			if (XSingleton<XGlobalConfig>.singleton.GetSettingEnum(ESettingConfig.ELowEffect))
				XQualitySetting.SetQuality(EFun.ELowEffect, XQualitySetting._QualityLevel == XQualitySetting.lowLevel);
			else
				XQualitySetting.SetQuality(EFun.ELowEffect, false);
			XQualitySetting.SetQuality(EFun.ECommonHigh, XQualitySetting._QualityLevel >= XQualitySetting.heighLevel && XQualitySetting._InHall);
		}

		public static int GetQuality() => XQualitySetting._QualityLevel;

		public static bool GetQuality(EFun fun) => (uint)(XQualitySetting._flag & XFastEnumIntEqualityComparer<EFun>.ToInt(fun)) > 0U;

		public static void SetQuality(EFun fun, bool add)
		{
			if (add)
				XQualitySetting._flag |= XFastEnumIntEqualityComparer<EFun>.ToInt(fun);
			else
				XQualitySetting._flag &= ~XFastEnumIntEqualityComparer<EFun>.ToInt(fun);
		}

		public static XQualitySetting.XSetting GetCurrentQualitySetting() => XQualitySetting._settings[XQualitySetting._QualityLevel];

		public static bool SupportHighEffect() => XQualitySetting._HardwareQualityLevel >= XQualitySetting.veryHighLevel && Application.platform != RuntimePlatform.Android;

		public static int GetDefaultQualityLevel() => XQualitySetting._IsPcOrSimulator ? XQualitySetting.veryHighLevel : (XQualitySetting._HardwareQualityLevel > XQualitySetting.heighLevel ? XQualitySetting.heighLevel : XQualitySetting._HardwareQualityLevel);

		public static void EnterScene()
		{
			XQualitySetting._InHall = false;
			XQualitySetting.PostSetQuality();
		}

		public static void EnterHall()
		{
			XQualitySetting._InHall = true;
			XQualitySetting.PostSetQuality();
		}

		public static void SwitchScene() => XQualitySetting._envSet = (IEnvSetting)null;

		public static void PostSceneLoad()
		{
			Shader.SetGlobalFloat("uirim", 0.0f);
			XQualitySetting._CastShadow = false;
			XQualitySetting.mainLight = (Light)null;
			GameObject gameObject = GameObject.Find("MainLight");
			if ((UnityEngine.Object)gameObject != (UnityEngine.Object)null)
			{
				XQualitySetting.mainLight = gameObject.GetComponent<Light>();
				if ((UnityEngine.Object)XQualitySetting.mainLight != (UnityEngine.Object)null)
				{
					Shader.SetGlobalColor("lightColor", XQualitySetting.mainLight.color * XQualitySetting.mainLight.intensity);
					Vector3 vector3 = -gameObject.transform.forward.normalized;
					Shader.SetGlobalVector("lightDir", new Vector4(vector3.x, vector3.y, vector3.z, 1f));
					XQualitySetting.mainLight.shadows = LightShadows.None;
					XQualitySetting._CastShadow = XQualitySetting.GetQuality(EFun.ERealTimeShadow) && !XSingleton<XScene>.singleton.IsMustTransform && gameObject.layer == XQualitySetting.TerrainLayer;
				}
			}
			ShadowMapInfo.EnableShadow(XQualitySetting._CastShadow);
		}

		public static void PostSetting()
		{
			DateTime now = DateTime.Now;
			int num = now.Hour * 3600 + now.Minute * 60 + now.Second;
			if (XQualitySetting._envSet != null)
			{
				SceneTable.RowData sceneData = XSingleton<XScene>.singleton.SceneData;
				if (sceneData != null && sceneData.EnvSet.Count > 0)
				{
					int index = 0;
					for (int count = sceneData.EnvSet.Count; index < count; ++index)
					{
						if (num >= sceneData.EnvSet[index, 0] && num < sceneData.EnvSet[index, 1])
						{
							XQualitySetting._envSet.EnableSetting(sceneData.EnvSet[index, 2]);
							break;
						}
					}
				}
				else
					XQualitySetting._envSet.EnableSetting(0);
			}
			XQualitySetting._WindSpeedFactor = XSingleton<XCommon>.singleton.RandomFloat(0.5f, 2f);
			XQualitySetting.fxPro = (IFxPro)null;
			if (XQualitySetting._CurrentSetting == null)
				return;
			Camera unityCamera = XSingleton<XScene>.singleton.GameCamera.UnityCamera;
			if ((UnityEngine.Object)unityCamera != (UnityEngine.Object)null)
			{
				unityCamera.hdr = false;
				if (XQualitySetting._InHall || XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID) == SceneType.SCENE_CALLBACK)
				{
					unityCamera.farClipPlane = XQualitySetting._CurrentSetting._CameraHall;
					unityCamera.cullingMask &= ~(XQualitySetting._QualityHighLayerOffset | XQualitySetting._QualityNormalLayerOffset);
					unityCamera.cullingMask |= XQualitySetting._CurrentSetting._CullMask;
					unityCamera.cullingMask &= ~XQualitySetting._InvisiblityLayerOffset;
					unityCamera.cullingMask &= ~XQualitySetting._UILayerOffset;
					unityCamera.layerCullDistances = XQualitySetting._hallLayerculldistance;
				}
				else
				{
					if ((double)unityCamera.farClipPlane < 300.0 || (double)unityCamera.farClipPlane > 600.0)
						unityCamera.farClipPlane = XQualitySetting._CurrentSetting._CameraWorld;
					unityCamera.cullingMask &= ~(XQualitySetting._QualityHighLayerOffset | XQualitySetting._QualityNormalLayerOffset);
					unityCamera.cullingMask |= XQualitySetting._CurrentSetting._CullMask;
					unityCamera.layerCullDistances = XQualitySetting._layerculldistance;
					unityCamera.cullingMask &= ~XQualitySetting._InvisiblityLayerOffset;
					unityCamera.cullingMask &= ~XQualitySetting._UILayerOffset;
				}
				if (Application.platform == RuntimePlatform.IPhonePlayer || XQualitySetting._IsPcOrSimulator)
				{
					XQualitySetting.fxPro = unityCamera.GetComponent("FxPro") as IFxPro;
					if (XQualitySetting.fxPro != null)
					{
						if (XQualitySetting.GetQuality(EFun.EFxPro) || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_LOGIN)
							XQualitySetting.fxPro.Enable(true);
						else
							XQualitySetting.fxPro.Enable(false);
					}
				}
				XSingleton<XFxMgr>.singleton.CameraLayerMask = unityCamera.cullingMask | XQualitySetting._UILayerOffset;
				unityCamera.useOcclusionCulling = false;
			}
			if (XQualitySetting._InHall && !XSingleton<XGame>.singleton.switchScene)
			{
				XQualitySetting.PostSceneLoad();
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				if (player != null && player.GetXComponent(XShadowComponent.uuID) is XShadowComponent xcomponent7)
					xcomponent7.ProcessShadow();
				List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
				for (int index = 0; index < all.Count; ++index)
				{
					XEntity xentity = all[index];
					if (xentity.Equipment != null)
					{
						xentity.Equipment.RefreshSuitFx();
						xentity.Equipment.RefreshEquipFx();
						xentity.Equipment.RefreshSecondWeaponFx();
					}
					if (xentity.GetXComponent(XShadowComponent.uuID) is XShadowComponent xcomponent8)
						xcomponent8.ProcessShadow();
				}
			}
			RenderSettings.fog = XQualitySetting._CurrentSetting._EnableFog;
			Shader.globalMaximumLOD = XQualitySetting._CurrentSetting._ShaderLod;
			XFxMgr.MaxParticelCount = XQualitySetting._CurrentSetting._MaxParticelCount;
		}

		public static void SetEnvSet(IEnvSetting envSet) => XQualitySetting._envSet = envSet;

		public static void SetDofFade(float fade)
		{
			if (XQualitySetting.fxPro == null)
				return;
			XQualitySetting.fxPro.SetDofFade(fade);
		}

		public static void Update()
		{
			if (XQualitySetting._CurrentSetting != null && XQualitySetting._CurrentSetting._ShaderLod >= 400 && XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.World)
				Shader.SetGlobalFloat("_windSpeed", Mathf.Sin(XQualitySetting._WindSpeedFactor * Time.realtimeSinceStartup));
			Transform cameraTrans = XSingleton<XScene>.singleton.GameCamera.CameraTrans;
			if (!((UnityEngine.Object)cameraTrans != (UnityEngine.Object)null))
				return;
			Shader.SetGlobalVector("cameraPos", (Vector4)cameraTrans.position);
		}

		public enum ESetting
		{
			ELow,
			ENormal,
			EHeigh,
			EVeryHeigh,
			ENum,
		}

		public enum EResolution
		{
			ELow,
			ENormal,
			EHeigh,
			ENum,
		}

		public class XSetting
		{
			public bool _bloom = false;
			public float _CameraHall = 130f;
			public float _CameraWorld = 80f;
			public BlendWeights bw = BlendWeights.OneBone;
			public int _CullMask = -1;
			public bool _EnableFog = true;
			public int _ShaderLod = 600;
			public int _MaxParticelCount = 10;
		}
	}
}
