using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018D8 RID: 6360
	internal class LoversLivenessDlg : DlgBase<LoversLivenessDlg, LoversLivenessBehaviour>
	{
		// Token: 0x17003A68 RID: 14952
		// (get) Token: 0x0601092E RID: 67886 RVA: 0x004154C4 File Offset: 0x004136C4
		public override string fileName
		{
			get
			{
				return "GameSystem/Wedding/WeddingLoverLiveness";
			}
		}

		// Token: 0x17003A69 RID: 14953
		// (get) Token: 0x0601092F RID: 67887 RVA: 0x004154DC File Offset: 0x004136DC
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A6A RID: 14954
		// (get) Token: 0x06010930 RID: 67888 RVA: 0x004154F0 File Offset: 0x004136F0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A6B RID: 14955
		// (get) Token: 0x06010931 RID: 67889 RVA: 0x00415504 File Offset: 0x00413704
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06010932 RID: 67890 RVA: 0x00415518 File Offset: 0x00413718
		protected override void Init()
		{
			GameObject tpl = base.uiBehaviour.m_loopScrool.GetTpl();
			bool flag = tpl != null && tpl.GetComponent<LoverLivenessRecordItem>() == null;
			if (flag)
			{
				tpl.AddComponent<LoverLivenessRecordItem>();
			}
			base.uiBehaviour.m_Progress.IncreaseSpeed = LoversLivenessDlg.m_expIncreaseSpeed;
			for (int i = 0; i < XWeddingDocument.LoverLivenessTable.Table.Length; i++)
			{
				WeddingLoverLiveness.RowData rowData = XWeddingDocument.LoverLivenessTable.Table[i];
				GameObject chest = base.uiBehaviour.m_ChestPool.FetchGameObject(false);
				XChest chest2 = new XChest(chest, rowData.boxPic);
				base.uiBehaviour.m_Progress.AddChest(chest2);
			}
			this.ChangeChestProgressState(true);
		}

		// Token: 0x06010933 RID: 67891 RVA: 0x004155DC File Offset: 0x004137DC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClosed));
			for (int i = 0; i < XWeddingDocument.LoverLivenessTable.Table.Length; i++)
			{
				base.uiBehaviour.m_Progress.ChestList[i].m_Chest.ID = (ulong)((long)i);
				base.uiBehaviour.m_Progress.ChestList[i].m_Chest.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClicked));
			}
		}

		// Token: 0x06010934 RID: 67892 RVA: 0x0041567C File Offset: 0x0041387C
		protected override void OnShow()
		{
			base.uiBehaviour.m_Name.SetText(XStringDefineProxy.GetString("WeddingLoverLivenessName"));
			base.uiBehaviour.m_Tip.SetText(XStringDefineProxy.GetString("WeddingLoverLivenessTip"));
			XWeddingDocument.Doc.ReqPartnerLivenessInfo();
		}

		// Token: 0x06010935 RID: 67893 RVA: 0x004156CB File Offset: 0x004138CB
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06010936 RID: 67894 RVA: 0x004156D5 File Offset: 0x004138D5
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x06010937 RID: 67895 RVA: 0x004156DF File Offset: 0x004138DF
		protected override void OnUnload()
		{
			base.OnUnload();
			base.uiBehaviour.m_Progress.Unload();
		}

		// Token: 0x06010938 RID: 67896 RVA: 0x004156FA File Offset: 0x004138FA
		public override void OnUpdate()
		{
			base.OnUpdate();
			base.uiBehaviour.m_Progress.Update(Time.deltaTime);
		}

		// Token: 0x06010939 RID: 67897 RVA: 0x0041571C File Offset: 0x0041391C
		public void FillContent()
		{
			this.RefreshBox();
			List<LoopItemData> list = new List<LoopItemData>();
			string empty = string.Empty;
			for (int i = 0; i < XWeddingDocument.Doc.RecordList.Count; i++)
			{
				LoverLivenessRecord loverLivenessRecord = XWeddingDocument.Doc.RecordList[i];
				loverLivenessRecord.LoopID = XSingleton<XCommon>.singleton.XHash(XWeddingDocument.Doc.RecordList[i].ToString() + i);
				list.Add(loverLivenessRecord);
			}
			base.uiBehaviour.m_loopScrool.Init(list, new DelegateHandler(this.RefreshRecordItem), null, 0, true);
		}

		// Token: 0x0601093A RID: 67898 RVA: 0x004157CA File Offset: 0x004139CA
		public void RefreshBox()
		{
			this.ChangeChestProgressState(false);
			this.SetCurrentExpAmi();
			this.ShowReward(XWeddingDocument.Doc.FindNeedShowReward());
		}

		// Token: 0x0601093B RID: 67899 RVA: 0x004157F0 File Offset: 0x004139F0
		private void RefreshRecordItem(ILoopItemObject item, LoopItemData data)
		{
			LoverLivenessRecord loverLivenessRecord = data as LoverLivenessRecord;
			bool flag = loverLivenessRecord != null;
			if (flag)
			{
				GameObject obj = item.GetObj();
				bool flag2 = obj != null;
				if (flag2)
				{
					LoverLivenessRecordItem component = obj.GetComponent<LoverLivenessRecordItem>();
					bool flag3 = component != null;
					if (flag3)
					{
						component.Refresh(loverLivenessRecord);
					}
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("GuildMiniReportItem info is null", null, null, null, null, null);
			}
		}

		// Token: 0x0601093C RID: 67900 RVA: 0x0041585C File Offset: 0x00413A5C
		public void SetCurrentExpAmi()
		{
			base.uiBehaviour.m_Progress.TargetExp = XWeddingDocument.Doc.CurrExp;
			base.uiBehaviour.m_TotalExpTween.SetNumberWithTween((ulong)XWeddingDocument.Doc.CurrExp, "", false, true);
		}

		// Token: 0x0601093D RID: 67901 RVA: 0x004158A8 File Offset: 0x00413AA8
		public void ChangeChestProgressState(bool init = false)
		{
			for (int i = 0; i < XWeddingDocument.LoverLivenessTable.Table.Length; i++)
			{
				XChest xchest = base.uiBehaviour.m_Progress.ChestList[i];
				if (init)
				{
					xchest.SetExp(XWeddingDocument.LoverLivenessTable.Table[i].liveness);
				}
				xchest.Opened = XWeddingDocument.Doc.IsChestOpened(i + 1);
			}
			if (init)
			{
				base.uiBehaviour.m_Progress.SetExp(0U, XWeddingDocument.MaxExp);
			}
		}

		// Token: 0x0601093E RID: 67902 RVA: 0x0041593C File Offset: 0x00413B3C
		public void ResetBoxRedDot(int index)
		{
			bool flag = index < 0 || index >= base.uiBehaviour.m_Progress.ChestList.Count;
			if (!flag)
			{
				base.uiBehaviour.m_Progress.ChestList[index].Open();
			}
		}

		// Token: 0x0601093F RID: 67903 RVA: 0x00415990 File Offset: 0x00413B90
		private void OnChestClicked(IXUISprite iSp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			if (!flag)
			{
				int num = (int)iSp.ID;
				this.ShowReward(num);
				bool flag2 = base.uiBehaviour.m_Progress.IsExpEnough(num);
				if (flag2)
				{
					WeddingLoverLiveness.RowData rowData = XWeddingDocument.LoverLivenessTable.Table[num];
					bool flag3 = rowData != null;
					if (flag3)
					{
						XWeddingDocument.Doc.ReqTakePartnerChest(rowData.index);
					}
				}
			}
		}

		// Token: 0x06010940 RID: 67904 RVA: 0x00415A00 File Offset: 0x00413C00
		public void ShowReward(int index)
		{
			this.m_CurSelectIndex = index;
			base.uiBehaviour.m_RewardItemPool.ReturnAll(false);
			WeddingLoverLiveness.RowData rowData = XWeddingDocument.LoverLivenessTable.Table[index];
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

		// Token: 0x06010941 RID: 67905 RVA: 0x00415B6F File Offset: 0x00413D6F
		private void OnClosed(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x06010942 RID: 67906 RVA: 0x00415B7C File Offset: 0x00413D7C
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

		// Token: 0x0400784C RID: 30796
		private static readonly uint m_expIncreaseSpeed = 800U;

		// Token: 0x0400784D RID: 30797
		private int m_CurSelectIndex = 0;

		// Token: 0x0400784E RID: 30798
		private float m_fCoolTime = 0.5f;

		// Token: 0x0400784F RID: 30799
		private float m_fLastClickBtnTime = 0f;
	}
}
