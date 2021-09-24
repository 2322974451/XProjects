using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SpriteShopHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteShopHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this._maxColdDrawCount = XSingleton<XGlobalConfig>.singleton.GetInt("GoldDrawFreeDayCount");
			this.InitUI();
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryBuyEggCD();
			this.RefreshLotteryFrame();
		}

		private bool OnLotteryClicked(IXUIButton button)
		{
			this._doc.SendBuySpriteEggRpc((uint)button.ID);
			return true;
		}

		private void OnShowFinished(IXUITweenTool tween)
		{
			this.m_ResultFrame.gameObject.SetActive(false);
		}

		public void ShowResultFrame(List<ItemBrief> item)
		{
			this.m_ResultFrame.gameObject.SetActive(true);
			this.m_ResultTween.ResetTween(true);
			this.m_ResultTween.PlayTween(true, -1f);
			this.RefreshResultFrame(item);
		}

		public void RefreshLotteryFrame()
		{
			this.ShowNormalButton(this._doc.NormalCoolDown == 0U);
			this.ShowSpecialButton(this._doc.SpecialCoolDown == 0U);
		}

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

		private void ShowSpecialButton(bool free)
		{
			this.m_SpecialLotteryFree.SetVisible(free);
			this.m_SpecialLotteryOnce.SetVisible(!free);
			this.m_SpecialLotteryTen.SetVisible(!free);
			this._specialCD.SetLeftTime(this._doc.SpecialCoolDown, -1);
			this._specialCD.SetFormatString(XStringDefineProxy.GetString("SpriteLotteryNextFreeTime"));
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._normalCD.Update();
			this._specialCD.Update();
		}

		private XSpriteSystemDocument _doc = null;

		private IXUIButton m_NormalLotteryOnce;

		private IXUIButton m_NormalLotteryTen;

		private IXUIButton m_NormalLotteryFree;

		private IXUILabelSymbol m_NormalLotteryOncePrice;

		private IXUILabelSymbol m_NormalLotteryTenPrice;

		private IXUILabel m_NormalLotteryTip;

		private IXUIButton m_SpecialLotteryOnce;

		private IXUIButton m_SpecialLotteryTen;

		private IXUIButton m_SpecialLotteryFree;

		private IXUILabelSymbol m_SpecialLotteryOncePrice;

		private IXUILabelSymbol m_SpecialLotteryTenPrice;

		private IXUILabel m_SpecialLotteryTip;

		private Transform m_NormalLottery;

		private Transform m_SpecialLottery;

		private Transform m_ResultFrame;

		private IXUITweenTool m_ResultTween;

		private XUIPool m_ResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIList m_ResultList;

		private int _maxColdDrawCount;

		private XLeftTimeCounter _normalCD;

		private XLeftTimeCounter _specialCD;
	}
}
