using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008D3 RID: 2259
	internal class XCombatStatisticsDocument : XDocComponent
	{
		// Token: 0x17002AB4 RID: 10932
		// (get) Token: 0x060088A7 RID: 34983 RVA: 0x0011BA18 File Offset: 0x00119C18
		public override uint ID
		{
			get
			{
				return XCombatStatisticsDocument.uuID;
			}
		}

		// Token: 0x17002AB5 RID: 10933
		// (get) Token: 0x060088A8 RID: 34984 RVA: 0x0011BA30 File Offset: 0x00119C30
		public bool bShowDps
		{
			get
			{
				return this.m_bShowDps;
			}
		}

		// Token: 0x17002AB6 RID: 10934
		// (get) Token: 0x060088A9 RID: 34985 RVA: 0x0011BA48 File Offset: 0x00119C48
		public List<XCombatStatisticsInfo> StatisticsList
		{
			get
			{
				return this.m_StatisticsList;
			}
		}

		// Token: 0x17002AB7 RID: 10935
		// (get) Token: 0x060088AA RID: 34986 RVA: 0x0011BA60 File Offset: 0x00119C60
		// (set) Token: 0x060088AB RID: 34987 RVA: 0x0011BA68 File Offset: 0x00119C68
		public double TotalDamage { get; set; }

		// Token: 0x060088AC RID: 34988 RVA: 0x0011BA71 File Offset: 0x00119C71
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.m_RankBase = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("DpsBaseRank"));
		}

		// Token: 0x060088AD RID: 34989 RVA: 0x0011BA98 File Offset: 0x00119C98
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			SceneTable.RowData sceneData = XSingleton<XScene>.singleton.SceneData;
			this.m_DpsBase = sceneData.DPS[0];
			this.m_DpsDenominator = sceneData.DPS[1];
			this.m_bShowDps = (this.m_DpsDenominator > 0.0);
			this.bShowDamage = false;
		}

		// Token: 0x060088AE RID: 34990 RVA: 0x0011BAFE File Offset: 0x00119CFE
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			XSingleton<XAttributeMgr>.singleton.XPlayerData.CombatReset();
			this.m_SkillReset.Reset();
			this.m_MobReset.Reset();
		}

		// Token: 0x060088AF RID: 34991 RVA: 0x0011BB30 File Offset: 0x00119D30
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

		// Token: 0x060088B0 RID: 34992 RVA: 0x0011BBBA File Offset: 0x00119DBA
		public void OnGetDps(double dps)
		{
			this._SetDps(dps);
		}

		// Token: 0x060088B1 RID: 34993 RVA: 0x0011BBC8 File Offset: 0x00119DC8
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

		// Token: 0x060088B2 RID: 34994 RVA: 0x0011BC74 File Offset: 0x00119E74
		private void _ClearStatistics()
		{
			for (int i = 0; i < this.m_StatisticsList.Count; i++)
			{
				this.m_StatisticsList[i].Recycle();
			}
			this.m_StatisticsList.Clear();
			this.m_DicStatistics.Clear();
		}

		// Token: 0x060088B3 RID: 34995 RVA: 0x0011BCC8 File Offset: 0x00119EC8
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

		// Token: 0x060088B4 RID: 34996 RVA: 0x0011BE4C File Offset: 0x0011A04C
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

		// Token: 0x060088B5 RID: 34997 RVA: 0x0011BED4 File Offset: 0x0011A0D4
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

		// Token: 0x060088B6 RID: 34998 RVA: 0x0011BFFC File Offset: 0x0011A1FC
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

		// Token: 0x060088B7 RID: 34999 RVA: 0x0011C134 File Offset: 0x0011A334
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

		// Token: 0x060088B8 RID: 35000 RVA: 0x0011C28C File Offset: 0x0011A48C
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

		// Token: 0x060088B9 RID: 35001 RVA: 0x0011C36C File Offset: 0x0011A56C
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

		// Token: 0x060088BA RID: 35002 RVA: 0x0011C3CC File Offset: 0x0011A5CC
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

		// Token: 0x060088BB RID: 35003 RVA: 0x0011C415 File Offset: 0x0011A615
		public void ResetStatistics()
		{
			this.m_SkillReset.Reset();
			this.m_SkillReset.Merge(this.m_SkillStatistics);
			this.m_MobReset.Reset();
			this.m_MobReset.Merge(this.m_MobStatistics);
		}

		// Token: 0x060088BC RID: 35004 RVA: 0x0011C454 File Offset: 0x0011A654
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

		// Token: 0x060088BD RID: 35005 RVA: 0x0011C50C File Offset: 0x0011A70C
		public void _RefreshUI()
		{
			bool flag = this.StatisticsHandler != null && this.StatisticsHandler.IsVisible();
			if (flag)
			{
				this.StatisticsHandler.RefreshData();
			}
		}

		// Token: 0x060088BE RID: 35006 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002B3F RID: 11071
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CombatStatisticsDocument");

		// Token: 0x04002B40 RID: 11072
		public BattleDpsHandler DpsHandler;

		// Token: 0x04002B41 RID: 11073
		public BattleStatisticsHandler StatisticsHandler;

		// Token: 0x04002B42 RID: 11074
		private bool m_bShowDps;

		// Token: 0x04002B43 RID: 11075
		private double m_DpsBase;

		// Token: 0x04002B44 RID: 11076
		private double m_DpsDenominator;

		// Token: 0x04002B45 RID: 11077
		private double m_RankBase;

		// Token: 0x04002B46 RID: 11078
		public bool bShowDamage;

		// Token: 0x04002B47 RID: 11079
		private List<XCombatStatisticsInfo> m_StatisticsList = new List<XCombatStatisticsInfo>();

		// Token: 0x04002B48 RID: 11080
		private Dictionary<string, XCombatStatisticsInfo> m_DicStatistics = new Dictionary<string, XCombatStatisticsInfo>();

		// Token: 0x04002B4A RID: 11082
		private XSecuritySkillInfo m_ServerSkillStatistics = new XSecuritySkillInfo();

		// Token: 0x04002B4B RID: 11083
		private XSecurityMobInfo m_ServerMobStatistics = new XSecurityMobInfo();

		// Token: 0x04002B4C RID: 11084
		private XSecuritySkillInfo m_SkillStatistics = new XSecuritySkillInfo();

		// Token: 0x04002B4D RID: 11085
		private XSecurityMobInfo m_MobStatistics = new XSecurityMobInfo();

		// Token: 0x04002B4E RID: 11086
		private XSecuritySkillInfo m_SkillReset = new XSecuritySkillInfo();

		// Token: 0x04002B4F RID: 11087
		private XSecurityMobInfo m_MobReset = new XSecurityMobInfo();
	}
}
