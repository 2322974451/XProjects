using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008B9 RID: 2233
	public class XCustomShadowMgr : XSingleton<XCustomShadowMgr>
	{
		// Token: 0x06008714 RID: 34580 RVA: 0x00113980 File Offset: 0x00111B80
		public override bool Init()
		{
			XCustomShadowMgr.texMatrix[0, 0] = 0.5f;
			XCustomShadowMgr.texMatrix[1, 1] = 0.5f;
			XCustomShadowMgr.texMatrix[2, 2] = 0.5f;
			XCustomShadowMgr.texMatrix[0, 3] = 0.5f;
			XCustomShadowMgr.texMatrix[1, 3] = 0.5f;
			XCustomShadowMgr.texMatrix[2, 3] = 0.5f;
			return true;
		}

		// Token: 0x06008715 RID: 34581 RVA: 0x00113A00 File Offset: 0x00111C00
		private ShadowMapInfo GetShadowMap(out int channel)
		{
			channel = 0;
			bool flag = this.m_shadowGroups == null;
			if (flag)
			{
				this.m_shadowGroups = new List<ShadowMapInfo>();
			}
			for (int i = 0; i < this.m_shadowGroups.Count; i++)
			{
				ShadowMapInfo shadowMapInfo = this.m_shadowGroups[i];
				int num = shadowMapInfo.AllocChannel();
				bool flag2 = num != 0;
				if (flag2)
				{
					channel = num;
					return shadowMapInfo;
				}
			}
			ShadowMapInfo shadowMapInfo2 = new ShadowMapInfo();
			shadowMapInfo2.CreateShadowMap();
			channel = shadowMapInfo2.AllocChannel();
			this.m_shadowGroups.Add(shadowMapInfo2);
			return shadowMapInfo2;
		}

		// Token: 0x06008716 RID: 34582 RVA: 0x00113A9C File Offset: 0x00111C9C
		public XCustomShadow AddShadowProjector(Transform mainCamera)
		{
			int num = 0;
			ShadowMapInfo shadowMap = this.GetShadowMap(out num);
			bool flag = shadowMap != null && num != 0;
			XCustomShadow result;
			if (flag)
			{
				bool flag2 = this.m_shadowInfos == null;
				if (flag2)
				{
					this.m_shadowInfos = new List<XCustomShadow>();
				}
				for (int i = 0; i < this.m_shadowInfos.Count; i++)
				{
					XCustomShadow xcustomShadow = this.m_shadowInfos[i];
					bool flag3 = xcustomShadow.shadowChannel == 0;
					if (flag3)
					{
						xcustomShadow.shadowChannel = num;
						return xcustomShadow;
					}
				}
				XCustomShadow xcustomShadow2 = XCustomShadow.Create(mainCamera, shadowMap);
				xcustomShadow2.shadowChannel = num;
				this.m_shadowInfos.Add(xcustomShadow2);
				result = xcustomShadow2;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06008717 RID: 34583 RVA: 0x00113B5B File Offset: 0x00111D5B
		public void RemoveShadowProjector(XCustomShadow cs)
		{
			cs.Clear(false);
		}

		// Token: 0x06008718 RID: 34584 RVA: 0x00113B68 File Offset: 0x00111D68
		public void SetCullLayer(bool enable)
		{
			bool flag = this.m_shadowInfos != null;
			if (flag)
			{
				for (int i = 0; i < this.m_shadowInfos.Count; i++)
				{
					XCustomShadow xcustomShadow = this.m_shadowInfos[i];
					bool flag2 = xcustomShadow != null;
					if (flag2)
					{
						xcustomShadow.SetCullLayer(enable);
					}
				}
			}
		}

		// Token: 0x06008719 RID: 34585 RVA: 0x00113BC8 File Offset: 0x00111DC8
		public void SetShadowScale(float scale)
		{
			bool flag = this.m_shadowInfos != null;
			if (flag)
			{
				XCustomShadow.scale = 0.33f / scale;
				Shader.SetGlobalFloat("shadowScale", XCustomShadow.scale);
				for (int i = 0; i < this.m_shadowInfos.Count; i++)
				{
					XCustomShadow xcustomShadow = this.m_shadowInfos[i];
					bool flag2 = xcustomShadow != null && xcustomShadow.m_shadowCamera != null;
					if (flag2)
					{
						xcustomShadow.m_shadowCamera.orthographicSize = 1.5f * scale;
					}
				}
			}
		}

		// Token: 0x0600871A RID: 34586 RVA: 0x00113C60 File Offset: 0x00111E60
		public void Clear()
		{
			XCustomShadow.scale = 0.33f;
			Shader.SetGlobalFloat("shadowScale", XCustomShadow.scale);
			bool flag = this.m_shadowInfos != null;
			if (flag)
			{
				for (int i = 0; i < this.m_shadowInfos.Count; i++)
				{
					XCustomShadow xcustomShadow = this.m_shadowInfos[i];
					xcustomShadow.Clear(true);
				}
				this.m_shadowInfos.Clear();
			}
			bool flag2 = this.m_shadowGroups != null;
			if (flag2)
			{
				for (int j = 0; j < this.m_shadowGroups.Count; j++)
				{
					ShadowMapInfo shadowMapInfo = this.m_shadowGroups[j];
					shadowMapInfo.Clear();
				}
				this.m_shadowGroups.Clear();
			}
		}

		// Token: 0x04002A87 RID: 10887
		private const int m_MaxShadowCount = 4;

		// Token: 0x04002A88 RID: 10888
		private const int m_CurrentShadowCount = 0;

		// Token: 0x04002A89 RID: 10889
		private List<ShadowMapInfo> m_shadowGroups = null;

		// Token: 0x04002A8A RID: 10890
		private List<XCustomShadow> m_shadowInfos = null;

		// Token: 0x04002A8B RID: 10891
		public static Matrix4x4 texMatrix = Matrix4x4.identity;
	}
}
