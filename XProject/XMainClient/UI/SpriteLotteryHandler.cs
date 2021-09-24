using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SpriteLotteryHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteLotteryHandler";
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
			this.m_NormalLotteryOncePrice = (base.PanelObject.transform.Find("Bg/NormalLottery/Button/Once/Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_NormalLotteryTenPrice = (base.PanelObject.transform.Find("Bg/NormalLottery/Button/Ten/Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_NormalLotteryDrop = (base.PanelObject.transform.Find("Bg/NormalLottery/Detail/Drop").GetComponent("XUIButton") as IXUIButton);
			this.m_SpecialLotteryOnce = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Once").GetComponent("XUIButton") as IXUIButton);
			this.m_SpecialLotteryTen = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Ten").GetComponent("XUIButton") as IXUIButton);
			this.m_SpecialLotteryOncePrice = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Once/Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SpecialLotteryTenPrice = (base.PanelObject.transform.Find("Bg/SpecialLottery/Button/Ten/Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SpecialLotteryDrop = (base.PanelObject.transform.Find("Bg/SpecialLottery/Detail/Drop").GetComponent("XUIButton") as IXUIButton);
			this.m_NormalLotteryOnce.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_GoldDraw_One));
			this.m_NormalLotteryTen.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_GoldDraw_Ten));
			this.m_SpecialLotteryOnce.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_Draw_One));
			this.m_SpecialLotteryTen.ID = (ulong)((long)XFastEnumIntEqualityComparer<LotteryType>.ToInt(LotteryType.Sprite_Draw_Ten));
			this.m_SafeCountTip = (base.PanelObject.transform.Find("Bg/SpecialLottery/Tip").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteGoldDrawCost").Split(XGlobalConfig.SequenceSeparator);
			string[] array2 = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteGoldTenDrawCost").Split(XGlobalConfig.SequenceSeparator);
			string[] array3 = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteDrawCost").Split(XGlobalConfig.SequenceSeparator);
			string[] array4 = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteTenDrawCost").Split(XGlobalConfig.SequenceSeparator);
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
			this.m_NormalLottery = base.PanelObject.transform.Find("Bg/NormalLottery");
			this.m_SpecialLottery = base.PanelObject.transform.Find("Bg/SpecialLottery");
			this.m_ResultFrame = base.PanelObject.transform.Find("Bg/ResultFrame");
			this.m_LotteryOnePos = base.PanelObject.transform.Find("Bg/ResultFrame/OnePos").localPosition;
			this.m_LotteryTenPos = base.PanelObject.transform.Find("Bg/ResultFrame/TenPos").localPosition;
			Transform transform = base.PanelObject.transform.Find("Bg/ResultFrame/ResultTpl");
			this.m_ResultPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_OkButton = (base.PanelObject.transform.Find("Bg/ResultFrame/OkButton").GetComponent("XUIButton") as IXUIButton);
			this.m_Block = base.PanelObject.transform.Find("Bg/ResultFrame/Block").gameObject;
			this.m_OkButtonTween = (base.PanelObject.transform.Find("Bg/ResultFrame/OkButton").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_NormalLotteryOnce.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_NormalLotteryTen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_NormalLotteryDrop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnNormalLotteryDropClicked));
			this.m_SpecialLotteryOnce.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_SpecialLotteryTen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLotteryClicked));
			this.m_SpecialLotteryDrop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSpecialLotteryDropClicked));
			this.m_OkButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOkButtonClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryBuyEggCD();
			this.ShowLotteryFrame();
		}

		protected override void OnHide()
		{
			this.ClearAllFx();
			this.m_ResultList.Clear();
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.ClearAllFx();
			base.OnUnload();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshSpriteFx();
		}

		private bool OnLotteryClicked(IXUIButton button)
		{
			this._doc.SendLotteryRpc((uint)button.ID);
			return true;
		}

		private bool OnNormalLotteryDropClicked(IXUIButton button)
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.OpenWindows(SpriteWindow.Illustration);
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._IllustrationHandler.ShowSpriteEggIllustration(SpriteEggLotteryType.Normal);
			return true;
		}

		private bool OnSpecialLotteryDropClicked(IXUIButton button)
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.OpenWindows(SpriteWindow.Illustration);
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._IllustrationHandler.ShowSpriteEggIllustration(SpriteEggLotteryType.Special);
			return true;
		}

		public void RefreshSafeCountUI()
		{
			this.m_SafeCountTip.InputText = XStringDefineProxy.GetString("SpriteLotterySafeTip", new object[]
			{
				this._doc.SpecialSafeCount
			});
		}

		public bool OnOkButtonClicked(IXUIButton button)
		{
			bool flag = false;
			for (int i = 0; i < this._doc.ResultShowList.Count; i++)
			{
				flag |= this._doc.ResultShowList[i];
			}
			bool flag2 = !flag;
			if (flag2)
			{
				bool flag3 = button != null;
				if (flag3)
				{
					this.ShowLotteryFrame();
				}
				else
				{
					DlgBase<XSpriteShowView, XSpriteShowBehaviour>.singleton.SetVisible(false, true);
				}
			}
			else
			{
				this._doc.AutoShowEpicSprite = true;
				for (int j = 0; j < this.m_ResultList.Count; j++)
				{
					IXUISprite ixuisprite = this.m_ResultList[j].transform.Find("SpecialResult").GetComponent("XUISprite") as IXUISprite;
					bool flag4 = this._doc.ResultShowList[(int)ixuisprite.ID];
					if (flag4)
					{
						this.OnEpicItemClicked(ixuisprite);
						break;
					}
				}
			}
			return true;
		}

		private void ShowLotteryFrame()
		{
			this.m_NormalLottery.gameObject.SetActive(true);
			this.m_SpecialLottery.gameObject.SetActive(true);
			this.m_ResultFrame.gameObject.SetActive(false);
			this.ClearAllFx();
		}

		public void ShowResultFrame()
		{
			this.m_NormalLottery.gameObject.SetActive(false);
			this.m_SpecialLottery.gameObject.SetActive(false);
			this.m_ResultFrame.gameObject.SetActive(true);
			this.RefreshResultFrame();
		}

		private void RefreshResultFrame()
		{
			this._doc.AutoShowEpicSprite = false;
			this.m_Block.SetActive(true);
			this.m_ResultPool.ReturnAll(false);
			this.m_ResultList.Clear();
			for (int i = 0; i < this._doc.CachedLotteryResult.Count; i++)
			{
				XSingleton<XTimerMgr>.singleton.SetTimer((float)i * 0.3f, new XTimerMgr.ElapsedEventHandler(this.SetupItem), i);
			}
			this.m_OkButton.SetAlpha(0f);
			XSingleton<XTimerMgr>.singleton.SetTimer((float)this._doc.CachedLotteryResult.Count * 0.3f + 0.3f, new XTimerMgr.ElapsedEventHandler(this.ShowOkButton), null);
		}

		private void ShowOkButton(object o)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_Block.SetActive(false);
				this.m_OkButtonTween.ResetTween(true);
				this.m_OkButtonTween.PlayTween(true, -1f);
			}
		}

		private void ClearAllFx()
		{
			for (int i = 0; i < this.m_FxList.Count; i++)
			{
				this._doc.DestroyFx(this.m_FxList[i]);
			}
			this.m_FxList.Clear();
		}

		private void SetupItem(object o)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				int num = (int)o;
				Vector3 vector = (this._doc.CachedLotteryResult.Count == 1) ? this.m_LotteryOnePos : this.m_LotteryTenPos;
				GameObject gameObject = this.m_ResultPool.FetchGameObject(false);
				this.m_ResultList.Add(gameObject);
				IXUITweenTool ixuitweenTool = gameObject.GetComponent("XUIPlayTween") as IXUITweenTool;
				GameObject gameObject2 = gameObject.transform.Find("ItemTpl").gameObject;
				IXUISprite ixuisprite = gameObject2.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = gameObject.transform.Find("SpecialResult").GetComponent("XUISprite") as IXUISprite;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)this._doc.CachedLotteryResult[num].itemID, (int)this._doc.CachedLotteryResult[num].itemCount, false);
				Transform parent = gameObject.transform.Find("Fx");
				LotteryType currentLotteryType = (LotteryType)this._doc.CurrentLotteryType;
				if (currentLotteryType - LotteryType.Sprite_Draw_One > 2)
				{
					if (currentLotteryType - LotteryType.Sprite_GoldDraw_One <= 2)
					{
						ixuisprite2.SetSprite("Fairy_EggNormal");
					}
				}
				else
				{
					ixuisprite2.SetSprite("Fairy_EggGold");
				}
				ixuisprite.ID = (ulong)this._doc.CachedLotteryResult[num].itemID;
				bool isbind = this._doc.CachedLotteryResult[num].isbind;
				if (isbind)
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
				}
				else
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				ixuisprite2.ID = (ulong)num;
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnEpicItemClicked));
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.CachedLotteryResult[num].itemID);
				ixuisprite2.SetVisible(this._doc.ResultShowList[num]);
				gameObject2.SetActive(!this._doc.ResultShowList[num]);
				bool flag2 = this._doc.ResultShowList[num];
				if (flag2)
				{
					switch (itemConf.ItemQuality)
					{
					case 3:
						this.m_FxList.Add(this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_04_orange", parent));
						break;
					case 4:
						this.m_FxList.Add(this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_04_purple", parent));
						break;
					case 5:
						this.m_FxList.Add(this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_04_red", parent));
						break;
					}
				}
				gameObject.transform.localPosition = new Vector3(vector.x + (float)(num % 5 * this.m_ResultPool.TplWidth), vector.y - (float)(num / 5 * this.m_ResultPool.TplHeight));
				ixuitweenTool.ResetTween(true);
				ixuitweenTool.PlayTween(true, -1f);
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Appear_NormalLoot", true, AudioChannel.Action);
			}
		}

		public void RefreshSpriteFx()
		{
			for (int i = 0; i < this.m_FxList.Count; i++)
			{
				bool flag = this.m_FxList[i] != null;
				if (flag)
				{
					this.m_FxList[i].Play();
				}
			}
		}

		private void OnEpicItemClicked(IXUISprite sp)
		{
			bool flag = (int)sp.ID >= this._doc.CachedLotteryResult.Count;
			if (!flag)
			{
				XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.ShowEpicItem), sp);
				this._doc.EpicSpriteShow((int)sp.ID);
			}
		}

		private void ShowEpicItem(object o)
		{
			IXUISprite ixuisprite = o as IXUISprite;
			bool flag = ixuisprite != null;
			if (flag)
			{
				GameObject gameObject = ixuisprite.parent.gameObject.transform.Find("ItemTpl").gameObject;
				gameObject.SetActive(true);
				ixuisprite.SetVisible(false);
			}
		}

		private XSpriteSystemDocument _doc = null;

		private IXUIButton m_NormalLotteryOnce;

		private IXUIButton m_NormalLotteryTen;

		private IXUILabelSymbol m_NormalLotteryOncePrice;

		private IXUILabelSymbol m_NormalLotteryTenPrice;

		private IXUIButton m_NormalLotteryDrop;

		private IXUIButton m_SpecialLotteryOnce;

		private IXUIButton m_SpecialLotteryTen;

		private IXUILabelSymbol m_SpecialLotteryOncePrice;

		private IXUILabelSymbol m_SpecialLotteryTenPrice;

		private IXUIButton m_SpecialLotteryDrop;

		private Transform m_NormalLottery;

		private Transform m_SpecialLottery;

		private Transform m_ResultFrame;

		private IXUILabelSymbol m_SafeCountTip;

		private Vector3 m_LotteryOnePos;

		private Vector3 m_LotteryTenPos;

		private XUIPool m_ResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton m_OkButton;

		private GameObject m_Block;

		private IXUITweenTool m_OkButtonTween;

		private int _maxColdDrawCount;

		private List<XFx> m_FxList = new List<XFx>();

		private List<GameObject> m_ResultList = new List<GameObject>();
	}
}
