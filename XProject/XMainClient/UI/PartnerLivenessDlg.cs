using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PartnerLivenessDlg : DlgBase<PartnerLivenessDlg, PartnerLivenessBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Partner/PartnerLiveness";
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

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_GoddessTrial);
			return true;
		}

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
			for (int i = 0; i < XPartnerDocument.PartnerLivenessData.RecordList.Count; i++)
			{
				PartnerLivenessRecord partnerLivenessRecord = XPartnerDocument.PartnerLivenessData.RecordList[i];
				partnerLivenessRecord.LoopID = XSingleton<XCommon>.singleton.XHash(XPartnerDocument.PartnerLivenessData.RecordList[i].ToString() + i);
				list.Add(partnerLivenessRecord);
			}
			base.uiBehaviour.m_loopScrool.Init(list, new DelegateHandler(this.RefreshRecordItem), null, 0, true);
		}

		public void RefreshBox()
		{
			this.ChangeChestProgressState(false);
			this.SetCurrentExpAmi();
			this.ShowReward(XPartnerDocument.PartnerLivenessData.FindNeedShowReward());
		}

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

		public void SetCurrentExpAmi()
		{
			base.uiBehaviour.m_Progress.TargetExp = XPartnerDocument.PartnerLivenessData.CurExp;
			base.uiBehaviour.m_TotalExpTween.SetNumberWithTween((ulong)XPartnerDocument.PartnerLivenessData.CurExp, "", false, true);
		}

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

		private void OnClosed(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

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

		private static readonly uint m_expIncreaseSpeed = 800U;

		private XPartnerDocument m_doc = XPartnerDocument.Doc;

		private List<PartnerLivenessTable.RowData> m_partnerLivenessRow;

		private int m_CurSelectIndex = 0;

		private float m_fCoolTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;
	}
}
