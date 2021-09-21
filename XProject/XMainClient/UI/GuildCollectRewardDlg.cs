using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200175B RID: 5979
	internal class GuildCollectRewardDlg : DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>
	{
		// Token: 0x17003802 RID: 14338
		// (get) Token: 0x0600F6F6 RID: 63222 RVA: 0x003822D4 File Offset: 0x003804D4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003803 RID: 14339
		// (get) Token: 0x0600F6F7 RID: 63223 RVA: 0x003822E8 File Offset: 0x003804E8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003804 RID: 14340
		// (get) Token: 0x0600F6F8 RID: 63224 RVA: 0x003822FC File Offset: 0x003804FC
		public override string fileName
		{
			get
			{
				return "Guild/GuildCollect/GuildCollectReward";
			}
		}

		// Token: 0x0600F6F9 RID: 63225 RVA: 0x00382313 File Offset: 0x00380513
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
			this._tipsStr = XStringDefineProxy.GetString("GuildCollectRewardTimeTips");
		}

		// Token: 0x0600F6FA RID: 63226 RVA: 0x00382340 File Offset: 0x00380540
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClick));
		}

		// Token: 0x0600F6FB RID: 63227 RVA: 0x0038238F File Offset: 0x0038058F
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryGetRewardCount();
			this.Refresh();
		}

		// Token: 0x0600F6FC RID: 63228 RVA: 0x003823AC File Offset: 0x003805AC
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F6FD RID: 63229 RVA: 0x003823B6 File Offset: 0x003805B6
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600F6FE RID: 63230 RVA: 0x003823C0 File Offset: 0x003805C0
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
		}

		// Token: 0x0600F6FF RID: 63231 RVA: 0x003823CA File Offset: 0x003805CA
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F700 RID: 63232 RVA: 0x003823D4 File Offset: 0x003805D4
		public void Refresh()
		{
			base.uiBehaviour.m_CollectPool.ReturnAll(false);
			base.uiBehaviour.m_ItemPool.ReturnAll(true);
			Vector3 tplPos = base.uiBehaviour.m_CollectPool.TplPos;
			for (int i = 0; i < this._doc.RewardReader.Table.Length; i++)
			{
				GuildCampPartyReward.RowData rowData = this._doc.RewardReader.Table[i];
				GameObject gameObject = base.uiBehaviour.m_CollectPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * base.uiBehaviour.m_CollectPool.TplHeight));
				Transform parent = gameObject.transform.Find("CollectList");
				Transform parent2 = gameObject.transform.Find("RewardList");
				IXUIButton ixuibutton = gameObject.transform.Find("BtnFetch").GetComponent("XUIButton") as IXUIButton;
				GameObject gameObject2 = gameObject.transform.Find("Get").gameObject;
				bool grey = true;
				for (int j = 0; j < rowData.Items.Count; j++)
				{
					GameObject gameObject3 = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
					gameObject3.transform.parent = parent;
					gameObject3.transform.localPosition = new Vector3((float)(j * base.uiBehaviour.m_ItemPool.TplWidth), 0f);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject3, (int)rowData.Items[j, 0], (int)rowData.Items[j, 1], true);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject3, (int)rowData.Items[j, 0]);
					IXUILabel ixuilabel = gameObject3.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					int num = (int)XBagDocument.BagDoc.GetItemCount((int)rowData.Items[j, 0]);
					ixuilabel.SetText(string.Format("{0}{1}/{2}", (num >= (int)rowData.Items[j, 1]) ? "[ffffff]" : "[fd4343]", num, (int)rowData.Items[j, 1]));
					bool flag = num < (int)rowData.Items[j, 1];
					if (flag)
					{
						grey = false;
					}
				}
				for (int k = 0; k < rowData.Reward.Count; k++)
				{
					GameObject gameObject4 = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
					gameObject4.transform.parent = parent2;
					gameObject4.transform.localPosition = new Vector3((float)(k * base.uiBehaviour.m_ItemPool.TplWidth), 0f);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject4, (int)rowData.Reward[k, 0], (int)rowData.Reward[k, 1], false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject4, (int)rowData.Reward[k, 0]);
				}
				int num2 = 0;
				this._doc.CollectUseDict.TryGetValue(rowData.ID, out num2);
				bool flag2 = num2 > 0;
				if (flag2)
				{
					gameObject2.SetActive(true);
					ixuibutton.SetVisible(false);
				}
				else
				{
					gameObject2.SetActive(false);
					ixuibutton.SetVisible(true);
					ixuibutton.SetGrey(grey);
					ixuibutton.ID = (ulong)rowData.ID;
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFetchBtnClick));
				}
			}
		}

		// Token: 0x0600F701 RID: 63233 RVA: 0x003827A0 File Offset: 0x003809A0
		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F702 RID: 63234 RVA: 0x003827BC File Offset: 0x003809BC
		private bool OnFetchBtnClick(IXUIButton btn)
		{
			this._doc.QueryGetReward((uint)btn.ID);
			return true;
		}

		// Token: 0x0600F703 RID: 63235 RVA: 0x003827E4 File Offset: 0x003809E4
		private bool OnHelpBtnClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildCollect);
			return true;
		}

		// Token: 0x0600F704 RID: 63236 RVA: 0x00382807 File Offset: 0x00380A07
		public void RefreshTime(int time)
		{
			base.uiBehaviour.m_LeftTime.SetText(string.Format(this._tipsStr, XSingleton<UiUtility>.singleton.TimeDuarationFormatString(time, 5)));
		}

		// Token: 0x04006B68 RID: 27496
		private XGuildCollectDocument _doc = null;

		// Token: 0x04006B69 RID: 27497
		private string _tipsStr;
	}
}
