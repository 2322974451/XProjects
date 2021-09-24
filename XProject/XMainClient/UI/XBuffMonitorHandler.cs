using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XBuffMonitorHandler : DlgHandlerBase
	{

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

		public override void OnUnload()
		{
			XResourceLoaderMgr.SafeDestroy(ref this.m_TplGo, true);
			base.OnUnload();
		}

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

		private XUIPool m_BuffPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XBuffIcon[] m_BuffList;

		private GameObject m_TplGo;

		private uint m_MaxDisplayBuffCount = 5U;
	}
}
