using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonGuildApplyView : DlgBase<XDragonGuildApplyView, XDragonGuildApplyBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopApplyDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDragonGuildListDocument.Doc;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnApply.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnApplyBtnClicked));
			base.uiBehaviour.m_BtnEnterGuild.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEnterSceneBtnClicked));
		}

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

		public void Hide()
		{
			this.SetVisible(false, true);
			this.DestroyFx(this.m_xfx);
		}

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

		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

		private bool _OnApplyBtnClicked(IXUIButton btn)
		{
			this._doc.ReqApplyDragonGuild(this.m_UID, this.m_Name);
			return true;
		}

		private bool _OnEnterSceneBtnClicked(IXUIButton btn)
		{
			this.Hide();
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshDragonGuildPage();
			return true;
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.Hide();
			return true;
		}

		private ulong m_UID;

		private string m_Name;

		private XDragonGuildListDocument _doc;

		private XFx m_xfx;
	}
}
