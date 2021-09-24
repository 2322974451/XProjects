using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCombatStatisticsDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCombatStatisticsDocument.uuID;
			}
		}

		public bool bShowDps
		{
			get
			{
				return this.m_bShowDps;
			}
		}

		public List<XCombatStatisticsInfo> StatisticsList
		{
			get
			{
				return this.m_StatisticsList;
			}
		}

		public double TotalDamage { get; set; }

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.m_RankBase = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("DpsBaseRank"));
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			SceneTable.RowData sceneData = XSingleton<XScene>.singleton.SceneData;
			this.m_DpsBase = sceneData.DPS[0];
			this.m_DpsDenominator = sceneData.DPS[1];
			this.m_bShowDps = (this.m_DpsDenominator > 0.0);
			this.bShowDamage = false;
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			XSingleton<XAttributeMgr>.singleton.XPlayerData.CombatReset();
			this.m_SkillReset.Reset();
			this.m_MobReset.Reset();
		}

		public void ReqDps()
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (!syncMode)
			{
				bool flag = this.bShowDamage;
				if (flag)
				{
					bool flag2 = this.DpsHandler != null && this.DpsHandler.IsVisible();
					if (flag2)
					{
						this.DpsHandler.SetInfo(XSingleton<XAttributeMgr>.singleton.XPlayerData.PrintDamage.ToString("F1"));
					}
				}
				else
				{
					double dps = XSingleton<XAttributeMgr>.singleton.XPlayerData.Dps;
					this._SetDps(dps);
				}
			}
		}

		public void OnGetDps(double dps)
		{
			this._SetDps(dps);
		}

		private void _SetDps(double dps)
		{
			bool flag = !this.bShowDps;
			if (!flag)
			{
				double dps2 = 0.0;
				double num = 0.0;
				bool flag2 = dps > 0.0;
				if (flag2)
				{
					num = this.m_RankBase;
					dps2 = dps;
					bool flag3 = dps > this.m_DpsBase;
					if (flag3)
					{
						num += (dps - this.m_DpsBase) / this.m_DpsDenominator;
					}
				}
				num = Math.Min(num, 99.0);
				bool flag4 = this.DpsHandler != null && this.DpsHandler.IsVisible();
				if (flag4)
				{
					this.DpsHandler.SetDps(dps2, num);
				}
			}
		}

		private void _ClearStatistics()
		{
			for (int i = 0; i < this.m_StatisticsList.Count; i++)
			{
				this.m_StatisticsList[i].Recycle();
			}
			this.m_StatisticsList.Clear();
			this.m_DicStatistics.Clear();
		}

		private void _BuildPlayerStatistics(BattleStatisticsNtf data)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			if (!flag)
			{
				XSkillMgr skillMgr = XSingleton<XEntityMgr>.singleton.Player.SkillMgr;
				bool flag2 = skillMgr == null;
				if (!flag2)
				{
					bool flag3 = data.skillCount.Count != data.skillID.Count || data.skillID.Count != data.skillValue.Count;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Count not the same. ", data.skillID.Count.ToString(), " ", data.skillCount.Count.ToString(), " ", data.skillValue.Count.ToString());
					}
					else
					{
						this.m_ServerSkillStatistics.Reset();
						for (int i = 0; i < data.skillID.Count; i++)
						{
							this.m_ServerSkillStatistics.OnCast(data.skillID[i], data.skillCount[i]);
							this.m_ServerSkillStatistics.OnCastDamage(data.skillID[i], data.skillValue[i]);
						}
						this.m_SkillStatistics.Reset();
						this.m_ServerSkillStatistics.EndTo(XSingleton<XEntityMgr>.singleton.Player, this.m_SkillStatistics, false);
						this._ProcessSkillStatistics();
					}
				}
			}
		}

		private void _BuildPlayerStatistics()
		{
			XSecuritySkillInfo xsecuritySkillInfo = XSecuritySkillInfo.TryGetStatistics(XSingleton<XEntityMgr>.singleton.Player);
			bool flag = xsecuritySkillInfo == null;
			if (!flag)
			{
				XAttributes attributes = XSingleton<XEntityMgr>.singleton.Player.Attributes;
				XSkillMgr skillMgr = XSingleton<XEntityMgr>.singleton.Player.SkillMgr;
				bool flag2 = attributes == null || skillMgr == null;
				if (!flag2)
				{
					this.m_SkillStatistics.Reset();
					xsecuritySkillInfo.EndTo(XSingleton<XEntityMgr>.singleton.Player, this.m_SkillStatistics, false);
					this._ProcessSkillStatistics();
				}
			}
		}

		private void _ProcessSkillStatistics()
		{
			XCombatStatisticsInfo data = XDataPool<XCombatStatisticsInfo>.GetData();
			bool flag = !data.Set(this.m_SkillStatistics.NormalAttackInfo, XSingleton<XEntityMgr>.singleton.Player, this.m_SkillReset.NormalAttackInfo);
			if (flag)
			{
				data.Recycle();
			}
			else
			{
				data.name = XStringDefineProxy.GetString("PhysicalAttack");
				data.CutName();
				this.m_StatisticsList.Add(data);
				this.m_DicStatistics[data.name] = data;
			}
			for (int i = 0; i < this.m_SkillStatistics.SkillInfoList.Count; i++)
			{
				XCombatStatisticsInfo data2 = XDataPool<XCombatStatisticsInfo>.GetData();
				bool flag2 = !data2.Set(this.m_SkillStatistics.SkillInfoList[i], XSingleton<XEntityMgr>.singleton.Player, this.m_SkillReset.GetSkillInfoByID(this.m_SkillStatistics.SkillInfoList[i]._SkillID));
				if (flag2)
				{
					data2.Recycle();
				}
				else
				{
					this.m_StatisticsList.Add(data2);
					this.m_DicStatistics[data2.name] = data2;
				}
			}
		}

		private void _BuildMobsStatistics(BattleStatisticsNtf data)
		{
			bool flag = data.mobCount.Count != data.mobID.Count || data.mobID.Count != data.mobValue.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Count not the same. ", data.mobID.Count.ToString(), " ", data.mobCount.Count.ToString(), " ", data.mobValue.Count.ToString());
			}
			else
			{
				this.m_ServerMobStatistics.Reset();
				for (int i = 0; i < data.mobID.Count; i++)
				{
					this.m_ServerMobStatistics.OnCast(data.mobID[i], data.mobCount[i]);
					this.m_ServerMobStatistics.OnCastDamage(data.mobID[i], data.mobValue[i]);
				}
				this.m_MobStatistics.Reset();
				this.m_MobStatistics.Merge(this.m_ServerMobStatistics);
				this._ProcessMobStatistics();
			}
		}

		private void _BuildMobsStatistics()
		{
			XSecurityMobInfo xsecurityMobInfo = XSecurityMobInfo.TryGetStatistics(XSingleton<XEntityMgr>.singleton.Player);
			bool flag = xsecurityMobInfo == null;
			if (!flag)
			{
				this.m_MobStatistics.Reset();
				this.m_MobStatistics.Merge(xsecurityMobInfo);
				XSkillComponent skill = XSingleton<XEntityMgr>.singleton.Player.Skill;
				bool flag2 = skill != null && skill.SkillMobs != null;
				if (flag2)
				{
					for (int i = 0; i < skill.SkillMobs.Count; i++)
					{
						this.m_MobStatistics.Append(skill.SkillMobs[i]);
					}
				}
				XBuffComponent buffs = XSingleton<XEntityMgr>.singleton.Player.Buffs;
				bool flag3 = buffs != null;
				if (flag3)
				{
					for (int j = 0; j < buffs.BuffList.Count; j++)
					{
						XBuff xbuff = buffs.BuffList[j];
						bool flag4 = !xbuff.Valid || xbuff.EffectData.MobID == 0UL;
						if (!flag4)
						{
							XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(xbuff.EffectData.MobID);
							bool flag5 = entity == null;
							if (!flag5)
							{
								this.m_MobStatistics.Append(entity);
							}
						}
					}
				}
				this._ProcessMobStatistics();
			}
		}

		private void _ProcessMobStatistics()
		{
			for (int i = 0; i < this.m_MobStatistics.MobInfoList.Count; i++)
			{
				XCombatStatisticsInfo data = XDataPool<XCombatStatisticsInfo>.GetData();
				bool flag = !data.Set(this.m_MobStatistics.MobInfoList[i], XSingleton<XEntityMgr>.singleton.Player, this.m_MobReset.GetMobInfoByID(this.m_MobStatistics.MobInfoList[i]._TemplateID));
				if (flag)
				{
					data.Recycle();
				}
				else
				{
					XCombatStatisticsInfo xcombatStatisticsInfo;
					bool flag2 = this.m_DicStatistics.TryGetValue(data.name, out xcombatStatisticsInfo);
					if (flag2)
					{
						xcombatStatisticsInfo.MergeValue(data);
						data.Recycle();
					}
					else
					{
						this.m_StatisticsList.Add(data);
						this.m_DicStatistics[data.name] = data;
					}
				}
			}
		}

		public void ReqStatistics()
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				PtcC2G_BattleStatisticsReport proto = new PtcC2G_BattleStatisticsReport();
				XSingleton<XClientNetwork>.singleton.Send(proto);
			}
			else
			{
				this._ClearStatistics();
				this._BuildPlayerStatistics();
				this._BuildMobsStatistics();
				this.m_StatisticsList.Sort();
				this._BuildPercentage();
				this._RefreshUI();
			}
		}

		public void OnGetStatistics(BattleStatisticsNtf data)
		{
			bool flag = data == null;
			if (!flag)
			{
				this._ClearStatistics();
				this._BuildPlayerStatistics(data);
				this._BuildMobsStatistics(data);
				this.m_StatisticsList.Sort();
				this._BuildPercentage();
				this._RefreshUI();
			}
		}

		public void ResetStatistics()
		{
			this.m_SkillReset.Reset();
			this.m_SkillReset.Merge(this.m_SkillStatistics);
			this.m_MobReset.Reset();
			this.m_MobReset.Merge(this.m_MobStatistics);
		}

		private void _BuildPercentage()
		{
			this.TotalDamage = 0.0;
			for (int i = 0; i < this.m_StatisticsList.Count; i++)
			{
				XCombatStatisticsInfo xcombatStatisticsInfo = this.m_StatisticsList[i];
				this.TotalDamage += xcombatStatisticsInfo.value;
			}
			for (int j = 0; j < this.m_StatisticsList.Count; j++)
			{
				XCombatStatisticsInfo xcombatStatisticsInfo2 = this.m_StatisticsList[j];
				xcombatStatisticsInfo2.percent = ((this.TotalDamage == 0.0) ? 0f : ((float)(xcombatStatisticsInfo2.value / this.TotalDamage)));
			}
		}

		public void _RefreshUI()
		{
			bool flag = this.StatisticsHandler != null && this.StatisticsHandler.IsVisible();
			if (flag)
			{
				this.StatisticsHandler.RefreshData();
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CombatStatisticsDocument");

		public BattleDpsHandler DpsHandler;

		public BattleStatisticsHandler StatisticsHandler;

		private bool m_bShowDps;

		private double m_DpsBase;

		private double m_DpsDenominator;

		private double m_RankBase;

		public bool bShowDamage;

		private List<XCombatStatisticsInfo> m_StatisticsList = new List<XCombatStatisticsInfo>();

		private Dictionary<string, XCombatStatisticsInfo> m_DicStatistics = new Dictionary<string, XCombatStatisticsInfo>();

		private XSecuritySkillInfo m_ServerSkillStatistics = new XSecuritySkillInfo();

		private XSecurityMobInfo m_ServerMobStatistics = new XSecurityMobInfo();

		private XSecuritySkillInfo m_SkillStatistics = new XSecuritySkillInfo();

		private XSecurityMobInfo m_MobStatistics = new XSecurityMobInfo();

		private XSecuritySkillInfo m_SkillReset = new XSecuritySkillInfo();

		private XSecurityMobInfo m_MobReset = new XSecurityMobInfo();
	}
}
