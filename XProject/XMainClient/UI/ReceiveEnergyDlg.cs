using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ReceiveEnergyDlg : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/ReceiveEnergy";
			}
		}

		protected override void Init()
		{
			this.mDoc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XSystemRewardDocument.uuID) as XSystemRewardDocument);
			this.mSupperRewardInfo = this.mDoc.GetTableDataByType(SystemRewardTypeMrg.GetTypeUInt(SystemRewardType.RewardSupper));
			this.mDinnerRewardInfo = this.mDoc.GetTableDataByType(SystemRewardTypeMrg.GetTypeUInt(SystemRewardType.RewardDinner));
			this.m_btnDo = (base.transform.Find("Bg/GetReward").GetComponent("XUIButton") as IXUIButton);
			this.dinnerPanel.FindFrom(base.transform.Find("Bg/L"));
			this.supperPanel.FindFrom(base.transform.Find("Bg/R"));
			this.dinnerData = XSingleton<XGlobalConfig>.singleton.GetSequenceList("DinnerReward", false);
			this.supperData = XSingleton<XGlobalConfig>.singleton.GetSequenceList("SupperReward", false);
			this.m_BtnSubscribe = (base.transform.FindChild("Bg/Subscribe").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnCancelSubscribe = (base.transform.FindChild("Bg/UnSubscribe").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			this.m_btnDo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonDo));
			this.m_BtnSubscribe.ID = 0UL;
			this.m_BtnSubscribe.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubscribeClick));
			this.m_BtnCancelSubscribe.ID = 1UL;
			this.m_BtnCancelSubscribe.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubscribeClick));
		}

		public override void RefreshData()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.mSupperRewardData = null;
				this.mDinnerRewardData = null;
				List<XSystemRewardData> dataList = this.mDoc.DataList;
				for (int i = 0; i < dataList.Count; i++)
				{
					bool flag2 = dataList[i].type == SystemRewardTypeMrg.GetTypeUInt(SystemRewardType.RewardSupper);
					if (flag2)
					{
						this.mSupperRewardData = dataList[i];
					}
					else
					{
						bool flag3 = dataList[i].type == SystemRewardTypeMrg.GetTypeUInt(SystemRewardType.RewardDinner);
						if (flag3)
						{
							this.mDinnerRewardData = dataList[i];
						}
					}
					bool flag4 = this.mSupperRewardData != null && this.mDinnerRewardData != null;
					if (flag4)
					{
						break;
					}
				}
				bool flag5 = this.mSupperRewardData != null;
				if (flag5)
				{
					this.supperPanel.m_sprFinish.SetVisible(this.mSupperRewardData.state == XSystemRewardState.SRS_FETCHED);
					this.SetItemStatue(this.supperData, this.supperPanel);
				}
				else
				{
					this.supperPanel.m_sprFinish.SetVisible(false);
				}
				bool flag6 = this.mDinnerRewardData != null;
				if (flag6)
				{
					this.dinnerPanel.m_sprFinish.SetVisible(this.mDinnerRewardData.state == XSystemRewardState.SRS_FETCHED);
					this.SetItemStatue(this.dinnerData, this.dinnerPanel);
				}
				else
				{
					this.dinnerPanel.m_sprFinish.SetVisible(false);
				}
				this.m_btnDo.SetVisible((this.mSupperRewardData == null && this.mDinnerRewardData == null) || (this.mSupperRewardData != null && this.mSupperRewardData.state == XSystemRewardState.SRS_CAN_FETCH) || (this.mDinnerRewardData != null && this.mDinnerRewardData.state == XSystemRewardState.SRS_CAN_FETCH));
			}
		}

		private void SetItemStatue(SeqList<int> lst, ReceiveEnergyPanelModelView go)
		{
			bool flag = lst.Count > 1;
			if (flag)
			{
				int itemID = lst[0, 0];
				int num = lst[0, 1];
				ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
				bool flag2 = itemConf.ItemIcon1 != null && itemConf.ItemIcon1.Length != 0;
				if (flag2)
				{
					go.m_EnerySpr.SetSprite(itemConf.ItemIcon1[0]);
					go.m_lbNum.SetText(num.ToString());
				}
				else
				{
					this.dinnerPanel.m_lbNum.SetText("");
				}
				itemID = lst[1, 0];
				num = lst[1, 1];
				itemConf = XBagDocument.GetItemConf(itemID);
				bool flag3 = itemConf.ItemIcon1 != null && itemConf.ItemIcon1.Length != 0;
				if (flag3)
				{
					go.m_ItemGo.SetActive(true);
					go.m_ItemIcon.SetSprite(itemConf.ItemIcon1[0]);
					go.m_ItemNumLab.SetText(num.ToString());
				}
				else
				{
					go.m_ItemGo.SetActive(false);
				}
			}
			else
			{
				bool flag4 = lst.Count == 1;
				if (flag4)
				{
					int itemID2 = lst[0, 0];
					int num2 = lst[0, 1];
					ItemList.RowData itemConf2 = XBagDocument.GetItemConf(itemID2);
					bool flag5 = itemConf2.ItemIcon1 != null && itemConf2.ItemIcon1.Length != 0;
					if (flag5)
					{
						go.m_EnerySpr.SetSprite(itemConf2.ItemIcon1[0]);
						go.m_lbNum.SetText(num2.ToString());
					}
					else
					{
						this.dinnerPanel.m_lbNum.SetText("");
					}
					go.m_ItemGo.SetActive(false);
				}
				else
				{
					go.m_lbNum.SetVisible(false);
				}
			}
		}

		private bool OnClickButtonDo(IXUIButton go)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				int num = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE);
				bool flag2 = this.mSupperRewardData != null && this.mSupperRewardData.state == XSystemRewardState.SRS_CAN_FETCH;
				if (flag2)
				{
					this.m_rewardUid = this.mSupperRewardData.uid;
					bool flag3 = num + this.supperData[0, 1] > int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MaxFatigue"));
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowFatigueSureDlg(new ButtonClickEventHandler(this.GetFatigueSure));
						return true;
					}
					this.mDoc.ReqFetchReward(this.m_rewardUid);
				}
				else
				{
					bool flag4 = this.mDinnerRewardData != null && this.mDinnerRewardData.state == XSystemRewardState.SRS_CAN_FETCH;
					if (flag4)
					{
						this.m_rewardUid = this.mDinnerRewardData.uid;
						bool flag5 = num + this.dinnerData[0, 1] > int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MaxFatigue"));
						if (flag5)
						{
							XSingleton<UiUtility>.singleton.ShowFatigueSureDlg(new ButtonClickEventHandler(this.GetFatigueSure));
							return true;
						}
						this.mDoc.ReqFetchReward(this.m_rewardUid);
					}
				}
				result = true;
			}
			return result;
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

		private bool GetFatigueSure(IXUIButton btn)
		{
			this.mDoc.ReqFetchReward(this.m_rewardUid);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		public override void OnUnload()
		{
			this.mSupperRewardInfo = null;
			this.mDinnerRewardInfo = null;
			this.mDoc = null;
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this.RefreshSubscribe();
		}

		protected override void OnHide()
		{
		}

		protected void OnHideTweenFinished(IXUITweenTool tween)
		{
			base.SetVisible(false);
		}

		private bool OnSubscribeClick(IXUIButton button)
		{
			this.SubscribebuttonID = button.ID;
			PushSubscribeTable.RowData pushSubscribe = XPushSubscribeDocument.GetPushSubscribe(PushSubscribeOptions.ReceiveEnergy);
			XSingleton<UiUtility>.singleton.ShowModalDialog((button.ID == 0UL) ? pushSubscribe.SubscribeDescription : pushSubscribe.CancelDescription, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ReqSubscribeChange));
			return true;
		}

		private bool ReqSubscribeChange(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XPushSubscribeDocument specificDocument = XDocuments.GetSpecificDocument<XPushSubscribeDocument>(XPushSubscribeDocument.uuID);
			specificDocument.ReqSetSubscribe(PushSubscribeOptions.ReceiveEnergy, this.SubscribebuttonID == 0UL);
			return true;
		}

		public void RefreshSubscribe()
		{
			PushSubscribeTable.RowData pushSubscribe = XPushSubscribeDocument.GetPushSubscribe(PushSubscribeOptions.ReceiveEnergy);
			XPushSubscribeDocument specificDocument = XDocuments.GetSpecificDocument<XPushSubscribeDocument>(XPushSubscribeDocument.uuID);
			bool flag = XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LGOIN_WECHAT_PF && pushSubscribe.IsShow && specificDocument.OptionsDefault != null && specificDocument.OptionsDefault.Count != 0;
			if (flag)
			{
				bool curSubscribeStatus = specificDocument.GetCurSubscribeStatus(PushSubscribeOptions.ReceiveEnergy);
				this.m_BtnSubscribe.gameObject.SetActive(!curSubscribeStatus);
				this.m_BtnCancelSubscribe.gameObject.SetActive(curSubscribeStatus);
			}
			else
			{
				this.m_BtnSubscribe.gameObject.SetActive(false);
				this.m_BtnCancelSubscribe.gameObject.SetActive(false);
			}
		}

		private SystemRewardTable.RowData mSupperRewardInfo;

		private SystemRewardTable.RowData mDinnerRewardInfo;

		private XSystemRewardData mSupperRewardData;

		private XSystemRewardData mDinnerRewardData;

		private XSystemRewardDocument mDoc;

		public IXUIButton m_btnDo;

		public ReceiveEnergyPanelModelView supperPanel = new ReceiveEnergyPanelModelView();

		public ReceiveEnergyPanelModelView dinnerPanel = new ReceiveEnergyPanelModelView();

		private SeqList<int> dinnerData;

		private SeqList<int> supperData;

		public IXUIButton m_BtnSubscribe;

		public IXUIButton m_BtnCancelSubscribe;

		private ulong m_rewardUid = 0UL;

		private float m_fCoolTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private ulong SubscribebuttonID = 0UL;
	}
}
