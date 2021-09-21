using System;
using System.Collections;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CE7 RID: 3303
	internal class GameMallTabsHandler : DlgHandlerBase
	{
		// Token: 0x0600B8ED RID: 47341 RVA: 0x00256574 File Offset: 0x00254774
		protected override void Init()
		{
			base.Init();
			this.m_btnGift = (base.transform.Find("Illustration").GetComponent("XUIButton") as IXUIButton);
			for (int i = 0; i < 8; i++)
			{
				this.m_objTabs[i] = (base.PanelObject.transform.Find("item" + i + "/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
				this.m_sprRedpoints[i] = (this.m_objTabs[i].gameObject.transform.Find("RedPoint").GetComponent("XUISprite") as IXUISprite);
				this.m_tabPos[i] = this.m_objTabs[i].gameObject.transform.parent.localPosition;
				bool flag = this.showTypes[i] == DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType;
				if (flag)
				{
				}
			}
		}

		// Token: 0x0600B8EE RID: 47342 RVA: 0x0025667C File Offset: 0x0025487C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = 0; i < this.m_objTabs.Length; i++)
			{
				this.m_objTabs[i].ID = (ulong)((long)i);
				this.m_objTabs[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			}
			this.m_btnGift.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGiftClick));
		}

		// Token: 0x0600B8EF RID: 47343 RVA: 0x002566EC File Offset: 0x002548EC
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this.doc == null;
			if (flag)
			{
				this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
			List<uint> uintList = XSingleton<XGlobalConfig>.singleton.GetUIntList("MallTabLevel");
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			this.malltype_list.Clear();
			bool flag2 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.currSys == XSysDefine.XSys_GameMall_Diamond;
			if (flag2)
			{
				bool flag3 = level >= uintList[0];
				if (flag3)
				{
					this.malltype_list.Add(MallType.WEEK);
				}
				bool flag4 = level >= uintList[7];
				if (flag4)
				{
					this.malltype_list.Add(MallType.EQUIP);
				}
				bool flag5 = level >= uintList[1];
				if (flag5)
				{
					this.malltype_list.Add(MallType.COST);
				}
				bool flag6 = level >= uintList[2];
				if (flag6)
				{
					this.malltype_list.Add(MallType.LONGYU);
				}
				bool flag7 = level >= uintList[3];
				if (flag7)
				{
					this.malltype_list.Add(MallType.FASHION);
				}
				bool flag8 = level >= uintList[5];
				if (flag8)
				{
					this.malltype_list.Add(MallType.GIFT);
				}
				bool flag9 = level >= uintList[0] && this.doc.vipTabshow;
				if (flag9)
				{
					this.malltype_list.Add(MallType.VIP);
				}
			}
			else
			{
				bool flag10 = DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.currSys == XSysDefine.XSys_GameMall_Dragon;
				if (flag10)
				{
					bool flag11 = level >= uintList[0];
					if (flag11)
					{
						this.malltype_list.Add(MallType.WEEK);
					}
					bool flag12 = level >= uintList[7];
					if (flag12)
					{
						this.malltype_list.Add(MallType.EQUIP);
					}
					bool flag13 = level >= uintList[1];
					if (flag13)
					{
						this.malltype_list.Add(MallType.COST);
					}
					bool flag14 = level >= uintList[2];
					if (flag14)
					{
						this.malltype_list.Add(MallType.LONGYU);
					}
					bool flag15 = level >= uintList[4];
					if (flag15)
					{
						this.malltype_list.Add(MallType.RIDE);
					}
					bool flag16 = level >= uintList[3];
					if (flag16)
					{
						this.malltype_list.Add(MallType.FASHION);
					}
				}
			}
			this._onShowCheck = true;
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.uiBehaviour.StartCoroutine(this.ResetOnshowCheck());
			this.CheckTabs();
			this.SetupTabs();
			this.m_btnGift.SetVisible(this.doc.presentStatus);
		}

		// Token: 0x0600B8F0 RID: 47344 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B8F1 RID: 47345 RVA: 0x00256974 File Offset: 0x00254B74
		private bool OnGiftClick(IXUIButton btn)
		{
			DlgBase<GiftboxDlg, GiftboxBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x0600B8F2 RID: 47346 RVA: 0x00256994 File Offset: 0x00254B94
		public void Refresh()
		{
			List<uint> uintList = XSingleton<XGlobalConfig>.singleton.GetUIntList("MallTabLevel");
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			bool flag = this.doc == null;
			if (flag)
			{
				this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
			int num = 0;
			for (int i = 0; i < this.showTypes.Length; i++)
			{
				bool flag2 = this.showTypes[i] == MallType.VIP;
				if (flag2)
				{
					num = i;
					break;
				}
			}
			GameObject gameObject = this.m_objTabs[num].gameObject;
			bool flag3 = gameObject != null;
			if (flag3)
			{
				gameObject.SetActive(this.doc.vipTabshow && this.malltype_list.Contains(MallType.VIP));
			}
		}

		// Token: 0x0600B8F3 RID: 47347 RVA: 0x00209F22 File Offset: 0x00208122
		public override void RefreshData()
		{
			base.RefreshData();
		}

		// Token: 0x0600B8F4 RID: 47348 RVA: 0x00256A58 File Offset: 0x00254C58
		public void CheckTabs()
		{
			this.SetMalltypeWithItemID();
			bool flag = !this.malltype_list.Contains(DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType);
			if (flag)
			{
				DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType = MallType.WEEK;
				this.m_objTabs[0].bChecked = true;
			}
			else
			{
				int num = 0;
				for (int i = 0; i < this.showTypes.Length; i++)
				{
					bool flag2 = this.showTypes[i] == DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType;
					if (flag2)
					{
						num = i;
						break;
					}
				}
				bool flag3 = num >= 0;
				if (flag3)
				{
					this.m_objTabs[num].bChecked = true;
				}
			}
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.QueryItemsInfo();
		}

		// Token: 0x0600B8F5 RID: 47349 RVA: 0x00256B0C File Offset: 0x00254D0C
		private void SetMalltypeWithItemID()
		{
			bool flag = this.doc.currItemID != 0;
			if (flag)
			{
				uint num = 0U;
				uint num2 = 0U;
				this.doc.FindItem(this.doc.currItemID, out num, out num2);
				bool flag2 = num2 > 0U;
				if (flag2)
				{
					DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType = (MallType)num2;
				}
			}
		}

		// Token: 0x0600B8F6 RID: 47350 RVA: 0x00256B60 File Offset: 0x00254D60
		private IEnumerator ResetOnshowCheck()
		{
			yield return new WaitForEndOfFrame();
			this._onShowCheck = false;
			yield break;
		}

		// Token: 0x0600B8F7 RID: 47351 RVA: 0x00256B70 File Offset: 0x00254D70
		private void SetupTabs()
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				MallType mallType = this.showTypes[i];
				bool flag = this.malltype_list.Contains(mallType);
				if (flag)
				{
					this.m_objTabs[i].SetVisible(true);
					this.m_objTabs[i].gameObject.transform.parent.localPosition = this.m_tabPos[num];
					this.m_sprRedpoints[i].SetVisible(this.IsShowNew(mallType));
					num++;
				}
				else
				{
					this.m_objTabs[i].SetVisible(false);
				}
			}
		}

		// Token: 0x0600B8F8 RID: 47352 RVA: 0x00256C1C File Offset: 0x00254E1C
		private bool IsShowNew(MallType type)
		{
			bool flag = this.doc == null;
			if (flag)
			{
				this.doc = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
			bool flag2 = type == MallType.WEEK;
			bool result;
			if (flag2)
			{
				result = this.doc.isNewWeekly;
			}
			else
			{
				bool flag3 = type == MallType.VIP;
				result = (flag3 && this.doc.isNewVIP);
			}
			return result;
		}

		// Token: 0x0600B8F9 RID: 47353 RVA: 0x00256C78 File Offset: 0x00254E78
		private bool OnTabClick(IXUICheckBox icbox)
		{
			bool flag = !icbox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				MallType type = this.showTypes[(int)icbox.ID];
				this.ExecuteTab(type);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B8FA RID: 47354 RVA: 0x00256CB4 File Offset: 0x00254EB4
		private void ExecuteTab(MallType type)
		{
			bool flag = type != MallType.VIP && this.mClickTab == MallType.VIP;
			if (flag)
			{
				this.doc.hotGoods.Clear();
				this.m_sprRedpoints[XFastEnumIntEqualityComparer<MallType>.ToInt(MallType.VIP) - 1].SetVisible(false);
			}
			bool flag2 = type != MallType.WEEK && this.doc.isNewWeekly;
			if (flag2)
			{
				this.doc.isNewWeekly = false;
				this.m_sprRedpoints[XFastEnumIntEqualityComparer<MallType>.ToInt(MallType.WEEK) - 1].SetVisible(false);
			}
			this.mClickTab = type;
			bool flag3 = !this._onShowCheck;
			if (flag3)
			{
				this.doc.currItemID = 0;
			}
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.mallType = type;
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton._gameBuyCardHander.ResetCurrCnt();
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.QueryItemsInfo();
		}

		// Token: 0x0400497E RID: 18814
		private const int tabsNum = 8;

		// Token: 0x0400497F RID: 18815
		private List<MallType> malltype_list = new List<MallType>();

		// Token: 0x04004980 RID: 18816
		public IXUIButton m_btnGift;

		// Token: 0x04004981 RID: 18817
		public IXUICheckBox[] m_objTabs = new IXUICheckBox[8];

		// Token: 0x04004982 RID: 18818
		public IXUISprite[] m_sprRedpoints = new IXUISprite[8];

		// Token: 0x04004983 RID: 18819
		private Vector3[] m_tabPos = new Vector3[8];

		// Token: 0x04004984 RID: 18820
		private bool _onShowCheck = false;

		// Token: 0x04004985 RID: 18821
		public MallType[] showTypes = new MallType[]
		{
			MallType.WEEK,
			MallType.EQUIP,
			MallType.COST,
			MallType.LONGYU,
			MallType.FASHION,
			MallType.RIDE,
			MallType.GIFT,
			MallType.VIP
		};

		// Token: 0x04004986 RID: 18822
		private MallType mClickTab = MallType.WEEK;

		// Token: 0x04004987 RID: 18823
		private XGameMallDocument doc;
	}
}
