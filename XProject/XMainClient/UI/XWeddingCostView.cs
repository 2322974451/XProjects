using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018DD RID: 6365
	internal class XWeddingCostView : DlgBase<XWeddingCostView, XWeddingCostBehavior>
	{
		// Token: 0x17003A70 RID: 14960
		// (get) Token: 0x06010960 RID: 67936 RVA: 0x00416908 File Offset: 0x00414B08
		public override string fileName
		{
			get
			{
				return "GameSystem/Wedding/weddingCost";
			}
		}

		// Token: 0x17003A71 RID: 14961
		// (get) Token: 0x06010961 RID: 67937 RVA: 0x00416920 File Offset: 0x00414B20
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A72 RID: 14962
		// (get) Token: 0x06010962 RID: 67938 RVA: 0x00416934 File Offset: 0x00414B34
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A73 RID: 14963
		// (get) Token: 0x06010963 RID: 67939 RVA: 0x00416948 File Offset: 0x00414B48
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010964 RID: 67940 RVA: 0x0041695B File Offset: 0x00414B5B
		protected override void Init()
		{
			this.InitProperties();
		}

		// Token: 0x06010965 RID: 67941 RVA: 0x00416965 File Offset: 0x00414B65
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06010966 RID: 67942 RVA: 0x0041696F File Offset: 0x00414B6F
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06010967 RID: 67943 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnShow()
		{
		}

		// Token: 0x06010968 RID: 67944 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnHide()
		{
		}

		// Token: 0x06010969 RID: 67945 RVA: 0x0041697C File Offset: 0x00414B7C
		private bool OnCloseClicked(IXUIButton iSp)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601096A RID: 67946 RVA: 0x00416998 File Offset: 0x00414B98
		private void InitProperties()
		{
			base.uiBehaviour.Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.OkBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOkBtnClicked));
		}

		// Token: 0x0601096B RID: 67947 RVA: 0x00416A00 File Offset: 0x00414C00
		private bool OnOkBtnClicked(IXUIButton button)
		{
			XWeddingDocument.Doc.SendMarriageOp(MarriageOpType.MarriageOpType_MarryApply, this._weddingType, 0UL);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601096C RID: 67948 RVA: 0x00416A30 File Offset: 0x00414C30
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

		// Token: 0x0601096D RID: 67949 RVA: 0x00416BE0 File Offset: 0x00414DE0
		public bool RefreshItems(IXUICheckBox go)
		{
			return true;
		}

		// Token: 0x0400786C RID: 30828
		private WeddingType _weddingType;
	}
}
