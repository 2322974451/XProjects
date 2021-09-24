using System;
using System.Text;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRaceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XRaceDocument.uuID;
			}
		}

		public static XRaceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XRaceDocument.uuID) as XRaceDocument;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XRaceDocument.AsyncLoader.AddTask("Table/Horse", XRaceDocument._HorseTable, false);
			XRaceDocument.AsyncLoader.Execute(callback);
		}

		public static Horse.RowData GetHorseRace(uint sceneId)
		{
			return XRaceDocument._HorseTable.GetBysceneid(sceneId);
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HORSE_RACE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING;
			if (flag)
			{
				this.ReqRaceAllInfo();
				this.ReqDoodadItemList();
			}
		}

		public void ReqRaceAllInfo()
		{
			RpcC2G_HorseReConnect rpc = new RpcC2G_HorseReConnect();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqDoodadItemList()
		{
			RpcC2G_DoodadItemAllSkillReq rpc = new RpcC2G_DoodadItemAllSkillReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void RefreshAllInfo(HorseReConnectRes oRes)
		{
			this.RefreshRank(oRes.rank);
			this.RaceComplete(oRes.selfarrive);
			this.RaceEndLeftTime(oRes.otherreach);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XRaceDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static Horse _HorseTable = new Horse();

		public RaceBattleHandler RaceHandler = null;
	}
}
