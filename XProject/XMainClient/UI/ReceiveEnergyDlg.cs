using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001711 RID: 5905
	internal class ReceiveEnergyDlg : DlgHandlerBase
	{
		// Token: 0x17003797 RID: 14231
		// (get) Token: 0x0600F3BE RID: 62398 RVA: 0x003673FC File Offset: 0x003655FC
		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/ReceiveEnergy";
			}
		}

		// Token: 0x0600F3BF RID: 62399 RVA: 0x00367414 File Offset: 0x00365614
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

		// Token: 0x0600F3C0 RID: 62400 RVA: 0x00367544 File Offset: 0x00365744
		public override void RegisterEvent()
		{
			this.m_btnDo.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonDo));
			this.m_BtnSubscribe.ID = 0UL;
			this.m_BtnSubscribe.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubscribeClick));
			this.m_BtnCancelSubscribe.ID = 1UL;
			this.m_BtnCancelSubscribe.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubscribeClick));
		}

		// Token: 0x0600F3C1 RID: 62401 RVA: 0x003675B8 File Offset: 0x003657B8
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

		// Token: 0x0600F3C2 RID: 62402 RVA: 0x00367778 File Offset: 0x00365978
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

		// Token: 0x0600F3C3 RID: 62403 RVA: 0x00367938 File Offset: 0x00365B38
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

		// Token: 0x0600F3C4 RID: 62404 RVA: 0x00367A8C File Offset: 0x00365C8C
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

		// Token: 0x0600F3C5 RID: 62405 RVA: 0x00367AC4 File Offset: 0x00365CC4
		private bool GetFatigueSure(IXUIButton btn)
		{
			this.mDoc.ReqFetchReward(this.m_rewardUid);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F3C6 RID: 62406 RVA: 0x00367AF6 File Offset: 0x00365CF6
		public override void OnUnload()
		{
			this.mSupperRewardInfo = null;
			this.mDinnerRewardInfo = null;
			this.mDoc = null;
			base.OnUnload();
		}

		// Token: 0x0600F3C7 RID: 62407 RVA: 0x00367B15 File Offset: 0x00365D15
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this.RefreshSubscribe();
		}

		// Token: 0x0600F3C8 RID: 62408 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnHide()
		{
		}

		// Token: 0x0600F3C9 RID: 62409 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		protected void OnHideTweenFinished(IXUITweenTool tween)
		{
			base.SetVisible(false);
		}

		// Token: 0x0600F3CA RID: 62410 RVA: 0x00367B30 File Offset: 0x00365D30
		private bool OnSubscribeClick(IXUIButton button)
		{
			this.SubscribebuttonID = button.ID;
			PushSubscribeTable.RowData pushSubscribe = XPushSubscribeDocument.GetPushSubscribe(PushSubscribeOptions.ReceiveEnergy);
			XSingleton<UiUtility>.singleton.ShowModalDialog((button.ID == 0UL) ? pushSubscribe.SubscribeDescription : pushSubscribe.CancelDescription, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.ReqSubscribeChange));
			return true;
		}

		// Token: 0x0600F3CB RID: 62411 RVA: 0x00367B98 File Offset: 0x00365D98
		private bool ReqSubscribeChange(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XPushSubscribeDocument specificDocument = XDocuments.GetSpecificDocument<XPushSubscribeDocument>(XPushSubscribeDocument.uuID);
			specificDocument.ReqSetSubscribe(PushSubscribeOptions.ReceiveEnergy, this.SubscribebuttonID == 0UL);
			return true;
		}

		// Token: 0x0600F3CC RID: 62412 RVA: 0x00367BD4 File Offset: 0x00365DD4
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

		// Token: 0x040068A8 RID: 26792
		private SystemRewardTable.RowData mSupperRewardInfo;

		// Token: 0x040068A9 RID: 26793
		private SystemRewardTable.RowData mDinnerRewardInfo;

		// Token: 0x040068AA RID: 26794
		private XSystemRewardData mSupperRewardData;

		// Token: 0x040068AB RID: 26795
		private XSystemRewardData mDinnerRewardData;

		// Token: 0x040068AC RID: 26796
		private XSystemRewardDocument mDoc;

		// Token: 0x040068AD RID: 26797
		public IXUIButton m_btnDo;

		// Token: 0x040068AE RID: 26798
		public ReceiveEnergyPanelModelView supperPanel = new ReceiveEnergyPanelModelView();

		// Token: 0x040068AF RID: 26799
		public ReceiveEnergyPanelModelView dinnerPanel = new ReceiveEnergyPanelModelView();

		// Token: 0x040068B0 RID: 26800
		private SeqList<int> dinnerData;

		// Token: 0x040068B1 RID: 26801
		private SeqList<int> supperData;

		// Token: 0x040068B2 RID: 26802
		public IXUIButton m_BtnSubscribe;

		// Token: 0x040068B3 RID: 26803
		public IXUIButton m_BtnCancelSubscribe;

		// Token: 0x040068B4 RID: 26804
		private ulong m_rewardUid = 0UL;

		// Token: 0x040068B5 RID: 26805
		private float m_fCoolTime = 0.5f;

		// Token: 0x040068B6 RID: 26806
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x040068B7 RID: 26807
		private ulong SubscribebuttonID = 0UL;
	}
}
