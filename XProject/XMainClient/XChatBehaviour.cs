using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E15 RID: 3605
	internal class XChatBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C227 RID: 49703 RVA: 0x0029AC1C File Offset: 0x00298E1C
		private void Awake()
		{
			this.m_sprTq = (base.transform.FindChild("Bg/ChatTopText/world_times/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_lblPriviledge = (this.m_sprTq.gameObject.transform.Find("Txt").GetComponent("XUILabel") as IXUILabel);
			this.m_ChangeToVoice = (base.transform.FindChild("Bg/ChatTopText/speak").GetComponent("XUIButton") as IXUIButton);
			this.m_SpeakEff = base.transform.FindChild("Bg/ChatTopText/speak/Effect").gameObject;
			this.m_ChatTextCost = (base.transform.FindChild("Bg/ChatTopText/speak/cost").GetComponent("XUILabel") as IXUILabel);
			this.m_TextBoard = (base.transform.FindChild("Bg/ChatTopText").GetComponent("XUISprite") as IXUISprite);
			this.m_LimitBoard = (base.transform.FindChild("Bg/LvLimit").GetComponent("XUISprite") as IXUISprite);
			this.m_DoSendChat = (base.transform.FindChild("Bg/ChatTopText/sendchat").GetComponent("XUIButton") as IXUIButton);
			this.m_ChatText = (base.transform.FindChild("Bg/ChatTopText/textinput/chattext").GetComponent("XUILabel") as IXUILabel);
			this.m_ChatInput = (base.transform.FindChild("Bg/ChatTopText/textinput").GetComponent("XUIInput") as IXUIInput);
			this.m_ChatSymbol = (base.transform.FindChild("Bg/ChatTopText/textinput/chattext").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Input = (base.transform.FindChild("Bg/ChatTopText/textinput").GetComponent("XUIInput") as IXUIInput);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Flower = base.transform.FindChild("Bg/ChatTopText/getFlower").gameObject;
			this.m_GetFlowerBtn = (base.transform.FindChild("Bg/ChatTopText/getFlower/flower").GetComponent("XUIButton") as IXUIButton);
			this.m_GetFlowerLeftTime = (base.transform.FindChild("Bg/ChatTopText/getFlower/leftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_GetFlowerLeftTime.SetText("");
			this.m_FlowerOwnCount = (base.transform.FindChild("Bg/ChatTopText/getFlower/label").GetComponent("XUILabel") as IXUILabel);
			this.m_FlowerOwnCount.SetText("0");
			this.m_FlowerEff = base.transform.FindChild("Bg/ChatTopText/getFlower/effect").gameObject;
			this.m_FlowerTween = (base.transform.FindChild("Bg/ChatTopText/getFlower/flower").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_lblWorldTimes = (base.transform.FindChild("Bg/ChatTopText/world_times").GetComponent("XUILabel") as IXUILabel);
			this.m_worldTween = (base.transform.FindChild("Bg/ChatTopText/world_times").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_btnAdd = (base.transform.FindChild("Bg/ChatTopText/addBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_objFriendBar = base.transform.FindChild("Bg/friendToolBar").gameObject;
			this.m_objGroupBar = base.transform.FindChild("Bg/groupChatBar").gameObject;
			this.m_sprFriendClear = (base.transform.FindChild("Bg/friendToolBar/BtnClear").GetComponent("XUISprite") as IXUISprite);
			this.m_sprFriendAdd = (base.transform.FindChild("Bg/friendToolBar/BtnAdd").GetComponent("XUISprite") as IXUISprite);
			this.m_sprFriendBack = (base.transform.FindChild("Bg/friendToolBar/BtnBack").GetComponent("XUISprite") as IXUISprite);
			this.m_sprFriendChat = (base.transform.FindChild("Bg/friendToolBar/BtnChat").GetComponent("XUISprite") as IXUISprite);
			this.m_lblFriendTip = (base.transform.FindChild("Bg/friendToolBar/Chatting").GetComponent("XUILabel") as IXUILabel);
			this.m_sprGroupBack = (this.m_objGroupBar.transform.FindChild("BtnBack").GetComponent("XUISprite") as IXUISprite);
			this.m_sprGroupQuit = (this.m_objGroupBar.transform.FindChild("Submenu/BtnQuit").GetComponent("XUISprite") as IXUISprite);
			this.m_sprGroupClear = (this.m_objGroupBar.transform.FindChild("BtnClear").GetComponent("XUISprite") as IXUISprite);
			this.m_sprMember = (this.m_objGroupBar.transform.FindChild("Submenu/BtnMember").GetComponent("XUISprite") as IXUISprite);
			this.m_sprList = (this.m_objGroupBar.transform.FindChild("Submenu/BtnList").GetComponent("XUISprite") as IXUISprite);
			this.m_panelSubMenu = (this.m_objGroupBar.transform.FindChild("Submenu").GetComponent("XUIPanel") as IXUIPanel);
			this.m_sprMore = (this.m_objGroupBar.transform.FindChild("BtnMore").GetComponent("XUISprite") as IXUISprite);
			this.m_sprGroupBind = (this.m_objGroupBar.transform.FindChild("BtnBind").GetComponent("XUISprite") as IXUISprite);
			this.m_sprGroupCreate = (this.m_objGroupBar.transform.FindChild("BtnCreate").GetComponent("XUISprite") as IXUISprite);
			this.m_lblGroupChat = (this.m_objGroupBar.transform.FindChild("Chatting").GetComponent("XUILabel") as IXUILabel);
			this.m_tranOffset = base.transform.FindChild("Bg/loopoffset");
			this.m_panelRoot = (base.GetComponent("XUIPanel") as IXUIPanel);
			this.m_panelText = (this.m_TextBoard.gameObject.GetComponent("XUIPanel") as IXUIPanel);
			this.m_loopView = (base.transform.FindChild("Bg/loopoffset/loopScroll").GetComponent("LoopScrollView") as ILoopScrollView);
			this.m_friendView = (base.transform.FindChild("Bg/friendsScroll").GetComponent("LoopScrollView") as ILoopScrollView);
			this.m_groupView = (base.transform.FindChild("Bg/groupsScroll").GetComponent("LoopScrollView") as ILoopScrollView);
			this.m_systemView = (base.transform.FindChild("Bg/systemScroll").GetComponent("LoopScrollView") as ILoopScrollView);
			this.m_sprSet = (base.transform.FindChild("Bg/btns/Setting").GetComponent("XUISprite") as IXUISprite);
			this.m_sprMail = (base.transform.FindChild("Bg/btns/Mail").GetComponent("XUISprite") as IXUISprite);
			this.m_sprMailRedpoint = (base.transform.FindChild("Bg/btns/Mail/redpoint").GetComponent("XUISprite") as IXUISprite);
			this.m_sprXinyue = (base.transform.FindChild("Bg/btns/Xinyue").GetComponent("XUISprite") as IXUISprite);
			this.m_sprXinyueRed = (this.m_sprXinyue.transform.FindChild("redpoint").GetComponent("XUISprite") as IXUISprite);
			this.m_sprFriend = (base.transform.FindChild("Bg/btns/Friend").GetComponent("XUISprite") as IXUISprite);
			this.m_chxAutoVoice = (base.transform.FindChild("Bg/btns/AutoVoice/CheckBox").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_lblAutoVoice = (base.transform.FindChild("Bg/btns/AutoVoice/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_btns = base.transform.FindChild("Bg/btns").gameObject;
		}

		// Token: 0x040052A9 RID: 21161
		public IXUISprite m_sprTq;

		// Token: 0x040052AA RID: 21162
		public IXUILabel m_lblPriviledge;

		// Token: 0x040052AB RID: 21163
		public IXUIButton m_ChangeToVoice;

		// Token: 0x040052AC RID: 21164
		public IXUILabel m_ChatTextCost;

		// Token: 0x040052AD RID: 21165
		public IXUISprite m_TextBoard;

		// Token: 0x040052AE RID: 21166
		public IXUISprite m_LimitBoard;

		// Token: 0x040052AF RID: 21167
		public IXUIButton m_DoSendChat;

		// Token: 0x040052B0 RID: 21168
		public IXUILabel m_ChatText;

		// Token: 0x040052B1 RID: 21169
		public IXUIInput m_ChatInput;

		// Token: 0x040052B2 RID: 21170
		public IXUILabelSymbol m_ChatSymbol;

		// Token: 0x040052B3 RID: 21171
		public IXUIInput m_Input;

		// Token: 0x040052B4 RID: 21172
		public IXUIButton m_Close;

		// Token: 0x040052B5 RID: 21173
		public IXUIButton m_GetFlowerBtn;

		// Token: 0x040052B6 RID: 21174
		public IXUILabel m_GetFlowerLeftTime;

		// Token: 0x040052B7 RID: 21175
		public IXUILabel m_FlowerOwnCount;

		// Token: 0x040052B8 RID: 21176
		public GameObject m_Flower;

		// Token: 0x040052B9 RID: 21177
		public GameObject m_FlowerEff;

		// Token: 0x040052BA RID: 21178
		public GameObject m_SpeakEff;

		// Token: 0x040052BB RID: 21179
		public GameObject m_objFriendBar;

		// Token: 0x040052BC RID: 21180
		public GameObject m_objGroupBar;

		// Token: 0x040052BD RID: 21181
		public IXUITweenTool m_FlowerTween;

		// Token: 0x040052BE RID: 21182
		public IXUILabel m_lblWorldTimes;

		// Token: 0x040052BF RID: 21183
		public IXUITweenTool m_worldTween;

		// Token: 0x040052C0 RID: 21184
		public IXUIButton m_btnAdd;

		// Token: 0x040052C1 RID: 21185
		public IXUISprite m_sprFriendClear;

		// Token: 0x040052C2 RID: 21186
		public IXUISprite m_sprFriendAdd;

		// Token: 0x040052C3 RID: 21187
		public IXUISprite m_sprFriendBack;

		// Token: 0x040052C4 RID: 21188
		public IXUISprite m_sprFriendChat;

		// Token: 0x040052C5 RID: 21189
		public IXUILabel m_lblFriendTip;

		// Token: 0x040052C6 RID: 21190
		public IXUISprite m_sprGroupBind;

		// Token: 0x040052C7 RID: 21191
		public IXUISprite m_sprGroupQuit;

		// Token: 0x040052C8 RID: 21192
		public IXUILabel m_lblGroupChat;

		// Token: 0x040052C9 RID: 21193
		public IXUISprite m_sprGroupClear;

		// Token: 0x040052CA RID: 21194
		public IXUISprite m_sprGroupBack;

		// Token: 0x040052CB RID: 21195
		public IXUISprite m_sprGroupCreate;

		// Token: 0x040052CC RID: 21196
		public IXUISprite m_sprMember;

		// Token: 0x040052CD RID: 21197
		public IXUISprite m_sprList;

		// Token: 0x040052CE RID: 21198
		public IXUISprite m_sprMore;

		// Token: 0x040052CF RID: 21199
		public Transform m_tranOffset;

		// Token: 0x040052D0 RID: 21200
		public IXUIPanel m_panelRoot;

		// Token: 0x040052D1 RID: 21201
		public IXUIPanel m_panelText;

		// Token: 0x040052D2 RID: 21202
		public IXUIPanel m_panelSubMenu;

		// Token: 0x040052D3 RID: 21203
		public IXUISprite m_sprSet;

		// Token: 0x040052D4 RID: 21204
		public IXUISprite m_sprMail;

		// Token: 0x040052D5 RID: 21205
		public IXUISprite m_sprMailRedpoint;

		// Token: 0x040052D6 RID: 21206
		public IXUISprite m_sprXinyue;

		// Token: 0x040052D7 RID: 21207
		public IXUISprite m_sprXinyueRed;

		// Token: 0x040052D8 RID: 21208
		public IXUISprite m_sprFriend;

		// Token: 0x040052D9 RID: 21209
		public IXUICheckBox m_chxAutoVoice;

		// Token: 0x040052DA RID: 21210
		public IXUILabel m_lblAutoVoice;

		// Token: 0x040052DB RID: 21211
		public GameObject m_btns;

		// Token: 0x040052DC RID: 21212
		public ILoopScrollView m_loopView;

		// Token: 0x040052DD RID: 21213
		public ILoopScrollView m_friendView;

		// Token: 0x040052DE RID: 21214
		public ILoopScrollView m_groupView;

		// Token: 0x040052DF RID: 21215
		public ILoopScrollView m_systemView;
	}
}
