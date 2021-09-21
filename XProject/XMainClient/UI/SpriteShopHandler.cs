using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017FA RID: 6138
	internal class SpriteShopHandler : DlgHandlerBase
	{
		// Token: 0x170038E8 RID: 14568
		// (get) Token: 0x0600FE9E RID: 65182 RVA: 0x003BE26C File Offset: 0x003BC46C
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteShopHandler";
			}
		}

		// Token: 0x0600FE9F RID: 65183 RVA: 0x003BE283 File Offset: 0x003BC483
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this._maxColdDrawCount = XSingleton<XGlobalConfig>.singleton.GetInt("GoldDrawFreeDayCount");
			this.InitUI();
		}

		// Token: 0x0600FEA0 RID: 65184 RVA: 0x003BE2BC File Offset: 0x003BC4BC
		private void InitUI()
		{
			this.m_NormalLotteryOnce = (base.PanelObject.transform.Find("Bg/NormalLottery/Button/Once").GetComponent("XUIButton") as IXUIButton);
			this.m_NormalLotteryTen = (base.PanelObject.transform.Find("Bg/NormalLottery/Button/Ten").GetComponent("XUIButton") as IXUIButton);
			this.m_NormalLotteryFree = (base.PanelObject.transform.Find("Bg/NormalLottery/Button/Free").GetComponent("XUIButton") as IXUIButton);
			this.m_NormalLotteryOncePrice = (base.PanelObject.transform.Find("Bg/NormalLottery/Button/Once/Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_NormalLotteryTenPrice = (base.PanelObject.transform.Find("Bg/NormalLottery/Button/Ten/Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_NormalLotteryTip = (base.PanelObject.transform.Find("Bg/NormalLottery/Button/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_SpecialLotteryOnce = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Once").GetComponent("XUIButton") as IXUIButton);
			this.m_SpecialLotteryTen = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Ten").GetComponent("XUIButton") as IXUIButton);
			this.m_SpecialLotteryFree = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Free").GetComponent("XUIButton") as IXUIButton);
			this.m_SpecialLotteryOncePrice = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Once/Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SpecialLotteryTenPrice = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Ten/Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SpecialLotteryTip = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_NormalLotteryFree.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_GoldDraw_One_Free));
			this.m_NormalLotteryOnce.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_GoldDraw_One));
			this.m_NormalLotteryTen.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_GoldDraw_Ten));
			this.m_SpecialLotteryFree.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_Draw_One_Free));
			this.m_SpecialLotteryOnce.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_Draw_One));
			this.m_SpecialLotteryTen.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_Draw_Ten));
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteShopGoldOneCost").Split(XGlobalConfig.SequenceSeparator);
			string[] array2 = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteShopGoldTenCost").Split(XGlobalConfig.SequenceSeparator);
			string[] array3 = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteShopOneCost").Split(XGlobalConfig.SequenceSeparator);
			string[] array4 = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteShopTenCost").Split(XGlobalConfig.SequenceSeparator);
			bool flag = array.Length == 2 && array2.Length == 2;
			if (flag)
			{
				this.m_NormalLotteryOncePrice.InputText = XLabelSymbolHelper.FormatCostWithIcon(int.Parse(array[1]), (ItemEnum)int.Parse(array[0]));
				this.m_NormalLotteryTenPrice.InputText = XLabelSymbolHelper.FormatCostWithIcon(int.Parse(array2[1]), (ItemEnum)int.Parse(array2[0]));
			}
			bool flag2 = array3.Length == 2 && array4.Length == 2;
			if (flag2)
			{
				this.m_SpecialLotteryOncePrice.InputText = XLabelSymbolHelper.FormatCostWithIcon(int.Parse(array3[1]), (ItemEnum)int.Parse(array3[0]));
				this.m_SpecialLotteryTenPrice.InputText = XLabelSymbolHelper.FormatCostWithIcon(int.Parse(array4[1]), (ItemEnum)int.Parse(array4[0]));
			}
			this._normalCD = new XLeftTimeCounter(this.m_NormalLotteryTip, true);
			this._specialCD = new XLeftTimeCounter(this.m_SpecialLotteryTip, true);
			this.m_NormalLottery = base.PanelObject.transform.Find("Bg/NormalLottery");
			this.m_SpecialLottery = base.PanelObject.transform.Find("Bg/SpecialLottery");
			this.m_ResultFrame = base.PanelObject.transform.Find("Bg/ResultFrame");
			this.m_ResultFrame.gameObject.SetActive(false);
			this.m_ResultTween = (base.PanelObject.transform.Find("Bg/ResultFrame/Result").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_ResultList = (base.PanelObject.transform.Find("Bg/ResultFrame/Result/Grid").GetComponent("XUIList") as IXUIList);
			Transform transform = base.PanelObject.transform.Find("Bg/ResultFrame/Result/Grid/ResultTpl");
			this.m_ResultPool.SetupPool(transform.parent.gameObject, transform.gameObject, 1U, false);
		}

		// Token: 0x0600FEA1 RID: 65185 RVA: 0x003BE764 File Offset: 0x003BC964
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_NormalLotteryOnce.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_NormalLotteryTen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_NormalLotteryFree.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_SpecialLotteryOnce.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_SpecialLotteryTen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_SpecialLotteryFree.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_ResultTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnShowFinished));
		}

		// Token: 0x0600FEA2 RID: 65186 RVA: 0x003BE821 File Offset: 0x003BCA21
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryBuyEggCD();
			this.RefreshLotteryFrame();
		}

		// Token: 0x0600FEA3 RID: 65187 RVA: 0x003BE840 File Offset: 0x003BCA40
		private bool OnLotteryClicked(IXUIButton button)
		{
			this._doc.SendBuySpriteEggRpc((uint)button.ID);
			return true;
		}

		// Token: 0x0600FEA4 RID: 65188 RVA: 0x003BE866 File Offset: 0x003BCA66
		private void OnShowFinished(IXUITweenTool tween)
		{
			this.m_ResultFrame.gameObject.SetActive(false);
		}

		// Token: 0x0600FEA5 RID: 65189 RVA: 0x003BE87B File Offset: 0x003BCA7B
		public void ShowResultFrame(List<ItemBrief> item)
		{
			this.m_ResultFrame.gameObject.SetActive(true);
			this.m_ResultTween.ResetTween(true);
			this.m_ResultTween.PlayTween(true, -1f);
			this.RefreshResultFrame(item);
		}

		// Token: 0x0600FEA6 RID: 65190 RVA: 0x003BE8B7 File Offset: 0x003BCAB7
		public void RefreshLotteryFrame()
		{
			this.ShowNormalButton(this._doc.NormalCoolDown == 0U);
			this.ShowSpecialButton(this._doc.SpecialCoolDown == 0U);
		}

		// Token: 0x0600FEA7 RID: 65191 RVA: 0x003BE8E4 File Offset: 0x003BCAE4
		private void RefreshResultFrame(List<ItemBrief> gift)
		{
			this.m_ResultPool.ReturnAll(false);
			for (int i = 0; i < gift.Count; i++)
			{
				GameObject gameObject = this.m_ResultPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_ResultList.gameObject.transform;
				GameObject gameObject2 = gameObject.transform.Find("ItemTpl").gameObject;
				IXUILabel ixuilabel = gameObject.transform.Find("ItemTpl/Name").GetComponent("XUILabel") as IXUILabel;
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)gift[i].itemID);
				bool flag = itemConf != null;
				if (flag)
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U));
				}
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)gift[i].itemID, (int)gift[i].itemCount, false);
			}
			this.m_ResultList.Refresh();
		}

		// Token: 0x0600FEA8 RID: 65192 RVA: 0x003BE9EC File Offset: 0x003BCBEC
		private void ShowNormalButton(bool free)
		{
			this.m_NormalLotteryFree.SetVisible(free);
			this.m_NormalLotteryOnce.SetVisible(!free);
			this.m_NormalLotteryTen.SetVisible(!free);
			this._normalCD.SetLeftTime(this._doc.NormalCoolDown, -1);
			bool flag = this._doc.NormalFreeCount == this._doc.NormalMaxCount;
			if (flag)
			{
				this._normalCD.SetFormatString(string.Format("{0}({1}/{2})", XStringDefineProxy.GetString("FREE_COUNT_RUNOUT"), this._doc.NormalMaxCount - this._doc.NormalFreeCount, this._doc.NormalMaxCount));
			}
			else
			{
				this._normalCD.SetFormatString(string.Format("{0}({1}/{2})", XStringDefineProxy.GetString("SpriteLotteryNextFreeTime"), this._doc.NormalMaxCount - this._doc.NormalFreeCount, this._doc.NormalMaxCount));
			}
		}

		// Token: 0x0600FEA9 RID: 65193 RVA: 0x003BEAFC File Offset: 0x003BCCFC
		private void ShowSpecialButton(bool free)
		{
			this.m_SpecialLotteryFree.SetVisible(free);
			this.m_SpecialLotteryOnce.SetVisible(!free);
			this.m_SpecialLotteryTen.SetVisible(!free);
			this._specialCD.SetLeftTime(this._doc.SpecialCoolDown, -1);
			this._specialCD.SetFormatString(XStringDefineProxy.GetString("SpriteLotteryNextFreeTime"));
		}

		// Token: 0x0600FEAA RID: 65194 RVA: 0x003BEB67 File Offset: 0x003BCD67
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._normalCD.Update();
			this._specialCD.Update();
		}

		// Token: 0x0400706F RID: 28783
		private XSpriteSystemDocument _doc = null;

		// Token: 0x04007070 RID: 28784
		private IXUIButton m_NormalLotteryOnce;

		// Token: 0x04007071 RID: 28785
		private IXUIButton m_NormalLotteryTen;

		// Token: 0x04007072 RID: 28786
		private IXUIButton m_NormalLotteryFree;

		// Token: 0x04007073 RID: 28787
		private IXUILabelSymbol m_NormalLotteryOncePrice;

		// Token: 0x04007074 RID: 28788
		private IXUILabelSymbol m_NormalLotteryTenPrice;

		// Token: 0x04007075 RID: 28789
		private IXUILabel m_NormalLotteryTip;

		// Token: 0x04007076 RID: 28790
		private IXUIButton m_SpecialLotteryOnce;

		// Token: 0x04007077 RID: 28791
		private IXUIButton m_SpecialLotteryTen;

		// Token: 0x04007078 RID: 28792
		private IXUIButton m_SpecialLotteryFree;

		// Token: 0x04007079 RID: 28793
		private IXUILabelSymbol m_SpecialLotteryOncePrice;

		// Token: 0x0400707A RID: 28794
		private IXUILabelSymbol m_SpecialLotteryTenPrice;

		// Token: 0x0400707B RID: 28795
		private IXUILabel m_SpecialLotteryTip;

		// Token: 0x0400707C RID: 28796
		private Transform m_NormalLottery;

		// Token: 0x0400707D RID: 28797
		private Transform m_SpecialLottery;

		// Token: 0x0400707E RID: 28798
		private Transform m_ResultFrame;

		// Token: 0x0400707F RID: 28799
		private IXUITweenTool m_ResultTween;

		// Token: 0x04007080 RID: 28800
		private XUIPool m_ResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007081 RID: 28801
		private IXUIList m_ResultList;

		// Token: 0x04007082 RID: 28802
		private int _maxColdDrawCount;

		// Token: 0x04007083 RID: 28803
		private XLeftTimeCounter _normalCD;

		// Token: 0x04007084 RID: 28804
		private XLeftTimeCounter _specialCD;
	}
}
