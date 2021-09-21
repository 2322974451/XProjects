using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B18 RID: 2840
	internal sealed class XStaticSecurityStatistics
	{
		// Token: 0x0600A717 RID: 42775 RVA: 0x001D7E28 File Offset: 0x001D6028
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

		// Token: 0x0600A718 RID: 42776 RVA: 0x001D7E9C File Offset: 0x001D609C
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

		// Token: 0x0600A719 RID: 42777 RVA: 0x001D7FA0 File Offset: 0x001D61A0
		public static void Append(string key, string value, List<string> keyList, List<string> valueList)
		{
			keyList.Add(key);
			valueList.Add(value);
		}

		// Token: 0x0600A71A RID: 42778 RVA: 0x001D7FB3 File Offset: 0x001D61B3
		public static void Append(string key, string value)
		{
			XStaticSecurityStatistics.Append(key, value, XStaticSecurityStatistics._KeyList, XStaticSecurityStatistics._ValueList);
		}

		// Token: 0x0600A71B RID: 42779 RVA: 0x001D7FC8 File Offset: 0x001D61C8
		public static void Append(string key, double value, List<string> keyList, List<string> valueList)
		{
			XStaticSecurityStatistics.Append(key, ((long)value).ToString(), keyList, valueList);
		}

		// Token: 0x0600A71C RID: 42780 RVA: 0x001D7FEC File Offset: 0x001D61EC
		public static void Append(string key, double value)
		{
			bool flag = value == 0.0 || value == double.MaxValue;
			if (!flag)
			{
				XStaticSecurityStatistics.Append(key, value, XStaticSecurityStatistics._KeyList, XStaticSecurityStatistics._ValueList);
			}
		}

		// Token: 0x0600A71D RID: 42781 RVA: 0x001D8030 File Offset: 0x001D6230
		public static void Append(string key, float value, List<string> keyList, List<string> valueList)
		{
			XStaticSecurityStatistics.Append(key, ((long)value).ToString(), keyList, valueList);
		}

		// Token: 0x0600A71E RID: 42782 RVA: 0x001D8054 File Offset: 0x001D6254
		public static void Append(string key, float value)
		{
			bool flag = value == 0f || value == float.MaxValue;
			if (!flag)
			{
				XStaticSecurityStatistics.Append(key, value, XStaticSecurityStatistics._KeyList, XStaticSecurityStatistics._ValueList);
			}
		}

		// Token: 0x0600A71F RID: 42783 RVA: 0x001D8090 File Offset: 0x001D6290
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

		// Token: 0x0600A720 RID: 42784 RVA: 0x001D8120 File Offset: 0x001D6320
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

		// Token: 0x0600A721 RID: 42785 RVA: 0x001D8388 File Offset: 0x001D6588
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

		// Token: 0x04003D95 RID: 15765
		public static XSecurityHPInfo _BossHPInfo = new XSecurityHPInfo();

		// Token: 0x04003D96 RID: 15766
		public static XSecurityHPInfo _MonsterHPInfo = new XSecurityHPInfo();

		// Token: 0x04003D97 RID: 15767
		public static XSecurityDamageInfo _BossDamageInfo = new XSecurityDamageInfo();

		// Token: 0x04003D98 RID: 15768
		public static XSecurityDamageInfo _MonsterDamageInfo = new XSecurityDamageInfo();

		// Token: 0x04003D99 RID: 15769
		public static XSecurityAIInfo _BossAIInfo = new XSecurityAIInfo();

		// Token: 0x04003D9A RID: 15770
		public static XSecurityAIInfo _MonsterAIInfo = new XSecurityAIInfo();

		// Token: 0x04003D9B RID: 15771
		public static float _BossMoveDistance;

		// Token: 0x04003D9C RID: 15772
		public static float _MonsterMoveDistance;

		// Token: 0x04003D9D RID: 15773
		public static DateTime _StartTime;

		// Token: 0x04003D9E RID: 15774
		private static bool _Inited = false;

		// Token: 0x04003D9F RID: 15775
		private static List<string> _KeyList;

		// Token: 0x04003DA0 RID: 15776
		private static List<string> _ValueList;
	}
}
