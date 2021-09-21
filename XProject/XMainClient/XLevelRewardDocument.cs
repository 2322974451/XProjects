using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009A5 RID: 2469
	internal class XLevelRewardDocument : XDocComponent
	{
		// Token: 0x17002D01 RID: 11521
		// (get) Token: 0x060094D1 RID: 38097 RVA: 0x00160970 File Offset: 0x0015EB70
		public override uint ID
		{
			get
			{
				return XLevelRewardDocument.uuID;
			}
		}

		// Token: 0x17002D02 RID: 11522
		// (get) Token: 0x060094D2 RID: 38098 RVA: 0x00160988 File Offset: 0x0015EB88
		// (set) Token: 0x060094D3 RID: 38099 RVA: 0x001609A0 File Offset: 0x0015EBA0
		public bool RequestServer
		{
			get
			{
				return this._requestServer;
			}
			set
			{
				this._requestServer = value;
			}
		}

		// Token: 0x17002D03 RID: 11523
		// (get) Token: 0x060094D4 RID: 38100 RVA: 0x001609AC File Offset: 0x0015EBAC
		public uint Rank
		{
			get
			{
				return this.GetRankByBit(this._rank);
			}
		}

		// Token: 0x17002D04 RID: 11524
		// (get) Token: 0x060094D5 RID: 38101 RVA: 0x001609CA File Offset: 0x0015EBCA
		// (set) Token: 0x060094D6 RID: 38102 RVA: 0x001609D2 File Offset: 0x0015EBD2
		public uint FirstStars { get; set; }

		// Token: 0x17002D05 RID: 11525
		// (get) Token: 0x060094D7 RID: 38103 RVA: 0x001609DC File Offset: 0x0015EBDC
		public SceneType CurrentStage
		{
			get
			{
				return XSingleton<XScene>.singleton.SceneType;
			}
		}

		// Token: 0x17002D06 RID: 11526
		// (get) Token: 0x060094D8 RID: 38104 RVA: 0x001609F8 File Offset: 0x0015EBF8
		public uint CurrentScene
		{
			get
			{
				return XSingleton<XScene>.singleton.SceneID;
			}
		}

		// Token: 0x17002D07 RID: 11527
		// (get) Token: 0x060094D9 RID: 38105 RVA: 0x00160A14 File Offset: 0x0015EC14
		public SceneTable.RowData CurrentSceneData
		{
			get
			{
				return this._current_scene_data;
			}
		}

		// Token: 0x17002D08 RID: 11528
		// (get) Token: 0x060094DA RID: 38106 RVA: 0x00160A2C File Offset: 0x0015EC2C
		// (set) Token: 0x060094DB RID: 38107 RVA: 0x00160A34 File Offset: 0x0015EC34
		public int LevelFinishTime { get; set; }

		// Token: 0x17002D09 RID: 11529
		// (get) Token: 0x060094DC RID: 38108 RVA: 0x00160A3D File Offset: 0x0015EC3D
		// (set) Token: 0x060094DD RID: 38109 RVA: 0x00160A45 File Offset: 0x0015EC45
		public uint LevelFinishHp { get; set; }

		// Token: 0x17002D0A RID: 11530
		// (get) Token: 0x060094DE RID: 38110 RVA: 0x00160A50 File Offset: 0x0015EC50
		public bool CanPeerBox
		{
			get
			{
				bool flag = this.CurrentSceneData == null;
				return !flag && this.CurrentSceneData.PeerBox[0] > 0U;
			}
		}

		// Token: 0x17002D0B RID: 11531
		// (get) Token: 0x060094DF RID: 38111 RVA: 0x00160A88 File Offset: 0x0015EC88
		public uint PeerBoxCost
		{
			get
			{
				bool flag = this.CurrentSceneData == null;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					result = this.CurrentSceneData.PeerBox[1];
				}
				return result;
			}
		}

		// Token: 0x17002D0C RID: 11532
		// (get) Token: 0x060094E0 RID: 38112 RVA: 0x00160ABC File Offset: 0x0015ECBC
		// (set) Token: 0x060094E1 RID: 38113 RVA: 0x00160AC4 File Offset: 0x0015ECC4
		public bool IsArenaMiss { get; set; }

		// Token: 0x17002D0D RID: 11533
		// (get) Token: 0x060094E2 RID: 38114 RVA: 0x00160ACD File Offset: 0x0015ECCD
		// (set) Token: 0x060094E3 RID: 38115 RVA: 0x00160AD5 File Offset: 0x0015ECD5
		public int ArenaRankUp { get; set; }

		// Token: 0x17002D0E RID: 11534
		// (get) Token: 0x060094E4 RID: 38116 RVA: 0x00160ADE File Offset: 0x0015ECDE
		// (set) Token: 0x060094E5 RID: 38117 RVA: 0x00160AE6 File Offset: 0x0015ECE6
		public uint ArenaGemUp { get; set; }

		// Token: 0x17002D0F RID: 11535
		// (get) Token: 0x060094E6 RID: 38118 RVA: 0x00160AEF File Offset: 0x0015ECEF
		// (set) Token: 0x060094E7 RID: 38119 RVA: 0x00160AF7 File Offset: 0x0015ECF7
		public int TotalDamage { get; set; }

		// Token: 0x17002D10 RID: 11536
		// (get) Token: 0x060094E8 RID: 38120 RVA: 0x00160B00 File Offset: 0x0015ED00
		// (set) Token: 0x060094E9 RID: 38121 RVA: 0x00160B08 File Offset: 0x0015ED08
		public bool IsSelect { get; set; }

		// Token: 0x17002D11 RID: 11537
		// (get) Token: 0x060094EA RID: 38122 RVA: 0x00160B11 File Offset: 0x0015ED11
		// (set) Token: 0x060094EB RID: 38123 RVA: 0x00160B19 File Offset: 0x0015ED19
		public int SelectLeftTime { get; set; }

		// Token: 0x17002D12 RID: 11538
		// (get) Token: 0x060094EC RID: 38124 RVA: 0x00160B22 File Offset: 0x0015ED22
		// (set) Token: 0x060094ED RID: 38125 RVA: 0x00160B2A File Offset: 0x0015ED2A
		public bool IsWin { get; set; }

		// Token: 0x17002D13 RID: 11539
		// (get) Token: 0x060094EE RID: 38126 RVA: 0x00160B33 File Offset: 0x0015ED33
		// (set) Token: 0x060094EF RID: 38127 RVA: 0x00160B3B File Offset: 0x0015ED3B
		public bool IsStageFailed { get; set; }

		// Token: 0x17002D14 RID: 11540
		// (get) Token: 0x060094F0 RID: 38128 RVA: 0x00160B44 File Offset: 0x0015ED44
		// (set) Token: 0x060094F1 RID: 38129 RVA: 0x00160B4C File Offset: 0x0015ED4C
		public int PickUpTotalTime { get; set; }

		// Token: 0x17002D15 RID: 11541
		// (get) Token: 0x060094F2 RID: 38130 RVA: 0x00160B55 File Offset: 0x0015ED55
		// (set) Token: 0x060094F3 RID: 38131 RVA: 0x00160B5D File Offset: 0x0015ED5D
		public int RandomTaskExp { get; set; }

		// Token: 0x17002D16 RID: 11542
		// (get) Token: 0x060094F4 RID: 38132 RVA: 0x00160B66 File Offset: 0x0015ED66
		// (set) Token: 0x060094F5 RID: 38133 RVA: 0x00160B6E File Offset: 0x0015ED6E
		public int RandomTaskMoney { get; set; }

		// Token: 0x17002D17 RID: 11543
		// (get) Token: 0x060094F6 RID: 38134 RVA: 0x00160B77 File Offset: 0x0015ED77
		// (set) Token: 0x060094F7 RID: 38135 RVA: 0x00160B7F File Offset: 0x0015ED7F
		public int RandomTask { get; set; }

		// Token: 0x17002D18 RID: 11544
		// (get) Token: 0x060094F8 RID: 38136 RVA: 0x00160B88 File Offset: 0x0015ED88
		// (set) Token: 0x060094F9 RID: 38137 RVA: 0x00160B90 File Offset: 0x0015ED90
		public int StartLevel { get; set; }

		// Token: 0x17002D19 RID: 11545
		// (get) Token: 0x060094FA RID: 38138 RVA: 0x00160B99 File Offset: 0x0015ED99
		// (set) Token: 0x060094FB RID: 38139 RVA: 0x00160BA1 File Offset: 0x0015EDA1
		public float StartPercent { get; set; }

		// Token: 0x17002D1A RID: 11546
		// (get) Token: 0x060094FC RID: 38140 RVA: 0x00160BAA File Offset: 0x0015EDAA
		// (set) Token: 0x060094FD RID: 38141 RVA: 0x00160BB2 File Offset: 0x0015EDB2
		public float TotalExpPercent { get; set; }

		// Token: 0x17002D1B RID: 11547
		// (get) Token: 0x060094FE RID: 38142 RVA: 0x00160BBB File Offset: 0x0015EDBB
		// (set) Token: 0x060094FF RID: 38143 RVA: 0x00160BC3 File Offset: 0x0015EDC3
		public float CurrentExpPercent { get; set; }

		// Token: 0x17002D1C RID: 11548
		// (get) Token: 0x06009500 RID: 38144 RVA: 0x00160BCC File Offset: 0x0015EDCC
		// (set) Token: 0x06009501 RID: 38145 RVA: 0x00160BD4 File Offset: 0x0015EDD4
		public float GrowExpPercent { get; set; }

		// Token: 0x17002D1D RID: 11549
		// (get) Token: 0x06009502 RID: 38146 RVA: 0x00160BDD File Offset: 0x0015EDDD
		// (set) Token: 0x06009503 RID: 38147 RVA: 0x00160BE5 File Offset: 0x0015EDE5
		public float TotalExp { get; set; }

		// Token: 0x17002D1E RID: 11550
		// (get) Token: 0x06009504 RID: 38148 RVA: 0x00160BEE File Offset: 0x0015EDEE
		// (set) Token: 0x06009505 RID: 38149 RVA: 0x00160BF6 File Offset: 0x0015EDF6
		public int SmallMonsterRank { get; set; }

		// Token: 0x17002D1F RID: 11551
		// (get) Token: 0x06009506 RID: 38150 RVA: 0x00160BFF File Offset: 0x0015EDFF
		// (set) Token: 0x06009507 RID: 38151 RVA: 0x00160C07 File Offset: 0x0015EE07
		public bool BrokeRecords { get; set; }

		// Token: 0x17002D20 RID: 11552
		// (get) Token: 0x06009508 RID: 38152 RVA: 0x00160C10 File Offset: 0x0015EE10
		// (set) Token: 0x06009509 RID: 38153 RVA: 0x00160C18 File Offset: 0x0015EE18
		public bool RedSmallMonsterKilled { get; set; }

		// Token: 0x17002D21 RID: 11553
		// (get) Token: 0x0600950A RID: 38154 RVA: 0x00160C21 File Offset: 0x0015EE21
		// (set) Token: 0x0600950B RID: 38155 RVA: 0x00160C29 File Offset: 0x0015EE29
		public int TowerFloor { get; set; }

		// Token: 0x17002D22 RID: 11554
		// (get) Token: 0x0600950C RID: 38156 RVA: 0x00160C32 File Offset: 0x0015EE32
		// (set) Token: 0x0600950D RID: 38157 RVA: 0x00160C3A File Offset: 0x0015EE3A
		public bool IsEndLevel { get; set; }

		// Token: 0x17002D23 RID: 11555
		// (get) Token: 0x0600950E RID: 38158 RVA: 0x00160C43 File Offset: 0x0015EE43
		// (set) Token: 0x0600950F RID: 38159 RVA: 0x00160C4B File Offset: 0x0015EE4B
		public uint WatchCount { get; set; }

		// Token: 0x17002D24 RID: 11556
		// (get) Token: 0x06009510 RID: 38160 RVA: 0x00160C54 File Offset: 0x0015EE54
		// (set) Token: 0x06009511 RID: 38161 RVA: 0x00160C5C File Offset: 0x0015EE5C
		public uint LikeCount { get; set; }

		// Token: 0x06009512 RID: 38162 RVA: 0x00160C65 File Offset: 0x0015EE65
		public static void Execute(OnLoadedCallback callback = null)
		{
			XLevelRewardDocument.AsyncLoader.AddTask("Table/StageRank", XLevelRewardDocument.Table, false);
			XLevelRewardDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009513 RID: 38163 RVA: 0x00160C8C File Offset: 0x0015EE8C
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this.PvpBattleData.Init();
			this.InvFightBattleData.Init();
			this.SkyArenaBattleData.Init();
			this.AbyssPartyBattleData.Init();
			this.BigMeleeBattleData.Init();
			this.BattleFieldBattleData.Init();
			this.RaceBattleData.Init();
			this.GuildMineBattleData.Init();
			this.GerenalBattleData.Init();
			this.SelectChestFrameData.Init();
			this.DragonCrusadeDataWin.Init();
			this.QualifyingBattleData.Init();
			this.CustomBattleData.Init();
			this._current_scene_data = XSingleton<XSceneMgr>.singleton.GetSceneData(this.CurrentScene);
		}

		// Token: 0x06009514 RID: 38164 RVA: 0x00160D53 File Offset: 0x0015EF53
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this.DestroyFx(this.TheGoddessWinFx);
			this.TheGoddessWinFx = null;
		}

		// Token: 0x06009515 RID: 38165 RVA: 0x00160D74 File Offset: 0x0015EF74
		public void SendLeaveScene()
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CLICK_TOO_FAST"), "fece00");
			}
			else
			{
				this.LastLeaveSceneTime = Time.time;
				XSingleton<XScene>.singleton.ReqLeaveScene();
			}
		}

		// Token: 0x06009516 RID: 38166 RVA: 0x00160DCC File Offset: 0x0015EFCC
		public void SendSelectChest(uint index)
		{
			RpcC2G_SelectChestReward rpcC2G_SelectChestReward = new RpcC2G_SelectChestReward();
			rpcC2G_SelectChestReward.oArg.chestIdx = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SelectChestReward);
		}

		// Token: 0x06009517 RID: 38167 RVA: 0x00160DFC File Offset: 0x0015EFFC
		public void SendPeerChest(uint index)
		{
			RpcC2G_PeerBox rpcC2G_PeerBox = new RpcC2G_PeerBox();
			rpcC2G_PeerBox.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PeerBox);
		}

		// Token: 0x06009518 RID: 38168 RVA: 0x00160E2C File Offset: 0x0015F02C
		public void SetPeerChest(uint index, ItemBrief item, uint type)
		{
			this.SelectChestFrameData.Player.chestList[(int)index].itemID = (int)item.itemID;
			this.SelectChestFrameData.Player.chestList[(int)index].itemCount = (int)item.itemCount;
			this.SelectChestFrameData.Player.chestList[(int)index].isbind = item.isbind;
			this.SelectChestFrameData.Player.chestList[(int)index].chestType = (int)type;
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetPeerResult();
			}
		}

		// Token: 0x06009519 RID: 38169 RVA: 0x00160EDC File Offset: 0x0015F0DC
		public void SendQueryBoxs(bool force = false)
		{
			bool flag = !force && Time.time - this._last_query_box_time < 1f;
			if (!flag)
			{
				this._last_query_box_time = Time.time;
				RpcC2G_QueryBoxs rpc = new RpcC2G_QueryBoxs();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		// Token: 0x0600951A RID: 38170 RVA: 0x00160F28 File Offset: 0x0015F128
		public void SetSelectBoxLeftTime(uint leftTime)
		{
			this.SelectChestFrameData.SelectLeftTime = (int)leftTime;
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.RefreshSelectChestLeftTime();
			}
		}

		// Token: 0x0600951B RID: 38171 RVA: 0x00160F60 File Offset: 0x0015F160
		public void SetBoxsInfo(List<BoxInfos> boxs)
		{
			this.SetSelectBoxLeftTime(0U);
			for (int i = 0; i < boxs.Count; i++)
			{
				bool flag = boxs[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.SelectChestFrameData.Player.BoxID = (int)boxs[i].index;
					for (int j = 0; j < this.SelectChestFrameData.Player.chestList.Count; j++)
					{
						this.SelectChestFrameData.Player.chestList[j].itemID = (int)boxs[i].items[j].itemID;
						this.SelectChestFrameData.Player.chestList[j].itemCount = (int)boxs[i].items[j].itemCount;
						this.SelectChestFrameData.Player.chestList[j].isbind = boxs[i].items[j].isbind;
						this.SelectChestFrameData.Player.chestList[j].chestType = (int)boxs[i].type[j];
					}
				}
				else
				{
					for (int k = 0; k < this.SelectChestFrameData.Others.Count; k++)
					{
						bool flag2 = boxs[i].roleid == this.SelectChestFrameData.Others[k].uid;
						if (flag2)
						{
							XLevelRewardDocument.LevelRewardRoleData levelRewardRoleData = this.SelectChestFrameData.Others[k];
							levelRewardRoleData.BoxID = (int)boxs[i].index;
							for (int l = 0; l < this.SelectChestFrameData.Player.chestList.Count; l++)
							{
								levelRewardRoleData.chestList[l].itemID = (int)boxs[i].items[l].itemID;
								levelRewardRoleData.chestList[l].itemCount = (int)boxs[i].items[l].itemCount;
								levelRewardRoleData.chestList[l].isbind = boxs[i].items[l].isbind;
								levelRewardRoleData.chestList[l].chestType = (int)boxs[i].type[l];
							}
							this.SelectChestFrameData.Others[k] = levelRewardRoleData;
						}
					}
				}
			}
			bool flag3 = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag3)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowAllChest();
			}
		}

		// Token: 0x0600951C RID: 38172 RVA: 0x00161268 File Offset: 0x0015F468
		public void SendReturnWaitBattleField()
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (!flag)
			{
				this.LastLeaveSceneTime = Time.time;
				PtcC2M_GoBackReadySceneNtf proto = new PtcC2M_GoBackReadySceneNtf();
				XSingleton<XClientNetwork>.singleton.Send(proto);
			}
		}

		// Token: 0x0600951D RID: 38173 RVA: 0x001612AC File Offset: 0x0015F4AC
		public void ReEnterLevel()
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (!flag)
			{
				this.LastLeaveSceneTime = Time.time;
				PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
				ptcC2G_EnterSceneReq.Data.sceneID = this.CurrentScene;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
			}
		}

		// Token: 0x0600951E RID: 38174 RVA: 0x00161304 File Offset: 0x0015F504
		public void SendReEnterAbyssParty(uint ID)
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (!flag)
			{
				this.LastLeaveSceneTime = Time.time;
				bool flag2 = ID == 0U;
				if (flag2)
				{
					DlgBase<AbyssPartyEntranceView, AbyssPartyEntranceBehaviour>.singleton.OnJoinClicked(null);
				}
				else
				{
					XAbyssPartyDocument.Doc.AbyssPartyEnter((int)ID);
				}
			}
		}

		// Token: 0x0600951F RID: 38175 RVA: 0x00161358 File Offset: 0x0015F558
		public void SendReEnterRiskBattle()
		{
			bool flag = Time.time - this.LastLeaveSceneTime < 3f;
			if (!flag)
			{
				this.LastLeaveSceneTime = Time.time;
				RpcC2G_ReEnterRiskBattle rpc = new RpcC2G_ReEnterRiskBattle();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		// Token: 0x06009520 RID: 38176 RVA: 0x0016139C File Offset: 0x0015F59C
		public void SetBattleResult(List<uint> stars, uint money, List<ItemBrief> items, uint firstStars, List<ItemBrief> starsItems)
		{
			this.Stars.Clear();
			for (int i = 0; i < stars.Count; i++)
			{
				this.Stars.Add(stars[i]);
			}
			this.Items.Clear();
			for (int j = 0; j < items.Count; j++)
			{
				bool flag = false;
				for (int k = 0; k < this.Items.Count; k++)
				{
					bool flag2 = items[j].itemID == this.Items[k].itemID;
					if (flag2)
					{
						flag = true;
						this.Items[k].itemCount += items[j].itemCount;
						break;
					}
				}
				bool flag3 = !flag;
				if (flag3)
				{
					this.Items.Add(this.CopyItemBrief(items[j]));
				}
			}
			bool flag4 = money > 0U;
			if (flag4)
			{
				ItemBrief itemBrief = new ItemBrief
				{
					itemID = (uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD),
					itemCount = money
				};
				bool flag = false;
				for (int l = 0; l < this.Items.Count; l++)
				{
					bool flag5 = itemBrief.itemID == this.Items[l].itemID;
					if (flag5)
					{
						flag = true;
						this.Items[l].itemCount += itemBrief.itemCount;
						break;
					}
				}
				bool flag6 = !flag;
				if (flag6)
				{
					this.Items.Add(this.CopyItemBrief(itemBrief));
				}
			}
			this.FirstStars = firstStars;
			this.StarsItems.Clear();
			for (int m = 0; m < starsItems.Count; m++)
			{
				this.StarsItems.Add(this.CopyItemBrief(starsItems[m]));
			}
			this.MemberSelectChest.Clear();
			this.IsSelect = false;
			this.SelectLeftTime = XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishSelectChestTime");
		}

		// Token: 0x06009521 RID: 38177 RVA: 0x001615D4 File Offset: 0x0015F7D4
		public void SetQualifyingResult(PkResult data)
		{
			this.IsWin = (data.result == PkResultType.PkResult_Win);
			this.QualifyingBattleData.Init();
			this.QualifyingBattleData.QualifyingResult = data.result;
			this.QualifyingBattleData.QualifyingRankChange = data.rank;
			this.QualifyingBattleData.FirstRank = data.firstrank;
			this.QualifyingBattleData.QualifyingPointChange = data.winpoint;
			this.QualifyingBattleData.QualifyingHonorChange = data.honorpoint;
			this.QualifyingBattleData.QualifyingHonorItems = data.items;
			bool flag = data.dragoncount > 0U;
			if (flag)
			{
				ItemBrief itemBrief = new ItemBrief();
				itemBrief.itemID = 7U;
				itemBrief.itemCount = data.dragoncount;
				this.QualifyingBattleData.QualifyingHonorItems.Add(itemBrief);
			}
			this.QualifyingBattleData.myState = data.mystate;
			this.QualifyingBattleData.opState = data.opstate;
		}

		// Token: 0x06009522 RID: 38178 RVA: 0x001616C4 File Offset: 0x0015F8C4
		public void SetDamageRank(List<string> name, List<uint> damage)
		{
			this.Member.Clear();
			this.TotalDamage = 0;
			for (int i = 0; i < name.Count; i++)
			{
				XLevelRewardDocument.DamageRank item = new XLevelRewardDocument.DamageRank
				{
					Name = name[i],
					Damage = (int)damage[i]
				};
				this.Member.Add(item);
				this.TotalDamage += item.Damage;
			}
			this.TotalDamage = Math.Max(1, this.TotalDamage);
			this.Member.Sort(new Comparison<XLevelRewardDocument.DamageRank>(XLevelRewardDocument.DamageCompare));
		}

		// Token: 0x06009523 RID: 38179 RVA: 0x00161774 File Offset: 0x0015F974
		public void ShowBattleResultFrame()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(false);
			}
			bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisiblePure(false);
			}
			bool flag3 = DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.IsLoaded();
			if (flag3)
			{
				DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.SetVisiblePure(false);
			}
			bool isWin = this.IsWin;
			if (isWin)
			{
				XLevelFinishMgr.PlayVictory();
			}
			bool isEndLevel = this.IsEndLevel;
			if (isEndLevel)
			{
				this.DestroyFx(this.TheGoddessWinFx);
				this.TheGoddessWinFx = null;
				this.TheGoddessWinFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_TheGoddessWin", XSingleton<XGameUI>.singleton.UIRoot, Vector3.zero, Vector3.one, 1f, true, (float)XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishFxTime"), true);
				XSingleton<XTimerMgr>.singleton.SetTimer((float)XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishFxTime"), new XTimerMgr.ElapsedEventHandler(this.ShowLevelRewardUI), null);
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.ShowLevelRewardUI), null);
			}
		}

		// Token: 0x06009524 RID: 38180 RVA: 0x001618A2 File Offset: 0x0015FAA2
		public void ShowLevelReward()
		{
			this.ShowLevelRewardUI(null);
		}

		// Token: 0x06009525 RID: 38181 RVA: 0x001618B0 File Offset: 0x0015FAB0
		private void ShowLevelRewardUI(object o)
		{
			this.DestroyFx(this.TheGoddessWinFx);
			this.TheGoddessWinFx = null;
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (!bSpectator)
			{
				XSingleton<XVirtualTab>.singleton.Cancel();
				bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
				}
				SceneType currentStage = this.CurrentStage;
				switch (currentStage)
				{
				case SceneType.SCENE_BATTLE:
				case SceneType.SCENE_NEST:
				case (SceneType)4:
				case (SceneType)6:
				case SceneType.SCENE_WORLDBOSS:
				case (SceneType)8:
				case SceneType.SCENE_BOSSRUSH:
				case SceneType.SCENE_GUILD_HALL:
				case SceneType.SCENE_GUILD_BOSS:
				case SceneType.SCENE_ABYSSS:
				case (SceneType)14:
				case SceneType.SCENE_FAMILYGARDEN:
				case SceneType.SCENE_TOWER:
				case SceneType.SCENE_DRAGON:
				case SceneType.SCENE_GMF:
				case SceneType.SCENE_GODDESS:
				case SceneType.SCENE_ENDLESSABYSS:
					goto IL_2A9;
				case SceneType.SCENE_ARENA:
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Victory");
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_ARENA);
					goto IL_2CE;
				case SceneType.SCENE_PK:
					break;
				case SceneType.SCENE_PVP:
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/mapambience/PVP_score");
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_PVP);
					goto IL_2CE;
				case SceneType.SCENE_DRAGON_EXP:
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/guankashenli");
					DlgBase<DragonCrusadeGateWin, DragonCrusadeGateWinBehavior>.singleton.SetVisible(true, true);
					DlgBase<DragonCrusadeGateWin, DragonCrusadeGateWinBehavior>.singleton.Refresh();
					goto IL_2CE;
				case SceneType.SCENE_RISK:
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/guankashenli");
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_RISK);
					goto IL_2CE;
				default:
					switch (currentStage)
					{
					case SceneType.SCENE_WEEK_NEST:
					case SceneType.SCENE_VS_CHALLENGE:
					case SceneType.SCENE_HORSE:
					case SceneType.SCENE_HORSE_RACE:
					case SceneType.SCENE_CASTLE_WAIT:
					case SceneType.SCENE_CASTLE_FIGHT:
					case SceneType.SCENE_LEAGUE_BATTLE:
					case SceneType.SCENE_ACTIVITY_ONE:
					case SceneType.SCENE_ACTIVITY_TWO:
					case SceneType.SCENE_ACTIVITY_THREE:
					case SceneType.SCENE_ABYSS_PARTY:
						goto IL_2A9;
					case SceneType.SCENE_HEROBATTLE:
					case SceneType.SCENE_MOBA:
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(this.CurrentStage);
						goto IL_2CE;
					case SceneType.SCENE_INVFIGHT:
					{
						bool isWin = this.InvFightBattleData.isWin;
						if (isWin)
						{
							XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Victory");
						}
						else
						{
							XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Lose");
						}
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_INVFIGHT);
						goto IL_2CE;
					}
					case SceneType.SCENE_CUSTOMPK:
					case SceneType.SCENE_CUSTOMPKTWO:
						XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/mapambience/PVP_score");
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(this.CurrentStage);
						goto IL_2CE;
					case SceneType.SCENE_PKTWO:
						break;
					case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
					case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
					case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
					case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
					case SceneType.SCENE_WEEKEND4V4_HORSERACING:
					case SceneType.SCENE_WEEKEND4V4_DUCK:
						DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(this.CurrentStage);
						goto IL_2CE;
					default:
						if (currentStage != SceneType.SCENE_SURVIVE)
						{
							goto IL_2A9;
						}
						goto IL_2CE;
					}
					break;
				}
				bool flag2 = this.QualifyingBattleData.QualifyingResult == PkResultType.PkResult_Win;
				if (flag2)
				{
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Victory");
				}
				else
				{
					XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/PvP_Lose");
				}
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_PK);
				goto IL_2CE;
				IL_2A9:
				XSingleton<XAudioMgr>.singleton.PlayBGM("Audio/UI/guankashenli");
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(this.CurrentStage);
				IL_2CE:
				int sceneAutoLeaveTime = XSingleton<XSceneMgr>.singleton.GetSceneAutoLeaveTime(this.CurrentScene);
				bool flag3 = sceneAutoLeaveTime != 0;
				if (flag3)
				{
					this._autoReturnTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer((float)sceneAutoLeaveTime, new XTimerMgr.ElapsedEventHandler(this.AutoLeaveScene), null);
				}
			}
		}

		// Token: 0x06009526 RID: 38182 RVA: 0x00161BC8 File Offset: 0x0015FDC8
		public void ShowStageFailUI(object o)
		{
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (!bSpectator)
			{
				XSingleton<XVirtualTab>.singleton.Cancel();
				bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
				}
				SceneType currentStage = this.CurrentStage;
				if (currentStage != SceneType.SCENE_RISK)
				{
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowStageFailFrame(this.CurrentStage);
				}
				else
				{
					DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowStageFailFrame(SceneType.SCENE_RISK);
				}
			}
		}

		// Token: 0x06009527 RID: 38183 RVA: 0x00161C48 File Offset: 0x0015FE48
		private void AutoLeaveScene(object o)
		{
			bool flag = this.CurrentScene != XSingleton<XScene>.singleton.SceneID;
			if (!flag)
			{
				bool flag2 = this.CurrentStage == SceneType.SCENE_GODDESS || this.CurrentStage == SceneType.SCENE_ENDLESSABYSS;
				if (flag2)
				{
					XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
					bool flag3 = !specificDocument.bIsLeader;
					if (!flag3)
					{
						XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
						int num = 0;
						bool flag4 = this.CurrentStage == SceneType.SCENE_GODDESS;
						if (flag4)
						{
							num = specificDocument2.GetDayCount(TeamLevelType.TeamLevelGoddessTrial, null);
						}
						else
						{
							bool flag5 = this.CurrentStage == SceneType.SCENE_ENDLESSABYSS;
							if (flag5)
							{
								num = specificDocument2.GetDayCount(TeamLevelType.TeamLevelEndlessAbyss, null);
							}
						}
						bool flag6 = num - 1 <= 0;
						if (!flag6)
						{
							specificDocument.ReqTeamOp(TeamOperate.TEAM_BATTLE_CONTINUE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
						}
					}
				}
				else
				{
					this.SendLeaveScene();
				}
			}
		}

		// Token: 0x06009528 RID: 38184 RVA: 0x00161D1E File Offset: 0x0015FF1E
		public void ShowSelectChestFrame()
		{
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowSelectChestFrame();
		}

		// Token: 0x06009529 RID: 38185 RVA: 0x00161D2C File Offset: 0x0015FF2C
		public void ShowFirstPassShareView()
		{
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DungeonShareReward);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("ShowFirstPassShareView", null, null, null, null, null, XDebugColor.XDebug_None);
				XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
				bool flag2 = this.CurrentScene != 0U && this.CurrentScene == specificDocument.FirstPassSceneID;
				if (flag2)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this._autoReturnTimeToken);
					this._autoReturnTimeToken = 0U;
					XScreenShotShareDocument specificDocument2 = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
					XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.DungeonShare;
					specificDocument2.CurShareBgType = ShareBgType.DungeonType;
					DlgBase<DungeonShareView, DungeonShareBehavior>.singleton.SetVisibleWithAnimation(true, null);
				}
			}
		}

		// Token: 0x0600952A RID: 38186 RVA: 0x00161DD4 File Offset: 0x0015FFD4
		private static int DamageCompare(XLevelRewardDocument.DamageRank member1, XLevelRewardDocument.DamageRank member2)
		{
			return member2.Damage.CompareTo(member1.Damage);
		}

		// Token: 0x0600952B RID: 38187 RVA: 0x00161DFC File Offset: 0x0015FFFC
		public void SetPickItemList(List<ItemBrief> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				this.Items.Add(this.CopyItemBrief(items[i]));
			}
		}

		// Token: 0x0600952C RID: 38188 RVA: 0x00161E3C File Offset: 0x0016003C
		public void SetBattleResultData(NewBattleResult data)
		{
			this.IsWin = true;
			int index = 0;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					index = i;
					break;
				}
			}
			this.IsEndLevel = data.isFinalResult;
			StageRoleResult stageRoleResult = data.roleReward[index];
			bool flag2 = !stageRoleResult.ishelper;
			if (flag2)
			{
				XSingleton<XStageProgress>.singleton.SetRank((int)data.stageInfo.stageID, (int)stageRoleResult.stars);
			}
			this._rank = stageRoleResult.stars;
			this.SetBattleResult(this.GetStarsByBit(stageRoleResult.stars), stageRoleResult.money, stageRoleResult.items, stageRoleResult.firststars, stageRoleResult.starreward);
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				this.LevelFinishTime = (int)data.stageInfo.timespan;
			}
			bool flag3 = data.specialStage != null;
			if (flag3)
			{
				this.ArenaRankUp = (int)data.specialStage.arenaup;
				this.IsArenaMiss = data.specialStage.arenamissed;
			}
			this.ArenaGemUp = 0U;
			for (int j = 0; j < stageRoleResult.items.Count; j++)
			{
				bool flag4 = stageRoleResult.items[j].itemID == 7U;
				if (flag4)
				{
					this.ArenaGemUp = stageRoleResult.items[j].itemCount;
				}
			}
			this.IsStageFailed = data.stageInfo.isStageFailed;
			bool flag5 = stageRoleResult.pkresult != null;
			if (flag5)
			{
				this.SetQualifyingResult(stageRoleResult.pkresult);
			}
			bool flag6 = stageRoleResult.stars < 7U && data.stageInfo.stageType == 2U;
			if (flag6)
			{
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				bool flag7 = player != null && player.Attributes.Level > 10U;
				if (flag7)
				{
					XFPStrengthenDocument specificDocument = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
					specificDocument.TryShowBrief();
				}
			}
			bool flag8 = stageRoleResult.guildGoblinResult != null;
			if (flag8)
			{
				this.SmallMonsterRank = stageRoleResult.guildGoblinResult.curRank;
				this.RedSmallMonsterKilled = stageRoleResult.guildGoblinResult.getGuildBonus;
			}
			bool flag9 = data.specialStage != null;
			if (flag9)
			{
				this.BrokeRecords = false;
				bool flag10 = data.specialStage.bossrushresult != null;
				if (flag10)
				{
					this.BrokeRecords = (data.specialStage.bossrushresult.lastmax < data.specialStage.bossrushresult.currentmax);
				}
			}
			bool flag11 = stageRoleResult.towerResult != null;
			if (flag11)
			{
				this.BrokeRecords = stageRoleResult.towerResult.isNewRecord;
				this.TowerFloor = stageRoleResult.towerResult.towerFloor;
			}
			this.WatchCount = 0U;
			this.LikeCount = 0U;
			bool flag12 = data.watchinfo != null;
			if (flag12)
			{
				this.WatchCount = data.watchinfo.wathccount;
				this.LikeCount = data.watchinfo.likecount;
			}
			XSingleton<XLevelStatistics>.singleton.OnSetBattleResult();
			this.SetBattleDataList(data);
			this.SetSelectChestResult(data);
			this.SetGerenalResult(data);
			SceneType stageType = (SceneType)data.stageInfo.stageType;
			if (stageType <= SceneType.SCENE_WEEKEND4V4_DUCK)
			{
				if (stageType != SceneType.SCENE_PVP)
				{
					if (stageType != SceneType.SCENE_DRAGON_EXP)
					{
						switch (stageType)
						{
						case SceneType.SKYCITY_FIGHTING:
							this.SetSkyArenaResult(data);
							break;
						case SceneType.SCENE_RESWAR_PVP:
						case SceneType.SCENE_RESWAR_PVE:
							this.SetGuildMineResult(data);
							break;
						case SceneType.SCENE_HORSE_RACE:
							this.SetRaceResult(data);
							break;
						case SceneType.SCENE_HEROBATTLE:
							this.SetHeroBattleResult(data);
							break;
						case SceneType.SCENE_INVFIGHT:
							this.SetInviFightResult(data);
							break;
						case SceneType.SCENE_ABYSS_PARTY:
							this.SetAbyssPartyResult(data);
							break;
						case SceneType.SCENE_CUSTOMPK:
						case SceneType.SCENE_CUSTOMPKTWO:
							this.SetCustomBattleResult(data);
							break;
						case SceneType.SCENE_MOBA:
							this.SetMobaBattleResult(data);
							break;
						case SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT:
						case SceneType.SCENE_WEEKEND4V4_GHOSTACTION:
						case SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE:
						case SceneType.SCENE_WEEKEND4V4_CRAZYBOMB:
						case SceneType.SCENE_WEEKEND4V4_HORSERACING:
						case SceneType.SCENE_WEEKEND4V4_DUCK:
							this.SetWeekendPartyBattleResult(data);
							break;
						}
					}
					else
					{
						this.SetDragonCrusadeResult(data);
					}
				}
				else
				{
					this.SetPVPResult(data);
				}
			}
			else if (stageType != SceneType.SCENE_BIGMELEE_FIGHT)
			{
				if (stageType != SceneType.SCENE_BATTLEFIELD_FIGHT)
				{
					if (stageType == SceneType.SCENE_RIFT)
					{
						this.SetRiftData(data);
					}
				}
				else
				{
					this.SetBattleFieldResult(data);
				}
			}
			else
			{
				this.SetBigMeleeResult(data);
			}
			bool canDrawBox = this.CurrentSceneData.CanDrawBox;
			if (canDrawBox)
			{
				this.SendQueryBoxs(false);
			}
		}

		// Token: 0x0600952D RID: 38189 RVA: 0x0016230C File Offset: 0x0016050C
		private void SetWeekendPartyBattleResult(NewBattleResult data)
		{
			this.WeekendPartyBattleData.Init();
			StageRoleResult stageRoleResult = null;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					bool flag2 = data.roleReward[i].weekend4v4roledata != null;
					if (flag2)
					{
						this.WeekendPartyBattleData.PlayerRedBlue = stageRoleResult.weekend4v4roledata.redblue;
						XSingleton<XDebug>.singleton.AddLog("WeekendPary result selfRedBlue = " + this.WeekendPartyBattleData.PlayerRedBlue.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
					}
					break;
				}
			}
			bool flag3 = stageRoleResult == null;
			if (!flag3)
			{
				for (int j = 0; j < data.roleReward.Count; j++)
				{
					WeekendPartyBattleRoleInfo weekendPartyBattleRoleInfo = new WeekendPartyBattleRoleInfo();
					WeekEnd4v4BattleRoleData weekend4v4roledata = data.roleReward[j].weekend4v4roledata;
					bool flag4 = weekend4v4roledata != null && weekend4v4roledata.isline;
					if (flag4)
					{
						weekendPartyBattleRoleInfo.roleName = weekend4v4roledata.rolename;
						weekendPartyBattleRoleInfo.roleID = weekend4v4roledata.roleid;
						weekendPartyBattleRoleInfo.kill = weekend4v4roledata.killCount;
						weekendPartyBattleRoleInfo.beKilled = weekend4v4roledata.bekilledCount;
						weekendPartyBattleRoleInfo.score = weekend4v4roledata.score;
						weekendPartyBattleRoleInfo.redBlue = weekend4v4roledata.redblue;
						weekendPartyBattleRoleInfo.RoleProf = (int)weekend4v4roledata.profession;
						this.WeekendPartyBattleData.AllRoleData.Add(weekendPartyBattleRoleInfo);
					}
				}
				bool flag5 = data.stageInfo != null && data.stageInfo.weekend4v4tmresult != null;
				if (flag5)
				{
					this.WeekendPartyBattleData.WarTime = data.stageInfo.weekend4v4tmresult.teamSeconds;
					this.WeekendPartyBattleData.Team1Score = ((this.WeekendPartyBattleData.PlayerRedBlue == 1U) ? data.stageInfo.weekend4v4tmresult.redTeamScore : data.stageInfo.weekend4v4tmresult.blueTeamScore);
					this.WeekendPartyBattleData.Team2Score = ((this.WeekendPartyBattleData.PlayerRedBlue != 1U) ? data.stageInfo.weekend4v4tmresult.redTeamScore : data.stageInfo.weekend4v4tmresult.blueTeamScore);
					this.WeekendPartyBattleData.HasRewardsID = data.stageInfo.weekend4v4tmresult.hasRewardsID;
					XSingleton<XDebug>.singleton.AddLog("WeekendPary result redTeamScore = " + data.stageInfo.weekend4v4tmresult.redTeamScore.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
					XSingleton<XDebug>.singleton.AddLog("WeekendPary result blueTeamScore = " + data.stageInfo.weekend4v4tmresult.blueTeamScore.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
		}

		// Token: 0x0600952E RID: 38190 RVA: 0x001625F4 File Offset: 0x001607F4
		private void SetRiftData(NewBattleResult data)
		{
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					StageRoleResult stageRoleResult = data.roleReward[i];
					this.RiftResult = stageRoleResult.riftResult;
					break;
				}
			}
		}

		// Token: 0x0600952F RID: 38191 RVA: 0x00162668 File Offset: 0x00160868
		private void SetCustomBattleResult(NewBattleResult data)
		{
			this.CustomBattleData.Init();
			StageRoleResult stageRoleResult = null;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					break;
				}
			}
			bool flag2 = stageRoleResult == null;
			if (!flag2)
			{
				this.CustomBattleData.GameType = (uint)XFastEnumIntEqualityComparer<CustomBattleType>.ToInt(stageRoleResult.custombattle.type);
				this.CustomBattleData.Result = stageRoleResult.custombattle.result;
				for (int j = 0; j < data.roleReward.Count; j++)
				{
					XLevelRewardDocument.CustomBattleInfo item = new XLevelRewardDocument.CustomBattleInfo
					{
						RoleName = data.roleReward[j].rolename,
						RoleID = data.roleReward[j].roleid,
						RoleProf = data.roleReward[j].profession,
						KillCount = data.roleReward[j].killcount,
						MaxKillCount = data.roleReward[j].killcontinuemax,
						DeathCount = (int)data.roleReward[j].deathcount,
						Damage = (ulong)data.roleReward[j].damage,
						Heal = (ulong)data.roleReward[j].treat,
						PointChange = data.roleReward[j].custombattle.point,
						IsMvp = false
					};
					bool flag3 = stageRoleResult.custombattle.fightgroup == data.roleReward[j].custombattle.fightgroup;
					if (flag3)
					{
						this.CustomBattleData.Team1Data.Add(item);
					}
					else
					{
						this.CustomBattleData.Team2Data.Add(item);
					}
				}
			}
		}

		// Token: 0x06009530 RID: 38192 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetDragonCrusadeWin()
		{
		}

		// Token: 0x06009531 RID: 38193 RVA: 0x00162898 File Offset: 0x00160A98
		public void SetPlayerSelectChestID(int index)
		{
			this.SelectChestFrameData.Player.BoxID = index;
			bool flag = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.RefreshSelectChest();
			}
		}

		// Token: 0x06009532 RID: 38194 RVA: 0x001628D8 File Offset: 0x00160AD8
		public void SetBattleDataList(NewBattleResult data)
		{
			this.BattleDataList.Clear();
			float num = 0f;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				num += data.roleReward[i].damage;
			}
			bool flag = num == 0f;
			if (flag)
			{
				num = 1f;
			}
			for (int j = 0; j < data.roleReward.Count; j++)
			{
				XLevelRewardDocument.BattleData item = new XLevelRewardDocument.BattleData
				{
					uid = data.roleReward[j].roleid,
					Name = data.roleReward[j].rolename,
					ProfID = data.roleReward[j].profession,
					Rank = this.GetRankByBit(data.roleReward[j].stars),
					isLeader = data.roleReward[j].isLeader,
					DamageTotal = (ulong)data.roleReward[j].damage,
					DamagePercent = data.roleReward[j].damage * 100f / num,
					HealTotal = (ulong)data.roleReward[j].treat,
					DeathCount = data.roleReward[j].deathcount,
					ComboCount = data.roleReward[j].maxcombo
				};
				this.BattleDataList.Add(item);
			}
		}

		// Token: 0x06009533 RID: 38195 RVA: 0x00162A88 File Offset: 0x00160C88
		private void SetSelectChestResult(NewBattleResult data)
		{
			this.SelectChestFrameData.Init();
			StageRoleResult stageRoleResult = null;
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					num = i;
					break;
				}
			}
			bool flag2 = stageRoleResult == null;
			if (!flag2)
			{
				this.SelectChestFrameData.Player.uid = stageRoleResult.roleid;
				this.SelectChestFrameData.Player.Name = stageRoleResult.rolename;
				this.SelectChestFrameData.Player.Rank = this.GetRankByBit(stageRoleResult.stars);
				this.SelectChestFrameData.Player.Level = stageRoleResult.endlevel;
				this.SelectChestFrameData.Player.ProfID = stageRoleResult.profession;
				this.SelectChestFrameData.Player.isLeader = stageRoleResult.isLeader;
				this.SelectChestFrameData.Player.BoxID = 0;
				List<BattleRewardChest> chestList = new List<BattleRewardChest>
				{
					new BattleRewardChest(),
					new BattleRewardChest(),
					new BattleRewardChest(),
					new BattleRewardChest()
				};
				this.SelectChestFrameData.Player.chestList = chestList;
				this.SelectChestFrameData.Player.isHelper = stageRoleResult.ishelper;
				this.SelectChestFrameData.Player.noneReward = stageRoleResult.isboxexcept;
				this.SelectChestFrameData.Others.Clear();
				for (int j = 0; j < data.roleReward.Count; j++)
				{
					bool flag3 = j != num;
					if (flag3)
					{
						chestList = new List<BattleRewardChest>
						{
							new BattleRewardChest(),
							new BattleRewardChest(),
							new BattleRewardChest(),
							new BattleRewardChest()
						};
						XLevelRewardDocument.LevelRewardRoleData item = new XLevelRewardDocument.LevelRewardRoleData
						{
							uid = data.roleReward[j].roleid,
							Name = data.roleReward[j].rolename,
							Level = data.roleReward[j].endlevel,
							ProfID = data.roleReward[j].profession,
							isLeader = data.roleReward[j].isLeader,
							Rank = this.GetRankByBit(data.roleReward[j].stars),
							BoxID = 0,
							chestList = chestList,
							isHelper = data.roleReward[j].ishelper,
							noneReward = data.roleReward[j].isboxexcept,
							ServerID = data.roleReward[j].serverid
						};
						this.SelectChestFrameData.Others.Add(item);
					}
				}
				this.SelectChestFrameData.SelectLeftTime = XSingleton<XGlobalConfig>.singleton.GetInt("LevelFinishSelectChestTime");
			}
		}

		// Token: 0x06009534 RID: 38196 RVA: 0x00162DD0 File Offset: 0x00160FD0
		private void SetGerenalResult(NewBattleResult data)
		{
			this.GerenalBattleData.Init();
			StageRoleResult stageRoleResult = null;
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					num = i;
					break;
				}
			}
			bool flag2 = stageRoleResult == null;
			if (!flag2)
			{
				this.GerenalBattleData.Score = stageRoleResult.score;
				this.GerenalBattleData.Rank = this.GetRankByBit(this._rank);
				List<uint> starsByBit = this.GetStarsByBit(this._rank);
				for (int j = 0; j < starsByBit.Count; j++)
				{
					this.GerenalBattleData.Stars.Add(starsByBit[j]);
				}
				this.GerenalBattleData.Items.Clear();
				for (int k = 0; k < stageRoleResult.items.Count; k++)
				{
					bool flag3 = false;
					for (int l = 0; l < this.GerenalBattleData.Items.Count; l++)
					{
						bool flag4 = stageRoleResult.items[k].itemID == this.GerenalBattleData.Items[l].itemID;
						if (flag4)
						{
							flag3 = true;
							this.GerenalBattleData.Items[l].itemCount += stageRoleResult.items[k].itemCount;
							break;
						}
					}
					bool flag5 = !flag3;
					if (flag5)
					{
						this.GerenalBattleData.Items.Add(this.CopyItemBrief(stageRoleResult.items[k]));
					}
				}
				bool flag6 = stageRoleResult.money > 0U;
				if (flag6)
				{
					ItemBrief itemBrief = new ItemBrief
					{
						itemID = (uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD),
						itemCount = stageRoleResult.money
					};
					bool flag3 = false;
					for (int m = 0; m < this.GerenalBattleData.Items.Count; m++)
					{
						bool flag7 = itemBrief.itemID == this.Items[m].itemID;
						if (flag7)
						{
							flag3 = true;
							this.GerenalBattleData.Items[m].itemCount += itemBrief.itemCount;
							break;
						}
					}
					bool flag8 = !flag3;
					if (flag8)
					{
						this.GerenalBattleData.Items.Add(this.CopyItemBrief(itemBrief));
					}
				}
				this.GerenalBattleData.LevelFinishTime = data.stageInfo.timespan;
				XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				this.GerenalBattleData.StartLevel = stageRoleResult.startLevel;
				this.GerenalBattleData.StartPercent = 1f * stageRoleResult.startExp / (float)xplayerData.GetLevelUpExp((int)(stageRoleResult.startLevel + 1U));
				this.GerenalBattleData.TotalExpPercent = stageRoleResult.endlevel - stageRoleResult.startLevel + 1f * stageRoleResult.endexp / (float)xplayerData.GetLevelUpExp((int)(stageRoleResult.endlevel + 1U)) - 1f * stageRoleResult.startExp / (float)xplayerData.GetLevelUpExp((int)(stageRoleResult.startLevel + 1U));
				this.GerenalBattleData.CurrentExpPercent = 1f * stageRoleResult.startExp / (float)xplayerData.GetLevelUpExp((int)(stageRoleResult.startLevel + 1U));
				this.GerenalBattleData.GrowExpPercent = this.GerenalBattleData.TotalExpPercent / 60f;
				this.GerenalBattleData.TotalExp = stageRoleResult.exp;
				this.GerenalBattleData.GuildBuff = 0f;
				for (int n = 0; n < data.roleReward.Count; n++)
				{
					bool flag9 = num != n && data.roleReward[n].gid != 0UL && data.roleReward[num].gid == data.roleReward[n].gid;
					if (flag9)
					{
						SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.CurrentScene);
						this.GerenalBattleData.GuildBuff = sceneData.GuildExpBounus;
						break;
					}
				}
				this.GerenalBattleData.SwitchLeftTime = 0;
				this.GerenalBattleData.GuildExp = stageRoleResult.guildexp;
				this.GerenalBattleData.GuildContribution = stageRoleResult.guildcon;
				this.GerenalBattleData.GuildDragonCoin = stageRoleResult.guilddargon;
				bool flag10 = stageRoleResult.teamcostreward != null;
				if (flag10)
				{
					this.GerenalBattleData.GoldGroupReward = new ItemBrief();
					this.GerenalBattleData.GoldGroupReward.itemID = stageRoleResult.teamcostreward.itemID;
					this.GerenalBattleData.GoldGroupReward.itemCount = stageRoleResult.teamcostreward.itemCount;
					this.GerenalBattleData.GoldGroupReward.isbind = stageRoleResult.teamcostreward.isbind;
				}
				this.GerenalBattleData.isHelper = stageRoleResult.ishelper;
				this.GerenalBattleData.noneReward = stageRoleResult.isboxexcept;
				this.GerenalBattleData.isSeal = stageRoleResult.isexpseal;
			}
		}

		// Token: 0x06009535 RID: 38197 RVA: 0x0016332C File Offset: 0x0016152C
		private void SetPVPResult(NewBattleResult data)
		{
			this.PvpBattleData.Init();
			PVPResult pvpresult = null;
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					pvpresult = data.roleReward[i].pvpresult;
					num = i;
					break;
				}
			}
			bool flag2 = pvpresult == null;
			if (!flag2)
			{
				this.IsWin = (pvpresult.wingroup == pvpresult.mygroup);
				bool flag3 = pvpresult.wingroup == 3;
				if (flag3)
				{
					this.PvpBattleData.PVPResult = 3;
				}
				else
				{
					bool flag4 = pvpresult.wingroup == pvpresult.mygroup;
					if (flag4)
					{
						this.PvpBattleData.PVPResult = 1;
					}
					else
					{
						this.PvpBattleData.PVPResult = 2;
					}
				}
				for (int j = 0; j < pvpresult.dayjoinreward.Count; j++)
				{
					this.PvpBattleData.DayJoinReward.Add(pvpresult.dayjoinreward[j]);
				}
				for (int k = 0; k < pvpresult.winreward.Count; k++)
				{
					this.PvpBattleData.WinReward.Add(pvpresult.winreward[k]);
				}
				this.PvpBattleData.Team1Data.Add(this.GetPVPRoleInfo(num, data, true));
				for (int l = 0; l < data.roleReward.Count; l++)
				{
					bool flag5 = l == num;
					if (!flag5)
					{
						bool flag6 = pvpresult.mygroup == data.roleReward[l].pvpresult.mygroup;
						if (flag6)
						{
							this.PvpBattleData.Team1Data.Add(this.GetPVPRoleInfo(l, data, true));
						}
						else
						{
							this.PvpBattleData.Team2Data.Add(this.GetPVPRoleInfo(l, data, true));
						}
					}
				}
			}
		}

		// Token: 0x06009536 RID: 38198 RVA: 0x00163548 File Offset: 0x00161748
		private void SetHeroBattleResult(NewBattleResult data)
		{
			this.HeroData.Init();
			uint num = uint.MaxValue;
			int num2 = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.HeroData.Result = data.roleReward[i].heroresult.over;
					num = data.roleReward[i].heroresult.teamid;
					num2 = i;
					break;
				}
			}
			bool flag2 = num == uint.MaxValue;
			if (!flag2)
			{
				this.HeroData.Team1Data.Add(this.GetPVPRoleInfo(num2, data, false));
				for (int j = 0; j < data.roleReward[num2].heroresult.winreward.Count; j++)
				{
					this.HeroData.WinReward.Add(this.CopyItemBrief(data.roleReward[num2].heroresult.winreward[j]));
				}
				for (int k = 0; k < data.roleReward[num2].heroresult.dayjoinreward.Count; k++)
				{
					this.HeroData.DayJoinReward.Add(this.CopyItemBrief(data.roleReward[num2].heroresult.dayjoinreward[k]));
				}
				for (int l = 0; l < data.roleReward.Count; l++)
				{
					bool flag3 = data.roleReward[l].heroresult.mvpid == data.roleReward[l].roleid;
					if (flag3)
					{
						this.HeroData.MvpData = this.GetPVPRoleInfo(l, data, false);
						this.HeroData.MvpHeroID = data.roleReward[l].heroresult.mvpheroid;
					}
					bool flag4 = data.roleReward[l].killcount > this.HeroData.KillMax;
					if (flag4)
					{
						this.HeroData.KillMax = data.roleReward[l].killcount;
					}
					bool flag5 = (ulong)data.roleReward[l].deathcount < (ulong)((long)this.HeroData.DeathMin);
					if (flag5)
					{
						this.HeroData.DeathMin = (int)data.roleReward[l].deathcount;
					}
					bool flag6 = (ulong)data.roleReward[l].assitnum > (ulong)((long)this.HeroData.AssitMax);
					if (flag6)
					{
						this.HeroData.AssitMax = (int)data.roleReward[l].assitnum;
					}
					bool flag7 = data.roleReward[l].damage > this.HeroData.DamageMax;
					if (flag7)
					{
						this.HeroData.DamageMax = (ulong)data.roleReward[l].damage;
					}
					bool flag8 = data.roleReward[l].behitdamage > this.HeroData.BeHitMax;
					if (flag8)
					{
						this.HeroData.BeHitMax = data.roleReward[l].behitdamage;
					}
					bool flag9 = l == num2;
					if (!flag9)
					{
						bool flag10 = num == data.roleReward[l].heroresult.teamid;
						if (flag10)
						{
							this.HeroData.Team1Data.Add(this.GetPVPRoleInfo(l, data, false));
						}
						else
						{
							this.HeroData.Team2Data.Add(this.GetPVPRoleInfo(l, data, false));
						}
					}
				}
			}
		}

		// Token: 0x06009537 RID: 38199 RVA: 0x00163928 File Offset: 0x00161B28
		private void SetMobaBattleResult(NewBattleResult data)
		{
			this.MobaData.Init();
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.MobaData.Result = (data.roleReward[i].mobabattle.isWin ? HeroBattleOver.HeroBattleOver_Win : HeroBattleOver.HeroBattleOver_Lose);
					num = i;
					break;
				}
			}
			bool flag2 = num == -1;
			if (!flag2)
			{
				this.MobaData.Team1Data.Add(this.GetMobaRoleInfo(num, data, false));
				for (int j = 0; j < data.roleReward[num].mobabattle.winreward.Count; j++)
				{
					this.MobaData.WinReward.Add(this.CopyItemBrief(data.roleReward[num].mobabattle.winreward[j]));
				}
				this.MobaData.BeHitMaxUid = data.stageInfo.mobabattle.behitdamagemaxid;
				this.MobaData.DamageMaxUid = data.stageInfo.mobabattle.damagemaxid;
				for (int k = 0; k < data.roleReward.Count; k++)
				{
					bool flag3 = data.stageInfo.mobabattle.mvpid == data.roleReward[k].roleid;
					if (flag3)
					{
						this.MobaData.MvpData = this.GetMobaRoleInfo(k, data, false);
						this.MobaData.MvpHeroID = data.roleReward[k].mobabattle.heroid;
					}
					bool flag4 = data.roleReward[k].killcount > this.MobaData.KillMax;
					if (flag4)
					{
						this.MobaData.KillMax = data.roleReward[k].killcount;
					}
					bool flag5 = (ulong)data.roleReward[k].deathcount < (ulong)((long)this.MobaData.DeathMin);
					if (flag5)
					{
						this.MobaData.DeathMin = (int)data.roleReward[k].deathcount;
					}
					bool flag6 = (ulong)data.roleReward[k].assitnum > (ulong)((long)this.MobaData.AssitMax);
					if (flag6)
					{
						this.MobaData.AssitMax = (int)data.roleReward[k].assitnum;
					}
					bool flag7 = k == num;
					if (!flag7)
					{
						bool flag8 = specificDocument.isAlly(data.roleReward[k].roleid);
						if (flag8)
						{
							this.MobaData.Team1Data.Add(this.GetMobaRoleInfo(k, data, false));
						}
						else
						{
							this.MobaData.Team2Data.Add(this.GetMobaRoleInfo(k, data, false));
						}
					}
				}
			}
		}

		// Token: 0x06009538 RID: 38200 RVA: 0x00163C40 File Offset: 0x00161E40
		private void SetGuildMineResult(NewBattleResult data)
		{
			this.GuildMineBattleData.Init();
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.GuildMineBattleData.item = data.roleReward[i].items;
					this.GuildMineBattleData.mine = data.roleReward[i].reswar;
					break;
				}
			}
		}

		// Token: 0x06009539 RID: 38201 RVA: 0x00163CD8 File Offset: 0x00161ED8
		private void SetRaceResult(NewBattleResult data)
		{
			this.RaceBattleData.Init();
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				StageRoleResult stageRoleResult = data.roleReward[i];
				bool flag = stageRoleResult.money > 0U;
				if (flag)
				{
					ItemBrief item = new ItemBrief
					{
						itemID = (uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD),
						itemCount = stageRoleResult.money
					};
					stageRoleResult.items.Add(item);
				}
				this.RaceBattleData.rolename.Add(stageRoleResult.rolename);
				this.RaceBattleData.profession.Add(stageRoleResult.profession);
				this.RaceBattleData.item.Add(stageRoleResult.items);
				this.RaceBattleData.time.Add(stageRoleResult.horse.time);
				this.RaceBattleData.petid.Add(stageRoleResult.horse.horse);
				this.RaceBattleData.rank.Add(stageRoleResult.horse.rank);
			}
		}

		// Token: 0x0600953A RID: 38202 RVA: 0x00163DFC File Offset: 0x00161FFC
		private void SetInviFightResult(NewBattleResult data)
		{
			this.InvFightBattleData.Init();
			int num = 0;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					num = i;
					break;
				}
			}
			StageRoleResult stageRoleResult = (num < data.roleReward.Count) ? data.roleReward[num] : null;
			bool flag2 = stageRoleResult != null;
			if (flag2)
			{
				this.InvFightBattleData.isWin = (stageRoleResult.invfightresult.resulttype == PkResultType.PkResult_Win);
				this.InvFightBattleData.rivalName = stageRoleResult.invfightresult.opname;
			}
		}

		// Token: 0x0600953B RID: 38203 RVA: 0x00163EBC File Offset: 0x001620BC
		private void SetSkyArenaResult(NewBattleResult data)
		{
			this.SkyArenaBattleData.Init();
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				StageRoleResult stageRoleResult = data.roleReward[i];
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.SkyArenaBattleData.roleid.Add(stageRoleResult.roleid);
					this.SkyArenaBattleData.killcount.Add(stageRoleResult.killcount);
					this.SkyArenaBattleData.deathcount.Add((int)stageRoleResult.deathcount);
					this.SkyArenaBattleData.damage.Add((ulong)stageRoleResult.damage);
					this.SkyArenaBattleData.ismvp.Add(stageRoleResult.skycity.ismvp);
					this.SkyArenaBattleData.item = stageRoleResult.skycity.item;
					this.SkyArenaBattleData.floor = stageRoleResult.skycity.floor;
				}
			}
			for (int j = 0; j < data.roleReward.Count; j++)
			{
				bool flag2 = data.roleReward[j].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (!flag2)
				{
					StageRoleResult stageRoleResult = data.roleReward[j];
					this.SkyArenaBattleData.roleid.Add(stageRoleResult.roleid);
					this.SkyArenaBattleData.killcount.Add(stageRoleResult.killcount);
					this.SkyArenaBattleData.deathcount.Add((int)stageRoleResult.deathcount);
					this.SkyArenaBattleData.damage.Add((ulong)stageRoleResult.damage);
					this.SkyArenaBattleData.ismvp.Add(stageRoleResult.skycity.ismvp);
				}
			}
		}

		// Token: 0x0600953C RID: 38204 RVA: 0x001640B4 File Offset: 0x001622B4
		private void SetAbyssPartyResult(NewBattleResult data)
		{
			this.AbyssPartyBattleData.Init();
			this.AbyssPartyBattleData.Time = data.stageInfo.timespan;
			bool flag = data.roleReward.Count > 0;
			if (flag)
			{
				this.AbyssPartyBattleData.item = data.roleReward[0].items;
			}
			this.AbyssPartyBattleData.AbysssPartyListId = (int)data.stageInfo.abyssid;
		}

		// Token: 0x0600953D RID: 38205 RVA: 0x0016412C File Offset: 0x0016232C
		private void SetBigMeleeResult(NewBattleResult data)
		{
			this.BigMeleeBattleData.Init();
			bool flag = data.roleReward.Count == 0;
			if (!flag)
			{
				this.BigMeleeBattleData.rank = data.roleReward[0].bigmelee.rank;
				this.BigMeleeBattleData.score = data.roleReward[0].bigmelee.score;
				this.BigMeleeBattleData.kill = data.roleReward[0].bigmelee.kill;
				this.BigMeleeBattleData.death = data.roleReward[0].bigmelee.death;
				this.BigMeleeBattleData.item = data.roleReward[0].bigmelee.items;
			}
		}

		// Token: 0x0600953E RID: 38206 RVA: 0x00164204 File Offset: 0x00162404
		private void SetBattleFieldResult(NewBattleResult data)
		{
			this.BattleFieldBattleData.Init();
			this.BattleFieldBattleData.allend = data.stageInfo.end;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				XLevelRewardDocument.BattleRankRoleInfo battleRankRoleInfo = default(XLevelRewardDocument.BattleRankRoleInfo);
				battleRankRoleInfo.RoleID = data.roleReward[i].battlefield.roleid;
				battleRankRoleInfo.Rank = data.roleReward[i].battlefield.rank;
				battleRankRoleInfo.Point = data.roleReward[i].battlefield.point;
				battleRankRoleInfo.KillCount = data.roleReward[i].battlefield.killer;
				battleRankRoleInfo.DeathCount = data.roleReward[i].battlefield.death;
				battleRankRoleInfo.ServerName = data.roleReward[i].battlefield.svrname;
				battleRankRoleInfo.isMVP = data.roleReward[i].battlefield.ismvp;
				battleRankRoleInfo.Damage = (ulong)data.roleReward[i].battlefield.hurt;
				battleRankRoleInfo.Name = data.roleReward[i].battlefield.name;
				battleRankRoleInfo.RoleProf = (int)data.roleReward[i].battlefield.job;
				battleRankRoleInfo.CombKill = data.roleReward[i].battlefield.killstreak;
				this.BattleFieldBattleData.MemberData.Add(battleRankRoleInfo);
				bool flag = battleRankRoleInfo.RoleID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.BattleFieldBattleData.item = data.roleReward[i].items;
				}
			}
		}

		// Token: 0x0600953F RID: 38207 RVA: 0x001643EC File Offset: 0x001625EC
		public void ShowBattleRoyaleResultUI()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ResetPressState();
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(false);
				DlgBase<RadioBattleDlg, RadioBattleBahaviour>.singleton.Show(false);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(true);
			}
			bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisiblePure(false);
				DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(false);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(false);
			}
			bool flag3 = DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.IsLoaded();
			if (flag3)
			{
				DlgBase<ReviveDlg, ReviveDlgBehaviour>.singleton.SetVisiblePure(false);
			}
			bool flag4 = DlgBase<XChatView, XChatBehaviour>.singleton.IsLoaded();
			if (flag4)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
			}
			XSingleton<XVirtualTab>.singleton.Cancel();
			bool flag5 = !DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.IsVisible();
			if (flag5)
			{
				DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.SetVisible(true, true);
			}
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.ShowLevelReward(SceneType.SCENE_SURVIVE);
		}

		// Token: 0x06009540 RID: 38208 RVA: 0x001644E4 File Offset: 0x001626E4
		private void SetDragonCrusadeResult(NewBattleResult data)
		{
			this.DragonCrusadeDataWin.Init();
			StageRoleResult stageRoleResult = null;
			int num = -1;
			for (int i = 0; i < data.roleReward.Count; i++)
			{
				bool flag = data.roleReward[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					stageRoleResult = data.roleReward[i];
					num = i;
					this.DragonCrusadeDataWin.MyResult = data.roleReward[i].deresult;
					break;
				}
			}
			bool flag2 = stageRoleResult == null;
			if (!flag2)
			{
				this.DragonCrusadeDataWin.Player.uid = stageRoleResult.roleid;
				this.DragonCrusadeDataWin.Player.Name = stageRoleResult.rolename;
				this.DragonCrusadeDataWin.Player.Rank = this.GetRankByBit(stageRoleResult.stars);
				this.DragonCrusadeDataWin.Player.Level = stageRoleResult.endlevel;
				this.DragonCrusadeDataWin.Player.ProfID = stageRoleResult.profession;
				this.DragonCrusadeDataWin.Player.isLeader = stageRoleResult.isLeader;
				this.DragonCrusadeDataWin.Player.BoxID = 0;
				this.DragonCrusadeDataWin.Player.chestList = stageRoleResult.box;
				this.DragonCrusadeDataWin.Player.isHelper = stageRoleResult.ishelper;
				this.DragonCrusadeDataWin.Others.Clear();
				for (int j = 0; j < data.roleReward.Count; j++)
				{
					bool flag3 = j != num;
					if (flag3)
					{
						XLevelRewardDocument.LevelRewardRoleData item = new XLevelRewardDocument.LevelRewardRoleData
						{
							uid = data.roleReward[j].roleid,
							Name = data.roleReward[j].rolename,
							Level = data.roleReward[j].endlevel,
							ProfID = data.roleReward[j].profession,
							isLeader = data.roleReward[j].isLeader,
							Rank = this.GetRankByBit(data.roleReward[j].stars),
							BoxID = 0,
							chestList = data.roleReward[j].box,
							isHelper = data.roleReward[j].ishelper
						};
						this.DragonCrusadeDataWin.Others.Add(item);
					}
				}
			}
		}

		// Token: 0x06009541 RID: 38209 RVA: 0x0016478C File Offset: 0x0016298C
		private XLevelRewardDocument.PVPRoleInfo GetPVPRoleInfo(int id, NewBattleResult data, bool isCapData = true)
		{
			return new XLevelRewardDocument.PVPRoleInfo
			{
				uID = data.roleReward[id].roleid,
				Name = data.roleReward[id].rolename,
				Prof = data.roleReward[id].profession,
				Level = data.roleReward[id].endlevel,
				KillCount = data.roleReward[id].killcount,
				MaxKillCount = data.roleReward[id].killcontinuemax,
				DeathCount = data.roleReward[id].deathcount,
				AssitCount = data.roleReward[id].assitnum,
				IsMvp = (isCapData ? data.roleReward[id].pvpresult.ismvp : (data.roleReward[id].heroresult.mvpid == data.roleReward[id].roleid || data.roleReward[id].heroresult.losemvpid == data.roleReward[id].roleid)),
				Damage = (ulong)data.roleReward[id].damage,
				BeHit = data.roleReward[id].behitdamage,
				Kda = ((data.roleReward[id].heroresult == null) ? 0f : data.roleReward[id].heroresult.kda),
				Heal = (ulong)data.roleReward[id].treat,
				ServerID = data.roleReward[id].serverid,
				militaryRank = data.roleReward[id].military_rank
			};
		}

		// Token: 0x06009542 RID: 38210 RVA: 0x00164994 File Offset: 0x00162B94
		private XLevelRewardDocument.PVPRoleInfo GetMobaRoleInfo(int id, NewBattleResult data, bool isCapData = true)
		{
			return new XLevelRewardDocument.PVPRoleInfo
			{
				uID = data.roleReward[id].roleid,
				Name = data.roleReward[id].rolename,
				Prof = data.roleReward[id].profession,
				Level = data.roleReward[id].endlevel,
				KillCount = data.roleReward[id].killcount,
				MaxKillCount = (int)data.roleReward[id].multikillcountmax,
				DeathCount = data.roleReward[id].deathcount,
				AssitCount = data.roleReward[id].assitnum,
				IsMvp = (data.roleReward[id].roleid == data.stageInfo.mobabattle.mvpid || data.roleReward[id].roleid == data.stageInfo.mobabattle.losemvpid),
				Damage = (ulong)data.roleReward[id].damage,
				BeHit = data.roleReward[id].behitdamage,
				Kda = ((data.roleReward[id].mobabattle == null) ? 0f : data.roleReward[id].mobabattle.kda),
				Heal = (ulong)data.roleReward[id].treat,
				ServerID = data.roleReward[id].serverid,
				militaryRank = data.roleReward[id].military_rank,
				isescape = data.roleReward[id].mobabattle.isescape
			};
		}

		// Token: 0x06009543 RID: 38211 RVA: 0x00164B90 File Offset: 0x00162D90
		private List<uint> GetStarsByBit(uint rank)
		{
			List<uint> list = new List<uint>();
			int i = 0;
			int num = 1;
			while (i < 5)
			{
				bool flag = ((ulong)rank & (ulong)((long)num)) > 0UL;
				if (flag)
				{
					list.Add(1U);
				}
				else
				{
					list.Add(0U);
				}
				i++;
				num <<= 1;
			}
			return list;
		}

		// Token: 0x06009544 RID: 38212 RVA: 0x00164BE8 File Offset: 0x00162DE8
		public uint GetRankByBit(uint bit)
		{
			uint num = 0U;
			while (bit > 0U)
			{
				bool flag = (bit & 1U) == 1U;
				if (flag)
				{
					num += 1U;
				}
				bit >>= 1;
			}
			return num;
		}

		// Token: 0x06009545 RID: 38213 RVA: 0x00164C20 File Offset: 0x00162E20
		public ItemBrief CopyItemBrief(ItemBrief item)
		{
			return new ItemBrief
			{
				itemID = item.itemID,
				itemCount = item.itemCount,
				isbind = item.isbind
			};
		}

		// Token: 0x06009546 RID: 38214 RVA: 0x00164C60 File Offset: 0x00162E60
		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

		// Token: 0x06009547 RID: 38215 RVA: 0x00164C88 File Offset: 0x00162E88
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && (this._requestServer || XSingleton<XGame>.singleton.SyncMode);
			if (flag)
			{
				XSingleton<XLevelFinishMgr>.singleton.SendBattleReport(null);
			}
		}

		// Token: 0x06009548 RID: 38216 RVA: 0x00164CD4 File Offset: 0x00162ED4
		public void ReportPlayer(ulong uid, List<reportType> list)
		{
			RpcC2G_ReportBadPlayer rpcC2G_ReportBadPlayer = new RpcC2G_ReportBadPlayer();
			rpcC2G_ReportBadPlayer.oArg.roleid = uid;
			rpcC2G_ReportBadPlayer.oArg.reason.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				bool state = list[i].state;
				if (state)
				{
					rpcC2G_ReportBadPlayer.oArg.reason.Add(list[i].type);
				}
			}
			rpcC2G_ReportBadPlayer.oArg.scenetype = (uint)XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReportBadPlayer);
		}

		// Token: 0x06009549 RID: 38217 RVA: 0x00164D74 File Offset: 0x00162F74
		public List<string> GetMobaIconList(XLevelRewardDocument.PVPRoleInfo data, ulong DamageMaxUid = 0UL, ulong BeHitMaxUid = 0UL, int KillMax = 0, int AssistsMax = 0)
		{
			List<string> list = new List<string>();
			bool flag = data.MaxKillCount > 2;
			if (flag)
			{
				int maxKillCount = data.MaxKillCount;
				if (maxKillCount != 3)
				{
					if (maxKillCount != 4)
					{
						list.Add("ic_pf5");
					}
					else
					{
						list.Add("ic_pf4");
					}
				}
				else
				{
					list.Add("ic_pf3");
				}
			}
			bool flag2 = data.KillCount == KillMax && KillMax != 0;
			if (flag2)
			{
				list.Add("ic_pf1");
			}
			bool flag3 = (ulong)data.AssitCount == (ulong)((long)AssistsMax) && AssistsMax != 0;
			if (flag3)
			{
				list.Add("ic_pf6");
			}
			bool flag4 = data.uID == BeHitMaxUid && BeHitMaxUid > 0UL;
			if (flag4)
			{
				list.Add("ic_pf2");
			}
			bool flag5 = data.uID == DamageMaxUid && DamageMaxUid > 0UL;
			if (flag5)
			{
				list.Add("ic_pf0");
			}
			bool isescape = data.isescape;
			if (isescape)
			{
				list.Add("ic_pf8");
			}
			return list;
		}

		// Token: 0x0400324F RID: 12879
		public static int MEMBER_COUNT = 16;

		// Token: 0x04003250 RID: 12880
		public RiftResult RiftResult;

		// Token: 0x04003251 RID: 12881
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("LevelRewardDocument");

		// Token: 0x04003252 RID: 12882
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003253 RID: 12883
		private bool _requestServer = false;

		// Token: 0x04003254 RID: 12884
		private uint _rank = 0U;

		// Token: 0x04003255 RID: 12885
		public List<uint> Stars = new List<uint>();

		// Token: 0x04003256 RID: 12886
		public List<ItemBrief> Items = new List<ItemBrief>();

		// Token: 0x04003258 RID: 12888
		public List<ItemBrief> StarsItems = new List<ItemBrief>();

		// Token: 0x04003259 RID: 12889
		private SceneTable.RowData _current_scene_data = null;

		// Token: 0x0400325C RID: 12892
		private float _last_query_box_time = 0f;

		// Token: 0x04003260 RID: 12896
		public List<XLevelRewardDocument.DamageRank> Member = new List<XLevelRewardDocument.DamageRank>();

		// Token: 0x04003261 RID: 12897
		public Dictionary<ulong, int> MemberSelectChest = new Dictionary<ulong, int>();

		// Token: 0x04003263 RID: 12899
		public static StageRankTable Table = new StageRankTable();

		// Token: 0x04003276 RID: 12918
		public XLevelRewardDocument.PVPData PvpBattleData = default(XLevelRewardDocument.PVPData);

		// Token: 0x04003277 RID: 12919
		public XLevelRewardDocument.HeroBattleData HeroData = default(XLevelRewardDocument.HeroBattleData);

		// Token: 0x04003278 RID: 12920
		public XLevelRewardDocument.HeroBattleData MobaData = default(XLevelRewardDocument.HeroBattleData);

		// Token: 0x04003279 RID: 12921
		public XLevelRewardDocument.RaceData RaceBattleData = default(XLevelRewardDocument.RaceData);

		// Token: 0x0400327A RID: 12922
		public XLevelRewardDocument.InvFightData InvFightBattleData = default(XLevelRewardDocument.InvFightData);

		// Token: 0x0400327B RID: 12923
		public XLevelRewardDocument.SkyArenaData SkyArenaBattleData = default(XLevelRewardDocument.SkyArenaData);

		// Token: 0x0400327C RID: 12924
		public XLevelRewardDocument.AbyssPartyData AbyssPartyBattleData = default(XLevelRewardDocument.AbyssPartyData);

		// Token: 0x0400327D RID: 12925
		public XLevelRewardDocument.BigMeleeData BigMeleeBattleData = default(XLevelRewardDocument.BigMeleeData);

		// Token: 0x0400327E RID: 12926
		public XLevelRewardDocument.BattleFieldData BattleFieldBattleData = default(XLevelRewardDocument.BattleFieldData);

		// Token: 0x0400327F RID: 12927
		public XLevelRewardDocument.GuildMineData GuildMineBattleData = default(XLevelRewardDocument.GuildMineData);

		// Token: 0x04003280 RID: 12928
		public XLevelRewardDocument.GerenalData GerenalBattleData = default(XLevelRewardDocument.GerenalData);

		// Token: 0x04003281 RID: 12929
		public XLevelRewardDocument.SelectChestData SelectChestFrameData = default(XLevelRewardDocument.SelectChestData);

		// Token: 0x04003282 RID: 12930
		public XLevelRewardDocument.DragonCrusadeData DragonCrusadeDataWin = default(XLevelRewardDocument.DragonCrusadeData);

		// Token: 0x04003283 RID: 12931
		public List<XLevelRewardDocument.BattleData> BattleDataList = new List<XLevelRewardDocument.BattleData>();

		// Token: 0x04003284 RID: 12932
		public XLevelRewardDocument.QualifyingData QualifyingBattleData = default(XLevelRewardDocument.QualifyingData);

		// Token: 0x04003285 RID: 12933
		public XLevelRewardDocument.CustomBattleGameData CustomBattleData = default(XLevelRewardDocument.CustomBattleGameData);

		// Token: 0x04003286 RID: 12934
		public XLevelRewardDocument.WeekendPartyData WeekendPartyBattleData = default(XLevelRewardDocument.WeekendPartyData);

		// Token: 0x04003287 RID: 12935
		public XLevelRewardDocument.BattleRoyaleData BattleRoyaleDataInfo = default(XLevelRewardDocument.BattleRoyaleData);

		// Token: 0x0400328B RID: 12939
		private float LastLeaveSceneTime = 0f;

		// Token: 0x0400328C RID: 12940
		private XFx TheGoddessWinFx = null;

		// Token: 0x0400328D RID: 12941
		private uint _autoReturnTimeToken = 0U;

		// Token: 0x0200196D RID: 6509
		public struct DamageRank
		{
			// Token: 0x17003B44 RID: 15172
			// (get) Token: 0x06010FF5 RID: 69621 RVA: 0x00452E71 File Offset: 0x00451071
			// (set) Token: 0x06010FF6 RID: 69622 RVA: 0x00452E79 File Offset: 0x00451079
			public string Name { get; set; }

			// Token: 0x17003B45 RID: 15173
			// (get) Token: 0x06010FF7 RID: 69623 RVA: 0x00452E82 File Offset: 0x00451082
			// (set) Token: 0x06010FF8 RID: 69624 RVA: 0x00452E8A File Offset: 0x0045108A
			public int Damage { get; set; }
		}

		// Token: 0x0200196E RID: 6510
		public struct PVPRoleInfo
		{
			// Token: 0x04007E26 RID: 32294
			public string Name;

			// Token: 0x04007E27 RID: 32295
			public ulong uID;

			// Token: 0x04007E28 RID: 32296
			public uint Level;

			// Token: 0x04007E29 RID: 32297
			public int Prof;

			// Token: 0x04007E2A RID: 32298
			public int KillCount;

			// Token: 0x04007E2B RID: 32299
			public int MaxKillCount;

			// Token: 0x04007E2C RID: 32300
			public uint DeathCount;

			// Token: 0x04007E2D RID: 32301
			public uint AssitCount;

			// Token: 0x04007E2E RID: 32302
			public bool IsMvp;

			// Token: 0x04007E2F RID: 32303
			public ulong Damage;

			// Token: 0x04007E30 RID: 32304
			public uint BeHit;

			// Token: 0x04007E31 RID: 32305
			public float Kda;

			// Token: 0x04007E32 RID: 32306
			public ulong Heal;

			// Token: 0x04007E33 RID: 32307
			public uint ServerID;

			// Token: 0x04007E34 RID: 32308
			public uint militaryRank;

			// Token: 0x04007E35 RID: 32309
			public bool isescape;
		}

		// Token: 0x0200196F RID: 6511
		public struct PVPData
		{
			// Token: 0x06010FF9 RID: 69625 RVA: 0x00452E93 File Offset: 0x00451093
			public void Init()
			{
				this.PVPResult = 0;
				this.DayJoinReward = new List<ItemBrief>();
				this.WinReward = new List<ItemBrief>();
				this.Team1Data = new List<XLevelRewardDocument.PVPRoleInfo>();
				this.Team2Data = new List<XLevelRewardDocument.PVPRoleInfo>();
			}

			// Token: 0x04007E36 RID: 32310
			public int PVPResult;

			// Token: 0x04007E37 RID: 32311
			public List<ItemBrief> DayJoinReward;

			// Token: 0x04007E38 RID: 32312
			public List<ItemBrief> WinReward;

			// Token: 0x04007E39 RID: 32313
			public List<XLevelRewardDocument.PVPRoleInfo> Team1Data;

			// Token: 0x04007E3A RID: 32314
			public List<XLevelRewardDocument.PVPRoleInfo> Team2Data;
		}

		// Token: 0x02001970 RID: 6512
		public struct CustomBattleInfo
		{
			// Token: 0x04007E3B RID: 32315
			public string RoleName;

			// Token: 0x04007E3C RID: 32316
			public ulong RoleID;

			// Token: 0x04007E3D RID: 32317
			public int RoleProf;

			// Token: 0x04007E3E RID: 32318
			public int KillCount;

			// Token: 0x04007E3F RID: 32319
			public int MaxKillCount;

			// Token: 0x04007E40 RID: 32320
			public int DeathCount;

			// Token: 0x04007E41 RID: 32321
			public ulong Damage;

			// Token: 0x04007E42 RID: 32322
			public ulong Heal;

			// Token: 0x04007E43 RID: 32323
			public int PointChange;

			// Token: 0x04007E44 RID: 32324
			public bool IsMvp;
		}

		// Token: 0x02001971 RID: 6513
		public struct CustomBattleGameData
		{
			// Token: 0x06010FFA RID: 69626 RVA: 0x00452EC9 File Offset: 0x004510C9
			public void Init()
			{
				this.GameType = 0U;
				this.Result = PkResultType.PkResult_Draw;
				this.Team1Data = new List<XLevelRewardDocument.CustomBattleInfo>();
				this.Team2Data = new List<XLevelRewardDocument.CustomBattleInfo>();
			}

			// Token: 0x04007E45 RID: 32325
			public uint GameType;

			// Token: 0x04007E46 RID: 32326
			public PkResultType Result;

			// Token: 0x04007E47 RID: 32327
			public List<XLevelRewardDocument.CustomBattleInfo> Team1Data;

			// Token: 0x04007E48 RID: 32328
			public List<XLevelRewardDocument.CustomBattleInfo> Team2Data;
		}

		// Token: 0x02001972 RID: 6514
		public struct WeekendPartyData
		{
			// Token: 0x06010FFB RID: 69627 RVA: 0x00452EF0 File Offset: 0x004510F0
			public void Init()
			{
				this.WarTime = 0U;
				this.Team1Score = 0U;
				this.Team2Score = 0U;
				this.PlayerRedBlue = 0U;
				this.AllRoleData = new List<WeekendPartyBattleRoleInfo>();
				this.HasRewardsID = new List<ulong>();
			}

			// Token: 0x04007E49 RID: 32329
			public uint WarTime;

			// Token: 0x04007E4A RID: 32330
			public List<WeekendPartyBattleRoleInfo> AllRoleData;

			// Token: 0x04007E4B RID: 32331
			public uint Team1Score;

			// Token: 0x04007E4C RID: 32332
			public uint Team2Score;

			// Token: 0x04007E4D RID: 32333
			public uint PlayerRedBlue;

			// Token: 0x04007E4E RID: 32334
			public List<ulong> HasRewardsID;
		}

		// Token: 0x02001973 RID: 6515
		public struct HeroBattleData
		{
			// Token: 0x06010FFC RID: 69628 RVA: 0x00452F28 File Offset: 0x00451128
			public void Init()
			{
				this.MvpHeroID = 1U;
				this.KillMax = 0;
				this.AssitMax = 0;
				this.DamageMax = 0UL;
				this.BeHitMax = 0U;
				this.DeathMin = int.MaxValue;
				this.DayJoinReward = new List<ItemBrief>();
				this.WinReward = new List<ItemBrief>();
				this.Team1Data = new List<XLevelRewardDocument.PVPRoleInfo>();
				this.Team2Data = new List<XLevelRewardDocument.PVPRoleInfo>();
			}

			// Token: 0x04007E4F RID: 32335
			public HeroBattleOver Result;

			// Token: 0x04007E50 RID: 32336
			public uint MvpHeroID;

			// Token: 0x04007E51 RID: 32337
			public int KillMax;

			// Token: 0x04007E52 RID: 32338
			public int DeathMin;

			// Token: 0x04007E53 RID: 32339
			public int AssitMax;

			// Token: 0x04007E54 RID: 32340
			public ulong DamageMax;

			// Token: 0x04007E55 RID: 32341
			public uint BeHitMax;

			// Token: 0x04007E56 RID: 32342
			public ulong DamageMaxUid;

			// Token: 0x04007E57 RID: 32343
			public ulong BeHitMaxUid;

			// Token: 0x04007E58 RID: 32344
			public List<ItemBrief> DayJoinReward;

			// Token: 0x04007E59 RID: 32345
			public List<ItemBrief> WinReward;

			// Token: 0x04007E5A RID: 32346
			public XLevelRewardDocument.PVPRoleInfo MvpData;

			// Token: 0x04007E5B RID: 32347
			public List<XLevelRewardDocument.PVPRoleInfo> Team1Data;

			// Token: 0x04007E5C RID: 32348
			public List<XLevelRewardDocument.PVPRoleInfo> Team2Data;
		}

		// Token: 0x02001974 RID: 6516
		public struct GuildMineData
		{
			// Token: 0x06010FFD RID: 69629 RVA: 0x00452F91 File Offset: 0x00451191
			public void Init()
			{
				this.mine = 0U;
				this.item = new List<ItemBrief>();
			}

			// Token: 0x04007E5D RID: 32349
			public uint mine;

			// Token: 0x04007E5E RID: 32350
			public List<ItemBrief> item;
		}

		// Token: 0x02001975 RID: 6517
		public struct RaceData
		{
			// Token: 0x06010FFE RID: 69630 RVA: 0x00452FA8 File Offset: 0x004511A8
			public void Init()
			{
				this.rolename = new List<string>();
				this.profession = new List<int>();
				this.item = new List<List<ItemBrief>>();
				this.time = new List<uint>();
				this.petid = new List<uint>();
				this.rank = new List<uint>();
			}

			// Token: 0x04007E5F RID: 32351
			public List<string> rolename;

			// Token: 0x04007E60 RID: 32352
			public List<int> profession;

			// Token: 0x04007E61 RID: 32353
			public List<List<ItemBrief>> item;

			// Token: 0x04007E62 RID: 32354
			public List<uint> time;

			// Token: 0x04007E63 RID: 32355
			public List<uint> petid;

			// Token: 0x04007E64 RID: 32356
			public List<uint> rank;
		}

		// Token: 0x02001976 RID: 6518
		public struct InvFightData
		{
			// Token: 0x06010FFF RID: 69631 RVA: 0x00452FF8 File Offset: 0x004511F8
			public void Init()
			{
				this.rivalName = "";
				this.isWin = false;
			}

			// Token: 0x04007E65 RID: 32357
			public string rivalName;

			// Token: 0x04007E66 RID: 32358
			public bool isWin;
		}

		// Token: 0x02001977 RID: 6519
		public struct SkyArenaData
		{
			// Token: 0x06011000 RID: 69632 RVA: 0x00453010 File Offset: 0x00451210
			public void Init()
			{
				this.roleid = new List<ulong>();
				this.killcount = new List<int>();
				this.deathcount = new List<int>();
				this.damage = new List<ulong>();
				this.ismvp = new List<bool>();
				this.floor = 0U;
				this.item = new List<ItemBrief>();
			}

			// Token: 0x04007E67 RID: 32359
			public List<ulong> roleid;

			// Token: 0x04007E68 RID: 32360
			public List<int> killcount;

			// Token: 0x04007E69 RID: 32361
			public List<int> deathcount;

			// Token: 0x04007E6A RID: 32362
			public List<ulong> damage;

			// Token: 0x04007E6B RID: 32363
			public List<bool> ismvp;

			// Token: 0x04007E6C RID: 32364
			public uint floor;

			// Token: 0x04007E6D RID: 32365
			public List<ItemBrief> item;
		}

		// Token: 0x02001978 RID: 6520
		public struct AbyssPartyData
		{
			// Token: 0x06011001 RID: 69633 RVA: 0x00453067 File Offset: 0x00451267
			public void Init()
			{
				this.AbysssPartyListId = 0;
				this.Time = 0U;
				this.item = new List<ItemBrief>();
			}

			// Token: 0x04007E6E RID: 32366
			public int AbysssPartyListId;

			// Token: 0x04007E6F RID: 32367
			public uint Time;

			// Token: 0x04007E70 RID: 32368
			public List<ItemBrief> item;
		}

		// Token: 0x02001979 RID: 6521
		public struct BigMeleeData
		{
			// Token: 0x06011002 RID: 69634 RVA: 0x00453083 File Offset: 0x00451283
			public void Init()
			{
				this.rank = 0U;
				this.score = 0U;
				this.kill = 0U;
				this.death = 0U;
				this.item = new List<ItemBrief>();
			}

			// Token: 0x04007E71 RID: 32369
			public uint rank;

			// Token: 0x04007E72 RID: 32370
			public uint score;

			// Token: 0x04007E73 RID: 32371
			public uint kill;

			// Token: 0x04007E74 RID: 32372
			public uint death;

			// Token: 0x04007E75 RID: 32373
			public List<ItemBrief> item;
		}

		// Token: 0x0200197A RID: 6522
		public struct BattleRankRoleInfo
		{
			// Token: 0x04007E76 RID: 32374
			public ulong RoleID;

			// Token: 0x04007E77 RID: 32375
			public uint Rank;

			// Token: 0x04007E78 RID: 32376
			public string Name;

			// Token: 0x04007E79 RID: 32377
			public string ServerName;

			// Token: 0x04007E7A RID: 32378
			public uint KillCount;

			// Token: 0x04007E7B RID: 32379
			public uint CombKill;

			// Token: 0x04007E7C RID: 32380
			public uint DeathCount;

			// Token: 0x04007E7D RID: 32381
			public bool isMVP;

			// Token: 0x04007E7E RID: 32382
			public ulong Damage;

			// Token: 0x04007E7F RID: 32383
			public int RoleProf;

			// Token: 0x04007E80 RID: 32384
			public uint Point;
		}

		// Token: 0x0200197B RID: 6523
		public struct BattleFieldData
		{
			// Token: 0x06011003 RID: 69635 RVA: 0x004530AD File Offset: 0x004512AD
			public void Init()
			{
				this.allend = false;
				this.MemberData = new List<XLevelRewardDocument.BattleRankRoleInfo>();
				this.item = new List<ItemBrief>();
			}

			// Token: 0x04007E81 RID: 32385
			public bool allend;

			// Token: 0x04007E82 RID: 32386
			public List<XLevelRewardDocument.BattleRankRoleInfo> MemberData;

			// Token: 0x04007E83 RID: 32387
			public List<ItemBrief> item;
		}

		// Token: 0x0200197C RID: 6524
		public struct GerenalData
		{
			// Token: 0x06011004 RID: 69636 RVA: 0x004530D0 File Offset: 0x004512D0
			public void Init()
			{
				this.Rank = 0U;
				this.Stars = new List<uint>();
				this.Items = new List<ItemBrief>();
				this.LevelFinishTime = 0U;
				this.StartLevel = 0U;
				this.StartPercent = 0f;
				this.TotalExpPercent = 0f;
				this.CurrentExpPercent = 0f;
				this.GrowExpPercent = 0f;
				this.TotalExp = 0f;
				this.SwitchLeftTime = 0;
				this.GuildExp = 0U;
				this.GuildContribution = 0U;
				this.GuildDragonCoin = 0U;
				this.GoldGroupReward = null;
				this.isHelper = false;
				this.noneReward = false;
				this.isSeal = false;
			}

			// Token: 0x04007E84 RID: 32388
			public uint Rank;

			// Token: 0x04007E85 RID: 32389
			public uint Score;

			// Token: 0x04007E86 RID: 32390
			public List<uint> Stars;

			// Token: 0x04007E87 RID: 32391
			public List<ItemBrief> Items;

			// Token: 0x04007E88 RID: 32392
			public uint LevelFinishTime;

			// Token: 0x04007E89 RID: 32393
			public uint StartLevel;

			// Token: 0x04007E8A RID: 32394
			public float StartPercent;

			// Token: 0x04007E8B RID: 32395
			public float TotalExpPercent;

			// Token: 0x04007E8C RID: 32396
			public float CurrentExpPercent;

			// Token: 0x04007E8D RID: 32397
			public float GrowExpPercent;

			// Token: 0x04007E8E RID: 32398
			public float TotalExp;

			// Token: 0x04007E8F RID: 32399
			public float GuildBuff;

			// Token: 0x04007E90 RID: 32400
			public int SwitchLeftTime;

			// Token: 0x04007E91 RID: 32401
			public uint GuildExp;

			// Token: 0x04007E92 RID: 32402
			public uint GuildContribution;

			// Token: 0x04007E93 RID: 32403
			public uint GuildDragonCoin;

			// Token: 0x04007E94 RID: 32404
			public ItemBrief GoldGroupReward;

			// Token: 0x04007E95 RID: 32405
			public bool isHelper;

			// Token: 0x04007E96 RID: 32406
			public bool noneReward;

			// Token: 0x04007E97 RID: 32407
			public bool isSeal;
		}

		// Token: 0x0200197D RID: 6525
		public struct LevelRewardRoleData
		{
			// Token: 0x06011005 RID: 69637 RVA: 0x00453178 File Offset: 0x00451378
			public void Init()
			{
				this.uid = 0UL;
				this.Name = "";
				this.Level = 0U;
				this.isLeader = false;
				this.isHelper = false;
				this.noneReward = false;
				this.ProfID = 0;
				this.Rank = 0U;
				this.BoxID = 0;
				this.chestList = new List<BattleRewardChest>();
			}

			// Token: 0x04007E98 RID: 32408
			public ulong uid;

			// Token: 0x04007E99 RID: 32409
			public string Name;

			// Token: 0x04007E9A RID: 32410
			public uint Level;

			// Token: 0x04007E9B RID: 32411
			public bool isLeader;

			// Token: 0x04007E9C RID: 32412
			public bool isHelper;

			// Token: 0x04007E9D RID: 32413
			public bool noneReward;

			// Token: 0x04007E9E RID: 32414
			public int ProfID;

			// Token: 0x04007E9F RID: 32415
			public uint Rank;

			// Token: 0x04007EA0 RID: 32416
			public int BoxID;

			// Token: 0x04007EA1 RID: 32417
			public uint ServerID;

			// Token: 0x04007EA2 RID: 32418
			public List<BattleRewardChest> chestList;
		}

		// Token: 0x0200197E RID: 6526
		public struct SelectChestData
		{
			// Token: 0x06011006 RID: 69638 RVA: 0x004531D5 File Offset: 0x004513D5
			public void Init()
			{
				this.Player.Init();
				this.Others = new List<XLevelRewardDocument.LevelRewardRoleData>();
				this.SelectLeftTime = 0;
			}

			// Token: 0x04007EA3 RID: 32419
			public XLevelRewardDocument.LevelRewardRoleData Player;

			// Token: 0x04007EA4 RID: 32420
			public List<XLevelRewardDocument.LevelRewardRoleData> Others;

			// Token: 0x04007EA5 RID: 32421
			public int SelectLeftTime;
		}

		// Token: 0x0200197F RID: 6527
		public struct DragonCrusadeData
		{
			// Token: 0x06011007 RID: 69639 RVA: 0x004531F6 File Offset: 0x004513F6
			public void Init()
			{
				this.Player.Init();
				this.Others = new List<XLevelRewardDocument.LevelRewardRoleData>();
				this.BossDamageHP = 0;
				this.BossLeftHP = 0;
				this.MyResult = null;
			}

			// Token: 0x04007EA6 RID: 32422
			public XLevelRewardDocument.LevelRewardRoleData Player;

			// Token: 0x04007EA7 RID: 32423
			public List<XLevelRewardDocument.LevelRewardRoleData> Others;

			// Token: 0x04007EA8 RID: 32424
			public int BossDamageHP;

			// Token: 0x04007EA9 RID: 32425
			public int BossLeftHP;

			// Token: 0x04007EAA RID: 32426
			public DragonExpResult MyResult;
		}

		// Token: 0x02001980 RID: 6528
		public struct BattleData
		{
			// Token: 0x04007EAB RID: 32427
			public ulong uid;

			// Token: 0x04007EAC RID: 32428
			public string Name;

			// Token: 0x04007EAD RID: 32429
			public int ProfID;

			// Token: 0x04007EAE RID: 32430
			public bool isLeader;

			// Token: 0x04007EAF RID: 32431
			public uint Rank;

			// Token: 0x04007EB0 RID: 32432
			public ulong DamageTotal;

			// Token: 0x04007EB1 RID: 32433
			public float DamagePercent;

			// Token: 0x04007EB2 RID: 32434
			public ulong HealTotal;

			// Token: 0x04007EB3 RID: 32435
			public uint DeathCount;

			// Token: 0x04007EB4 RID: 32436
			public uint ComboCount;
		}

		// Token: 0x02001981 RID: 6529
		public struct QualifyingData
		{
			// Token: 0x06011008 RID: 69640 RVA: 0x00453225 File Offset: 0x00451425
			public void Init()
			{
				this.QualifyingResult = PkResultType.PkResult_Draw;
				this.QualifyingRankChange = 0;
				this.FirstRank = 0;
				this.QualifyingPointChange = 0;
				this.QualifyingHonorChange = 0U;
				this.QualifyingHonorItems = new List<ItemBrief>();
				this.myState = KKVsRoleState.KK_VS_ROLE_NORMAL;
				this.opState = KKVsRoleState.KK_VS_ROLE_NORMAL;
			}

			// Token: 0x04007EB5 RID: 32437
			public PkResultType QualifyingResult;

			// Token: 0x04007EB6 RID: 32438
			public int QualifyingRankChange;

			// Token: 0x04007EB7 RID: 32439
			public int FirstRank;

			// Token: 0x04007EB8 RID: 32440
			public int QualifyingPointChange;

			// Token: 0x04007EB9 RID: 32441
			public uint QualifyingHonorChange;

			// Token: 0x04007EBA RID: 32442
			public List<ItemBrief> QualifyingHonorItems;

			// Token: 0x04007EBB RID: 32443
			public KKVsRoleState myState;

			// Token: 0x04007EBC RID: 32444
			public KKVsRoleState opState;
		}

		// Token: 0x02001982 RID: 6530
		public struct BattleRoyaleData
		{
			// Token: 0x06011009 RID: 69641 RVA: 0x00453264 File Offset: 0x00451464
			public void Init()
			{
				this.SelfRank = 0U;
				this.AllRank = 0U;
				this.KillCount = 0U;
				this.KilledBy = "";
				this.LiveTime = 0U;
				this.AddPoint = 0;
			}

			// Token: 0x04007EBD RID: 32445
			public uint SelfRank;

			// Token: 0x04007EBE RID: 32446
			public uint AllRank;

			// Token: 0x04007EBF RID: 32447
			public uint KillCount;

			// Token: 0x04007EC0 RID: 32448
			public string KilledBy;

			// Token: 0x04007EC1 RID: 32449
			public uint LiveTime;

			// Token: 0x04007EC2 RID: 32450
			public int AddPoint;
		}
	}
}
