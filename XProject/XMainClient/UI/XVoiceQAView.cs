using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018D2 RID: 6354
	internal class XVoiceQAView : DlgBase<XVoiceQAView, XVoiceQABehaviour>
	{
		// Token: 0x17003A62 RID: 14946
		// (get) Token: 0x060108DF RID: 67807 RVA: 0x004116E4 File Offset: 0x0040F8E4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A63 RID: 14947
		// (get) Token: 0x060108E0 RID: 67808 RVA: 0x004116F8 File Offset: 0x0040F8F8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A64 RID: 14948
		// (get) Token: 0x060108E1 RID: 67809 RVA: 0x0041170C File Offset: 0x0040F90C
		public override string fileName
		{
			get
			{
				return "GameSystem/AnswerDlg";
			}
		}

		// Token: 0x060108E2 RID: 67810 RVA: 0x00411724 File Offset: 0x0040F924
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			this._audioList.Clear();
			base.uiBehaviour.m_RankPool.ReturnAll(false);
			this.m_RankName.Clear();
			this.m_RankNum.Clear();
			for (int i = 0; i < XVoiceQAView.RANKSHOWNUMBER; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RankPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(-10f, (float)(161 - 35 * i), 0f);
				IXUILabel ixuilabel = gameObject.transform.Find("name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("num").GetComponent("XUILabel") as IXUILabel;
				this.m_RankName.Add(ixuilabel);
				this.m_RankNum.Add(ixuilabel2);
				bool flag = i < 3;
				if (flag)
				{
					ixuilabel.SetColor(new Color(255f, 255f, 0f, 255f));
					ixuilabel2.SetColor(new Color(255f, 255f, 0f, 255f));
				}
			}
			IXUILabel item = base.uiBehaviour.m_MultipleGo.transform.Find("ScoreRank/rank/myRank/num").GetComponent("XUILabel") as IXUILabel;
			this.m_RankNum.Add(item);
		}

		// Token: 0x060108E3 RID: 67811 RVA: 0x004118B8 File Offset: 0x0040FAB8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_ExitVoiceQA.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_SingleWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapListInit));
			base.uiBehaviour.m_MultiWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapListInit));
			base.uiBehaviour.m_SingleWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DesWrapListUpdated));
			base.uiBehaviour.m_MultiWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DesWrapListUpdated));
			base.uiBehaviour.m_SpeakBtn.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnVoiceButton));
			base.uiBehaviour.m_SpeakBtn.RegisterDragEventHandler(new ButtonDragEventHandler(this.OnVoiceButtonDrag));
			base.uiBehaviour.m_NextQuestion.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnNextQuestionBtnClick));
			base.uiBehaviour.m_AutoPlay.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnAutoPlayBtnClick));
			base.uiBehaviour.m_Input.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnInputBtnClick));
		}

		// Token: 0x060108E4 RID: 67812 RVA: 0x00411A0C File Offset: 0x0040FC0C
		private void SetTimesLabel(IXUILabel label, uint times)
		{
			label.SetText(XStringDefineProxy.GetString(string.Format("Multiple_times_{0}", times)));
		}

		// Token: 0x060108E5 RID: 67813 RVA: 0x00411A2C File Offset: 0x0040FC2C
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl/Except_Quiz", 0f);
			XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl/Quiz ", 1f);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(false);
			XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(false);
			this._doc.GetReward();
			base.uiBehaviour.m_AutoPlay.gameObject.SetActive(true);
			base.uiBehaviour.m_SingleGo.SetActive(this._doc.CurrentType == 1U);
			base.uiBehaviour.m_MultipleGo.SetActive(this._doc.CurrentType != 1U);
			bool flag = this._doc.CurrentType == 2U;
			if (flag)
			{
				DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.SetVisible(false, true);
			}
			this.RefreshList();
			this._doc.SendQueryVoiceQAInfo();
			bool flag2 = !XSingleton<XClientNetwork>.singleton.IsWifiEnable() && XSingleton<XChatIFlyMgr>.singleton.IsChannelAutoPlayEnable(ChatChannelType.ZeroChannel);
			if (flag2)
			{
				this._doc.IsAutoPlay = false;
			}
			base.uiBehaviour.m_AutoPlay.bChecked = this._doc.IsAutoPlay;
			this.OnAutoPlayBtnClick(base.uiBehaviour.m_AutoPlay);
			this.RefreshPage(this._startid, this._startindex, this._starttime);
		}

		// Token: 0x060108E6 RID: 67814 RVA: 0x00411B8C File Offset: 0x0040FD8C
		private bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x060108E7 RID: 67815 RVA: 0x00411BA8 File Offset: 0x0040FDA8
		private bool OnInputBtnClick(IXUIButton btn)
		{
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.ShowChatInput(new ChatInputStringBack(this.OnInputStringGet));
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.SetInputType(ChatInputType.TEXT);
			DlgBase<XChatInputView, XChatInputBehaviour>.singleton.SetCharacterLimit(50);
			return true;
		}

		// Token: 0x060108E8 RID: 67816 RVA: 0x00411BEB File Offset: 0x0040FDEB
		public void OnInputStringGet(string str)
		{
			XSingleton<XDebug>.singleton.AddLog("Player input string is ", str, null, null, null, null, XDebugColor.XDebug_None);
			this._doc.SendAnswer(str, 0UL, 0U);
		}

		// Token: 0x060108E9 RID: 67817 RVA: 0x00411C14 File Offset: 0x0040FE14
		private bool OnAutoPlayBtnClick(IXUICheckBox iCheckBox)
		{
			bool flag = iCheckBox.bChecked && !XSingleton<XClientNetwork>.singleton.IsWifiEnable();
			if (flag)
			{
				bool flag2 = XSingleton<XChatIFlyMgr>.singleton.IsChannelAutoPlayEnable(ChatChannelType.ZeroChannel);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("VoiceQA_AutoPlay_Error"), XStringDefineProxy.GetString("COMMON_OK"));
					iCheckBox.bChecked = false;
					return true;
				}
			}
			this._doc.IsAutoPlay = iCheckBox.bChecked;
			bool flag3 = !this._doc.IsAutoPlay;
			if (flag3)
			{
				bool flag4 = !this.currPlayAudioIsMy;
				if (flag4)
				{
					XSingleton<XAudioMgr>.singleton.StopUISound();
					XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
					this.currPlayAudio = XVoiceQAView.UNPLAY;
				}
				this._audioList.Clear();
			}
			return true;
		}

		// Token: 0x060108EA RID: 67818 RVA: 0x00411CE4 File Offset: 0x0040FEE4
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

		// Token: 0x060108EB RID: 67819 RVA: 0x00411D30 File Offset: 0x0040FF30
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
					XSingleton<XChatApolloMgr>.singleton.StartRecord(VoiceUsage.ANSWER, null);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StartRecord(VoiceUsage.ANSWER, null);
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

		// Token: 0x060108EC RID: 67820 RVA: 0x00411DEC File Offset: 0x0040FFEC
		public void VoiceQAStart(double time)
		{
			base.uiBehaviour.m_Start.SetActive(true);
			base.uiBehaviour.m_Ongoing.SetActive(false);
			base.uiBehaviour.m_End.SetActive(false);
			bool isFirstOpenUI = this._doc.IsFirstOpenUI;
			if (isFirstOpenUI)
			{
				this._doc.IsFirstOpenUI = false;
				this.DealWithAudio(new VoiceQAAudio
				{
					isTips = true,
					tipsType = VoiceQATipsType.WELCOME
				}, QAAudioPriority.URGEN);
			}
			bool flag = this._doc.CurrentType != 1U;
			if (flag)
			{
				base.uiBehaviour.m_RankScrollView.ResetPosition();
			}
			IXUILabel ixuilabel = base.uiBehaviour.m_Start.transform.Find("label").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("VoiceQA_Start_Description_" + this._doc.CurrentType.ToString()));
			this.timeLabel = (base.uiBehaviour.m_Start.transform.Find("time").GetComponent("XUILabel") as IXUILabel);
			this.SetTime((double)(DateTime.Now.Ticks / 10000000L) + time, false);
		}

		// Token: 0x060108ED RID: 67821 RVA: 0x00411F38 File Offset: 0x00410138
		public void SetQuestion(int id, uint index, bool isNew = true, double time = 0.0)
		{
			base.uiBehaviour.m_Start.SetActive(false);
			base.uiBehaviour.m_Ongoing.SetActive(true);
			base.uiBehaviour.m_End.SetActive(false);
			base.uiBehaviour.m_NextQuestion.gameObject.SetActive(this._doc.CurrentType == 1U);
			base.uiBehaviour.m_Right.SetActive(this._doc.IsNowDesRight);
			this._audioList.Clear();
			if (isNew)
			{
				VoiceQAAudio voiceQAAudio = new VoiceQAAudio();
				voiceQAAudio.isTips = true;
				voiceQAAudio.signTime = Time.time + 1000f;
				bool flag = id == 1;
				if (flag)
				{
					voiceQAAudio.tipsType = VoiceQATipsType.START;
					this.DealWithAudio(voiceQAAudio, QAAudioPriority.URGEN);
				}
				else
				{
					voiceQAAudio.tipsType = VoiceQATipsType.NEXT;
					this.DealWithAudio(voiceQAAudio, (this._doc.CurrentType == 1U) ? QAAudioPriority.AFTER : QAAudioPriority.URGEN);
				}
			}
			bool flag2 = this._doc.CurrentType != 1U;
			if (flag2)
			{
				this.RefreshList();
			}
			QuestionLibraryTable.RowData byID = this._doc.QuestionTable.GetByID((int)index);
			base.uiBehaviour.m_QuesDesc.SetText(byID.Question);
			base.uiBehaviour.m_QuesNum.SetText(string.Format(XStringDefineProxy.GetString("VoiceQA_QuestionNumber"), id));
			base.uiBehaviour.m_Reward.InputText = XLabelSymbolHelper.FormatCostWithIcon((int)this._doc.Reward[0, 1], (ItemEnum)this._doc.Reward[0, 0]);
			this.timeLabel = (base.uiBehaviour.m_Ongoing.transform.Find("message/time").GetComponent("XUILabel") as IXUILabel);
			if (isNew)
			{
				QuestionLibraryTable.RowData byID2 = this._doc.QuestionTable.GetByID((int)index);
				this.SetTime((double)(DateTime.Now.Ticks / 10000000L + (long)byID2.TimeLimit), false);
			}
			else
			{
				this.SetTime((double)(DateTime.Now.Ticks / 10000000L) + time, false);
			}
		}

		// Token: 0x060108EE RID: 67822 RVA: 0x0041216C File Offset: 0x0041036C
		public void VoiceQAEnd(uint questionNum, uint rightNum, List<ItemBrief> list)
		{
			base.uiBehaviour.m_Start.SetActive(false);
			base.uiBehaviour.m_Ongoing.SetActive(false);
			base.uiBehaviour.m_End.SetActive(true);
			VoiceQAAudio voiceQAAudio = new VoiceQAAudio();
			voiceQAAudio.isTips = true;
			voiceQAAudio.tipsType = VoiceQATipsType.OVER;
			this._audioList.Clear();
			this.DealWithAudio(voiceQAAudio, QAAudioPriority.URGEN);
			base.uiBehaviour.m_AutoPlay.gameObject.SetActive(false);
			IXUILabel ixuilabel = base.uiBehaviour.m_End.transform.Find("label").GetComponent("XUILabel") as IXUILabel;
			IXUILabelSymbol ixuilabelSymbol = base.uiBehaviour.m_End.transform.Find("reward").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			ixuilabelSymbol.gameObject.SetActive(questionNum > 0U);
			bool flag = questionNum > 0U;
			if (flag)
			{
				string text = "";
				for (int i = 0; i < list.Count; i++)
				{
					text += XLabelSymbolHelper.FormatCostWithIcon((int)list[i].itemCount, (ItemEnum)list[i].itemID);
				}
				ixuilabelSymbol.InputText = text;
				ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("VoiceQA_End_Description1"), questionNum, rightNum));
			}
			else
			{
				ixuilabel.SetText(XStringDefineProxy.GetString("VoiceQA_End_Description2"));
			}
			this.timeLabel = (base.uiBehaviour.m_End.transform.Find("time").GetComponent("XUILabel") as IXUILabel);
			this.SetTime((double)(DateTime.Now.Ticks / 10000000L + 30L), true);
		}

		// Token: 0x060108EF RID: 67823 RVA: 0x0041233C File Offset: 0x0041053C
		private bool OnNextQuestionBtnClick(IXUIButton btn)
		{
			XSingleton<XAudioMgr>.singleton.StopUISound();
			XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
			this.currPlayAudioIsMy = false;
			this._audioList.Clear();
			this._doc.NextQuestionQuery();
			return true;
		}

		// Token: 0x060108F0 RID: 67824 RVA: 0x00412384 File Offset: 0x00410584
		private void OnAudioButtonClick(IXUISprite iSp)
		{
			this.DealWithAudio(new VoiceQAAudio
			{
				isTips = false,
				audioID = this._doc.AnswerList[(int)iSp.ID].audioID,
				audioTime = this._doc.AnswerList[(int)iSp.ID].audioTime
			}, QAAudioPriority.URGEN);
		}

		// Token: 0x060108F1 RID: 67825 RVA: 0x004123F0 File Offset: 0x004105F0
		private void AudioPlayEnd(object obj)
		{
			this.currPlayAudioIsMy = false;
			bool flag = this.playingAni != null;
			if (flag)
			{
				this.playingAni.StopAndReset();
				this.playingAni = null;
			}
			this.PlayAudioList();
		}

		// Token: 0x060108F2 RID: 67826 RVA: 0x00412430 File Offset: 0x00410630
		public void SetTime(double _targetTime, bool _isEndTime = false)
		{
			this.isEndTime = _isEndTime;
			this.targetTime = _targetTime;
			bool flag = this.targetTime > 10.0;
			if (flag)
			{
				this.timeLabel.SetColor(XVoiceQAView.greenColor);
				this.isGreenColor = true;
			}
			else
			{
				this.timeLabel.SetColor(XVoiceQAView.redColor);
				this.isGreenColor = false;
			}
		}

		// Token: 0x060108F3 RID: 67827 RVA: 0x00412497 File Offset: 0x00410697
		private void WrapListInit(Transform t, int i)
		{
			this.aniArr[i] = (t.Find("voice/board/sign").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation);
		}

		// Token: 0x060108F4 RID: 67828 RVA: 0x004124BC File Offset: 0x004106BC
		private void DesWrapListUpdated(Transform t, int i)
		{
			bool flag = this._doc.AnswerList[i].roleId == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			IXUILabel ixuilabel = t.Find("time").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)this._doc.AnswerList[i].answerTime, 3, 3, 4, false, true));
			IXUILabel ixuilabel2 = t.Find("voice/content").GetComponent("XUILabel") as IXUILabel;
			string text = this._doc.AnswerList[i].content;
			int num = (this._doc.CurrentType == 1U) ? 23 : 48;
			bool flag2 = text.Length > num;
			if (flag2)
			{
				text = text.Substring(0, num);
			}
			ixuilabel2.SetText(text);
			bool flag3 = this._doc.CurrentType != 1U;
			if (flag3)
			{
				Vector3 localPosition = ixuilabel2.gameObject.transform.localPosition;
				localPosition.y = (float)((ixuilabel2.spriteHeight > 30) ? -41 : -50);
				ixuilabel2.gameObject.transform.localPosition = localPosition;
			}
			GameObject gameObject = t.Find("voice/board").gameObject;
			gameObject.SetActive(this._doc.AnswerList[i].audioID > 0UL);
			bool flag4 = this._doc.CurrentType != 1U;
			if (flag4)
			{
				IXUIButton ixuibutton = t.Find("voice/flower").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.gameObject.SetActive(!flag && this._doc.AnswerList[i].audioID > 0UL);
				ixuibutton.ID = this._doc.AnswerList[i].roleId;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendFlowerClicked));
			}
			bool flag5 = this._doc.AnswerList[i].audioID > 0UL;
			if (flag5)
			{
				IXUILabel ixuilabel3 = t.Find("voice/board/time").GetComponent("XUILabel") as IXUILabel;
				ixuilabel3.SetText(((this._doc.AnswerList[i].audioTime < 1000U) ? 1U : (this._doc.AnswerList[i].audioTime / 1000U)).ToString() + "''");
				IXUISprite ixuisprite = t.Find("voice/board").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)i);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAudioButtonClick));
				IXUISpriteAnimation ixuispriteAnimation = ixuisprite.gameObject.transform.Find("sign").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
				ixuispriteAnimation.ID = this._doc.AnswerList[i].audioID;
				bool flag6 = this._doc.AnswerList[i].audioID == this.currPlayAudio;
				if (flag6)
				{
					ixuispriteAnimation.Reset();
					this.playingAni = ixuispriteAnimation;
				}
				else
				{
					ixuispriteAnimation.StopAndReset();
				}
			}
			bool flag7 = flag;
			if (flag7)
			{
				IXUISprite ixuisprite2 = t.Find("R/head").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)this._doc.AnswerList[i].profession);
			}
			else
			{
				IXUISprite ixuisprite3 = t.Find("L/head").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)this._doc.AnswerList[i].profession);
			}
			GameObject gameObject2 = t.Find("voice/right").gameObject;
			gameObject2.SetActive(this._doc.AnswerList[i].right);
			bool right = this._doc.AnswerList[i].right;
			if (right)
			{
				bool isNew = this._doc.AnswerList[i].isNew;
				if (isNew)
				{
					IXUITweenTool ixuitweenTool = gameObject2.GetComponent("XUIPlayTween") as IXUITweenTool;
					ixuitweenTool.PlayTween(true, -1f);
				}
				bool flag8 = this._doc.AnswerList[i].isNew && flag && this._doc.CurrentType != 1U && !this._doc.IsNowDesRight;
				if (flag8)
				{
					this._doc.IsNowDesRight = true;
					base.uiBehaviour.m_Right.SetActive(true);
					IXUITweenTool ixuitweenTool2 = base.uiBehaviour.m_Right.GetComponent("XUIPlayTween") as IXUITweenTool;
					ixuitweenTool2.PlayTween(true, -1f);
				}
			}
			GameObject gameObject3 = t.Find("reward").gameObject;
			gameObject3.SetActive(this._doc.AnswerList[i].times > 0U);
			bool flag9 = this._doc.AnswerList[i].times > 0U;
			if (flag9)
			{
				IXUILabelSymbol ixuilabelSymbol = t.Find("reward/item").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				ixuilabelSymbol.InputText = XLabelSymbolHelper.FormatCostWithIcon((int)(this._doc.Reward[0, 1] * this._doc.AnswerList[i].times), (ItemEnum)this._doc.Reward[0, 0]);
				IXUILabel ixuilabel4 = t.Find("reward/times").GetComponent("XUILabel") as IXUILabel;
				bool flag10 = this._doc.AnswerList[i].times > 1U;
				if (flag10)
				{
					ixuilabel4.gameObject.SetActive(true);
					this.SetTimesLabel(ixuilabel4, this._doc.AnswerList[i].times);
				}
				else
				{
					ixuilabel4.gameObject.SetActive(false);
				}
			}
			bool flag11 = this._doc.CurrentType != 1U;
			if (flag11)
			{
				GameObject gameObject4 = t.Find("R").gameObject;
				GameObject gameObject5 = t.Find("L").gameObject;
				gameObject4.SetActive(flag);
				gameObject5.SetActive(!flag);
				GameObject gameObject6 = t.Find("name").gameObject;
				gameObject6.SetActive(flag);
				GameObject gameObject7 = t.Find("name2").gameObject;
				gameObject7.SetActive(!flag);
				GameObject gameObject8 = t.Find("voice").gameObject;
				IXUILabel ixuilabel5 = t.Find("enter").GetComponent("XUILabel") as IXUILabel;
				gameObject8.SetActive(!this._doc.AnswerList[i].isEnterRoom);
				ixuilabel5.gameObject.SetActive(this._doc.AnswerList[i].isEnterRoom);
				bool isEnterRoom = this._doc.AnswerList[i].isEnterRoom;
				if (isEnterRoom)
				{
					bool flag12 = flag;
					if (flag12)
					{
						ixuilabel5.SetText(XStringDefineProxy.GetString("ME") + XStringDefineProxy.GetString("VoiceQA_EnterRoomInfo"));
					}
					else
					{
						ixuilabel5.SetText(this._doc.AnswerList[i].name + XStringDefineProxy.GetString("VoiceQA_EnterRoomInfo"));
					}
				}
				bool flag13 = !flag;
				if (flag13)
				{
					IXUILabelSymbol ixuilabelSymbol2 = gameObject7.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					string inputText = XSingleton<UiUtility>.singleton.SetChatCoverDesignation(this._doc.AnswerList[i].name, this._doc.AnswerList[i].desID, false);
					ixuilabelSymbol2.InputText = inputText;
				}
				GameObject gameObject9 = t.Find("quickreward").gameObject;
				int rank = (int)this._doc.AnswerList[i].rank;
				gameObject9.SetActive(rank != 0 && rank <= this._doc.ExtraReward.Count);
				bool flag14 = rank != 0 && rank <= this._doc.ExtraReward.Count;
				if (flag14)
				{
					IXUILabel ixuilabel6 = gameObject9.transform.Find("label").GetComponent("XUILabel") as IXUILabel;
					bool flag15 = rank == 1;
					if (flag15)
					{
						ixuilabel6.SetText(XStringDefineProxy.GetString("VoiceQA_quick_1"));
					}
					else
					{
						ixuilabel6.SetText(XStringDefineProxy.GetString("VoiceQA_quick_2"));
					}
					IXUILabelSymbol ixuilabelSymbol3 = gameObject9.transform.Find("item").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					ixuilabelSymbol3.InputText = XLabelSymbolHelper.FormatCostWithIcon((int)this._doc.ExtraReward[rank - 1, 1], (ItemEnum)this._doc.ExtraReward[rank - 1, 0]);
				}
			}
			bool isNew2 = this._doc.AnswerList[i].isNew;
			if (isNew2)
			{
				this._doc.AnswerList[i].isNew = false;
				bool flag16 = !this._doc.AnswerList[i].isEnterRoom;
				if (flag16)
				{
					bool flag17 = this._doc.AnswerList[i].audioID > 0UL;
					if (flag17)
					{
						bool flag18 = flag;
						if (flag18)
						{
							VoiceQAAudio voiceQAAudio = new VoiceQAAudio();
							voiceQAAudio.isTips = false;
							voiceQAAudio.audioID = this._doc.AnswerList[i].audioID;
							voiceQAAudio.audioTime = this._doc.AnswerList[i].audioTime;
							this.currPlayAudioIsMy = true;
							this.DealWithAudio(voiceQAAudio, QAAudioPriority.URGEN);
						}
						else
						{
							bool isAutoPlay = this._doc.IsAutoPlay;
							if (isAutoPlay)
							{
								this.DealWithAudio(new VoiceQAAudio
								{
									isTips = false,
									audioID = this._doc.AnswerList[i].audioID,
									audioTime = this._doc.AnswerList[i].audioTime,
									signTime = Time.time + XVoiceQAView.AUDIODELAYPLAYTIME
								}, QAAudioPriority.AFTER);
							}
						}
					}
					bool flag19 = flag && this._doc.AnswerList[i].right;
					if (flag19)
					{
						this.DealWithAudio(new VoiceQAAudio
						{
							isTips = true,
							tipsType = VoiceQATipsType.RIGHT,
							signTime = Time.time + 1000f
						}, QAAudioPriority.BEFORE);
					}
				}
			}
		}

		// Token: 0x060108F5 RID: 67829 RVA: 0x00412FB4 File Offset: 0x004111B4
		public void RefreshRank()
		{
			int num = Math.Min(this._doc.ScoreList.Count, XVoiceQAView.RANKSHOWNUMBER);
			for (int i = 0; i < num; i++)
			{
				this.m_RankName[i].gameObject.transform.parent.gameObject.SetActive(true);
				this.m_RankName[i].SetText(string.Format("{0}.{1}", i + 1, this._doc.GetPlayerNameByRoleID(this._doc.ScoreList[i].uuid)));
				this.m_RankNum[i].SetText(this._doc.ScoreList[i].score.ToString());
			}
			for (int j = num; j < XVoiceQAView.RANKSHOWNUMBER; j++)
			{
				this.m_RankName[j].gameObject.transform.parent.gameObject.SetActive(false);
			}
			this.m_RankNum[XVoiceQAView.RANKSHOWNUMBER].SetText(this._doc.MyScore.ToString());
		}

		// Token: 0x060108F6 RID: 67830 RVA: 0x004130FC File Offset: 0x004112FC
		public void RefreshPage(int id, uint index, double time)
		{
			this._startid = id;
			this._startindex = index;
			this._starttime = time;
			base.uiBehaviour.m_Title.SetText(XStringDefineProxy.GetString("VoiceQA_Title" + this._doc.CurrentType.ToString()));
			bool flag = id == 0;
			if (flag)
			{
				this.VoiceQAStart(time);
			}
			else
			{
				this.SetQuestion(id, index, false, time);
			}
			this.RefreshList();
		}

		// Token: 0x060108F7 RID: 67831 RVA: 0x00413178 File Offset: 0x00411378
		public void RefreshList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this._doc.CurrentType == 1U;
				IXUIScrollView ixuiscrollView;
				IXUIWrapContent ixuiwrapContent;
				if (flag2)
				{
					ixuiscrollView = base.uiBehaviour.m_SingleSrcollView;
					ixuiwrapContent = base.uiBehaviour.m_SingleWrapContent;
				}
				else
				{
					ixuiscrollView = base.uiBehaviour.m_MultiSrollView;
					ixuiwrapContent = base.uiBehaviour.m_MultiWrapContent;
				}
				int num = Mathf.Min(this._doc.AnswerList.Count, ixuiwrapContent.maxItemCount);
				for (int i = num; i < 5; i++)
				{
					this.aniArr[i] = null;
				}
				ixuiwrapContent.SetContentCount(this._doc.AnswerList.Count, false);
				bool flag3 = this._doc.AnswerList.Count < 3;
				if (flag3)
				{
					ixuiscrollView.SetPosition(0f);
				}
				else
				{
					ixuiscrollView.NeedRecalcBounds();
					ixuiscrollView.SetPosition(1f);
				}
			}
		}

		// Token: 0x060108F8 RID: 67832 RVA: 0x00413274 File Offset: 0x00411474
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.timeLabel == null;
			if (!flag)
			{
				int num = (int)(this.targetTime - (double)(DateTime.Now.Ticks / 10000000L));
				bool flag2 = num < 0;
				if (flag2)
				{
					num = 0;
				}
				bool flag3 = !this.isEndTime && this.isGreenColor && num <= 10;
				if (flag3)
				{
					this.timeLabel.SetColor(XVoiceQAView.redColor);
					this.isGreenColor = false;
				}
				bool flag4 = this.isEndTime;
				if (flag4)
				{
					bool flag5 = num == 0;
					if (flag5)
					{
						this.timeLabel = null;
						this.SetVisible(false, true);
					}
					else
					{
						this.timeLabel.SetText(num.ToString());
					}
				}
				else
				{
					this.timeLabel.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(num, 2, 2, 4, false, true));
				}
			}
		}

		// Token: 0x060108F9 RID: 67833 RVA: 0x0041335C File Offset: 0x0041155C
		private bool OnSendFlowerClicked(IXUIButton btn)
		{
			ulong id = btn.ID;
			string playerNameByRoleID = this._doc.GetPlayerNameByRoleID(id);
			DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.ShowBoard(id, playerNameByRoleID);
			return true;
		}

		// Token: 0x060108FA RID: 67834 RVA: 0x00413390 File Offset: 0x00411590
		public void DealWithAudio(VoiceQAAudio audio, QAAudioPriority pro)
		{
			bool flag = pro == QAAudioPriority.URGEN;
			if (flag)
			{
				bool flag2 = this.currPlayAudio == XVoiceQAView.SYSTEMTIPS;
				if (flag2)
				{
					XSingleton<XAudioMgr>.singleton.StopUISound();
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
				}
				this.currPlayAudioIsMy = false;
				this.PlayAudio(audio);
			}
			else
			{
				bool flag3 = pro == QAAudioPriority.BEFORE;
				if (flag3)
				{
					this._audioList.AddFirst(audio);
				}
				else
				{
					this._audioList.AddLast(audio);
				}
				bool flag4 = this.currPlayAudio == XVoiceQAView.UNPLAY;
				if (flag4)
				{
					this.PlayAudioList();
				}
			}
		}

		// Token: 0x060108FB RID: 67835 RVA: 0x00413424 File Offset: 0x00411624
		private void PlayAudio(VoiceQAAudio audio)
		{
			bool flag = this.playingAni != null;
			if (flag)
			{
				this.playingAni.StopAndReset();
				this.playingAni = null;
			}
			float interval = 0f;
			bool isTips = audio.isTips;
			if (isTips)
			{
				this.currPlayAudio = XVoiceQAView.SYSTEMTIPS;
				switch (audio.tipsType)
				{
				case VoiceQATipsType.WELCOME:
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/VO/QuizGame_welcome", true, AudioChannel.Action);
					interval = 4.885f;
					break;
				case VoiceQATipsType.RIGHT:
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/VO/QuizGame_right", true, AudioChannel.Action);
					interval = 1.646f;
					break;
				case VoiceQATipsType.START:
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/VO/QuizGame_start", true, AudioChannel.Action);
					interval = 3.964f;
					break;
				case VoiceQATipsType.NEXT:
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/VO/QuizGame_next", true, AudioChannel.Action);
					interval = 0.683f;
					break;
				case VoiceQATipsType.OVER:
					XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/VO/QuizGame_over2", true, AudioChannel.Action);
					interval = 3.809f;
					break;
				}
			}
			else
			{
				this.currPlayAudio = audio.audioID;
				ulong audioID = audio.audioID;
				XSingleton<XChatIFlyMgr>.singleton.StartPlayAudioId(audioID);
				interval = audio.audioTime / 1000f;
				for (int i = 0; i < 5; i++)
				{
					bool flag2 = this.aniArr[i] == null;
					if (!flag2)
					{
						bool flag3 = !this.aniArr[i].gameObject.activeSelf;
						if (!flag3)
						{
							bool flag4 = this.aniArr[i].ID == audio.audioID;
							if (flag4)
							{
								this.aniArr[i].Reset();
								this.playingAni = this.aniArr[i];
							}
							else
							{
								this.aniArr[i].StopAndReset();
							}
						}
					}
				}
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
			this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.AudioPlayEnd), null);
		}

		// Token: 0x060108FC RID: 67836 RVA: 0x00413620 File Offset: 0x00411820
		private void PlayAudioList()
		{
			bool flag = this._audioList.Count == 0;
			if (flag)
			{
				this.currPlayAudio = XVoiceQAView.UNPLAY;
			}
			else
			{
				while (this._audioList.Count != 0)
				{
					VoiceQAAudio value = this._audioList.First.Value;
					this._audioList.RemoveFirst();
					bool flag2 = value.signTime > Time.time;
					if (flag2)
					{
						this.PlayAudio(value);
						break;
					}
				}
			}
		}

		// Token: 0x060108FD RID: 67837 RVA: 0x0041369D File Offset: 0x0041189D
		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			base.OnUnload();
		}

		// Token: 0x060108FE RID: 67838 RVA: 0x004136C4 File Offset: 0x004118C4
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl/Except_Quiz", 1f);
			XSingleton<XAudioMgr>.singleton.SetBusStatuMute("bus:/MainGroupControl/Quiz ", 1f);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			XSingleton<XChatIFlyMgr>.singleton.EnableAutoPlay(true);
			this.timeLabel = null;
			XSingleton<XAudioMgr>.singleton.StopUISound();
			XSingleton<XChatIFlyMgr>.singleton.StopAutoPlay();
			this.currPlayAudioIsMy = false;
			this._audioList.Clear();
			this.currPlayAudio = XVoiceQAView.UNPLAY;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
			this.OnRemoveAllQACache();
		}

		// Token: 0x060108FF RID: 67839 RVA: 0x00413770 File Offset: 0x00411970
		private void OnRemoveAllQACache()
		{
			bool flag = XChatDocument.is_delete_audio && XSingleton<XChatIFlyMgr>.singleton.NeedClear();
			if (flag)
			{
				XSingleton<XChatIFlyMgr>.singleton.ClearAudioCache();
			}
		}

		// Token: 0x040077FA RID: 30714
		private XVoiceQADocument _doc = null;

		// Token: 0x040077FB RID: 30715
		private Vector2 m_DragDistance = Vector2.zero;

		// Token: 0x040077FC RID: 30716
		private bool m_CancelRecord = false;

		// Token: 0x040077FD RID: 30717
		private IXUILabel timeLabel;

		// Token: 0x040077FE RID: 30718
		private double targetTime;

		// Token: 0x040077FF RID: 30719
		private bool isGreenColor;

		// Token: 0x04007800 RID: 30720
		private bool isEndTime = false;

		// Token: 0x04007801 RID: 30721
		private static readonly ulong UNPLAY = 10001UL;

		// Token: 0x04007802 RID: 30722
		private static readonly ulong SYSTEMTIPS = 10000UL;

		// Token: 0x04007803 RID: 30723
		private ulong currPlayAudio = XVoiceQAView.UNPLAY;

		// Token: 0x04007804 RID: 30724
		private bool currPlayAudioIsMy = false;

		// Token: 0x04007805 RID: 30725
		public List<IXUILabel> m_RankName = new List<IXUILabel>();

		// Token: 0x04007806 RID: 30726
		public List<IXUILabel> m_RankNum = new List<IXUILabel>();

		// Token: 0x04007807 RID: 30727
		private LinkedList<VoiceQAAudio> _audioList = new LinkedList<VoiceQAAudio>();

		// Token: 0x04007808 RID: 30728
		private static readonly float AUDIODELAYPLAYTIME = 10f;

		// Token: 0x04007809 RID: 30729
		private static readonly int RANKSHOWNUMBER = 20;

		// Token: 0x0400780A RID: 30730
		private uint _timerToken;

		// Token: 0x0400780B RID: 30731
		private int _startid = 0;

		// Token: 0x0400780C RID: 30732
		private uint _startindex = 0U;

		// Token: 0x0400780D RID: 30733
		private double _starttime = 0.0;

		// Token: 0x0400780E RID: 30734
		private IXUISpriteAnimation playingAni;

		// Token: 0x0400780F RID: 30735
		private IXUISpriteAnimation[] aniArr = new IXUISpriteAnimation[6];

		// Token: 0x04007810 RID: 30736
		private static readonly Color greenColor = new Color32(63, 216, 51, byte.MaxValue);

		// Token: 0x04007811 RID: 30737
		private static readonly Color redColor = new Color32(byte.MaxValue, 0, 0, byte.MaxValue);
	}
}
