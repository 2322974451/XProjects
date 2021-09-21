using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009BE RID: 2494
	internal class XSelectCharacterDocument : XDocComponent
	{
		// Token: 0x17002D8A RID: 11658
		// (get) Token: 0x0600972E RID: 38702 RVA: 0x0016F0E4 File Offset: 0x0016D2E4
		public override uint ID
		{
			get
			{
				return XSelectCharacterDocument.uuID;
			}
		}

		// Token: 0x17002D8B RID: 11659
		// (get) Token: 0x0600972F RID: 38703 RVA: 0x0016F0FC File Offset: 0x0016D2FC
		// (set) Token: 0x06009730 RID: 38704 RVA: 0x0016F114 File Offset: 0x0016D314
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

		// Token: 0x17002D8C RID: 11660
		// (get) Token: 0x06009731 RID: 38705 RVA: 0x0016F120 File Offset: 0x0016D320
		// (set) Token: 0x06009732 RID: 38706 RVA: 0x0016F138 File Offset: 0x0016D338
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

		// Token: 0x17002D8D RID: 11661
		// (get) Token: 0x06009733 RID: 38707 RVA: 0x0016F144 File Offset: 0x0016D344
		// (set) Token: 0x06009734 RID: 38708 RVA: 0x0016F15C File Offset: 0x0016D35C
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

		// Token: 0x06009735 RID: 38709 RVA: 0x0016F166 File Offset: 0x0016D366
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.testlist.Add(1);
			this.testlist.Add(2);
			this.testlist.Add(4);
		}

		// Token: 0x06009736 RID: 38710 RVA: 0x0016F198 File Offset: 0x0016D398
		public void OnSelectCharBack()
		{
			XSingleton<XClientNetwork>.singleton.Close(NetErrCode.Net_NoError);
			XAutoFade.FadeOut2In(1.5f, 0.5f);
			XSingleton<XDebug>.singleton.AddLog(string.Concat(this.tttt), null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.BackToLoginOnClick), null);
		}

		// Token: 0x06009737 RID: 38711 RVA: 0x0016F200 File Offset: 0x0016D400
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

		// Token: 0x06009738 RID: 38712 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009739 RID: 38713 RVA: 0x0016F24B File Offset: 0x0016D44B
		private void BackToLoginOnClick(object o)
		{
			XAutoFade.MakeBlack(false);
			XSingleton<XLoginDocument>.singleton.FromLogining();
		}

		// Token: 0x0400339C RID: 13212
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SelectCharacterDocument");

		// Token: 0x0400339D RID: 13213
		private int _currentCreateProf = -1;

		// Token: 0x0400339E RID: 13214
		private int tttt = 2;

		// Token: 0x0400339F RID: 13215
		private List<RoleBriefInfo> _roleList = new List<RoleBriefInfo>();

		// Token: 0x040033A0 RID: 13216
		private XSelectCharView _view = null;

		// Token: 0x040033A1 RID: 13217
		private List<int> testlist = new List<int>();
	}
}
