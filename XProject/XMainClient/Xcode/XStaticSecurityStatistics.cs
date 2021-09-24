using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XStaticSecurityStatistics
	{

		public static void Reset()
		{
			XStaticSecurityStatistics._MonsterDamageInfo.Reset();
			XStaticSecurityStatistics._BossDamageInfo.Reset();
			XStaticSecurityStatistics._BossHPInfo.Reset();
			XStaticSecurityStatistics._MonsterHPInfo.Reset();
			XStaticSecurityStatistics._BossAIInfo.Reset();
			XStaticSecurityStatistics._MonsterAIInfo.Reset();
			XStaticSecurityStatistics._BossMoveDistance = 0f;
			XStaticSecurityStatistics._MonsterMoveDistance = 0f;
			XStaticSecurityStatistics._StartTime = DateTime.Now;
			XStaticSecurityStatistics._Inited = true;
		}

		public static void OnEnd()
		{
			bool flag = !XStaticSecurityStatistics._Inited;
			if (!flag)
			{
				XStaticSecurityStatistics._Inited = false;
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.World || XSingleton<XScene>.singleton.bSpectator;
				if (!flag2)
				{
					List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
					XSecurityStatistics xsecurityStatistics;
					for (int i = 0; i < all.Count; i++)
					{
						xsecurityStatistics = XSecurityStatistics.TryGetStatistics(all[i]);
						bool flag3 = xsecurityStatistics == null;
						if (!flag3)
						{
							xsecurityStatistics.Dump();
						}
					}
					bool flag4 = XSingleton<XEntityMgr>.singleton.Player != null;
					if (flag4)
					{
						XBattleEndArgs @event = XEventPool<XBattleEndArgs>.GetEvent();
						@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
					xsecurityStatistics = XSingleton<XAttributeMgr>.singleton.XPlayerData.SecurityStatistics;
					bool flag5 = xsecurityStatistics != null;
					if (flag5)
					{
						xsecurityStatistics.OnEnd();
					}
					XStaticSecurityStatistics._SendBattleStartData();
					XStaticSecurityStatistics._SendBattleFinishMainData();
					XStaticSecurityStatistics._SendBattleFinishOtherData();
				}
			}
		}

		public static void Append(string key, string value, List<string> keyList, List<string> valueList)
		{
			keyList.Add(key);
			valueList.Add(value);
		}

		public static void Append(string key, string value)
		{
			XStaticSecurityStatistics.Append(key, value, XStaticSecurityStatistics._KeyList, XStaticSecurityStatistics._ValueList);
		}

		public static void Append(string key, double value, List<string> keyList, List<string> valueList)
		{
			XStaticSecurityStatistics.Append(key, ((long)value).ToString(), keyList, valueList);
		}

		public static void Append(string key, double value)
		{
			bool flag = value == 0.0 || value == double.MaxValue;
			if (!flag)
			{
				XStaticSecurityStatistics.Append(key, value, XStaticSecurityStatistics._KeyList, XStaticSecurityStatistics._ValueList);
			}
		}

		public static void Append(string key, float value, List<string> keyList, List<string> valueList)
		{
			XStaticSecurityStatistics.Append(key, ((long)value).ToString(), keyList, valueList);
		}

		public static void Append(string key, float value)
		{
			bool flag = value == 0f || value == float.MaxValue;
			if (!flag)
			{
				XStaticSecurityStatistics.Append(key, value, XStaticSecurityStatistics._KeyList, XStaticSecurityStatistics._ValueList);
			}
		}

		private static void _SendBattleStartData()
		{
			PtcC2G_BattleLogReport ptcC2G_BattleLogReport = new PtcC2G_BattleLogReport();
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			ptcC2G_BattleLogReport.Data.roleid = xplayerData.RoleID;
			XStaticSecurityStatistics._KeyList = ptcC2G_BattleLogReport.Data.key;
			XStaticSecurityStatistics._ValueList = ptcC2G_BattleLogReport.Data.value;
			ptcC2G_BattleLogReport.Data.type = 1U;
			XStaticSecurityStatistics.Append("ClientStartTime", XStaticSecurityStatistics._StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_BattleLogReport);
			XStaticSecurityStatistics._KeyList = null;
			XStaticSecurityStatistics._ValueList = null;
		}

		private static void _SendBattleFinishMainData()
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			XSecurityStatistics securityStatistics = xplayerData.SecurityStatistics;
			bool flag = securityStatistics == null;
			if (!flag)
			{
				PtcC2G_BattleLogReport ptcC2G_BattleLogReport = new PtcC2G_BattleLogReport();
				ptcC2G_BattleLogReport.Data.roleid = xplayerData.RoleID;
				XStaticSecurityStatistics._KeyList = ptcC2G_BattleLogReport.Data.key;
				XStaticSecurityStatistics._ValueList = ptcC2G_BattleLogReport.Data.value;
				ptcC2G_BattleLogReport.Data.type = 2U;
				XStaticSecurityStatistics.Append("ClientEndTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				XBattleSkillDocument specificDocument = XDocuments.GetSpecificDocument<XBattleSkillDocument>(XBattleSkillDocument.uuID);
				int num = 0;
				while ((long)num < (long)((ulong)XBattleSkillDocument.Total_skill_slot))
				{
					XStaticSecurityStatistics.Append("ButtonClickCount" + (num + 1), specificDocument.GetSlotClicked(num));
					num++;
				}
				bool syncMode = XSingleton<XGame>.singleton.SyncMode;
				if (syncMode)
				{
					bool flag2 = securityStatistics.AttributeStatistics != null;
					if (flag2)
					{
						securityStatistics.AttributeStatistics.SendPlayerInitData();
					}
				}
				else
				{
					XStaticSecurityStatistics.Append("PlayerInitHP", securityStatistics._InitHp);
					XStaticSecurityStatistics.Append("PlayerInitMP", securityStatistics._InitMp);
					XStaticSecurityStatistics.Append("PlayerEndHP", securityStatistics._FinalHp);
					XStaticSecurityStatistics.Append("PlayerEndMP", securityStatistics._FinalMp);
					XStaticSecurityStatistics.Append("MoveTotal", securityStatistics._Distance);
					bool flag3 = securityStatistics.AttributeStatistics != null;
					if (flag3)
					{
						securityStatistics.AttributeStatistics.SendData();
					}
					bool flag4 = securityStatistics.DamageStatistics != null;
					if (flag4)
					{
						XSecurityDamageInfo.SendPlayerData(securityStatistics.DamageStatistics);
					}
					bool flag5 = securityStatistics.SkillStatistics != null;
					if (flag5)
					{
						XSecuritySkillInfo.SendPlayerData(XSingleton<XEntityMgr>.singleton.Player, securityStatistics.SkillStatistics);
					}
					XSecurityHPInfo.SendData(XStaticSecurityStatistics._BossHPInfo, "Boss");
					XSecurityHPInfo.SendData(XStaticSecurityStatistics._MonsterHPInfo, "Monster");
					XSecurityDamageInfo.SendEnemyData(XStaticSecurityStatistics._BossDamageInfo, "Boss");
					XSecurityDamageInfo.SendEnemyData(XStaticSecurityStatistics._MonsterDamageInfo, "Monster");
					XSecurityAIInfo.SendBossData(XStaticSecurityStatistics._BossAIInfo, "Boss");
					XSecurityAIInfo.SendEnemyData(XStaticSecurityStatistics._MonsterAIInfo, "Monster");
					XStaticSecurityStatistics.Append("BossMoveTotal", XStaticSecurityStatistics._BossMoveDistance);
					XStaticSecurityStatistics.Append("MonsterMoveTotal", XStaticSecurityStatistics._MonsterMoveDistance);
					XSingleton<XLevelStatistics>.singleton.SendData();
				}
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_BattleLogReport);
				XStaticSecurityStatistics._KeyList = null;
				XStaticSecurityStatistics._ValueList = null;
			}
		}

		private static void _SendBattleFinishOtherData()
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				XSecurityStatistics securityStatistics = xplayerData.SecurityStatistics;
				bool flag = securityStatistics == null;
				if (!flag)
				{
					PtcC2G_BattleLogReport ptcC2G_BattleLogReport = new PtcC2G_BattleLogReport();
					ptcC2G_BattleLogReport.Data.roleid = xplayerData.RoleID;
					XStaticSecurityStatistics._KeyList = ptcC2G_BattleLogReport.Data.key;
					XStaticSecurityStatistics._ValueList = ptcC2G_BattleLogReport.Data.value;
					ptcC2G_BattleLogReport.Data.type = 3U;
					XSecurityBuffInfo.SendPlayerData(securityStatistics.BuffStatistics);
					XSingleton<XClientNetwork>.singleton.Send(ptcC2G_BattleLogReport);
					XStaticSecurityStatistics._KeyList = null;
					XStaticSecurityStatistics._ValueList = null;
				}
			}
		}

		public static XSecurityHPInfo _BossHPInfo = new XSecurityHPInfo();

		public static XSecurityHPInfo _MonsterHPInfo = new XSecurityHPInfo();

		public static XSecurityDamageInfo _BossDamageInfo = new XSecurityDamageInfo();

		public static XSecurityDamageInfo _MonsterDamageInfo = new XSecurityDamageInfo();

		public static XSecurityAIInfo _BossAIInfo = new XSecurityAIInfo();

		public static XSecurityAIInfo _MonsterAIInfo = new XSecurityAIInfo();

		public static float _BossMoveDistance;

		public static float _MonsterMoveDistance;

		public static DateTime _StartTime;

		private static bool _Inited = false;

		private static List<string> _KeyList;

		private static List<string> _ValueList;
	}
}
