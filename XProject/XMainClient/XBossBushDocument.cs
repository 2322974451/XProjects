using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200097D RID: 2429
	internal class XBossBushDocument : XDocComponent
	{
		// Token: 0x17002C99 RID: 11417
		// (get) Token: 0x0600924C RID: 37452 RVA: 0x00151800 File Offset: 0x0014FA00
		public override uint ID
		{
			get
			{
				return XBossBushDocument.uuID;
			}
		}

		// Token: 0x0600924D RID: 37453 RVA: 0x00151817 File Offset: 0x0014FA17
		public static void Execute(OnLoadedCallback callback = null)
		{
			XBossBushDocument.AsyncLoader.AddTask("Table/BossRush", XBossBushDocument.bossRushTable, false);
			XBossBushDocument.AsyncLoader.AddTask("Table/BossRushBuff", XBossBushDocument.bossBuffTable, false);
			XBossBushDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600924E RID: 37454 RVA: 0x0012BF81 File Offset: 0x0012A181
		public override void OnGamePause(bool pause)
		{
			base.OnGamePause(pause);
		}

		// Token: 0x0600924F RID: 37455 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009250 RID: 37456 RVA: 0x00151854 File Offset: 0x0014FA54
		public override void OnEnterSceneFinally()
		{
			bool flag = DlgBase<BossRushDlg, BossRushBehavior>.singleton.isHallUI && DlgBase<BossRushDlg, BossRushBehavior>.singleton.backHall;
			if (flag)
			{
				DlgBase<BossRushDlg, BossRushBehavior>.singleton.backHall = false;
				DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_DailyAcitivity);
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BOSSRUSH;
			if (flag2)
			{
				DlgBase<BossRushDlg, BossRushBehavior>.singleton.OnBossFadein();
			}
		}

		// Token: 0x06009251 RID: 37457 RVA: 0x001518B8 File Offset: 0x0014FAB8
		public void SendQuery(BossRushReqStatus type)
		{
			RpcC2G_BossRushReq rpcC2G_BossRushReq = new RpcC2G_BossRushReq();
			rpcC2G_BossRushReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BossRushReq);
		}

		// Token: 0x06009252 RID: 37458 RVA: 0x001518E8 File Offset: 0x0014FAE8
		public void Resp(BossRushReqStatus type, BossRushData res)
		{
			this.isSendingRefreshMsg = false;
			this.respData = res;
			bool flag = this.leftChanllageCnt <= 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BOSSRUSH_T_USELESS"), "fece00");
				DlgBase<BossRushDlg, BossRushBehavior>.singleton.SetVisible(false, true);
			}
			else
			{
				bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_BossRush);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BOSSRUSH_UNLOCK"), "fece00");
				}
				else
				{
					bool flag3 = this.respData.confid == 0;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("BOSSRUSH_UNLOCK"), "fece00");
						XSingleton<XDebug>.singleton.AddGreenLog("bossrush server error! Make sure your level correct!", null, null, null, null, null);
						DlgBase<BossRushDlg, BossRushBehavior>.singleton.SetVisible(false, true);
					}
					else
					{
						this.bossRushRow = this.GetBossRushRow(res.confid);
						bool flag4 = false;
						for (int i = 0; i < XBossBushDocument.bossBuffTable.Table.Length; i++)
						{
							bool flag5 = XBossBushDocument.bossBuffTable.Table[i].BossRushBuffID == res.buffid1;
							if (flag5)
							{
								this.bossBuff1Row = XBossBushDocument.bossBuffTable.Table[i];
								bool flag6 = this.bossBuff1Row.RewardBuff > 0f;
								if (flag6)
								{
									flag4 = true;
									this.rwdRate = this.bossBuff1Row.RewardBuff;
								}
							}
							bool flag7 = XBossBushDocument.bossBuffTable.Table[i].BossRushBuffID == res.buffid2;
							if (flag7)
							{
								this.bossBuff2Row = XBossBushDocument.bossBuffTable.Table[i];
								bool flag8 = this.bossBuff2Row.RewardBuff > 0f;
								if (flag8)
								{
									flag4 = true;
									this.rwdRate = this.bossBuff2Row.RewardBuff;
								}
							}
						}
						bool flag9 = !flag4;
						if (flag9)
						{
							this.rwdRate = 1f;
						}
						this.entityRow = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID((uint)this.bossRushRow.bossid);
						this.presentRow = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(this.entityRow.PresentID);
						bool flag10 = type == BossRushReqStatus.BOSSRUSH_REQ_BASEDATA;
						if (flag10)
						{
							bool flag11 = DlgBase<NpcPopSpeekView, DlgBehaviourBase>.singleton.IsVisible();
							if (flag11)
							{
								DlgBase<NpcPopSpeekView, DlgBehaviourBase>.singleton.SetVisible(false, true);
							}
							bool flag12 = !DlgBase<BossRushDlg, BossRushBehavior>.singleton.IsVisible();
							if (flag12)
							{
								DlgBase<BossRushDlg, BossRushBehavior>.singleton.SetVisibleWithAnimation(true, null);
							}
							DlgBase<BossRushDlg, BossRushBehavior>.singleton.Refresh();
						}
						else
						{
							bool flag13 = DlgBase<NpcPopSpeekView, DlgBehaviourBase>.singleton.IsVisible();
							if (flag13)
							{
								DlgBase<NpcPopSpeekView, DlgBehaviourBase>.singleton.SetVisible(false, true);
							}
							DlgBase<BossRushDlg, BossRushBehavior>.singleton.OnResOpenAnimDlg();
						}
					}
				}
			}
		}

		// Token: 0x06009253 RID: 37459 RVA: 0x00151BA4 File Offset: 0x0014FDA4
		public BossRushTable.RowData GetBossRushRow(int confid)
		{
			return XBossBushDocument.bossRushTable.GetByqniqueid((short)confid);
		}

		// Token: 0x06009254 RID: 37460 RVA: 0x00151BC4 File Offset: 0x0014FDC4
		public void ParseRefresh()
		{
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("BossRushRefreshCost");
			string[] array = value.Split(XGlobalConfig.ListSeparator);
			this.refreshConfig.freeIndex = int.Parse(array[0]);
			this.refreshConfig.item1Index = int.Parse(array[1]) + this.refreshConfig.freeIndex;
			this.refreshConfig.item1Id = int.Parse(array[2]);
			this.refreshConfig.item2Id = int.Parse(array[3]);
			this.refreshConfig.item1Start = int.Parse(array[4]);
			this.refreshConfig.item1Add = int.Parse(array[5]);
			this.refreshConfig.item2Start = int.Parse(array[6]);
			this.refreshConfig.item2Add = int.Parse(array[7]);
		}

		// Token: 0x06009255 RID: 37461 RVA: 0x00151C94 File Offset: 0x0014FE94
		public BossRushBuffTable.RowData[] GetRandBuffs()
		{
			int num = Random.Range(0, XBossBushDocument.bossBuffTable.Table.Length);
			int num2 = Random.Range(0, XBossBushDocument.bossBuffTable.Table.Length);
			while (num == num2)
			{
				num2 = Random.Range(0, XBossBushDocument.bossBuffTable.Table.Length);
			}
			return new BossRushBuffTable.RowData[]
			{
				XBossBushDocument.bossBuffTable.Table[num],
				XBossBushDocument.bossBuffTable.Table[num2]
			};
		}

		// Token: 0x040030E0 RID: 12512
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBossBushDocument");

		// Token: 0x040030E1 RID: 12513
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040030E2 RID: 12514
		public static BossRushBuffTable bossBuffTable = new BossRushBuffTable();

		// Token: 0x040030E3 RID: 12515
		public static BossRushTable bossRushTable = new BossRushTable();

		// Token: 0x040030E4 RID: 12516
		public int leftChanllageCnt;

		// Token: 0x040030E5 RID: 12517
		public BossRushData respData;

		// Token: 0x040030E6 RID: 12518
		public BossRushTable.RowData bossRushRow;

		// Token: 0x040030E7 RID: 12519
		public BossRushBuffTable.RowData bossBuff1Row;

		// Token: 0x040030E8 RID: 12520
		public BossRushBuffTable.RowData bossBuff2Row;

		// Token: 0x040030E9 RID: 12521
		public XEntityStatistics.RowData entityRow;

		// Token: 0x040030EA RID: 12522
		public XEntityPresentation.RowData presentRow;

		// Token: 0x040030EB RID: 12523
		public XBossBushDocument.RefreshConf refreshConfig = default(XBossBushDocument.RefreshConf);

		// Token: 0x040030EC RID: 12524
		public UnitAppearance unitAppearance;

		// Token: 0x040030ED RID: 12525
		public float rwdRate = 1f;

		// Token: 0x040030EE RID: 12526
		public bool isSendingRefreshMsg = false;

		// Token: 0x02001967 RID: 6503
		public struct RefreshConf
		{
			// Token: 0x04007E12 RID: 32274
			public int freeIndex;

			// Token: 0x04007E13 RID: 32275
			public int item1Index;

			// Token: 0x04007E14 RID: 32276
			public int item1Id;

			// Token: 0x04007E15 RID: 32277
			public int item2Id;

			// Token: 0x04007E16 RID: 32278
			public int item1Start;

			// Token: 0x04007E17 RID: 32279
			public int item1Add;

			// Token: 0x04007E18 RID: 32280
			public int item2Start;

			// Token: 0x04007E19 RID: 32281
			public int item2Add;
		}
	}
}
