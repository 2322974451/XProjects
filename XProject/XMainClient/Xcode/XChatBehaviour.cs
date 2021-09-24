using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XChatBehaviour : DlgBehaviourBase
	{

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

		public IXUISprite m_sprTq;

		public IXUILabel m_lblPriviledge;

		public IXUIButton m_ChangeToVoice;

		public IXUILabel m_ChatTextCost;

		public IXUISprite m_TextBoard;

		public IXUISprite m_LimitBoard;

		public IXUIButton m_DoSendChat;

		public IXUILabel m_ChatText;

		public IXUIInput m_ChatInput;

		public IXUILabelSymbol m_ChatSymbol;

		public IXUIInput m_Input;

		public IXUIButton m_Close;

		public IXUIButton m_GetFlowerBtn;

		public IXUILabel m_GetFlowerLeftTime;

		public IXUILabel m_FlowerOwnCount;

		public GameObject m_Flower;

		public GameObject m_FlowerEff;

		public GameObject m_SpeakEff;

		public GameObject m_objFriendBar;

		public GameObject m_objGroupBar;

		public IXUITweenTool m_FlowerTween;

		public IXUILabel m_lblWorldTimes;

		public IXUITweenTool m_worldTween;

		public IXUIButton m_btnAdd;

		public IXUISprite m_sprFriendClear;

		public IXUISprite m_sprFriendAdd;

		public IXUISprite m_sprFriendBack;

		public IXUISprite m_sprFriendChat;

		public IXUILabel m_lblFriendTip;

		public IXUISprite m_sprGroupBind;

		public IXUISprite m_sprGroupQuit;

		public IXUILabel m_lblGroupChat;

		public IXUISprite m_sprGroupClear;

		public IXUISprite m_sprGroupBack;

		public IXUISprite m_sprGroupCreate;

		public IXUISprite m_sprMember;

		public IXUISprite m_sprList;

		public IXUISprite m_sprMore;

		public Transform m_tranOffset;

		public IXUIPanel m_panelRoot;

		public IXUIPanel m_panelText;

		public IXUIPanel m_panelSubMenu;

		public IXUISprite m_sprSet;

		public IXUISprite m_sprMail;

		public IXUISprite m_sprMailRedpoint;

		public IXUISprite m_sprXinyue;

		public IXUISprite m_sprXinyueRed;

		public IXUISprite m_sprFriend;

		public IXUICheckBox m_chxAutoVoice;

		public IXUILabel m_lblAutoVoice;

		public GameObject m_btns;

		public ILoopScrollView m_loopView;

		public ILoopScrollView m_friendView;

		public ILoopScrollView m_groupView;

		public ILoopScrollView m_systemView;
	}
}
