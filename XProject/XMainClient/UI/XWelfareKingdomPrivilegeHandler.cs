using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWelfareKingdomPrivilegeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/KingdomPrivilege";
			}
		}

		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.Find("ListType/Grid/Tpl");
			this.m_PrivilegeTypePool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 3U, false);
			this.m_PrivilegeTypeList = (base.PanelObject.transform.Find("ListType/Grid").GetComponent("XUIList") as IXUIList);
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
			XSingleton<UiUtility>.singleton.DestroyTextureInActivePool(this.m_PrivilegeTypePool, "Icon");
		}

		public override void RefreshData()
		{
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			PayMemberTable payMemberTable = XWelfareDocument.PayMemberTable;
			List<PayMember> payMemeberInfo = specificDocument.PayMemeberInfo;
			this.m_LeftTimeLabel.Clear();
			this.m_LeftTime.Clear();
			bool flag = payMemeberInfo == null;
			if (!flag)
			{
				this.m_PrivilegeTypePool.FakeReturnAll();
				for (int i = 0; i < payMemberTable.Table.Length; i++)
				{
					int systemID = payMemberTable.Table[i].SystemID;
					int id = payMemberTable.Table[i].ID;
					bool flag2 = XSingleton<XGameSysMgr>.singleton.IsSystemOpen(systemID);
					if (flag2)
					{
						GameObject gameObject = this.m_PrivilegeTypePool.FetchGameObject(false);
						gameObject.transform.parent = this.m_PrivilegeTypeList.gameObject.transform;
						gameObject.transform.localScale = Vector3.one;
						bool flag3 = false;
						for (int j = 0; j < payMemeberInfo.Count; j++)
						{
							bool flag4 = id == payMemeberInfo[j].ID;
							if (flag4)
							{
								flag3 = true;
								this.SetBaseInfo(gameObject, payMemberTable.Table[i], payMemeberInfo[j]);
							}
						}
						bool flag5 = !flag3;
						if (flag5)
						{
							this.SetBaseInfo(gameObject, payMemberTable.Table[i], null);
						}
					}
				}
				this.m_PrivilegeTypeList.Refresh();
				this.m_PrivilegeTypePool.ActualReturnAll(false);
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
				this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
			}
		}

		private void SetBaseInfo(GameObject item, PayMemberTable.RowData baseInfo, PayMember info)
		{
			float num = (float)baseInfo.Price / 100f;
			IXUILabel ixuilabel = item.transform.Find("Title").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(baseInfo.Name);
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			IXUISprite ixuisprite = item.transform.Find("TqIcon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetSprite(specificDocument.GetMemberPrivilegeIcon((MemberPrivilege)baseInfo.ID));
			IXUITexture ixuitexture = item.transform.Find("Icon").GetComponent("XUITexture") as IXUITexture;
			ixuitexture.SetTexturePath(baseInfo.Icon);
			IXUILabel ixuilabel2 = item.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(XStringDefineProxy.GetString("PAY_KINGDOM_VALUE", new object[]
			{
				baseInfo.Value[1],
				XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf((int)baseInfo.Value[0]).ItemName, 0U)
			}));
			IXUILabel ixuilabel3 = item.transform.Find("Detail/DetailDesc").GetComponent("XUILabel") as IXUILabel;
			string[] array = baseInfo.Desc.Split(new char[]
			{
				'|'
			});
			int num2 = 3;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = i < num2;
				if (flag)
				{
					stringBuilder.Append(array[i]);
				}
				else
				{
					bool flag2 = i == num2;
					if (flag2)
					{
						stringBuilder.Append("......");
						break;
					}
				}
				bool flag3 = i != array.Length - 1 && i != num2;
				if (flag3)
				{
					stringBuilder.Append("\n");
				}
			}
			ixuilabel3.SetText(stringBuilder.ToString());
			IXUIButton ixuibutton = item.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton;
			IXUILabel ixuilabel4 = item.transform.Find("LeftTime").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel5 = item.transform.Find("Btn/T").GetComponent("XUILabel") as IXUILabel;
			this.m_LeftTimeLabel.Add(ixuilabel4);
			bool flag4 = info != null;
			if (flag4)
			{
				this.m_LeftTime.Add(info.ExpireTime);
				this.SetLeftTime(ixuilabel4, info.ExpireTime);
				ixuilabel5.SetText((info.ExpireTime > 0) ? XSingleton<XStringTable>.singleton.GetString("PAY_KINGDOM_BUY_AGAIN") : baseInfo.Tip);
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("WelfareMemberPrivilegeRenewDays");
				bool visible = info.ExpireTime <= 86400 * @int;
				ixuibutton.SetVisible(visible);
			}
			else
			{
				ixuilabel4.SetVisible(false);
				ixuilabel5.SetText(baseInfo.Tip);
				this.m_LeftTime.Add(0);
				ixuibutton.SetVisible(true);
			}
			ixuibutton.ID = (ulong)((long)baseInfo.ID);
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBuyBtnClicked));
			IXUISprite ixuisprite2 = item.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.ID = (ulong)((long)baseInfo.ID);
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnDetailBtnClicked));
		}

		private void SetLeftTime(IXUILabel leftTime, int time)
		{
			leftTime.SetVisible(time > 0);
			bool flag = time > 86400;
			if (flag)
			{
				int num = time / 86400;
				leftTime.SetText(string.Format("{0}{1}", XStringDefineProxy.GetString("PAY_KINGDOM_LEFTTIME", new object[]
				{
					num
				}), XSingleton<XStringTable>.singleton.GetString("DAY_DUARATION")));
			}
			else
			{
				leftTime.SetText(XStringDefineProxy.GetString("PAY_KINGDOM_LEFTTIME", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeFormatString(time, 3, 3, 4, false, true)
				}));
			}
		}

		private void LeftTimeUpdate(object o)
		{
			for (int i = 0; i < this.m_LeftTime.Count; i++)
			{
				bool flag = this.m_LeftTime[i] > 0;
				if (flag)
				{
					List<int> leftTime = this.m_LeftTime;
					int index = i;
					int num = leftTime[index];
					leftTime[index] = num - 1;
					int @int = XSingleton<XGlobalConfig>.singleton.GetInt("WelfareMemberPrivilegeRenewDays");
					bool flag2 = this.m_LeftTime[i] == 0 || this.m_LeftTime[i] == 86400 * @int;
					if (flag2)
					{
						XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						specificDocument.ReqPayAllInfo();
					}
				}
				bool flag3 = i < this.m_LeftTimeLabel.Count;
				if (flag3)
				{
					this.SetLeftTime(this.m_LeftTimeLabel[i], this.m_LeftTime[i]);
				}
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDToken);
			this._CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdate), null);
		}

		private bool OnBuyBtnClicked(IXUIButton btn)
		{
			int num = (int)btn.ID;
			XWelfareDocument specificDocument = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			PayMemberTable payMemberTable = XWelfareDocument.PayMemberTable;
			List<PayMember> payMemeberInfo = specificDocument.PayMemeberInfo;
			bool flag = payMemeberInfo == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < payMemberTable.Table.Length; i++)
				{
					int id = payMemberTable.Table[i].ID;
					bool flag2 = id == num;
					if (flag2)
					{
						for (int j = 0; j < payMemeberInfo.Count; j++)
						{
							bool flag3 = id == payMemeberInfo[j].ID;
							if (flag3)
							{
								bool flag4 = payMemeberInfo[j].ExpireTime > 0;
								if (flag4)
								{
									DlgBase<XWelfareKingdomPrivilegeRenewView, XWelfareKingdomPrivilegeRenewBehaviour>.singleton.Show(payMemberTable.Table[i], false, 0);
									return true;
								}
							}
						}
						XRechargeDocument specificDocument2 = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
						bool flag5 = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.Android;
						if (flag5)
						{
							specificDocument2.SDKSubscribe(payMemberTable.Table[i].Price, 1, payMemberTable.Table[i].ServiceCode, payMemberTable.Table[i].Name, payMemberTable.Table[i].ParamID, PayParamType.PAY_PARAM_MEMBER);
						}
						else
						{
							bool flag6 = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.Platfrom() == XPlatformType.IOS;
							if (flag6)
							{
								specificDocument2.SDKSubscribe(payMemberTable.Table[i].Price, payMemberTable.Table[i].Days, payMemberTable.Table[i].ServiceCode, payMemberTable.Table[i].Name, payMemberTable.Table[i].ParamID, PayParamType.PAY_PARAM_MEMBER);
							}
						}
						return true;
					}
				}
				result = true;
			}
			return result;
		}

		private void OnDetailBtnClicked(IXUISprite sp)
		{
			int num = (int)sp.ID;
			PayMemberTable payMemberTable = XWelfareDocument.PayMemberTable;
			for (int i = 0; i < payMemberTable.Table.Length; i++)
			{
				int id = payMemberTable.Table[i].ID;
				bool flag = id == num;
				if (flag)
				{
					DlgBase<XWelfareKingdomPrivilegeDetailView, XWelfareKingdomPrivilegeDetailBehaviour>.singleton.ShowDetail(payMemberTable.Table[i], true);
					break;
				}
			}
		}

		private XUIPool m_PrivilegeTypePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIList m_PrivilegeTypeList;

		private List<IXUILabel> m_LeftTimeLabel = new List<IXUILabel>();

		private List<int> m_LeftTime = new List<int>();

		private uint _CDToken = 0U;
	}
}
