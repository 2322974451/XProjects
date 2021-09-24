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

	internal class XChatSmallView : DlgBase<XChatSmallView, XChatSmallBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ChatSmallDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			XChatSmallView._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			XChatSmallView._doc.ChatSmallView = this;
			this.m_bForceShow = false;
			this.m_bFakeHide = false;
			base.uiBehaviour.m_ChatPool.ReturnAll(false);
			this.OnShowWindow(false);
		}

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

		private void HanderOfflineTimer(object o)
		{
			bool flag = !XChatSmallView.start && !this.IsInited;
			if (flag)
			{
				this.CacheMsg();
			}
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_BgSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoOpenChatWindow));
			base.uiBehaviour.m_BgSpriteMini.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoOpenChatWindow));
			base.uiBehaviour.m_OpenWindow.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenMiniWindow));
			base.uiBehaviour.m_OpenWindowMini.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOpenMainWindow));
			base.uiBehaviour.m_sprMailRed.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(DlgBase<XChatView, XChatBehaviour>.singleton.OnMailClick));
			base.uiBehaviour.m_sprMailRed.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.TestChatMiniPress));
		}

		public void SetExp()
		{
			base.uiBehaviour.m_Exp.value = XSingleton<XAttributeMgr>.singleton.XPlayerData.Exp * 1f / XSingleton<XAttributeMgr>.singleton.XPlayerData.MaxExp;
			base.uiBehaviour.m_ExpValue.SetText(string.Format("{0}/{1}", XSingleton<XAttributeMgr>.singleton.XPlayerData.Exp, XSingleton<XAttributeMgr>.singleton.XPlayerData.MaxExp));
		}

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

		public void SetScrollView(object obj)
		{
			bool flag = base.IsLoaded() && base.IsVisible();
			if (flag)
			{
				this.SetPivot();
			}
		}

		protected override void OnUnload()
		{
			XChatSmallView._doc = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_offToken);
			base.OnUnload();
		}

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

		public void DoOpenChatWindow(IXUISprite sp)
		{
			bool flag = !DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		public void OnOpenMainWindow(IXUISprite sp)
		{
			this.OnShowWindow(false);
		}

		public static void OnLabelMainWindow(string param)
		{
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.DoOpenChatWindow(null);
		}

		public void OnOpenMiniWindow(IXUISprite sp)
		{
			this.OnShowWindow(true);
		}

		public void OnCleanUpChatWindow()
		{
			XChatSmallView._doc.RestrainSmallChatInfoNum();
			base.uiBehaviour.ChatUIInfoList.Clear();
		}

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

		public void SetRedpoint(bool show)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			bool flag2 = base.uiBehaviour.m_RedPoint != null;
			if (flag2)
			{
				base.uiBehaviour.m_RedPoint.SetVisible(show && flag);
			}
		}

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

		private void InitChatUI(ChatInfo info, GameObject go)
		{
			string inputText = XChatSmallView.InitMiniChatUI(info, go);
			base.uiBehaviour.m_MiniTemplate.SetVisible(true);
			base.uiBehaviour.m_MiniAudioTemplate.SetVisible(false);
			base.uiBehaviour.m_MiniText.InputText = inputText;
		}

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

		public void SetDeepth(int depth)
		{
			this.m_uiBehaviour.m_panel.SetDepth(depth);
			this.m_uiBehaviour.m_contentPanel.SetDepth(depth + 1);
		}

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

		public void ShowPanel(bool show)
		{
			base.uiBehaviour.m_MainPanel.SetVisible(show);
		}

		public void ShowMailRedpoint()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_BIGMELEE_READY;
			bool flag2 = DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible();
			bool flag3 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
			bool flag4 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Mail);
			bool sysRedPointState = XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(XSysDefine.XSys_Mail);
			base.uiBehaviour.m_sprMailRed.SetVisible(flag4 && sysRedPointState && flag && !flag2 && !flag3);
		}

		public void ShowChatDefaultMiniUI()
		{
			this.ShowChatMiniUI(new ShowSettingArgs
			{
				position = 0,
				anim = false
			});
		}

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

		private static XChatDocument _doc = null;

		private bool m_ShowMini = false;

		public bool IsInited = false;

		private bool m_bForceShow = false;

		private bool m_bFakeHide = false;

		private uint m_offToken = 0U;

		private static readonly int SCROLL_HEIGHT = 90;

		private static readonly int HEIGHT_ADJUST = 3;

		private float presstime = 0f;

		private static bool start = false;

		private float last_time;
	}
}
