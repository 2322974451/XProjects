using System;

namespace XUtliPoolLib
{

	public class SceneTable : CVSReader
	{

		public SceneTable.RowData GetBySceneID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SceneTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchSceneID(key);
			}
			return result;
		}

		private SceneTable.RowData BinarySearchSceneID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			SceneTable.RowData rowData;
			SceneTable.RowData rowData2;
			SceneTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.id == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.id == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.id.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.id.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			SceneTable.RowData rowData = new SceneTable.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.type, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.configFile, CVSReader.stringParse);
			this.columnno = 2;
			rowData.StartPos.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.ReadArray<float>(reader, ref rowData.StartRot, CVSReader.floatParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.sceneFile, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<byte>(reader, ref rowData.syncMode, CVSReader.byteParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.BlockFilePath, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<short>(reader, ref rowData.UIPos, CVSReader.shortParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.Exp, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.Money, CVSReader.intParse);
			this.columnno = 10;
			base.Read<short>(reader, ref rowData.Chapter, CVSReader.shortParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Comment, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.RecommendPower, CVSReader.intParse);
			this.columnno = 14;
			base.Read<byte>(reader, ref rowData.RequiredLevel, CVSReader.byteParse);
			this.columnno = 20;
			base.ReadArray<int>(reader, ref rowData.FirstDownDrop, CVSReader.intParse);
			this.columnno = 23;
			base.ReadArray<int>(reader, ref rowData.ViewableDropList, CVSReader.intParse);
			this.columnno = 25;
			rowData.FatigueCost.Read(reader, this.m_DataHandler);
			this.columnno = 27;
			base.Read<string>(reader, ref rowData.EndCutScene, CVSReader.stringParse);
			this.columnno = 28;
			base.Read<float>(reader, ref rowData.EndCutSceneTime, CVSReader.floatParse);
			this.columnno = 29;
			rowData.WinCondition.Read(reader, this.m_DataHandler);
			this.columnno = 33;
			rowData.LoseCondition.Read(reader, this.m_DataHandler);
			this.columnno = 34;
			base.Read<short>(reader, ref rowData.DayLimit, CVSReader.shortParse);
			this.columnno = 35;
			base.Read<bool>(reader, ref rowData.CanDrawBox, CVSReader.boolParse);
			this.columnno = 36;
			base.Read<bool>(reader, ref rowData.HasFlyOut, CVSReader.boolParse);
			this.columnno = 37;
			base.Read<uint>(reader, ref rowData.DayLimitGroupID, CVSReader.uintParse);
			this.columnno = 38;
			base.Read<string>(reader, ref rowData.DynamicScene, CVSReader.stringParse);
			this.columnno = 39;
			base.Read<bool>(reader, ref rowData.CanPause, CVSReader.boolParse);
			this.columnno = 42;
			base.ReadArray<short>(reader, ref rowData.OperationSettings, CVSReader.shortParse);
			this.columnno = 43;
			base.Read<string>(reader, ref rowData.BGM, CVSReader.stringParse);
			this.columnno = 46;
			base.Read<bool>(reader, ref rowData.ShowUp, CVSReader.boolParse);
			this.columnno = 47;
			rowData.FirstSSS.Read(reader, this.m_DataHandler);
			this.columnno = 48;
			base.ReadArray<int>(reader, ref rowData.PreScene, CVSReader.intParse);
			this.columnno = 49;
			base.Read<int>(reader, ref rowData.SceneChest, CVSReader.intParse);
			this.columnno = 50;
			base.ReadArray<short>(reader, ref rowData.BoxUIPos, CVSReader.shortParse);
			this.columnno = 51;
			base.ReadArray<string>(reader, ref rowData.LoadingTips, CVSReader.stringParse);
			this.columnno = 53;
			base.ReadArray<string>(reader, ref rowData.LoadingPic, CVSReader.stringParse);
			this.columnno = 54;
			base.Read<bool>(reader, ref rowData.SceneCanNavi, CVSReader.boolParse);
			this.columnno = 55;
			base.Read<float>(reader, ref rowData.HurtCoef, CVSReader.floatParse);
			this.columnno = 59;
			base.Read<string>(reader, ref rowData.MiniMap, CVSReader.stringParse);
			this.columnno = 60;
			base.ReadArray<short>(reader, ref rowData.MiniMapSize, CVSReader.shortParse);
			this.columnno = 61;
			base.Read<short>(reader, ref rowData.MiniMapRotation, CVSReader.shortParse);
			this.columnno = 62;
			base.Read<short>(reader, ref rowData.PreTask, CVSReader.shortParse);
			this.columnno = 63;
			base.Read<bool>(reader, ref rowData.SwitchToSelf, CVSReader.boolParse);
			this.columnno = 64;
			base.Read<string>(reader, ref rowData.SceneAI, CVSReader.stringParse);
			this.columnno = 65;
			base.Read<bool>(reader, ref rowData.ShowAutoFight, CVSReader.boolParse);
			this.columnno = 66;
			base.Read<float>(reader, ref rowData.GuildExpBounus, CVSReader.floatParse);
			this.columnno = 68;
			base.Read<string>(reader, ref rowData.FailText, CVSReader.stringParse);
			this.columnno = 69;
			base.Read<string>(reader, ref rowData.RecommendHint, CVSReader.stringParse);
			this.columnno = 71;
			base.Read<byte>(reader, ref rowData.TeamInfoDefaultTab, CVSReader.byteParse);
			this.columnno = 72;
			base.Read<byte>(reader, ref rowData.CombatType, CVSReader.byteParse);
			this.columnno = 73;
			base.Read<int>(reader, ref rowData.SweepNeedPPT, CVSReader.intParse);
			this.columnno = 74;
			base.Read<short>(reader, ref rowData.ReviveNumb, CVSReader.shortParse);
			this.columnno = 75;
			rowData.ReviveCost.Read(reader, this.m_DataHandler);
			this.columnno = 76;
			base.Read<bool>(reader, ref rowData.CanRevive, CVSReader.boolParse);
			this.columnno = 77;
			base.ReadArray<short>(reader, ref rowData.TimeCounter, CVSReader.shortParse);
			this.columnno = 82;
			base.Read<bool>(reader, ref rowData.HasComboBuff, CVSReader.boolParse);
			this.columnno = 83;
			base.Read<byte>(reader, ref rowData.AutoReturn, CVSReader.byteParse);
			this.columnno = 85;
			base.Read<uint>(reader, ref rowData.StoryDriver, CVSReader.uintParse);
			this.columnno = 86;
			rowData.ReviveMoneyCost.Read(reader, this.m_DataHandler);
			this.columnno = 88;
			base.Read<string>(reader, ref rowData.LeaveSceneTip, CVSReader.stringParse);
			this.columnno = 90;
			base.Read<string>(reader, ref rowData.ReviveBuffTip, CVSReader.stringParse);
			this.columnno = 91;
			base.Read<bool>(reader, ref rowData.ShowSkill, CVSReader.boolParse);
			this.columnno = 93;
			base.Read<string>(reader, ref rowData.WinConditionTips, CVSReader.stringParse);
			this.columnno = 94;
			base.Read<float>(reader, ref rowData.DelayTransfer, CVSReader.floatParse);
			this.columnno = 95;
			rowData.DPS.Read(reader, this.m_DataHandler);
			this.columnno = 97;
			base.Read<bool>(reader, ref rowData.IsCanQuit, CVSReader.boolParse);
			this.columnno = 99;
			base.Read<byte>(reader, ref rowData.CanVIPRevive, CVSReader.byteParse);
			this.columnno = 100;
			base.Read<bool>(reader, ref rowData.ShowNormalAttack, CVSReader.boolParse);
			this.columnno = 101;
			base.Read<bool>(reader, ref rowData.HideTeamIndicate, CVSReader.boolParse);
			this.columnno = 102;
			base.Read<string>(reader, ref rowData.BattleExplainTips, CVSReader.stringParse);
			this.columnno = 103;
			base.ReadArray<byte>(reader, ref rowData.ShieldSight, CVSReader.byteParse);
			this.columnno = 104;
			base.Read<string>(reader, ref rowData.ScenePath, CVSReader.stringParse);
			this.columnno = 105;
			rowData.EnvSet.Read(reader, this.m_DataHandler);
			this.columnno = 106;
			base.Read<float>(reader, ref rowData.SpecifiedTargetLocatedRange, CVSReader.floatParse);
			this.columnno = 107;
			base.ReadArray<float>(reader, ref rowData.StaticMiniMapCenter, CVSReader.floatParse);
			this.columnno = 110;
			base.Read<byte>(reader, ref rowData.VipReviveLimit, CVSReader.byteParse);
			this.columnno = 111;
			base.ReadArray<float>(reader, ref rowData.MiniMapOutSize, CVSReader.floatParse);
			this.columnno = 112;
			base.Read<bool>(reader, ref rowData.ShowBattleStatistics, CVSReader.boolParse);
			this.columnno = 115;
			rowData.PeerBox.Read(reader, this.m_DataHandler);
			this.columnno = 116;
			rowData.SelectBoxTime.Read(reader, this.m_DataHandler);
			this.columnno = 117;
			base.ReadArray<uint>(reader, ref rowData.SweepTicket, CVSReader.uintParse);
			this.columnno = 118;
			base.Read<uint>(reader, ref rowData.CycleLimitTime, CVSReader.uintParse);
			this.columnno = 119;
			rowData.AwardRate.Read(reader, this.m_DataHandler);
			this.columnno = 120;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SceneTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SceneTable.RowData[] Table = null;

		public class RowData
		{

			public int id;

			public byte type;

			public string configFile;

			public SeqListRef<float> StartPos;

			public float[] StartRot;

			public string sceneFile;

			public byte syncMode;

			public string BlockFilePath;

			public short[] UIPos;

			public int Exp;

			public int Money;

			public short Chapter;

			public string Comment;

			public int RecommendPower;

			public byte RequiredLevel;

			public int[] FirstDownDrop;

			public int[] ViewableDropList;

			public SeqListRef<int> FatigueCost;

			public string EndCutScene;

			public float EndCutSceneTime;

			public SeqListRef<int> WinCondition;

			public SeqListRef<int> LoseCondition;

			public short DayLimit;

			public bool CanDrawBox;

			public bool HasFlyOut;

			public uint DayLimitGroupID;

			public string DynamicScene;

			public bool CanPause;

			public short[] OperationSettings;

			public string BGM;

			public bool ShowUp;

			public SeqListRef<uint> FirstSSS;

			public int[] PreScene;

			public int SceneChest;

			public short[] BoxUIPos;

			public string[] LoadingTips;

			public string[] LoadingPic;

			public bool SceneCanNavi;

			public float HurtCoef;

			public string MiniMap;

			public short[] MiniMapSize;

			public short MiniMapRotation;

			public short PreTask;

			public bool SwitchToSelf;

			public string SceneAI;

			public bool ShowAutoFight;

			public float GuildExpBounus;

			public string FailText;

			public string RecommendHint;

			public byte TeamInfoDefaultTab;

			public byte CombatType;

			public int SweepNeedPPT;

			public short ReviveNumb;

			public SeqListRef<uint> ReviveCost;

			public bool CanRevive;

			public short[] TimeCounter;

			public bool HasComboBuff;

			public byte AutoReturn;

			public uint StoryDriver;

			public SeqListRef<uint> ReviveMoneyCost;

			public string LeaveSceneTip;

			public string ReviveBuffTip;

			public bool ShowSkill;

			public string WinConditionTips;

			public float DelayTransfer;

			public SeqRef<uint> DPS;

			public bool IsCanQuit;

			public byte CanVIPRevive;

			public bool ShowNormalAttack;

			public bool HideTeamIndicate;

			public string BattleExplainTips;

			public byte[] ShieldSight;

			public string ScenePath;

			public SeqListRef<int> EnvSet;

			public float SpecifiedTargetLocatedRange;

			public float[] StaticMiniMapCenter;

			public byte VipReviveLimit;

			public float[] MiniMapOutSize;

			public bool ShowBattleStatistics;

			public SeqRef<uint> PeerBox;

			public SeqRef<uint> SelectBoxTime;

			public uint[] SweepTicket;

			public uint CycleLimitTime;

			public SeqListRef<float> AwardRate;
		}
	}
}
