using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C41 RID: 3137
	internal class XGuildJokerCommonView<T> : DlgBase<T, XGuildJokerBehaviour> where T : IXUIDlg, new()
	{
		// Token: 0x1700315F RID: 12639
		// (get) Token: 0x0600B1A9 RID: 45481 RVA: 0x00221DF0 File Offset: 0x0021FFF0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003160 RID: 12640
		// (get) Token: 0x0600B1AA RID: 45482 RVA: 0x00221E04 File Offset: 0x00220004
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003161 RID: 12641
		// (get) Token: 0x0600B1AB RID: 45483 RVA: 0x00221E18 File Offset: 0x00220018
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003162 RID: 12642
		// (get) Token: 0x0600B1AC RID: 45484 RVA: 0x00221E2C File Offset: 0x0022002C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B1AD RID: 45485 RVA: 0x00221E3F File Offset: 0x0022003F
		public XGuildJokerCommonView()
		{
			this.ResetJokerStatusCb = new XTimerMgr.ElapsedEventHandler(this.ResetJokerStatus);
		}

		// Token: 0x0600B1AE RID: 45486 RVA: 0x00221E62 File Offset: 0x00220062
		protected override void Init()
		{
			base.Init();
			this.CreateCard();
		}

		// Token: 0x0600B1AF RID: 45487 RVA: 0x00221E73 File Offset: 0x00220073
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B1B0 RID: 45488 RVA: 0x00221E80 File Offset: 0x00220080
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Rule.gameObject.SetActive(false);
			this.ClearCard();
			this.SetGameTipStatus(false);
			this.ResetJokerStatus(null);
			this._cardLock = false;
			this._changeCardLock = false;
		}

		// Token: 0x0600B1B1 RID: 45489 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void SetCurrentReward()
		{
		}

		// Token: 0x17003163 RID: 12643
		// (get) Token: 0x0600B1B2 RID: 45490 RVA: 0x00221ED4 File Offset: 0x002200D4
		protected virtual int CurrentStore
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17003164 RID: 12644
		// (get) Token: 0x0600B1B3 RID: 45491 RVA: 0x00221EE8 File Offset: 0x002200E8
		protected virtual int CurrentCardCount
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17003165 RID: 12645
		// (get) Token: 0x0600B1B4 RID: 45492 RVA: 0x00221EFC File Offset: 0x002200FC
		protected virtual uint CardResult
		{
			get
			{
				return 0U;
			}
		}

		// Token: 0x17003166 RID: 12646
		// (get) Token: 0x0600B1B5 RID: 45493 RVA: 0x00221F10 File Offset: 0x00220110
		protected virtual List<uint> BestCard
		{
			get
			{
				return new List<uint>();
			}
		}

		// Token: 0x17003167 RID: 12647
		// (get) Token: 0x0600B1B6 RID: 45494 RVA: 0x00221F28 File Offset: 0x00220128
		protected virtual string BestName
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x17003168 RID: 12648
		// (get) Token: 0x0600B1B7 RID: 45495 RVA: 0x00221F40 File Offset: 0x00220140
		protected virtual List<uint> CurrentCard
		{
			get
			{
				return new List<uint>();
			}
		}

		// Token: 0x0600B1B8 RID: 45496 RVA: 0x00221F58 File Offset: 0x00220158
		protected virtual bool OnCloseClick(IXUIButton button)
		{
			return false;
		}

		// Token: 0x0600B1B9 RID: 45497 RVA: 0x00221F6C File Offset: 0x0022016C
		protected virtual bool OnEndGameClicked(IXUIButton button)
		{
			return false;
		}

		// Token: 0x0600B1BA RID: 45498 RVA: 0x00221F80 File Offset: 0x00220180
		protected virtual bool OnStartGameClicked(IXUIButton button)
		{
			return false;
		}

		// Token: 0x0600B1BB RID: 45499 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnCardClick(IXUISprite sp)
		{
		}

		// Token: 0x0600B1BC RID: 45500 RVA: 0x00221F93 File Offset: 0x00220193
		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_JokerPic.SetTexturePath("");
		}

		// Token: 0x0600B1BD RID: 45501 RVA: 0x00221FB4 File Offset: 0x002201B4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClick));
			base.uiBehaviour.m_ReCharge.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRechargeClicked));
			base.uiBehaviour.m_AddCoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddCoinClicked));
			base.uiBehaviour.m_StartGame.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartGameClicked));
			base.uiBehaviour.m_RuleClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRuleCloseClicked));
		}

		// Token: 0x0600B1BE RID: 45502 RVA: 0x0022207C File Offset: 0x0022027C
		private bool OnRuleCloseClicked(IXUIButton sp)
		{
			base.uiBehaviour.m_Rule.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600B1BF RID: 45503 RVA: 0x002220A8 File Offset: 0x002202A8
		private bool OnHelpClick(IXUIButton button)
		{
			base.uiBehaviour.m_Rule.gameObject.SetActive(true);
			this.SetupRuleFrame();
			return true;
		}

		// Token: 0x0600B1C0 RID: 45504 RVA: 0x002220DC File Offset: 0x002202DC
		private bool OnRechargeClicked(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Recharge, 0UL);
			return true;
		}

		// Token: 0x0600B1C1 RID: 45505 RVA: 0x00222100 File Offset: 0x00220300
		private bool OnAddCoinClicked(IXUIButton button)
		{
			XPurchaseView singleton = DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton;
			singleton.ReqQuickCommonPurchase(ItemEnum.GOLD);
			return true;
		}

		// Token: 0x0600B1C2 RID: 45506 RVA: 0x00222121 File Offset: 0x00220321
		public void SetButtonTip(string tip)
		{
			base.uiBehaviour.m_ButtonTip.SetText(XStringDefineProxy.GetString(tip));
		}

		// Token: 0x0600B1C3 RID: 45507 RVA: 0x0022213C File Offset: 0x0022033C
		private void CreateCard()
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					string location = string.Format("UI/Guild/Card/Card{0}", j + 1);
					base.uiBehaviour.m_Card[i, j] = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(location, true, false) as GameObject).transform;
					bool flag = i == 0;
					if (flag)
					{
						base.uiBehaviour.m_Card[i, j].FindChild("T1").gameObject.SetActive(false);
						(base.uiBehaviour.m_Card[i, j].FindChild("Hs").GetComponent("XUISprite") as IXUISprite).SetSprite("pk_01");
					}
					else
					{
						bool flag2 = i == 1;
						if (flag2)
						{
							base.uiBehaviour.m_Card[i, j].FindChild("T1").gameObject.SetActive(false);
							(base.uiBehaviour.m_Card[i, j].FindChild("Hs").GetComponent("XUISprite") as IXUISprite).SetSprite("pk_02");
						}
						else
						{
							bool flag3 = i == 2;
							if (flag3)
							{
								base.uiBehaviour.m_Card[i, j].FindChild("T2").gameObject.SetActive(false);
								(base.uiBehaviour.m_Card[i, j].FindChild("Hs").GetComponent("XUISprite") as IXUISprite).SetSprite("pk_03");
							}
							else
							{
								bool flag4 = i == 3;
								if (flag4)
								{
									base.uiBehaviour.m_Card[i, j].FindChild("T2").gameObject.SetActive(false);
									(base.uiBehaviour.m_Card[i, j].FindChild("Hs").GetComponent("XUISprite") as IXUISprite).SetSprite("pk_04");
								}
							}
						}
					}
					base.uiBehaviour.m_Card[i, j].parent = base.uiBehaviour.m_CardBag;
					base.uiBehaviour.m_Card[i, j].localScale = Vector3.one;
					base.uiBehaviour.m_Card[i, j].name = (i * 13 + j).ToString();
					IXUISprite ixuisprite = base.uiBehaviour.m_Card[i, j].GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((j + 1) * 16 + i);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCardClick));
					base.uiBehaviour.m_Card[i, j].gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600B1C4 RID: 45508 RVA: 0x0022243C File Offset: 0x0022063C
		public void ClearCard()
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					base.uiBehaviour.m_Card[i, j].gameObject.SetActive(false);
					base.uiBehaviour.m_Card[i, j].gameObject.transform.FindChild("Back").gameObject.SetActive(false);
					base.uiBehaviour.m_Card[i, j].gameObject.transform.FindChild("Select").gameObject.SetActive(false);
					(base.uiBehaviour.m_Card[i, j].GetComponent("XUIPlayTween") as IXUITweenTool).ResetTween(true);
				}
			}
			this._changeCardLock = false;
		}

		// Token: 0x0600B1C5 RID: 45509 RVA: 0x0022252C File Offset: 0x0022072C
		public void RefreshCard()
		{
			this.ClearCard();
			XSingleton<XDebug>.singleton.AddGreenLog("RefreshCard Times ??????", this.CurrentCardCount.ToString(), null, null, null, null);
			bool flag = this.CurrentCardCount != 0;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.SetupCard), 0);
				this._cardLock = true;
			}
			else
			{
				this._cardLock = false;
			}
		}

		// Token: 0x0600B1C6 RID: 45510 RVA: 0x002225A4 File Offset: 0x002207A4
		private void SetupCard(object o)
		{
			int num = (int)o;
			bool flag = num >= this.CurrentCardCount;
			if (!flag)
			{
				uint num2 = this.CardAnalyze(this.CurrentCard[num]);
				uint num3 = num2 >> 4;
				uint num4 = num2 % 16U;
				base.uiBehaviour.m_Card[(int)num4, (int)(num3 - 1U)].gameObject.SetActive(true);
				(base.uiBehaviour.m_Card[(int)num4, (int)(num3 - 1U)].GetComponent("XUIPlayTween") as IXUITweenTool).ResetTween(true);
				base.uiBehaviour.m_Card[(int)num4, (int)(num3 - 1U)].transform.position = base.uiBehaviour.m_CardPos[num].position;
				base.uiBehaviour.m_Card[(int)num4, (int)(num3 - 1U)].transform.rotation = base.uiBehaviour.m_CardPos[num].rotation;
				this.OnCardTween4Finish(base.uiBehaviour.m_Card[(int)num4, (int)(num3 - 1U)].GetComponent("XUIPlayTween") as IXUITweenTool);
				bool flag2 = num + 1 < this.CurrentCardCount;
				if (flag2)
				{
					XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(this.SetupCard), num + 1);
				}
				else
				{
					this._cardLock = false;
				}
			}
		}

		// Token: 0x0600B1C7 RID: 45511 RVA: 0x00222708 File Offset: 0x00220908
		private uint CardAnalyze(uint cardNum)
		{
			uint num = cardNum >> 4;
			uint num2 = cardNum % 16U;
			bool flag = num == 14U;
			if (flag)
			{
				num = 1U;
			}
			return (num << 4) + num2;
		}

		// Token: 0x0600B1C8 RID: 45512 RVA: 0x00222734 File Offset: 0x00220934
		protected uint CardReAnalyze(uint cardNum)
		{
			uint num = cardNum >> 4;
			uint num2 = cardNum % 16U;
			bool flag = num == 1U;
			if (flag)
			{
				num = 14U;
			}
			return (num << 4) + num2;
		}

		// Token: 0x0600B1C9 RID: 45513 RVA: 0x00222760 File Offset: 0x00220960
		public void ChangeCard(uint oldCard, uint newCard, int cardNum)
		{
			bool flag = newCard == 0U || oldCard == 0U || cardNum == -1;
			if (!flag)
			{
				uint num = this.CardAnalyze(oldCard);
				uint num2 = this.CardAnalyze(newCard);
				this._oldCardNum = num >> 4;
				this._oldCardType = num % 16U;
				this._newCardNum = num2 >> 4;
				this._newCardType = num2 % 16U;
				this._cardChangeNum = cardNum;
				XSingleton<XDebug>.singleton.AddGreenLog("Change Card:", this._oldCardNum.ToString(), "  ", this._oldCardType.ToString(), null, null);
				bool flag2 = this._oldCardType < 4U && this._oldCardNum < 14U;
				if (flag2)
				{
					this.ClearCardSelect();
					this.PlayCardTween(base.uiBehaviour.m_Card[(int)this._oldCardType, (int)(this._oldCardNum - 1U)].GetComponent("XUIPlayTween") as IXUITweenTool);
				}
			}
		}

		// Token: 0x0600B1CA RID: 45514 RVA: 0x00222848 File Offset: 0x00220A48
		public void SetCardStore()
		{
			bool flag = this.CurrentStore >= XGuildJokerDocument._CardStoreTable.Table.Length;
			string jokerLabel;
			if (flag)
			{
				jokerLabel = string.Format("{0}", XStringDefineProxy.GetString("NONE"));
			}
			else
			{
				jokerLabel = string.Format("{0}", XGuildJokerDocument._CardStoreTable.Table[this.CurrentStore].words);
			}
			this.SetJokerLabel(jokerLabel);
		}

		// Token: 0x0600B1CB RID: 45515 RVA: 0x002228B5 File Offset: 0x00220AB5
		protected void SetJokerLabel(string strTmp)
		{
			base.uiBehaviour.m_JokerLabel.SetText(strTmp);
		}

		// Token: 0x0600B1CC RID: 45516 RVA: 0x002228CA File Offset: 0x00220ACA
		protected void SetCurrentRewardStr(string strTmp)
		{
			base.uiBehaviour.m_CurrentReward.InputText = strTmp;
		}

		// Token: 0x0600B1CD RID: 45517 RVA: 0x002228E0 File Offset: 0x00220AE0
		private void ClearCardSelect()
		{
			for (int i = 0; i < this.CurrentCardCount; i++)
			{
				uint num = this.CardAnalyze(this.CurrentCard[i]);
				uint num2 = num >> 4;
				uint num3 = num % 16U;
				base.uiBehaviour.m_Card[(int)num3, (int)(num2 - 1U)].FindChild("Select").gameObject.SetActive(false);
			}
		}

		// Token: 0x0600B1CE RID: 45518 RVA: 0x00222950 File Offset: 0x00220B50
		public void SetupBestCard()
		{
			bool flag = this.BestCard.Count == 0;
			if (flag)
			{
				for (int i = 0; i < 5; i++)
				{
					base.uiBehaviour.m_BestCardColor[i].SetVisible(false);
					base.uiBehaviour.m_BestCardNum1[i].SetVisible(false);
					base.uiBehaviour.m_BestCardNum2[i].SetVisible(false);
				}
			}
			for (int j = 0; j < this.BestCard.Count; j++)
			{
				uint num = this.CardAnalyze(this.BestCard[j]);
				uint num2 = num >> 4;
				uint num3 = num % 16U;
				base.uiBehaviour.m_BestCardColor[j].SetVisible(true);
				base.uiBehaviour.m_BestCardColor[j].SetSprite(string.Format("pk_0{0}", num3 + 1U));
				bool flag2 = num3 < 2U;
				if (flag2)
				{
					base.uiBehaviour.m_BestCardNum1[j].SetVisible(false);
					base.uiBehaviour.m_BestCardNum2[j].SetVisible(true);
					bool flag3 = num2 > 1U && num2 < 11U;
					if (flag3)
					{
						base.uiBehaviour.m_BestCardNum2[j].SetText(num2.ToString());
					}
					else
					{
						bool flag4 = num2 == 1U;
						if (flag4)
						{
							base.uiBehaviour.m_BestCardNum2[j].SetText("A");
						}
						else
						{
							bool flag5 = num2 == 11U;
							if (flag5)
							{
								base.uiBehaviour.m_BestCardNum2[j].SetText("J");
							}
							else
							{
								bool flag6 = num2 == 12U;
								if (flag6)
								{
									base.uiBehaviour.m_BestCardNum2[j].SetText("Q");
								}
								else
								{
									bool flag7 = num2 == 13U;
									if (flag7)
									{
										base.uiBehaviour.m_BestCardNum2[j].SetText("K");
									}
								}
							}
						}
					}
				}
				else
				{
					base.uiBehaviour.m_BestCardNum1[j].SetVisible(true);
					base.uiBehaviour.m_BestCardNum2[j].SetVisible(false);
					bool flag8 = num2 > 1U && num2 < 11U;
					if (flag8)
					{
						base.uiBehaviour.m_BestCardNum1[j].SetText(num2.ToString());
					}
					else
					{
						bool flag9 = num2 == 1U;
						if (flag9)
						{
							base.uiBehaviour.m_BestCardNum1[j].SetText("A");
						}
						else
						{
							bool flag10 = num2 == 11U;
							if (flag10)
							{
								base.uiBehaviour.m_BestCardNum1[j].SetText("J");
							}
							else
							{
								bool flag11 = num2 == 12U;
								if (flag11)
								{
									base.uiBehaviour.m_BestCardNum1[j].SetText("Q");
								}
								else
								{
									bool flag12 = num2 == 13U;
									if (flag12)
									{
										base.uiBehaviour.m_BestCardNum1[j].SetText("K");
									}
								}
							}
						}
					}
				}
			}
			base.uiBehaviour.m_BestPlayerName.SetText(this.BestName);
		}

		// Token: 0x0600B1CF RID: 45519 RVA: 0x00222C50 File Offset: 0x00220E50
		protected virtual SeqListRef<uint> GetCardReward(int index)
		{
			return XGuildJokerDocument._CardRewardTable.Table[index].reward;
		}

		// Token: 0x0600B1D0 RID: 45520 RVA: 0x00222C74 File Offset: 0x00220E74
		public void SetupRuleFrame()
		{
			base.uiBehaviour.m_RuleItemPool.FakeReturnAll();
			for (int i = 0; i < XGuildJokerDocument._CardRewardTable.Table.Length; i++)
			{
				string text = string.Format("Bg/RulePanel/RuleTpl{0}/ScoreTip", i + 1);
				IXUILabel ixuilabel = base.uiBehaviour.m_Rule.FindChild(text).GetComponent("XUILabel") as IXUILabel;
				bool flag = ixuilabel != null;
				if (flag)
				{
					ixuilabel.SetText(XGuildJokerDocument._CardRewardTable.Table[i].point.ToString());
				}
				SeqListRef<uint> cardReward = this.GetCardReward(i);
				for (int j = 0; j < cardReward.Count; j++)
				{
					GameObject gameObject = base.uiBehaviour.m_RuleItemPool.FetchGameObject(false);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)cardReward[j, 0];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)cardReward[j, 0], (int)cardReward[j, 1], false);
					gameObject.transform.localPosition = base.uiBehaviour.m_RuleItemPool.TplPos + new Vector3((float)(j * base.uiBehaviour.m_RuleItemPool.TplWidth), (float)(-(float)i * base.uiBehaviour.m_RuleItemPool.TplHeight));
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
			base.uiBehaviour.m_RuleItemPool.ActualReturnAll(false);
			base.uiBehaviour.m_RuleScrollView.ResetPosition();
		}

		// Token: 0x0600B1D1 RID: 45521 RVA: 0x00222E3C File Offset: 0x0022103C
		private void PlayCardTween(IXUITweenTool cardTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.CurrentCardCount == 0;
				if (!flag2)
				{
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/puke", true, AudioChannel.Action);
					this._changeCardLock = true;
					cardTween.PlayTween(true, -1f);
					cardTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnCardTween1Finish));
				}
			}
		}

		// Token: 0x0600B1D2 RID: 45522 RVA: 0x00222EA4 File Offset: 0x002210A4
		private void OnCardTween1Finish(IXUITweenTool cardTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.CurrentCardCount == 0;
				if (!flag2)
				{
					Transform transform = cardTween.gameObject.transform.FindChild("Back");
					transform.gameObject.SetActive(true);
					cardTween.PlayTween(false, -1f);
					cardTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnCardTween2Finish));
				}
			}
		}

		// Token: 0x0600B1D3 RID: 45523 RVA: 0x00222F14 File Offset: 0x00221114
		private void PlayCardWaitTween(object o)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.CurrentCardCount == 0;
				if (!flag2)
				{
					base.uiBehaviour.m_Card[(int)this._oldCardType, (int)(this._oldCardNum - 1U)].gameObject.SetActive(false);
					base.uiBehaviour.m_Card[(int)this._newCardType, (int)(this._newCardNum - 1U)].gameObject.SetActive(true);
					base.uiBehaviour.m_Card[(int)this._newCardType, (int)(this._newCardNum - 1U)].transform.position = base.uiBehaviour.m_CardPos[this._cardChangeNum].position;
					base.uiBehaviour.m_Card[(int)this._newCardType, (int)(this._newCardNum - 1U)].transform.rotation = base.uiBehaviour.m_CardPos[this._cardChangeNum].rotation;
					base.uiBehaviour.m_Card[(int)this._newCardType, (int)(this._newCardNum - 1U)].transform.FindChild("Back").gameObject.SetActive(true);
					base.uiBehaviour.m_Card[(int)this._newCardType, (int)(this._newCardNum - 1U)].transform.FindChild("Select").gameObject.SetActive(false);
					IXUITweenTool ixuitweenTool = base.uiBehaviour.m_Card[(int)this._newCardType, (int)(this._newCardNum - 1U)].GetComponent("XUIPlayTween") as IXUITweenTool;
					ixuitweenTool.ResetTween(true);
					ixuitweenTool.PlayTween(true, -1f);
					ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnCardTween3Finish));
				}
			}
		}

		// Token: 0x0600B1D4 RID: 45524 RVA: 0x002230E4 File Offset: 0x002212E4
		private void OnCardTween2Finish(IXUITweenTool cardTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.CurrentCardCount == 0;
				if (!flag2)
				{
					XSingleton<XTimerMgr>.singleton.SetTimer(0.3f, new XTimerMgr.ElapsedEventHandler(this.PlayCardWaitTween), cardTween);
					cardTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnCardTween3Finish));
				}
			}
		}

		// Token: 0x0600B1D5 RID: 45525 RVA: 0x00223140 File Offset: 0x00221340
		private void OnCardTween4Finish(IXUITweenTool cardTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.CurrentCardCount == 0;
				if (!flag2)
				{
					cardTween.gameObject.transform.FindChild("Back").gameObject.SetActive(true);
					cardTween.gameObject.transform.FindChild("Select").gameObject.SetActive(false);
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/puke", true, AudioChannel.Action);
					this._changeCardLock = true;
					cardTween.ResetTween(true);
					cardTween.PlayTween(true, -1f);
					cardTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnCardTween3Finish));
				}
			}
		}

		// Token: 0x0600B1D6 RID: 45526 RVA: 0x002231F8 File Offset: 0x002213F8
		private void OnCardTween3Finish(IXUITweenTool cardTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.CurrentCardCount == 0;
				if (!flag2)
				{
					Transform transform = cardTween.gameObject.transform.FindChild("Back");
					transform.gameObject.SetActive(false);
					cardTween.PlayTween(false, -1f);
					cardTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnCardTweenOver));
				}
			}
		}

		// Token: 0x0600B1D7 RID: 45527 RVA: 0x00223268 File Offset: 0x00221468
		private void OnCardTweenOver(IXUITweenTool cardTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.CurrentCardCount == 0;
				if (!flag2)
				{
					this._changeCardLock = false;
					this.SetCurrentReward();
				}
			}
		}

		// Token: 0x0600B1D8 RID: 45528 RVA: 0x002232A4 File Offset: 0x002214A4
		protected void RefreshCardSelect()
		{
			bool flag = this.CardResult == 0U || this.CardResult == 2U || this.CardResult == 3U || this.CardResult == 4U;
			if (flag)
			{
				for (int i = 0; i < this.CurrentCardCount; i++)
				{
					uint num = this.CardAnalyze(this.CurrentCard[i]);
					uint num2 = num >> 4;
					uint type = num % 16U;
					this.SetCardSelected(type, num2 - 1U);
				}
			}
			else
			{
				for (int j = 0; j < this.CurrentCardCount; j++)
				{
					uint num3 = this.CardAnalyze(this.CurrentCard[j]);
					uint num4 = num3 >> 4;
					uint type2 = num3 % 16U;
					for (int k = j + 1; k < this.CurrentCardCount; k++)
					{
						uint num5 = this.CardAnalyze(this.CurrentCard[k]);
						uint num6 = num5 >> 4;
						uint type3 = num5 % 16U;
						bool flag2 = num4 == num6;
						if (flag2)
						{
							this.SetCardSelected(type2, num4 - 1U);
							this.SetCardSelected(type3, num6 - 1U);
						}
					}
				}
			}
		}

		// Token: 0x0600B1D9 RID: 45529 RVA: 0x002233D8 File Offset: 0x002215D8
		private void SetCardSelected(uint type, uint index)
		{
			bool flag = type >= 4U || index >= 13U;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("type == {0}, index={1}", type, index), null, null, null, null, null);
			}
			else
			{
				bool flag2 = base.uiBehaviour.m_Card[(int)type, (int)index] == null;
				if (!flag2)
				{
					base.uiBehaviour.m_Card[(int)type, (int)index].FindChild("Select").gameObject.SetActive(true);
				}
			}
		}

		// Token: 0x0600B1DA RID: 45530 RVA: 0x00223468 File Offset: 0x00221668
		public void JokerStatus(int status)
		{
			switch (status)
			{
			case 1:
				base.uiBehaviour.m_JokerPic.SetTexturePath("atlas/UI/Social/gh_bg_xcpk_xc0");
				break;
			case 2:
				base.uiBehaviour.m_JokerPic.SetTexturePath("atlas/UI/Social/gh_bg_xcpk_xc1");
				break;
			case 3:
				base.uiBehaviour.m_JokerPic.SetTexturePath("atlas/UI/Social/gh_bg_xcpk_xc2");
				break;
			}
		}

		// Token: 0x0600B1DB RID: 45531 RVA: 0x002234D8 File Offset: 0x002216D8
		private void ResetJokerStatus(object o = null)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.JokerStatus(1);
			}
		}

		// Token: 0x0600B1DC RID: 45532 RVA: 0x002234FD File Offset: 0x002216FD
		public void SetGameTipStatus(bool status)
		{
			base.uiBehaviour.m_GameTip.gameObject.SetActive(status);
		}

		// Token: 0x04004477 RID: 17527
		protected uint _currentChangeCard;

		// Token: 0x04004478 RID: 17528
		private uint _oldCardNum;

		// Token: 0x04004479 RID: 17529
		private uint _oldCardType;

		// Token: 0x0400447A RID: 17530
		private uint _newCardNum;

		// Token: 0x0400447B RID: 17531
		private uint _newCardType;

		// Token: 0x0400447C RID: 17532
		private int _cardChangeNum;

		// Token: 0x0400447D RID: 17533
		protected bool _changeCardLock;

		// Token: 0x0400447E RID: 17534
		protected bool _cardLock;

		// Token: 0x0400447F RID: 17535
		public XTimerMgr.ElapsedEventHandler ResetJokerStatusCb = null;
	}
}
