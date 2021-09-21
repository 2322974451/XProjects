using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DCB RID: 3531
	internal class XSubSysRedPointMgr
	{
		// Token: 0x0600C05B RID: 49243 RVA: 0x0028AD1F File Offset: 0x00288F1F
		public void SetupRedPoints(IXUIObject[] btns)
		{
			this._btns.Clear();
			this.Append(btns);
			this.UpdateRedPointUI();
		}

		// Token: 0x0600C05C RID: 49244 RVA: 0x0028AD40 File Offset: 0x00288F40
		public void Append(IXUIObject[] btns)
		{
			bool flag = btns != null;
			if (flag)
			{
				foreach (IXUIObject btn in btns)
				{
					this.Append(btn);
				}
			}
		}

		// Token: 0x0600C05D RID: 49245 RVA: 0x0028AD78 File Offset: 0x00288F78
		public void Append(IXUIObject btn)
		{
			bool flag = btn != null;
			if (flag)
			{
				XSubSysRedPointMgr.RedPointInfo redPointInfo = new XSubSysRedPointMgr.RedPointInfo();
				redPointInfo._btn = btn;
				redPointInfo.redPoint = btn.gameObject.transform.FindChild("RedPoint");
				this._btns.Add(redPointInfo);
			}
		}

		// Token: 0x0600C05E RID: 49246 RVA: 0x0028ADC8 File Offset: 0x00288FC8
		public void UpdateRedPointUI()
		{
			bool flag = this._btns == null;
			if (!flag)
			{
				XGameSysMgr singleton = XSingleton<XGameSysMgr>.singleton;
				for (int i = 0; i < this._btns.Count; i++)
				{
					XSubSysRedPointMgr.RedPointInfo redPointInfo = this._btns[i];
					bool flag2 = redPointInfo._btn == null || redPointInfo.redPoint == null;
					if (!flag2)
					{
						XSysDefine sys = (XSysDefine)redPointInfo._btn.ID;
						redPointInfo.redPoint.gameObject.SetActive(singleton.GetSysRedPointState(sys));
					}
				}
			}
		}

		// Token: 0x04005060 RID: 20576
		public List<XSubSysRedPointMgr.RedPointInfo> _btns = new List<XSubSysRedPointMgr.RedPointInfo>();

		// Token: 0x020019C6 RID: 6598
		public class RedPointInfo
		{
			// Token: 0x04007FE3 RID: 32739
			public IXUIObject _btn = null;

			// Token: 0x04007FE4 RID: 32740
			public Transform redPoint = null;
		}
	}
}
