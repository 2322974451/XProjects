using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CombatEffectHelper : XDataBase
	{

		public BuffTable.RowData BuffInfo
		{
			get
			{
				return this.m_pBuffInfo;
			}
		}

		public EffectDataParams EffectData
		{
			get
			{
				return this.m_pEffectData;
			}
		}

		public CombatEffectType CacheQueryType
		{
			get
			{
				return this.m_CacheType;
			}
		}

		public EffectDataParams.TypeDataCollection CacheTypeDataCollection
		{
			get
			{
				return this.m_CacheCollection;
			}
		}

		public void SetCacheQuery(CombatEffectType type, EffectDataParams.TypeDataCollection collection)
		{
			this.m_CacheType = type;
			this.m_CacheCollection = collection;
		}

		public void ClearCache()
		{
			this.m_CacheCollection = null;
			this.m_CacheType = CombatEffectType.CET_INVALID;
		}

		public BuffTable.RowData GetTemplateBuffTable(uint templateBuffID)
		{
			BuffTable.RowData buffData;
			bool flag = this.m_Template2BuffTable.TryGetValue(templateBuffID, out buffData);
			BuffTable.RowData result;
			if (flag)
			{
				result = buffData;
			}
			else
			{
				buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)templateBuffID, 1);
				this.m_Template2BuffTable[templateBuffID] = buffData;
				result = buffData;
			}
			return result;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.m_Template2BuffTable.Clear();
			this.m_pBuffInfo = null;
			this.m_pEffectData = null;
			this.m_SkillHash = 0U;
			this.m_ActualSkillHash = 0U;
			this.m_CacheType = CombatEffectType.CET_INVALID;
			this.m_CacheCollection = null;
		}

		private bool _IsValidEntity(XEntity entity)
		{
			bool flag = entity == null || entity.Deprecated || entity.Destroying || entity.Attributes == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !entity.IsPlayer;
				if (flag2)
				{
					bool flag3 = entity.Attributes.FinalHostID == 0UL;
					if (flag3)
					{
						return false;
					}
					XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(entity.Attributes.FinalHostID);
					bool flag4 = entityConsiderDeath == null || !entityConsiderDeath.IsPlayer;
					if (flag4)
					{
						return false;
					}
				}
				result = true;
			}
			return result;
		}

		public void Set(BuffTable.RowData pBuffInfo, ulong casterID, XEntity defaultEntity)
		{
			bool flag = casterID == 0UL || defaultEntity == null || casterID == defaultEntity.ID;
			if (flag)
			{
				this.Set(pBuffInfo, defaultEntity);
			}
			else
			{
				this.Set(pBuffInfo, XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(casterID));
			}
		}

		public void Set(BuffTable.RowData pBuffInfo, XEntity entity)
		{
			this.m_SkillHash = 0U;
			this.m_ActualSkillHash = 0U;
			this.m_pBuffInfo = pBuffInfo;
			this.m_CacheType = CombatEffectType.CET_INVALID;
			this.m_CacheCollection = null;
			this.m_Template2BuffTable.Clear();
			bool flag = !this._IsValidEntity(entity) || !XSingleton<XCombatEffectManager>.singleton.IsArtifactEnabled();
			if (!flag)
			{
				this.m_pEffectData = XSingleton<XCombatEffectManager>.singleton.GetEffectDataByBuff((uint)pBuffInfo.BuffID);
			}
		}

		public void Set(string skillName, XEntity entity)
		{
			this.Set(XSingleton<XCommon>.singleton.XHash(skillName), entity);
		}

		public void Set(uint skillHash, XEntity entity)
		{
			this.m_SkillHash = skillHash;
			this.m_ActualSkillHash = skillHash;
			this.m_pBuffInfo = null;
			this.m_CacheType = CombatEffectType.CET_INVALID;
			this.m_CacheCollection = null;
			this.m_Template2BuffTable.Clear();
			bool flag = !this._IsValidEntity(entity) || !XSingleton<XCombatEffectManager>.singleton.IsArtifactEnabled();
			if (!flag)
			{
				this.m_pEffectData = XSingleton<XCombatEffectManager>.singleton.GetEffectDataBySkill(skillHash);
				bool flag2 = this.m_pEffectData == null;
				if (flag2)
				{
					uint preSkill = XSingleton<XSkillEffectMgr>.singleton.GetPreSkill(skillHash, entity.SkillCasterTypeID);
					bool flag3 = preSkill > 0U;
					if (flag3)
					{
						this.m_pEffectData = XSingleton<XCombatEffectManager>.singleton.GetEffectDataBySkill(preSkill);
						this.m_ActualSkillHash = preSkill;
					}
				}
			}
		}

		private static EffectDataParams.TypeDataCollection GetTypeDataList(CombatEffectType type, CombatEffectHelper helper)
		{
			bool flag = helper.CacheQueryType == type;
			EffectDataParams.TypeDataCollection result;
			if (flag)
			{
				result = helper.CacheTypeDataCollection;
			}
			else
			{
				bool flag2 = helper.EffectData == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					EffectDataParams.TypeDataCollection collection = helper.EffectData.GetCollection(type);
					bool flag3 = collection == null;
					if (flag3)
					{
						result = null;
					}
					else
					{
						helper.SetCacheQuery(type, collection);
						result = collection;
					}
				}
			}
			return result;
		}

		public bool bHasEffect(CombatEffectType type)
		{
			return CombatEffectHelper.GetTypeDataList(type, this) != null;
		}

		private int GetSum(CombatEffectType type)
		{
			EffectDataParams.TypeDataCollection typeDataList = CombatEffectHelper.GetTypeDataList(type, this);
			bool flag = typeDataList == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = 0;
				for (int i = 0; i < typeDataList.datas.Count; i++)
				{
					EffectDataParams.TypeData typeData = typeDataList.datas[i];
					for (int j = 0; j < typeData.randomParams.Count; j++)
					{
						num += typeData.randomParams[j];
					}
				}
				result = num;
			}
			return result;
		}

		private bool GetSequenceSum(ref CombatEffectHelper.GetSeqDataParam param, SequenceList<float> vecOut, GetBuffDataSeqFloat getBuffDataDelegate, int dim)
		{
			bool flag = param.replaceIndex >= param.dim;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EffectDataParams.TypeDataCollection typeDataList = CombatEffectHelper.GetTypeDataList(param.type, param.helper);
				bool flag2 = typeDataList == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					vecOut.Reset((short)param.dim, (int)((short)typeDataList.datas.Count));
					for (int i = 0; i < typeDataList.datas.Count; i++)
					{
						EffectDataParams.TypeData typeData = typeDataList.datas[i];
						BuffTable.RowData rowData = (typeData.templatebuffID == 0U) ? param.helper.BuffInfo : param.helper.GetTemplateBuffTable(typeData.templatebuffID);
						bool flag3 = rowData == null;
						if (!flag3)
						{
							bool flag4 = typeData.randomParams.Count == 0;
							if (!flag4)
							{
								bool flag5 = getBuffDataDelegate != null;
								if (flag5)
								{
									bool flag6 = !this._ReplaceSeq<float>(getBuffDataDelegate(rowData), (float)((double)typeData.randomParams[0] * param.ratio), param.replaceIndex, vecOut, i, dim);
									if (flag6)
									{
										return false;
									}
								}
							}
						}
					}
					result = true;
				}
			}
			return result;
		}

		private bool GetVecSequenceSum(ref CombatEffectHelper.GetSeqListDataParam param, SequenceList<float> vecOut, GetBuffDataSeqListFloat getBuffDataDelegate, int dim)
		{
			bool flag = param.replaceIndex >= param.dim;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EffectDataParams.TypeDataCollection typeDataList = CombatEffectHelper.GetTypeDataList(param.type, param.helper);
				bool flag2 = typeDataList == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					vecOut.CheckOrReset((short)param.dim);
					int count = vecOut.Count;
					for (int i = 0; i < typeDataList.datas.Count; i++)
					{
						EffectDataParams.TypeData typeData = typeDataList.datas[i];
						BuffTable.RowData rowData = (typeData.templatebuffID == 0U) ? param.helper.BuffInfo : param.helper.GetTemplateBuffTable(typeData.templatebuffID);
						bool flag3 = rowData == null;
						if (!flag3)
						{
							bool flag4 = getBuffDataDelegate != null;
							if (flag4)
							{
								bool flag5 = !this._ReplaceVecSeq(ref param, getBuffDataDelegate(rowData), typeData.randomParams, vecOut, ref count, dim);
								if (flag5)
								{
									return false;
								}
							}
						}
					}
					result = true;
				}
			}
			return result;
		}

		private bool GetVecSequenceSum(ref CombatEffectHelper.GetSeqListDataParam param, SequenceList<int> vecOut, GetBuffDataSeqListInt getBuffDataDelegate, int dim)
		{
			bool flag = param.replaceIndex >= param.dim;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EffectDataParams.TypeDataCollection typeDataList = CombatEffectHelper.GetTypeDataList(param.type, param.helper);
				bool flag2 = typeDataList == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					vecOut.CheckOrReset((short)param.dim);
					int count = vecOut.Count;
					for (int i = 0; i < typeDataList.datas.Count; i++)
					{
						EffectDataParams.TypeData typeData = typeDataList.datas[i];
						BuffTable.RowData rowData = (typeData.templatebuffID == 0U) ? param.helper.BuffInfo : param.helper.GetTemplateBuffTable(typeData.templatebuffID);
						bool flag3 = rowData == null;
						if (!flag3)
						{
							bool flag4 = getBuffDataDelegate != null;
							if (flag4)
							{
								bool flag5 = !this._ReplaceVecSeq(ref param, getBuffDataDelegate(rowData), typeData.randomParams, vecOut, ref count, dim);
								if (flag5)
								{
									return false;
								}
							}
						}
					}
					result = true;
				}
			}
			return result;
		}

		private bool GetVecSequenceSumFromVecString(ref CombatEffectHelper.GetSeqListDataFromVecStringParam param, SequenceList<uint> vecOut, GetBuffDataSeqListString getBuffDataDelegate, int dim)
		{
			bool flag = param.replaceIndex >= param.dim;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				EffectDataParams.TypeDataCollection typeDataList = CombatEffectHelper.GetTypeDataList(param.type, param.helper);
				bool flag2 = typeDataList == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					vecOut.CheckOrReset((short)param.dim);
					int count = vecOut.Count;
					for (int i = 0; i < typeDataList.datas.Count; i++)
					{
						EffectDataParams.TypeData typeData = typeDataList.datas[i];
						BuffTable.RowData rowData = (typeData.templatebuffID == 0U) ? param.helper.BuffInfo : param.helper.GetTemplateBuffTable(typeData.templatebuffID);
						bool flag3 = rowData == null;
						if (!flag3)
						{
							bool flag4 = getBuffDataDelegate != null;
							if (flag4)
							{
								bool flag5 = !this._ReplaceVecSeqFromVecString(ref param, getBuffDataDelegate(rowData), typeData.randomParams, vecOut, ref count, dim);
								if (flag5)
								{
									return false;
								}
							}
						}
					}
					result = true;
				}
			}
			return result;
		}

		private float _Double2Float(double d)
		{
			return (float)d;
		}

		private uint _Double2Uint(double d)
		{
			return (uint)d;
		}

		private int _Double2Int(double d)
		{
			return (int)d;
		}

		private uint _Uint2Uint(uint u)
		{
			return u;
		}

		private uint _Int2Uint(int u)
		{
			return (uint)u;
		}

		private bool _ReplaceSeq<T, N>(T refData, N value, int replaceIndex, SequenceList<N> vecOut, int dataIndex, int dim) where T : ISeqRef<N> where N : IComparable<N>
		{
			bool flag = dim <= replaceIndex;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < dim; i++)
				{
					bool flag2 = i == replaceIndex;
					if (flag2)
					{
						vecOut[dataIndex, replaceIndex] = value;
					}
					else
					{
						vecOut[dataIndex, i] = refData[i];
					}
				}
				result = true;
			}
			return result;
		}

		private bool _ReplaceSeq<N>(ISeqRef<N> refData, N value, int replaceIndex, SequenceList<N> vecOut, int dataIndex, int dim)
		{
			bool flag = dim <= replaceIndex;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < dim; i++)
				{
					bool flag2 = i == replaceIndex;
					if (flag2)
					{
						vecOut[dataIndex, replaceIndex] = value;
					}
					else
					{
						vecOut[dataIndex, i] = refData[i];
					}
				}
				result = true;
			}
			return result;
		}

		private bool _ReplaceVecSeq(ref CombatEffectHelper.GetSeqListDataParam param, ISeqListRef<float> refData, List<int> values, SequenceList<float> vecOut, ref int index, int dim)
		{
			bool flag = param.replaceIndex >= dim || (refData.Count != 0 && refData.Count != values.Count);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int i = 0;
				while (i < refData.Count)
				{
					for (int j = 0; j < dim; j++)
					{
						bool flag2 = j == param.replaceIndex;
						if (flag2)
						{
							vecOut[index, j] = (float)((double)values[i] * param.ratio);
						}
						else
						{
							vecOut[index, j] = refData[i, j];
						}
					}
					i++;
					index++;
				}
				result = true;
			}
			return result;
		}

		private bool _ReplaceVecSeq(ref CombatEffectHelper.GetSeqListDataParam param, ISeqListRef<int> refData, List<int> values, SequenceList<int> vecOut, ref int index, int dim)
		{
			bool flag = param.replaceIndex >= dim || (refData.Count != 0 && refData.Count != values.Count);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int i = 0;
				while (i < refData.Count)
				{
					for (int j = 0; j < dim; j++)
					{
						bool flag2 = j == param.replaceIndex;
						if (flag2)
						{
							vecOut[index, j] = (int)((double)values[i] * param.ratio);
						}
						else
						{
							vecOut[index, j] = refData[i, j];
						}
					}
					i++;
					index++;
				}
				result = true;
			}
			return result;
		}

		private bool _ReplaceVecSeqFromVecString(ref CombatEffectHelper.GetSeqListDataFromVecStringParam param, ISeqListRef<string> refData, List<int> values, SequenceList<uint> vecOut, ref int index, int dim)
		{
			bool flag = param.replaceIndex >= dim || (refData.Count != 0 && refData.Count != values.Count);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int i = 0;
				while (i < refData.Count)
				{
					for (int j = 0; j < dim; j++)
					{
						bool flag2 = j == param.replaceIndex;
						if (flag2)
						{
							vecOut[index, j] = (uint)values[i];
						}
						else
						{
							bool flag3 = j == param.hashIndex;
							if (flag3)
							{
								vecOut[index, j] = XSingleton<XCommon>.singleton.XHash(refData[i, j]);
							}
							else
							{
								vecOut[index, j] = uint.Parse(refData[i, j]);
							}
						}
					}
					i++;
					index++;
				}
				result = true;
			}
			return result;
		}

		public static float Add(float left, float right)
		{
			return left + right;
		}

		public static int Add(int left, int right)
		{
			return left + right;
		}

		public static uint Add(uint left, uint right)
		{
			return left + right;
		}

		private bool _CompareSeq<T>(T[] left, T[] right, int exclusiveIndex) where T : IComparable<T>
		{
			bool flag = left.Length != right.Length;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < left.Length; i++)
				{
					bool flag2 = i == exclusiveIndex;
					if (!flag2)
					{
						bool flag3 = left[i].CompareTo(right[i]) != 0;
						if (flag3)
						{
							return false;
						}
					}
				}
				result = true;
			}
			return result;
		}

		public void Merge(SequenceList<float> datas, int exclusiveIndex)
		{
			int num = 0;
			int num2 = 1;
			float[] array = CombatEffectHelper.startDataBufferFloat;
			float[] array2 = CombatEffectHelper.curDataBufferFloat;
			while (num < datas.Count && num2 < datas.Count)
			{
				datas.Get(num2, array2);
				int num3 = -1;
				for (int i = 0; i <= num; i++)
				{
					datas.Get(i, array);
					bool flag = this._CompareSeq<float>(array, array2, exclusiveIndex);
					if (flag)
					{
						num3 = i;
						break;
					}
				}
				bool flag2 = num3 != -1;
				if (flag2)
				{
					datas[num3, exclusiveIndex] = array2[exclusiveIndex] + datas[num3, exclusiveIndex];
				}
				else
				{
					num++;
					bool flag3 = num < num2;
					if (flag3)
					{
						datas.Set(num, array2);
					}
				}
				num2++;
			}
			datas.Trim(num + 1);
		}

		public void Merge(SequenceList<uint> datas, int exclusiveIndex)
		{
			int num = 0;
			int num2 = 1;
			uint[] array = CombatEffectHelper.startDataBufferUint;
			uint[] array2 = CombatEffectHelper.curDataBufferUint;
			while (num < datas.Count && num2 < datas.Count)
			{
				datas.Get(num2, array2);
				int num3 = -1;
				for (int i = 0; i <= num; i++)
				{
					datas.Get(i, array);
					bool flag = this._CompareSeq<uint>(array, array2, exclusiveIndex);
					if (flag)
					{
						num3 = i;
						break;
					}
				}
				bool flag2 = num3 != -1;
				if (flag2)
				{
					datas[num3, exclusiveIndex] = array2[exclusiveIndex] + datas[num3, exclusiveIndex];
				}
				else
				{
					num++;
					bool flag3 = num < num2;
					if (flag3)
					{
						datas.Set(num, array2);
					}
				}
				num2++;
			}
			datas.Trim(num + 1);
		}

		private ISeqRef<float> _GetBuffHPData(BuffTable.RowData pBuffData)
		{
			return pBuffData.BuffHP;
		}

		public bool GetBuffHP(SequenceList<float> vecOut)
		{
			CombatEffectHelper.GetSeqDataParam getSeqDataParam;
			getSeqDataParam.dim = 2;
			getSeqDataParam.helper = this;
			getSeqDataParam.ratio = 1.0;
			getSeqDataParam.replaceIndex = 1;
			getSeqDataParam.type = CombatEffectType.CET_Buff_HP;
			return this.GetSequenceSum(ref getSeqDataParam, vecOut, new GetBuffDataSeqFloat(this._GetBuffHPData), 2);
		}

		private ISeqListRef<float> _GetBuffChangeAttributeData(BuffTable.RowData pBuffData)
		{
			return pBuffData.BuffChangeAttribute;
		}

		public bool GetBuffChangeAttribute(SequenceList<float> vecOut)
		{
			CombatEffectHelper.GetSeqListDataParam getSeqListDataParam;
			getSeqListDataParam.dim = 3;
			getSeqListDataParam.helper = this;
			getSeqListDataParam.ratio = 0.001;
			getSeqListDataParam.replaceIndex = 1;
			getSeqListDataParam.type = CombatEffectType.CET_Buff_ChangeAttribute;
			bool vecSequenceSum = this.GetVecSequenceSum(ref getSeqListDataParam, vecOut, new GetBuffDataSeqListFloat(this._GetBuffChangeAttributeData), 3);
			this.Merge(vecOut, 1);
			return vecSequenceSum;
		}

		public bool GetSkillDamage(out float ratio)
		{
			ratio = 0f;
			int sum = this.GetSum(CombatEffectType.CET_Skill_Damage);
			bool flag = sum == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ratio = (float)sum * 0.001f;
				result = true;
			}
			return result;
		}

		public bool GetSkillCD(out float fOut)
		{
			fOut = 0f;
			int sum = this.GetSum(CombatEffectType.CET_Skill_CD);
			bool flag = sum == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				fOut = (float)sum * 0.001f;
				bool flag2 = fOut > 1f;
				if (flag2)
				{
					fOut = 1f;
				}
				fOut = -fOut;
				result = true;
			}
			return result;
		}

		public float GetBuffAuraRadius()
		{
			return (float)this.GetSum(CombatEffectType.CET_Buff_AuraRadius) * 0.001f;
		}

		public float GetBuffTriggerRate()
		{
			return (float)this.GetSum(CombatEffectType.CET_Buff_TriggerRate) * 0.001f;
		}

		public float GetBuffDuration()
		{
			return (float)this.GetSum(CombatEffectType.CET_Buff_Duration) * 0.001f;
		}

		public bool GetSkillAddBuff(ref List<BuffDesc> vecBuffs, XSkillFlags flags)
		{
			EffectDataParams.TypeDataCollection typeDataList = CombatEffectHelper.GetTypeDataList(CombatEffectType.CET_Skill_AddBuff, this);
			bool flag = typeDataList == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < typeDataList.datas.Count; i++)
				{
					EffectDataParams.TypeData typeData = typeDataList.datas[i];
					for (int j = 0; j < typeData.constantParams.Count; j++)
					{
						string[] array = typeData.constantParams[j].Split(CombatEffectHelper.ConstantSeparator);
						bool flag2 = array.Length >= 4 && flags != null && !flags.IsFlagSet(uint.Parse(array[3]));
						if (!flag2)
						{
							bool flag3 = array.Length == 0;
							if (!flag3)
							{
								BuffDesc item;
								item.BuffID = int.Parse(array[0]);
								item.BuffLevel = ((array.Length >= 2) ? int.Parse(array[1]) : 1);
								item.DelayTime = ((array.Length >= 3) ? float.Parse(array[2]) : 0f);
								item.SkillID = this.m_SkillHash;
								item.EffectTime = BuffDesc.DEFAULT_TIME;
								item.CasterID = 0UL;
								bool flag4 = vecBuffs == null;
								if (flag4)
								{
									vecBuffs = new List<BuffDesc>();
								}
								vecBuffs.Add(item);
							}
						}
					}
				}
				result = true;
			}
			return result;
		}

		public bool GetSkillAddMobBuff(int skillLevel, List<BuffDesc> vecBuffs)
		{
			EffectDataParams.TypeDataCollection typeDataList = CombatEffectHelper.GetTypeDataList(CombatEffectType.CET_Skill_AddMobBuff, this);
			bool flag = typeDataList == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < typeDataList.datas.Count; i++)
				{
					EffectDataParams.TypeData typeData = typeDataList.datas[i];
					for (int j = 0; j < typeData.constantParams.Count; j++)
					{
						string[] array = typeData.constantParams[j].Split(CombatEffectHelper.ConstantSeparator);
						bool flag2 = array.Length == 0;
						if (!flag2)
						{
							BuffDesc item;
							item.BuffID = int.Parse(array[0]);
							item.BuffLevel = ((array.Length >= 2) ? int.Parse(array[1]) : skillLevel);
							item.DelayTime = 0f;
							item.SkillID = 0U;
							item.EffectTime = BuffDesc.DEFAULT_TIME;
							item.CasterID = 0UL;
							vecBuffs.Add(item);
						}
					}
				}
				result = true;
			}
			return result;
		}

		private ISeqListRef<string> _GetBuffReduceSkillCDData(BuffTable.RowData pBuffData)
		{
			return pBuffData.ReduceSkillCD;
		}

		public bool GetBuffReduceSkillCD(SequenceList<uint> vecOut)
		{
			CombatEffectHelper.GetSeqListDataFromVecStringParam getSeqListDataFromVecStringParam;
			getSeqListDataFromVecStringParam.dim = 3;
			getSeqListDataFromVecStringParam.helper = this;
			getSeqListDataFromVecStringParam.hashIndex = 0;
			getSeqListDataFromVecStringParam.replaceIndex = 1;
			getSeqListDataFromVecStringParam.type = CombatEffectType.CET_Buff_ReduceCD;
			bool vecSequenceSumFromVecString = this.GetVecSequenceSumFromVecString(ref getSeqListDataFromVecStringParam, vecOut, new GetBuffDataSeqListString(this._GetBuffReduceSkillCDData), 3);
			this.Merge(vecOut, 1);
			return vecSequenceSumFromVecString;
		}

		private ISeqListRef<string> _GetBuffChangeSkillDamageData(BuffTable.RowData pBuffData)
		{
			return pBuffData.ChangeSkillDamage;
		}

		public bool GetBuffChangeSkillDamage(SequenceList<uint> vecOut)
		{
			CombatEffectHelper.GetSeqListDataFromVecStringParam getSeqListDataFromVecStringParam;
			getSeqListDataFromVecStringParam.dim = 2;
			getSeqListDataFromVecStringParam.helper = this;
			getSeqListDataFromVecStringParam.hashIndex = 0;
			getSeqListDataFromVecStringParam.replaceIndex = 1;
			getSeqListDataFromVecStringParam.type = CombatEffectType.CET_Buff_ChangeSkillDamage;
			return this.GetVecSequenceSumFromVecString(ref getSeqListDataFromVecStringParam, vecOut, new GetBuffDataSeqListString(this._GetBuffChangeSkillDamageData), 2);
		}

		public bool GetBuffChangeDamage(out double castDamage, out double receiveDamage)
		{
			castDamage = (double)this.GetSum(CombatEffectType.CET_Buff_ChangeDamage_Cast) * 0.001;
			receiveDamage = (double)this.GetSum(CombatEffectType.CET_Buff_ChangeDamage_Receive) * 0.001;
			return true;
		}

		private ISeqListRef<float> _GetBuffDOTData(BuffTable.RowData pBuffData)
		{
			return pBuffData.BuffDOT;
		}

		private ISeqListRef<int> _GetBuffDOTFromCasterData(BuffTable.RowData pBuffData)
		{
			return pBuffData.BuffDOTValueFromCaster;
		}

		public bool GetBuffRegenerate(SequenceList<float> vecDotOut, SequenceList<int> vecFromCasterOut)
		{
			bool flag = true;
			CombatEffectHelper.GetSeqListDataParam getSeqListDataParam;
			getSeqListDataParam.dim = 3;
			getSeqListDataParam.helper = this;
			getSeqListDataParam.ratio = 0.001;
			getSeqListDataParam.replaceIndex = 1;
			getSeqListDataParam.type = CombatEffectType.CET_Buff_DOTorHOT;
			flag = (flag && this.GetVecSequenceSum(ref getSeqListDataParam, vecDotOut, new GetBuffDataSeqListFloat(this._GetBuffDOTData), 3));
			CombatEffectHelper.GetSeqListDataParam getSeqListDataParam2;
			getSeqListDataParam2.dim = 2;
			getSeqListDataParam2.helper = this;
			getSeqListDataParam2.ratio = 0.001;
			getSeqListDataParam2.replaceIndex = 1;
			getSeqListDataParam2.type = CombatEffectType.CET_Buff_DOTorHOT;
			return flag && this.GetVecSequenceSum(ref getSeqListDataParam2, vecFromCasterOut, new GetBuffDataSeqListInt(this._GetBuffDOTFromCasterData), 2);
		}

		private BuffTable.RowData m_pBuffInfo;

		private EffectDataParams m_pEffectData;

		private uint m_SkillHash;

		private uint m_ActualSkillHash;

		private CombatEffectType m_CacheType;

		private EffectDataParams.TypeDataCollection m_CacheCollection;

		private Dictionary<uint, BuffTable.RowData> m_Template2BuffTable = new Dictionary<uint, BuffTable.RowData>();

		private static float[] startDataBufferFloat = new float[10];

		private static float[] curDataBufferFloat = new float[10];

		private static uint[] startDataBufferUint = new uint[10];

		private static uint[] curDataBufferUint = new uint[10];

		public static readonly char[] ConstantSeparator = new char[]
		{
			'^'
		};

		private struct GetSeqDataParam
		{

			public GetSeqDataParam(int dimension)
			{
				this.helper = null;
				this.dim = dimension;
				this.type = CombatEffectType.CET_INVALID;
				this.replaceIndex = 0;
				this.ratio = 0.0;
			}

			public CombatEffectHelper helper;

			public int dim;

			public CombatEffectType type;

			public int replaceIndex;

			public double ratio;
		}

		private struct GetSeqListDataParam
		{

			public GetSeqListDataParam(int dimension)
			{
				this.helper = null;
				this.dim = dimension;
				this.type = CombatEffectType.CET_INVALID;
				this.replaceIndex = 0;
				this.ratio = 0.0;
			}

			public CombatEffectHelper helper;

			public int dim;

			public CombatEffectType type;

			public int replaceIndex;

			public double ratio;
		}

		private struct GetSeqListDataFromVecStringParam
		{

			public GetSeqListDataFromVecStringParam(int dimension)
			{
				this.helper = null;
				this.dim = dimension;
				this.type = CombatEffectType.CET_INVALID;
				this.replaceIndex = 0;
				this.hashIndex = 0;
			}

			public CombatEffectHelper helper;

			public int dim;

			public CombatEffectType type;

			public int replaceIndex;

			public int hashIndex;
		}
	}
}
