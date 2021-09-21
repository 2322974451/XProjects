using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000938 RID: 2360
	internal class XGuildSalaryDocument : XDocComponent
	{
		// Token: 0x17002BF2 RID: 11250
		// (get) Token: 0x06008E84 RID: 36484 RVA: 0x0013BAD4 File Offset: 0x00139CD4
		public override uint ID
		{
			get
			{
				return XGuildSalaryDocument.uuID;
			}
		}

		// Token: 0x06008E85 RID: 36485 RVA: 0x0013BAEB File Offset: 0x00139CEB
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildSalaryDocument.AsyncLoader.AddTask("Table/GuildSalaryDesc", XGuildSalaryDocument.m_guildSalaryDesc, false);
			XGuildSalaryDocument.AsyncLoader.AddTask("Table/Guildsalary", XGuildSalaryDocument.m_guildSalaryTable, false);
			XGuildSalaryDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008E86 RID: 36486 RVA: 0x0013BB28 File Offset: 0x00139D28
		public static void OnTableLoaded()
		{
			XGuildSalaryDocument.TabIndexs.Clear();
			XGuildSalaryDocument.TabNames.Clear();
			XGuildSalaryDocument.GuildSalaryDescDic.Clear();
			int i = 0;
			int num = XGuildSalaryDocument.m_guildSalaryDesc.Table.Length;
			while (i < num)
			{
				bool flag = !XGuildSalaryDocument.TabIndexs.Contains(XGuildSalaryDocument.m_guildSalaryDesc.Table[i].Type);
				if (flag)
				{
					XGuildSalaryDocument.TabIndexs.Add(XGuildSalaryDocument.m_guildSalaryDesc.Table[i].Type);
					XGuildSalaryDocument.TabNames.Add(XSingleton<XCommon>.singleton.StringCombine("GuildSalaryTitle", XGuildSalaryDocument.m_guildSalaryDesc.Table[i].Type.ToString()));
				}
				List<GuildSalaryDesc.RowData> list;
				bool flag2 = !XGuildSalaryDocument.GuildSalaryDescDic.TryGetValue(XGuildSalaryDocument.m_guildSalaryDesc.Table[i].Type, out list);
				if (flag2)
				{
					list = new List<GuildSalaryDesc.RowData>();
					XGuildSalaryDocument.GuildSalaryDescDic.Add(XGuildSalaryDocument.m_guildSalaryDesc.Table[i].Type, list);
				}
				list.Add(XGuildSalaryDocument.m_guildSalaryDesc.Table[i]);
				i++;
			}
		}

		// Token: 0x06008E87 RID: 36487 RVA: 0x0013BC4C File Offset: 0x00139E4C
		public static string GetGrade(int grade)
		{
			int num = grade - 1;
			List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("GuildGrade");
			bool flag = num < stringList.Count && num >= 0;
			string result;
			if (flag)
			{
				result = stringList[num];
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06008E88 RID: 36488 RVA: 0x0013BC98 File Offset: 0x00139E98
		public static string GetGradeName(int grade)
		{
			int num = grade - 1;
			List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("GuildGradeName");
			bool flag = num < stringList.Count && num >= 0;
			string result;
			if (flag)
			{
				result = stringList[num];
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x17002BF3 RID: 11251
		// (get) Token: 0x06008E89 RID: 36489 RVA: 0x0013BCE4 File Offset: 0x00139EE4
		public List<GuildActivityRole> TopPlayers
		{
			get
			{
				return this.m_topPlayers;
			}
		}

		// Token: 0x17002BF4 RID: 11252
		// (get) Token: 0x06008E8B RID: 36491 RVA: 0x0013BD18 File Offset: 0x00139F18
		// (set) Token: 0x06008E8A RID: 36490 RVA: 0x0013BCFC File Offset: 0x00139EFC
		public bool HasRedPoint
		{
			get
			{
				return this.m_hasRedPoint;
			}
			set
			{
				this.m_hasRedPoint = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildBoon_Salay, true);
			}
		}

		// Token: 0x17002BF5 RID: 11253
		// (get) Token: 0x06008E8C RID: 36492 RVA: 0x0013BD30 File Offset: 0x00139F30
		public bool NotHasLastSalaryInfo
		{
			get
			{
				return this.m_lastLevel == 0U;
			}
		}

		// Token: 0x17002BF6 RID: 11254
		// (get) Token: 0x06008E8D RID: 36493 RVA: 0x0013BD4C File Offset: 0x00139F4C
		public uint CurScore
		{
			get
			{
				return this.m_curScore;
			}
		}

		// Token: 0x17002BF7 RID: 11255
		// (get) Token: 0x06008E8E RID: 36494 RVA: 0x0013BD64 File Offset: 0x00139F64
		public XGuildSalaryInfo Activity
		{
			get
			{
				return this.m_activity;
			}
		}

		// Token: 0x17002BF8 RID: 11256
		// (get) Token: 0x06008E8F RID: 36495 RVA: 0x0013BD7C File Offset: 0x00139F7C
		public XGuildSalaryInfo RoleNum
		{
			get
			{
				return this.m_roleNum;
			}
		}

		// Token: 0x17002BF9 RID: 11257
		// (get) Token: 0x06008E90 RID: 36496 RVA: 0x0013BD94 File Offset: 0x00139F94
		public XGuildSalaryInfo Prestige
		{
			get
			{
				return this.m_prestige;
			}
		}

		// Token: 0x17002BFA RID: 11258
		// (get) Token: 0x06008E91 RID: 36497 RVA: 0x0013BDAC File Offset: 0x00139FAC
		public XGuildSalaryInfo Exp
		{
			get
			{
				return this.m_exp;
			}
		}

		// Token: 0x17002BFB RID: 11259
		// (get) Token: 0x06008E92 RID: 36498 RVA: 0x0013BDC4 File Offset: 0x00139FC4
		public uint CurGrade
		{
			get
			{
				return this.m_curGrade;
			}
		}

		// Token: 0x17002BFC RID: 11260
		// (get) Token: 0x06008E93 RID: 36499 RVA: 0x0013BDDC File Offset: 0x00139FDC
		public uint LastScore
		{
			get
			{
				return this.m_lastScore;
			}
		}

		// Token: 0x17002BFD RID: 11261
		// (get) Token: 0x06008E94 RID: 36500 RVA: 0x0013BDF4 File Offset: 0x00139FF4
		public uint MulMaxScore
		{
			get
			{
				return this.m_mulMaxScore;
			}
		}

		// Token: 0x17002BFE RID: 11262
		// (get) Token: 0x06008E95 RID: 36501 RVA: 0x0013BE0C File Offset: 0x0013A00C
		public WageRewardState RewardState
		{
			get
			{
				return this.m_rewardState;
			}
		}

		// Token: 0x17002BFF RID: 11263
		// (get) Token: 0x06008E96 RID: 36502 RVA: 0x0013BE24 File Offset: 0x0013A024
		public uint LastGrade
		{
			get
			{
				return this.m_lastGrade;
			}
		}

		// Token: 0x17002C00 RID: 11264
		// (get) Token: 0x06008E97 RID: 36503 RVA: 0x0013BE3C File Offset: 0x0013A03C
		public GuildPosition LastPosition
		{
			get
			{
				return this.m_lastPosition;
			}
		}

		// Token: 0x17002C01 RID: 11265
		// (get) Token: 0x06008E98 RID: 36504 RVA: 0x0013BE54 File Offset: 0x0013A054
		public uint LastLevel
		{
			get
			{
				return this.m_lastLevel;
			}
		}

		// Token: 0x06008E99 RID: 36505 RVA: 0x0013BE6C File Offset: 0x0013A06C
		public XGuildSalaryInfo GetValue(int type)
		{
			XGuildSalaryInfo result = null;
			switch (type)
			{
			case 0:
				result = this.m_roleNum;
				break;
			case 1:
				result = this.m_prestige;
				break;
			case 2:
				result = this.m_activity;
				break;
			case 3:
				result = this.m_exp;
				break;
			}
			return result;
		}

		// Token: 0x06008E9A RID: 36506 RVA: 0x0013BEC0 File Offset: 0x0013A0C0
		public bool TryGetGuildSalary(uint guildLevel, out GuildSalaryTable.RowData rowData)
		{
			rowData = XGuildSalaryDocument.m_guildSalaryTable.GetByGuildLevel(guildLevel);
			return rowData != null;
		}

		// Token: 0x06008E9B RID: 36507 RVA: 0x0013BEE4 File Offset: 0x0013A0E4
		public void SendGuildWageReward()
		{
			bool flag = this.m_rewardState == WageRewardState.notreward;
			if (flag)
			{
				RpcC2M_GetGuildWageReward rpc = new RpcC2M_GetGuildWageReward();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

		// Token: 0x06008E9C RID: 36508 RVA: 0x0013BF14 File Offset: 0x0013A114
		public void ReceiveGuildWageReward(GetGuildWageReward res)
		{
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(res.errorcode);
			}
			else
			{
				this.HasRedPoint = false;
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalSuccess"), "fece00");
				this.m_rewardState = WageRewardState.rewarded;
				bool flag2 = DlgBase<GuildSalayDlg, GuildSalayBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<GuildSalayDlg, GuildSalayBehavior>.singleton.Refresh();
				}
			}
		}

		// Token: 0x06008E9D RID: 36509 RVA: 0x0013BF88 File Offset: 0x0013A188
		public void SendAskGuildWageInfo()
		{
			RpcC2M_AskGuildWageInfo rpc = new RpcC2M_AskGuildWageInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008E9E RID: 36510 RVA: 0x0013BFA8 File Offset: 0x0013A1A8
		public void ReceiveAskGuildWageInfo(AskGuildWageInfoRes res)
		{
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(res.errorcode);
			}
			else
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				uint level = specificDocument.BasicData.level;
				GuildSalaryTable.RowData byGuildLevel = XGuildSalaryDocument.m_guildSalaryTable.GetByGuildLevel(level);
				this.m_topPlayers = res.roles;
				this.m_roleNum.Init(res.rolenum, byGuildLevel, 0U);
				this.m_prestige.Init(res.prestige, byGuildLevel, 1U);
				this.m_exp.Init(res.exp, byGuildLevel, 3U);
				this.m_activity.Init(res.activity, byGuildLevel, 2U);
				this.m_rewardState = res.rewardstate;
				this.m_curScore = (this.m_roleNum.Score + this.m_prestige.Score + this.m_exp.Score + this.m_activity.Score) / 4U;
				this.m_curGrade = this.CalculateGrade(byGuildLevel.GuildReview, this.CurScore);
				this.m_lastScore = res.lastScore;
				this.m_lastGrade = res.wagelvl;
				this.m_lastLevel = res.guildlvl;
				this.m_lastPosition = (GuildPosition)res.lastposition;
				this.HasRedPoint = (res.rewardstate == WageRewardState.notreward);
				uint num = this.CalculateGradeMaxScore(byGuildLevel.GuildReview, this.m_lastScore);
				this.m_mulMaxScore = ((this.m_lastScore < num) ? (num - this.m_lastScore) : 0U);
				num = this.CalculateGradeMaxScore(byGuildLevel.GuildReview, this.m_curScore);
				this.CurMulScore = ((this.m_curScore < num) ? (num - this.m_curScore) : 0U);
				bool flag2 = DlgBase<GuildSalayDlg, GuildSalayBehavior>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<GuildSalayDlg, GuildSalayBehavior>.singleton.Refresh();
				}
			}
		}

		// Token: 0x06008E9F RID: 36511 RVA: 0x0013C16C File Offset: 0x0013A36C
		public uint GetNextGradeScore(uint GuildLevel, int Grade)
		{
			GuildSalaryTable.RowData byGuildLevel = XGuildSalaryDocument.m_guildSalaryTable.GetByGuildLevel(GuildLevel);
			int num = 4 - Grade;
			bool flag = num < 0;
			uint result;
			if (flag)
			{
				result = byGuildLevel.GuildReview[0];
			}
			else
			{
				bool flag2 = num >= 4;
				if (flag2)
				{
					result = 0U;
				}
				else
				{
					result = byGuildLevel.GuildReview[num];
				}
			}
			return result;
		}

		// Token: 0x06008EA0 RID: 36512 RVA: 0x0013C1BC File Offset: 0x0013A3BC
		public SeqListRef<uint> GetGuildSalayList(uint guildLevel, GuildPosition pos, uint grade)
		{
			GuildSalaryTable.RowData byGuildLevel = XGuildSalaryDocument.m_guildSalaryTable.GetByGuildLevel(guildLevel);
			XSingleton<XDebug>.singleton.AddGreenLog("rowData == null ?", guildLevel.ToString(), pos.ToString(), grade.ToString(), null, null);
			bool flag = byGuildLevel == null;
			SeqListRef<uint> result;
			if (flag)
			{
				result = default(SeqListRef<uint>);
			}
			else
			{
				bool flag2 = pos == GuildPosition.GPOS_LEADER;
				if (flag2)
				{
					switch (grade)
					{
					case 1U:
						result = byGuildLevel.SSalary1;
						break;
					case 2U:
						result = byGuildLevel.ASalary1;
						break;
					case 3U:
						result = byGuildLevel.BSalary1;
						break;
					case 4U:
						result = byGuildLevel.CSalary1;
						break;
					case 5U:
						result = byGuildLevel.DSalary1;
						break;
					default:
						result = byGuildLevel.DSalary1;
						break;
					}
				}
				else
				{
					bool flag3 = pos == GuildPosition.GPOS_VICELEADER;
					if (flag3)
					{
						switch (grade)
						{
						case 1U:
							result = byGuildLevel.SSalary2;
							break;
						case 2U:
							result = byGuildLevel.ASalary2;
							break;
						case 3U:
							result = byGuildLevel.BSalary2;
							break;
						case 4U:
							result = byGuildLevel.CSalary2;
							break;
						case 5U:
							result = byGuildLevel.DSalary2;
							break;
						default:
							result = byGuildLevel.DSalary2;
							break;
						}
					}
					else
					{
						bool flag4 = pos == GuildPosition.GPOS_OFFICER;
						if (flag4)
						{
							switch (grade)
							{
							case 1U:
								result = byGuildLevel.SSalary3;
								break;
							case 2U:
								result = byGuildLevel.ASalary3;
								break;
							case 3U:
								result = byGuildLevel.BSalary3;
								break;
							case 4U:
								result = byGuildLevel.CSalary3;
								break;
							case 5U:
								result = byGuildLevel.DSalary3;
								break;
							default:
								result = byGuildLevel.DSalary3;
								break;
							}
						}
						else
						{
							bool flag5 = pos == GuildPosition.GPOS_ELITEMEMBER;
							if (flag5)
							{
								switch (grade)
								{
								case 1U:
									result = byGuildLevel.SSalary4;
									break;
								case 2U:
									result = byGuildLevel.ASalary4;
									break;
								case 3U:
									result = byGuildLevel.BSalary4;
									break;
								case 4U:
									result = byGuildLevel.CSalary4;
									break;
								case 5U:
									result = byGuildLevel.DSalary4;
									break;
								default:
									result = byGuildLevel.DSalary4;
									break;
								}
							}
							else
							{
								bool flag6 = pos == GuildPosition.GPOS_MEMBER;
								if (flag6)
								{
									switch (grade)
									{
									case 1U:
										result = byGuildLevel.SSalary5;
										break;
									case 2U:
										result = byGuildLevel.ASalary5;
										break;
									case 3U:
										result = byGuildLevel.BSalary5;
										break;
									case 4U:
										result = byGuildLevel.CSalary5;
										break;
									case 5U:
										result = byGuildLevel.DSalary5;
										break;
									default:
										result = byGuildLevel.DSalary5;
										break;
									}
								}
								else
								{
									result = default(SeqListRef<uint>);
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06008EA1 RID: 36513 RVA: 0x0013C458 File Offset: 0x0013A658
		private uint CalculateGrade(uint[] scores, uint cur)
		{
			uint num = 1U;
			bool flag = scores != null;
			if (flag)
			{
				for (int i = scores.Length - 1; i >= 0; i--)
				{
					bool flag2 = cur < scores[i];
					if (!flag2)
					{
						break;
					}
					num += 1U;
				}
			}
			return num;
		}

		// Token: 0x06008EA2 RID: 36514 RVA: 0x0013C4AC File Offset: 0x0013A6AC
		private uint CalculateGradeMaxScore(uint[] scores, uint cur)
		{
			bool flag = scores != null && scores.Length != 0;
			uint result;
			if (flag)
			{
				uint num = scores[scores.Length - 1];
				for (int i = scores.Length - 1; i >= 0; i--)
				{
					bool flag2 = cur < scores[i];
					if (!flag2)
					{
						break;
					}
					num = scores[i];
				}
				result = num;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x17002C02 RID: 11266
		// (get) Token: 0x06008EA4 RID: 36516 RVA: 0x0013C514 File Offset: 0x0013A714
		// (set) Token: 0x06008EA3 RID: 36515 RVA: 0x0013C50B File Offset: 0x0013A70B
		public int SelectTabs { get; set; }

		// Token: 0x06008EA5 RID: 36517 RVA: 0x0013C51C File Offset: 0x0013A71C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<GuildSalayDlg, GuildSalayBehavior>.singleton.IsVisible();
			if (flag)
			{
				this.SendAskGuildWageInfo();
			}
		}

		// Token: 0x04002E7C RID: 11900
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildSalaryDocument");

		// Token: 0x04002E7D RID: 11901
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002E7E RID: 11902
		public static GuildSalaryDesc m_guildSalaryDesc = new GuildSalaryDesc();

		// Token: 0x04002E7F RID: 11903
		public static GuildSalaryTable m_guildSalaryTable = new GuildSalaryTable();

		// Token: 0x04002E80 RID: 11904
		public static List<int> TabIndexs = new List<int>();

		// Token: 0x04002E81 RID: 11905
		public static List<string> TabNames = new List<string>();

		// Token: 0x04002E82 RID: 11906
		public static Dictionary<int, List<GuildSalaryDesc.RowData>> GuildSalaryDescDic = new Dictionary<int, List<GuildSalaryDesc.RowData>>();

		// Token: 0x04002E83 RID: 11907
		private XGuildSalaryInfo m_activity = new XGuildSalaryInfo();

		// Token: 0x04002E84 RID: 11908
		private XGuildSalaryInfo m_exp = new XGuildSalaryInfo();

		// Token: 0x04002E85 RID: 11909
		private XGuildSalaryInfo m_roleNum = new XGuildSalaryInfo();

		// Token: 0x04002E86 RID: 11910
		private XGuildSalaryInfo m_prestige = new XGuildSalaryInfo();

		// Token: 0x04002E87 RID: 11911
		private List<GuildActivityRole> m_topPlayers;

		// Token: 0x04002E88 RID: 11912
		private uint m_curGrade;

		// Token: 0x04002E89 RID: 11913
		private uint m_curScore;

		// Token: 0x04002E8A RID: 11914
		private WageRewardState m_rewardState;

		// Token: 0x04002E8B RID: 11915
		private uint m_lastLevel;

		// Token: 0x04002E8C RID: 11916
		private uint m_lastGrade;

		// Token: 0x04002E8D RID: 11917
		private uint m_lastScore;

		// Token: 0x04002E8E RID: 11918
		private GuildPosition m_lastPosition;

		// Token: 0x04002E8F RID: 11919
		private uint m_mulMaxScore;

		// Token: 0x04002E90 RID: 11920
		private bool m_hasRedPoint = false;

		// Token: 0x04002E91 RID: 11921
		public uint CurMulScore;
	}
}
