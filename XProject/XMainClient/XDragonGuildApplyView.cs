using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A47 RID: 2631
	internal class XDragonGuildApplyView : DlgBase<XDragonGuildApplyView, XDragonGuildApplyBehaviour>
	{
		// Token: 0x17002EE3 RID: 12003
		// (get) Token: 0x06009FC4 RID: 40900 RVA: 0x001A8324 File Offset: 0x001A6524
		public override string fileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopApplyDlg";
			}
		}

		// Token: 0x17002EE4 RID: 12004
		// (get) Token: 0x06009FC5 RID: 40901 RVA: 0x001A833C File Offset: 0x001A653C
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002EE5 RID: 12005
		// (get) Token: 0x06009FC6 RID: 40902 RVA: 0x001A8350 File Offset: 0x001A6550
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002EE6 RID: 12006
		// (get) Token: 0x06009FC7 RID: 40903 RVA: 0x001A8364 File Offset: 0x001A6564
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06009FC8 RID: 40904 RVA: 0x001A8377 File Offset: 0x001A6577
		protected override void Init()
		{
			this._doc = XDragonGuildListDocument.Doc;
		}

		// Token: 0x06009FC9 RID: 40905 RVA: 0x001A8388 File Offset: 0x001A6588
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnApply.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnApplyBtnClicked));
			base.uiBehaviour.m_BtnEnterGuild.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEnterSceneBtnClicked));
		}

		// Token: 0x06009FCA RID: 40906 RVA: 0x001A83F4 File Offset: 0x001A65F4
		public void ShowApply(ulong uid, string name, uint ppt, bool bNeedApprove)
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
			base.uiBehaviour.m_ApplyMenu.SetActive(true);
			base.uiBehaviour.m_ResultMenu.SetActive(false);
			base.uiBehaviour.m_Close.SetVisible(true);
		}

		// Token: 0x06009FCB RID: 40907 RVA: 0x001A849F File Offset: 0x001A669F
		public void Hide()
		{
			this.SetVisible(false, true);
			this.DestroyFx(this.m_xfx);
		}

		// Token: 0x06009FCC RID: 40908 RVA: 0x001A84B8 File Offset: 0x001A66B8
		public void ShowResult(bool bCreate, string name)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			string text = bCreate ? XStringDefineProxy.GetString("CREATE") : XStringDefineProxy.GetString("JOIN");
			base.uiBehaviour.m_ResultNote.SetText(XStringDefineProxy.GetString("DRAGON_GUILD_APPLY_SUCCESS", new object[]
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

		// Token: 0x06009FCD RID: 40909 RVA: 0x001A85AC File Offset: 0x001A67AC
		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

		// Token: 0x06009FCE RID: 40910 RVA: 0x001A85D4 File Offset: 0x001A67D4
		private bool _OnApplyBtnClicked(IXUIButton btn)
		{
			this._doc.ReqApplyDragonGuild(this.m_UID, this.m_Name);
			return true;
		}

		// Token: 0x06009FCF RID: 40911 RVA: 0x001A8600 File Offset: 0x001A6800
		private bool _OnEnterSceneBtnClicked(IXUIButton btn)
		{
			this.Hide();
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshDragonGuildPage();
			return true;
		}

		// Token: 0x06009FD0 RID: 40912 RVA: 0x001A8628 File Offset: 0x001A6828
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.Hide();
			return true;
		}

		// Token: 0x0400390B RID: 14603
		private ulong m_UID;

		// Token: 0x0400390C RID: 14604
		private string m_Name;

		// Token: 0x0400390D RID: 14605
		private XDragonGuildListDocument _doc;

		// Token: 0x0400390E RID: 14606
		private XFx m_xfx;
	}
}
