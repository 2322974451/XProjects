using System;
using KKSG;
using UILib;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CA4 RID: 3236
	internal class XTeamPasswordHandler : DlgHandlerBase
	{
		// Token: 0x0600B640 RID: 46656 RVA: 0x00241BF8 File Offset: 0x0023FDF8
		protected override void Init()
		{
			base.Init();
			this.m_BtnNeedPwd = (base.PanelObject.transform.Find("BtnNeedPwd").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_IptPwd = (base.PanelObject.transform.Find("Input").GetComponent("XUIInput") as IXUIInput);
			this.m_PwdTween = (base.PanelObject.transform.Find("BtnNeedPwd").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.optionsDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
		}

		// Token: 0x0600B641 RID: 46657 RVA: 0x00241CAB File Offset: 0x0023FEAB
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnNeedPwd.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnUsePasswordChanged));
		}

		// Token: 0x0600B642 RID: 46658 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600B643 RID: 46659 RVA: 0x00241CD0 File Offset: 0x0023FED0
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

		// Token: 0x0600B644 RID: 46660 RVA: 0x00241D18 File Offset: 0x0023FF18
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

		// Token: 0x0600B645 RID: 46661 RVA: 0x00241DE8 File Offset: 0x0023FFE8
		public string GetPassword()
		{
			return this.m_BtnNeedPwd.bChecked ? this.m_IptPwd.GetText() : string.Empty;
		}

		// Token: 0x0600B646 RID: 46662 RVA: 0x00241E1C File Offset: 0x0024001C
		public string GetInputPassword()
		{
			return this.m_IptPwd.GetText();
		}

		// Token: 0x0600B647 RID: 46663 RVA: 0x00241E3C File Offset: 0x0024003C
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

		// Token: 0x0600B648 RID: 46664 RVA: 0x00241EF8 File Offset: 0x002400F8
		private void _OnInputSubmit(IXUIInput input)
		{
			bool bIsLeader = this.doc.bIsLeader;
			if (bIsLeader)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Change password to ", input.GetText(), null, null, null, null);
			}
		}

		// Token: 0x04004754 RID: 18260
		public IXUICheckBox m_BtnNeedPwd;

		// Token: 0x04004755 RID: 18261
		public IXUIInput m_IptPwd;

		// Token: 0x04004756 RID: 18262
		public IXUITweenTool m_PwdTween;

		// Token: 0x04004757 RID: 18263
		private XTeamDocument doc;

		// Token: 0x04004758 RID: 18264
		private XOptionsDocument optionsDoc;
	}
}
