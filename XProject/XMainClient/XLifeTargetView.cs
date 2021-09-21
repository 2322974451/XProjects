using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F00 RID: 3840
	internal class XLifeTargetView : DlgBase<XLifeTargetView, XLifeTargetDlgBehaviour>
	{
		// Token: 0x1700358B RID: 13707
		// (get) Token: 0x0600CC05 RID: 52229 RVA: 0x002ED520 File Offset: 0x002EB720
		public override string fileName
		{
			get
			{
				return "GameSystem/LifeTargetDlg";
			}
		}

		// Token: 0x1700358C RID: 13708
		// (get) Token: 0x0600CC06 RID: 52230 RVA: 0x002ED538 File Offset: 0x002EB738
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700358D RID: 13709
		// (get) Token: 0x0600CC07 RID: 52231 RVA: 0x002ED54C File Offset: 0x002EB74C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700358E RID: 13710
		// (get) Token: 0x0600CC08 RID: 52232 RVA: 0x002ED560 File Offset: 0x002EB760
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600CC09 RID: 52233 RVA: 0x002ED573 File Offset: 0x002EB773
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			this._doc.LifeTargetView = this;
		}

		// Token: 0x0600CC0A RID: 52234 RVA: 0x002ED593 File Offset: 0x002EB793
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600CC0B RID: 52235 RVA: 0x002ED5B3 File Offset: 0x002EB7B3
		protected override void OnUnload()
		{
			base.OnUnload();
			this._doc.LifeTargetView = null;
		}

		// Token: 0x0600CC0C RID: 52236 RVA: 0x002ED5CA File Offset: 0x002EB7CA
		protected override void OnShow()
		{
			this.RefreshList();
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		// Token: 0x0600CC0D RID: 52237 RVA: 0x002ED5E8 File Offset: 0x002EB7E8
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600CC0E RID: 52238 RVA: 0x002ED604 File Offset: 0x002EB804
		public void RefreshList()
		{
			base.uiBehaviour.m_TargetPool.ReturnAll(false);
			List<uint> list = new List<uint>();
			List<uint> list2 = new List<uint>();
			this._doc.UpdateShowingAchivementListWithoutMergeType(ref list, ref list2);
			Vector3 localPosition = base.uiBehaviour.m_TargetPool._tpl.transform.localPosition;
			int num = -1;
			foreach (uint aid in list)
			{
				AchivementTable.RowData achivementData = this._doc.GetAchivementData(aid);
				bool flag = achivementData == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("achivement not found", null, null, null, null, null);
				}
				else
				{
					bool flag2 = achivementData.AchievementCategory != 1;
					if (!flag2)
					{
						GameObject gameObject = base.uiBehaviour.m_TargetPool.FetchGameObject(false);
						bool flag3 = gameObject != null;
						if (flag3)
						{
							gameObject.transform.localPosition = new Vector3(localPosition.x, localPosition.y - (float)(++num * base.uiBehaviour.m_TargetPool.TplHeight), localPosition.z);
							this._SetAchiveRecord(gameObject, achivementData, AchivementState.Achive_NoFetch);
						}
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
				}
				else
				{
					bool flag5 = achivementData2.AchievementCategory != 1;
					if (!flag5)
					{
						GameObject gameObject2 = base.uiBehaviour.m_TargetPool.FetchGameObject(false);
						bool flag6 = gameObject2 != null;
						if (flag6)
						{
							gameObject2.transform.localPosition = new Vector3(localPosition.x, localPosition.y - (float)(++num * base.uiBehaviour.m_TargetPool.TplHeight), localPosition.z);
							this._SetAchiveRecord(gameObject2, achivementData2, AchivementState.Not_Achive);
						}
					}
				}
			}
		}

		// Token: 0x0600CC0F RID: 52239 RVA: 0x002ED854 File Offset: 0x002EBA54
		protected void _SetAchiveRecord(GameObject go, AchivementTable.RowData data, AchivementState state)
		{
			IXUILabel ixuilabel = go.transform.FindChild("TargetBg/Name").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("TargetBg/ItemTpl/Quality").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = go.transform.FindChild("TargetBg/ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite;
			IXUIButton ixuibutton = go.transform.FindChild("TargetBg/Fetch").GetComponent("XUIButton") as IXUIButton;
			Transform transform = go.transform.FindChild("TargetBg/CantFetch");
			IXUILabel ixuilabel2 = transform.FindChild("Condition").GetComponent("XUILabel") as IXUILabel;
			bool flag = state == AchivementState.Achive_NoFetch;
			if (flag)
			{
				ixuibutton.gameObject.SetActive(true);
				ixuibutton.ID = (ulong)((long)data.AchievementID);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFetchClicked));
				transform.gameObject.SetActive(false);
			}
			else
			{
				ixuibutton.gameObject.SetActive(false);
				transform.gameObject.SetActive(true);
			}
			ixuilabel.SetText(data.AchievementName);
			ixuilabel2.SetText(data.AchievementDescription);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(go.transform.FindChild("TargetBg/ItemTpl").gameObject, data.AchievementItem[0, 0], 0, false);
		}

		// Token: 0x0600CC10 RID: 52240 RVA: 0x002ED9CC File Offset: 0x002EBBCC
		protected bool OnFetchClicked(IXUIButton button)
		{
			this._doc.FetchAchivement((uint)button.ID);
			return true;
		}

		// Token: 0x04005A99 RID: 23193
		private XAchievementDocument _doc = null;
	}
}
