using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ExchangeItemDlg : DlgBase<ExchangeItemDlg, ExchangeItemBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildCollect/ExchangeItemDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XExchangeItemDocument>(XExchangeItemDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_EnsureBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnsureBtnClick));
			base.uiBehaviour.m_Input.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnInputBtnClick));
			base.uiBehaviour.m_SpeakBtn.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnVoiceButton));
			base.uiBehaviour.m_SpeakBtn.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnVoiceButtonDrag));
			base.uiBehaviour.m_MyVoiceBtn.ID = 0UL;
			base.uiBehaviour.m_MyVoiceBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAudioPlayClick));
			base.uiBehaviour.m_OtherVoiceBtn.ID = 1UL;
			base.uiBehaviour.m_OtherVoiceBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAudioPlayClick));
		}

		protected override void OnShow()
		{
			base.uiBehaviour.m_MyVoiceBtn.SetVisible(false);
			base.uiBehaviour.m_MyInputGo.SetActive(false);
			base.uiBehaviour.m_OtherVoiceBtn.SetVisible(false);
			base.uiBehaviour.m_OtherInputGo.SetActive(false);
			XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl/Except_Quiz", 0f);
			XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl/Quiz ", 1f);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(false);
			XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(false);
			base.OnShow();
		}

		public void InitShow(string name, uint prof)
		{
			this.SetVisibleWithAnimation(true, null);
			base.uiBehaviour.m_Title.SetText(string.Format(XStringDefineProxy.GetString("ExchangeTitle"), this._doc.ExchangeItemStr));
			base.uiBehaviour.m_MyItemGo.SetActive(false);
			base.uiBehaviour.m_OtherItemGo.SetActive(false);
			IXUILabel ixuilabel = base.uiBehaviour.transform.Find("Bg/Other/Name").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = base.uiBehaviour.transform.Find("Bg/Other/head").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText(name);
			ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetSuperRiskAvatar(prof % 10U);
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				IXUILabel ixuilabel2 = base.uiBehaviour.transform.Find("Bg/Self/Name").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = base.uiBehaviour.transform.Find("Bg/Self/head").GetComponent("XUISprite") as IXUISprite;
				ixuilabel2.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
				ixuisprite2.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetSuperRiskAvatar(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % 10U);
			}
			this.OnTipsChange();
			this.OnEnsureStateChange();
			ulong typeFilter = 1UL << this._doc.ExchangeType;
			this._doc.ItemList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this._doc.ItemList);
			this.RefreshMyItemList();
			base.uiBehaviour.m_ItemScrollView.ResetPosition();
		}

		public void RefreshMyItemList()
		{
			base.uiBehaviour.m_MyItemPool.FakeReturnAll();
			Vector3 tplPos = base.uiBehaviour.m_MyItemPool.TplPos;
			int num = 0;
			for (int i = 0; i < this._doc.ItemList.Count; i++)
			{
				bool flag = this._doc.ItemList[i].uid == this._doc.CurrentSelectUid && this._doc.ItemList[i].itemCount == 1;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.m_MyItemPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(num % this.COLNUM * base.uiBehaviour.m_MyItemPool.TplWidth), tplPos.y - (float)(num / this.COLNUM * base.uiBehaviour.m_MyItemPool.TplHeight), 0f);
					ItemList.RowData itemConf = XBagDocument.GetItemConf(this._doc.ItemList[i].itemID);
					int itemCount = (this._doc.ItemList[i].uid == this._doc.CurrentSelectUid) ? (this._doc.ItemList[i].itemCount - 1) : this._doc.ItemList[i].itemCount;
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf, itemCount, false);
					IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = this._doc.ItemList[i].uid;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClick));
					num++;
				}
			}
			base.uiBehaviour.m_MyItemPool.ActualReturnAll(false);
		}

		public void OnMySelectChange(ulong SelectID)
		{
			bool flag = SelectID == 0UL;
			if (flag)
			{
				base.uiBehaviour.m_MyItemGo.SetActive(false);
			}
			else
			{
				base.uiBehaviour.m_MyItemGo.SetActive(true);
				int i = 0;
				while (i < this._doc.ItemList.Count)
				{
					bool flag2 = this._doc.ItemList[i].uid == SelectID;
					if (flag2)
					{
						ItemList.RowData itemConf = XBagDocument.GetItemConf(this._doc.ItemList[i].itemID);
						bool flag3 = itemConf == null;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("Can't find my select itemid for itemlist. selectID = ", SelectID.ToString(), null, null, null, null);
							return;
						}
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_MySelect, itemConf, 0, false);
						base.uiBehaviour.m_MyItemName.SetText(XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U));
						IXUISprite ixuisprite = base.uiBehaviour.m_MySelect.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = 0UL;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClick));
						return;
					}
					else
					{
						i++;
					}
				}
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find MySelectID for bag. MySelectID = ", SelectID.ToString(), null, null, null, null);
			}
		}

		public void OnOtherSelectChange(int SelectID)
		{
			bool flag = SelectID == 0;
			if (flag)
			{
				base.uiBehaviour.m_OtherItemGo.SetActive(false);
			}
			else
			{
				base.uiBehaviour.m_OtherItemGo.SetActive(true);
				ItemList.RowData itemConf = XBagDocument.GetItemConf(SelectID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Can't find Other select itemid for itemlist. selectID = ", SelectID.ToString(), null, null, null, null);
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_OtherSelect, itemConf, 0, false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(base.uiBehaviour.m_OtherSelect, SelectID);
					base.uiBehaviour.m_OtherItemName.SetText(XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U));
				}
			}
		}

		public void OnEnsureStateChange()
		{
			base.uiBehaviour.m_MyEnsureText.SetText(XStringDefineProxy.GetString(string.Format("ExchangeMyEnsureTips_{0}", this._doc.MyEnsureState ? 1 : 0)));
			base.uiBehaviour.m_OtherEnsureText.SetText(XStringDefineProxy.GetString(string.Format("ExchangeOtherEnsureTips_{0}", this._doc.OtherEnsureState ? 1 : 0)));
		}

		public void OnTipsChange()
		{
			string text = XStringDefineProxy.GetString(string.Format("ExchangeTips_{0}", this._doc.TipsState));
			bool flag = this._doc.TipsState == 0 || this._doc.TipsState == 2;
			if (flag)
			{
				text = string.Format(text, this._doc.ExchangeItemStr);
			}
			base.uiBehaviour.m_Tips.SetText(text);
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._audioPlayToken);
			XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl/Except_Quiz", 1f);
			XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl/Quiz ", 1f);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(true);
			XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
			base.OnHide();
		}

		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._audioPlayToken);
			base.OnUnload();
		}

		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this._doc.QueryCloseUI();
			return true;
		}

		private void OnItemClick(IXUISprite iSp)
		{
			bool flag = this._doc.CurrentSelectUid != iSp.ID;
			if (flag)
			{
				this._doc.QuerySelectItem(iSp.ID);
			}
		}

		private bool OnEnsureBtnClick(IXUIButton btn)
		{
			this._doc.QueryEnsureExchange(!this._doc.MyEnsureState);
			return true;
		}

		public void RefreshMyChat()
		{
			bool flag = this._doc.MyAudioID == 0UL;
			if (flag)
			{
				base.uiBehaviour.m_MyInputGo.SetActive(true);
				base.uiBehaviour.m_MyVoiceBtn.SetVisible(false);
				base.uiBehaviour.m_MyInputText.SetText(this._doc.MyInputText);
			}
			else
			{
				base.uiBehaviour.m_MyInputGo.SetActive(false);
				base.uiBehaviour.m_MyVoiceBtn.SetVisible(true);
				this.OnAudioPlayClick(base.uiBehaviour.m_MyVoiceBtn);
				base.uiBehaviour.m_MyVoiceText.SetText(this._doc.MyInputText);
			}
		}

		public void RefreshOtherChat()
		{
			bool flag = this._doc.OtherAudioID == 0UL;
			if (flag)
			{
				base.uiBehaviour.m_OtherInputGo.SetActive(true);
				base.uiBehaviour.m_OtherVoiceBtn.SetVisible(false);
				base.uiBehaviour.m_OtherInputText.SetText(this._doc.OtherInputText);
			}
			else
			{
				base.uiBehaviour.m_OtherInputGo.SetActive(false);
				base.uiBehaviour.m_OtherVoiceBtn.SetVisible(true);
				this.OnAudioPlayClick(base.uiBehaviour.m_OtherVoiceBtn);
				base.uiBehaviour.m_OtherVoiceText.SetText(this._doc.OtherInputText);
			}
		}

		private void OnAudioPlayClick(IXUISprite iSp)
		{
			XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
			base.uiBehaviour.m_MyVoiceAni.StopAndReset();
			base.uiBehaviour.m_OtherVoiceAni.StopAndReset();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._audioPlayToken);
			bool flag = iSp.ID == 0UL;
			if (flag)
			{
				XSingleton<XChatIFlyMgr>.singleton.StartPlayAudioId(this._doc.MyAudioID);
				base.uiBehaviour.m_MyVoiceAni.Reset();
				this._audioPlayToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._doc.MyAudioTime / 1000f, new XTimerMgr.ElapsedEventHandler(this.OnPlayEnd), null);
				XSingleton<XDebug>.singleton.AddLog("exchange my voice time = ", this._doc.MyAudioTime.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				XSingleton<XChatIFlyMgr>.singleton.StartPlayAudioId(this._doc.OtherAudioID);
				base.uiBehaviour.m_OtherVoiceAni.Reset();
				this._audioPlayToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._doc.OtherAudioTime / 1000f, new XTimerMgr.ElapsedEventHandler(this.OnPlayEnd), null);
				XSingleton<XDebug>.singleton.AddLog("exchange other voice time = ", this._doc.OtherAudioTime.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		private void OnPlayEnd(object o = null)
		{
			base.uiBehaviour.m_MyVoiceAni.StopAndReset();
			base.uiBehaviour.m_OtherVoiceAni.StopAndReset();
		}

		private bool OnInputBtnClick(IXUIButton btn)
		{
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.ShowChatInput(new ChatInputStringBack(this.OnInputStringGet));
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.SetInputType(ChatInputType.TEXT);
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.SetCharacterLimit(50);
			return true;
		}

		public void OnInputStringGet(string str)
		{
			XSingleton<XDebug>.singleton.AddLog("Player input string is ", str, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.SendChat(str, 0UL, 0U);
		}

		private void OnVoiceButtonDrag(IXUIButton sp, Vector2 delta)
		{
			this.m_DragDistance += delta;
			bool flag = this.m_DragDistance.magnitude >= 100f;
			if (flag)
			{
				this.m_CancelRecord = true;
			}
			else
			{
				this.m_CancelRecord = false;
			}
		}

		private void OnVoiceButton(IXUIButton sp, bool state)
		{
			if (state)
			{
				this.m_CancelRecord = false;
				XSingleton<XDebug>.singleton.AddLog("Press down", null, null, null, null, null, XDebugColor.XDebug_None);
				this.m_DragDistance = Vector2.zero;
				bool answerUseApollo = XChatDocument.m_AnswerUseApollo;
				if (answerUseApollo)
				{
					XSingleton<XChatApolloMgr>.singleton.StartRecord(VoiceUsage.GUILDCOLLECT, null);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StartRecord(VoiceUsage.GUILDCOLLECT, null);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Press up", null, null, null, null, null, XDebugColor.XDebug_None);
				DlgBase<XChatView, XChatBehaviour>.singleton.SetActiveChannel(ChatChannelType.Team);
				bool answerUseApollo2 = XChatDocument.m_AnswerUseApollo;
				if (answerUseApollo2)
				{
					XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				this.m_CancelRecord = false;
			}
		}

		private XExchangeItemDocument _doc = null;

		private readonly int COLNUM = 4;

		private Vector2 m_DragDistance = Vector2.zero;

		private bool m_CancelRecord = false;

		private uint _audioPlayToken;
	}
}
