using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBossBushDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XBossBushDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XBossBushDocument.AsyncLoader.AddTask("Table/BossRush", XBossBushDocument.bossRushTable, false);
			XBossBushDocument.AsyncLoader.AddTask("Table/BossRushBuff", XBossBushDocument.bossBuffTable, false);
			XBossBushDocument.AsyncLoader.Execute(callback);
		}

		public override void OnGamePause(bool pause)
		{
			base.OnGamePause(pause);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

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

		public void SendQuery(BossRushReqStatus type)
		{
			RpcC2G_BossRushReq rpcC2G_BossRushReq = new RpcC2G_BossRushReq();
			rpcC2G_BossRushReq.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BossRushReq);
		}

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

		public BossRushTable.RowData GetBossRushRow(int confid)
		{
			return XBossBushDocument.bossRushTable.GetByqniqueid((short)confid);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XBossBushDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static BossRushBuffTable bossBuffTable = new BossRushBuffTable();

		public static BossRushTable bossRushTable = new BossRushTable();

		public int leftChanllageCnt;

		public BossRushData respData;

		public BossRushTable.RowData bossRushRow;

		public BossRushBuffTable.RowData bossBuff1Row;

		public BossRushBuffTable.RowData bossBuff2Row;

		public XEntityStatistics.RowData entityRow;

		public XEntityPresentation.RowData presentRow;

		public XBossBushDocument.RefreshConf refreshConfig = default(XBossBushDocument.RefreshConf);

		public UnitAppearance unitAppearance;

		public float rwdRate = 1f;

		public bool isSendingRefreshMsg = false;

		public struct RefreshConf
		{

			public int freeIndex;

			public int item1Index;

			public int item1Id;

			public int item2Id;

			public int item1Start;

			public int item1Add;

			public int item2Start;

			public int item2Add;
		}
	}
}
