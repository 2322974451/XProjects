using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamConfirmView : DlgBase<XTeamConfirmView, XTeamConfirmBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/TeamConfirmDlg";
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

		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			this.INVITE_TIME = (float)XSingleton<XGlobalConfig>.singleton.GetInt("TeamInviteConfirmTime");
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			base.uiBehaviour.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

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

		private bool _OnOKBtnClick(IXUIButton go)
		{
			return this.m_OKHandler(go);
		}

		private bool _OnCancelBtnClick(IXUIButton go)
		{
			return this.m_CancelHandler(go);
		}

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

		protected override void OnPopupBlocked()
		{
			this.ClearInviteList();
		}

		private XTeamInviteDocument doc;

		private ButtonClickEventHandler m_OKHandler;

		private ButtonClickEventHandler m_CancelHandler;

		private float INVITE_TIME = 5f;

		private float m_TargetTime;

		private float m_CurrentTime;

		private XTeamInviteData m_CurrentInviteData;
	}
}
