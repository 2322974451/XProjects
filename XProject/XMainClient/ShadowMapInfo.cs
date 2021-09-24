using System;
using UnityEngine;

namespace XMainClient
{

	public class ShadowMapInfo
	{

		public void CreateShadowMap()
		{
			this.shadowMap = new RenderTexture(512, 512, 0, (RenderTextureFormat)16, (RenderTextureReadWrite)0);
			this.shadowMap.name = "ShadowMap";
			this.shadowMap.autoGenerateMips = false;
			this.shadowMap.Create();
			Shader.SetGlobalTexture("_CustomShadowMapTexture", this.shadowMap);
			Shader.SetGlobalFloat("shadowScale", XCustomShadow.scale);
			ShadowMapInfo.hasShadowMap = true;
			ShadowMapInfo.EnableShadow(true);
		}

		public void DestroyShadowMap()
		{
			bool flag = this.shadowMap != null;
			if (flag)
			{
				this.shadowMap.Release();
				this.shadowMap = null;
				ShadowMapInfo.hasShadowMap = false;
			}
		}

		public static void ClearShadowRes()
		{
			Shader.SetGlobalTexture("_CustomShadowMapTexture", null);
			ShadowMapInfo.EnableShadow(false);
		}

		public static void EnableShadow(bool enable)
		{
			bool flag = enable && ShadowMapInfo.hasShadowMap;
			if (flag)
			{
				Shader.EnableKeyword("CUSTOM_SHADOW_ON");
			}
			else
			{
				Shader.DisableKeyword("CUSTOM_SHADOW_ON");
			}
		}

		public int AllocChannel()
		{
			bool flag = (this.m_shadowChannelState & 1) == 0;
			int result;
			if (flag)
			{
				this.m_shadowChannelState |= 1;
				result = 1;
			}
			else
			{
				bool flag2 = (this.m_shadowChannelState & 2) == 0;
				if (flag2)
				{
					this.m_shadowChannelState |= 2;
					result = 2;
				}
				else
				{
					bool flag3 = (this.m_shadowChannelState & 4) == 0;
					if (flag3)
					{
						this.m_shadowChannelState |= 4;
						result = 4;
					}
					else
					{
						bool flag4 = (this.m_shadowChannelState & 8) == 0;
						if (flag4)
						{
							this.m_shadowChannelState |= 8;
							result = 8;
						}
						else
						{
							result = 0;
						}
					}
				}
			}
			return result;
		}

		public void FreeChannel(int channle)
		{
			this.m_shadowChannelState &= ~channle;
		}

		public void Clear()
		{
			this.m_shadowChannelState = 0;
			this.DestroyShadowMap();
		}

		private const int m_shadowMapWidth = 512;

		private const int m_shadowMapHeight = 512;

		public RenderTexture shadowMap = null;

		public const int RChannel = 1;

		public const int GChannel = 2;

		public const int BChannel = 4;

		public const int AChannel = 8;

		public const int EmpytChannel = 0;

		private int m_shadowChannelState = 0;

		private static bool hasShadowMap = false;
	}
}
