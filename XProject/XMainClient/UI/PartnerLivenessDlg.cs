using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017F1 RID: 6129
	internal class PartnerLivenessDlg : DlgBase<PartnerLivenessDlg, PartnerLivenessBehaviour>
	{
		// Token: 0x170038D4 RID: 14548
		// (get) Token: 0x0600FE14 RID: 65044 RVA: 0x003BABF8 File Offset: 0x003B8DF8
		public override string fileName
		{
			get
			{
				return "Partner/PartnerLiveness";
			}
		}

		// Token: 0x170038D5 RID: 14549
		// (get) Token: 0x0600FE15 RID: 65045 RVA: 0x003BAC10 File Offset: 0x003B8E10
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170038D6 RID: 14550
		// (get) Token: 0x0600FE16 RID: 65046 RVA: 0x003BAC24 File Offset: 0x003B8E24
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038D7 RID: 14551
		// (get) Token: 0x0600FE17 RID: 65047 RVA: 0x003BAC38 File Offset: 0x003B8E38
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600FE18 RID: 65048 RVA: 0x003BAC4C File Offset: 0x003B8E4C
		protected override void Init()
		{
			XPartnerDocument.PartnerLivenessData.View = this;
			GameObject tpl = base.uiBehaviour.m_loopScrool.GetTpl();
			bool flag = tpl != null && tpl.GetComponent<PartnerLivenessRecordItem>() == null;
			if (flag)
			{
				tpl.AddComponent<PartnerLivenessRecordItem>();
			}
			base.uiBehaviour.m_Progress.IncreaseSpeed = PartnerLivenessDlg.m_expIncreaseSpeed;
			this.m_partnerLivenessRow = null;
			XPartnerDocument.PartnerLivenessData.GetPartnerLivenessRowsByLevel(this.m_doc.CurPartnerLevel, out this.m_partnerLivenessRow);
			for (int i = 0; i < this.m_partnerLivenessRow.Count; i++)
			{
				GameObject chest = base.uiBehaviour.m_ChestPool.FetchGameObject(false);
				XChest chest2 = new XChest(chest, this.m_partnerLivenessRow[i].boxPic);
				base.uiBehaviour.m_Progress.AddChest(chest2);
			}
			this.ChangeChestProgressState(true);
		}

		// Token: 0x0600FE19 RID: 65049 RVA: 0x003BAD38 File Offset: 0x003B8F38
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClosed));
			this.m_partnerLivenessRow = null;
			XPartnerDocument.PartnerLivenessData.GetPartnerLivenessRowsByLevel(this.m_doc.CurPartnerLevel, out this.m_partnerLivenessRow);
			for (int i = 0; i < this.m_partnerLivenessRow.Count; i++)
			{
				base.uiBehaviour.m_Progress.ChestList[i].m_Chest.ID = (ulong)((long)i);
				base.uiBehaviour.m_Progress.ChestList[i].m_Chest.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClicked));
			}
		}

		// Token: 0x0600FE1A RID: 65050 RVA: 0x003BADFC File Offset: 0x003B8FFC
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_GoddessTrial);
			return true;
		}

		// Token: 0x0600FE1B RID: 65051 RVA: 0x003BAE20 File Offset: 0x003B9020
		protected override void OnShow()
		{
			base.uiBehaviour.m_Name.SetText(XStringDefineProxy.GetString("PartnerLivenessName"));
			base.uiBehaviour.m_Tip.SetText(XStringDefineProxy.GetString("PartnerLivenessTip"));
			XPartnerDocument.PartnerLivenessData.ReqPartnerLivenessInfo();
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.SetRelatedDlg(this);
			}
		}

		// Token: 0x0600FE1C RID: 65052 RVA: 0x003BAE8C File Offset: 0x003B908C
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.SetRelatedDlg(null);
			}
		}

		// Token: 0x0600FE1D RID: 65053 RVA: 0x003BAEBB File Offset: 0x003B90BB
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FE1E RID: 65054 RVA: 0x003BAEC5 File Offset: 0x003B90C5
		protected override void OnUnload()
		{
			base.OnUnload();
			base.uiBehaviour.m_Progress.Unload();
		}

		// Token: 0x0600FE1F RID: 65055 RVA: 0x003BAEE0 File Offset: 0x003B90E0
		public override void OnUpdate()
		{
			base.OnUpdate();
			base.uiBehaviour.m_Progress.Update(Time.deltaTime);
		}

		// Token: 0x0600FE20 RID: 65056 RVA: 0x003BAF00 File Offset: 0x003B9100
		public void FillContent()
		{
			this.RefreshBox();
			List<LoopItemData> list = new List<LoopItemData>();
			string empty = string.Empty;
			for (int i = 0; i < XPartnerDocument.PartnerLivenessData.RecordList.Count; i++)
			{
				PartnerLivenessRecord partnerLivenessRecord = XPartnerDocument.PartnerLivenessData.RecordList[i];
				partnerLivenessRecord.LoopID = XSingleton<XCommon>.singleton.XHash(XPartnerDocument.PartnerLivenessData.RecordList[i].ToString() + i);
				list.Add(partnerLivenessRecord);
			}
			base.uiBehaviour.m_loopScrool.Init(list, new DelegateHandler(this.RefreshRecordItem), null, 0, true);
		}

		// Token: 0x0600FE21 RID: 65057 RVA: 0x003BAFAE File Offset: 0x003B91AE
		public void RefreshBox()
		{
			this.ChangeChestProgressState(false);
			this.SetCurrentExpAmi();
			this.ShowReward(XPartnerDocument.PartnerLivenessData.FindNeedShowReward());
		}

		// Token: 0x0600FE22 RID: 65058 RVA: 0x003BAFD4 File Offset: 0x003B91D4
		private void RefreshRecordItem(ILoopItemObject item, LoopItemData data)
		{
			PartnerLivenessRecord partnerLivenessRecord = data as PartnerLivenessRecord;
			bool flag = partnerLivenessRecord != null;
			if (flag)
			{
				GameObject obj = item.GetObj();
				bool flag2 = obj != null;
				if (flag2)
				{
					PartnerLivenessRecordItem component = obj.GetComponent<PartnerLivenessRecordItem>();
					bool flag3 = component != null;
					if (flag3)
					{
						component.Refresh(partnerLivenessRecord);
					}
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("GuildMiniReportItem info is null", null, null, null, null, null);
			}
		}

		// Token: 0x0600FE23 RID: 65059 RVA: 0x003BB040 File Offset: 0x003B9240
		public void SetCurrentExpAmi()
		{
			base.uiBehaviour.m_Progress.TargetExp = XPartnerDocument.PartnerLivenessData.CurExp;
			base.uiBehaviour.m_TotalExpTween.SetNumberWithTween((ulong)XPartnerDocument.PartnerLivenessData.CurExp, "", false, true);
		}

		// Token: 0x0600FE24 RID: 65060 RVA: 0x003BB08C File Offset: 0x003B928C
		public void ChangeChestProgressState(bool init = false)
		{
			for (int i = 0; i < this.m_partnerLivenessRow.Count; i++)
			{
				XChest xchest = base.uiBehaviour.m_Progress.ChestList[i];
				if (init)
				{
					xchest.SetExp(this.m_partnerLivenessRow[i].liveness);
				}
				xchest.Opened = XPartnerDocument.PartnerLivenessData.IsChestOpened(i + 1);
			}
			if (init)
			{
				base.uiBehaviour.m_Progress.SetExp(0U, XPartnerDocument.PartnerLivenessData.MaxExp);
			}
		}

		// Token: 0x0600FE25 RID: 65061 RVA: 0x003BB124 File Offset: 0x003B9324
		public void ResetBoxRedDot(int index)
		{
			bool flag = index < 0 || index >= base.uiBehaviour.m_Progress.ChestList.Count;
			if (!flag)
			{
				base.uiBehaviour.m_Progress.ChestList[index].Open();
			}
		}

		// Token: 0x0600FE26 RID: 65062 RVA: 0x003BB178 File Offset: 0x003B9378
		private void OnChestClicked(IXUISprite iSp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			if (!flag)
			{
				int index = (int)iSp.ID;
				this.ShowReward(index);
				bool flag2 = base.uiBehaviour.m_Progress.IsExpEnough(index);
				if (flag2)
				{
					PartnerLivenessTable.RowData rowData = this.m_partnerLivenessRow[index];
					bool flag3 = rowData != null;
					if (flag3)
					{
						XPartnerDocument.PartnerLivenessData.ReqTakePartnerChest(rowData.index);
					}
				}
			}
		}

		// Token: 0x0600FE27 RID: 65063 RVA: 0x003BB1E8 File Offset: 0x003B93E8
		public void ShowReward(int index)
		{
			this.m_CurSelectIndex = index;
			base.uiBehaviour.m_RewardItemPool.ReturnAll(false);
			PartnerLivenessTable.RowData rowData = this.m_partnerLivenessRow[this.m_CurSelectIndex];
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

		// Token: 0x0600FE28 RID: 65064 RVA: 0x003BB35C File Offset: 0x003B955C
		private void OnClosed(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0600FE29 RID: 65065 RVA: 0x003BB368 File Offset: 0x003B9568
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x04007035 RID: 28725
		private static readonly uint m_expIncreaseSpeed = 800U;

		// Token: 0x04007036 RID: 28726
		private XPartnerDocument m_doc = XPartnerDocument.Doc;

		// Token: 0x04007037 RID: 28727
		private List<PartnerLivenessTable.RowData> m_partnerLivenessRow;

		// Token: 0x04007038 RID: 28728
		private int m_CurSelectIndex = 0;

		// Token: 0x04007039 RID: 28729
		private float m_fCoolTime = 0.5f;

		// Token: 0x0400703A RID: 28730
		private float m_fLastClickBtnTime = 0f;
	}
}
