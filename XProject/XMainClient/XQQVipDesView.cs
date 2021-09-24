using System;
using System.Collections.Generic;
using MiniJSON;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQQVipDesView : DlgBase<XQQVipDesView, XQQVipDesBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/PlatformAbility/QQVipDesDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID);
			base.uiBehaviour.m_Detail.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XGlobalConfig>.singleton.GetValue("QQVipDesc")));
			base.uiBehaviour.m_ItemPool.FakeReturnAll();
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("QQVipGift", true);
			this.SetVipGiftInfo(base.uiBehaviour.m_VipDesc, sequenceList);
			SeqList<int> sequenceList2 = XSingleton<XGlobalConfig>.singleton.GetSequenceList("QQSVipGift", true);
			this.SetVipGiftInfo(base.uiBehaviour.m_SVipDesc, sequenceList2);
			base.uiBehaviour.m_ItemPool.ActualReturnAll(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.m_VipBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnVipBtnClicked));
			base.uiBehaviour.m_SVipBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSVipBtnClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshBtnsState();
		}

		public void RefreshBtnsState()
		{
			bool flag = this._doc.QQVipInfo == null;
			if (!flag)
			{
				XSingleton<XDebug>.singleton.AddLog(string.Concat(new string[]
				{
					"[QQVipInfo] isVip:",
					this._doc.QQVipInfo.is_vip.ToString(),
					", isSVip:",
					this._doc.QQVipInfo.is_svip.ToString(),
					",is_bigger_one_month:",
					this._doc.QQVipInfo.is_bigger_one_month.ToString()
				}), null, null, null, null, null, XDebugColor.XDebug_None);
				XQQVipDesView.VipButtonType vipButtonType = XQQVipDesView.VipButtonType.None;
				XQQVipDesView.VipButtonType en = XQQVipDesView.VipButtonType.None;
				string text = "";
				string text2 = "";
				bool flag2 = !this._doc.QQVipInfo.is_vip;
				if (flag2)
				{
					vipButtonType = XQQVipDesView.VipButtonType.OpenVip;
					en = XQQVipDesView.VipButtonType.OpenSVip;
					text = XSingleton<XStringTable>.singleton.GetString("QQVIP_OPEN_VIP");
					text2 = XSingleton<XStringTable>.singleton.GetString("QQVIP_OPEN_SVIP");
				}
				else
				{
					bool flag3 = this._doc.QQVipInfo.is_vip && !this._doc.QQVipInfo.is_svip;
					if (flag3)
					{
						bool is_bigger_one_month = this._doc.QQVipInfo.is_bigger_one_month;
						if (is_bigger_one_month)
						{
							vipButtonType = XQQVipDesView.VipButtonType.RenewVip;
							en = XQQVipDesView.VipButtonType.UpgradeSVip;
							text = XSingleton<XStringTable>.singleton.GetString("QQVIP_RENEW_VIP");
							text2 = XSingleton<XStringTable>.singleton.GetString("QQVIP_UPGRADE_SVIP");
						}
						else
						{
							vipButtonType = XQQVipDesView.VipButtonType.RenewVip;
							en = XQQVipDesView.VipButtonType.OpenSVip;
							text = XSingleton<XStringTable>.singleton.GetString("QQVIP_RENEW_VIP");
							text2 = XSingleton<XStringTable>.singleton.GetString("QQVIP_OPEN_SVIP");
						}
					}
					else
					{
						bool flag4 = this._doc.QQVipInfo.is_vip && this._doc.QQVipInfo.is_svip;
						if (flag4)
						{
							vipButtonType = XQQVipDesView.VipButtonType.RenewVip;
							en = XQQVipDesView.VipButtonType.RenewSVip;
							text = XSingleton<XStringTable>.singleton.GetString("QQVIP_RENEW_VIP");
							text2 = XSingleton<XStringTable>.singleton.GetString("QQVIP_RENEW_SVIP");
						}
					}
				}
				bool flag5 = vipButtonType > XQQVipDesView.VipButtonType.None;
				if (flag5)
				{
					base.uiBehaviour.m_VipBtn.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQQVipDesView.VipButtonType>.ToInt(vipButtonType));
					base.uiBehaviour.m_SVipBtn.ID = (ulong)((long)XFastEnumIntEqualityComparer<XQQVipDesView.VipButtonType>.ToInt(en));
					base.uiBehaviour.m_VipBtnText.SetText(text);
					base.uiBehaviour.m_SVipBtnText.SetText(text2);
				}
				else
				{
					base.uiBehaviour.m_VipBtn.SetEnable(false, false);
					base.uiBehaviour.m_SVipBtn.SetEnable(false, false);
				}
			}
		}

		private void SetVipGiftInfo(Transform vip, SeqList<int> giftList)
		{
			IXUIList ixuilist = vip.Find("ItemList").GetComponent("XUIList") as IXUIList;
			for (int i = 0; i < (int)giftList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
				gameObject.transform.parent = ixuilist.gameObject.transform;
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, giftList[i, 0], giftList[i, 1], false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)giftList[i, 0]);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			ixuilist.Refresh();
		}

		private bool OnVipBtnClicked(IXUIButton btn)
		{
			bool flag = this._doc.QQVipInfo == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XQQVipDesView.VipButtonType vipButtonType = (XQQVipDesView.VipButtonType)btn.ID;
				string serviceCode = "";
				int serviceType = 1;
				bool flag2 = !this._doc.QQVipInfo.is_vip;
				if (flag2)
				{
					bool flag3 = vipButtonType == XQQVipDesView.VipButtonType.OpenVip;
					if (flag3)
					{
						serviceCode = "LTMCLUB";
					}
					serviceType = 1;
				}
				else
				{
					bool flag4 = this._doc.QQVipInfo.is_vip && !this._doc.QQVipInfo.is_svip;
					if (flag4)
					{
						bool is_bigger_one_month = this._doc.QQVipInfo.is_bigger_one_month;
						if (is_bigger_one_month)
						{
							bool flag5 = vipButtonType == XQQVipDesView.VipButtonType.RenewVip;
							if (flag5)
							{
								serviceCode = "LTMCLUB";
								serviceType = 1;
							}
						}
						else
						{
							bool flag6 = vipButtonType == XQQVipDesView.VipButtonType.RenewVip;
							if (flag6)
							{
								serviceCode = "LTMCLUB";
								serviceType = 1;
							}
						}
					}
					else
					{
						bool flag7 = this._doc.QQVipInfo.is_vip && this._doc.QQVipInfo.is_svip;
						if (flag7)
						{
							bool flag8 = vipButtonType == XQQVipDesView.VipButtonType.RenewVip;
							if (flag8)
							{
								serviceCode = "LTMCLUB";
								serviceType = 1;
							}
						}
					}
				}
				this.QQVipPurchase(serviceCode, serviceType);
				result = true;
			}
			return result;
		}

		private bool OnSVipBtnClicked(IXUIButton btn)
		{
			bool flag = this._doc.QQVipInfo == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XQQVipDesView.VipButtonType vipButtonType = (XQQVipDesView.VipButtonType)btn.ID;
				string serviceCode = "";
				int serviceType = 1;
				bool flag2 = !this._doc.QQVipInfo.is_vip;
				if (flag2)
				{
					bool flag3 = vipButtonType == XQQVipDesView.VipButtonType.OpenSVip;
					if (flag3)
					{
						serviceCode = "CJCLUBT";
					}
					serviceType = 1;
				}
				else
				{
					bool flag4 = this._doc.QQVipInfo.is_vip && !this._doc.QQVipInfo.is_svip;
					if (flag4)
					{
						bool is_bigger_one_month = this._doc.QQVipInfo.is_bigger_one_month;
						if (is_bigger_one_month)
						{
							bool flag5 = vipButtonType == XQQVipDesView.VipButtonType.UpgradeSVip;
							if (flag5)
							{
								serviceCode = "CJCLUBT";
								serviceType = 3;
							}
						}
						else
						{
							bool flag6 = vipButtonType == XQQVipDesView.VipButtonType.OpenSVip;
							if (flag6)
							{
								serviceCode = "CJCLUBT";
								serviceType = 1;
							}
						}
					}
					else
					{
						bool flag7 = this._doc.QQVipInfo.is_vip && this._doc.QQVipInfo.is_svip;
						if (flag7)
						{
							bool flag8 = vipButtonType == XQQVipDesView.VipButtonType.RenewSVip;
							if (flag8)
							{
								serviceCode = "CJCLUBT";
								serviceType = 1;
							}
						}
					}
				}
				this.QQVipPurchase(serviceCode, serviceType);
				result = true;
			}
			return result;
		}

		private void QQVipPurchase(string ServiceCode, int ServiceType)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["serviceCode"] = ServiceCode;
			dictionary["serviceName"] = XSingleton<XStringTable>.singleton.GetString("QQVIP_OPEN_RENEW_TITLE");
			dictionary["serviceType"] = ServiceType;
			dictionary["remark"] = string.Format("aid={0}", XSingleton<XGlobalConfig>.singleton.GetValue("AID"));
			dictionary["zoneId"] = string.Format("{0}_{1}", XSingleton<XClientNetwork>.singleton.ServerID, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
			string text = Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("[QQVipInfo] jsonData:" + text, null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("pay_for_qq_club", text);
		}

		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private XPlatformAbilityDocument _doc = null;

		public enum VipButtonType
		{

			None,

			OpenVip,

			OpenSVip,

			RenewVip,

			RenewSVip,

			UpgradeSVip
		}
	}
}
