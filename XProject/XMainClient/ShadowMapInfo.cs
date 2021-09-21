using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x020008B8 RID: 2232
	public class ShadowMapInfo
	{
		// Token: 0x0600870B RID: 34571 RVA: 0x00113794 File Offset: 0x00111994
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

		// Token: 0x0600870C RID: 34572 RVA: 0x00113814 File Offset: 0x00111A14
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

		// Token: 0x0600870D RID: 34573 RVA: 0x0011384D File Offset: 0x00111A4D
		public static void ClearShadowRes()
		{
			Shader.SetGlobalTexture("_CustomShadowMapTexture", null);
			ShadowMapInfo.EnableShadow(false);
		}

		// Token: 0x0600870E RID: 34574 RVA: 0x00113864 File Offset: 0x00111A64
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

		// Token: 0x0600870F RID: 34575 RVA: 0x001138A0 File Offset: 0x00111AA0
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

		// Token: 0x06008710 RID: 34576 RVA: 0x0011393D File Offset: 0x00111B3D
		public void FreeChannel(int channle)
		{
			this.m_shadowChannelState &= ~channle;
		}

		// Token: 0x06008711 RID: 34577 RVA: 0x0011394F File Offset: 0x00111B4F
		public void Clear()
		{
			this.m_shadowChannelState = 0;
			this.DestroyShadowMap();
		}

		// Token: 0x04002A7D RID: 10877
		private const int m_shadowMapWidth = 512;

		// Token: 0x04002A7E RID: 10878
		private const int m_shadowMapHeight = 512;

		// Token: 0x04002A7F RID: 10879
		public RenderTexture shadowMap = null;

		// Token: 0x04002A80 RID: 10880
		public const int RChannel = 1;

		// Token: 0x04002A81 RID: 10881
		public const int GChannel = 2;

		// Token: 0x04002A82 RID: 10882
		public const int BChannel = 4;

		// Token: 0x04002A83 RID: 10883
		public const int AChannel = 8;

		// Token: 0x04002A84 RID: 10884
		public const int EmpytChannel = 0;

		// Token: 0x04002A85 RID: 10885
		private int m_shadowChannelState = 0;

		// Token: 0x04002A86 RID: 10886
		private static bool hasShadowMap = false;
	}
}
