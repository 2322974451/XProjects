using System;

namespace XUtliPoolLib
{
	// Token: 0x02000166 RID: 358
	public class SceneTable : CVSReader
	{
		// Token: 0x060007F2 RID: 2034 RVA: 0x00028520 File Offset: 0x00026720
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

		// Token: 0x060007F3 RID: 2035 RVA: 0x00028558 File Offset: 0x00026758
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

		// Token: 0x060007F4 RID: 2036 RVA: 0x00028634 File Offset: 0x00026834
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

		// Token: 0x060007F5 RID: 2037 RVA: 0x00028F30 File Offset: 0x00027130
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

		// Token: 0x040003B2 RID: 946
		public SceneTable.RowData[] Table = null;

		// Token: 0x02000365 RID: 869
		public class RowData
		{
			// Token: 0x04000D9C RID: 3484
			public int id;

			// Token: 0x04000D9D RID: 3485
			public byte type;

			// Token: 0x04000D9E RID: 3486
			public string configFile;

			// Token: 0x04000D9F RID: 3487
			public SeqListRef<float> StartPos;

			// Token: 0x04000DA0 RID: 3488
			public float[] StartRot;

			// Token: 0x04000DA1 RID: 3489
			public string sceneFile;

			// Token: 0x04000DA2 RID: 3490
			public byte syncMode;

			// Token: 0x04000DA3 RID: 3491
			public string BlockFilePath;

			// Token: 0x04000DA4 RID: 3492
			public short[] UIPos;

			// Token: 0x04000DA5 RID: 3493
			public int Exp;

			// Token: 0x04000DA6 RID: 3494
			public int Money;

			// Token: 0x04000DA7 RID: 3495
			public short Chapter;

			// Token: 0x04000DA8 RID: 3496
			public string Comment;

			// Token: 0x04000DA9 RID: 3497
			public int RecommendPower;

			// Token: 0x04000DAA RID: 3498
			public byte RequiredLevel;

			// Token: 0x04000DAB RID: 3499
			public int[] FirstDownDrop;

			// Token: 0x04000DAC RID: 3500
			public int[] ViewableDropList;

			// Token: 0x04000DAD RID: 3501
			public SeqListRef<int> FatigueCost;

			// Token: 0x04000DAE RID: 3502
			public string EndCutScene;

			// Token: 0x04000DAF RID: 3503
			public float EndCutSceneTime;

			// Token: 0x04000DB0 RID: 3504
			public SeqListRef<int> WinCondition;

			// Token: 0x04000DB1 RID: 3505
			public SeqListRef<int> LoseCondition;

			// Token: 0x04000DB2 RID: 3506
			public short DayLimit;

			// Token: 0x04000DB3 RID: 3507
			public bool CanDrawBox;

			// Token: 0x04000DB4 RID: 3508
			public bool HasFlyOut;

			// Token: 0x04000DB5 RID: 3509
			public uint DayLimitGroupID;

			// Token: 0x04000DB6 RID: 3510
			public string DynamicScene;

			// Token: 0x04000DB7 RID: 3511
			public bool CanPause;

			// Token: 0x04000DB8 RID: 3512
			public short[] OperationSettings;

			// Token: 0x04000DB9 RID: 3513
			public string BGM;

			// Token: 0x04000DBA RID: 3514
			public bool ShowUp;

			// Token: 0x04000DBB RID: 3515
			public SeqListRef<uint> FirstSSS;

			// Token: 0x04000DBC RID: 3516
			public int[] PreScene;

			// Token: 0x04000DBD RID: 3517
			public int SceneChest;

			// Token: 0x04000DBE RID: 3518
			public short[] BoxUIPos;

			// Token: 0x04000DBF RID: 3519
			public string[] LoadingTips;

			// Token: 0x04000DC0 RID: 3520
			public string[] LoadingPic;

			// Token: 0x04000DC1 RID: 3521
			public bool SceneCanNavi;

			// Token: 0x04000DC2 RID: 3522
			public float HurtCoef;

