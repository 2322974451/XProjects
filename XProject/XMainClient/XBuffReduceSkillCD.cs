using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008A1 RID: 2209
	internal class XBuffReduceSkillCD : BuffEffect
	{
		// Token: 0x06008610 RID: 34320 RVA: 0x0010D49C File Offset: 0x0010B69C
		public static bool TryCreate(CombatEffectHelper pEffectHelper, XBuff buff)
		{
			bool flag = pEffectHelper.BuffInfo.ReduceSkillCD.Count == 0 && !pEffectHelper.bHasEffect(CombatEffectType.CET_Buff_ReduceCD);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffReduceSkillCD(buff));
				result = true;
			}
			return result;
		}

		// Token: 0x06008611 RID: 34321 RVA: 0x0010D4E3 File Offset: 0x0010B6E3
		public XBuffReduceSkillCD(XBuff buff)
		{
			this._buff = buff;
		}

		// Token: 0x06008612 RID: 34322 RVA: 0x0010D504 File Offset: 0x0010B704
		private static void _SetSequenceList(SequenceList<uint> _AllList, CombatEffectHelper pEffectHelper)
		{
			_AllList.Reset(3);
			bool flag = pEffectHelper.bHasEffect(CombatEffectType.CET_Buff_ReduceCD);
			if (flag)
			{
				pEffectHelper.GetBuffReduceSkillCD(_AllList);
			}
			SeqListRef<string> reduceSkillCD = pEffectHelper.BuffInfo.ReduceSkillCD;
			for (int i = 0; i < reduceSkillCD.Count; i++)
			{
				_AllList.Append(new uint[]
				{
					XSingleton<XCommon>.singleton.XHash(reduceSkillCD[i, 0]),
					uint.Parse(reduceSkillCD[i, 1]),
					string.IsNullOrEmpty(reduceSkillCD[i, 2]) ? 0U : uint.Parse(reduceSkillCD[i, 2])
				});
			}
		}

		// Token: 0x06008613 RID: 34323 RVA: 0x0010D5AC File Offset: 0x0010B7AC
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			bool isDummy = entity.IsDummy;
			if (!isDummy)
			{
				this._AllList = CommonObjectPool<SequenceList<uint>>.Get();
				XBuffReduceSkillCD._SetSequenceList(this._AllList, pEffectHelper);
				XBuffReduceSkillCD.DoReduce(this._AllList, entity);
			}
		}

		// Token: 0x06008614 RID: 34324 RVA: 0x0010D5EC File Offset: 0x0010B7EC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			bool isDummy = entity.IsDummy;
			if (!isDummy)
			{
				XBuffReduceSkillCD.UnDo(this._AllList, entity);
				CommonObjectPool<SequenceList<uint>>.Release(this._AllList);
			}
		}

		// Token: 0x06008615 RID: 34325 RVA: 0x0010D620 File Offset: 0x0010B820
		public static void DoReduce(SequenceList<uint> datas, XEntity entity)
		{
			bool flag = entity == null;
			if (!flag)
			{
				XSkillMgr skillMgr = entity.SkillMgr;
				bool flag2 = skillMgr == null;
				if (!flag2)
				{
					for (int i = 0; i < datas.Count; i++)
					{
						uint id = datas[i, 0];
						switch (datas[i, 2])
						{
						case 0U:
						{
							float delta = datas[i, 1] * 0.001f;
							skillMgr.Accelerate(id, delta, false);
							break;
						}
						case 1U:
						{
							float delta2 = datas[i, 1] * 0.01f;
							skillMgr.Accelerate(id, delta2, true);
							break;
						}
						case 2U:
						{
							float delta3 = datas[i, 1] * 0.01f;
							skillMgr.AccelerateStaticCD(id, delta3);
							break;
						}
						}
					}
				}
			}
		}

		// Token: 0x06008616 RID: 34326 RVA: 0x0010D700 File Offset: 0x0010B900
		public static void UnDo(SequenceList<uint> datas, XEntity entity)
		{
			bool flag = entity == null;
			if (!flag)
			{
				XSkillMgr skillMgr = entity.SkillMgr;
				bool flag2 = skillMgr == null;
				if (!flag2)
				{
					for (int i = 0; i < datas.Count; i++)
					{
						uint id = datas[i, 0];
						uint num = datas[i, 2];
						uint num2 = num;
						if (num2 == 2U)
						{
							skillMgr.ResetStaticCD(id);
						}
					}
				}
			}
		}

		// Token: 0x06008617 RID: 34327 RVA: 0x0010D770 File Offset: 0x0010B970
		public static void DoReduce(int buffID, int buffLevel, XEntity entity)
		{
			bool flag = entity == null;
			if (!flag)
			{
				BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(buffID, buffLevel);
				bool flag2 = buffData == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("DoReduce Buff data not found: [{0} {1}]", buffID, buffLevel), null, null, null, null, null);
				}
				else
				{
					CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
					data.Set(buffData, entity);
					SequenceList<uint> sequenceList = CommonObjectPool<SequenceList<uint>>.Get();
					XBuffReduceSkillCD._SetSequenceList(sequenceList, data);
					XBuffReduceSkillCD.DoReduce(sequenceList, entity);
					CommonObjectPool<SequenceList<uint>>.Release(sequenceList);
					data.Recycle();
				}
			}
		}

		// Token: 0x06008618 RID: 34328 RVA: 0x0010D7FC File Offset: 0x0010B9FC
		public static void UnDo(int buffID, int buffLevel, XEntity entity)
		{
			bool flag = entity == null;
			if (!flag)
			{
				BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(buffID, buffLevel);
				bool flag2 = buffData == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("UnDoReduce Buff data not found: [{0} {1}]", buffID, buffLevel), null, null, null, null, null);
				}
				else
				{
					CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
					data.Set(buffData, entity);
					SequenceList<uint> sequenceList = CommonObjectPool<SequenceList<uint>>.Get();
					XBuffReduceSkillCD._SetSequenceList(sequenceList, data);
					XBuffReduceSkillCD.UnDo(sequenceList, entity);
					CommonObjectPool<SequenceList<uint>>.Release(sequenceList);
					data.Recycle();
				}
			}
		}

		// Token: 0x040029C8 RID: 10696
		private XBuff _buff = null;

		// Token: 0x040029C9 RID: 10697
		private SequenceList<uint> _AllList = null;
	}
}
