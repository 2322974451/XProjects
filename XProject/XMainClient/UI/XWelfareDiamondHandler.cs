using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018EE RID: 6382
	internal class XWelfareDiamondHandler : DlgHandlerBase
	{
		// Token: 0x17003A85 RID: 14981
		// (get) Token: 0x06010A11 RID: 68113 RVA: 0x0041CC8C File Offset: 0x0041AE8C
		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/DiamondFrame";
			}
		}

		// Token: 0x06010A12 RID: 68114 RVA: 0x0041CCA4 File Offset: 0x0041AEA4
		protected override void Init()
		{
			base.Init();
			this.m_RemainTimeName = (base.PanelObject.transform.Find("LeftTimeName").GetComponent("XUILabel") as IXUILabel);
			this.m_RemainTimeName.SetText(XSingleton<XStringTable>.singleton.GetString("PAY_CARD_LEFT_TIME_TITLE"));
			this.m_RemainTime = (base.PanelObject.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_Tip = (base.PanelObject.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_Tip.SetText(XSingleton<XStringTable>.singleton.GetString("PAY_CARD_TIP"));
			this.m_WeeklyCard = base.PanelObject.transform.Find("WeeklyCard/Tpl").gameObject;
			this.m_MonthlyCard = base.PanelObject.transform.Find("MonthlyCard/Tpl").gameObject;
			this.cardType.Clear();
			this.cardType.Add(1U);
			this.cardType.Add(2U);
		}

		// Token: 0x06010A13 RID: 68115 RVA: 0x0041CDD4 File Offset: 0x0041AFD4
		protected override void OnHide()
		{
			base.OnHide();
			IXUITexture ixuitexture = this.m_WeeklyCard.transform.Find("Icon").GetComponent("XUITexture") as IXUITexture;
			bool flag = ixuitexture != null;
			if (flag)
			{
				ixuitexture.SetTexturePath("");
			}
			ixuitexture = (this.m_MonthlyCard.transform.Find("Icon").GetComponent("XUITexture") as IXUITexture);
			bool flag2 = ixuitexture != null;
			if (flag2)
			{
				ixuitexture.SetTexturePath("");
			}
		}

		// Token: 0x06010A14 RID: 68116 RVA: 0x0041CE60 File Offset: 0x0041B060
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			IXUIButton ixuibutton = this.m_WeeklyCard.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.ID = 1UL;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClicked));
			IXUIButton ixuibutton2 = this.m_MonthlyCard.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.ID = 2UL;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClicked));
		}

		// Token: 0x06010A15 RID: 68117 RVA: 0x0041CEF8 File Offset: 0x0041B0F8
		private bool OnBuyBtnClicked(IXUIButton btn)
		{
			uint num = (uint)btn.ID;
			int num2 = this.cardState[num];
			bool flag = num2 == -1;
			if (flag)
			{
				PayCardTable.RowData payCardConfig = XWelfareDocument.GetPayCardConfig(num);
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				bool flag2 = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.Android;
				if (flag2)
				{
					specificDocument.SDKSubscribe(payCardConfig.Price, 1, payCardConfig.ServiceCode, payCardConfig.Name, payCardConfig.ParamID, PayParamType.PAY_PARAM_CARD);
				}
				else
				{
					bool flag3 = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.IOS;
					if (flag3)
					{
						int buyNum = (num == 1U) ? 7 : 30;
						specificDocument.SDKSubscribe(payCardConfig.Price, buyNum, payCardConfig.ServiceCode, payCardConfig.Name, payCardConfig.ParamID, PayParamType.PAY_PARAM_CARD);
					}
				}
			}
			else
			{
				XWelfareDocument specificDocument2 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
				specificDocument2.GetCardDailyDiamond(num);
			}
			return true;
		}

		// Token: 0x06010A16 RID: 68118 RVA: 0x0041CFE4 File Offset: 0x0041B1E4
		public override void RefreshData()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.payInfo = specificDocument.PayCardInfo;
			uint payCardRemainTime = specificDocument.PayCardRemainTime;
			this.cardState.Clear();
			bool flag = this.payInfo == null;
			if (!flag)
			{
				this.RefreshRemainTime(this.payInfo, payCardRemainTime);
				for (int i = 0; i < this.cardType.Count; i++)
				{
					bool flag2 = false;
					int num = 0;
					for (int j = 0; j < this.payInfo.Count; j++)
					{
						bool flag3 = (this.cardType[i] == this.payInfo[j].type && this.payInfo[j].remainedCount > 0U) || (this.cardType[i] == this.payInfo[j].type && this.payInfo[j].isGet);
						if (flag3)
						{
							flag2 = true;
							num = j;
							break;
						}
					}
					bool flag4 = this.cardType[i] == 1U;
					if (flag4)
					{
						this.RefreshCard(this.m_WeeklyCard, this.cardType[i], flag2 ? num : -1);
					}
					else
					{
						bool flag5 = this.cardType[i] == 2U;
						if (flag5)
						{
							this.RefreshCard(this.m_MonthlyCard, this.cardType[i], flag2 ? num : -1);
						}
					}
				}
			}
		}

		// Token: 0x06010A17 RID: 68119 RVA: 0x0041D180 File Offset: 0x0041B380
		private void RefreshRemainTime(List<PayCard> payInfo, uint remainTime)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 0; i < payInfo.Count; i++)
			{
				bool flag4 = !payInfo[i].isGet && payInfo[i].remainedCount > 0U;
				if (flag4)
				{
					flag2 = true;
				}
				bool flag5 = payInfo[i].isGet && payInfo[i].remainedCount > 0U;
				if (flag5)
				{
					flag3 = true;
				}
			}
			bool flag6 = !flag2 && flag3;
			if (flag6)
			{
				flag = true;
			}
			this.m_RemainTime.gameObject.SetActive(flag);
			this.m_RemainTimeName.gameObject.SetActive(flag);
			bool flag7 = flag;
			if (flag7)
			{
				this.currLeftTime = (int)remainTime;
				this.m_RemainTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)remainTime, 3, 3, 4, false, true));
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
				this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
			}
		}

		// Token: 0x06010A18 RID: 68120 RVA: 0x0041D294 File Offset: 0x0041B494
		private void LeftTimeUpdate(object o)
		{
			this.currLeftTime--;
			bool flag = this.currLeftTime < 0;
			if (flag)
			{
				this.m_RemainTime.gameObject.SetActive(false);
				this.m_RemainTimeName.gameObject.SetActive(false);
			}
			else
			{
				this.m_RemainTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(this.currLeftTime, 3, 3, 4, false, true));
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
				this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
			}
		}

		// Token: 0x06010A19 RID: 68121 RVA: 0x0041D338 File Offset: 0x0041B538
		private void RefreshCard(GameObject card, uint cardType, int index)
		{
			bool flag = this.payInfo == null;
			if (!flag)
			{
				PayCard payCard = (index == -1) ? null : this.payInfo[index];
				this.cardState.Add(cardType, index);
				IXUILabel ixuilabel = card.transform.Find("Title").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = card.transform.Find("tip1").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = card.transform.Find("tip2").GetComponent("XUILabel") as IXUILabel;
				IXUIButton ixuibutton = card.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton;
				IXUILabel ixuilabel4 = card.transform.Find("Btn/T").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = card.transform.Find("HasGot").GetComponent("XUISprite") as IXUISprite;
				IXUITexture ixuitexture = card.transform.Find("Icon").GetComponent("XUITexture") as IXUITexture;
				ixuitexture.SetTexturePath(XWelfareDocument.GetPayCardConfig(cardType).Icon);
				IXUISprite ixuisprite2 = card.transform.Find("Btn/redpoint").GetComponent("XUISprite") as IXUISprite;
				bool flag2 = payCard != null;
				if (flag2)
				{
					ixuilabel2.gameObject.SetActive(false);
					ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_CARD_LEFT_TIMES"), payCard.remainedCount));
					int dayAward = XWelfareDocument.GetPayCardConfig(payCard.type).DayAward;
					ixuilabel3.SetText(payCard.isGet ? string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_CARD_HAS_GOT"), dayAward) : string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_CARD_CAN_GET"), dayAward));
					ixuilabel4.SetText(XSingleton<XStringTable>.singleton.GetString("PAY_GOT_TEX"));
					ixuibutton.SetVisible(!payCard.isGet);
					ixuisprite2.gameObject.SetActive(!payCard.isGet);
					ixuisprite.gameObject.SetActive(payCard.isGet);
				}
				else
				{
					ixuilabel2.gameObject.SetActive(true);
					ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_CARD_TITLE"), XWelfareDocument.GetPayCardConfig(cardType).Name));
					ixuilabel2.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_CARD_TIP_1"), XWelfareDocument.GetPayCardConfig(cardType).Diamond));
					int num = (cardType == 1U) ? 7 : 30;
					ixuilabel3.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_CARD_TIP_2"), num, XWelfareDocument.GetPayCardConfig(cardType).DayAward));
					float num2 = (float)XWelfareDocument.GetPayCardConfig(cardType).Price / 100f;
					ixuilabel4.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PAY_BUY_TEX"), num2));
					ixuibutton.SetVisible(true);
					ixuisprite2.gameObject.SetActive(false);
					ixuisprite.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x040078F9 RID: 30969
		private IXUILabel m_Tip;

		// Token: 0x040078FA RID: 30970
		private GameObject m_WeeklyCard;

		// Token: 0x040078FB RID: 30971
		private GameObject m_MonthlyCard;

		// Token: 0x040078FC RID: 30972
		private IXUILabel m_RemainTime;

		// Token: 0x040078FD RID: 30973
		private IXUILabel m_RemainTimeName;

		// Token: 0x040078FE RID: 30974
		private int currLeftTime;

		// Token: 0x040078FF RID: 30975
		private uint _CDToken;

		// Token: 0x04007900 RID: 30976
		private const uint WEEKLY_CARD_TYPE = 1U;

		// Token: 0x04007901 RID: 30977
		private const uint MONTHLY_CARD_TYPE = 2U;

		// Token: 0x04007902 RID: 30978
		private List<uint> cardType = new List<uint>();

		// Token: 0x04007903 RID: 30979
		private List<PayCard> payInfo;

		// Token: 0x04007904 RID: 30980
		private Dictionary<uint, int> cardState = new Dictionary<uint, int>();
	}
}
