using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSevenLoginDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSevenLoginDocument.uuID;
			}
		}

		public SevenLoginDlg SevenLoginView { get; set; }

		public bool bHasAvailableSevenIcon
		{
			get
			{
				return this.m_bHasAvailableSevenIcon;
			}
			set
			{
				bool flag = this.m_bHasAvailableSevenIcon != value;
				if (flag)
				{
					this.m_bHasAvailableSevenIcon = value;
					bool flag2 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
					if (flag2)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnSingleSysChange(XSysDefine.XSys_SevenActivity, true);
					}
				}
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XSevenLoginDocument.AsyncLoader.AddTask("Table/SevenImport", XSevenLoginDocument.m_sevenImportTable, false);
			XSevenLoginDocument.AsyncLoader.Execute(callback);
		}

		public bool bHasAvailableRedPoint
		{
			get
			{
				return this.m_bHasAvailableSevenRedPoint;
			}
		}

		public List<LoginReward> LoginRewards
		{
			get
			{
				return this.m_LoginRewards ?? new List<LoginReward>();
			}
		}

		public uint GetRedayFatigue(int day)
		{
			uint num = 0U;
			bool flag = this.m_LoginRewards != null;
			if (flag)
			{
				int i = 0;
				int count = this.LoginRewards.Count;
				while (i < count)
				{
					bool flag2 = this.LoginRewards[i].day == day;
					if (flag2)
					{
						int j = 0;
						int count2 = this.LoginRewards[i].items.Count;
						while (j < count2)
						{
							bool flag3 = (ulong)this.LoginRewards[i].items[j].itemID == (ulong)((long)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FATIGUE));
							if (flag3)
							{
								num += this.LoginRewards[i].items[j].itemCount;
							}
							j++;
						}
					}
					i++;
				}
			}
			return num;
		}

		public override void Update(float fDeltaT)
		{
			bool flag = !this.bHasAvailableSevenIcon;
			if (!flag)
			{
				this.m_CurrentTime += (double)fDeltaT;
			}
		}

		public int GetLastSecond()
		{
			return (this.m_CurrentLoginDay < this.m_NextImprotDay) ? ((this.m_NextImprotDay - this.m_CurrentLoginDay) * 86400 - (int)this.m_CurrentTime) : 0;
		}

		public void GetLoginReward(int day)
		{
			RpcC2G_ReqGetLoginReward rpcC2G_ReqGetLoginReward = new RpcC2G_ReqGetLoginReward();
			rpcC2G_ReqGetLoginReward.oArg.day = day;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReqGetLoginReward);
		}

		public void ReceiveLoginReward(LoginRewardGetReq oArg, LoginRewardGetRet oRes)
		{
			bool flag = oRes.ret > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ret, "fece00");
			}
			else
			{
				bool flag2 = this.m_LoginRewards == null;
				if (!flag2)
				{
					bool flag3 = false;
					int i = 0;
					int count = this.m_LoginRewards.Count;
					while (i < count)
					{
						bool flag4 = this.m_LoginRewards[i].day == this.m_NextImprotDay;
						if (flag4)
						{
							flag3 = (this.m_LoginRewards[i].state == LoginRewardState.LOGINRS_CANNOT);
							break;
						}
						i++;
					}
					bool flag5 = this.LastDay == 1 && oArg.day == this.m_CurrentLoginDay && flag3;
					if (flag5)
					{
						bool flag6 = DlgBase<SevenLoginDlg, SevenLoginBehaviour>.singleton.IsVisible();
						if (flag6)
						{
							DlgBase<SevenLoginDlg, SevenLoginBehaviour>.singleton.ShowDialogSheredTexture();
						}
					}
				}
			}
		}

		public int LastDay
		{
			get
			{
				return this.m_NextImprotDay - this.m_CurrentLoginDay;
			}
		}

		public int NextImportDay
		{
			get
			{
				return this.m_NextImprotDay;
			}
		}

		public int NextImportItem
		{
			get
			{
				return this.m_NextImportItemID;
			}
		}

		public bool NextGetState
		{
			get
			{
				return this.m_NextGetState;
			}
		}

		public bool TryGetHallMessage(out string message, out string spriteName)
		{
			message = string.Empty;
			spriteName = string.Empty;
			bool flag = this.m_NextImprotDay == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				SevenImportTable.RowData byID = XSevenLoginDocument.m_sevenImportTable.GetByID(this.m_NextImprotDay);
				bool flag2 = byID == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf(this.NextImportItem);
					bool flag3 = itemConf != null;
					if (flag3)
					{
						bool nextGetState = this.m_NextGetState;
						if (nextGetState)
						{
							message = XStringDefineProxy.GetString("SEVEN_LOGIN_MAIN_MESSAGE2", new object[]
							{
								(itemConf == null) ? "??" : itemConf.ItemName[0]
							});
						}
						else
						{
							message = XStringDefineProxy.GetString("SEVEN_LOGIN_MAIN_MESSAGE1", new object[]
							{
								this.LastDay,
								(itemConf == null) ? "??" : itemConf.ItemName[0]
							});
						}
					}
					spriteName = byID.SharedIcon;
					result = true;
				}
			}
			return result;
		}

		public string GetDialogSharedString()
		{
			SevenImportTable.RowData byID = XSevenLoginDocument.m_sevenImportTable.GetByID(this.m_NextImprotDay);
			return (byID == null) ? string.Empty : byID.DialogSharedTexture;
		}

		public string GetSharedString()
		{
			SevenImportTable.RowData byID = XSevenLoginDocument.m_sevenImportTable.GetByID(this.m_NextImprotDay);
			return (byID == null) ? string.Empty : byID.SharedTexture;
		}

		public void OnSevenLoginReward(LoginRewardRet oRes)
		{
			this.bHasAvailableSevenIcon = oRes.open;
			bool flag = !this.bHasAvailableSevenIcon;
			if (!flag)
			{
				this.m_CurrentLoginDay = (int)oRes.logindayforreward;
				this.m_LoginRewards = oRes.rewards;
				this.m_CurrentTime = oRes.sectoday;
				this.m_bHasAvailableSevenRedPoint = false;
				SevenImportTable.RowData[] table = XSevenLoginDocument.m_sevenImportTable.Table;
				this.m_NextImprotDay = 0;
				this.m_NextImportItemID = 0;
				this.m_NextGetState = false;
				for (int i = this.m_LoginRewards.Count - 1; i >= 0; i--)
				{
					bool flag2 = this.m_LoginRewards[i].state == LoginRewardState.LOGINRS_HAVEHOT;
					if (flag2)
					{
						this.m_bHasAvailableSevenRedPoint = true;
					}
					for (int j = table.Length - 1; j >= 0; j--)
					{
						SevenImportTable.RowData rowData = table[j];
						bool flag3 = rowData.ID == this.m_LoginRewards[i].day;
						if (flag3)
						{
							bool flag4 = this.m_LoginRewards[i].state == LoginRewardState.LOGINRS_HAVEHOT || this.m_LoginRewards[i].state == LoginRewardState.LOGINRS_CANNOT;
							if (flag4)
							{
								this.m_NextImprotDay = this.m_LoginRewards[i].day;
								this.m_NextImportItemID = rowData.ItemID;
								this.m_NextGetState = (this.m_LoginRewards[i].state == LoginRewardState.LOGINRS_HAVEHOT);
								break;
							}
						}
					}
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_SevenActivity, true);
				bool flag5 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
				if (flag5)
				{
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.InitSevenLoginWhenShow();
				}
				bool flag6 = this.SevenLoginView != null && this.SevenLoginView.IsVisible();
				if (flag6)
				{
					this.SevenLoginView.Refresh();
				}
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs args)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSevenLoginDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static SevenImportTable m_sevenImportTable = new SevenImportTable();

		private List<LoginReward> m_LoginRewards;

		private bool m_bHasAvailableSevenIcon = false;

		private bool m_bHasAvailableSevenRedPoint = false;

		private int m_CurrentLoginDay = 1;

		private double m_CurrentTime = 0.0;

		private int m_NextImprotDay = 0;

		private int m_NextImportItemID = 0;

		private bool m_NextGetState = false;
	}
}
