using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016D8 RID: 5848
	internal class DragonGuildLivenessDlg : DlgBase<DragonGuildLivenessDlg, DragonGuildLivenessBehaviour>
	{
		// Token: 0x17003746 RID: 14150
		// (get) Token: 0x0600F12C RID: 61740 RVA: 0x00353204 File Offset: 0x00351404
		public override string fileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopLiveness";
			}
		}

		// Token: 0x17003747 RID: 14151
		// (get) Token: 0x0600F12D RID: 61741 RVA: 0x0035321C File Offset: 0x0035141C
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003748 RID: 14152
		// (get) Token: 0x0600F12E RID: 61742 RVA: 0x00353230 File Offset: 0x00351430
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003749 RID: 14153
		// (get) Token: 0x0600F12F RID: 61743 RVA: 0x00353244 File Offset: 0x00351444
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600F130 RID: 61744 RVA: 0x00353258 File Offset: 0x00351458
		protected override void Init()
		{
			XDragonGuildDocument.DragonGuildLivenessData.View = this;
			GameObject tpl = base.uiBehaviour.m_loopScrool.GetTpl();
			bool flag = tpl != null && tpl.GetComponent<DragonGuildLivenessRecordItem>() == null;
			if (flag)
			{
				tpl.AddComponent<DragonGuildLivenessRecordItem>();
			}
			base.uiBehaviour.m_Progress.IncreaseSpeed = DragonGuildLivenessDlg.m_expIncreaseSpeed;
			this.m_dragonguildLivenessRow = null;
			XDragonGuildDocument.DragonGuildLivenessData.GetDragonGuildLivenessRowsByLevel(this.m_doc.BaseData.level, out this.m_dragonguildLivenessRow);
			for (int i = 0; i < this.m_dragonguildLivenessRow.Count; i++)
			{
				GameObject chest = base.uiBehaviour.m_ChestPool.FetchGameObject(false);
				XChest chest2 = new XChest(chest, this.m_dragonguildLivenessRow[i].boxPic);
				base.uiBehaviour.m_Progress.AddChest(chest2);
			}
			this.ChangeChestProgressState(true);
		}

		// Token: 0x0600F131 RID: 61745 RVA: 0x0035334C File Offset: 0x0035154C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClosed));
			this.m_dragonguildLivenessRow = null;
			XDragonGuildDocument.DragonGuildLivenessData.GetDragonGuildLivenessRowsByLevel(this.m_doc.BaseData.level, out this.m_dragonguildLivenessRow);
			for (int i = 0; i < this.m_dragonguildLivenessRow.Count; i++)
			{
				base.uiBehaviour.m_Progress.ChestList[i].m_Chest.ID = (ulong)((long)i);
				base.uiBehaviour.m_Progress.ChestList[i].m_Chest.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClicked));
			}
		}

		// Token: 0x0600F132 RID: 61746 RVA: 0x00353414 File Offset: 0x00351614
		protected override void OnShow()
		{
			XDragonGuildDocument.DragonGuildLivenessData.ReqDragonGuildLivenessInfo();
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.SetRelatedDlg(this);
			}
		}

		// Token: 0x0600F133 RID: 61747 RVA: 0x00353448 File Offset: 0x00351648
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.SetRelatedDlg(null);
			}
		}

		// Token: 0x0600F134 RID: 61748 RVA: 0x00353477 File Offset: 0x00351677
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600F135 RID: 61749 RVA: 0x00353481 File Offset: 0x00351681
		protected override void OnUnload()
		{
			base.OnUnload();
			base.uiBehaviour.m_Progress.Unload();
		}

		// Token: 0x0600F136 RID: 61750 RVA: 0x0035349C File Offset: 0x0035169C
		public override void OnUpdate()
		{
			base.OnUpdate();
			base.uiBehaviour.m_Progress.Update(Time.deltaTime);
		}

		// Token: 0x0600F137 RID: 61751 RVA: 0x003534BC File Offset: 0x003516BC
		public void FillContent()
		{
			this.RefreshBox();
			List<LoopItemData> list = new List<LoopItemData>();
			string empty = string.Empty;
			for (int i = 0; i < XDragonGuildDocument.DragonGuildLivenessData.RecordList.Count; i++)
			{
				DragonGuildLivenessRecord dragonGuildLivenessRecord = XDragonGuildDocument.DragonGuildLivenessData.RecordList[i];
				dragonGuildLivenessRecord.LoopID = XSingleton<XCommon>.singleton.XHash(XDragonGuildDocument.DragonGuildLivenessData.RecordList[i].ToString() + i);
				list.Add(dragonGuildLivenessRecord);
			}
			base.uiBehaviour.m_loopScrool.Init(list, new DelegateHandler(this.RefreshRecordItem), null, 0, true);
		}

		// Token: 0x0600F138 RID: 61752 RVA: 0x0035356A File Offset: 0x0035176A
		public void RefreshBox()
		{
			this.ChangeChestProgressState(false);
			this.SetCurrentExpAmi();
			this.ShowReward(XDragonGuildDocument.DragonGuildLivenessData.FindNeedShowReward());
		}

		// Token: 0x0600F139 RID: 61753 RVA: 0x00353590 File Offset: 0x00351790
		private void RefreshRecordItem(ILoopItemObject item, LoopItemData data)
		{
			DragonGuildLivenessRecord dragonGuildLivenessRecord = data as DragonGuildLivenessRecord;
			bool flag = dragonGuildLivenessRecord != null;
			if (flag)
			{
				GameObject obj = item.GetObj();
				bool flag2 = obj != null;
				if (flag2)
				{
					DragonGuildLivenessRecordItem component = obj.GetComponent<DragonGuildLivenessRecordItem>();
					bool flag3 = component != null;
					if (flag3)
					{
						component.Refresh(dragonGuildLivenessRecord);
					}
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("GuildMiniReportItem info is null", null, null, null, null, null);
			}
		}

		// Token: 0x0600F13A RID: 61754 RVA: 0x003535FC File Offset: 0x003517FC
		public void SetCurrentExpAmi()
		{
			base.uiBehaviour.m_Progress.TargetExp = XDragonGuildDocument.DragonGuildLivenessData.CurExp;
			base.uiBehaviour.m_TotalExpTween.SetNumberWithTween((ulong)XDragonGuildDocument.DragonGuildLivenessData.CurExp, "", false, true);
		}

		// Token: 0x0600F13B RID: 61755 RVA: 0x00353648 File Offset: 0x00351848
		public void ChangeChestProgressState(bool init = false)
		{
			for (int i = 0; i < this.m_dragonguildLivenessRow.Count; i++)
			{
				XChest xchest = base.uiBehaviour.m_Progress.ChestList[i];
				if (init)
				{
					xchest.SetExp(this.m_dragonguildLivenessRow[i].liveness);
				}
				xchest.Opened = XDragonGuildDocument.DragonGuildLivenessData.IsChestOpened(i + 1);
			}
			if (init)
			{
				base.uiBehaviour.m_Progress.SetExp(0U, XDragonGuildDocument.DragonGuildLivenessData.MaxExp);
			}
		}

		// Token: 0x0600F13C RID: 61756 RVA: 0x003536E0 File Offset: 0x003518E0
		public void ResetBoxRedDot(int index)
		{
			bool flag = index < 0 || index >= base.uiBehaviour.m_Progress.ChestList.Count;
			if (!flag)
			{
				base.uiBehaviour.m_Progress.ChestList[index].Open();
			}
		}

		// Token: 0x0600F13D RID: 61757 RVA: 0x00353734 File Offset: 0x00351934
		private void OnChestClicked(IXUISprite iSp)
		{
			bool flag = this.SetButtonCool(this.m_CoolTime);
			if (!flag)
			{
				int index = (int)iSp.ID;
				this.ShowReward(index);
				bool flag2 = base.uiBehaviour.m_Progress.IsExpEnough(index);
				if (flag2)
				{
					DragonGuildLivenessTable.RowData rowData = this.m_dragonguildLivenessRow[index];
					bool flag3 = rowData != null;
					if (flag3)
					{
						XDragonGuildDocument.DragonGuildLivenessData.ReqTakeDragonGuildChest(rowData.index);
					}
				}
			}
		}

		// Token: 0x0600F13E RID: 61758 RVA: 0x003537A4 File Offset: 0x003519A4
		public void ShowReward(int index)
		{
			this.m_CurSelectIndex = index;
			base.uiBehaviour.m_RewardItemPool.ReturnAll(false);
			DragonGuildLivenessTable.RowData rowData = this.m_dragonguildLivenessRow[this.m_CurSelectIndex];
			for (int i = 0; i < rowData.viewabledrop.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_RewardItemPool.FetchGameObject(false);
				bool flag = rowData.viewabledrop[i, 0] == 4U;
				if (flag)
				{
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)rowData.viewabledrop[i, 0], 0, false);
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)rowData.viewabledrop[i, 0], (int)rowData.viewabledrop[i, 1], true);
				}
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject, (int)rowData.viewabledrop[i, 0]);
				Vector3 tplPos = base.uiBehaviour.m_RewardItemPool.TplPos;
				gameObject.transform.localPosition = new Vector3(tplPos.x + (float)base.uiBehaviour.m_RewardItemPool.TplWidth * ((float)(-(float)rowData.viewabledrop.Count) / 2f + 0.5f + (float)i), tplPos.y, tplPos.z);
			}
			base.uiBehaviour.m_chestTips.SetText(rowData.liveness.ToString());
		}

		// Token: 0x0600F13F RID: 61759 RVA: 0x00353918 File Offset: 0x00351B18
		private void OnClosed(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0600F140 RID: 61760 RVA: 0x00353924 File Offset: 0x00351B24
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_LastClickTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_LastClickTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x04006706 RID: 26374
		private static readonly uint m_expIncreaseSpeed = 800U;

		// Token: 0x04006707 RID: 26375
		private XDragonGuildDocument m_doc = XDragonGuildDocument.Doc;

		// Token: 0x04006708 RID: 26376
		private List<DragonGuildLivenessTable.RowData> m_dragonguildLivenessRow;

		// Token: 0x04006709 RID: 26377
		private int m_CurSelectIndex = 0;

		// Token: 0x0400670A RID: 26378
		private float m_CoolTime = 0.5f;

		// Token: 0x0400670B RID: 26379
		private float m_LastClickTime = 0f;
	}
}
