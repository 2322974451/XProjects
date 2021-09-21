using System;
using System.Text;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000966 RID: 2406
	internal class XRaceDocument : XDocComponent
	{
		// Token: 0x17002C55 RID: 11349
		// (get) Token: 0x060090F2 RID: 37106 RVA: 0x0014AF90 File Offset: 0x00149190
		public override uint ID
		{
			get
			{
				return XRaceDocument.uuID;
			}
		}

		// Token: 0x17002C56 RID: 11350
		// (get) Token: 0x060090F3 RID: 37107 RVA: 0x0014AFA8 File Offset: 0x001491A8
		public static XRaceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XRaceDocument.uuID) as XRaceDocument;
			}
		}

		// Token: 0x060090F4 RID: 37108 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x060090F5 RID: 37109 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnEnterSceneFinally()
		{
		}

		// Token: 0x060090F6 RID: 37110 RVA: 0x0014AFD3 File Offset: 0x001491D3
		public static void Execute(OnLoadedCallback callback = null)
		{
			XRaceDocument.AsyncLoader.AddTask("Table/Horse", XRaceDocument._HorseTable, false);
			XRaceDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060090F7 RID: 37111 RVA: 0x0014AFF8 File Offset: 0x001491F8
		public static Horse.RowData GetHorseRace(uint sceneId)
		{
			return XRaceDocument._HorseTable.GetBysceneid(sceneId);
		}

		// Token: 0x060090F8 RID: 37112 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x060090F9 RID: 37113 RVA: 0x0014B018 File Offset: 0x00149218
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HORSE_RACE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING;
			if (flag)
			{
				this.ReqRaceAllInfo();
				this.ReqDoodadItemList();
			}
		}

		// Token: 0x060090FA RID: 37114 RVA: 0x0014B05C File Offset: 0x0014925C
		public void ReqRaceAllInfo()
		{
			RpcC2G_HorseReConnect rpc = new RpcC2G_HorseReConnect();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x060090FB RID: 37115 RVA: 0x0014B07C File Offset: 0x0014927C
		public void ReqDoodadItemList()
		{
			RpcC2G_DoodadItemAllSkillReq rpc = new RpcC2G_DoodadItemAllSkillReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x060090FC RID: 37116 RVA: 0x0014B09C File Offset: 0x0014929C
		public void RefreshAllInfo(HorseReConnectRes oRes)
		{
			this.RefreshRank(oRes.rank);
			this.RaceComplete(oRes.selfarrive);
			this.RaceEndLeftTime(oRes.otherreach);
		}

		// Token: 0x060090FD RID: 37117 RVA: 0x0014B0C8 File Offset: 0x001492C8
		public void RefreshRank(HorseRank data)
		{
			bool flag = this.RaceHandler != null && data != null;
			if (flag)
			{
				bool rankSpecified = data.rankSpecified;
				if (rankSpecified)
				{
					this.RaceHandler.RefreshRank(data.rank);
				}
				bool turnsSpecified = data.turnsSpecified;
				if (turnsSpecified)
				{
					this.RaceHandler.RefreshLap(data.turns);
				}
			}
		}

		// Token: 0x060090FE RID: 37118 RVA: 0x0014B124 File Offset: 0x00149324
		public void RefreshTime(HorseCountDownTime data)
		{
			bool flag = this.RaceHandler != null && data != null;
			if (flag)
			{
				bool timeSpecified = data.timeSpecified;
				if (timeSpecified)
				{
					this.RaceHandler.RefreshTime(data.time / 1000f);
				}
			}
		}

		// Token: 0x060090FF RID: 37119 RVA: 0x0014B16C File Offset: 0x0014936C
		public void RaceComplete(HorseFinal data)
		{
			bool flag = this.RaceHandler != null && data != null;
			if (flag)
			{
				bool rankSpecified = data.rankSpecified;
				if (rankSpecified)
				{
					this.RaceHandler.RefreshRank(data.rank);
					this.RaceHandler.ShowRank(data.rank);
				}
				bool turnsSpecified = data.turnsSpecified;
				if (turnsSpecified)
				{
					this.RaceHandler.RefreshLap(data.turns);
				}
				bool timeSpecified = data.timeSpecified;
				if (timeSpecified)
				{
					this.RaceHandler.RefreshTime(data.time);
				}
				this.RaceHandler.RaceEnd();
			}
		}

		// Token: 0x06009100 RID: 37120 RVA: 0x0014B208 File Offset: 0x00149408
		public void RaceEndLeftTime(HorseAnimation data)
		{
			bool flag = this.RaceHandler != null && data != null;
			if (flag)
			{
				bool timeSpecified = data.timeSpecified;
				if (timeSpecified)
				{
					this.RaceHandler.ShowEndLeftTime(data.time / 1000f);
				}
			}
		}

		// Token: 0x06009101 RID: 37121 RVA: 0x0014B250 File Offset: 0x00149450
		public void UseDoodad(ItemBuffOpArg oArg, ItemBuffOpRes oRes)
		{
			bool flag = this.RaceHandler != null;
			if (flag)
			{
				bool flag2 = oArg.indexSpecified && oArg.op == 3U;
				if (flag2)
				{
					this.RaceHandler.UseDoodad(oArg.index);
				}
			}
		}

		// Token: 0x06009102 RID: 37122 RVA: 0x0014B29C File Offset: 0x0014949C
		public void AddInfo(DoodadItemUseNtf data)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_BattleShowInfoHandler == null;
			if (!flag)
			{
				XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(data.roleid);
				BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)data.buffid, 1);
				bool flag2 = entity == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("entity not found: {0}", data.roleid), null, null, null, null, null);
				}
				else
				{
					bool flag3 = buffData == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("RaceAddInfo: Buff data not found: [{0} {1}]", data.buffid, 1), null, null, null, null, null);
					}
					else
					{
						bool flag4 = data.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						string arg;
						if (flag4)
						{
							arg = BattleShowInfoHandler.blue;
						}
						else
						{
							arg = BattleShowInfoHandler.red;
						}
						StringBuilder stringBuilder = new StringBuilder();
						bool flag5 = false;
						for (int i = 0; i < buffData.BuffName.Length; i++)
						{
							bool flag6 = buffData.BuffName[i] == '[';
							if (flag6)
							{
								flag5 = true;
							}
							bool flag7 = buffData.BuffName[i] == ')';
							if (flag7)
							{
								flag5 = false;
							}
							bool flag8 = flag5;
							if (flag8)
							{
								stringBuilder.Append(buffData.BuffName[i]);
							}
							bool flag9 = buffData.BuffName[i] == '(';
							if (flag9)
							{
								flag5 = true;
							}
							bool flag10 = buffData.BuffName[i] == ']';
							if (flag10)
							{
								flag5 = false;
							}
						}
						string newInfo = string.Format(XSingleton<XStringTable>.singleton.GetString("RACE_GAME_INFO"), arg, entity.Name, stringBuilder.ToString());
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_BattleShowInfoHandler.AddInfo(newInfo);
					}
				}
			}
		}

		// Token: 0x0400300C RID: 12300
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XRaceDocument");

		// Token: 0x0400300D RID: 12301
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400300E RID: 12302
		private static Horse _HorseTable = new Horse();

		// Token: 0x0400300F RID: 12303
		public RaceBattleHandler RaceHandler = null;
	}
}
