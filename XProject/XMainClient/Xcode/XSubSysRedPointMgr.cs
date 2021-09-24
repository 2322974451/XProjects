using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSubSysRedPointMgr
	{

		public void SetupRedPoints(IXUIObject[] btns)
		{
			this._btns.Clear();
			this.Append(btns);
			this.UpdateRedPointUI();
		}

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

		public List<XSubSysRedPointMgr.RedPointInfo> _btns = new List<XSubSysRedPointMgr.RedPointInfo>();

		public class RedPointInfo
		{

			public IXUIObject _btn = null;

			public Transform redPoint = null;
		}
	}
}
