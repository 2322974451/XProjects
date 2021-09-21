using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001814 RID: 6164
	internal class SpriteLotteryHandler : DlgHandlerBase
	{
		// Token: 0x17003901 RID: 14593
		// (get) Token: 0x0600FFAA RID: 65450 RVA: 0x003C78E8 File Offset: 0x003C5AE8
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteLotteryHandler";
			}
		}

		// Token: 0x0600FFAB RID: 65451 RVA: 0x003C78FF File Offset: 0x003C5AFF
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			this._maxColdDrawCount = XSingleton<XGlobalConfig>.singleton.GetInt("GoldDrawFreeDayCount");
			this.InitUI();
		}

		// Token: 0x0600FFAC RID: 65452 RVA: 0x003C7938 File Offset: 0x003C5B38
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

		// Token: 0x0600FFAD RID: 65453 RVA: 0x003C7DB8 File Offset: 0x003C5FB8
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

		// Token: 0x0600FFAE RID: 65454 RVA: 0x003C7E75 File Offset: 0x003C6075
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryBuyEggCD();
			this.ShowLotteryFrame();
		}

		// Token: 0x0600FFAF RID: 65455 RVA: 0x003C7E92 File Offset: 0x003C6092
		protected override void OnHide()
		{
			this.ClearAllFx();
			this.m_ResultList.Clear();
			base.OnHide();
		}

		// Token: 0x0600FFB0 RID: 65456 RVA: 0x003C7EAF File Offset: 0x003C60AF
		public override void OnUnload()
		{
			this.ClearAllFx();
			base.OnUnload();
		}

		// Token: 0x0600FFB1 RID: 65457 RVA: 0x003C7EC0 File Offset: 0x003C60C0
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshSpriteFx();
		}

		// Token: 0x0600FFB2 RID: 65458 RVA: 0x003C7ED4 File Offset: 0x003C60D4
		private bool OnLotteryClicked(IXUIButton button)
		{
			this._doc.SendLotteryRpc((uint)button.ID);
			return true;
		}

		// Token: 0x0600FFB3 RID: 65459 RVA: 0x003C7EFC File Offset: 0x003C60FC
		private bool OnNormalLotteryDropClicked(IXUIButton button)
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.OpenWindows(SpriteWindow.Illustration);
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._IllustrationHandler.ShowSpriteEggIllustration(SpriteEggLotteryType.Normal);
			return true;
		}

		// Token: 0x0600FFB4 RID: 65460 RVA: 0x003C7F2C File Offset: 0x003C612C
		private bool OnSpecialLotteryDropClicked(IXUIButton button)
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.OpenWindows(SpriteWindow.Illustration);
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._IllustrationHandler.ShowSpriteEggIllustration(SpriteEggLotteryType.Special);
			return true;
		}

		// Token: 0x0600FFB5 RID: 65461 RVA: 0x003C7F5C File Offset: 0x003C615C
		public void RefreshSafeCountUI()
		{
			this.m_SafeCountTip.InputText = XStringDefineProxy.GetString("SpriteLotterySafeTip", new object[]
			{
				this._doc.SpecialSafeCount
			});
		}

		// Token: 0x0600FFB6 RID: 65462 RVA: 0x003C7F90 File Offset: 0x003C6190
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

		// Token: 0x0600FFB7 RID: 65463 RVA: 0x003C8097 File Offset: 0x003C6297
		private void ShowLotteryFrame()
		{
			this.m_NormalLottery.gameObject.SetActive(true);
			this.m_SpecialLottery.gameObject.SetActive(true);
			this.m_ResultFrame.gameObject.SetActive(false);
			this.ClearAllFx();
		}

		// Token: 0x0600FFB8 RID: 65464 RVA: 0x003C80D7 File Offset: 0x003C62D7
		public void ShowResultFrame()
		{
			this.m_NormalLottery.gameObject.SetActive(false);
			this.m_SpecialLottery.gameObject.SetActive(false);
			this.m_ResultFrame.gameObject.SetActive(true);
			this.RefreshResultFrame();
		}

		// Token: 0x0600FFB9 RID: 65465 RVA: 0x003C8118 File Offset: 0x003C6318
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

		// Token: 0x0600FFBA RID: 65466 RVA: 0x003C81E8 File Offset: 0x003C63E8
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

		// Token: 0x0600FFBB RID: 65467 RVA: 0x003C8234 File Offset: 0x003C6434
		private void ClearAllFx()
		{
			for (int i = 0; i < this.m_FxList.Count; i++)
			{
				this._doc.DestroyFx(this.m_FxList[i]);
			}
			this.m_FxList.Clear();
		}

		// Token: 0x0600FFBC RID: 65468 RVA: 0x003C8284 File Offset: 0x003C6484
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

		// Token: 0x0600FFBD RID: 65469 RVA: 0x003C85C8 File Offset: 0x003C67C8
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

		// Token: 0x0600FFBE RID: 65470 RVA: 0x003C8618 File Offset: 0x003C6818
		private void OnEpicItemClicked(IXUISprite sp)
		{
			bool flag = (int)sp.ID >= this._doc.CachedLotteryResult.Count;
			if (!flag)
			{
				XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.ShowEpicItem), sp);
				this._doc.EpicSpriteShow((int)sp.ID);
			}
		}

		// Token: 0x0600FFBF RID: 65471 RVA: 0x003C8678 File Offset: 0x003C6878
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

		// Token: 0x0400713A RID: 28986
		private XSpriteSystemDocument _doc = null;

		// Token: 0x0400713B RID: 28987
		private IXUIButton m_NormalLotteryOnce;

		// Token: 0x0400713C RID: 28988
		private IXUIButton m_NormalLotteryTen;

		// Token: 0x0400713D RID: 28989
		private IXUILabelSymbol m_NormalLotteryOncePrice;

		// Token: 0x0400713E RID: 28990
		private IXUILabelSymbol m_NormalLotteryTenPrice;

		// Token: 0x0400713F RID: 28991
		private IXUIButton m_NormalLotteryDrop;

		// Token: 0x04007140 RID: 28992
		private IXUIButton m_SpecialLotteryOnce;

		// Token: 0x04007141 RID: 28993
		private IXUIButton m_SpecialLotteryTen;

		// Token: 0x04007142 RID: 28994
		private IXUILabelSymbol m_SpecialLotteryOncePrice;

		// Token: 0x04007143 RID: 28995
		private IXUILabelSymbol m_SpecialLotteryTenPrice;

		// Token: 0x04007144 RID: 28996
		private IXUIButton m_SpecialLotteryDrop;

		// Token: 0x04007145 RID: 28997
		private Transform m_NormalLottery;

		// Token: 0x04007146 RID: 28998
		private Transform m_SpecialLottery;

		// Token: 0x04007147 RID: 28999
		private Transform m_ResultFrame;

		// Token: 0x04007148 RID: 29000
		private IXUILabelSymbol m_SafeCountTip;

		// Token: 0x04007149 RID: 29001
		private Vector3 m_LotteryOnePos;

		// Token: 0x0400714A RID: 29002
		private Vector3 m_LotteryTenPos;

		// Token: 0x0400714B RID: 29003
		private XUIPool m_ResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400714C RID: 29004
		private IXUIButton m_OkButton;

		// Token: 0x0400714D RID: 29005
		private GameObject m_Block;

		// Token: 0x0400714E RID: 29006
		private IXUITweenTool m_OkButtonTween;

		// Token: 0x0400714F RID: 29007
		private int _maxColdDrawCount;

		// Token: 0x04007150 RID: 29008
		private List<XFx> m_FxList = new List<XFx>();

		// Token: 0x04007151 RID: 29009
		private List<GameObject> m_ResultList = new List<GameObject>();
	}
}
