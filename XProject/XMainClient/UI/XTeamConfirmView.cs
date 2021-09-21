using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018C3 RID: 6339
	internal class XTeamConfirmView : DlgBase<XTeamConfirmView, XTeamConfirmBehaviour>
	{
		// Token: 0x17003A4B RID: 14923
		// (get) Token: 0x06010877 RID: 67703 RVA: 0x0040E850 File Offset: 0x0040CA50
		public override string fileName
		{
			get
			{
				return "Team/TeamConfirmDlg";
			}
		}

		// Token: 0x17003A4C RID: 14924
		// (get) Token: 0x06010878 RID: 67704 RVA: 0x0040E868 File Offset: 0x0040CA68
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A4D RID: 14925
		// (get) Token: 0x06010879 RID: 67705 RVA: 0x0040E87C File Offset: 0x0040CA7C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A4E RID: 14926
		// (get) Token: 0x0601087A RID: 67706 RVA: 0x0040E890 File Offset: 0x0040CA90
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A4F RID: 14927
		// (get) Token: 0x0601087B RID: 67707 RVA: 0x0040E8A4 File Offset: 0x0040CAA4
		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601087C RID: 67708 RVA: 0x0040E8B7 File Offset: 0x0040CAB7
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			this.INVITE_TIME = (float)XSingleton<XGlobalConfig>.singleton.GetInt("TeamInviteConfirmTime");
		}

		// Token: 0x0601087D RID: 67709 RVA: 0x0040E8E0 File Offset: 0x0040CAE0
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			base.uiBehaviour.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

		// Token: 0x0601087E RID: 67710 RVA: 0x0040E920 File Offset: 0x0040CB20
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_TargetTime > 0f;
			if (flag)
			{
				bool flag2 = this.m_CurrentTime >= this.m_TargetTime;
				if (flag2)
				{
					this.m_TargetTime = -1f;
					this._OnCancelBtnClick(null);
				}
				else
				{
					bool flag3 = this.m_CurrentTime < this.m_TargetTime;
					if (flag3)
					{
						this.m_CurrentTime += Time.deltaTime;
						base.uiBehaviour.m_Progress.value = this.m_CurrentTime / this.m_TargetTime;
					}
				}
			}
		}

		// Token: 0x0601087F RID: 67711 RVA: 0x0040E9B8 File Offset: 0x0040CBB8
		public void ClearInviteList()
		{
			bool flag = this.m_CurrentInviteData != null;
			if (flag)
			{
				this.m_CurrentInviteData.Recycle();
				this.m_CurrentInviteData = null;
			}
			bool flag2 = base.IsVisible();
			if (flag2)
			{
				this.SetVisibleWithAnimation(false, null);
			}
		}

		// Token: 0x06010880 RID: 67712 RVA: 0x0040E9FC File Offset: 0x0040CBFC
		public void InviteComing(XTeamInviteData data)
		{
			this.m_OKHandler = new ButtonClickEventHandler(this._OnInviteAgreeBtnClick);
			this.m_CancelHandler = new ButtonClickEventHandler(this._OnInviteRejectBtnClick);
			bool flag = this.m_CurrentInviteData != null;
			if (flag)
			{
				this.doc.ReqTeamInviteAck(false, this.m_CurrentInviteData.inviteID);
				this.m_CurrentInviteData.Recycle();
			}
			this.m_CurrentInviteData = data;
			this.NewInvite(true);
		}

		// Token: 0x06010881 RID: 67713 RVA: 0x0040EA74 File Offset: 0x0040CC74
		public void NewInvite(bool bResetTime)
		{
			bool flag = this.m_CurrentInviteData == null;
			if (!flag)
			{
				bool flag2 = !base.IsVisible();
				if (flag2)
				{
					this.SetVisibleWithAnimation(true, null);
				}
				bool flag3 = !base.IsLoaded();
				if (!flag3)
				{
					if (bResetTime)
					{
						this.m_TargetTime = this.INVITE_TIME;
						this.m_CurrentTime = 0f;
						base.uiBehaviour.m_Progress.value = 0f;
						base.uiBehaviour.m_Progress.ForceUpdate();
					}
					XTeamInviteData currentInviteData = this.m_CurrentInviteData;
					base.uiBehaviour.m_Content.SetText(XStringDefineProxy.GetString("TEAMCONFIRM_JOIN_CONTENT"));
					base.uiBehaviour.m_MemberText.SetText(XStringDefineProxy.GetString("TEAMCONFIRM_JOIN_MEMBERTEXT"));
					base.uiBehaviour.m_DungeonName.SetText(currentInviteData.briefData.dungeonName);
					base.uiBehaviour.m_PPT.SetText(currentInviteData.briefData.leaderPPT.ToString());
					base.uiBehaviour.m_MemberCount.SetText(string.Format("{0}/{1}", currentInviteData.briefData.currentMemberCount.ToString(), currentInviteData.briefData.totalMemberCount.ToString()));
					base.uiBehaviour.m_LeaderName.SetText(currentInviteData.briefData.leaderName);
					base.uiBehaviour.m_LeaderLevel.SetText(string.Format("Lv.{0}", currentInviteData.briefData.leaderLevel.ToString()));
				}
			}
		}

		// Token: 0x06010882 RID: 67714 RVA: 0x0040EC04 File Offset: 0x0040CE04
		private bool _OnOKBtnClick(IXUIButton go)
		{
			return this.m_OKHandler(go);
		}

		// Token: 0x06010883 RID: 67715 RVA: 0x0040EC24 File Offset: 0x0040CE24
		private bool _OnCancelBtnClick(IXUIButton go)
		{
			return this.m_CancelHandler(go);
		}

		// Token: 0x06010884 RID: 67716 RVA: 0x0040EC44 File Offset: 0x0040CE44
		private bool _OnInviteAgreeBtnClick(IXUIButton go)
		{
			bool flag = this.m_CurrentInviteData != null;
			if (flag)
			{
				this.doc.ReqTeamInviteAck(true, this.m_CurrentInviteData.inviteID);
			}
			this.ClearInviteList();
			return true;
		}

		// Token: 0x06010885 RID: 67717 RVA: 0x0040EC88 File Offset: 0x0040CE88
		private bool _OnInviteRejectBtnClick(IXUIButton go)
		{
			bool flag = this.m_CurrentInviteData != null;
			if (flag)
			{
				bool flag2 = go != null;
				if (flag2)
				{
					this.doc.ReqTeamInviteAck(false, this.m_CurrentInviteData.inviteID);
				}
			}
			this.ClearInviteList();
			return true;
		}

		// Token: 0x06010886 RID: 67718 RVA: 0x0040ECD1 File Offset: 0x0040CED1
		protected override void OnPopupBlocked()
		{
			this.ClearInviteList();
		}

		// Token: 0x040077AC RID: 30636
		private XTeamInviteDocument doc;

		// Token: 0x040077AD RID: 30637
		private ButtonClickEventHandler m_OKHandler;

		// Token: 0x040077AE RID: 30638
		private ButtonClickEventHandler m_CancelHandler;

		// Token: 0x040077AF RID: 30639
		private float INVITE_TIME = 5f;

		// Token: 0x040077B0 RID: 30640
		private float m_TargetTime;

		// Token: 0x040077B1 RID: 30641
		private float m_CurrentTime;

		// Token: 0x040077B2 RID: 30642
		private XTeamInviteData m_CurrentInviteData;
	}
}
