using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001864 RID: 6244
	internal class XTeamBattleQuickConfirmView : DlgBase<XTeamBattleQuickConfirmView, XTeamBattleQuickConfirmBehaviour>
	{
		// Token: 0x17003995 RID: 14741
		// (get) Token: 0x06010414 RID: 66580 RVA: 0x003EE65C File Offset: 0x003EC85C
		public override string fileName
		{
			get
			{
				return "Team/BattleQuickBeginConfirmDlg";
			}
		}

		// Token: 0x17003996 RID: 14742
		// (get) Token: 0x06010415 RID: 66581 RVA: 0x003EE674 File Offset: 0x003EC874
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003997 RID: 14743
		// (get) Token: 0x06010416 RID: 66582 RVA: 0x003EE688 File Offset: 0x003EC888
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003998 RID: 14744
		// (get) Token: 0x06010417 RID: 66583 RVA: 0x003EE69C File Offset: 0x003EC89C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003999 RID: 14745
		// (get) Token: 0x06010418 RID: 66584 RVA: 0x003EE6B0 File Offset: 0x003EC8B0
		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010419 RID: 66585 RVA: 0x003EE6C3 File Offset: 0x003EC8C3
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.FIGHT_VOTE_TIME = (float)XSingleton<XGlobalConfig>.singleton.GetInt("TeamFastMatchConfirmT");
		}

		// Token: 0x0601041A RID: 66586 RVA: 0x003EE6EC File Offset: 0x003EC8EC
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

		// Token: 0x0601041B RID: 66587 RVA: 0x003EE70C File Offset: 0x003EC90C
		protected override void OnShow()
		{
			base.OnShow();
			this.m_fLeftTime = this.FIGHT_VOTE_TIME;
			this.m_nLeftTime = (int)this.FIGHT_VOTE_TIME;
			base.uiBehaviour.m_Time.SetText(this.m_nLeftTime.ToString());
			base.uiBehaviour.m_Cancel.SetVisible(true);
		}

		// Token: 0x0601041C RID: 66588 RVA: 0x003EE768 File Offset: 0x003EC968
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

		// Token: 0x0601041D RID: 66589 RVA: 0x003EE804 File Offset: 0x003ECA04
		private bool _OnCancelBtnClick(IXUIButton go)
		{
			PtcC2M_FMBRefuseC2M ptcC2M_FMBRefuseC2M = new PtcC2M_FMBRefuseC2M();
			ptcC2M_FMBRefuseC2M.Data.refuse = true;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FMBRefuseC2M);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0601041E RID: 66590 RVA: 0x003EE840 File Offset: 0x003ECA40
		protected override void OnPopupBlocked()
		{
			PtcC2M_FMBRefuseC2M ptcC2M_FMBRefuseC2M = new PtcC2M_FMBRefuseC2M();
			ptcC2M_FMBRefuseC2M.Data.refuse = true;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FMBRefuseC2M);
		}

		// Token: 0x040074DB RID: 29915
		private XTeamDocument doc;

		// Token: 0x040074DC RID: 29916
		private float FIGHT_VOTE_TIME = 3f;

		// Token: 0x040074DD RID: 29917
		private float m_fLeftTime;

		// Token: 0x040074DE RID: 29918
		private int m_nLeftTime;
	}
}
