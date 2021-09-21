using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008D4 RID: 2260
	internal class XCustomBattleDocument : XDocComponent
	{
		// Token: 0x17002AB8 RID: 10936
		// (get) Token: 0x060088C1 RID: 35009 RVA: 0x0011C5C4 File Offset: 0x0011A7C4
		public override uint ID
		{
			get
			{
				return XCustomBattleDocument.uuID;
			}
		}

		// Token: 0x17002AB9 RID: 10937
		// (get) Token: 0x060088C2 RID: 35010 RVA: 0x0011C5DC File Offset: 0x0011A7DC
		public List<XCustomBattleDocument.BountyModeData> BountyList
		{
			get
			{
				return this._bounty_list;
			}
		}

		// Token: 0x17002ABA RID: 10938
		// (get) Token: 0x060088C3 RID: 35011 RVA: 0x0011C5F4 File Offset: 0x0011A7F4
		public List<XCustomBattleDocument.CustomModeData> CustomList
		{
			get
			{
				return this._custom_list;
			}
		}

		// Token: 0x17002ABB RID: 10939
		// (get) Token: 0x060088C4 RID: 35012 RVA: 0x0011C60C File Offset: 0x0011A80C
		// (set) Token: 0x060088C5 RID: 35013 RVA: 0x0011C614 File Offset: 0x0011A814
		public XCustomBattleDocument.BountyModeData CurrentBountyData { get; set; }

		// Token: 0x17002ABC RID: 10940
		// (get) Token: 0x060088C6 RID: 35014 RVA: 0x0011C61D File Offset: 0x0011A81D
		// (set) Token: 0x060088C7 RID: 35015 RVA: 0x0011C625 File Offset: 0x0011A825
		public XCustomBattleDocument.CustomModeData CurrentCustomData { get; set; }

		// Token: 0x17002ABD RID: 10941
		// (get) Token: 0x060088C8 RID: 35016 RVA: 0x0011C62E File Offset: 0x0011A82E
		// (set) Token: 0x060088C9 RID: 35017 RVA: 0x0011C636 File Offset: 0x0011A836
		public XCustomBattleDocument.CustomModeData SelfCustomData { get; set; }

		// Token: 0x17002ABE RID: 10942
		// (get) Token: 0x060088CA RID: 35018 RVA: 0x0011C640 File Offset: 0x0011A840
		public ulong CurrentMatchingID
		{
			get
			{
				return this._currentMatchingID;
			}
		}

		// Token: 0x17002ABF RID: 10943
		// (get) Token: 0x060088CB RID: 35019 RVA: 0x0011C658 File Offset: 0x0011A858
		// (set) Token: 0x060088CC RID: 35020 RVA: 0x0011C660 File Offset: 0x0011A860
		public bool passwordForJoin { get; set; }

		// Token: 0x17002AC0 RID: 10944
		// (get) Token: 0x060088CD RID: 35021 RVA: 0x0011C669 File Offset: 0x0011A869
		// (set) Token: 0x060088CE RID: 35022 RVA: 0x0011C671 File Offset: 0x0011A871
		public ulong CacheGameID { get; set; }

		// Token: 0x17002AC1 RID: 10945
		// (get) Token: 0x060088CF RID: 35023 RVA: 0x0011C67C File Offset: 0x0011A87C
		public bool RedPoint
		{
			get
			{
				return this.BountyModeRedPoint || this.CustomModeRedPoint;
			}
		}

		// Token: 0x17002AC2 RID: 10946
		// (get) Token: 0x060088D0 RID: 35024 RVA: 0x0011C69F File Offset: 0x0011A89F
		// (set) Token: 0x060088D1 RID: 35025 RVA: 0x0011C6A7 File Offset: 0x0011A8A7
		public bool BountyModeRedPoint { get; set; }

		// Token: 0x17002AC3 RID: 10947
		// (get) Token: 0x060088D2 RID: 35026 RVA: 0x0011C6B0 File Offset: 0x0011A8B0
		// (set) Token: 0x060088D3 RID: 35027 RVA: 0x0011C6B8 File Offset: 0x0011A8B8
		public bool CustomModeRedPoint { get; set; }

		// Token: 0x060088D4 RID: 35028 RVA: 0x0011C6C4 File Offset: 0x0011A8C4
		public static void Execute(OnLoadedCallback callback = null)
		{
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomBattle", XCustomBattleDocument._customBattleTable, false);
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomReward", XCustomBattleDocument._customRewardTable, false);
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomBattleSystem", XCustomBattleDocument._customSystemTable, false);
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomSystemReward", XCustomBattleDocument._customSystemRewardTable, false);
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomBattleType", XCustomBattleDocument._customBattleType, false);
			XCustomBattleDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060088D5 RID: 35029 RVA: 0x0011C74C File Offset: 0x0011A94C
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SendCustomBattleQueryBountyMode();
				this.SendCustomBattleQueryCustomModeSelfInfo();
			}
		}

		// Token: 0x060088D6 RID: 35030 RVA: 0x0011C788 File Offset: 0x0011A988
		public void SendCustomBattleSearch(string str)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Search;
			rpcC2M_CustomBattleOp.oArg.name = str;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088D7 RID: 35031 RVA: 0x0011C7C4 File Offset: 0x0011A9C4
		public void SendCustomBattleQueryBountyMode()
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Query;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088D8 RID: 35032 RVA: 0x0011C7F4 File Offset: 0x0011A9F4
		public void SendCustomBattleQueryCustomModeList(bool queryCross = false)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_QueryRandom;
			rpcC2M_CustomBattleOp.oArg.querycross = queryCross;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088D9 RID: 35033 RVA: 0x0011C830 File Offset: 0x0011AA30
		public void SendCustomBattleSearchCustomModeList(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_QueryOne;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088DA RID: 35034 RVA: 0x0011C86C File Offset: 0x0011AA6C
		public void SendCustomBattleQueryCustomModeSelfInfo()
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_QuerySelf;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088DB RID: 35035 RVA: 0x0011C89C File Offset: 0x0011AA9C
		public void SendCustomBattleMatch(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Match;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088DC RID: 35036 RVA: 0x0011C8D8 File Offset: 0x0011AAD8
		public void SendCustomBattleUnMatch()
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_UnMatch;
			rpcC2M_CustomBattleOp.oArg.uid = this._currentMatchingID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088DD RID: 35037 RVA: 0x0011C918 File Offset: 0x0011AB18
		public void SendCustomBattleDrop(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Drop;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088DE RID: 35038 RVA: 0x0011C954 File Offset: 0x0011AB54
		public void SendCustomBattleJoin(ulong gameID, bool showPassword = false, string password = "")
		{
			bool flag = !showPassword;
			if (flag)
			{
				RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
				rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Join;
				rpcC2M_CustomBattleOp.oArg.uid = gameID;
				rpcC2M_CustomBattleOp.oArg.password = password;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
			}
			else
			{
				this.passwordForJoin = true;
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowPasswordSettingHandler();
			}
		}

		// Token: 0x060088DF RID: 35039 RVA: 0x0011C9BC File Offset: 0x0011ABBC
		public void SendCustomBattleExit(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_UnJoin;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088E0 RID: 35040 RVA: 0x0011C9F8 File Offset: 0x0011ABF8
		public void SendCustomBattleModifyPassword(ulong gameID, string password)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Modify;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			rpcC2M_CustomBattleOp.oArg.password = password;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088E1 RID: 35041 RVA: 0x0011CA40 File Offset: 0x0011AC40
		public void SendCustomBattleCreate()
		{
			CustomBattleTable.RowData customBattleData = this.GetCustomBattleData(this.CustomCreateData.configID);
			bool flag = customBattleData == null;
			if (!flag)
			{
				RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
				rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Create;
				rpcC2M_CustomBattleOp.oArg.config = new CustomBattleConfig();
				rpcC2M_CustomBattleOp.oArg.config.name = this.CustomCreateData.gameName;
				rpcC2M_CustomBattleOp.oArg.config.configid = this.CustomCreateData.configID;
				rpcC2M_CustomBattleOp.oArg.config.canjoincount = this.CustomCreateData.canJoinCount;
				rpcC2M_CustomBattleOp.oArg.config.battletime = customBattleData.timespan[(int)this.CustomCreateData.battleTimeIndex];
				rpcC2M_CustomBattleOp.oArg.config.haspassword = this.CustomCreateData.hasPassword;
				rpcC2M_CustomBattleOp.oArg.config.password = this.CustomCreateData.password;
				rpcC2M_CustomBattleOp.oArg.config.isfair = this.CustomCreateData.isFair;
				rpcC2M_CustomBattleOp.oArg.config.scalemask = this.CustomCreateData.scaleMask;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
			}
		}

		// Token: 0x060088E2 RID: 35042 RVA: 0x0011CB84 File Offset: 0x0011AD84
		public void SendCustomBattleStartNow(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_StartNow;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088E3 RID: 35043 RVA: 0x0011CBC0 File Offset: 0x0011ADC0
		public void SendCustomBattleClearCD(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_ClearCD;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088E4 RID: 35044 RVA: 0x0011CBFC File Offset: 0x0011ADFC
		public void SendCustomBattleGetReward(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Reward;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		// Token: 0x060088E5 RID: 35045 RVA: 0x0011CC38 File Offset: 0x0011AE38
		public CustomBattleSystemTable.RowData GetSystemBattleData(uint id)
		{
			return XCustomBattleDocument._customSystemTable.GetByid(id);
		}

		// Token: 0x060088E6 RID: 35046 RVA: 0x0011CC58 File Offset: 0x0011AE58
		public void DoErrorOp(CustomBattleOp op, ulong gameID)
		{
			if (op - CustomBattleOp.CustomBattle_Join <= 3)
			{
				this.RefreshCustomBattleInfo();
			}
		}

		// Token: 0x060088E7 RID: 35047 RVA: 0x0011CC7C File Offset: 0x0011AE7C
		public void RecvCustomBattleOp(CustomBattleOp op, ulong gameID, CustomBattleClientInfo data, CustomBattleOpArg oArg)
		{
			switch (op)
			{
			case CustomBattleOp.CustomBattle_Query:
				this.SetCustomBattleList(data);
				break;
			case CustomBattleOp.CustomBattle_Create:
				this.OnCreateGameSucc(gameID, data);
				break;
			case CustomBattleOp.CustomBattle_Join:
				this.ShowCustomBattleInfo(gameID, data);
				break;
			case CustomBattleOp.CustomBattle_Match:
			{
				bool flag = this.CurrentBountyData != null && this.CurrentBountyData.gameID == gameID;
				if (flag)
				{
					XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_CustomBattle_BountyMode, EXStage.Hall);
				}
				else
				{
					bool flag2 = this.CurrentCustomData != null && this.CurrentCustomData.gameID == gameID;
					if (flag2)
					{
						XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_CustomBattle_CustomMode, EXStage.Hall);
					}
				}
				this._currentMatchingID = gameID;
				this.CacheGameID = gameID;
				this.ShowMatchingHandler();
				break;
			}
			case CustomBattleOp.CustomBattle_Reward:
				this.OnFetchSystemBattleChest(gameID, data);
				break;
			case CustomBattleOp.CustomBattle_ClearCD:
				this.OnClearSystemBattleChestCD(gameID, data);
				break;
			case CustomBattleOp.CustomBattle_QueryRandom:
				this.SetCustomBattleCustomModeListRandom(data);
				break;
			case CustomBattleOp.CustomBattle_QueryOne:
				this.SetCustomBattleCustomModeListOne(data);
				break;
			case CustomBattleOp.CustomBattle_UnJoin:
				this.OnUnjoinBattleSucc();
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("UnJoinCustomBattle"), "fece00");
				break;
			case CustomBattleOp.CustomBattle_UnMatch:
				XSingleton<XUICacheMgr>.singleton.RemoveCachedUI(XSysDefine.XSys_CustomBattle_BountyMode);
				XSingleton<XUICacheMgr>.singleton.RemoveCachedUI(XSysDefine.XSys_CustomBattle_CustomMode);
				this._currentMatchingID = 0UL;
				this.CacheGameID = 0UL;
				break;
			case CustomBattleOp.CustomBattle_Modify:
				XSingleton<UiUtility>.singleton.ShowSystemTip((oArg.password != "") ? XSingleton<XStringTable>.singleton.GetString("SetPasswordSucc") : XSingleton<XStringTable>.singleton.GetString("CancelPassword"), "fece00");
				break;
			case CustomBattleOp.CustomBattle_QuerySelf:
				this.SetCustomBattleCustomModeSelfInfo(data);
				break;
			case CustomBattleOp.CustomBattle_StartNow:
				this.OnCustomBattleStartNow();
				break;
			case CustomBattleOp.CustomBattle_Drop:
				this.OnBountyModeDrop();
				break;
			case CustomBattleOp.CustomBattle_Search:
				this.SetCustomBattleCustomModeListSearch(data);
				break;
			}
		}

		// Token: 0x060088E8 RID: 35048 RVA: 0x0011CE7F File Offset: 0x0011B07F
		private void OnCustomBattleStartNow()
		{
			this.SendCustomBattleQueryCustomModeSelfInfo();
		}

		// Token: 0x060088E9 RID: 35049 RVA: 0x0011CE89 File Offset: 0x0011B089
		private void OnBountyModeDrop()
		{
			this.SendCustomBattleQueryBountyMode();
		}

		// Token: 0x060088EA RID: 35050 RVA: 0x0011CE94 File Offset: 0x0011B094
		private void RefreshHandler(DlgHandlerBase handler)
		{
			bool flag = handler != null && handler.IsVisible();
			if (flag)
			{
				handler.RefreshData();
			}
		}

		// Token: 0x060088EB RID: 35051 RVA: 0x0011CEBC File Offset: 0x0011B0BC
		private void RefreshAllView()
		{
			this.RefreshRedPoint();
			bool flag = !DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler);
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeListHandler);
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeBriefHandler);
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._ChestHandler);
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler);
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler);
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeListHandler);
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._MatchingHandler);
				this.RefreshHandler(DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._PasswordSettingHandler);
			}
		}

		// Token: 0x060088EC RID: 35052 RVA: 0x0011CF80 File Offset: 0x0011B180
		private void OnClearSystemBattleChestCD(ulong gameID, CustomBattleClientInfo data)
		{
			for (int i = 0; i < this._bounty_list.Count; i++)
			{
				bool flag = this._bounty_list[i].gameID == gameID;
				if (flag)
				{
					this._bounty_list[i].boxOpenTime = 0U;
				}
			}
			for (int j = 0; j < this._custom_list.Count; j++)
			{
				bool flag2 = this._custom_list[j].gameID == gameID;
				if (flag2)
				{
					this._custom_list[j].boxOpenTime = 0U;
				}
			}
			bool flag3 = this.CurrentBountyData != null && this.CurrentBountyData.gameID == gameID;
			if (flag3)
			{
				this.CurrentBountyData.boxOpenTime = 0U;
			}
			bool flag4 = this.CurrentCustomData != null && this.CurrentCustomData.gameID == gameID;
			if (flag4)
			{
				this.CurrentCustomData.boxOpenTime = 0U;
			}
			this.RefreshAllView();
		}

		// Token: 0x060088ED RID: 35053 RVA: 0x0011D084 File Offset: 0x0011B284
		private void OnFetchSystemBattleChest(ulong gameID, CustomBattleClientInfo data)
		{
			for (int i = 0; i < this._bounty_list.Count; i++)
			{
				bool flag = this._bounty_list[i].gameID == gameID;
				if (flag)
				{
					this._bounty_list[i].status = CustomBattleRoleState.CustomBattle_RoleState_Ready;
				}
			}
			for (int j = 0; j < this._custom_list.Count; j++)
			{
				bool flag2 = this._custom_list[j].gameID == gameID;
				if (flag2)
				{
					this._custom_list[j].gameStatus = CustomBattleState.CustomBattle_End;
					this._custom_list[j].selfStatus = CustomBattleRoleState.Custombattle_RoleState_Taken;
				}
			}
			bool flag3 = this.CurrentBountyData != null && this.CurrentBountyData.gameID == gameID;
			if (flag3)
			{
				this.CurrentBountyData.status = CustomBattleRoleState.CustomBattle_RoleState_Ready;
				this.CurrentBountyData = null;
			}
			bool flag4 = this.CurrentCustomData != null && this.CurrentCustomData.gameID == gameID;
			if (flag4)
			{
				this.CurrentCustomData.gameStatus = CustomBattleState.CustomBattle_End;
				this.CurrentCustomData.selfStatus = CustomBattleRoleState.Custombattle_RoleState_Taken;
			}
			bool flag5 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._ChestHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._ChestHandler.IsVisible();
			if (flag5)
			{
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._ChestHandler.SetVisible(false);
			}
			bool flag6 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler.IsVisible();
			if (flag6)
			{
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler.SetVisible(false);
			}
			this.RefreshAllView();
		}

		// Token: 0x060088EE RID: 35054 RVA: 0x0011D21C File Offset: 0x0011B41C
		private void OnCreateGameSucc(ulong gameID, CustomBattleClientInfo data)
		{
			bool flag = this.SelfCustomData == null;
			if (flag)
			{
				this.SelfCustomData = new XCustomBattleDocument.CustomModeData();
			}
			this.SetCustomInfo(this.SelfCustomData, data.createinfo);
			bool flag2 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler != null;
			if (flag2)
			{
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeCreateHandler.SetVisible(false);
			}
			this.RefreshAllView();
		}

		// Token: 0x060088EF RID: 35055 RVA: 0x0011D280 File Offset: 0x0011B480
		private void ShowCustomBattleInfo(ulong gameID, CustomBattleClientInfo data)
		{
			bool flag = !DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				for (int i = 0; i < this._bounty_list.Count; i++)
				{
					bool flag2 = this._bounty_list[i].gameID == gameID;
					if (flag2)
					{
						bool flag3 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeListHandler != null;
						if (flag3)
						{
							DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeListHandler.ShowDetailByIndex(i);
							this.SendCustomBattleQueryBountyMode();
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("JoinBountyBattle"), "fece00");
							break;
						}
					}
				}
				for (int j = 0; j < this._custom_list.Count; j++)
				{
					bool flag4 = this._custom_list[j].gameID == gameID;
					if (flag4)
					{
						bool flag5 = data != null && data.joininfo != null;
						if (flag5)
						{
							bool flag6 = this.SelfCustomData == null;
							if (flag6)
							{
								this.SelfCustomData = new XCustomBattleDocument.CustomModeData();
							}
							this.SetCustomInfo(this.SelfCustomData, data.joininfo);
							bool flag7 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeListHandler != null;
							if (flag7)
							{
								DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeListHandler.ShowSelfDetail();
								this.SendCustomBattleQueryCustomModeList(this.QueryCross);
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("JoinCustomBattle"), "fece00");
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x060088F0 RID: 35056 RVA: 0x0011D40C File Offset: 0x0011B60C
		private void RefreshCustomBattleInfo()
		{
			bool flag = !DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				this.SendCustomBattleQueryBountyMode();
				this.SendCustomBattleQueryCustomModeList(this.QueryCross);
				bool flag2 = this.CurrentCustomData != null;
				if (flag2)
				{
					this.SendCustomBattleSearchCustomModeList(this.CurrentCustomData.gameID);
				}
				this.SendCustomBattleQueryCustomModeSelfInfo();
			}
		}

		// Token: 0x060088F1 RID: 35057 RVA: 0x0011D468 File Offset: 0x0011B668
		private void SetCustomBattleList(CustomBattleClientInfo data)
		{
			this._bounty_list.Clear();
			bool flag = data == null || data.queryinfo == null || data.queryinfo.battlesystem == null;
			if (flag)
			{
				this.RefreshAllView();
			}
			else
			{
				for (int i = 0; i < data.queryinfo.battlesystem.Count; i++)
				{
					bool flag2 = data.queryinfo.battlesystem[i].data == null;
					if (!flag2)
					{
						bool issystem = data.queryinfo.battlesystem[i].data.config.issystem;
						if (issystem)
						{
							this.AddBountyInfoList(data.queryinfo.battlesystem[i]);
						}
					}
				}
				this.RefreshAllView();
			}
		}

		// Token: 0x060088F2 RID: 35058 RVA: 0x0011D538 File Offset: 0x0011B738
		private void SetCustomBattleCustomModeListSearch(CustomBattleClientInfo data)
		{
			this._custom_list.Clear();
			bool flag = data == null || data.searchinfo == null;
			if (flag)
			{
				this.RefreshAllView();
			}
			else
			{
				for (int i = 0; i < data.searchinfo.Count; i++)
				{
					bool flag2 = data.searchinfo[i].data == null;
					if (!flag2)
					{
						this._custom_list.Add(new XCustomBattleDocument.CustomModeData());
						this.SetCustomInfo(this._custom_list[i], data.searchinfo[i]);
					}
				}
				this.RefreshAllView();
			}
		}

		// Token: 0x060088F3 RID: 35059 RVA: 0x0011D5DC File Offset: 0x0011B7DC
		private void SetCustomBattleCustomModeListRandom(CustomBattleClientInfo data)
		{
			this._custom_list.Clear();
			bool flag = data == null || data.queryinfo == null || data.queryinfo.battlerandom == null;
			if (flag)
			{
				this.RefreshAllView();
			}
			else
			{
				for (int i = 0; i < data.queryinfo.battlerandom.Count; i++)
				{
					bool flag2 = data.queryinfo.battlerandom[i].data == null;
					if (!flag2)
					{
						this._custom_list.Add(new XCustomBattleDocument.CustomModeData());
						this.SetCustomInfo(this._custom_list[i], data.queryinfo.battlerandom[i]);
					}
				}
				this.RefreshAllView();
			}
		}

		// Token: 0x060088F4 RID: 35060 RVA: 0x0011D69C File Offset: 0x0011B89C
		private void SetCustomBattleCustomModeListOne(CustomBattleClientInfo data)
		{
			bool flag = data == null || data.queryinfo == null || data.queryinfo.battleone == null;
			if (flag)
			{
				this.RefreshAllView();
			}
			else
			{
				bool flag2 = data.queryinfo.battleone.data != null;
				if (flag2)
				{
					for (int i = 0; i < this._custom_list.Count; i++)
					{
						bool flag3 = this._custom_list[i].gameID == data.queryinfo.battleone.data.uid;
						if (flag3)
						{
							this.SetCustomInfo(this._custom_list[i], data.queryinfo.battleone);
						}
					}
					bool flag4 = this.SelfCustomData != null && this.SelfCustomData.gameID == data.queryinfo.battleone.data.uid;
					if (flag4)
					{
						this.SetCustomInfo(this.SelfCustomData, data.queryinfo.battleone);
					}
				}
				this.RefreshAllView();
			}
		}

		// Token: 0x060088F5 RID: 35061 RVA: 0x0011D7B4 File Offset: 0x0011B9B4
		private void SetCustomBattleCustomModeSelfInfo(CustomBattleClientInfo data)
		{
			bool flag = data == null || data.joininfo == null;
			if (flag)
			{
				this.RefreshAllView();
			}
			else
			{
				bool flag2 = data.joininfo.data != null;
				if (flag2)
				{
					bool flag3 = this.SelfCustomData == null;
					if (flag3)
					{
						this.SelfCustomData = new XCustomBattleDocument.CustomModeData();
					}
					this.SetCustomInfo(this.SelfCustomData, data.joininfo);
				}
				this.RefreshAllView();
			}
		}

		// Token: 0x060088F6 RID: 35062 RVA: 0x0011D828 File Offset: 0x0011BA28
		private void ShowMatchingHandler()
		{
			bool flag = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowMatchingHandler();
			}
		}

		// Token: 0x060088F7 RID: 35063 RVA: 0x0011D851 File Offset: 0x0011BA51
		private void OnUnjoinBattleSucc()
		{
			this.SelfCustomData = null;
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler.SetVisible(false);
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeListHandler();
		}

		// Token: 0x060088F8 RID: 35064 RVA: 0x0011D878 File Offset: 0x0011BA78
		public void ShowTeamView(int expID)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(expID);
		}

		// Token: 0x060088F9 RID: 35065 RVA: 0x0011D89C File Offset: 0x0011BA9C
		private void AddBountyInfoList(CustomBattleDataRole info)
		{
			CustomBattleSystemTable.RowData byid = XCustomBattleDocument._customSystemTable.GetByid((uint)info.data.uid);
			bool flag = byid == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Bounty Game not found: " + info.data.uid, null, null, null, null, null);
			}
			else
			{
				XCustomBattleDocument.BountyModeData bountyModeData = new XCustomBattleDocument.BountyModeData();
				bountyModeData.gameID = info.data.uid;
				bountyModeData.expID = byid.ExpID;
				bountyModeData.gameName = byid.desc;
				bountyModeData.gameType = byid.type;
				bountyModeData.ticket = new ItemBrief();
				bountyModeData.ticket.itemID = byid.ticket[0];
				bountyModeData.ticket.itemCount = byid.ticket[1];
				bool flag2 = info.role != null;
				if (flag2)
				{
					bountyModeData.status = info.role.state;
					bountyModeData.winMax = byid.end[0];
					bountyModeData.winCount = info.role.win;
					bountyModeData.loseCount = info.role.lose;
					bountyModeData.boxOpenTime = (uint)Time.time + info.role.rewardcd;
				}
				else
				{
					bountyModeData.status = CustomBattleRoleState.CustomBattle_RoleState_Ready;
					bountyModeData.winMax = byid.end[0];
					bountyModeData.winCount = 0U;
					bountyModeData.loseCount = 0U;
					bountyModeData.boxOpenTime = 0U;
				}
				this._bounty_list.Add(bountyModeData);
				bool flag3 = this.CurrentBountyData != null;
				if (flag3)
				{
					bool flag4 = this.CurrentBountyData.gameID == bountyModeData.gameID;
					if (flag4)
					{
						this.CurrentBountyData = bountyModeData;
					}
				}
			}
		}

		// Token: 0x060088FA RID: 35066 RVA: 0x0011DA50 File Offset: 0x0011BC50
		public SeqListRef<uint> GetSystemBattleReward(uint id, uint win)
		{
			for (int i = 0; i < XCustomBattleDocument._customSystemRewardTable.Table.Length; i++)
			{
				bool flag = XCustomBattleDocument._customSystemRewardTable.Table[i].id == id && XCustomBattleDocument._customSystemRewardTable.Table[i].wincounts == win;
				if (flag)
				{
					return XCustomBattleDocument._customSystemRewardTable.Table[i].rewardshow;
				}
			}
			return default(SeqListRef<uint>);
		}

		// Token: 0x060088FB RID: 35067 RVA: 0x0011DAD0 File Offset: 0x0011BCD0
		public SeqRef<uint> GetSystemBattleQuickOpenCost(uint id, uint win)
		{
			for (int i = 0; i < XCustomBattleDocument._customSystemRewardTable.Table.Length; i++)
			{
				bool flag = XCustomBattleDocument._customSystemRewardTable.Table[i].id == id && XCustomBattleDocument._customSystemRewardTable.Table[i].wincounts == win;
				if (flag)
				{
					return XCustomBattleDocument._customSystemRewardTable.Table[i].boxquickopen;
				}
			}
			return new SeqRef<uint>(DataHandler.defaultUIntBuffer);
		}

		// Token: 0x060088FC RID: 35068 RVA: 0x0011DB50 File Offset: 0x0011BD50
		private void SetCustomInfo(XCustomBattleDocument.CustomModeData data, CustomBattleDataRole info)
		{
			CustomBattleTable.RowData byid = XCustomBattleDocument._customBattleTable.GetByid(info.data.config.configid);
			bool flag = byid == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Bounty Game not found: " + info.data.config.configid, null, null, null, null, null);
			}
			else
			{
				data.token = info.data.config.token;
				data.gameID = info.data.uid;
				data.expID = byid.ExpID;
				data.gameName = info.data.config.name;
				data.configID = info.data.config.configid;
				data.gameType = info.data.config.tagtype;
				data.gameCreator = info.data.config.creatorname;
				data.creatorID = info.data.config.creator;
				data.joinCount = info.data.config.hasjoincount;
				data.maxJoinCount = info.data.config.canjoincount;
				data.gameLength = info.data.config.battletimeconf;
				data.gameReadyTime = (uint)Time.time + info.data.config.readytime;
				data.gameBattleTime = (uint)Time.time + info.data.config.battletime;
				data.gameMask = info.data.config.scalemask;
				data.tagMask = info.data.config.tagmask;
				data.fairMode = info.data.config.isfair;
				data.hasPassword = info.data.config.haspassword;
				data.gamePassword = info.data.config.password;
				data.gameStatus = info.data.config.state;
				bool flag2 = info.role != null;
				if (flag2)
				{
					data.selfPoint = info.role.point;
					data.selfRank = info.role.rank;
					data.selfStatus = info.role.state;
					data.boxOpenTime = (uint)Time.time + info.role.rewardcd;
				}
				else
				{
					data.selfPoint = 0U;
					data.selfRank = 0U;
					data.selfStatus = (CustomBattleRoleState)0;
					data.boxOpenTime = 0U;
				}
				bool flag3 = info.data.rank != null && info.data.rank.Count > 0;
				if (flag3)
				{
					data.rankList.Clear();
					for (int i = 0; i < info.data.rank.Count; i++)
					{
						data.rankList.Add(info.data.rank[i]);
					}
				}
				bool flag4 = this.CurrentCustomData != null;
				if (flag4)
				{
					bool flag5 = this.CurrentCustomData.gameID == data.gameID;
					if (flag5)
					{
						this.CurrentCustomData = data;
					}
				}
			}
		}

		// Token: 0x060088FD RID: 35069 RVA: 0x0011DE80 File Offset: 0x0011C080
		public void ResetCustomModeCreateData()
		{
			XCustomBattleDocument.CustomModeCreateData customModeCreateData = default(XCustomBattleDocument.CustomModeCreateData);
			customModeCreateData.gameName = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
			customModeCreateData.gameType = XCustomBattleDocument._customBattleTable.Table[0].type;
			customModeCreateData.configID = XCustomBattleDocument._customBattleTable.Table[0].id;
			customModeCreateData.canJoinCount = XCustomBattleDocument._customBattleTable.Table[0].joincount;
			customModeCreateData.battleTimeIndex = 0U;
			customModeCreateData.hasPassword = false;
			customModeCreateData.password = "";
			customModeCreateData.isFair = false;
			customModeCreateData.scaleMask = 0U;
			customModeCreateData.readyTime = XCustomBattleDocument._customBattleTable.Table[0].readytimepan;
			customModeCreateData.cost = new ItemBrief();
			customModeCreateData.cost.itemID = XCustomBattleDocument._customBattleTable.Table[0].create[0, 0];
			customModeCreateData.cost.itemCount = XCustomBattleDocument._customBattleTable.Table[0].create[0, 1];
			this.CustomCreateData = customModeCreateData;
		}

		// Token: 0x060088FE RID: 35070 RVA: 0x0011DF94 File Offset: 0x0011C194
		public CustomBattleTypeTable.RowData[] GetCustomBattleTypelist()
		{
			return XCustomBattleDocument._customBattleType.Table;
		}

		// Token: 0x060088FF RID: 35071 RVA: 0x0011DFB0 File Offset: 0x0011C1B0
		public CustomBattleTypeTable.RowData GetCustomBattleTypeData(int typeID)
		{
			return XCustomBattleDocument._customBattleType.GetBytype(typeID);
		}

		// Token: 0x06008900 RID: 35072 RVA: 0x0011DFD0 File Offset: 0x0011C1D0
		public CustomBattleTable.RowData GetCustomBattleData(uint configid)
		{
			return XCustomBattleDocument._customBattleTable.GetByid(configid);
		}

		// Token: 0x06008901 RID: 35073 RVA: 0x0011DFF0 File Offset: 0x0011C1F0
		public uint GetCustomBattleFirstID(uint type)
		{
			uint num = uint.MaxValue;
			for (int i = 0; i < XCustomBattleDocument._customBattleTable.Table.Length; i++)
			{
				bool flag = type == XCustomBattleDocument._customBattleTable.Table[i].type && XCustomBattleDocument._customBattleTable.Table[i].id < num;
				if (flag)
				{
					num = XCustomBattleDocument._customBattleTable.Table[i].id;
				}
			}
			return num;
		}

		// Token: 0x06008902 RID: 35074 RVA: 0x0011E068 File Offset: 0x0011C268
		public uint GetCustomBattleNextID(uint type, uint currentid)
		{
			uint num = uint.MaxValue;
			for (int i = 0; i < XCustomBattleDocument._customBattleTable.Table.Length; i++)
			{
				bool flag = type == XCustomBattleDocument._customBattleTable.Table[i].type && XCustomBattleDocument._customBattleTable.Table[i].id > currentid && XCustomBattleDocument._customBattleTable.Table[i].id < num;
				if (flag)
				{
					num = XCustomBattleDocument._customBattleTable.Table[i].id;
				}
			}
			return num;
		}

		// Token: 0x06008903 RID: 35075 RVA: 0x0011E0F4 File Offset: 0x0011C2F4
		public uint GetCustomBattlePreID(uint type, uint currentid)
		{
			uint num = 0U;
			for (int i = 0; i < XCustomBattleDocument._customBattleTable.Table.Length; i++)
			{
				bool flag = type == XCustomBattleDocument._customBattleTable.Table[i].type && XCustomBattleDocument._customBattleTable.Table[i].id < currentid && XCustomBattleDocument._customBattleTable.Table[i].id > num;
				if (flag)
				{
					num = XCustomBattleDocument._customBattleTable.Table[i].id;
				}
			}
			return num;
		}

		// Token: 0x06008904 RID: 35076 RVA: 0x0011E180 File Offset: 0x0011C380
		public uint GetCustomBattleLevelLimitByType(uint type)
		{
			for (int i = 0; i < XCustomBattleDocument._customBattleTable.Table.Length; i++)
			{
				bool flag = XCustomBattleDocument._customBattleTable.Table[i].type == type;
				if (flag)
				{
					return XCustomBattleDocument._customBattleTable.Table[i].levellimit;
				}
			}
			return 0U;
		}

		// Token: 0x06008905 RID: 35077 RVA: 0x0011E1DC File Offset: 0x0011C3DC
		public SeqListRef<uint> GetCustomBattleBestReward(uint configID)
		{
			for (int i = 0; i < XCustomBattleDocument._customRewardTable.Table.Length; i++)
			{
				bool flag = XCustomBattleDocument._customRewardTable.Table[i].id == configID && XCustomBattleDocument._customRewardTable.Table[i].rank[0] == 1U;
				if (flag)
				{
					return XCustomBattleDocument._customRewardTable.Table[i].rewardshow;
				}
			}
			return default(SeqListRef<uint>);
		}

		// Token: 0x06008906 RID: 35078 RVA: 0x0011E260 File Offset: 0x0011C460
		public SeqListRef<uint> GetCustomBattleRewardByRank(uint configID, uint rank)
		{
			for (int i = 0; i < XCustomBattleDocument._customRewardTable.Table.Length; i++)
			{
				bool flag = XCustomBattleDocument._customRewardTable.Table[i].id == configID && XCustomBattleDocument._customRewardTable.Table[i].rank[0] <= rank && XCustomBattleDocument._customRewardTable.Table[i].rank[1] >= rank;
				if (flag)
				{
					return XCustomBattleDocument._customRewardTable.Table[i].rewardshow;
				}
			}
			return default(SeqListRef<uint>);
		}

		// Token: 0x06008907 RID: 35079 RVA: 0x0011E300 File Offset: 0x0011C500
		public SeqRef<uint> GetCustomBattleQuickOpenCost(uint configID, uint rank)
		{
			for (int i = 0; i < XCustomBattleDocument._customRewardTable.Table.Length; i++)
			{
				bool flag = XCustomBattleDocument._customRewardTable.Table[i].id == configID && XCustomBattleDocument._customRewardTable.Table[i].rank[0] <= rank && XCustomBattleDocument._customRewardTable.Table[i].rank[1] >= rank;
				if (flag)
				{
					return XCustomBattleDocument._customRewardTable.Table[i].boxquickopen;
				}
			}
			return new SeqRef<uint>(DataHandler.defaultUIntBuffer);
		}

		// Token: 0x06008908 RID: 35080 RVA: 0x0011E3A0 File Offset: 0x0011C5A0
		public void DestoryFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

		// Token: 0x06008909 RID: 35081 RVA: 0x0011E3C8 File Offset: 0x0011C5C8
		private void RefreshRedPoint()
		{
			this.BountyModeRedPoint = false;
			this.CustomModeRedPoint = false;
			for (int i = 0; i < this._bounty_list.Count; i++)
			{
				this.BountyModeRedPoint |= (this._bounty_list[i].status == CustomBattleRoleState.CustomBattle_RoleState_Reward && this._bounty_list[i].boxLeftTime == 0U);
			}
			for (int j = 0; j < this._custom_list.Count; j++)
			{
				this.CustomModeRedPoint |= (this._custom_list[j].selfStatus == CustomBattleRoleState.CustomBattle_RoleState_Reward && this._custom_list[j].boxLeftTime == 0U);
			}
			bool flag = this.SelfCustomData != null;
			if (flag)
			{
				this.CustomModeRedPoint |= (this.SelfCustomData.selfStatus == CustomBattleRoleState.CustomBattle_RoleState_Reward && this.SelfCustomData.boxLeftTime == 0U);
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_CustomBattle_BountyMode, true);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_CustomBattle_CustomMode, true);
		}

		// Token: 0x0600890A RID: 35082 RVA: 0x0011E4F0 File Offset: 0x0011C6F0
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.RefreshCustomBattleInfo();
		}

		// Token: 0x04002B50 RID: 11088
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CustomBattleDocument");

		// Token: 0x04002B51 RID: 11089
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002B52 RID: 11090
		private List<XCustomBattleDocument.BountyModeData> _bounty_list = new List<XCustomBattleDocument.BountyModeData>();

		// Token: 0x04002B53 RID: 11091
		private List<XCustomBattleDocument.CustomModeData> _custom_list = new List<XCustomBattleDocument.CustomModeData>();

		// Token: 0x04002B57 RID: 11095
		public XCustomBattleDocument.CustomModeCreateData CustomCreateData;

		// Token: 0x04002B58 RID: 11096
		private ulong _currentMatchingID = 0UL;

		// Token: 0x04002B5A RID: 11098
		public bool QueryCross = true;

		// Token: 0x04002B5C RID: 11100
		public bool IsCreateGM = false;

		// Token: 0x04002B5D RID: 11101
		private static CustomBattleTable _customBattleTable = new CustomBattleTable();

		// Token: 0x04002B5E RID: 11102
		private static CustomRewardTable _customRewardTable = new CustomRewardTable();

		// Token: 0x04002B5F RID: 11103
		private static CustomBattleSystemTable _customSystemTable = new CustomBattleSystemTable();

		// Token: 0x04002B60 RID: 11104
		private static CustomSystemRewardTable _customSystemRewardTable = new CustomSystemRewardTable();

		// Token: 0x04002B61 RID: 11105
		private static CustomBattleTypeTable _customBattleType = new CustomBattleTypeTable();

		// Token: 0x02001953 RID: 6483
		public class BountyModeData
		{
			// Token: 0x17003B3B RID: 15163
			// (get) Token: 0x06010FE4 RID: 69604 RVA: 0x00452B60 File Offset: 0x00450D60
			public float winPrecent
			{
				get
				{
					return 1f * this.winCount / this.winMax;
				}
			}

			// Token: 0x17003B3C RID: 15164
			// (get) Token: 0x06010FE5 RID: 69605 RVA: 0x00452B8C File Offset: 0x00450D8C
			public string winText
			{
				get
				{
					return string.Format("{0}/{1}", this.winCount, this.winMax);
				}
			}

			// Token: 0x17003B3D RID: 15165
			// (get) Token: 0x06010FE6 RID: 69606 RVA: 0x00452BC0 File Offset: 0x00450DC0
			public uint boxLeftTime
			{
				get
				{
					return (Time.time < this.boxOpenTime) ? (this.boxOpenTime - (uint)Time.time) : 0U;
				}
			}

			// Token: 0x04007D95 RID: 32149
			public ulong gameID;

			// Token: 0x04007D96 RID: 32150
			public int expID;

			// Token: 0x04007D97 RID: 32151
			public uint gameType;

			// Token: 0x04007D98 RID: 32152
			public string gameName;

			// Token: 0x04007D99 RID: 32153
			public ItemBrief ticket;

			// Token: 0x04007D9A RID: 32154
			public CustomBattleRoleState status;

			// Token: 0x04007D9B RID: 32155
			public uint winMax;

			// Token: 0x04007D9C RID: 32156
			public uint winCount;

			// Token: 0x04007D9D RID: 32157
			public uint loseCount;

			// Token: 0x04007D9E RID: 32158
			public uint boxOpenTime;
		}

		// Token: 0x02001954 RID: 6484
		public class CustomModeData
		{
			// Token: 0x17003B3E RID: 15166
			// (get) Token: 0x06010FE8 RID: 69608 RVA: 0x00452BF4 File Offset: 0x00450DF4
			public string joinText
			{
				get
				{
					return string.Format("{0}/{1}", this.joinCount, this.maxJoinCount);
				}
			}

			// Token: 0x17003B3F RID: 15167
			// (get) Token: 0x06010FE9 RID: 69609 RVA: 0x00452C28 File Offset: 0x00450E28
			public uint gameStartLeftTime
			{
				get
				{
					return (Time.time < this.gameReadyTime) ? (this.gameReadyTime - (uint)Time.time) : 0U;
				}
			}

			// Token: 0x17003B40 RID: 15168
			// (get) Token: 0x06010FEA RID: 69610 RVA: 0x00452C5C File Offset: 0x00450E5C
			public uint gameEndLeftTime
			{
				get
				{
					return (Time.time < this.gameBattleTime) ? (this.gameBattleTime - (uint)Time.time) : 0U;
				}
			}

			// Token: 0x17003B41 RID: 15169
			// (get) Token: 0x06010FEB RID: 69611 RVA: 0x00452C90 File Offset: 0x00450E90
			public uint boxLeftTime
			{
				get
				{
					return (Time.time < this.boxOpenTime) ? (this.boxOpenTime - (uint)Time.time) : 0U;
				}
			}

			// Token: 0x04007D9F RID: 32159
			public string token;

			// Token: 0x04007DA0 RID: 32160
			public ulong gameID;

			// Token: 0x04007DA1 RID: 32161
			public int expID;

			// Token: 0x04007DA2 RID: 32162
			public uint configID;

			// Token: 0x04007DA3 RID: 32163
			public uint gameType;

			// Token: 0x04007DA4 RID: 32164
			public string gameName;

			// Token: 0x04007DA5 RID: 32165
			public string gameCreator;

			// Token: 0x04007DA6 RID: 32166
			public ulong creatorID;

			// Token: 0x04007DA7 RID: 32167
			public uint joinCount;

			// Token: 0x04007DA8 RID: 32168
			public uint maxJoinCount;

			// Token: 0x04007DA9 RID: 32169
			public uint gameLength;

			// Token: 0x04007DAA RID: 32170
			public uint gameReadyTime;

			// Token: 0x04007DAB RID: 32171
			public uint gameBattleTime;

			// Token: 0x04007DAC RID: 32172
			public uint gameMask;

			// Token: 0x04007DAD RID: 32173
			public uint tagMask;

			// Token: 0x04007DAE RID: 32174
			public bool fairMode;

			// Token: 0x04007DAF RID: 32175
			public bool hasPassword;

			// Token: 0x04007DB0 RID: 32176
			public string gamePassword;

			// Token: 0x04007DB1 RID: 32177
			public CustomBattleState gameStatus;

			// Token: 0x04007DB2 RID: 32178
			public uint selfPoint;

			// Token: 0x04007DB3 RID: 32179
			public uint selfRank;

			// Token: 0x04007DB4 RID: 32180
			public CustomBattleRoleState selfStatus;

			// Token: 0x04007DB5 RID: 32181
			public uint boxOpenTime;

			// Token: 0x04007DB6 RID: 32182
			public List<CustomBattleRank> rankList = new List<CustomBattleRank>();
		}

		// Token: 0x02001955 RID: 6485
		public struct CustomModeCreateData
		{
			// Token: 0x04007DB7 RID: 32183
			public string gameName;

			// Token: 0x04007DB8 RID: 32184
			public uint gameType;

			// Token: 0x04007DB9 RID: 32185
			public uint configID;

			// Token: 0x04007DBA RID: 32186
			public uint canJoinCount;

			// Token: 0x04007DBB RID: 32187
			public uint battleTimeIndex;

			// Token: 0x04007DBC RID: 32188
			public bool hasPassword;

			// Token: 0x04007DBD RID: 32189
			public string password;

			// Token: 0x04007DBE RID: 32190
			public bool isFair;

			// Token: 0x04007DBF RID: 32191
			public uint scaleMask;

			// Token: 0x04007DC0 RID: 32192
			public uint readyTime;

			// Token: 0x04007DC1 RID: 32193
			public ItemBrief cost;
		}
	}
}
