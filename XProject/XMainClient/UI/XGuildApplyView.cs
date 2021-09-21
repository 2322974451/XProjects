using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018B3 RID: 6323
	internal class XGuildApplyView : DlgBase<XGuildApplyView, XGuildApplyBehaviour>
	{
		// Token: 0x17003A36 RID: 14902
		// (get) Token: 0x060107B5 RID: 67509 RVA: 0x00409230 File Offset: 0x00407430
		public override string fileName
		{
			get
			{
				return "Guild/GuildApplyDlg";
			}
		}

		// Token: 0x17003A37 RID: 14903
		// (get) Token: 0x060107B6 RID: 67510 RVA: 0x00409248 File Offset: 0x00407448
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A38 RID: 14904
		// (get) Token: 0x060107B7 RID: 67511 RVA: 0x0040925C File Offset: 0x0040745C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A39 RID: 14905
		// (get) Token: 0x060107B8 RID: 67512 RVA: 0x00409270 File Offset: 0x00407470
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060107B9 RID: 67513 RVA: 0x00409283 File Offset: 0x00407483
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XGuildListDocument>(XGuildListDocument.uuID);
		}

		// Token: 0x060107BA RID: 67514 RVA: 0x00409298 File Offset: 0x00407498
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnApply.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnApplyBtnClicked));
			base.uiBehaviour.m_BtnEnterGuild.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEnterSceneBtnClicked));
		}

		// Token: 0x060107BB RID: 67515 RVA: 0x00409304 File Offset: 0x00407504
		public void ShowApply(ulong uid, string name, uint ppt, bool bNeedApprove, string annoucement)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			this.m_UID = uid;
			this.m_Name = name;
			base.uiBehaviour.m_PPT.SetText(ppt.ToString());
			base.uiBehaviour.m_NeedApprove.SetText(bNeedApprove ? XStringDefineProxy.GetString("YES") : XStringDefineProxy.GetString("NO"));
			base.uiBehaviour.m_Annoucement.SetText(annoucement);
			base.uiBehaviour.m_ApplyMenu.SetActive(true);
			base.uiBehaviour.m_ResultMenu.SetActive(false);
			base.uiBehaviour.m_Close.SetVisible(true);
		}

		// Token: 0x060107BC RID: 67516 RVA: 0x004093C2 File Offset: 0x004075C2
		public void Hide()
		{
			this.SetVisible(false, true);
			this.DestroyFx(this.m_xfx);
		}

		// Token: 0x060107BD RID: 67517 RVA: 0x004093DC File Offset: 0x004075DC
		public void ShowResult(bool bCreate, string name)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			string text = bCreate ? XStringDefineProxy.GetString("CREATE") : XStringDefineProxy.GetString("JOIN");
			base.uiBehaviour.m_ResultNote.SetText(XStringDefineProxy.GetString("GUILD_APPLY_SUCCESS", new object[]
			{
				text,
				name
			}));
			base.uiBehaviour.m_ApplyMenu.SetActive(false);
			base.uiBehaviour.m_ResultMenu.SetActive(true);
			base.uiBehaviour.m_Close.SetVisible(false);
			this.DestroyFx(this.m_xfx);
			this.m_xfx = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_yh", null, true);
			this.m_xfx.Play(DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.m_FxFirework.transform, Vector3.zero, Vector3.one, 1f, true, false);
		}

		// Token: 0x060107BE RID: 67518 RVA: 0x004094D0 File Offset: 0x004076D0
		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

		// Token: 0x060107BF RID: 67519 RVA: 0x004094F8 File Offset: 0x004076F8
		private bool _OnApplyBtnClicked(IXUIButton btn)
		{
			this._doc.ReqApplyGuild(this.m_UID, this.m_Name);
			return true;
		}

		// Token: 0x060107C0 RID: 67520 RVA: 0x00409524 File Offset: 0x00407724
		private bool _OnEnterSceneBtnClicked(IXUIButton btn)
		{
			this.Hide();
			bool flag = DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildViewView, XGuildViewBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			}
			DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			XSingleton<XGameSysMgr>.singleton.OpenGuildSystem(XSysDefine.XSys_GuildHall);
			return true;
		}

		// Token: 0x060107C1 RID: 67521 RVA: 0x00409574 File Offset: 0x00407774
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.Hide();
			return true;
		}

		// Token: 0x04007721 RID: 30497
		private ulong m_UID;

		// Token: 0x04007722 RID: 30498
		private string m_Name;

		// Token: 0x04007723 RID: 30499
		private XGuildListDocument _doc;

		// Token: 0x04007724 RID: 30500
		private XFx m_xfx;
	}
}
