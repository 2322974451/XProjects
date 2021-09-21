using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CC5 RID: 3269
	public class ChatItem : MonoBehaviour
	{
		// Token: 0x0600B786 RID: 46982 RVA: 0x0024901C File Offset: 0x0024721C
		private void Awake()
		{
			this.m_sprHead = (base.transform.FindChild("head").GetComponent("XUISprite") as IXUISprite);
			this.m_sprHost = (base.transform.FindChild("head/hoster").GetComponent("XUISprite") as IXUISprite);
			this.m_regression = (base.transform.Find("head/Regression").GetComponent("XUISprite") as IXUISprite);
			this.m_sprFrame = (base.transform.Find("head/AvatarFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_campDuel = (base.transform.Find("head/CampDuel").GetComponent("XUISprite") as IXUISprite);
			this.m_lblTime = (base.transform.FindChild("board/offset/time").GetComponent("XUILabel") as IXUILabel);
			this.m_symContent = (base.transform.Find("board/offset/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_lblContent = (this.m_symContent.gameObject.GetComponent("XUILabel") as IXUILabel);
			this.m_sprBoard = (base.transform.Find("board").GetComponent("XUISprite") as IXUISprite);
			this.m_objName = base.transform.Find("board/offset/name").gameObject;
			this.m_lblName = (base.transform.Find("board/offset/selfname").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_objVoice = base.transform.Find("board/offset/voice").gameObject;
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_offset = base.transform.Find("board/offset");
			this.m_sprHead.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickChatHead));
		}

		// Token: 0x0600B787 RID: 46983 RVA: 0x00249214 File Offset: 0x00247414
		public void Refresh(ChatInfo info)
		{
			bool flag = this.mChatInfo == info || this.m_lblTime == null;
			if (!flag)
			{
				this.mChatInfo = info;
				this.mChatInfo.id = (info.id = DlgBase<XChatView, XChatBehaviour>.singleton.ChatIdIndex);
				this.mChatInfo.isUIShowed = (info.isUIShowed = true);
				DateTime mTime = info.mTime;
				TimeSpan timeSpan = DateTime.Now - mTime;
				string text = string.Format("{0:D2}:{1:D2}:{2:D2}", mTime.Hour, mTime.Minute, mTime.Second);
				bool flag2 = timeSpan.Days > 0;
				if (flag2)
				{
					text = XStringDefineProxy.GetString("CHAT_DAY", new object[]
					{
						timeSpan.Days
					});
				}
				bool flag3 = this.m_lblTime != null;
				if (flag3)
				{
					this.m_lblTime.SetText(text);
				}
				IXUILabelSymbol ixuilabelSymbol = this.m_objName.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				string text2 = XSingleton<UiUtility>.singleton.GetChatDesignation(info.mCoverDesignationID, info.mSpecialDesignation, info.mSenderName);
				text2 = XSingleton<XCommon>.singleton.StringCombine(text2, XWelfareDocument.GetMemberPrivilegeIconString(info.mSenderPaymemberid));
				ixuilabelSymbol.InputText = XMilitaryRankDocument.GetMilitaryRankWithFormat(info.militaryRank, text2, false);
				this.m_regression.SetVisible(info.mRegression);
				this.m_campDuel.SetVisible(info.CampDuelID > 0U);
				bool flag4 = info.CampDuelID == 1U;
				if (flag4)
				{
					this.m_campDuel.SetSprite(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelChatLeftIcon"));
				}
				bool flag5 = info.CampDuelID == 2U;
				if (flag5)
				{
					this.m_campDuel.SetSprite(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelChatRightIcon"));
				}
				bool isSelfSender = info.isSelfSender;
				if (isSelfSender)
				{
					this.m_sprHead.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession));
					bool flag6 = info.payConsume != null && info.payConsume.setid != null;
					if (flag6)
					{
						XSingleton<UiUtility>.singleton.ParseHeadIcon(info.payConsume.setid, this.m_sprFrame);
					}
					else
					{
						this.m_sprFrame.SetVisible(false);
					}
				}
				else
				{
					bool flag7 = info.mSenderId == 0UL && info.mChannelId == ChatChannelType.Guild;
					if (flag7)
					{
						this.m_sprHead.SetSprite("zy_0_0");
						this.m_sprFrame.SetVisible(false);
					}
					else
					{
						bool flag8 = info.mSenderId == 0UL && info.mChannelId == ChatChannelType.Team;
						if (flag8)
						{
							this.m_sprHead.SetSprite("zy_0_1");
							this.m_sprFrame.SetVisible(false);
						}
						else
						{
							this.m_sprHead.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)info.mServerProfession));
							bool flag9 = info.payConsume != null && info.payConsume.setid != null;
							if (flag9)
							{
								XSingleton<UiUtility>.singleton.ParseHeadIcon(info.payConsume.setid, this.m_sprFrame);
							}
							else
							{
								this.m_sprFrame.SetVisible(false);
							}
						}
					}
				}
				bool flag10 = !info.isSelfSender && (info.mChannelId == ChatChannelType.Guild || info.mChannelId == ChatChannelType.World || info.mChannelId == ChatChannelType.Team);
				bool flag11 = flag10;
				if (flag11)
				{
					IXUILabelSymbol ixuilabelSymbol2 = this.m_objName.GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					string text3 = XSingleton<UiUtility>.singleton.GetChatDesignation(info.mCoverDesignationID, info.mSpecialDesignation, info.mSenderName);
					text3 = XSingleton<XCommon>.singleton.StringCombine(text3, XWelfareDocument.GetMemberPrivilegeIconString(info.mSenderPaymemberid));
					ixuilabelSymbol2.InputText = XMilitaryRankDocument.GetMilitaryRankWithFormat(info.militaryRank, text3, false);
				}
				else
				{
					bool flag12 = this.m_lblName != null;
					if (flag12)
					{
						bool flag13 = info.mSenderId == 0UL && info.mChannelId == ChatChannelType.Guild;
						if (flag13)
						{
							this.m_lblName.InputText = XStringDefineProxy.GetString("CHAT_GUILD_NEW");
						}
						else
						{
							bool flag14 = info.mChatType == ChatType.OtherText || info.mChatType == ChatType.OtherVoice;
							if (flag14)
							{
								this.m_lblName.InputText = ((info.mChannelId == ChatChannelType.Friends) ? XStringDefineProxy.GetString("CHAT_FRIENDS2", new object[]
								{
									info.mReceiverName
								}) : info.mSenderName);
							}
							else
							{
								string text4 = XSingleton<XCommon>.singleton.StringCombine(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name, XWelfareDocument.GetMemberPrivilegeIconString(info.mSenderPaymemberid));
								text4 = XMilitaryRankDocument.GetMilitaryRankWithFormat(info.militaryRank, text4, false);
								this.m_lblName.InputText = ((info.mChannelId == ChatChannelType.Friends) ? XStringDefineProxy.GetString("CHAT_FRIENDS1", new object[]
								{
									info.mReceiverName
								}) : text4);
							}
						}
					}
				}
				this.m_objVoice.SetActive(info.isAudioChat);
				bool isAudioChat = info.isAudioChat;
				if (isAudioChat)
				{
					this.InitAudioUI();
				}
				else
				{
					this.InitTextUI();
				}
				float num = (float)(info.isAudioChat ? -16 : 30);
				float num2 = (float)(info.isSelfSender ? 14 : 24);
				this.m_lblContent.gameObject.transform.localPosition = new Vector3(num2, num, 0f);
				this.SetPivot();
				XChatView singleton = DlgBase<XChatView, XChatBehaviour>.singleton;
				int chatIdIndex = singleton.ChatIdIndex;
				singleton.ChatIdIndex = chatIdIndex + 1;
				XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
				this.m_sprHost.SetVisible(specificDocument.hostIDs.Contains(this.mChatInfo.mSenderId) && this.mChatInfo.mChannelId == ChatChannelType.Broadcast);
			}
		}

		// Token: 0x0600B788 RID: 46984 RVA: 0x002497E4 File Offset: 0x002479E4
		private void SetPivot()
		{
			this.m_sprBoard.SetFlipHorizontal(this.mChatInfo.isSelfSender);
			float num = (float)(this.mChatInfo.isSelfSender ? -215 : -145);
			this.m_sprBoard.gameObject.transform.localPosition = new Vector3(num, -30f, 0f);
			this.m_objName.SetActive(!this.mChatInfo.isSelfSender);
			this.m_lblName.SetVisible(this.mChatInfo.isSelfSender);
			num = (float)(this.mChatInfo.isSelfSender ? 175 : -180);
			float num2 = this.m_offset.transform.localPosition.y + this.m_sprBoard.gameObject.transform.localPosition.y;
			float num3 = this.m_lblTime.gameObject.transform.localPosition.y + num2 + 4f;
			this.m_sprHead.gameObject.transform.localPosition = new Vector3(num, num3, 0f);
		}

		// Token: 0x0600B789 RID: 46985 RVA: 0x0024990C File Offset: 0x00247B0C
		private void InitAudioUI()
		{
			this.mChatInfo.mUIObject = this.m_objVoice;
			IXUISprite ixuisprite = this.m_objVoice.transform.FindChild("board").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = this.m_objVoice.transform.FindChild("redpoint").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = this.m_objVoice.transform.FindChild("time").GetComponent("XUILabel") as IXUILabel;
			IXUIButton ixuibutton = this.m_objVoice.transform.FindChild("sendFlower").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.ID = (ulong)((long)this.mChatInfo.id);
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(DlgBase<XChatView, XChatBehaviour>.singleton.UIOP.OnSendFlowerClicked));
			ixuibutton.SetVisible(!this.mChatInfo.isSelfSender && !DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded());
			ixuilabel.SetText((this.mChatInfo.mAudioTime / 1000U + 1U).ToString() + "\"");
			string mContent = this.mChatInfo.mContent;
			this.m_symContent.InputText = ChatItem.ParsePayComsume(this.mChatInfo, mContent, false);
			ixuisprite.ID = (ulong)((long)this.mChatInfo.id);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(DlgBase<XChatView, XChatBehaviour>.singleton.UIOP.OnStartPlayAudio));
			ixuisprite2.SetVisible(!this.mChatInfo.isUIShowed);
			this.m_sprBoard.spriteHeight = 56 + this.m_lblContent.spriteHeight;
			this.m_sprRoot.spriteHeight = this.m_sprBoard.spriteHeight + 40;
			this.m_offset.transform.localPosition = new Vector3(0f, (float)((this.m_sprBoard.spriteHeight - this.boardHeight) / 2 + 30), 0f);
			IXUISpriteAnimation ixuispriteAnimation = this.m_objVoice.transform.FindChild("sign").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
			ixuispriteAnimation.SetFrameRate(0);
		}

		// Token: 0x0600B78A RID: 46986 RVA: 0x00249B48 File Offset: 0x00247D48
		private void InitTextUI()
		{
			this.mChatInfo.mContent = DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(this.mChatInfo.mContent);
			XLabelSymbolHelper.RegisterHyperLinkClicks(this.m_symContent);
			string mContent = this.mChatInfo.mContent;
			this.m_symContent.InputText = ChatItem.ParsePayComsume(this.mChatInfo, mContent, false);
			this.m_sprBoard.spriteHeight = ((this.mChatInfo.mChannelId != ChatChannelType.System) ? (20 + this.m_lblContent.spriteHeight) : (10 + this.m_lblContent.spriteHeight));
			this.m_sprRoot.spriteHeight = ((this.mChatInfo.mChannelId != ChatChannelType.System) ? (60 + this.m_lblContent.spriteHeight) : (10 + this.m_lblContent.spriteHeight));
			this.m_offset.transform.localPosition = new Vector3(0f, (float)((this.m_sprBoard.spriteHeight - this.boardHeight) / 2 + 30), 0f);
		}

		// Token: 0x0600B78B RID: 46987 RVA: 0x00249C50 File Offset: 0x00247E50
		private void OnClickChatHead(IXUISprite sp)
		{
			bool flag = !this.mChatInfo.isSelfSender && this.mChatInfo.mSenderId != 0UL && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				bool flag2 = this.mChatInfo.mChannelId == ChatChannelType.Broadcast;
				if (!flag2)
				{
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(this.mChatInfo.mSenderId, false);
				}
			}
		}

		// Token: 0x0600B78C RID: 46988 RVA: 0x00249CC0 File Offset: 0x00247EC0
		public static string ParsePayComsume(ChatInfo info, string txt, bool ismini)
		{
			bool flag = info != null && info.payConsume != null;
			if (flag)
			{
				string text = string.Empty;
				string text2 = string.Empty;
				string text3 = XPrerogativeDocument.ConvertTypeToPreContent(PrerogativeType.PreStart, info.payConsume.setid);
				string[] array = text3.Split(new char[]
				{
					'='
				});
				bool flag2 = !string.IsNullOrEmpty(text3);
				if (flag2)
				{
					text = array[0];
					bool flag3 = ismini && array.Length > 1;
					if (flag3)
					{
						text = array[1];
					}
				}
				text2 = XPrerogativeDocument.ConvertTypeToPreContent(PrerogativeType.PreChatAdorn, info.payConsume.setid);
				bool flag4 = !string.IsNullOrEmpty(text2);
				if (flag4)
				{
					text2 = XLabelSymbolHelper.FormatImage("Chat/Chat", text2);
				}
				bool flag5 = !string.IsNullOrEmpty(text2);
				if (flag5)
				{
					txt = text2 + txt + text2;
				}
				bool flag6 = !string.IsNullOrEmpty(text);
				if (flag6)
				{
					txt = string.Format("[c][{0}]{1}[/c]", text, DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(txt));
				}
			}
			return txt;
		}

		// Token: 0x04004824 RID: 18468
		private ChatInfo mChatInfo;

		// Token: 0x04004825 RID: 18469
		private int boardHeight = 144;

		// Token: 0x04004826 RID: 18470
		private IXUISprite m_sprHead;

		// Token: 0x04004827 RID: 18471
		private IXUISprite m_sprHost;

		// Token: 0x04004828 RID: 18472
		private IXUISprite m_sprFrame;

		// Token: 0x04004829 RID: 18473
		private IXUILabel m_lblTime;

		// Token: 0x0400482A RID: 18474
		private IXUILabelSymbol m_symContent;

		// Token: 0x0400482B RID: 18475
		private IXUILabel m_lblContent;

		// Token: 0x0400482C RID: 18476
		private IXUISprite m_sprBoard;

		// Token: 0x0400482D RID: 18477
		private GameObject m_objName;

		// Token: 0x0400482E RID: 18478
		private IXUILabelSymbol m_lblName;

		// Token: 0x0400482F RID: 18479
		private GameObject m_objVoice;

		// Token: 0x04004830 RID: 18480
		private IXUISprite m_sprRoot;

		// Token: 0x04004831 RID: 18481
		private Transform m_offset;

		// Token: 0x04004832 RID: 18482
		private IXUISprite m_regression;

		// Token: 0x04004833 RID: 18483
		private IXUISprite m_campDuel;
	}
}
