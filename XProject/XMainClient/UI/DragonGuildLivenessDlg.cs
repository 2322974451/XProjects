using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DragonGuildLivenessDlg : DlgBase<DragonGuildLivenessDlg, DragonGuildLivenessBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopLiveness";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

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

		protected override void OnShow()
		{
			XDragonGuildDocument.DragonGuildLivenessData.ReqDragonGuildLivenessInfo();
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.SetRelatedDlg(this);
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.SetRelatedDlg(null);
			}
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
			base.uiBehaviour.m_Progress.Unload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			base.uiBehaviour.m_Progress.Update(Time.deltaTime);
		}

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

		public void RefreshBox()
		{
			this.ChangeChestProgressState(false);
			this.SetCurrentExpAmi();
			this.ShowReward(XDragonGuildDocument.DragonGuildLivenessData.FindNeedShowReward());
		}

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

		public void SetCurrentExpAmi()
		{
			base.uiBehaviour.m_Progress.TargetExp = XDragonGuildDocument.DragonGuildLivenessData.CurExp;
			base.uiBehaviour.m_TotalExpTween.SetNumberWithTween((ulong)XDragonGuildDocument.DragonGuildLivenessData.CurExp, "", false, true);
		}

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

		public void ResetBoxRedDot(int index)
		{
			bool flag = index < 0 || index >= base.uiBehaviour.m_Progress.ChestList.Count;
			if (!flag)
			{
				base.uiBehaviour.m_Progress.ChestList[index].Open();
			}
		}

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

		private void OnClosed(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

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

		private static readonly uint m_expIncreaseSpeed = 800U;

		private XDragonGuildDocument m_doc = XDragonGuildDocument.Doc;

		private List<DragonGuildLivenessTable.RowData> m_dragonguildLivenessRow;

		private int m_CurSelectIndex = 0;

		private float m_CoolTime = 0.5f;

		private float m_LastClickTime = 0f;
	}
}
