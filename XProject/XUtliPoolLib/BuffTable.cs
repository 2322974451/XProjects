using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B9 RID: 185
	public class BuffTable : CVSReader
	{
		// Token: 0x06000559 RID: 1369 RVA: 0x00017CCC File Offset: 0x00015ECC
		protected override void ReadLine(XBinaryReader reader)
		{
			BuffTable.RowData rowData = new BuffTable.RowData();
			base.Read<int>(reader, ref rowData.BuffID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.BuffLevel, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.BuffDuration, CVSReader.floatParse);
			this.columnno = 2;
			rowData.BuffChangeAttribute.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.ReadArray<byte>(reader, ref rowData.BuffState, CVSReader.byteParse);
			this.columnno = 4;
			base.Read<byte>(reader, ref rowData.BuffMergeType, CVSReader.byteParse);
			this.columnno = 5;
			base.Read<short>(reader, ref rowData.TargetType, CVSReader.shortParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.BuffIcon, CVSReader.stringParse);
			this.columnno = 7;
			rowData.BuffDOT.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.BuffFx, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.BuffDoodadFx, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.BuffName, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<byte>(reader, ref rowData.BuffTriggerCond, CVSReader.byteParse);
			this.columnno = 12;
			base.Read<float>(reader, ref rowData.BuffTriggerRate, CVSReader.floatParse);
			this.columnno = 13;
			base.ReadArray<string>(reader, ref rowData.BuffTriggerParam, CVSReader.stringParse);
			this.columnno = 14;
			rowData.BuffTriggerBuff.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			base.Read<float>(reader, ref rowData.CostModify, CVSReader.floatParse);
			this.columnno = 16;
			base.Read<float>(reader, ref rowData.BuffTriggerCD, CVSReader.floatParse);
			this.columnno = 18;
			rowData.AuraAddBuffID.Read(reader, this.m_DataHandler);
			this.columnno = 19;
			base.Read<bool>(reader, ref rowData.BuffIsVisible, CVSReader.boolParse);
			this.columnno = 20;
			base.Read<string>(reader, ref rowData.BuffEffectFx, CVSReader.stringParse);
			this.columnno = 21;
			base.ReadArray<float>(reader, ref rowData.AuraParams, CVSReader.floatParse);
			this.columnno = 22;
			rowData.DamageReduce.Read(reader, this.m_DataHandler);
			this.columnno = 23;
			base.Read<bool>(reader, ref rowData.DontShowText, CVSReader.boolParse);
			this.columnno = 24;
			base.ReadArray<short>(reader, ref rowData.EffectGroup, CVSReader.shortParse);
			this.columnno = 25;
			rowData.BuffDOTValueFromCaster.Read(reader, this.m_DataHandler);
			this.columnno = 26;
			rowData.ChangeDamage.Read(reader, this.m_DataHandler);
			this.columnno = 27;
			base.Read<byte>(reader, ref rowData.BuffClearType, CVSReader.byteParse);
			this.columnno = 28;
			base.ReadArray<byte>(reader, ref rowData.ClearTypes, CVSReader.byteParse);
			this.columnno = 29;
			base.Read<float>(reader, ref rowData.DamageReflection, CVSReader.floatParse);
			this.columnno = 30;
			base.Read<uint>(reader, ref rowData.MobID, CVSReader.uintParse);
			this.columnno = 31;
			rowData.BuffHP.Read(reader, this.m_DataHandler);
			this.columnno = 32;
			base.Read<byte>(reader, ref rowData.StackMaxCount, CVSReader.byteParse);
			this.columnno = 33;
			base.Read<short>(reader, ref rowData.ChangeFightGroup, CVSReader.shortParse);
			this.columnno = 34;
			base.Read<byte>(reader, ref rowData.BuffTriggerCount, CVSReader.byteParse);
			this.columnno = 35;
			rowData.LifeSteal.Read(reader, this.m_DataHandler);
			this.columnno = 36;
			rowData.ReduceSkillCD.Read(reader, this.m_DataHandler);
			this.columnno = 37;
			base.Read<int>(reader, ref rowData.StateParam, CVSReader.intParse);
			this.columnno = 38;
			base.Read<bool>(reader, ref rowData.IsGlobalTrigger, CVSReader.boolParse);
			this.columnno = 39;
			base.ReadArray<byte>(reader, ref rowData.Tags, CVSReader.byteParse);
			this.columnno = 40;
			base.Read<string>(reader, ref rowData.BuffSpriteFx, CVSReader.stringParse);
			this.columnno = 41;
			base.Read<string>(reader, ref rowData.MiniMapIcon, CVSReader.stringParse);
			this.columnno = 42;
			base.Read<string>(reader, ref rowData.BuffTriggerSkill, CVSReader.stringParse);
			this.columnno = 43;
			rowData.ChangeSkillDamage.Read(reader, this.m_DataHandler);
			this.columnno = 44;
			base.ReadArray<byte>(reader, ref rowData.SceneEffect, CVSReader.byteParse);
			this.columnno = 45;
			rowData.TargetLifeAddAttack.Read(reader, this.m_DataHandler);
			this.columnno = 46;
			rowData.AIEvent.Read(reader, this.m_DataHandler);
			this.columnno = 47;
			base.ReadArray<string>(reader, ref rowData.RelevantSkills, CVSReader.stringParse);
			this.columnno = 48;
			base.Read<bool>(reader, ref rowData.IsTriggerImm, CVSReader.boolParse);
			this.columnno = 49;
			base.ReadArray<float>(reader, ref rowData.Manipulate, CVSReader.floatParse);
			this.columnno = 50;
			rowData.SkillsReplace.Read(reader, this.m_DataHandler);
			this.columnno = 51;
			rowData.SelfLifeAddAttack.Read(reader, this.m_DataHandler);
			this.columnno = 52;
			rowData.ChangeCastDamageByDistance.Read(reader, this.m_DataHandler);
			this.columnno = 53;
			base.Read<short>(reader, ref rowData.Kill, CVSReader.shortParse);
			this.columnno = 54;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x000182A0 File Offset: 0x000164A0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BuffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002DF RID: 735
		public BuffTable.RowData[] Table = null;

		// Token: 0x020002B7 RID: 695
		public class RowData
		{
			// Token: 0x0400091F RID: 2335
			public int BuffID;

			// Token: 0x04000920 RID: 2336
			public byte BuffLevel;

			// Token: 0x04000921 RID: 2337
			public float BuffDuration;

			// Token: 0x04000922 RID: 2338
			public SeqListRef<float> BuffChangeAttribute;

			// Token: 0x04000923 RID: 2339
			public byte[] BuffState;

			// Token: 0x04000924 RID: 2340
			public byte BuffMergeType;

			// Token: 0x04000925 RID: 2341
			public short TargetType;

			// Token: 0x04000926 RID: 2342
			public string BuffIcon;

			// Token: 0x04000927 RID: 2343
			public SeqListRef<float> BuffDOT;

			// Token: 0x04000928 RID: 2344
			public string BuffFx;

			// Token: 0x04000929 RID: 2345
			public string BuffDoodadFx;

			// Token: 0x0400092A RID: 2346
			public string BuffName;

			// Token: 0x0400092B RID: 2347
			public byte BuffTriggerCond;

			// Token: 0x0400092C RID: 2348
			public float BuffTriggerRate;

			// Token: 0x0400092D RID: 2349
			public string[] BuffTriggerParam;

			// Token: 0x0400092E RID: 2350
			public SeqListRef<int> BuffTriggerBuff;

			// Token: 0x0400092F RID: 2351
			public float CostModify;

			// Token: 0x04000930 RID: 2352
			public float BuffTriggerCD;

			// Token: 0x04000931 RID: 2353
			public SeqListRef<int> AuraAddBuffID;

			// Token: 0x04000932 RID: 2354
			public bool BuffIsVisible;

			// Token: 0x04000933 RID: 2355
			public string BuffEffectFx;

			// Token: 0x04000934 RID: 2356
			public float[] AuraParams;

			// Token: 0x04000935 RID: 2357
			public SeqListRef<float> DamageReduce;

			// Token: 0x04000936 RID: 2358
			public bool DontShowText;

			// Token: 0x04000937 RID: 2359
			public short[] EffectGroup;

			// Token: 0x04000938 RID: 2360
			public SeqListRef<int> BuffDOTValueFromCaster;

			// Token: 0x04000939 RID: 2361
			public SeqRef<float> ChangeDamage;

			// Token: 0x0400093A RID: 2362
			public byte BuffClearType;

			// Token: 0x0400093B RID: 2363
			public byte[] ClearTypes;

			// Token: 0x0400093C RID: 2364
			public float DamageReflection;

			// Token: 0x0400093D RID: 2365
			public uint MobID;

			// Token: 0x0400093E RID: 2366
			public SeqRef<float> BuffHP;

			// Token: 0x0400093F RID: 2367
			public byte StackMaxCount;

			// Token: 0x04000940 RID: 2368
			public short ChangeFightGroup;

			// Token: 0x04000941 RID: 2369
			public byte BuffTriggerCount;

			// Token: 0x04000942 RID: 2370
			public SeqRef<float> LifeSteal;

			// Token: 0x04000943 RID: 2371
			public SeqListRef<string> ReduceSkillCD;

			// Token: 0x04000944 RID: 2372
			public int StateParam;

			// Token: 0x04000945 RID: 2373
			public bool IsGlobalTrigger;

			// Token: 0x04000946 RID: 2374
			public byte[] Tags;

			// Token: 0x04000947 RID: 2375
			public string BuffSpriteFx;

			// Token: 0x04000948 RID: 2376
			public string MiniMapIcon;

			// Token: 0x04000949 RID: 2377
			public string BuffTriggerSkill;

			// Token: 0x0400094A RID: 2378
			public SeqListRef<string> ChangeSkillDamage;

			// Token: 0x0400094B RID: 2379
			public byte[] SceneEffect;

			// Token: 0x0400094C RID: 2380
			public SeqListRef<float> TargetLifeAddAttack;

			// Token: 0x0400094D RID: 2381
			public SeqRef<string> AIEvent;

			// Token: 0x0400094E RID: 2382
			public string[] RelevantSkills;

			// Token: 0x0400094F RID: 2383
			public bool IsTriggerImm;

			// Token: 0x04000950 RID: 2384
			public float[] Manipulate;

			// Token: 0x04000951 RID: 2385
			public SeqListRef<string> SkillsReplace;

			// Token: 0x04000952 RID: 2386
			public SeqListRef<float> SelfLifeAddAttack;

			// Token: 0x04000953 RID: 2387
			public SeqListRef<float> ChangeCastDamageByDistance;

			// Token: 0x04000954 RID: 2388
			public short Kill;
		}
	}
}
