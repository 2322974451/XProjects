using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSalaryDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildSalaryDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildSalaryDocument.AsyncLoader.AddTask("Table/GuildSalaryDesc", XGuildSalaryDocument.m_guildSalaryDesc, false);
			XGuildSalaryDocument.AsyncLoader.AddTask("Table/Guildsalary", XGuildSalaryDocument.m_guildSalaryTable, false);
			XGuildSalaryDocument.AsyncLoader.Execute(callback);
		}

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

		public List<GuildActivityRole> TopPlayers
		{
			get
			{
				return this.m_topPlayers;
			}
		}

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

		public bool NotHasLastSalaryInfo
		{
			get
			{
				return this.m_lastLevel == 0U;
			}
		}

		public uint CurScore
		{
			get
			{
				return this.m_curScore;
			}
		}

		public XGuildSalaryInfo Activity
		{
			get
			{
				return this.m_activity;
			}
		}

		public XGuildSalaryInfo RoleNum
		{
			get
			{
				return this.m_roleNum;
			}
		}

		public XGuildSalaryInfo Prestige
		{
			get
			{
				return this.m_prestige;
			}
		}

		public XGuildSalaryInfo Exp
		{
			get
			{
				return this.m_exp;
			}
		}

		public uint CurGrade
		{
			get
			{
				return this.m_curGrade;
			}
		}

		public uint LastScore
		{
			get
			{
				return this.m_lastScore;
			}
		}

		public uint MulMaxScore
		{
			get
			{
				return this.m_mulMaxScore;
			}
		}

		public WageRewardState RewardState
		{
			get
			{
				return this.m_rewardState;
			}
		}

		public uint LastGrade
		{
			get
			{
				return this.m_lastGrade;
			}
		}

		public GuildPosition LastPosition
		{
			get
			{
				return this.m_lastPosition;
			}
		}

		public uint LastLevel
		{
			get
			{
				return this.m_lastLevel;
			}
		}

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

		public bool TryGetGuildSalary(uint guildLevel, out GuildSalaryTable.RowData rowData)
		{
			rowData = XGuildSalaryDocument.m_guildSalaryTable.GetByGuildLevel(guildLevel);
			return rowData != null;
		}

		public void SendGuildWageReward()
		{
			bool flag = this.m_rewardState == WageRewardState.notreward;
			if (flag)
			{
				RpcC2M_GetGuildWageReward rpc = new RpcC2M_GetGuildWageReward();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
		}

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

		public void SendAskGuildWageInfo()
		{
			RpcC2M_AskGuildWageInfo rpc = new RpcC2M_AskGuildWageInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public int SelectTabs { get; set; }

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<GuildSalayDlg, GuildSalayBehavior>.singleton.IsVisible();
			if (flag)
			{
				this.SendAskGuildWageInfo();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildSalaryDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static GuildSalaryDesc m_guildSalaryDesc = new GuildSalaryDesc();

		public static GuildSalaryTable m_guildSalaryTable = new GuildSalaryTable();

		public static List<int> TabIndexs = new List<int>();

		public static List<string> TabNames = new List<string>();

		public static Dictionary<int, List<GuildSalaryDesc.RowData>> GuildSalaryDescDic = new Dictionary<int, List<GuildSalaryDesc.RowData>>();

		private XGuildSalaryInfo m_activity = new XGuildSalaryInfo();

		private XGuildSalaryInfo m_exp = new XGuildSalaryInfo();

		private XGuildSalaryInfo m_roleNum = new XGuildSalaryInfo();

		private XGuildSalaryInfo m_prestige = new XGuildSalaryInfo();

		private List<GuildActivityRole> m_topPlayers;

		private uint m_curGrade;

		private uint m_curScore;

		private WageRewardState m_rewardState;

		private uint m_lastLevel;

		private uint m_lastGrade;

		private uint m_lastScore;

		private GuildPosition m_lastPosition;

		private uint m_mulMaxScore;

		private bool m_hasRedPoint = false;

		public uint CurMulScore;
	}
}
