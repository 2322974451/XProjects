using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200172F RID: 5935
	internal class XBuffMonitorHandler : DlgHandlerBase
	{
		// Token: 0x0600F512 RID: 62738 RVA: 0x00373CFC File Offset: 0x00371EFC
		protected override void Init()
		{
			base.Init();
			bool flag = base.PanelObject.layer == LayerMask.NameToLayer("Billboard");
			if (flag)
			{
				this.m_TplGo = base.PanelObject.transform.Find("Buff").gameObject;
			}
			else
			{
				this.m_TplGo = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/Buff", true, false) as GameObject);
				this.m_TplGo.transform.parent = base.PanelObject.transform;
			}
			Transform transform = base.PanelObject.transform.Find("BuffTpl");
			this.m_TplGo.transform.localPosition = transform.localPosition;
			this.m_TplGo.transform.localScale = transform.localScale;
			transform.gameObject.SetActive(false);
			this.m_BuffPool.SetupPool(base.PanelObject, this.m_TplGo, this.m_MaxDisplayBuffCount, false);
		}

		// Token: 0x0600F513 RID: 62739 RVA: 0x00373DF8 File Offset: 0x00371FF8
		public override void OnUnload()
		{
			XResourceLoaderMgr.SafeDestroy(ref this.m_TplGo, true);
			base.OnUnload();
		}

		// Token: 0x0600F514 RID: 62740 RVA: 0x00373E10 File Offset: 0x00372010
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_BuffList == null;
			if (!flag)
			{
				for (int i = 0; i < this.m_BuffList.Length; i++)
				{
					this.m_BuffList[i].OnUpdate();
				}
			}
		}

		// Token: 0x0600F515 RID: 62741 RVA: 0x00373E5C File Offset: 0x0037205C
		public void InitMonitor(uint maxDisplayCount, bool bLeftToRight = true, bool bShowTime = true)
		{
			this.m_MaxDisplayBuffCount = maxDisplayCount;
			bool flag = this.m_BuffList != null;
			if (flag)
			{
				this.m_BuffPool.ReturnAll(false);
			}
			this.m_BuffList = new XBuffIcon[this.m_MaxDisplayBuffCount];
			int num = 0;
			while ((long)num < (long)((ulong)this.m_MaxDisplayBuffCount))
			{
				XBuffIcon xbuffIcon = new XBuffIcon();
				GameObject gameObject = this.m_BuffPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(this.m_BuffPool.TplPos.x + (float)((bLeftToRight ? 1 : -1) * num * this.m_BuffPool.TplWidth), this.m_BuffPool.TplPos.y, this.m_BuffPool.TplPos.z);
				xbuffIcon.Init(gameObject, bShowTime);
				this.m_BuffList[num] = xbuffIcon;
				num++;
			}
		}

		// Token: 0x0600F516 RID: 62742 RVA: 0x00373F3C File Offset: 0x0037213C
		public void OnBuffChanged(List<UIBuffInfo> buffList)
		{
			int num = 0;
			int num2 = 0;
			while (num2 < buffList.Count && num < this.m_BuffList.Length)
			{
				bool flag = buffList[num2].buffInfo == null || !buffList[num2].buffInfo.BuffIsVisible;
				if (!flag)
				{
					this.m_BuffList[num++].Set(buffList[num2]);
				}
				num2++;
			}
			for (int i = num; i < this.m_BuffList.Length; i++)
			{
				this.m_BuffList[i].Hide();
			}
		}

		// Token: 0x04006A06 RID: 27142
		private XUIPool m_BuffPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006A07 RID: 27143
		private XBuffIcon[] m_BuffList;

		// Token: 0x04006A08 RID: 27144
		private GameObject m_TplGo;

		// Token: 0x04006A09 RID: 27145
		private uint m_MaxDisplayBuffCount = 5U;
	}
}
