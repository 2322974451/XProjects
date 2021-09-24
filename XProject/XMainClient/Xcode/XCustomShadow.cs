using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	[RequireComponent(typeof(Camera))]
	public class XCustomShadow : MonoBehaviour
	{

		public static XCustomShadow Create(Transform parent, ShadowMapInfo sg)
		{
			GameObject gameObject = new GameObject("ShadowProjector");
			Camera camera = gameObject.AddComponent<Camera>();
			XCustomShadow xcustomShadow = gameObject.AddComponent<XCustomShadow>();
			xcustomShadow.m_shadowCamera = camera;
			xcustomShadow.shadowMapInfoRef = sg;
			xcustomShadow.m_shadowCameraTransformCache = gameObject.transform;
			camera.useOcclusionCulling = false;
			camera.clearFlags = (CameraClearFlags)2;
			camera.backgroundColor = new Color(1f, 1f, 1f, 1f);
			camera.farClipPlane = 5f;
			camera.orthographicSize = 1.5f;
			camera.orthographic = true;
			camera.depth = -2f;
			camera.cullingMask = 0;
			camera.cullingMask |= 1 << XPlayer.PlayerLayer;
			camera.targetTexture = sg.shadowMap;
			camera.enabled = false;
			xcustomShadow.enabled = false;
			return xcustomShadow;
		}

		public void Begin(XGameObject target)
		{
			bool flag = this.OnTargetChange(target);
			if (flag)
			{
				bool flag2 = this.m_shadowCamera != null;
				if (flag2)
				{
					this.m_shadowCamera.orthographicSize = 1.5f;
					this.scaleBiasMatrix = Matrix4x4.Scale(Vector3.one);
					Shader shader = null;
					int num = this.shadowChannel;
					switch (num)
					{
					case 1:
						shader = ShaderManager._maskR;
						break;
					case 2:
						shader = ShaderManager._maskG;
						break;
					case 3:
						break;
					case 4:
						shader = ShaderManager._maskB;
						break;
					default:
						if (num == 8)
						{
							shader = ShaderManager._maskA;
						}
						break;
					}
					bool flag3 = shader != null;
					if (flag3)
					{
						this.m_shadowCamera.SetReplacementShader(shader, "RenderType");
						bool flag4 = XCustomShadow.shadowMask == null;
						if (flag4)
						{
							XCustomShadow.shadowMask = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<Texture>("Shader/Shadow/ShadowMask", ".png", true, false);
							Shader.SetGlobalTexture("_ShadowMask", XCustomShadow.shadowMask);
						}
					}
				}
			}
			bool flag5 = this.m_shadowCamera != null;
			if (flag5)
			{
				this.m_shadowCamera.enabled = true;
			}
			base.enabled = true;
		}

		public void Clear(bool destroy)
		{
			bool flag = this.shadowMapInfoRef != null;
			if (flag)
			{
				this.shadowMapInfoRef.FreeChannel(this.shadowChannel);
				this.shadowMapInfoRef = null;
			}
			this.shadowChannel = 0;
			this.m_lightTransformCache = null;
			this.m_TargetTransformCache = null;
			bool flag2 = this.m_shadowCamera != null;
			if (flag2)
			{
				this.m_shadowCamera.enabled = false;
			}
			base.enabled = false;
			if (destroy)
			{
				bool flag3 = this.m_shadowCamera != null;
				if (flag3)
				{
					this.m_shadowCamera.targetTexture = null;
				}
				bool flag4 = XCustomShadow.shadowMask != null;
				if (flag4)
				{
					XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource("Shader/Shadow/ShadowMask", ".png", XCustomShadow.shadowMask, false);
					XCustomShadow.shadowMask = null;
					Shader.SetGlobalTexture("_ShadowMask", null);
				}
				this.m_shadowCameraTransformCache = null;

				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public bool OnTargetChange(XGameObject target)
		{
			Transform transform = (target != null) ? target.Find("") : null;
			bool flag = this.m_TargetTransformCache != transform;
			bool result;
			if (flag)
			{
				this.m_TargetTransformCache = transform;
				this.m_lightTransformCache = null;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void SetCullLayer(bool enable)
		{
			bool flag = this.m_shadowCamera != null;
			if (flag)
			{
				this.m_shadowCamera.cullingMask = 0;
				if (enable)
				{
					this.m_shadowCamera.cullingMask |= 1 << XPlayer.PlayerLayer;
				}
				else
				{
					this.m_shadowCamera.cullingMask |= int.MinValue;
				}
			}
		}

		private void Update()
		{
			bool flag = this.m_lightTransformCache == null;
			if (flag)
			{
				Light mainLight = XQualitySetting.mainLight;
				bool flag2 = mainLight != null;
				if (flag2)
				{
					this.m_lightTransformCache = mainLight.transform;
					bool flag3 = this.m_lightTransformCache != null;
					if (flag3)
					{
						this.m_invLightForwardDir = -this.m_lightTransformCache.forward;
						this.m_lightRightDir = this.m_lightTransformCache.right;
						this.m_lightUpDir = this.m_lightTransformCache.up;
					}
				}
			}
			bool flag4 = this.m_shadowCameraTransformCache != null && this.m_lightTransformCache != null && this.m_TargetTransformCache != null;
			if (flag4)
			{
				Vector3 position = this.m_shadowCameraTransformCache.position;
				float num = this.m_lastShadowPos.x * position.x + this.m_lastShadowPos.y * position.y + this.m_lastShadowPos.z * position.z;
				float num2 = Quaternion.Angle(this.m_shadowCameraTransformCache.rotation, this.m_lightTransformCache.rotation);
				bool flag5 = num2 >= 5f || num > 0.5f;
				if (flag5)
				{
					this.m_shadowCameraTransformCache.rotation = this.m_lightTransformCache.rotation;
					this.m_shadowCameraTransformCache.position = this.m_TargetTransformCache.position + this.m_invLightForwardDir * 2f + this.m_lightRightDir * 0.4f + this.m_lightUpDir * 0.2f;
					this.m_lastShadowPos = this.m_shadowCameraTransformCache.position;
					this.scaleBiasMatrix[0, 0] = XCustomShadow.scale;
					this.scaleBiasMatrix[1, 1] = XCustomShadow.scale;
					this.scaleBiasMatrix[2, 2] = XCustomShadow.scale;
					this.scaleBiasMatrix[0, 3] = this.bias;
					this.scaleBiasMatrix[1, 3] = this.bias;
					this.scaleBiasMatrix[2, 3] = this.bias;
					Matrix4x4 matrix4x = this.scaleBiasMatrix * this.m_shadowCamera.worldToCameraMatrix;
					Shader.SetGlobalMatrix("custom_World2Shadow", matrix4x);
				}
				bool flag6 = this.m_modifyEntityTransformCache != this.m_TargetTransformCache && this.m_modifyEntityTransformCache != null;
				if (flag6)
				{
					this.m_TargetTransformCache = this.m_modifyEntityTransformCache;
				}
			}
		}

		public int shadowChannel = 0;

		public ShadowMapInfo shadowMapInfoRef = null;

		public Camera m_shadowCamera = null;

		private Transform m_shadowCameraTransformCache = null;

		private Transform m_TargetTransformCache = null;

		public Transform m_modifyEntityTransformCache = null;

		public static float scale = 0.33f;

		public float bias = 0.5f;

		private Vector3 m_lastShadowPos = Vector3.zero;

		private Transform m_lightTransformCache = null;

		private Vector3 m_invLightForwardDir = new Vector3(0f, 0f, -1f);

		private Vector3 m_lightRightDir = new Vector3(1f, 0f, 0f);

		private Vector3 m_lightUpDir = new Vector3(0f, 1f, 0f);

		public Matrix4x4 scaleBiasMatrix = Matrix4x4.identity;

		private static Texture shadowMask = null;
	}
}
