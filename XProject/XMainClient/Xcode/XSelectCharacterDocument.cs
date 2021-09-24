using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSelectCharacterDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSelectCharacterDocument.uuID;
			}
		}

		public XSelectCharView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public int CurrentProf
		{
			get
			{
				return this._currentCreateProf;
			}
			set
			{
				this._currentCreateProf = value;
			}
		}

		public List<RoleBriefInfo> RoleList
		{
			get
			{
				return this._roleList;
			}
			set
			{
				this._roleList = value;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.testlist.Add(1);
			this.testlist.Add(2);
			this.testlist.Add(4);
		}

		public void OnSelectCharBack()
		{
			XSingleton<XClientNetwork>.singleton.Close(NetErrCode.Net_NoError);
			XAutoFade.FadeOut2In(1.5f, 0.5f);
			XSingleton<XDebug>.singleton.AddLog(string.Concat(this.tttt), null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.BackToLoginOnClick), null);
		}

		public void OnEnterWorld()
		{
			XSelectcharStage xselectcharStage = XSingleton<XGame>.singleton.CurrentStage as XSelectcharStage;
			bool flag = xselectcharStage != null;
			if (flag)
			{
				xselectcharStage.EnterGameWorld(this._view.SelectCharIndex);
			}
			XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			specificDocument.GameAnnouncement = false;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		private void BackToLoginOnClick(object o)
		{
			XAutoFade.MakeBlack(false);
			XSingleton<XLoginDocument>.singleton.FromLogining();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SelectCharacterDocument");

		private int _currentCreateProf = -1;

		private int tttt = 2;

		private List<RoleBriefInfo> _roleList = new List<RoleBriefInfo>();

		private XSelectCharView _view = null;

		private List<int> testlist = new List<int>();
	}
}
