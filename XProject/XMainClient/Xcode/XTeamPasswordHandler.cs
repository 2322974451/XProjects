using System;
using KKSG;
using UILib;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamPasswordHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_BtnNeedPwd = (base.PanelObject.transform.Find("BtnNeedPwd").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_IptPwd = (base.PanelObject.transform.Find("Input").GetComponent("XUIInput") as IXUIInput);
			this.m_PwdTween = (base.PanelObject.transform.Find("BtnNeedPwd").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.optionsDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnNeedPwd.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnUsePasswordChanged));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		public void RefreshState()
		{
			bool bIsLeader = this.doc.bIsLeader;
			if (bIsLeader)
			{
				bool flag = base.IsVisible();
				if (flag)
				{
					this.RefreshData();
				}
				else
				{
					base.SetVisible(true);
				}
			}
			else
			{
				base.SetVisible(false);
			}
		}

		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = !this.doc.bInTeam;
			if (flag)
			{
				this.m_BtnNeedPwd.bChecked = false;
				this.m_PwdTween.ResetTweenByCurGroup(false);
				this.m_IptPwd.SetText(this.optionsDoc.GetStrValue(XOptionsDefine.OD_TEAM_PASSWORD));
			}
			else
			{
				bool flag2 = string.IsNullOrEmpty(this.doc.password);
				if (flag2)
				{
					base.SetVisible(false);
				}
				bool hasPwd = this.doc.MyTeam.teamBrief.hasPwd;
				this.m_BtnNeedPwd.bChecked = hasPwd;
				this.m_PwdTween.ResetTweenByCurGroup(hasPwd);
				this.m_IptPwd.SetText(this.doc.MyTeam.teamBrief.password);
			}
		}

		public string GetPassword()
		{
			return this.m_BtnNeedPwd.bChecked ? this.m_IptPwd.GetText() : string.Empty;
		}

		public string GetInputPassword()
		{
			return this.m_IptPwd.GetText();
		}

		private bool _OnUsePasswordChanged(IXUICheckBox ckb)
		{
			this.m_PwdTween.PlayTween(!ckb.bChecked, -1f);
			bool bIsLeader = this.doc.bIsLeader;
			if (bIsLeader)
			{
				bool bChecked = ckb.bChecked;
				if (bChecked)
				{
					bool flag = !this.doc.MyTeam.teamBrief.hasPwd;
					if (flag)
					{
						this.doc.ReqTeamOp(TeamOperate.TEAM_CHANGE_PASSWORD, 0UL, this.doc.password, TeamMemberType.TMT_NORMAL, null);
					}
				}
				else
				{
					bool hasPwd = this.doc.MyTeam.teamBrief.hasPwd;
					if (hasPwd)
					{
						this.doc.ReqTeamOp(TeamOperate.TEAM_CHANGE_PASSWORD, 0UL, string.Empty, TeamMemberType.TMT_NORMAL, null);
					}
				}
			}
			return true;
		}

		private void _OnInputSubmit(IXUIInput input)
		{
			bool bIsLeader = this.doc.bIsLeader;
			if (bIsLeader)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Change password to ", input.GetText(), null, null, null, null);
			}
		}

		public IXUICheckBox m_BtnNeedPwd;

		public IXUIInput m_IptPwd;

		public IXUITweenTool m_PwdTween;

		private XTeamDocument doc;

		private XOptionsDocument optionsDoc;
	}
}
