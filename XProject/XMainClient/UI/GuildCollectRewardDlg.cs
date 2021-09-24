using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildCollectRewardDlg : DlgBase<GuildCollectRewardDlg, GuildCollectRewardBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildCollect/GuildCollectReward";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
			this._tipsStr = XStringDefineProxy.GetString("GuildCollectRewardTimeTips");
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryGetRewardCount();
			this.Refresh();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

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

		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnFetchBtnClick(IXUIButton btn)
		{
			this._doc.QueryGetReward((uint)btn.ID);
			return true;
		}

		private bool OnHelpBtnClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildCollect);
			return true;
		}

		public void RefreshTime(int time)
		{
			base.uiBehaviour.m_LeftTime.SetText(string.Format(this._tipsStr, XSingleton<UiUtility>.singleton.TimeDuarationFormatString(time, 5)));
		}

		private XGuildCollectDocument _doc = null;

		private string _tipsStr;
	}
}
