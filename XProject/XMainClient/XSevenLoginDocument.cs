using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200097B RID: 2427
	internal class XSevenLoginDocument : XDocComponent
	{
		// Token: 0x17002C8E RID: 11406
		// (get) Token: 0x0600921D RID: 37405 RVA: 0x00150988 File Offset: 0x0014EB88
		public override uint ID
		{
			get
			{
				return XSevenLoginDocument.uuID;
			}
		}

		// Token: 0x17002C8F RID: 11407
		// (get) Token: 0x0600921F RID: 37407 RVA: 0x001509A8 File Offset: 0x0014EBA8
		// (set) Token: 0x0600921E RID: 37406 RVA: 0x0015099F File Offset: 0x0014EB9F
		public SevenLoginDlg SevenLoginView { get; set; }

		// Token: 0x17002C90 RID: 11408
		// (get) Token: 0x06009220 RID: 37408 RVA: 0x001509B0 File Offset: 0x0014EBB0
		// (set) Token: 0x06009221 RID: 37409 RVA: 0x001509C8 File Offset: 0x0014EBC8
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

		// Token: 0x06009222 RID: 37410 RVA: 0x00150A0B File Offset: 0x0014EC0B
		public static void Execute(OnLoadedCallback callback = null)
		{
			XSevenLoginDocument.AsyncLoader.AddTask("Table/SevenImport", XSevenLoginDocument.m_sevenImportTable, false);
			XSevenLoginDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x17002C91 RID: 11409
		// (get) Token: 0x06009223 RID: 37411 RVA: 0x00150A30 File Offset: 0x0014EC30
		public bool bHasAvailableRedPoint
		{
			get
			{
				return this.m_bHasAvailableSevenRedPoint;
			}
		}

		// Token: 0x17002C92 RID: 11410
		// (get) Token: 0x06009224 RID: 37412 RVA: 0x00150A48 File Offset: 0x0014EC48
		public List<LoginReward> LoginRewards
		{
			get
			{
				return this.m_LoginRewards ?? new List<LoginReward>();
			}
		}

		// Token: 0x06009225 RID: 37413 RVA: 0x00150A6C File Offset: 0x0014EC6C
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

		// Token: 0x06009226 RID: 37414 RVA: 0x00150B58 File Offset: 0x0014ED58
		public override void Update(float fDeltaT)
		{
			bool flag = !this.bHasAvailableSevenIcon;
			if (!flag)
			{
				this.m_CurrentTime += (double)fDeltaT;
			}
		}

		// Token: 0x06009227 RID: 37415 RVA: 0x00150B84 File Offset: 0x0014ED84
		public int GetLastSecond()
		{
			return (this.m_CurrentLoginDay < this.m_NextImprotDay) ? ((this.m_NextImprotDay - this.m_CurrentLoginDay) * 86400 - (int)this.m_CurrentTime) : 0;
		}

		// Token: 0x06009228 RID: 37416 RVA: 0x00150BC4 File Offset: 0x0014EDC4
		public void GetLoginReward(int day)
		{
			RpcC2G_ReqGetLoginReward rpcC2G_ReqGetLoginReward = new RpcC2G_ReqGetLoginReward();
			rpcC2G_ReqGetLoginReward.oArg.day = day;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReqGetLoginReward);
		}

		// Token: 0x06009229 RID: 37417 RVA: 0x00150BF4 File Offset: 0x0014EDF4
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

		// Token: 0x17002C93 RID: 11411
		// (get) Token: 0x0600922A RID: 37418 RVA: 0x00150CD8 File Offset: 0x0014EED8
		public int LastDay
		{
			get
			{
				return this.m_NextImprotDay - this.m_CurrentLoginDay;
			}
		}

		// Token: 0x17002C94 RID: 11412
		// (get) Token: 0x0600922B RID: 37419 RVA: 0x00150CF8 File Offset: 0x0014EEF8
		public int NextImportDay
		{
			get
			{
				return this.m_NextImprotDay;
			}
		}

		// Token: 0x17002C95 RID: 11413
		// (get) Token: 0x0600922C RID: 37420 RVA: 0x00150D10 File Offset: 0x0014EF10
		public int NextImportItem
		{
			get
			{
				return this.m_NextImportItemID;
			}
		}

		// Token: 0x17002C96 RID: 11414
		// (get) Token: 0x0600922D RID: 37421 RVA: 0x00150D28 File Offset: 0x0014EF28
		public bool NextGetState
		{
			get
			{
				return this.m_NextGetState;
			}
		}

		// Token: 0x0600922E RID: 37422 RVA: 0x00150D40 File Offset: 0x0014EF40
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

		// Token: 0x0600922F RID: 37423 RVA: 0x00150E24 File Offset: 0x0014F024
		public string GetDialogSharedString()
		{
			SevenImportTable.RowData byID = XSevenLoginDocument.m_sevenImportTable.GetByID(this.m_NextImprotDay);
			return (byID == null) ? string.Empty : byID.DialogSharedTexture;
		}

		// Token: 0x06009230 RID: 37424 RVA: 0x00150E58 File Offset: 0x0014F058
		public string GetSharedString()
		{
			SevenImportTable.RowData byID = XSevenLoginDocument.m_sevenImportTable.GetByID(this.m_NextImprotDay);
			return (byID == null) ? string.Empty : byID.SharedTexture;
		}

		// Token: 0x06009231 RID: 37425 RVA: 0x00150E8C File Offset: 0x0014F08C
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

		// Token: 0x06009232 RID: 37426 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs args)
		{
		}

		// Token: 0x040030BE RID: 12478
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSevenLoginDocument");

		// Token: 0x040030BF RID: 12479
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040030C0 RID: 12480
		private static SevenImportTable m_sevenImportTable = new SevenImportTable();

		// Token: 0x040030C2 RID: 12482
		private List<LoginReward> m_LoginRewards;

		// Token: 0x040030C3 RID: 12483
		private bool m_bHasAvailableSevenIcon = false;

		// Token: 0x040030C4 RID: 12484
		private bool m_bHasAvailableSevenRedPoint = false;

		// Token: 0x040030C5 RID: 12485
		private int m_CurrentLoginDay = 1;

		// Token: 0x040030C6 RID: 12486
		private double m_CurrentTime = 0.0;

		// Token: 0x040030C7 RID: 12487
		private int m_NextImprotDay = 0;

		// Token: 0x040030C8 RID: 12488
		private int m_NextImportItemID = 0;

		// Token: 0x040030C9 RID: 12489
		private bool m_NextGetState = false;
	}
}