			// Token: 0x04000DC3 RID: 3523
			public string MiniMap;

			// Token: 0x04000DC4 RID: 3524
			public short[] MiniMapSize;

			// Token: 0x04000DC5 RID: 3525
			public short MiniMapRotation;

			// Token: 0x04000DC6 RID: 3526
			public short PreTask;

			// Token: 0x04000DC7 RID: 3527
			public bool SwitchToSelf;

			// Token: 0x04000DC8 RID: 3528
			public string SceneAI;

			// Token: 0x04000DC9 RID: 3529
			public bool ShowAutoFight;

			// Token: 0x04000DCA RID: 3530
			public float GuildExpBounus;

			// Token: 0x04000DCB RID: 3531
			public string FailText;

			// Token: 0x04000DCC RID: 3532
			public string RecommendHint;

			// Token: 0x04000DCD RID: 3533
			public byte TeamInfoDefaultTab;

			// Token: 0x04000DCE RID: 3534
			public byte CombatType;

			// Token: 0x04000DCF RID: 3535
			public int SweepNeedPPT;

			// Token: 0x04000DD0 RID: 3536
			public short ReviveNumb;

			// Token: 0x04000DD1 RID: 3537
			public SeqListRef<uint> ReviveCost;

			// Token: 0x04000DD2 RID: 3538
			public bool CanRevive;

			// Token: 0x04000DD3 RID: 3539
			public short[] TimeCounter;

			// Token: 0x04000DD4 RID: 3540
			public bool HasComboBuff;

			// Token: 0x04000DD5 RID: 3541
			public byte AutoReturn;

			// Token: 0x04000DD6 RID: 3542
			public uint StoryDriver;

			// Token: 0x04000DD7 RID: 3543
			public SeqListRef<uint> ReviveMoneyCost;

			// Token: 0x04000DD8 RID: 3544
			public string LeaveSceneTip;

			// Token: 0x04000DD9 RID: 3545
			public string ReviveBuffTip;

			// Token: 0x04000DDA RID: 3546
			public bool ShowSkill;

			// Token: 0x04000DDB RID: 3547
			public string WinConditionTips;

			// Token: 0x04000DDC RID: 3548
			public float DelayTransfer;

			// Token: 0x04000DDD RID: 3549
			public SeqRef<uint> DPS;

			// Token: 0x04000DDE RID: 3550
			public bool IsCanQuit;

			// Token: 0x04000DDF RID: 3551
			public byte CanVIPRevive;

			// Token: 0x04000DE0 RID: 3552
			public bool ShowNormalAttack;

			// Token: 0x04000DE1 RID: 3553
			public bool HideTeamIndicate;

			// Token: 0x04000DE2 RID: 3554
			public string BattleExplainTips;

			// Token: 0x04000DE3 RID: 3555
			public byte[] ShieldSight;

			// Token: 0x04000DE4 RID: 3556
			public string ScenePath;

			// Token: 0x04000DE5 RID: 3557
			public SeqListRef<int> EnvSet;

			// Token: 0x04000DE6 RID: 3558
			public float SpecifiedTargetLocatedRange;

			// Token: 0x04000DE7 RID: 3559
			public float[] StaticMiniMapCenter;

			// Token: 0x04000DE8 RID: 3560
			public byte VipReviveLimit;

			// Token: 0x04000DE9 RID: 3561
			public float[] MiniMapOutSize;

			// Token: 0x04000DEA RID: 3562
			public bool ShowBattleStatistics;

			// Token: 0x04000DEB RID: 3563
			public SeqRef<uint> PeerBox;

			// Token: 0x04000DEC RID: 3564
			public SeqRef<uint> SelectBoxTime;

			// Token: 0x04000DED RID: 3565
			public uint[] SweepTicket;

			// Token: 0x04000DEE RID: 3566
			public uint CycleLimitTime;

			// Token: 0x04000DEF RID: 3567
			public SeqListRef<float> AwardRate;
		}
	}
}
