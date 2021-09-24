using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamBattleQuickConfirmView : DlgBase<XTeamBattleQuickConfirmView, XTeamBattleQuickConfirmBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/BattleQuickBeginConfirmDlg";
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
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.FIGHT_VOTE_TIME = (float)XSingleton<XGlobalConfig>.singleton.GetInt("TeamFastMatchConfirmT");
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_fLeftTime = this.FIGHT_VOTE_TIME;
			this.m_nLeftTime = (int)this.FIGHT_VOTE_TIME;
			base.uiBehaviour.m_Time.SetText(this.m_nLeftTime.ToString());
			base.uiBehaviour.m_Cancel.SetVisible(true);
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_fLeftTime > 0f;
			if (flag)
			{
				this.m_fLeftTime -= Time.deltaTime;
				int num = Mathf.CeilToInt(this.m_fLeftTime);
				bool flag2 = this.m_nLeftTime != num;
				if (flag2)
				{
					this.m_nLeftTime = num;
					base.uiBehaviour.m_Time.SetText(this.m_nLeftTime.ToString());
				}
			}
			else
			{
				base.uiBehaviour.m_Cancel.SetVisible(false);
				this.SetVisibleWithAnimation(false, null);
			}
		}

		private bool _OnCancelBtnClick(IXUIButton go)
		{
			PtcC2M_FMBRefuseC2M ptcC2M_FMBRefuseC2M = new PtcC2M_FMBRefuseC2M();
			ptcC2M_FMBRefuseC2M.Data.refuse = true;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FMBRefuseC2M);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		protected override void OnPopupBlocked()
		{
			PtcC2M_FMBRefuseC2M ptcC2M_FMBRefuseC2M = new PtcC2M_FMBRefuseC2M();
			ptcC2M_FMBRefuseC2M.Data.refuse = true;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FMBRefuseC2M);
		}

		private XTeamDocument doc;

		private float FIGHT_VOTE_TIME = 3f;

		private float m_fLeftTime;

		private int m_nLeftTime;
	}
}
