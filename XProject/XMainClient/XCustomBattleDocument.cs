using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCustomBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCustomBattleDocument.uuID;
			}
		}

		public List<XCustomBattleDocument.BountyModeData> BountyList
		{
			get
			{
				return this._bounty_list;
			}
		}

		public List<XCustomBattleDocument.CustomModeData> CustomList
		{
			get
			{
				return this._custom_list;
			}
		}

		public XCustomBattleDocument.BountyModeData CurrentBountyData { get; set; }

		public XCustomBattleDocument.CustomModeData CurrentCustomData { get; set; }

		public XCustomBattleDocument.CustomModeData SelfCustomData { get; set; }

		public ulong CurrentMatchingID
		{
			get
			{
				return this._currentMatchingID;
			}
		}

		public bool passwordForJoin { get; set; }

		public ulong CacheGameID { get; set; }

		public bool RedPoint
		{
			get
			{
				return this.BountyModeRedPoint || this.CustomModeRedPoint;
			}
		}

		public bool BountyModeRedPoint { get; set; }

		public bool CustomModeRedPoint { get; set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomBattle", XCustomBattleDocument._customBattleTable, false);
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomReward", XCustomBattleDocument._customRewardTable, false);
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomBattleSystem", XCustomBattleDocument._customSystemTable, false);
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomSystemReward", XCustomBattleDocument._customSystemRewardTable, false);
			XCustomBattleDocument.AsyncLoader.AddTask("Table/CustomBattleType", XCustomBattleDocument._customBattleType, false);
			XCustomBattleDocument.AsyncLoader.Execute(callback);
		}

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

		public void SendCustomBattleSearch(string str)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Search;
			rpcC2M_CustomBattleOp.oArg.name = str;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleQueryBountyMode()
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Query;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleQueryCustomModeList(bool queryCross = false)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_QueryRandom;
			rpcC2M_CustomBattleOp.oArg.querycross = queryCross;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleSearchCustomModeList(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_QueryOne;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleQueryCustomModeSelfInfo()
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_QuerySelf;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleMatch(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Match;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleUnMatch()
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_UnMatch;
			rpcC2M_CustomBattleOp.oArg.uid = this._currentMatchingID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleDrop(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Drop;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

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

		public void SendCustomBattleExit(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_UnJoin;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleModifyPassword(ulong gameID, string password)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Modify;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			rpcC2M_CustomBattleOp.oArg.password = password;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

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

		public void SendCustomBattleStartNow(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_StartNow;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleClearCD(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_ClearCD;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public void SendCustomBattleGetReward(ulong gameID)
		{
			RpcC2M_CustomBattleOp rpcC2M_CustomBattleOp = new RpcC2M_CustomBattleOp();
			rpcC2M_CustomBattleOp.oArg.op = CustomBattleOp.CustomBattle_Reward;
			rpcC2M_CustomBattleOp.oArg.uid = gameID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_CustomBattleOp);
		}

		public CustomBattleSystemTable.RowData GetSystemBattleData(uint id)
		{
			return XCustomBattleDocument._customSystemTable.GetByid(id);
		}

		public void DoErrorOp(CustomBattleOp op, ulong gameID)
		{
			if (op - CustomBattleOp.CustomBattle_Join <= 3)
			{
				this.RefreshCustomBattleInfo();
			}
		}

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

		private void OnCustomBattleStartNow()
		{
			this.SendCustomBattleQueryCustomModeSelfInfo();
		}

		private void OnBountyModeDrop()
		{
			this.SendCustomBattleQueryBountyMode();
		}

		private void RefreshHandler(DlgHandlerBase handler)
		{
			bool flag = handler != null && handler.IsVisible();
			if (flag)
			{
				handler.RefreshData();
			}
		}

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

		private void ShowMatchingHandler()
		{
			bool flag = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowMatchingHandler();
			}
		}

		private void OnUnjoinBattleSucc()
		{
			this.SelfCustomData = null;
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler.SetVisible(false);
			DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowCustomModeListHandler();
		}

		public void ShowTeamView(int expID)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(expID);
		}

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

		public CustomBattleTypeTable.RowData[] GetCustomBattleTypelist()
		{
			return XCustomBattleDocument._customBattleType.Table;
		}

		public CustomBattleTypeTable.RowData GetCustomBattleTypeData(int typeID)
		{
			return XCustomBattleDocument._customBattleType.GetBytype(typeID);
		}

		public CustomBattleTable.RowData GetCustomBattleData(uint configid)
		{
			return XCustomBattleDocument._customBattleTable.GetByid(configid);
		}

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

		public void DestoryFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.RefreshCustomBattleInfo();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CustomBattleDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private List<XCustomBattleDocument.BountyModeData> _bounty_list = new List<XCustomBattleDocument.BountyModeData>();

		private List<XCustomBattleDocument.CustomModeData> _custom_list = new List<XCustomBattleDocument.CustomModeData>();

		public XCustomBattleDocument.CustomModeCreateData CustomCreateData;

		private ulong _currentMatchingID = 0UL;

		public bool QueryCross = true;

		public bool IsCreateGM = false;

		private static CustomBattleTable _customBattleTable = new CustomBattleTable();

		private static CustomRewardTable _customRewardTable = new CustomRewardTable();

		private static CustomBattleSystemTable _customSystemTable = new CustomBattleSystemTable();

		private static CustomSystemRewardTable _customSystemRewardTable = new CustomSystemRewardTable();

		private static CustomBattleTypeTable _customBattleType = new CustomBattleTypeTable();

		public class BountyModeData
		{

			public float winPrecent
			{
				get
				{
					return 1f * this.winCount / this.winMax;
				}
			}

			public string winText
			{
				get
				{
					return string.Format("{0}/{1}", this.winCount, this.winMax);
				}
			}

			public uint boxLeftTime
			{
				get
				{
					return (Time.time < this.boxOpenTime) ? (this.boxOpenTime - (uint)Time.time) : 0U;
				}
			}

			public ulong gameID;

			public int expID;

			public uint gameType;

			public string gameName;

			public ItemBrief ticket;

			public CustomBattleRoleState status;

			public uint winMax;

			public uint winCount;

			public uint loseCount;

			public uint boxOpenTime;
		}

		public class CustomModeData
		{

			public string joinText
			{
				get
				{
					return string.Format("{0}/{1}", this.joinCount, this.maxJoinCount);
				}
			}

			public uint gameStartLeftTime
			{
				get
				{
					return (Time.time < this.gameReadyTime) ? (this.gameReadyTime - (uint)Time.time) : 0U;
				}
			}

			public uint gameEndLeftTime
			{
				get
				{
					return (Time.time < this.gameBattleTime) ? (this.gameBattleTime - (uint)Time.time) : 0U;
				}
			}

			public uint boxLeftTime
			{
				get
				{
					return (Time.time < this.boxOpenTime) ? (this.boxOpenTime - (uint)Time.time) : 0U;
				}
			}

			public string token;

			public ulong gameID;

			public int expID;

			public uint configID;

			public uint gameType;

			public string gameName;

			public string gameCreator;

			public ulong creatorID;

			public uint joinCount;

			public uint maxJoinCount;

			public uint gameLength;

			public uint gameReadyTime;

			public uint gameBattleTime;

			public uint gameMask;

			public uint tagMask;

			public bool fairMode;

			public bool hasPassword;

			public string gamePassword;

			public CustomBattleState gameStatus;

			public uint selfPoint;

			public uint selfRank;

			public CustomBattleRoleState selfStatus;

			public uint boxOpenTime;

			public List<CustomBattleRank> rankList = new List<CustomBattleRank>();
		}

		public struct CustomModeCreateData
		{

			public string gameName;

			public uint gameType;

			public uint configID;

			public uint canJoinCount;

			public uint battleTimeIndex;

			public bool hasPassword;

			public string password;

			public bool isFair;

			public uint scaleMask;

			public uint readyTime;

			public ItemBrief cost;
		}
	}
}
