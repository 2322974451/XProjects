using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F03 RID: 3843
	internal class XAchievementView : DlgHandlerBase
	{
		// Token: 0x0600CC2D RID: 52269 RVA: 0x002EEC48 File Offset: 0x002ECE48
		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XAchievementDocument.uuID) as XAchievementDocument);
			this._doc.AchievementView = this;
			Transform transform = base.PanelObject.transform.Find("Panel/RecordTpl");
			this.m_RewardPool.SetupPool(transform.parent.gameObject, transform.gameObject, 50U, false);
		}

		// Token: 0x0600CC2E RID: 52270 RVA: 0x002EECBF File Offset: 0x002ECEBF
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshAchivementList();
		}

		// Token: 0x0600CC2F RID: 52271 RVA: 0x002EECD0 File Offset: 0x002ECED0
		public override void OnUnload()
		{
			this._doc.AchievementView = null;
			base.OnUnload();
		}

		// Token: 0x0600CC30 RID: 52272 RVA: 0x002EECE8 File Offset: 0x002ECEE8
		public void RefreshAchivementList()
		{
			this.m_RewardPool.ReturnAll(false);
			List<uint> list = new List<uint>();
			List<uint> list2 = new List<uint>();
			this._doc.UpdateShowingAchivementList(ref list, ref list2);
			Vector3 localPosition = this.m_RewardPool._tpl.transform.localPosition;
			foreach (uint aid in list)
			{
				AchivementTable.RowData achivementData = this._doc.GetAchivementData(aid);
				bool flag = achivementData == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("achivement not found", null, null, null, null, null);
					return;
				}
				bool flag2 = achivementData.AchievementCategory == 1;
				if (!flag2)
				{
					GameObject gameObject = this.m_RewardPool.FetchGameObject(false);
					bool flag3 = gameObject != null;
					if (flag3)
					{
						gameObject.transform.localPosition = localPosition;
						localPosition.y -= (float)this.m_RewardPool.TplHeight;
						this._SetAchiveRecord(gameObject, achivementData, AchivementState.Achive_NoFetch);
					}
				}
			}
			foreach (uint aid2 in list2)
			{
				AchivementTable.RowData achivementData2 = this._doc.GetAchivementData(aid2);
				bool flag4 = achivementData2 == null;
				if (flag4)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("achivement not found", null, null, null, null, null);
					break;
				}
				bool flag5 = achivementData2.AchievementCategory == 1;
				if (!flag5)
				{
					GameObject gameObject2 = this.m_RewardPool.FetchGameObject(false);
					bool flag6 = gameObject2 != null;
					if (flag6)
					{
						gameObject2.transform.localPosition = localPosition;
						localPosition.y -= (float)this.m_RewardPool.TplHeight;
						this._SetAchiveRecord(gameObject2, achivementData2, AchivementState.Not_Achive);
					}
				}
			}
		}

		// Token: 0x0600CC31 RID: 52273 RVA: 0x002EEEEC File Offset: 0x002ED0EC
		protected void _SetAchiveRecord(GameObject go, AchivementTable.RowData achivementData, AchivementState state)
		{
			IXUISprite ixuisprite = go.GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Desc").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite2 = go.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUIButton ixuibutton = go.transform.FindChild("Fetch").GetComponent("XUIButton") as IXUIButton;
			Transform transform = go.transform.FindChild("CantFetch");
			GameObject gameObject = go.transform.FindChild("Item1").gameObject;
			GameObject gameObject2 = go.transform.FindChild("Item2").gameObject;
			gameObject.SetActive(false);
			gameObject2.SetActive(false);
			bool flag = state == AchivementState.Achive_NoFetch;
			if (flag)
			{
				ixuibutton.gameObject.SetActive(true);
				ixuibutton.ID = (ulong)((long)achivementData.AchievementID);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFetchClicked));
				transform.gameObject.SetActive(false);
			}
			else
			{
				ixuibutton.gameObject.SetActive(false);
				transform.gameObject.SetActive(true);
			}
			ixuilabel.SetText(achivementData.AchievementName);
			ixuilabel2.SetText(achivementData.AchievementDescription);
			ixuisprite2.SetSprite(achivementData.AchievementIcon);
			bool flag2 = achivementData.AchievementItem.Count > 0;
			if (flag2)
			{
				gameObject.SetActive(true);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, achivementData.AchievementItem[0, 0], achivementData.AchievementItem[0, 1], false);
			}
			bool flag3 = achivementData.AchievementItem.Count > 1;
			if (flag3)
			{
				gameObject.SetActive(true);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, achivementData.AchievementItem[1, 0], achivementData.AchievementItem[1, 1], false);
			}
		}

		// Token: 0x0600CC32 RID: 52274 RVA: 0x002EF108 File Offset: 0x002ED308
		protected bool OnFetchClicked(IXUIButton button)
		{
			this._doc.FetchAchivement((uint)button.ID);
			return true;
		}

		// Token: 0x0600CC33 RID: 52275 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void RefreshLoginList()
		{
		}

		// Token: 0x04005AAE RID: 23214
		private XAchievementDocument _doc = null;

		// Token: 0x04005AAF RID: 23215
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
