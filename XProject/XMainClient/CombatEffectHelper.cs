using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B0D RID: 2829
	internal class CombatEffectHelper : XDataBase
	{
		// Token: 0x17002FF5 RID: 12277
		// (get) Token: 0x0600A670 RID: 42608 RVA: 0x001D3ED8 File Offset: 0x001D20D8
		public BuffTable.RowData BuffInfo
		{
			get
			{
				return this.m_pBuffInfo;
			}
		}

		// Token: 0x17002FF6 RID: 12278
		// (get) Token: 0x0600A671 RID: 42609 RVA: 0x001D3EF0 File Offset: 0x001D20F0
		public EffectDataParams EffectData
		{
			get
			{
				return this.m_pEffectData;
			}
		}

		// Token: 0x17002FF7 RID: 12279
		// (get) Token: 0x0600A672 RID: 42610 RVA: 0x001D3F08 File Offset: 0x001D2108
		public CombatEffectType CacheQueryType
		{
			get
			{
				return this.m_CacheType;
			}
		}

		// Token: 0x17002FF8 RID: 12280
		// (get) Token: 0x0600A673 RID: 42611 RVA: 0x001D3F20 File Offset: 0x001D2120
		public EffectDataParams.TypeDataCollection CacheTypeDataCollection
		{
			get
			{
				return this.m_CacheCollection;
			}
		}

		// Token: 0x0600A674 RID: 42612 RVA: 0x001D3F38 File Offset: 0x001D2138
		public void SetCacheQuery(CombatEffectType type, EffectDataParams.TypeDataCollection collection)
		{
			this.m_CacheType = type;
			this.m_CacheCollection = collection;
		}

		// Token: 0x0600A675 RID: 42613 RVA: 0x001D3F49 File Offset: 0x001D2149
		public void ClearCache()
		{
			this.m_CacheCollection = null;
			this.m_CacheType = CombatEffectType.CET_INVALID;
		}

		// Token: 0x0600A676 RID: 42614 RVA: 0x001D3F5C File Offset: 0x001D215C
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

		// Token: 0x0600A677 RID: 42615 RVA: 0x001D3FA0 File Offset: 0x001D21A0
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

		// Token: 0x0600A678 RID: 42616 RVA: 0x001D3FE0 File Offset: 0x001D21E0
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

		// Token: 0x0600A679 RID: 42617 RVA: 0x001D4074 File Offset: 0x001D2274
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

		// Token: 0x0600A67A RID: 42618 RVA: 0x001D40B8 File Offset: 0x001D22B8
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

		// Token: 0x0600A67B RID: 42619 RVA: 0x001D412A File Offset: 0x001D232A
		public void Set(string skillName, XEntity entity)
		{
			this.Set(XSingleton<XCommon>.singleton.XHash(skillName), entity);
		}

		// Token: 0x0600A67C RID: 42620 RVA: 0x001D4140 File Offset: 0x001D2340
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

		// Token: 0x0600A67D RID: 42621 RVA: 0x001D41F0 File Offset: 0x001D23F0
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

		// Token: 0x0600A67E RID: 42622 RVA: 0x001D4250 File Offset: 0x001D2450
		public bool bHasEffect(CombatEffectType type)
		{
			return CombatEffectHelper.GetTypeDataList(type, this) != null;
		}

		// Token: 0x0600A67F RID: 42623 RVA: 0x001D426C File Offset: 0x001D246C
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

		// Token: 0x0600A680 RID: 42624 RVA: 0x001D42F8 File Offset: 0x001D24F8
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

		// Token: 0x0600A681 RID: 42625 RVA: 0x001D4430 File Offset: 0x001D2630
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

		// Token: 0x0600A682 RID: 42626 RVA: 0x001D453C File Offset: 0x001D273C
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

		// Token: 0x0600A683 RID: 42627 RVA: 0x001D4648 File Offset: 0x001D2848
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

		// Token: 0x0600A684 RID: 42628 RVA: 0x001D4754 File Offset: 0x001D2954
		private float _Double2Float(double d)
		{
			return (float)d;
		}

		// Token: 0x0600A685 RID: 42629 RVA: 0x001D4768 File Offset: 0x001D2968
		private uint _Double2Uint(double d)
		{
			return (uint)d;
		}

		// Token: 0x0600A686 RID: 42630 RVA: 0x001D477C File Offset: 0x001D297C
		private int _Double2Int(double d)
		{
			return (int)d;
		}

		// Token: 0x0600A687 RID: 42631 RVA: 0x001D4790 File Offset: 0x001D2990
		private uint _Uint2Uint(uint u)
		{
			return u;
		}

		// Token: 0x0600A688 RID: 42632 RVA: 0x001D47A4 File Offset: 0x001D29A4
		private uint _Int2Uint(int u)
		{
			return (uint)u;
		}

		// Token: 0x0600A689 RID: 42633 RVA: 0x001D47B8 File Offset: 0x001D29B8
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

		// Token: 0x0600A68A RID: 42634 RVA: 0x001D4820 File Offset: 0x001D2A20
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

		// Token: 0x0600A68B RID: 42635 RVA: 0x001D4880 File Offset: 0x001D2A80
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

		// Token: 0x0600A68C RID: 42636 RVA: 0x001D493C File Offset: 0x001D2B3C
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

		// Token: 0x0600A68D RID: 42637 RVA: 0x001D49F8 File Offset: 0x001D2BF8
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

		// Token: 0x0600A68E RID: 42638 RVA: 0x001D4AE8 File Offset: 0x001D2CE8
		public static float Add(float left, float right)
		{
			return left + right;
		}

		// Token: 0x0600A68F RID: 42639 RVA: 0x001D4B00 File Offset: 0x001D2D00
		public static int Add(int left, int right)
		{
			return left + right;
		}

		// Token: 0x0600A690 RID: 42640 RVA: 0x001D4B18 File Offset: 0x001D2D18
		public static uint Add(uint left, uint right)
		{
			return left + right;
		}

		// Token: 0x0600A691 RID: 42641 RVA: 0x001D4B30 File Offset: 0x001D2D30
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

		// Token: 0x0600A692 RID: 42642 RVA: 0x001D4BA0 File Offset: 0x001D2DA0
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

		// Token: 0x0600A693 RID: 42643 RVA: 0x001D4C7C File Offset: 0x001D2E7C
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

		// Token: 0x0600A694 RID: 42644 RVA: 0x001D4D58 File Offset: 0x001D2F58
		private ISeqRef<float> _GetBuffHPData(BuffTable.RowData pBuffData)
		{
			return pBuffData.BuffHP;
		}

		// Token: 0x0600A695 RID: 42645 RVA: 0x001D4D78 File Offset: 0x001D2F78
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

		// Token: 0x0600A696 RID: 42646 RVA: 0x001D4DD0 File Offset: 0x001D2FD0
		private ISeqListRef<float> _GetBuffChangeAttributeData(BuffTable.RowData pBuffData)
		{
			return pBuffData.BuffChangeAttribute;
		}

		// Token: 0x0600A697 RID: 42647 RVA: 0x001D4DF0 File Offset: 0x001D2FF0
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

		// Token: 0x0600A698 RID: 42648 RVA: 0x001D4E54 File Offset: 0x001D3054
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

		// Token: 0x0600A699 RID: 42649 RVA: 0x001D4E90 File Offset: 0x001D3090
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

		// Token: 0x0600A69A RID: 42650 RVA: 0x001D4EE8 File Offset: 0x001D30E8
		public float GetBuffAuraRadius()
		{
			return (float)this.GetSum(CombatEffectType.CET_Buff_AuraRadius) * 0.001f;
		}

		// Token: 0x0600A69B RID: 42651 RVA: 0x001D4F08 File Offset: 0x001D3108
		public float GetBuffTriggerRate()
		{
			return (float)this.GetSum(CombatEffectType.CET_Buff_TriggerRate) * 0.001f;
		}

		// Token: 0x0600A69C RID: 42652 RVA: 0x001D4F28 File Offset: 0x001D3128
		public float GetBuffDuration()
		{
			return (float)this.GetSum(CombatEffectType.CET_Buff_Duration) * 0.001f;
		}

		// Token: 0x0600A69D RID: 42653 RVA: 0x001D4F48 File Offset: 0x001D3148
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

		// Token: 0x0600A69E RID: 42654 RVA: 0x001D50AC File Offset: 0x001D32AC
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

		// Token: 0x0600A69F RID: 42655 RVA: 0x001D51BC File Offset: 0x001D33BC
		private ISeqListRef<string> _GetBuffReduceSkillCDData(BuffTable.RowData pBuffData)
		{
			return pBuffData.ReduceSkillCD;
		}

		// Token: 0x0600A6A0 RID: 42656 RVA: 0x001D51DC File Offset: 0x001D33DC
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

		// Token: 0x0600A6A1 RID: 42657 RVA: 0x001D5238 File Offset: 0x001D3438
		private ISeqListRef<string> _GetBuffChangeSkillDamageData(BuffTable.RowData pBuffData)
		{
			return pBuffData.ChangeSkillDamage;
		}

		// Token: 0x0600A6A2 RID: 42658 RVA: 0x001D5258 File Offset: 0x001D3458
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

		// Token: 0x0600A6A3 RID: 42659 RVA: 0x001D52A8 File Offset: 0x001D34A8
		public bool GetBuffChangeDamage(out double castDamage, out double receiveDamage)
		{
			castDamage = (double)this.GetSum(CombatEffectType.CET_Buff_ChangeDamage_Cast) * 0.001;
			receiveDamage = (double)this.GetSum(CombatEffectType.CET_Buff_ChangeDamage_Receive) * 0.001;
			return true;
		}

		// Token: 0x0600A6A4 RID: 42660 RVA: 0x001D52E4 File Offset: 0x001D34E4
		private ISeqListRef<float> _GetBuffDOTData(BuffTable.RowData pBuffData)
		{
			return pBuffData.BuffDOT;
		}

		// Token: 0x0600A6A5 RID: 42661 RVA: 0x001D5304 File Offset: 0x001D3504
		private ISeqListRef<int> _GetBuffDOTFromCasterData(BuffTable.RowData pBuffData)
		{
			return pBuffData.BuffDOTValueFromCaster;
		}

		// Token: 0x0600A6A6 RID: 42662 RVA: 0x001D5324 File Offset: 0x001D3524
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

		// Token: 0x04003D37 RID: 15671
		private BuffTable.RowData m_pBuffInfo;

		// Token: 0x04003D38 RID: 15672
		private EffectDataParams m_pEffectData;

		// Token: 0x04003D39 RID: 15673
		private uint m_SkillHash;

		// Token: 0x04003D3A RID: 15674
		private uint m_ActualSkillHash;

		// Token: 0x04003D3B RID: 15675
		private CombatEffectType m_CacheType;

		// Token: 0x04003D3C RID: 15676
		private EffectDataParams.TypeDataCollection m_CacheCollection;

		// Token: 0x04003D3D RID: 15677
		private Dictionary<uint, BuffTable.RowData> m_Template2BuffTable = new Dictionary<uint, BuffTable.RowData>();

		// Token: 0x04003D3E RID: 15678
		private static float[] startDataBufferFloat = new float[10];

		// Token: 0x04003D3F RID: 15679
		private static float[] curDataBufferFloat = new float[10];

		// Token: 0x04003D40 RID: 15680
		private static uint[] startDataBufferUint = new uint[10];

		// Token: 0x04003D41 RID: 15681
		private static uint[] curDataBufferUint = new uint[10];

		// Token: 0x04003D42 RID: 15682
		public static readonly char[] ConstantSeparator = new char[]
		{
			'^'
		};

		// Token: 0x02001993 RID: 6547
		private struct GetSeqDataParam
		{
			// Token: 0x06011024 RID: 69668 RVA: 0x00453741 File Offset: 0x00451941
			public GetSeqDataParam(int dimension)
			{
				this.helper = null;
				this.dim = dimension;
				this.type = CombatEffectType.CET_INVALID;
				this.replaceIndex = 0;
				this.ratio = 0.0;
			}

			// Token: 0x04007F04 RID: 32516
			public CombatEffectHelper helper;

			// Token: 0x04007F05 RID: 32517
			public int dim;

			// Token: 0x04007F06 RID: 32518
			public CombatEffectType type;

			// Token: 0x04007F07 RID: 32519
			public int replaceIndex;

			// Token: 0x04007F08 RID: 32520
			public double ratio;
		}

		// Token: 0x02001994 RID: 6548
		private struct GetSeqListDataParam
		{
			// Token: 0x06011025 RID: 69669 RVA: 0x0045376F File Offset: 0x0045196F
			public GetSeqListDataParam(int dimension)
			{
				this.helper = null;
				this.dim = dimension;
				this.type = CombatEffectType.CET_INVALID;
				this.replaceIndex = 0;
				this.ratio = 0.0;
			}

			// Token: 0x04007F09 RID: 32521
			public CombatEffectHelper helper;

			// Token: 0x04007F0A RID: 32522
			public int dim;

			// Token: 0x04007F0B RID: 32523
			public CombatEffectType type;

			// Token: 0x04007F0C RID: 32524
			public int replaceIndex;

			// Token: 0x04007F0D RID: 32525
			public double ratio;
		}

		// Token: 0x02001995 RID: 6549
		private struct GetSeqListDataFromVecStringParam
		{
			// Token: 0x06011026 RID: 69670 RVA: 0x0045379D File Offset: 0x0045199D
			public GetSeqListDataFromVecStringParam(int dimension)
			{
				this.helper = null;
				this.dim = dimension;
				this.type = CombatEffectType.CET_INVALID;
				this.replaceIndex = 0;
				this.hashIndex = 0;
			}

			// Token: 0x04007F0E RID: 32526
			public CombatEffectHelper helper;

			// Token: 0x04007F0F RID: 32527
			public int dim;

			// Token: 0x04007F10 RID: 32528
			public CombatEffectType type;

			// Token: 0x04007F11 RID: 32529
			public int replaceIndex;

			// Token: 0x04007F12 RID: 32530
			public int hashIndex;
		}
	}
}
