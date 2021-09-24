using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWeddingCostView : DlgBase<XWeddingCostView, XWeddingCostBehavior>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Wedding/weddingCost";
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
			this.InitProperties();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
		}

		protected override void OnHide()
		{
		}

		private bool OnCloseClicked(IXUIButton iSp)
		{
			this.SetVisible(false, true);
			return true;
		}

		private void InitProperties()
		{
			base.uiBehaviour.Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.OkBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOkBtnClicked));
		}

		private bool OnOkBtnClicked(IXUIButton button)
		{
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_MarryApply, this._weddingType, 0UL);
			this.SetVisible(false, true);
			return true;
		}

		public void RefreshUI(WeddingType type)
		{
			this.SetVisible(true, true);
			this._weddingType = type;
			string text = (type == WeddingType.WeddingType_Normal) ? XStringDefineProxy.GetString("Wedding_Npc_NormalWedding") : XStringDefineProxy.GetString("Wedding_Npc_BetterWedding");
			base.uiBehaviour.TitleLabel.SetText(text);
			string text2 = (type == WeddingType.WeddingType_Normal) ? XStringDefineProxy.GetString("weddingNormalWeddingWelfare") : XStringDefineProxy.GetString("weddingBetterWeddingWelfare");
			base.uiBehaviour.SecondTitle.SetText(text2);
			string text3 = (type == WeddingType.WeddingType_Normal) ? XStringDefineProxy.GetString("WeddingNormlWelfareTip") : XStringDefineProxy.GetString("WeddingBetterWelfareTip");
			text3 = XSingleton<UiUtility>.singleton.ReplaceReturn(text3);
			base.uiBehaviour.TipLabel.SetText(text3);
			string key = (type == WeddingType.WeddingType_Normal) ? "MarriageCost" : "MarriageSplendidCost";
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList(key, true);
			int num = sequenceList[0, 0];
			int num2 = sequenceList[0, 1];
			string text4 = XSingleton<XStringTable>.singleton.GetString("NeedCost") + XBagDocument.GetItemConf(num).ItemName[0];
			base.uiBehaviour.CostTip.SetText(text4);
			base.uiBehaviour.NumLabel.SetText("X" + num2);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.DrawItem, num, num2, false);
			IXUISprite ixuisprite = base.uiBehaviour.DrawItem.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)num);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
		}

		public bool RefreshItems(IXUICheckBox go)
		{
			return true;
		}

		private WeddingType _weddingType;
	}
}
