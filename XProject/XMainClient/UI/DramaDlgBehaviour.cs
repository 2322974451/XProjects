using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DramaDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_name = (base.transform.FindChild("_canvas/TalkTextBg/Talker/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_TaskArea = base.transform.FindChild("_canvas/TalkTextBg/TaskText");
			this.m_RewardArea = base.transform.FindChild("_canvas/TalkTextBg/TaskReward");
			this.m_FuncArea = (base.transform.FindChild("_canvas/TalkTextBg/NormalFunc").GetComponent("XUISprite") as IXUISprite);
			this.m_NpcText = (base.transform.FindChild("_canvas/TalkTextBg/TaskText/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_TaskNext = (base.transform.FindChild("_canvas/TalkTextBg/TaskText/Next").GetComponent("XUIButton") as IXUIButton);
			this.m_PlayerText = (base.transform.FindChild("_canvas/TalkTextBg/TaskText/PlayerText").GetComponent("XUILabel") as IXUILabel);
			this.m_RewardBg = (base.transform.FindChild("_canvas/TalkTextBg/TaskReward").GetComponent("XUISprite") as IXUISprite);
			this.m_RewardGold = (base.transform.FindChild("_canvas/TalkTextBg/TaskReward/Gold/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_RewardExp = (base.transform.FindChild("_canvas/TalkTextBg/TaskReward/Exp/Value").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("_canvas/TalkTextBg/TaskReward/P/ItemTpl");
			this.m_RewardItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_RewardNext = (base.transform.FindChild("_canvas/TalkTextBg/TaskReward/Next").GetComponent("XUIButton") as IXUIButton);
			this.m_RewardItemBg = base.transform.FindChild("_canvas/TalkTextBg/TaskReward/P");
			this.m_FuncText = (base.transform.FindChild("_canvas/TalkTextBg/NormalFunc/Text").GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("_canvas/TalkTextBg/NormalFunc/P/FuncTpl");
			this.m_FuncPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_FuncTplBg = base.transform.FindChild("_canvas/TalkTextBg/NormalFunc/P");
			this.m_leftSnapshot = (base.transform.FindChild("_canvas/LeftSnapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_rightSnapshot = (base.transform.FindChild("_canvas/RightSnapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_leftDummyPos = this.m_leftSnapshot.transform.localPosition;
			this.m_rightDummyPos = this.m_rightSnapshot.transform.localPosition;
			this.m_TaskAcceptArea = base.transform.Find("_canvas/TalkTextBg/TaskAccept").gameObject;
			this.m_BtnAccept = (this.m_TaskAcceptArea.transform.Find("BtnOK").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnReject = (this.m_TaskAcceptArea.transform.Find("BtnCancel").GetComponent("XUIButton") as IXUIButton);
			this.m_AcceptItemBg = this.m_TaskAcceptArea.transform.FindChild("ItemList").gameObject;
			transform = this.m_AcceptItemBg.transform.Find("ItemTpl");
			this.m_AcceptItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_OperateArea = base.transform.Find("_canvas/TalkTextBg/Operate").gameObject;
			this.m_OperateBtnPanel = this.m_OperateArea.transform.Find("Buttons").gameObject;
			this.m_OperateListPanel = this.m_OperateArea.transform.Find("List").gameObject;
			this.m_OperateText = (this.m_OperateArea.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
			for (int i = 0; i < 5; i++)
			{
				transform = this.m_OperateBtnPanel.transform.Find("Btn" + i);
				bool flag = transform == null;
				if (flag)
				{
					this.MAX_OPERATE_BTN_COUNT = i;
					break;
				}
				this.m_OperateBtns[i] = new DramaDlgBehaviour.OperateButton(transform.gameObject);
			}
			for (int j = 0; j < 4; j++)
			{
				transform = this.m_OperateListPanel.transform.Find("List" + j);
				bool flag2 = transform == null;
				if (flag2)
				{
					this.MAX_OPERATE_LIST_COUNT = j;
					break;
				}
				this.m_OperateLists[j] = new DramaDlgBehaviour.OperateList(transform.gameObject);
			}
			this.m_FavorGB = base.transform.Find("_canvas/TalkTextBg/NpcBlessing").gameObject;
			this.m_FavorBtnList = (this.m_FavorGB.transform.FindChild("Grid").GetComponent("XUIList") as IXUIList);
			this.m_SendBtn = (this.m_FavorGB.transform.FindChild("Grid/BtnSend").GetComponent("XUIButton") as IXUIButton);
			this.m_ExchangeBtn = (this.m_FavorGB.transform.FindChild("Grid/BtnChange").GetComponent("XUIButton") as IXUIButton);
			this.m_ExchangeRedPoint = this.m_FavorGB.transform.FindChild("Grid/BtnChange/RedPoint").gameObject;
			this.m_FavorText = (this.m_FavorGB.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel);
			this.m_FavorFrame = this.m_FavorGB.transform.FindChild("FavorFrame");
		}

		public IXUILabel m_name;

		public IUIDummy m_leftSnapshot;

		public IUIDummy m_rightSnapshot;

		public Vector3 m_leftDummyPos;

		public Vector3 m_rightDummyPos;

		public Transform m_TaskArea;

		public Transform m_RewardArea;

		public IXUISprite m_FuncArea;

		public IXUILabel m_NpcText;

		public IXUILabel m_PlayerText;

		public IXUIButton m_TaskNext;

		public IXUISprite m_RewardBg;

		public IXUILabel m_RewardGold;

		public IXUILabel m_RewardExp;

		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIButton m_RewardNext;

		public Transform m_RewardItemBg;

		public IXUILabel m_FuncText;

		public XUIPool m_FuncPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform m_FuncTplBg;

		public GameObject m_TaskAcceptArea;

		public IXUIButton m_BtnAccept;

		public IXUIButton m_BtnReject;

		public XUIPool m_AcceptItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_AcceptItemBg;

		public GameObject m_OperateArea;

		public GameObject m_OperateBtnPanel;

		public GameObject m_OperateListPanel;

		public IXUILabel m_OperateText;

		public DramaDlgBehaviour.OperateButton[] m_OperateBtns = new DramaDlgBehaviour.OperateButton[4];

		public DramaDlgBehaviour.OperateList[] m_OperateLists = new DramaDlgBehaviour.OperateList[4];

		public int MAX_OPERATE_BTN_COUNT;

		public int MAX_OPERATE_LIST_COUNT;

		public GameObject m_FavorGB;

		public IXUIList m_FavorBtnList;

		public IXUIButton m_SendBtn;

		public IXUIButton m_ExchangeBtn;

		public GameObject m_ExchangeRedPoint;

		public IXUILabel m_FavorText;

		public Transform m_FavorFrame;

		public class OperateBase
		{

			public OperateBase(GameObject go)
			{
				this.m_go = go;
			}

			public void SetActive(bool bActive)
			{
				this.m_go.SetActive(bActive);
			}

			public void SetLeftTime(float second, string note)
			{
				bool flag = this.leftTime != null;
				if (flag)
				{
					this.leftTime.SetLeftTime(second, -1);
				}
				bool flag2 = this.leftTimeNote != null;
				if (flag2)
				{
					this.leftTimeNote.SetText(note);
				}
			}

			public void Update()
			{
				bool flag = !this.m_go.activeSelf;
				if (!flag)
				{
					bool flag2 = this.leftTime != null;
					if (flag2)
					{
						this.leftTime.Update();
					}
				}
			}

			protected GameObject m_go;

			protected XLeftTimeCounter leftTime;

			protected IXUILabel leftTimeNote;
		}

		public class OperateButton : DramaDlgBehaviour.OperateBase
		{

			public OperateButton(GameObject go) : base(go)
			{
				this.btn = (this.m_go.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
				this.text = (this.btn.gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel);
				this.leftTime = new XLeftTimeCounter(this.m_go.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel, true);
				this.leftTimeNote = (this.m_go.transform.Find("LeftTime/Note").GetComponent("XUILabel") as IXUILabel);
			}

			public void SetButton(string buttonName, ulong id, ButtonClickEventHandler clickEvent, bool enable)
			{
				this.btn.ID = id;
				this.btn.RegisterClickEventHandler(clickEvent);
				this.btn.SetEnable(enable, false);
				this.text.SetText(buttonName);
			}

			public IXUIButton btn;

			public IXUILabel text;
		}

		public class OperateList : DramaDlgBehaviour.OperateBase
		{

			public OperateList(GameObject go) : base(go)
			{
				this.bg = (this.m_go.GetComponent("XUISprite") as IXUISprite);
				this.text = (this.m_go.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
				this.selected = this.m_go.transform.Find("Selected").gameObject;
				this.leftTime = new XLeftTimeCounter(this.m_go.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel, true);
				this.leftTimeNote = (this.m_go.transform.Find("LeftTime/Note").GetComponent("XUILabel") as IXUILabel);
			}

			public void SetList(string name, ulong id, SpriteClickEventHandler clickEvent)
			{
				this.bg.ID = id;
				this.bg.RegisterSpriteClickEventHandler(clickEvent);
				this.text.SetText(name);
			}

			public void SetSelect(bool bSelect)
			{
				this.selected.SetActive(bSelect);
			}

			public IXUISprite bg;

			public IXUILabel text;

			public GameObject selected;
		}
	}
}
