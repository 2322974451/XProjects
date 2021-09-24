using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWelfareKingdomPrivilegeRenewView : DlgBase<XWelfareKingdomPrivilegeRenewView, XWelfareKingdomPrivilegeRenewBehaviour>
	{

		public override bool autoload
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
				return "GameSystem/Welfare/KingdomPrivilegeRenew";
			}
		}

		public void Show(PayMemberTable.RowData info, bool suc = false, int leftTime = 0)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			this.payInfo = info;
			base.uiBehaviour.m_Title.SetText(suc ? XSingleton<XStringTable>.singleton.GetString("PAY_KINGDOM_RENEW_TITLE") : XSingleton<XStringTable>.singleton.GetString("PAY_KINGDOM_BUY_AGAIN"));
			base.uiBehaviour.m_Name.SetText(info.Name);
			base.uiBehaviour.m_Icon.SetTexturePath(info.Icon);
			base.uiBehaviour.m_Time.SetVisible(!suc);
			base.uiBehaviour.m_Time.SetText(string.Format("{0}{1}", info.Days, XSingleton<XStringTable>.singleton.GetString("DAY_DUARATION")));
			float num = (float)info.Price / 100f;
			base.uiBehaviour.m_Price.SetText(XStringDefineProxy.GetString("PAY_UNIT", new object[]
			{
				num
			}));
			base.uiBehaviour.m_Price.SetVisible(!suc);
			base.uiBehaviour.m_RenewSucTip.SetVisible(suc);
			base.uiBehaviour.m_Buy.SetVisible(!suc);
			if (suc)
			{
				int days = info.Days;
				int num2 = leftTime / 86400;
				base.uiBehaviour.m_RenewSucTip.SetText(XStringDefineProxy.GetString("PAY_KINGDOM_RENEW", new object[]
				{
					days,
					num2
				}));
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
			base.uiBehaviour.m_Buy.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClicked));
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.uiBehaviour.m_Icon.SetTexturePath("");
		}

		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		private bool OnBuyBtnClicked(IXUIButton btn)
		{
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			bool flag = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.Android;
			if (flag)
			{
				specificDocument.SDKSubscribe(this.payInfo.Price, 1, this.payInfo.ServiceCode, this.payInfo.Name, this.payInfo.ParamID, PayParamType.PAY_PARAM_MEMBER);
			}
			else
			{
				bool flag2 = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.IOS;
				if (flag2)
				{
					specificDocument.SDKSubscribe(this.payInfo.Price, this.payInfo.Days, this.payInfo.ServiceCode, this.payInfo.Name, this.payInfo.ParamID, PayParamType.PAY_PARAM_MEMBER);
				}
			}
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private PayMemberTable.RowData payInfo;
	}
}
