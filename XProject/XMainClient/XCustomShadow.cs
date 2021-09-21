using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008BA RID: 2234
	[RequireComponent(typeof(Camera))]
	public class XCustomShadow : MonoBehaviour
	{
		// Token: 0x0600871D RID: 34589 RVA: 0x00113D50 File Offset: 0x00111F50
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

		// Token: 0x0600871E RID: 34590 RVA: 0x00113E30 File Offset: 0x00112030
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

		// Token: 0x0600871F RID: 34591 RVA: 0x00113F54 File Offset: 0x00112154
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

		// Token: 0x06008720 RID: 34592 RVA: 0x00114040 File Offset: 0x00112240
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

		// Token: 0x06008721 RID: 34593 RVA: 0x00114088 File Offset: 0x00112288
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

		// Token: 0x06008722 RID: 34594 RVA: 0x001140F8 File Offset: 0x001122F8
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

		// Token: 0x04002A8C RID: 10892
		public int shadowChannel = 0;

		// Token: 0x04002A8D RID: 10893
		public ShadowMapInfo shadowMapInfoRef = null;

		// Token: 0x04002A8E RID: 10894
		public Camera m_shadowCamera = null;

		// Token: 0x04002A8F RID: 10895
		private Transform m_shadowCameraTransformCache = null;

		// Token: 0x04002A90 RID: 10896
		private Transform m_TargetTransformCache = null;

		// Token: 0x04002A91 RID: 10897
		public Transform m_modifyEntityTransformCache = null;

		// Token: 0x04002A92 RID: 10898
		public static float scale = 0.33f;

		// Token: 0x04002A93 RID: 10899
		public float bias = 0.5f;

		// Token: 0x04002A94 RID: 10900
		private Vector3 m_lastShadowPos = Vector3.zero;

		// Token: 0x04002A95 RID: 10901
		private Transform m_lightTransformCache = null;

		// Token: 0x04002A96 RID: 10902
		private Vector3 m_invLightForwardDir = new Vector3(0f, 0f, -1f);

		// Token: 0x04002A97 RID: 10903
		private Vector3 m_lightRightDir = new Vector3(1f, 0f, 0f);

		// Token: 0x04002A98 RID: 10904
		private Vector3 m_lightUpDir = new Vector3(0f, 1f, 0f);

		// Token: 0x04002A99 RID: 10905
		public Matrix4x4 scaleBiasMatrix = Matrix4x4.identity;

		// Token: 0x04002A9A RID: 10906
		private static Texture shadowMask = null;
	}
}
