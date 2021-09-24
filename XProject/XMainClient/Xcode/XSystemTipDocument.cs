using System;
using System.Collections.Generic;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSystemTipDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSystemTipDocument.uuID;
			}
		}

		public void ShowTip(string text, string rgb)
		{
			this.m_StrQueue.Enqueue(string.Format("[{0}]{1}", rgb, text));
			bool flag = !DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton.SetAlpha(1f);
				}
				DlgBase<XSystemTipView, XSystemTipBehaviour>.singleton.SetVisible(true, true);
			}
		}

		public bool TryGetTip(ref string s)
		{
			bool flag = this.m_StrQueue.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				s = this.m_StrQueue.Dequeue();
				result = true;
			}
			return result;
		}

		public int LeftCount
		{
			get
			{
				return this.m_StrQueue.Count;
			}
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this.m_StrQueue.Clear();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SystemTipDocument");

		private Queue<string> m_StrQueue = new Queue<string>();
	}
}
