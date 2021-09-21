using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000930 RID: 2352
	internal class XGuildArenaBattleDocument : XDocComponent
	{
		// Token: 0x17002BCD RID: 11213
		// (get) Token: 0x06008DDA RID: 36314 RVA: 0x00137CF8 File Offset: 0x00135EF8
		public override uint ID
		{
			get
			{
				return XGuildArenaBattleDocument.uuID;
			}
		}

		// Token: 0x06008DDB RID: 36315 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x17002BCE RID: 11214
		// (get) Token: 0x06008DDC RID: 36316 RVA: 0x00137D10 File Offset: 0x00135F10
		public GVGBattleInfo BlueInfo
		{
			get
			{
				return this._blueInfo;
			}
		}

		// Token: 0x17002BCF RID: 11215
		// (get) Token: 0x06008DDD RID: 36317 RVA: 0x00137D28 File Offset: 0x00135F28
		public GVGBattleInfo RedInfo
		{
			get
			{
				return this._redInfo;
			}
		}

		// Token: 0x06008DDE RID: 36318 RVA: 0x00137D40 File Offset: 0x00135F40
		private ulong GetMyGuildID()
		{
			return XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).BasicData.uid;
		}

		// Token: 0x06008DDF RID: 36319 RVA: 0x00137D68 File Offset: 0x00135F68
		public int GetBattleSignNumber()
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			int result = 0;
			bool flag = sceneType == SceneType.SCENE_GPR || sceneType == SceneType.SCENE_GCF;
			if (flag)
			{
				result = XSingleton<XGlobalConfig>.singleton.GetInt("GuildArenaBattleGpr");
			}
			else
			{
				bool flag2 = sceneType == SceneType.SCENE_GMF;
				if (flag2)
				{
					result = XSingleton<XGlobalConfig>.singleton.GetInt("GuildArenaBattleNumber");
				}
			}
			return result;
		}

		// Token: 0x17002BD0 RID: 11216
		// (get) Token: 0x06008DE0 RID: 36320 RVA: 0x00137DC8 File Offset: 0x00135FC8
		public double InspireCDTime
		{
			get
			{
				return this.m_InspireCDTime;
			}
		}

		// Token: 0x17002BD1 RID: 11217
		// (get) Token: 0x06008DE1 RID: 36321 RVA: 0x00137DE0 File Offset: 0x00135FE0
		private IGVGBattlePrepare CurView
		{
			get
			{
				bool flag = this.Pattern == GuildArenaBattlePattern.GMF || this.Pattern == GuildArenaBattlePattern.GPR;
				IGVGBattlePrepare singleton;
				if (flag)
				{
					singleton = DlgBase<InnerGVGBattlePrepareView, InnerGVGBattlePrepareBehaviour>.singleton;
				}
				else
				{
					singleton = DlgBase<CrossGVGBattlePrepareView, CrossGVGBattlePrepareBehaviour>.singleton;
				}
				return singleton;
			}
		}

		// Token: 0x17002BD2 RID: 11218
		// (get) Token: 0x06008DE2 RID: 36322 RVA: 0x00137E18 File Offset: 0x00136018
		private bool IsGVG
		{
			get
			{
				SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
				return sceneType == SceneType.SCENE_GPR || sceneType == SceneType.SCENE_GMF || sceneType == SceneType.SCENE_GCF;
			}
		}

		// Token: 0x06008DE3 RID: 36323 RVA: 0x00137E48 File Offset: 0x00136048
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool isGVG = this.IsGVG;
			if (isGVG)
			{
				this.EnterGVG();
			}
		}

		// Token: 0x06008DE4 RID: 36324 RVA: 0x00137E70 File Offset: 0x00136070
		public override void OnLeaveScene()
		{
			bool isGVG = this.IsGVG;
			if (isGVG)
			{
				this.LeaveGVG();
			}
		}

		// Token: 0x06008DE5 RID: 36325 RVA: 0x00137E8F File Offset: 0x0013608F
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			this.InspireUpdate(fDeltaT);
		}

		// Token: 0x06008DE6 RID: 36326 RVA: 0x00137EA4 File Offset: 0x001360A4
		public void OnUpdateGuildArenaBattle(GmfRoleDatas data)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("OnUpdateGuildArenaBattle", data.halfrole11.inspire.ToString(), "  ", data.halfrole22.inspire.ToString(), null, null);
			this.mGmfRoleDatas = data;
			this.MyFightState = GuildMatchFightState.GUILD_MF_NONE;
			this.MyReadyType = XGuildArenaBattleDocument.ReadyType.Observer;
			ulong myGuildID = this.GetMyGuildID();
			bool flag = data.halfrole11.guildb.guildid == myGuildID;
			if (flag)
			{
				this.InBattleGroup = true;
				this._blueInfo.Convert(data.halfrole11);
				this._redInfo.Convert(data.halfrole22);
				this.CheckRoleState(this._blueInfo.Group, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, ref this.MyFightState, ref this.MyReadyType);
			}
			else
			{
				bool flag2 = data.halfrole22.guildb.guildid == myGuildID;
				if (flag2)
				{
					this.InBattleGroup = true;
					this._blueInfo.Convert(data.halfrole22);
					this._redInfo.Convert(data.halfrole11);
					this.CheckRoleState(this._blueInfo.Group, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, ref this.MyFightState, ref this.MyReadyType);
				}
				else
				{
					this.InBattleGroup = false;
					this._blueInfo.Convert(data.halfrole11);
					this._redInfo.Convert(data.halfrole22);
				}
			}
			bool flag3 = this.IsGMF();
			if (flag3)
			{
				this.MatchPoint();
			}
			bool flag4 = this.CurView.IsVisible();
			if (flag4)
			{
				this.CurView.ReFreshGroup();
			}
		}

		// Token: 0x06008DE7 RID: 36327 RVA: 0x00138054 File Offset: 0x00136254
		private void CheckRoleState(List<GmfRole> roles, ulong roleID, ref GuildMatchFightState state, ref XGuildArenaBattleDocument.ReadyType type)
		{
			bool flag = roles == null;
			if (!flag)
			{
				type = XGuildArenaBattleDocument.ReadyType.NoReady;
				int i = 0;
				int count = roles.Count;
				while (i < count)
				{
					bool flag2 = roles[i].roleID == roleID;
					if (flag2)
					{
						state = roles[i].state;
						type = XGuildArenaBattleDocument.ReadyType.Ready;
						break;
					}
					i++;
				}
			}
		}

		// Token: 0x06008DE8 RID: 36328 RVA: 0x001380B4 File Offset: 0x001362B4
		private void SpectateSpecial(GmfRoleDatas data)
		{
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
				bool flag = specificDocument.BlueSaveID == 0UL || specificDocument.RedSaveID == 0UL;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.SpectateSpecial ", specificDocument.BlueSaveID.ToString(), " <-> ", specificDocument.RedSaveID.ToString(), null, null, XDebugColor.XDebug_None);
				}
				else
				{
					bool flag2 = specificDocument.BlueSaveID == data.halfrole11.guildb.guildid;
					if (flag2)
					{
						this._blueInfo.Convert(data.halfrole11);
						this._redInfo.Convert(data.halfrole22);
						this.MyReadyType = XGuildArenaBattleDocument.ReadyType.NoReady;
						foreach (GmfRole gmfRole in this._blueInfo.Group)
						{
							bool flag3 = gmfRole.roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
							if (flag3)
							{
								this.MyReadyType = XGuildArenaBattleDocument.ReadyType.Ready;
								this.MyFightState = gmfRole.state;
								break;
							}
						}
					}
					else
					{
						bool flag4 = specificDocument.BlueSaveID == data.halfrole22.guildb.guildid;
						if (flag4)
						{
							this._blueInfo.Convert(data.halfrole22);
							this._redInfo.Convert(data.halfrole11);
							this.MyReadyType = XGuildArenaBattleDocument.ReadyType.NoReady;
							foreach (GmfRole gmfRole2 in this._blueInfo.Group)
							{
								bool flag5 = gmfRole2.roleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
								if (flag5)
								{
									this.MyReadyType = XGuildArenaBattleDocument.ReadyType.Ready;
									this.MyFightState = gmfRole2.state;
									break;
								}
							}
						}
						else
						{
							this._blueInfo.Convert(data.halfrole11);
							this._redInfo.Convert(data.halfrole22);
							this.MyReadyType = XGuildArenaBattleDocument.ReadyType.Observer;
						}
					}
				}
			}
		}

		// Token: 0x06008DE9 RID: 36329 RVA: 0x001382F8 File Offset: 0x001364F8
		private void MatchPoint()
		{
			int num = 0;
			int num2 = 0;
			foreach (GmfRole gmfRole in this._blueInfo.Group)
			{
				bool flag = gmfRole.roleID == 0UL;
				if (!flag)
				{
					GuildMatchFightState state = gmfRole.state;
					if (state == GuildMatchFightState.GUILD_MF_WAITING || state == GuildMatchFightState.GUILD_MF_FIGHTING)
					{
						num++;
					}
				}
			}
			foreach (GmfRole gmfRole2 in this._redInfo.Group)
			{
				bool flag2 = gmfRole2.roleID == 0UL;
				if (!flag2)
				{
					GuildMatchFightState state2 = gmfRole2.state;
					if (state2 == GuildMatchFightState.GUILD_MF_WAITING || state2 == GuildMatchFightState.GUILD_MF_FIGHTING)
					{
						num2++;
					}
				}
			}
			this.GMFGroupBlueMatchPoint = num;
			this.GMFGroupRedMatchPoint = num2;
		}

		// Token: 0x06008DEA RID: 36330 RVA: 0x00138408 File Offset: 0x00136608
		public void OnUpdateBattleEnd(GmfOneBattleEnd data)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnUpdateBattleEnd ", data.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = !this.IsGMF();
			if (!flag)
			{
				bool flag2 = DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
				}
				bool flag3 = data.winguild.guildid == XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).BasicData.uid;
				if (flag3)
				{
					this.blueBattleEndData.isWin = true;
					this.redBattleEndData.isWin = false;
					this.blueBattleEndData.Role = data.winrole;
					this.redBattleEndData.Role = data.loselrole;
					this.blueBattleEndData.Guild = data.winguild;
					this.redBattleEndData.Guild = data.loseguild;
				}
				else
				{
					bool flag4 = data.loseguild.guildid == XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).BasicData.uid;
					if (flag4)
					{
						this.blueBattleEndData.isWin = false;
						this.redBattleEndData.isWin = true;
						this.blueBattleEndData.Role = data.loselrole;
						this.redBattleEndData.Role = data.winrole;
						this.blueBattleEndData.Guild = data.loseguild;
						this.redBattleEndData.Guild = data.winguild;
					}
					else
					{
						this.blueBattleEndData.isWin = true;
						this.redBattleEndData.isWin = false;
						this.blueBattleEndData.Role = data.winrole;
						this.redBattleEndData.Role = data.loselrole;
						this.blueBattleEndData.Guild = data.winguild;
						this.redBattleEndData.Guild = data.loseguild;
					}
				}
				ulong roleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				bool flag5 = roleID == this.blueBattleEndData.Role.roleid;
				bool flag6 = roleID == this.redBattleEndData.Role.roleid;
				bool flag7 = flag5;
				if (flag7)
				{
					XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.GmfOneBattleEnd Killer", null, null, null, null, null, XDebugColor.XDebug_None);
				}
				bool flag8 = flag6;
				if (flag8)
				{
					XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.GmfOneBattleEnd Deader", null, null, null, null, null, XDebugColor.XDebug_None);
				}
				string smallResult = string.Empty;
				switch (data.reason)
				{
				case GMFFailReason.GMF_FAIL_NONE:
				case GMFFailReason.GMF_FAIL_DIE:
					DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetSmallResult("");
					break;
				case GMFFailReason.GMF_FAIL_TIMEOVER:
					smallResult = string.Format(XStringDefineProxy.GetString("GUILD_ARENA_OVERTIME_WINER_PERSONAL"), data.winrole.rolename);
					DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetSmallResult(smallResult);
					break;
				case GMFFailReason.GMF_FAIL_QUIT:
					smallResult = string.Format(XStringDefineProxy.GetString("GUILD_ARENA_THEY_QUITE_PERSONAL"), data.loselrole.rolename);
					DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetSmallResult(smallResult);
					break;
				case GMFFailReason.GMF_FAIL_REFRESE:
					DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetSmallResult("");
					break;
				default:
					DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetSmallResult("");
					break;
				}
			}
		}

		// Token: 0x06008DEB RID: 36331 RVA: 0x00138700 File Offset: 0x00136900
		public void ReceiveGuildCombatNotify(GmfGuildCombatPara param)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.ReceiveGuildCombatNotify ", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = param.guildcombat11 == null || param.guildcombat22 == null;
			if (!flag)
			{
				ulong myGuildID = this.GetMyGuildID();
				bool flag2 = param.guildcombat11.gmfguild.guildid == myGuildID;
				if (flag2)
				{
					this.blueCombatInfo.Set(param.guildcombat11);
					this.redCombatInfo.Set(param.guildcombat22);
					this.BlueInfo.Convert(param.guildcombat11.rolecombat);
					this.RedInfo.Convert(param.guildcombat22.rolecombat);
				}
				else
				{
					bool flag3 = param.guildcombat22.gmfguild.guildid == myGuildID;
					if (flag3)
					{
						this.blueCombatInfo.Set(param.guildcombat22);
						this.redCombatInfo.Set(param.guildcombat11);
						this.BlueInfo.Convert(param.guildcombat22.rolecombat);
						this.RedInfo.Convert(param.guildcombat11.rolecombat);
					}
					else
					{
						this.blueCombatInfo.Set(param.guildcombat11);
						this.redCombatInfo.Set(param.guildcombat22);
						this.BlueInfo.Convert(param.guildcombat11.rolecombat);
						this.RedInfo.Convert(param.guildcombat22.rolecombat);
					}
				}
				this.Round = param.guildcombat11.score + param.guildcombat22.score;
				XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.ReceiveGuildCombatNotify ", this.Round.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				bool flag4 = this.CurView.IsVisible();
				if (flag4)
				{
					this.CurView.ReFreshGroup();
				}
			}
		}

		// Token: 0x06008DEC RID: 36332 RVA: 0x001388D4 File Offset: 0x00136AD4
		public void OnAllFightEnd(GmfAllFightEnd data)
		{
			bool flag = !this.IsGMF();
			if (!flag)
			{
				bool flag2 = DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
				}
				string log = "winguild:" + data.winguild.ToString() + "loseguildid:" + data.loseguild.ToString();
				XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnAllFightEnd ", log, null, null, null, null, XDebugColor.XDebug_None);
				DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.RefreahCountTime(10f, true);
				bool flag3 = data.winguild.guildid == XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).BasicData.uid;
				if (flag3)
				{
					this.blueAllFightEnd.isWin = true;
					this.redAllFightEnd.isWin = false;
					this.blueAllFightEnd.Guild = data.winguild;
					this.redAllFightEnd.Guild = data.loseguild;
				}
				else
				{
					bool flag4 = data.loseguild.guildid == XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).BasicData.uid;
					if (flag4)
					{
						this.blueAllFightEnd.isWin = false;
						this.redAllFightEnd.isWin = true;
						this.blueAllFightEnd.Guild = data.loseguild;
						this.redAllFightEnd.Guild = data.winguild;
					}
					else
					{
						this.blueAllFightEnd.isWin = true;
						this.redAllFightEnd.isWin = false;
						this.blueAllFightEnd.Guild = data.winguild;
						this.redAllFightEnd.Guild = data.loseguild;
					}
				}
				GmfGuildBrief winguild = data.winguild;
				GmfGuildBrief loseguild = data.loseguild;
				this.CurView.SetVisible(false, true);
				DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetVisible(true, true);
				string guildResult = string.Empty;
				bool flag5 = winguild.guildid == loseguild.guildid;
				if (flag5)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("data.winguildid = data.loseguildid", null, null, null, null, null);
				}
				else
				{
					bool flag6 = winguild.guildid == XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).BasicData.uid;
					if (flag6)
					{
						XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnAllFightEnd Guild Win", null, null, null, null, null, XDebugColor.XDebug_None);
						switch (data.wintype)
						{
						case GMF_FINAL_WIN_TYPE.GMF_FWY_NORMAL:
							DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetGuildResult("");
							break;
						case GMF_FINAL_WIN_TYPE.GMF_FWY_OPNONE:
							guildResult = string.Format(XStringDefineProxy.GetString("GUILD_ARENA_QUITE"), loseguild.guildname);
							DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetGuildResult(guildResult);
							break;
						case GMF_FINAL_WIN_TYPE.GMF_FWY_RANK:
							DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetGuildResult(XStringDefineProxy.GetString("GUILD_ARENA_WIN_GUILDALL_RANK"));
							break;
						}
					}
					else
					{
						bool flag7 = loseguild.guildid == XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID).BasicData.uid;
						if (flag7)
						{
							XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnAllFightEnd Guild Failed", null, null, null, null, null, XDebugColor.XDebug_None);
							switch (data.wintype)
							{
							case GMF_FINAL_WIN_TYPE.GMF_FWY_NORMAL:
								DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetGuildResult("");
								break;
							case GMF_FINAL_WIN_TYPE.GMF_FWY_OPNONE:
								guildResult = string.Format(XStringDefineProxy.GetString("GUILD_ARENA_QUITE"), loseguild.guildname);
								DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetGuildResult(guildResult);
								break;
							case GMF_FINAL_WIN_TYPE.GMF_FWY_RANK:
								DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetGuildResult(XStringDefineProxy.GetString("GUILD_ARENA_WIN_GUILDALL_RANK"));
								break;
							}
						}
						else
						{
							XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnAllFightEnd winguildid Observer", null, null, null, null, null, XDebugColor.XDebug_None);
						}
					}
				}
			}
		}

		// Token: 0x06008DED RID: 36333 RVA: 0x00138C3C File Offset: 0x00136E3C
		public void OnGmfJoinBattle(GmfJoinBattleArg oRes)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.GmfJoinBattleArg ", oRes.leftTime.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x06008DEE RID: 36334 RVA: 0x00138C6D File Offset: 0x00136E6D
		public void GetJoinBattleRes()
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.GetJoinBattleRes ", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x06008DEF RID: 36335 RVA: 0x00138C88 File Offset: 0x00136E88
		public void OnWaitOtherLoad(GmfWaitOtherArg oRes)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnWaitOtherLoad ", oRes.lefttime.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x06008DF0 RID: 36336 RVA: 0x00138CBC File Offset: 0x00136EBC
		public void OnWaitFightBegin(GmfWaitFightArg oRes)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnWaitFightBegin ", oRes.lefttime.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x06008DF1 RID: 36337 RVA: 0x00138CF0 File Offset: 0x00136EF0
		public void ReadyReq(ulong roleid, GMFReadyType type)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.ReadyReq ", type.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_GmfReadyReq rpcC2G_GmfReadyReq = new RpcC2G_GmfReadyReq();
			rpcC2G_GmfReadyReq.oArg.roleid = roleid;
			rpcC2G_GmfReadyReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GmfReadyReq);
		}

		// Token: 0x06008DF2 RID: 36338 RVA: 0x00138D4C File Offset: 0x00136F4C
		public void OnReadyReq(GmfReadyRes oRes)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnReadyReq ", oRes.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = oRes.errcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errcode, "fece00");
			}
			else
			{
				bool flag2 = this.CurView.IsVisible();
				if (flag2)
				{
					this.CurView.ReFreshGroup();
				}
			}
		}

		// Token: 0x06008DF3 RID: 36339 RVA: 0x00138DB8 File Offset: 0x00136FB8
		public void InspireReq()
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.InspireReq ", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_InspireReq rpc = new RpcC2G_InspireReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008DF4 RID: 36340 RVA: 0x00138DF0 File Offset: 0x00136FF0
		private void InspireUpdate(float detailTime)
		{
			bool flag = this.m_InspireCDTime > 0.0;
			if (flag)
			{
				this.m_InspireCDTime -= (double)detailTime;
			}
			else
			{
				this.m_InspireCDTime = 0.0;
			}
		}

		// Token: 0x06008DF5 RID: 36341 RVA: 0x00138E34 File Offset: 0x00137034
		public void OnInspireReq(InspireRes oRes)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnInspireReq ", oRes.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				XSingleton<XDebug>.singleton.AddGreenLog("XMainClient.XGuildArenaBattleDocument.Inspire.Cooldowntime:", oRes.cooldowntime.ToString(), null, null, null, null);
				this.m_InspireCDTime = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GMFInspireCoolDown"));
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILDARENA_INSPIRE_NOTICE"), "fece00");
				bool flag2 = this.CurView.IsLoaded() && this.CurView.IsVisible();
				if (flag2)
				{
					this.CurView.RefreshInspire();
				}
			}
		}

		// Token: 0x06008DF6 RID: 36342 RVA: 0x00138F08 File Offset: 0x00137108
		public void OnBattleState(GmfBatlleStatePara Data)
		{
			XSingleton<XDebug>.singleton.AddLog("XMainClient.XGuildArenaBattleDocument.OnBattleState ", Data.state.ToString(), " ", Data.lefttime.ToString(), null, null, XDebugColor.XDebug_None);
			switch (Data.state)
			{
			case GmfBattleState.GMF_BS_WAIT:
			{
				this.mArenaSection = XGuildArenaBattleDocument.GuildArenaSection.Prepare;
				bool flag = DlgBase<GuildArenaDuelRoundResultDlg, GuildArenaDuelRoundResultBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<GuildArenaDuelRoundResultDlg, GuildArenaDuelRoundResultBehaviour>.singleton.ReturnHall();
				}
				DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetVisible(false, true);
				bool flag2 = !this.CurView.IsVisible();
				if (flag2)
				{
					this.CurView.SetVisible(true, true);
				}
				else
				{
					this.CurView.RefreshSection();
				}
				this.CurView.RefreahCountTime(Data.lefttime);
				break;
			}
			case GmfBattleState.GMF_BS_FIGHT:
			{
				this.mArenaSection = XGuildArenaBattleDocument.GuildArenaSection.Battle;
				DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetVisible(false, true);
				bool flag3 = !this.CurView.IsVisible();
				if (flag3)
				{
					this.CurView.SetVisible(true, true);
				}
				else
				{
					this.CurView.RefreshSection();
				}
				this.CurView.RefreahCountTime(Data.lefttime);
				break;
			}
			case GmfBattleState.GMF_BS_RESULT:
			{
				this.CurView.SetVisible(false, true);
				bool flag4 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GMF;
				if (flag4)
				{
					this.mArenaSection = XGuildArenaBattleDocument.GuildArenaSection.Result;
					DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.SetVisible(true, true);
					DlgBase<GuildArenaDefeatDlg, GuildArenaDefeatBehaviour>.singleton.RefreahCountTime(Data.lefttime, false);
				}
				else
				{
					bool flag5 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GPR;
					if (flag5)
					{
						this.mArenaSection = XGuildArenaBattleDocument.GuildArenaSection.Prepare;
					}
				}
				break;
			}
			case GmfBattleState.GMF_BS_NONE:
				XSingleton<XDebug>.singleton.AddErrorLog("XMainClient.XGuildArenaBattleDocument.OnInspireReq ", Data.state.ToString(), " ", Data.lefttime.ToString(), null, null);
				break;
			}
		}

		// Token: 0x06008DF7 RID: 36343 RVA: 0x001390F0 File Offset: 0x001372F0
		public void OnBekicked(GmfKickRes res)
		{
			string text = string.Format(XSingleton<XStringTable>.singleton.GetString("GUILD_ARENA_BEKICKED"), res.kickname);
			XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
			bool flag = res.cooldowntime > 0.01f;
			if (flag)
			{
				this.bCantUpForKicked = true;
				bool flag2 = this._kicked_token > 0U;
				if (flag2)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._kicked_token);
				}
				this._kicked_token = XSingleton<XTimerMgr>.singleton.SetTimer(res.cooldowntime, new XTimerMgr.ElapsedEventHandler(this.OnBekickedCallback), null);
			}
			bool flag3 = this.CurView.IsLoaded();
			if (flag3)
			{
				this.CurView.UpdateDownUp();
			}
		}

		// Token: 0x06008DF8 RID: 36344 RVA: 0x001391A4 File Offset: 0x001373A4
		private void OnBekickedCallback(object o)
		{
			this.bCantUpForKicked = false;
			bool flag = this.CurView.IsLoaded();
			if (flag)
			{
				this.CurView.UpdateDownUp();
			}
		}

		// Token: 0x06008DF9 RID: 36345 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void ChangeSpectator(XRole role)
		{
		}

		// Token: 0x06008DFA RID: 36346 RVA: 0x001391D4 File Offset: 0x001373D4
		private void ConvertSceneTypeToPattern(SceneType type, ref GuildArenaBattlePattern pattern)
		{
			if (type != SceneType.SCENE_GMF)
			{
				if (type != SceneType.SCENE_GPR)
				{
					if (type == SceneType.SCENE_GCF)
					{
						pattern = GuildArenaBattlePattern.GCF;
					}
				}
				else
				{
					pattern = GuildArenaBattlePattern.GPR;
				}
			}
			else
			{
				pattern = GuildArenaBattlePattern.GMF;
			}
		}

		// Token: 0x06008DFB RID: 36347 RVA: 0x00139208 File Offset: 0x00137408
		private void EnterGVG()
		{
			this.ConvertSceneTypeToPattern(XSingleton<XScene>.singleton.SceneType, ref this.Pattern);
			this.CurView.OnEnterSceneFinally();
			this.bCantUpForKicked = false;
			bool flag = this.fxEncourageButton == null;
			if (flag)
			{
				this.fxEncourageButton = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_Encourage", null, true);
			}
			bool flag2 = this.fxEncourageProgressNum == null;
			if (flag2)
			{
				this.fxEncourageProgressNum = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_Encourage_Num", null, true);
			}
			bool flag3 = this.fxEncourageProgressAdd == null;
			if (flag3)
			{
				this.fxEncourageProgressAdd = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_Encourage_Add", null, true);
			}
			bool flag4 = this.mGmfRoleDatas != null;
			if (flag4)
			{
				this.SpectateSpecial(this.mGmfRoleDatas);
			}
		}

		// Token: 0x06008DFC RID: 36348 RVA: 0x001392C8 File Offset: 0x001374C8
		private void LeaveGVG()
		{
			bool flag = this.fxEncourageButton != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.fxEncourageButton, true);
				this.fxEncourageButton = null;
			}
			bool flag2 = this.fxEncourageProgressNum != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.fxEncourageProgressNum, true);
				this.fxEncourageProgressNum = null;
			}
			bool flag3 = this.fxEncourageProgressAdd != null;
			if (flag3)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.fxEncourageProgressAdd, true);
				this.fxEncourageProgressAdd = null;
			}
		}

		// Token: 0x06008DFD RID: 36349 RVA: 0x00139350 File Offset: 0x00137550
		public void ReceiveDuelRoundResult(GprOneBattleEnd res)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("XMainClient.XGuildArenaBattleDocument.ReceiveDuelRoundResult", null, null, null, null, null);
			bool flag = !this.IsGPR() && !this.IsGCF();
			if (!flag)
			{
				bool flag2 = DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
				}
				ulong myGuildID = this.GetMyGuildID();
				bool cross = this.IsGCF();
				bool flag3 = res.winguild.guildid == myGuildID;
				if (flag3)
				{
					this.InBattleGroup = true;
					this.BlueDuelResult.Setup(res.winguild, res.winrolecombat, true, cross);
					this.RedDuelResult.Setup(res.loseguild, res.loserolecombat, false, cross);
				}
				else
				{
					bool flag4 = res.loseguild.guildid == myGuildID;
					if (flag4)
					{
						this.InBattleGroup = true;
						this.BlueDuelResult.Setup(res.loseguild, res.loserolecombat, false, cross);
						this.RedDuelResult.Setup(res.winguild, res.winrolecombat, true, cross);
					}
					else
					{
						this.InBattleGroup = false;
						this.BlueDuelResult.Setup(res.winguild, res.winrolecombat, true, cross);
						this.RedDuelResult.Setup(res.loseguild, res.loserolecombat, false, cross);
					}
				}
				DlgBase<GuildArenaDuelRoundResultDlg, GuildArenaDuelRoundResultBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x06008DFE RID: 36350 RVA: 0x001394AC File Offset: 0x001376AC
		public void ReceiveDuelFinalResult(GprAllFightEnd res)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("XMainClient.XGuildArenaBattleDocument.ReceiveDuelFinalResult", null, null, null, null, null);
			bool flag = !this.IsGPR() && !this.IsGCF();
			if (!flag)
			{
				bool flag2 = DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
				}
				ulong myGuildID = this.GetMyGuildID();
				bool cross = this.IsGCF();
				bool flag3 = res.winguild.guildid == myGuildID;
				if (flag3)
				{
					this.BlueDuelResult.Setup(res.winguild, res.winscore, true, cross);
					this.RedDuelResult.Setup(res.loseguild, res.losescore, false, cross);
				}
				else
				{
					bool flag4 = res.loseguild.guildid == myGuildID;
					if (flag4)
					{
						this.BlueDuelResult.Setup(res.loseguild, res.losescore, false, cross);
						this.RedDuelResult.Setup(res.winguild, res.winscore, true, cross);
					}
					else
					{
						this.BlueDuelResult.Setup(res.winguild, res.winscore, true, cross);
						this.RedDuelResult.Setup(res.loseguild, res.losescore, false, cross);
					}
				}
				DlgBase<GuildArenaDuelFinalResultDlg, GuildArenaDuelFinalResultBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x06008DFF RID: 36351 RVA: 0x001395F3 File Offset: 0x001377F3
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnActionEvent));
			base.RegisterEvent(XEventDefine.XEvent_FightGroupChanged, new XComponent.XEventHandler(this.OnFightGroupChanged));
		}

		// Token: 0x06008E00 RID: 36352 RVA: 0x0013962C File Offset: 0x0013782C
		private bool OnFightGroupChanged(XEventArgs e)
		{
			bool flag = !this.IsGPR() && !this.IsGCF();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XFightGroupChangedArgs xfightGroupChangedArgs = e as XFightGroupChangedArgs;
				bool flag2 = xfightGroupChangedArgs == null || xfightGroupChangedArgs.targetEntity == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					BattleIndicateHandler battleIndicateHandler = null;
					XSingleton<XDebug>.singleton.AddGreenLog("OnFightGroupChanged", null, null, null, null, null);
					bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
					if (bSpectator)
					{
						bool flag3 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
						if (flag3)
						{
							battleIndicateHandler = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler;
						}
					}
					else
					{
						bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
						if (flag4)
						{
							battleIndicateHandler = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler;
						}
					}
					bool flag5 = battleIndicateHandler == null;
					if (flag5)
					{
						result = true;
					}
					else
					{
						bool isPlayer = xfightGroupChangedArgs.targetEntity.IsPlayer;
						if (isPlayer)
						{
							List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
							int i = 0;
							int count = all.Count;
							while (i < count)
							{
								bool isPlayer2 = all[i].IsPlayer;
								if (!isPlayer2)
								{
									this.UpdateIndicateHandle(battleIndicateHandler, all[i]);
								}
								i++;
							}
						}
						else
						{
							this.UpdateIndicateHandle(battleIndicateHandler, xfightGroupChangedArgs.targetEntity);
						}
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06008E01 RID: 36353 RVA: 0x0013976C File Offset: 0x0013796C
		private void UpdateIndicateHandle(BattleIndicateHandler handler, XEntity entity)
		{
			handler.MiniMapDel(entity);
			handler.MiniMapAdd(entity);
		}

		// Token: 0x06008E02 RID: 36354 RVA: 0x00139780 File Offset: 0x00137980
		private bool OnActionEvent(XEventArgs arg)
		{
			XRealDeadEventArgs xrealDeadEventArgs = arg as XRealDeadEventArgs;
			bool flag = !xrealDeadEventArgs.TheDead.IsPlayer;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.IsGPR();
				int @int;
				if (flag2)
				{
					@int = XSingleton<XGlobalConfig>.singleton.GetInt("GPRReviveTime");
				}
				else
				{
					bool flag3 = this.IsGCF();
					if (!flag3)
					{
						return false;
					}
					@int = XSingleton<XGlobalConfig>.singleton.GetInt("GPCFReviveTime");
				}
				bool flag4 = this.CurView.IsVisible();
				if (flag4)
				{
					this.CurView.SetResurgence(@int);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06008E03 RID: 36355 RVA: 0x00139810 File Offset: 0x00137A10
		public void ReceiveBattleSkill(PvpBattleKill battleSkillInfo)
		{
			bool flag = !this.CurView.IsVisible();
			if (!flag)
			{
				GVGBattleSkill gvgbattleSkill = new GVGBattleSkill();
				gvgbattleSkill.killerID = battleSkillInfo.killID;
				gvgbattleSkill.deadID = battleSkillInfo.deadID;
				gvgbattleSkill.contiKillCount = battleSkillInfo.contiKillCount;
				bool killerPosition = false;
				bool flag2 = this.TryGetBattleName(battleSkillInfo.killID, out gvgbattleSkill.killerName, out killerPosition);
				if (flag2)
				{
					gvgbattleSkill.killerPosition = killerPosition;
				}
				this.TryGetBattleName(battleSkillInfo.deadID, out gvgbattleSkill.deadName, out killerPosition);
				DlgBase<BattleContiDlg, BattleContiBehaviour>.singleton.AddBattleSkill(gvgbattleSkill);
				XSingleton<XDebug>.singleton.AddGreenLog(string.Format("ReceiveBattleSkill:{0} --- ,{1} ,.... {2}", gvgbattleSkill.killerName, gvgbattleSkill.deadName, gvgbattleSkill.contiKillCount), null, null, null, null, null);
			}
		}

		// Token: 0x06008E04 RID: 36356 RVA: 0x001398D4 File Offset: 0x00137AD4
		private bool TryGetBattleName(ulong roleID, out string targetName, out bool position)
		{
			targetName = string.Empty;
			position = false;
			GmfRole gmfRole = null;
			bool flag = this._redInfo.TryGetMember(roleID, out gmfRole);
			bool result;
			if (flag)
			{
				targetName = gmfRole.rolename;
				position = true;
				result = true;
			}
			else
			{
				bool flag2 = this._blueInfo.TryGetMember(roleID, out gmfRole);
				if (flag2)
				{
					targetName = gmfRole.rolename;
					position = false;
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06008E05 RID: 36357 RVA: 0x00139938 File Offset: 0x00137B38
		public bool IsGPR()
		{
			return XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GPR;
		}

		// Token: 0x06008E06 RID: 36358 RVA: 0x00139958 File Offset: 0x00137B58
		public bool IsGMF()
		{
			return XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GMF;
		}

		// Token: 0x06008E07 RID: 36359 RVA: 0x00139978 File Offset: 0x00137B78
		public bool IsGCF()
		{
			return XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GCF;
		}

		// Token: 0x06008E08 RID: 36360 RVA: 0x00139998 File Offset: 0x00137B98
		public void NotifyVSPayRevive(VsPayRevivePara para)
		{
			this.ReviveItemID = para.itemid;
			this.ReviveItemNumber = para.itemcount;
		}

		// Token: 0x06008E09 RID: 36361 RVA: 0x001399B4 File Offset: 0x00137BB4
		public void SendVSPayRevive()
		{
			bool flag = this.ReviveItemID > 0U;
			if (flag)
			{
				ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)this.ReviveItemID);
				bool flag2 = itemCount >= (ulong)this.ReviveItemNumber;
				if (flag2)
				{
					RpcC2G_VsPayReviveReq rpc = new RpcC2G_VsPayReviveReq();
					XSingleton<XClientNetwork>.singleton.Send(rpc);
				}
				else
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.ReviveItemID);
					bool flag3 = itemConf != null;
					if (flag3)
					{
						UiUtility singleton = XSingleton<UiUtility>.singleton;
						string key = "FASHION_HAIR_COLORING";
						object[] itemName = itemConf.ItemName;
						singleton.ShowSystemTip(XStringDefineProxy.GetString(key, itemName), "fece00");
					}
				}
			}
		}

		// Token: 0x06008E0A RID: 36362 RVA: 0x00139A48 File Offset: 0x00137C48
		public void ReceiveVSPayRevive(VsPayRevivePara oArg, VsPayReviveRes oRes)
		{
			bool flag = oRes.ret > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ret, "fece00");
			}
			bool flag2 = this.CurView.IsVisible();
			if (flag2)
			{
				this.CurView.SetResurgence(0);
			}
		}

		// Token: 0x04002E25 RID: 11813
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildArenaBattleDocument");

		// Token: 0x04002E26 RID: 11814
		private GVGBattleInfo _blueInfo = new GVGBattleInfo();

		// Token: 0x04002E27 RID: 11815
		private GVGBattleInfo _redInfo = new GVGBattleInfo();

		// Token: 0x04002E28 RID: 11816
		public double m_InspireCDTime = 0.0;

		// Token: 0x04002E29 RID: 11817
		public uint ReviveItemID = 0U;

		// Token: 0x04002E2A RID: 11818
		public uint ReviveItemNumber = 0U;

		// Token: 0x04002E2B RID: 11819
		public GuildArenaBattlePattern Pattern = GuildArenaBattlePattern.GPR;

		// Token: 0x04002E2C RID: 11820
		public XGuildArenaBattleDocument.ReadyType MyReadyType = XGuildArenaBattleDocument.ReadyType.Observer;

		// Token: 0x04002E2D RID: 11821
		public GuildMatchFightState MyFightState = GuildMatchFightState.GUILD_MF_NONE;

		// Token: 0x04002E2E RID: 11822
		public GmfRoleDatas mGmfRoleDatas = null;

		// Token: 0x04002E2F RID: 11823
		public int GMFGroupBlueMatchPoint = 0;

		// Token: 0x04002E30 RID: 11824
		public int GMFGroupRedMatchPoint = 0;

		// Token: 0x04002E31 RID: 11825
		public XGuildArenaBattleDocument.BattleEndData blueBattleEndData = new XGuildArenaBattleDocument.BattleEndData();

		// Token: 0x04002E32 RID: 11826
		public XGuildArenaBattleDocument.BattleEndData redBattleEndData = new XGuildArenaBattleDocument.BattleEndData();

		// Token: 0x04002E33 RID: 11827
		public XGuildArenaBattleDocument.GuildArenaSection mArenaSection;

		// Token: 0x04002E34 RID: 11828
		public GVGCombatInfo blueCombatInfo = new GVGCombatInfo();

		// Token: 0x04002E35 RID: 11829
		public GVGCombatInfo redCombatInfo = new GVGCombatInfo();

		// Token: 0x04002E36 RID: 11830
		public XGuildArenaBattleDocument.BattleEndData blueAllFightEnd = new XGuildArenaBattleDocument.BattleEndData();

		// Token: 0x04002E37 RID: 11831
		public XGuildArenaBattleDocument.BattleEndData redAllFightEnd = new XGuildArenaBattleDocument.BattleEndData();

		// Token: 0x04002E38 RID: 11832
		public uint _kicked_token = 0U;

		// Token: 0x04002E39 RID: 11833
		public bool bCantUpForKicked = false;

		// Token: 0x04002E3A RID: 11834
		protected internal XFx fxEncourageButton;

		// Token: 0x04002E3B RID: 11835
		protected internal XFx fxEncourageProgressNum;

		// Token: 0x04002E3C RID: 11836
		protected internal XFx fxEncourageProgressAdd;

		// Token: 0x04002E3D RID: 11837
		public GVGDuelResult BlueDuelResult = new GVGDuelResult();

		// Token: 0x04002E3E RID: 11838
		public GVGDuelResult RedDuelResult = new GVGDuelResult();

		// Token: 0x04002E3F RID: 11839
		public uint Round = 0U;

		// Token: 0x04002E40 RID: 11840
		public bool InBattleGroup = false;

		// Token: 0x0200195D RID: 6493
		public enum GuildArenaSection
		{
			// Token: 0x04007DE8 RID: 32232
			Prepare,
			// Token: 0x04007DE9 RID: 32233
			Battle,
			// Token: 0x04007DEA RID: 32234
			Result
		}

		// Token: 0x0200195E RID: 6494
		public enum ReadyType
		{
			// Token: 0x04007DEC RID: 32236
			Ready,
			// Token: 0x04007DED RID: 32237
			NoReady,
			// Token: 0x04007DEE RID: 32238
			Observer
		}

		// Token: 0x0200195F RID: 6495
		public class BattleEndData
		{
			// Token: 0x04007DEF RID: 32239
			public bool isWin = true;

			// Token: 0x04007DF0 RID: 32240
			public GmfRoleBrief Role = null;

			// Token: 0x04007DF1 RID: 32241
			public GmfGuildBrief Guild = null;
		}
	}
}
