using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018FB RID: 6395
	internal class DramaDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010B06 RID: 68358 RVA: 0x004287C4 File Offset: 0x004269C4
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

		// Token: 0x040079EC RID: 31212
		public IXUILabel m_name;

		// Token: 0x040079ED RID: 31213
		public IUIDummy m_leftSnapshot;

		// Token: 0x040079EE RID: 31214
		public IUIDummy m_rightSnapshot;

		// Token: 0x040079EF RID: 31215
		public Vector3 m_leftDummyPos;

		// Token: 0x040079F0 RID: 31216
		public Vector3 m_rightDummyPos;

		// Token: 0x040079F1 RID: 31217
		public Transform m_TaskArea;

		// Token: 0x040079F2 RID: 31218
		public Transform m_RewardArea;

		// Token: 0x040079F3 RID: 31219
		public IXUISprite m_FuncArea;

		// Token: 0x040079F4 RID: 31220
		public IXUILabel m_NpcText;

		// Token: 0x040079F5 RID: 31221
		public IXUILabel m_PlayerText;

		// Token: 0x040079F6 RID: 31222
		public IXUIButton m_TaskNext;

		// Token: 0x040079F7 RID: 31223
		public IXUISprite m_RewardBg;

		// Token: 0x040079F8 RID: 31224
		public IXUILabel m_RewardGold;

		// Token: 0x040079F9 RID: 31225
		public IXUILabel m_RewardExp;

		// Token: 0x040079FA RID: 31226
		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040079FB RID: 31227
		public IXUIButton m_RewardNext;

		// Token: 0x040079FC RID: 31228
		public Transform m_RewardItemBg;

		// Token: 0x040079FD RID: 31229
		public IXUILabel m_FuncText;

		// Token: 0x040079FE RID: 31230
		public XUIPool m_FuncPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040079FF RID: 31231
		public Transform m_FuncTplBg;

		// Token: 0x04007A00 RID: 31232
		public GameObject m_TaskAcceptArea;

		// Token: 0x04007A01 RID: 31233
		public IXUIButton m_BtnAccept;

		// Token: 0x04007A02 RID: 31234
		public IXUIButton m_BtnReject;

		// Token: 0x04007A03 RID: 31235
		public XUIPool m_AcceptItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007A04 RID: 31236
		public GameObject m_AcceptItemBg;

		// Token: 0x04007A05 RID: 31237
		public GameObject m_OperateArea;

		// Token: 0x04007A06 RID: 31238
		public GameObject m_OperateBtnPanel;

		// Token: 0x04007A07 RID: 31239
		public GameObject m_OperateListPanel;

		// Token: 0x04007A08 RID: 31240
		public IXUILabel m_OperateText;

		// Token: 0x04007A09 RID: 31241
		public DramaDlgBehaviour.OperateButton[] m_OperateBtns = new DramaDlgBehaviour.OperateButton[4];

		// Token: 0x04007A0A RID: 31242
		public DramaDlgBehaviour.OperateList[] m_OperateLists = new DramaDlgBehaviour.OperateList[4];

		// Token: 0x04007A0B RID: 31243
		public int MAX_OPERATE_BTN_COUNT;

		// Token: 0x04007A0C RID: 31244
		public int MAX_OPERATE_LIST_COUNT;

		// Token: 0x04007A0D RID: 31245
		public GameObject m_FavorGB;

		// Token: 0x04007A0E RID: 31246
		public IXUIList m_FavorBtnList;

		// Token: 0x04007A0F RID: 31247
		public IXUIButton m_SendBtn;

		// Token: 0x04007A10 RID: 31248
		public IXUIButton m_ExchangeBtn;

		// Token: 0x04007A11 RID: 31249
		public GameObject m_ExchangeRedPoint;

		// Token: 0x04007A12 RID: 31250
		public IXUILabel m_FavorText;

		// Token: 0x04007A13 RID: 31251
		public Transform m_FavorFrame;

		// Token: 0x02001A1E RID: 6686
		public class OperateBase
		{
			// Token: 0x06011149 RID: 69961 RVA: 0x00458514 File Offset: 0x00456714
			public OperateBase(GameObject go)
			{
				this.m_go = go;
			}

			// Token: 0x0601114A RID: 69962 RVA: 0x00458525 File Offset: 0x00456725
			public void SetActive(bool bActive)
			{
				this.m_go.SetActive(bActive);
			}

			// Token: 0x0601114B RID: 69963 RVA: 0x00458538 File Offset: 0x00456738
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

			// Token: 0x0601114C RID: 69964 RVA: 0x00458580 File Offset: 0x00456780
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

			// Token: 0x0400826B RID: 33387
			protected GameObject m_go;

			// Token: 0x0400826C RID: 33388
			protected XLeftTimeCounter leftTime;

			// Token: 0x0400826D RID: 33389
			protected IXUILabel leftTimeNote;
		}

		// Token: 0x02001A1F RID: 6687
		public class OperateButton : DramaDlgBehaviour.OperateBase
		{
			// Token: 0x0601114D RID: 69965 RVA: 0x004585BC File Offset: 0x004567BC
			public OperateButton(GameObject go) : base(go)
			{
				this.btn = (this.m_go.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
				this.text = (this.btn.gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel);
				this.leftTime = new XLeftTimeCounter(this.m_go.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel, true);
				this.leftTimeNote = (this.m_go.transform.Find("LeftTime/Note").GetComponent("XUILabel") as IXUILabel);
			}

			// Token: 0x0601114E RID: 69966 RVA: 0x00458685 File Offset: 0x00456885
			public void SetButton(string buttonName, ulong id, ButtonClickEventHandler clickEvent, bool enable)
			{
				this.btn.ID = id;
				this.btn.RegisterClickEventHandler(clickEvent);
				this.btn.SetEnable(enable, false);
				this.text.SetText(buttonName);
			}

			// Token: 0x0400826E RID: 33390
			public IXUIButton btn;

			// Token: 0x0400826F RID: 33391
			public IXUILabel text;
		}

		// Token: 0x02001A20 RID: 6688
		public class OperateList : DramaDlgBehaviour.OperateBase
		{
			// Token: 0x0601114F RID: 69967 RVA: 0x004586C0 File Offset: 0x004568C0
			public OperateList(GameObject go) : base(go)
			{
				this.bg = (this.m_go.GetComponent("XUISprite") as IXUISprite);
				this.text = (this.m_go.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
				this.selected = this.m_go.transform.Find("Selected").gameObject;
				this.leftTime = new XLeftTimeCounter(this.m_go.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel, true);
				this.leftTimeNote = (this.m_go.transform.Find("LeftTime/Note").GetComponent("XUILabel") as IXUILabel);
			}

			// Token: 0x06011150 RID: 69968 RVA: 0x0045879A File Offset: 0x0045699A
			public void SetList(string name, ulong id, SpriteClickEventHandler clickEvent)
			{
				this.bg.ID = id;
				this.bg.RegisterSpriteClickEventHandler(clickEvent);
				this.text.SetText(name);
			}

			// Token: 0x06011151 RID: 69969 RVA: 0x004587C4 File Offset: 0x004569C4
			public void SetSelect(bool bSelect)
			{
				this.selected.SetActive(bSelect);
			}

			// Token: 0x04008270 RID: 33392
			public IXUISprite bg;

			// Token: 0x04008271 RID: 33393
			public IXUILabel text;

			// Token: 0x04008272 RID: 33394
			public GameObject selected;
		}
	}
}
