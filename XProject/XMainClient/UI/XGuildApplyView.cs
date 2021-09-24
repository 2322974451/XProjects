using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildApplyView : DlgBase<XGuildApplyView, XGuildApplyBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildApplyDlg";
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
			this._doc = XDocuments.GetSpecificDocument<XGuildListDocument>(XGuildListDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnApply.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnApplyBtnClicked));
			base.uiBehaviour.m_BtnEnterGuild.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEnterSceneBtnClicked));
		}

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
			this._doc.ReqApplyGuild(this.m_UID, this.m_Name);
			return true;
		}

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

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.Hide();
			return true;
		}

		private ulong m_UID;

		private string m_Name;

		private XGuildListDocument _doc;

		private XFx m_xfx;
	}
}
