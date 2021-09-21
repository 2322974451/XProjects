using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018CB RID: 6347
	internal class XBuyCountView : DlgBase<XBuyCountView, XBuyCountBehaviour>
	{
		// Token: 0x17003A5C RID: 14940
		// (get) Token: 0x060108C2 RID: 67778 RVA: 0x00411110 File Offset: 0x0040F310
		public override string fileName
		{
			get
			{
				return "Common/BuyCountDlg";
			}
		}

		// Token: 0x17003A5D RID: 14941
		// (get) Token: 0x060108C3 RID: 67779 RVA: 0x00411128 File Offset: 0x0040F328
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x17003A5E RID: 14942
		// (get) Token: 0x060108C4 RID: 67780 RVA: 0x0041113C File Offset: 0x0040F33C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060108C5 RID: 67781 RVA: 0x0041114F File Offset: 0x0040F34F
		protected override void Init()
		{
			this.m_ExpDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
		}

		// Token: 0x060108C6 RID: 67782 RVA: 0x00411162 File Offset: 0x0040F362
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._DoCancel));
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._DoOK));
		}

		// Token: 0x060108C7 RID: 67783 RVA: 0x0041119F File Offset: 0x0040F39F
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x060108C8 RID: 67784 RVA: 0x004111A9 File Offset: 0x0040F3A9
		public void ActiveShow(TeamLevelType dungeonType)
		{
			this._ShowBuyCountAndBuyConfirm("ACTIVE_BUYCOUNT_CONFIRM", dungeonType);
		}

		// Token: 0x060108C9 RID: 67785 RVA: 0x004111B9 File Offset: 0x0040F3B9
		public void PassiveShow(TeamLevelType dungeonType)
		{
			this._ShowBuyCountAndBuyConfirm("PASSIVE_BUYCOUNT_CONFIRM", dungeonType);
		}

		// Token: 0x060108CA RID: 67786 RVA: 0x004111CC File Offset: 0x0040F3CC
		private void _ShowBuyCountAndBuyConfirm(string reason, TeamLevelType dungeonType)
		{
			base.Load();
			int num;
			int num2;
			bool flag = this.m_ExpDoc.CanBuy(dungeonType, out num, out num2);
			if (flag)
			{
				CostInfo buyCost = this.m_ExpDoc.GetBuyCost(dungeonType);
				base.uiBehaviour.m_ContentLabelSymbol.InputText = XStringDefineProxy.GetString(reason, new object[]
				{
					XLabelSymbolHelper.FormatCostWithIcon((int)buyCost.count, buyCost.type),
					XStringDefineProxy.GetString(dungeonType.ToString())
				});
				base.uiBehaviour.m_LeftBuyCount.SetText((num2 - num).ToString());
				this.m_Type = dungeonType;
				this.SetVisibleWithAnimation(true, null);
			}
			else
			{
				bool flag2 = this.m_ExpDoc.GetBuyLimit(dungeonType) > 0;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAMBUY_COUNT_MAX, "fece00");
				}
			}
		}

		// Token: 0x060108CB RID: 67787 RVA: 0x004112A8 File Offset: 0x0040F4A8
		private bool _DoOK(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			this.m_ExpDoc.ReqBuyCount(this.m_Type);
			return true;
		}

		// Token: 0x060108CC RID: 67788 RVA: 0x004112D8 File Offset: 0x0040F4D8
		private bool _DoCancel(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x040077DD RID: 30685
		private TeamLevelType m_Type;

		// Token: 0x040077DE RID: 30686
		private XExpeditionDocument m_ExpDoc;
	}
}
