using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XBuyCountView : DlgBase<XBuyCountView, XBuyCountBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/BuyCountDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
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
			this.m_ExpDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._DoCancel));
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._DoOK));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public void ActiveShow(TeamLevelType dungeonType)
		{
			this._ShowBuyCountAndBuyConfirm("ACTIVE_BUYCOUNT_CONFIRM", dungeonType);
		}

		public void PassiveShow(TeamLevelType dungeonType)
		{
			this._ShowBuyCountAndBuyConfirm("PASSIVE_BUYCOUNT_CONFIRM", dungeonType);
		}

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

		private bool _DoOK(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			this.m_ExpDoc.ReqBuyCount(this.m_Type);
			return true;
		}

		private bool _DoCancel(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private TeamLevelType m_Type;

		private XExpeditionDocument m_ExpDoc;
	}
}
