using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E21 RID: 3617
	internal class XChatSmallView : DlgBase<XChatSmallView, XChatSmallBehaviour>
	{
		// Token: 0x1700340C RID: 13324
		// (get) Token: 0x0600C241 RID: 49729 RVA: 0x0029BD84 File Offset: 0x00299F84
		public override string fileName
		{
			get
			{
				return "GameSystem/ChatSmallDlg";
			}
		}

		// Token: 0x1700340D RID: 13325
		// (get) Token: 0x0600C242 RID: 49730 RVA: 0x0029BD9C File Offset: 0x00299F9C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700340E RID: 13326
		// (get) Token: 0x0600C243 RID: 49731 RVA: 0x0029BDB0 File Offset: 0x00299FB0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700340F RID: 13327
		// (get) Token: 0x0600C244 RID: 49732 RVA: 0x0029BDC4 File Offset: 0x00299FC4
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003410 RID: 13328
		// (get) Token: 0x0600C245 RID: 49733 RVA: 0x0029BDD8 File Offset: 0x00299FD8
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600C246 RID: 49734 RVA: 0x0029BDEC File Offset: 0x00299FEC
		protected override void Init()
		{
			XChatSmallView._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			XChatSmallView._doc.ChatSmallView = this;
			this.m_bForceShow = false;
			this.m_bFakeHide = false;
			base.uiBehaviour.m_ChatPool.ReturnAll(false);
			this.OnShowWindow(false);
		}

		// Token: 0x0600C247 RID: 49735 RVA: 0x0029BE40 File Offset: 0x0029A040
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowMailRedpoint();
			bool isInited = this.IsInited;
			if (isInited)
			{
				this.ShowCacheMsg();
			}
			this.SetExp();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_offToken);
			this.m_offToken = XSingleton<XTimerMgr>.singleton.SetTimer(3f, new XTimerMgr.ElapsedEventHandler(this.HanderOfflineTimer), null);
		}

		// Token: 0x0600C248 RID: 49736 RVA: 0x0029BEA8 File Offset: 0x0029A0A8
		private void HanderOfflineTimer(object o)
		{
			bool flag = !XChatSmallView.start && !this.IsInited;
			if (flag)
			{
				this.CacheMsg();
			}
		}

		// Token: 0x0600C249 RID: 49737 RVA: 0x0029BED4 File Offset: 0x0029A0D4
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_BgSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoOpenChatWindow));
			base.uiBehaviour.m_BgSpriteMini.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoOpenChatWindow));
			base.uiBehaviour.m_OpenWindow.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenMiniWindow));
			base.uiBehaviour.m_OpenWindowMini.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenMainWindow));
			base.uiBehaviour.m_sprMailRed.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(DlgBase<XChatView, XChatBehaviour>.singleton.OnMailClick));
			base.uiBehaviour.m_sprMailRed.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.TestChatMiniPress));
		}

		// Token: 0x0600C24A RID: 49738 RVA: 0x0029BF94 File Offset: 0x0029A194
		public void SetExp()
		{
			base.uiBehaviour.m_Exp.value = XSingleton<XAttributeMgr>.singleton.XPlayerData.Exp * 1f / XSingleton<XAttributeMgr>.singleton.XPlayerData.MaxExp;
			base.uiBehaviour.m_ExpValue.SetText(string.Format("{0}/{1}", XSingleton<XAttributeMgr>.singleton.XPlayerData.Exp, XSingleton<XAttributeMgr>.singleton.XPlayerData.MaxExp));
		}

		// Token: 0x0600C24B RID: 49739 RVA: 0x0029C020 File Offset: 0x0029A220
		private bool TestChatMiniPress(IXUISprite sp, bool press)
		{
			if (press)
			{
				this.presstime = Time.unscaledTime;
			}
			else
			{
				bool flag = Time.unscaledTime - this.presstime > 16f;
				if (flag)
				{
					Transform transform = base.uiBehaviour.m_contentPanel.gameObject.transform;
					int childCount = transform.childCount;
					for (int i = 0; i < childCount; i++)
					{
						Transform child = transform.GetChild(i);
						XSingleton<XDebug>.singleton.AddLog("t name:", child.name, " active:" + child.gameObject.activeSelf.ToString(), null, null, null, XDebugColor.XDebug_None);
						bool activeSelf = child.gameObject.activeSelf;
						if (activeSelf)
						{
							IXUILabel ixuilabel = child.FindChild("content").GetComponent("XUILabel") as IXUILabel;
							XSingleton<XDebug>.singleton.AddLog(child.name, "  ", ixuilabel.GetText(), null, null, null, XDebugColor.XDebug_None);
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600C24C RID: 49740 RVA: 0x0029C13C File Offset: 0x0029A33C
		public void CacheMsg()
		{
			bool flag = base.uiBehaviour == null;
			if (!flag)
			{
				bool flag2 = XChatSmallView._doc == null;
				if (flag2)
				{
					XChatSmallView._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
					XChatSmallView._doc.ChatSmallView = this;
				}
				this.OnInitHistoryMsg();
				this.last_time = Time.time;
				this.IsInited = false;
				XChatSmallView.start = true;
				base.uiBehaviour.m_ChatPool.ReturnAll(false);
				base.uiBehaviour.m_ScrollView.SetPosition(0f);
			}
		}

		// Token: 0x0600C24D RID: 49741 RVA: 0x0029C1CC File Offset: 0x0029A3CC
		public override void OnUpdate()
		{
			bool flag = XChatSmallView.start;
			if (flag)
			{
				bool flag2 = Time.time - this.last_time > 1f;
				if (flag2)
				{
					XChatSmallView.start = false;
					bool flag3 = !this.IsInited;
					if (flag3)
					{
						this.ShowPanel(true);
						XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
						bool flag4 = specificDocument != null && specificDocument.MyTeamView != null && specificDocument.MyTeamView.IsVisible();
						if (flag4)
						{
							this.ShowChatMiniUI(new ShowSettingArgs
							{
								position = 1,
								needforceshow = true,
								forceshow = true,
								needdepth = true,
								depth = 4
							});
						}
					}
					this.ShowCacheMsg();
					this.IsInited = true;
				}
			}
		}

		// Token: 0x0600C24E RID: 49742 RVA: 0x0029C294 File Offset: 0x0029A494
		public void ShowCacheMsg()
		{
			base.uiBehaviour.m_ChatPool.ReturnAll(false);
			base.uiBehaviour.m_ScrollView.SetPosition(0f);
			this.OnCleanUpChatWindow();
			this.HandleOfflineInfoQuickily();
			bool flag = !this.IsInited || XChatDocument.offlineProcessList.Count <= 0;
			if (flag)
			{
				ChatInfo chatInfo = new ChatInfo();
				chatInfo.mChannelId = ChatChannelType.World;
				chatInfo.mSenderName = "";
				chatInfo.mContent = XStringDefineProxy.GetString("CHAT_INIT");
				XChatSmallView._doc.OnReceiveChatSmallInfo(chatInfo);
			}
			bool redpoint = DlgBase<XChatView, XChatBehaviour>.singleton.HasNewFriendMsg();
			this.SetRedpoint(redpoint);
		}

		// Token: 0x0600C24F RID: 49743 RVA: 0x0029C340 File Offset: 0x0029A540
		public void ShowCurrTempMsg(string content, string name = "")
		{
			bool flag = this.IsInited && base.IsVisible() && !string.IsNullOrEmpty(name);
			if (flag)
			{
				ChatInfo chatInfo = new ChatInfo();
				chatInfo.mChannelId = ChatChannelType.Curr;
				chatInfo.mSenderName = name;
				chatInfo.mContent = content;
				XChatSmallView._doc.OnReceiveChatSmallInfo(chatInfo);
			}
		}

		// Token: 0x0600C250 RID: 49744 RVA: 0x0029C398 File Offset: 0x0029A598
		public void SetScrollView(object obj)
		{
			bool flag = base.IsLoaded() && base.IsVisible();
			if (flag)
			{
				this.SetPivot();
			}
		}

		// Token: 0x0600C251 RID: 49745 RVA: 0x0029C3C4 File Offset: 0x0029A5C4
		protected override void OnUnload()
		{
			XChatSmallView._doc = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_offToken);
			base.OnUnload();
		}

		// Token: 0x0600C252 RID: 49746 RVA: 0x0029C3E8 File Offset: 0x0029A5E8
		public void OnShowWindow(bool ismini)
		{
			this.m_ShowMini = ismini;
			if (ismini)
			{
				base.uiBehaviour.m_BgSpriteMain.SetVisible(false);
				base.uiBehaviour.m_BgSpriteMini.SetVisible(true);
			}
			else
			{
				base.uiBehaviour.m_BgSpriteMain.SetVisible(true);
				base.uiBehaviour.m_BgSpriteMini.SetVisible(false);
				base.uiBehaviour.m_ScrollView.SetPosition(0f);
			}
		}

		// Token: 0x0600C253 RID: 49747 RVA: 0x0029C468 File Offset: 0x0029A668
		public void SetForceShow(bool bShow)
		{
			this.m_bForceShow = bShow;
			if (bShow)
			{
				this.SetVisible(true, true);
			}
			else
			{
				bool bFakeHide = this.m_bFakeHide;
				if (bFakeHide)
				{
					this.SetVisible(false, true);
				}
			}
		}

		// Token: 0x0600C254 RID: 49748 RVA: 0x0029C4A0 File Offset: 0x0029A6A0
		public void SetFakeHide(bool bHide)
		{
			this.m_bFakeHide = bHide;
			if (bHide)
			{
				bool flag = !this.m_bForceShow;
				if (flag)
				{
					this.SetVisible(false, true);
				}
			}
			else
			{
				this.SetVisible(true, true);
			}
		}

		// Token: 0x0600C255 RID: 49749 RVA: 0x0029C4E0 File Offset: 0x0029A6E0
		public void DoOpenChatWindow(IXUISprite sp)
		{
			bool flag = !DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x0600C256 RID: 49750 RVA: 0x0029C50C File Offset: 0x0029A70C
		public void OnOpenMainWindow(IXUISprite sp)
		{
			this.OnShowWindow(false);
		}

		// Token: 0x0600C257 RID: 49751 RVA: 0x0029C517 File Offset: 0x0029A717
		public static void OnLabelMainWindow(string param)
		{
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.DoOpenChatWindow(null);
		}

		// Token: 0x0600C258 RID: 49752 RVA: 0x0029C526 File Offset: 0x0029A726
		public void OnOpenMiniWindow(IXUISprite sp)
		{
			this.OnShowWindow(true);
		}

		// Token: 0x0600C259 RID: 49753 RVA: 0x0029C531 File Offset: 0x0029A731
		public void OnCleanUpChatWindow()
		{
			XChatSmallView._doc.RestrainSmallChatInfoNum();
			base.uiBehaviour.ChatUIInfoList.Clear();
		}

		// Token: 0x0600C25A RID: 49754 RVA: 0x0029C550 File Offset: 0x0029A750
		public void InitUI(ChatInfo info)
		{
			bool flag = !base.IsVisible() || !base.IsLoaded();
			if (!flag)
			{
				GameObject gameObject = base.uiBehaviour.m_ChatPool.FetchGameObject(false);
				this.InitChatUI(info, gameObject);
				int allUIHeight = this.GetAllUIHeight(-1);
				float num = (float)(55 - allUIHeight);
				gameObject.transform.localPosition = new Vector3(0f, num);
				XSmallChatInfo xsmallChatInfo = new XSmallChatInfo();
				xsmallChatInfo.info = info;
				xsmallChatInfo.uiobject = gameObject;
				base.uiBehaviour.ChatUIInfoList.Add(xsmallChatInfo);
				base.uiBehaviour.m_ScrollView.NeedRecalcBounds();
				bool redpoint = DlgBase<XChatView, XChatBehaviour>.singleton.HasNewFriendMsg();
				this.SetRedpoint(redpoint);
				this.SetPivot();
			}
		}

		// Token: 0x0600C25B RID: 49755 RVA: 0x0029C610 File Offset: 0x0029A810
		public void SetRedpoint(bool show)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			bool flag2 = base.uiBehaviour.m_RedPoint != null;
			if (flag2)
			{
				base.uiBehaviour.m_RedPoint.SetVisible(show && flag);
			}
		}

		// Token: 0x0600C25C RID: 49756 RVA: 0x0029C658 File Offset: 0x0029A858
		public void HandleOfflineInfoQuickily()
		{
			bool flag = !base.IsVisible() || !base.IsLoaded();
			if (!flag)
			{
				List<ChatInfo> offlineProcessList = XChatDocument.offlineProcessList;
				float num = 55f;
				this.ConstrainChatUINum();
				for (int i = 0; i < offlineProcessList.Count; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_ChatPool.FetchGameObject(false);
					this.InitChatUI(offlineProcessList[i], gameObject);
					gameObject.transform.localPosition = new Vector3(0f, num);
					XSmallChatInfo xsmallChatInfo = new XSmallChatInfo();
					xsmallChatInfo.info = offlineProcessList[i];
					xsmallChatInfo.uiobject = gameObject;
					base.uiBehaviour.ChatUIInfoList.Add(xsmallChatInfo);
					IXUILabel ixuilabel = gameObject.transform.FindChild("content").GetComponent("XUILabel") as IXUILabel;
					num -= (float)((int)ixuilabel.GetPrintSize().y + XChatSmallView.HEIGHT_ADJUST);
				}
				base.uiBehaviour.m_ScrollView.NeedRecalcBounds();
				this.SetPivot();
			}
		}

		// Token: 0x0600C25D RID: 49757 RVA: 0x0029C774 File Offset: 0x0029A974
		public void OnReceieveChatInfos(List<ChatInfo> infos)
		{
			for (int i = 0; i < infos.Count; i++)
			{
				this.ConstrainChatUINum();
				bool isInited = this.IsInited;
				if (isInited)
				{
					this.InitUI(infos[i]);
				}
				else
				{
					this.OnReceiveChatInfo(infos[i]);
				}
			}
			infos.Clear();
		}

		// Token: 0x0600C25E RID: 49758 RVA: 0x0029C7D0 File Offset: 0x0029A9D0
		public void OnReceiveChatInfo(ChatInfo info)
		{
			bool isInited = this.IsInited;
			if (isInited)
			{
				this.ConstrainChatUINum();
				bool flag = !DlgBase<XChatSettingView, XChatSettingBehaviour>.singleton.IsChannelEnable(info.mChannelId);
				if (!flag)
				{
					bool flag2 = XChatSmallView._doc != null;
					if (flag2)
					{
						this.InitUI(info);
						bool flag3 = !base.IsVisible() && !XSingleton<XCutScene>.singleton.IsPlaying && !DlgBase<CutoverViewView, CutoverViewBehaviour>.singleton.IsOpening;
						if (flag3)
						{
							this.SetVisible(true, true);
						}
						bool flag4 = base.uiBehaviour.m_MainPanel.GetAlpha() <= 0.7f;
						if (flag4)
						{
							this.StartPlayAlphaEffect();
						}
					}
				}
			}
		}

		// Token: 0x0600C25F RID: 49759 RVA: 0x0029C87C File Offset: 0x0029AA7C
		private void StartPlayAlphaEffect()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				base.uiBehaviour.m_BgTweenTool.SetTweenGroup(1);
				base.uiBehaviour.m_BgTweenTool.PlayTween(true, -1f);
				base.uiBehaviour.m_BgSprite.SetVisible(true);
			}
		}

		// Token: 0x0600C260 RID: 49760 RVA: 0x0029C8D4 File Offset: 0x0029AAD4
		private void SetPivot()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				bool flag2 = this.GetAllUIHeight(-1) > XChatSmallView.SCROLL_HEIGHT;
				if (flag2)
				{
					base.uiBehaviour.m_ScrollView.SetPosition(1f);
				}
				else
				{
					base.uiBehaviour.m_ScrollView.SetPosition(0f);
				}
			}
		}

		// Token: 0x0600C261 RID: 49761 RVA: 0x0029C930 File Offset: 0x0029AB30
		public void OnInitHistoryMsg()
		{
			base.uiBehaviour.m_ChatPool.ReturnAll(false);
			this.OnCleanUpChatWindow();
			List<ChatInfo> smallChatList = XChatSmallView._doc.GetSmallChatList();
			this.ConstrainChatUINum();
			for (int i = 0; i < smallChatList.Count; i++)
			{
				this.InitUI(smallChatList[i]);
			}
			XSingleton<XTimerMgr>.singleton.SetTimer(0.1f, new XTimerMgr.ElapsedEventHandler(this.SetScrollView), null);
		}

		// Token: 0x0600C262 RID: 49762 RVA: 0x0029C9AC File Offset: 0x0029ABAC
		public void EnableClickEvent(bool enable)
		{
			if (enable)
			{
				base.uiBehaviour.m_BgSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoOpenChatWindow));
			}
			else
			{
				base.uiBehaviour.m_BgSprite.RegisterSpriteClickEventHandler(null);
			}
		}

		// Token: 0x0600C263 RID: 49763 RVA: 0x0029C9F0 File Offset: 0x0029ABF0
		public static string InitMiniChatUI(ChatInfo info, GameObject go)
		{
			IXUILabelSymbol ixuilabelSymbol = go.transform.FindChild("content").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUISprite ixuisprite = go.transform.FindChild("channel").GetComponent("XUISprite") as IXUISprite;
			string text = DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(info.mContent);
			bool flag = string.IsNullOrEmpty(text) || (text.StartsWith(" ") && text.EndsWith(" "));
			if (flag)
			{
				text = "......";
			}
			bool flag2 = info.mChannelId != ChatChannelType.System && info.isAudioChat;
			if (flag2)
			{
				text = XSingleton<XCommon>.singleton.StringCombine(XLabelSymbolHelper.FormatImage("Chat/Chat", "yyicon5"), text);
			}
			XSingleton<XCommon>.singleton.CleanStringCombine();
			string s = "[f39354]";
			bool isSelfSender = info.isSelfSender;
			if (isSelfSender)
			{
				s = "[54aaf3]";
			}
			ChatChannelType mChannelId = info.mChannelId;
			if (mChannelId != ChatChannelType.System)
			{
				if (mChannelId != ChatChannelType.Curr)
				{
					if (mChannelId != ChatChannelType.Group)
					{
						text = ChatItem.ParsePayComsume(info, text, true);
						bool flag3 = string.IsNullOrEmpty(info.mSenderName);
						if (flag3)
						{
							XSingleton<XCommon>.singleton.AppendString("[ffffff] ", text, "[-]");
						}
						else
						{
							XSingleton<XCommon>.singleton.AppendString(XSingleton<UiUtility>.singleton.GetChatDesignation(info.mCoverDesignationID, info.mSpecialDesignation, ""));
							XSingleton<XCommon>.singleton.AppendString("[ffffff] ", s, info.mSenderName);
							XSingleton<XCommon>.singleton.AppendString("[-]：", text);
							XSingleton<XCommon>.singleton.AppendString("[-]");
						}
					}
					else
					{
						text = ChatItem.ParsePayComsume(info, text, true);
						XSingleton<XCommon>.singleton.AppendString("[ffffff] ", s);
						XSingleton<XCommon>.singleton.AppendString("[", info.group.groupchatName, "]");
						XSingleton<XCommon>.singleton.AppendString(XSingleton<UiUtility>.singleton.GetChatDesignation(info.mCoverDesignationID, info.mSpecialDesignation, ""));
						XSingleton<XCommon>.singleton.AppendString(info.mSenderName, "[-]：", text);
						XSingleton<XCommon>.singleton.AppendString("[-]");
					}
				}
				else
				{
					string pattern = "\\[[0-9a-fA-F]{6}\\]";
					Regex regex = new Regex(pattern);
					text = regex.Replace(text, "[ffffff]", 3);
					text = ChatItem.ParsePayComsume(info, text, true);
					XSingleton<XCommon>.singleton.AppendString(XSingleton<UiUtility>.singleton.GetChatDesignation(info.mCoverDesignationID, info.mSpecialDesignation, ""));
					XSingleton<XCommon>.singleton.AppendString("[ffffff] ", s, info.mSenderName);
					XSingleton<XCommon>.singleton.AppendString("[-]：", text);
					XSingleton<XCommon>.singleton.AppendString("[-]");
				}
			}
			else
			{
				XSingleton<XCommon>.singleton.AppendString("[e58db2] ", text, "[-]");
			}
			XLabelSymbolHelper.RegisterHyperLinkClicks(ixuilabelSymbol);
			ixuilabelSymbol.RegisterDefaultEventHandler(new HyperLinkClickEventHandler(XChatSmallView.OnLabelMainWindow));
			ixuilabelSymbol.InputText = XSingleton<XCommon>.singleton.GetString();
			XChatSmallView._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			string miniSpr = XChatSmallView._doc.GetRawData(info.mChannelId).miniSpr;
			ixuisprite.SetSprite(miniSpr);
			return XSingleton<XCommon>.singleton.GetString();
		}

		// Token: 0x0600C264 RID: 49764 RVA: 0x0029CD34 File Offset: 0x0029AF34
		private void InitChatUI(ChatInfo info, GameObject go)
		{
			string inputText = XChatSmallView.InitMiniChatUI(info, go);
			base.uiBehaviour.m_MiniTemplate.SetVisible(true);
			base.uiBehaviour.m_MiniAudioTemplate.SetVisible(false);
			base.uiBehaviour.m_MiniText.InputText = inputText;
		}

		// Token: 0x0600C265 RID: 49765 RVA: 0x0029CD80 File Offset: 0x0029AF80
		public int GetAllUIHeight(int count = -1)
		{
			int num = 0;
			bool flag = count == -1 || count > base.uiBehaviour.ChatUIInfoList.Count;
			if (flag)
			{
				count = base.uiBehaviour.ChatUIInfoList.Count;
			}
			for (int i = 0; i < count; i++)
			{
				GameObject uiobject = base.uiBehaviour.ChatUIInfoList[i].uiobject;
				IXUILabel ixuilabel = uiobject.transform.FindChild("content").GetComponent("XUILabel") as IXUILabel;
				num += (int)ixuilabel.GetPrintSize().y + XChatSmallView.HEIGHT_ADJUST;
			}
			return num;
		}

		// Token: 0x0600C266 RID: 49766 RVA: 0x0029CE2C File Offset: 0x0029B02C
		private bool ConstrainChatUINum()
		{
			bool flag = !base.IsVisible() || !base.IsLoaded();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = (long)base.uiBehaviour.ChatUIInfoList.Count >= (long)((ulong)XChatSmallBehaviour.m_MaxShowMsg);
				if (flag2)
				{
					int count = base.uiBehaviour.ChatUIInfoList.Count;
					int num = 0;
					while ((long)num <= (long)count - (long)((ulong)XChatSmallBehaviour.m_MaxShowMsg))
					{
						XSmallChatInfo xsmallChatInfo = base.uiBehaviour.ChatUIInfoList[0];
						base.uiBehaviour.m_ChatPool.ReturnInstance(xsmallChatInfo.uiobject, false);
						base.uiBehaviour.ChatUIInfoList.Remove(xsmallChatInfo);
						num++;
					}
					for (int i = 0; i < base.uiBehaviour.ChatUIInfoList.Count; i++)
					{
						int allUIHeight = this.GetAllUIHeight(i);
						float num2 = (float)(55 - allUIHeight);
						base.uiBehaviour.ChatUIInfoList[i].uiobject.transform.localPosition = new Vector3(0f, num2);
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600C267 RID: 49767 RVA: 0x0029CF5E File Offset: 0x0029B15E
		public void SetDeepth(int depth)
		{
			this.m_uiBehaviour.m_panel.SetDepth(depth);
			this.m_uiBehaviour.m_contentPanel.SetDepth(depth + 1);
		}

		// Token: 0x0600C268 RID: 49768 RVA: 0x0029CF88 File Offset: 0x0029B188
		public void SetPosition(int group, bool bAnim)
		{
			this.StartPlayAlphaEffect();
			base.uiBehaviour.m_TweenTool.StopTween();
			base.uiBehaviour.m_TweenTool.SetTweenGroup(group);
			if (bAnim)
			{
				base.uiBehaviour.m_TweenTool.PlayTween(true, -1f);
			}
			else
			{
				base.uiBehaviour.m_TweenTool.ResetTweenByGroup(false, group);
			}
		}

		// Token: 0x0600C269 RID: 49769 RVA: 0x0029CFF5 File Offset: 0x0029B1F5
		public void ShowPanel(bool show)
		{
			base.uiBehaviour.m_MainPanel.SetVisible(show);
		}

		// Token: 0x0600C26A RID: 49770 RVA: 0x0029D00C File Offset: 0x0029B20C
		public void ShowMailRedpoint()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BIGMELEE_READY;
			bool flag2 = DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible();
			bool flag3 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			bool flag4 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Mail);
			bool sysRedPointState = XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(XSysDefine.XSys_Mail);
			base.uiBehaviour.m_sprMailRed.SetVisible(flag4 && sysRedPointState && flag && !flag2 && !flag3);
		}

		// Token: 0x0600C26B RID: 49771 RVA: 0x0029D098 File Offset: 0x0029B298
		public void ShowChatDefaultMiniUI()
		{
			this.ShowChatMiniUI(new ShowSettingArgs
			{
				position = 0,
				anim = false
			});
		}

		// Token: 0x0600C26C RID: 49772 RVA: 0x0029D0C4 File Offset: 0x0029B2C4
		public void ShowChatMiniUI(ShowSettingArgs args)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("show miniui: " + args.forceshow.ToString(), null, null, null, null, null);
			bool needforceshow = args.needforceshow;
			if (needforceshow)
			{
				bool forceshow = args.forceshow;
				if (forceshow)
				{
					this.SetForceShow(args.forceshow);
					this.SetPosition(args.position, args.anim);
				}
				else
				{
					this.SetPosition(args.position, args.anim);
					this.SetForceShow(args.forceshow);
				}
			}
			else
			{
				this.SetVisible(true, true);
				this.SetPosition(args.position, args.anim);
			}
			this.ShowMailRedpoint();
			this.EnableClickEvent(args.enablebackclick);
			bool needdepth = args.needdepth;
			if (needdepth)
			{
				this.SetDeepth(args.depth);
			}
		}

		// Token: 0x04005369 RID: 21353
		private static XChatDocument _doc = null;

		// Token: 0x0400536A RID: 21354
		private bool m_ShowMini = false;

		// Token: 0x0400536B RID: 21355
		public bool IsInited = false;

		// Token: 0x0400536C RID: 21356
		private bool m_bForceShow = false;

		// Token: 0x0400536D RID: 21357
		private bool m_bFakeHide = false;

		// Token: 0x0400536E RID: 21358
		private uint m_offToken = 0U;

		// Token: 0x0400536F RID: 21359
		private static readonly int SCROLL_HEIGHT = 90;

		// Token: 0x04005370 RID: 21360
		private static readonly int HEIGHT_ADJUST = 3;

		// Token: 0x04005371 RID: 21361
		private float presstime = 0f;

		// Token: 0x04005372 RID: 21362
		private static bool start = false;

		// Token: 0x04005373 RID: 21363
		private float last_time;
	}
}
