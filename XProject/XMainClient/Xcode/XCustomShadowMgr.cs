using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public class XCustomShadowMgr : XSingleton<XCustomShadowMgr>
	{

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

		public void RemoveShadowProjector(XCustomShadow cs)
		{
			cs.Clear(false);
		}

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

		private const int m_MaxShadowCount = 4;

		private const int m_CurrentShadowCount = 0;

		private List<ShadowMapInfo> m_shadowGroups = null;

		private List<XCustomShadow> m_shadowInfos = null;

		public static Matrix4x4 texMatrix = Matrix4x4.identity;
	}
}
