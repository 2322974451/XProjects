using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffReduceSkillCD : BuffEffect
	{

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

		public XBuffReduceSkillCD(XBuff buff)
		{
			this._buff = buff;
		}

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

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			bool isDummy = entity.IsDummy;
			if (!isDummy)
			{
				XBuffReduceSkillCD.UnDo(this._AllList, entity);
				CommonObjectPool<SequenceList<uint>>.Release(this._AllList);
			}
		}

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

		private XBuff _buff = null;

		private SequenceList<uint> _AllList = null;
	}
}
