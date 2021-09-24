using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildJokerCommonView<T> : DlgBase<T, XGuildJokerBehaviour> where T : IXUIDlg, new()
	{

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public XGuildJokerCommonView()
		{
			this.ResetJokerStatusCb = new XTimerMgr.ElapsedEventHandler(this.ResetJokerStatus);
		}

		protected override void Init()
		{
			base.Init();
			this.CreateCard();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

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

		public virtual void SetCurrentReward()
		{
		}

		protected virtual int CurrentStore
		{
			get
			{
				return 0;
			}
		}

		protected virtual int CurrentCardCount
		{
			get
			{
				return 0;
			}
		}

		protected virtual uint CardResult
		{
			get
			{
				return 0U;
			}
		}

		protected virtual List<uint> BestCard
		{
			get
			{
				return new List<uint>();
			}
		}

		protected virtual string BestName
		{
			get
			{
				return string.Empty;
			}
		}

		protected virtual List<uint> CurrentCard
		{
			get
			{
				return new List<uint>();
			}
		}

		protected virtual bool OnCloseClick(IXUIButton button)
		{
			return false;
		}

		protected virtual bool OnEndGameClicked(IXUIButton button)
		{
			return false;
		}

		protected virtual bool OnStartGameClicked(IXUIButton button)
		{
			return false;
		}

		protected virtual void OnCardClick(IXUISprite sp)
		{
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_JokerPic.SetTexturePath("");
		}

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

		private bool OnRuleCloseClicked(IXUIButton sp)
		{
			base.uiBehaviour.m_Rule.gameObject.SetActive(false);
			return true;
		}

		private bool OnHelpClick(IXUIButton button)
		{
			base.uiBehaviour.m_Rule.gameObject.SetActive(true);
			this.SetupRuleFrame();
			return true;
		}

		private bool OnRechargeClicked(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Recharge, 0UL);
			return true;
		}

		private bool OnAddCoinClicked(IXUIButton button)
		{
			XPurchaseView singleton = DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton;
			singleton.ReqQuickCommonPurchase(ItemEnum.GOLD);
			return true;
		}

		public void SetButtonTip(string tip)
		{
			base.uiBehaviour.m_ButtonTip.SetText(XStringDefineProxy.GetString(tip));
		}

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

		protected void SetJokerLabel(string strTmp)
		{
			base.uiBehaviour.m_JokerLabel.SetText(strTmp);
		}

		protected void SetCurrentRewardStr(string strTmp)
		{
			base.uiBehaviour.m_CurrentReward.InputText = strTmp;
		}

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

		protected virtual SeqListRef<uint> GetCardReward(int index)
		{
			return XGuildJokerDocument._CardRewardTable.Table[index].reward;
		}

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

		private void ResetJokerStatus(object o = null)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.JokerStatus(1);
			}
		}

		public void SetGameTipStatus(bool status)
		{
			base.uiBehaviour.m_GameTip.gameObject.SetActive(status);
		}

		protected uint _currentChangeCard;

		private uint _oldCardNum;

		private uint _oldCardType;

		private uint _newCardNum;

		private uint _newCardType;

		private int _cardChangeNum;

		protected bool _changeCardLock;

		protected bool _cardLock;

		public XTimerMgr.ElapsedEventHandler ResetJokerStatusCb = null;
	}
}
