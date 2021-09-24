using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class LoversLivenessDlg : DlgBase<LoversLivenessDlg, LoversLivenessBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/Wedding/WeddingLoverLiveness";
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

		protected override void OnShow()
		{
			base.uiBehaviour.m_Name.SetText(XStringDefineProxy.GetString("WeddingLoverLivenessName"));
			base.uiBehaviour.m_Tip.SetText(XStringDefineProxy.GetString("WeddingLoverLivenessTip"));
			XWeddingDocument.Doc.ReqPartnerLivenessInfo();
		}

		protected override void OnHide()
		{
			base.OnHide();
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
			for (int i = 0; i < XWeddingDocument.Doc.RecordList.Count; i++)
			{
				LoverLivenessRecord loverLivenessRecord = XWeddingDocument.Doc.RecordList[i];
				loverLivenessRecord.LoopID = XSingleton<XCommon>.singleton.XHash(XWeddingDocument.Doc.RecordList[i].ToString() + i);
				list.Add(loverLivenessRecord);
			}
			base.uiBehaviour.m_loopScrool.Init(list, new DelegateHandler(this.RefreshRecordItem), null, 0, true);
		}

		public void RefreshBox()
		{
			this.ChangeChestProgressState(false);
			this.SetCurrentExpAmi();
			this.ShowReward(XWeddingDocument.Doc.FindNeedShowReward());
		}

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

		public void SetCurrentExpAmi()
		{
			base.uiBehaviour.m_Progress.TargetExp = XWeddingDocument.Doc.CurrExp;
			base.uiBehaviour.m_TotalExpTween.SetNumberWithTween((ulong)XWeddingDocument.Doc.CurrExp, "", false, true);
		}

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

		private int m_CurSelectIndex = 0;

		private float m_fCoolTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;
	}
}
