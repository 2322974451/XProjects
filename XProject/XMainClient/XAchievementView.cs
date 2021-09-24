using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAchievementView : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XAchievementDocument.uuID) as XAchievementDocument);
			this._doc.AchievementView = this;
			Transform transform = base.PanelObject.transform.Find("Panel/RecordTpl");
			this.m_RewardPool.SetupPool(transform.parent.gameObject, transform.gameObject, 50U, false);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshAchivementList();
		}

		public override void OnUnload()
		{
			this._doc.AchievementView = null;
			base.OnUnload();
		}

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

		protected bool OnFetchClicked(IXUIButton button)
		{
			this._doc.FetchAchivement((uint)button.ID);
			return true;
		}

		public void RefreshLoginList()
		{
		}

		private XAchievementDocument _doc = null;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
