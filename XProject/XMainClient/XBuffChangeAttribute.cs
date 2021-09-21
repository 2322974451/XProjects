using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DB3 RID: 3507
	internal class XBuffChangeAttribute : BuffEffect
	{
		// Token: 0x0600BE28 RID: 48680 RVA: 0x00278F50 File Offset: 0x00277150
		public static bool TryCreate(CombatEffectHelper helper, XBuff buff)
		{
			bool flag = helper.BuffInfo.BuffChangeAttribute.Count == 0 && !helper.bHasEffect(CombatEffectType.CET_Buff_ChangeAttribute);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffChangeAttribute(buff));
				result = true;
			}
			return result;
		}

		// Token: 0x0600BE29 RID: 48681 RVA: 0x00278F98 File Offset: 0x00277198
		public XBuffChangeAttribute(XBuff buff)
		{
			this._buff = buff;
		}

		// Token: 0x0600BE2A RID: 48682 RVA: 0x00278FF0 File Offset: 0x002771F0
		private void _Convert(int attrID, double deltaValue)
		{
			bool flag = this.m_Entity == null || this.m_Entity.Attributes == null;
			if (!flag)
			{
				bool flag2 = !this.m_Entity.IsRole;
				if (!flag2)
				{
					int basicTypeID = (int)this.m_Entity.Attributes.BasicTypeID;
					bool flag3 = !XAttributeCommon.IsFirstLevelAttr((XAttributeDefine)attrID);
					if (!flag3)
					{
						int basicAttr = XAttributeCommon.GetBasicAttr(attrID);
						XTuple<int, double>[] convertCoefficient = XSingleton<XPowerPointCalculator>.singleton.GetConvertCoefficient(basicAttr, basicTypeID);
						bool flag4 = convertCoefficient == null;
						if (!flag4)
						{
							bool flag5 = XAttributeCommon.IsPercentRange(attrID);
							if (flag5)
							{
								deltaValue *= 0.01 * this.m_Entity.Attributes.GetAttr((XAttributeDefine)basicAttr);
							}
							bool flag6 = Math.Abs(deltaValue) < 1E-06;
							if (!flag6)
							{
								bool flag7 = this.m_AdditionalAttrs == null;
								if (flag7)
								{
									this.m_AdditionalAttrs = ListPool<XAttrPair>.Get();
								}
								for (int i = 0; i < convertCoefficient.Length; i++)
								{
									XAttributeDefine item = (XAttributeDefine)convertCoefficient[i].Item1;
									double value = convertCoefficient[i].Item2 * deltaValue;
									XAttributeDefine attrCurAttr = XAttributeCommon.GetAttrCurAttr(item);
									bool flag8 = attrCurAttr != XAttributeDefine.XAttr_Invalid;
									if (flag8)
									{
										bool flag9 = deltaValue > 0.0;
										if (flag9)
										{
											this.m_AdditionalAttrs.Add(new XAttrPair(item, value));
											this.m_AdditionalAttrs.Add(new XAttrPair(attrCurAttr, value));
										}
										else
										{
											this.m_AdditionalAttrs.Add(new XAttrPair(attrCurAttr, value));
											this.m_AdditionalAttrs.Add(new XAttrPair(item, value));
										}
									}
									else
									{
										this.m_AdditionalAttrs.Add(new XAttrPair(item, value));
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600BE2B RID: 48683 RVA: 0x002791C4 File Offset: 0x002773C4
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this.m_Entity = entity;
			bool flag = entity.IsDummy || entity.IsDead;
			if (!flag)
			{
				this.m_bChanging = true;
				bool flag2 = pEffectHelper.bHasEffect(CombatEffectType.CET_Buff_ChangeAttribute);
				ISeqListRef<float> seqListRef;
				if (flag2)
				{
					this.m_OriginalAttrs = CommonObjectPool<SequenceList<float>>.Get();
					this.m_OriginalAttrs.Reset(3);
					this.m_OriginalAttrs.Append(this._buff.BuffInfo.BuffChangeAttribute, 3);
					pEffectHelper.GetBuffChangeAttribute(this.m_OriginalAttrs);
					seqListRef = this.m_OriginalAttrs;
				}
				else
				{
					seqListRef = this._buff.BuffInfo.BuffChangeAttribute;
				}
				for (int i = 0; i < seqListRef.Count; i++)
				{
					XAttributeDefine attrKey = (XAttributeDefine)seqListRef[i, 0];
					double num = (double)seqListRef[i, 1];
					bool flag3 = seqListRef[i, 2] != 0f;
					if (flag3)
					{
						XAttributeDefine xattributeDefine = (XAttributeDefine)seqListRef[i, 2];
						num *= entity.Attributes.GetAttr(xattributeDefine);
						this.m_ConvertorDeltaValue[i] = num;
						this.m_SetConvertor.Add(xattributeDefine);
					}
					XBuffChangeAttribute.ChangeAttribute(entity.Attributes, attrKey, num);
					this._Convert((int)seqListRef[i, 0], num);
				}
				bool flag4 = this.m_AdditionalAttrs != null;
				if (flag4)
				{
					for (int j = 0; j < this.m_AdditionalAttrs.Count; j++)
					{
						XBuffChangeAttribute.ChangeAttribute(entity.Attributes, this.m_AdditionalAttrs[j].AttrID, this.m_AdditionalAttrs[j].AttrValue);
					}
				}
				this.m_bChanging = false;
			}
		}

		// Token: 0x0600BE2C RID: 48684 RVA: 0x00279388 File Offset: 0x00277588
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			bool flag = entity.IsDummy || entity.IsDead;
			if (!flag)
			{
				this.m_bChanging = true;
				XSecurityBuffInfo xsecurityBuffInfo = XSecurityBuffInfo.TryGetStatistics(entity);
				bool flag2 = this.m_AdditionalAttrs != null;
				if (flag2)
				{
					for (int i = this.m_AdditionalAttrs.Count - 1; i >= 0; i--)
					{
						bool flag3 = xsecurityBuffInfo != null;
						if (flag3)
						{
							xsecurityBuffInfo.OnAttributeChanged(entity.Attributes, this._buff, this.m_AdditionalAttrs[i].AttrID, this.m_AdditionalAttrs[i].AttrValue);
						}
						XBuffChangeAttribute.ChangeAttribute(entity.Attributes, this.m_AdditionalAttrs[i].AttrID, -this.m_AdditionalAttrs[i].AttrValue);
					}
				}
				ISeqListRef<float> seqListRef = this.m_OriginalAttrs;
				bool flag4 = seqListRef == null;
				if (flag4)
				{
					seqListRef = this._buff.BuffInfo.BuffChangeAttribute;
				}
				for (int j = seqListRef.Count - 1; j >= 0; j--)
				{
					XAttributeDefine xattributeDefine = (XAttributeDefine)seqListRef[j, 0];
					double num = (double)(-(double)seqListRef[j, 1]);
					bool flag5 = seqListRef[j, 2] != 0f && this.m_ConvertorDeltaValue.ContainsKey(j);
					if (flag5)
					{
						num = -this.m_ConvertorDeltaValue[j];
					}
					bool flag6 = xsecurityBuffInfo != null;
					if (flag6)
					{
						xsecurityBuffInfo.OnAttributeChanged(entity.Attributes, this._buff, xattributeDefine, -num);
					}
					XBuffChangeAttribute.ChangeAttribute(entity.Attributes, xattributeDefine, num);
				}
				this.m_bChanging = false;
				this._buff = null;
				bool flag7 = this.m_AdditionalAttrs != null;
				if (flag7)
				{
					ListPool<XAttrPair>.Release(this.m_AdditionalAttrs);
					this.m_AdditionalAttrs = null;
				}
				bool flag8 = this.m_OriginalAttrs != null;
				if (flag8)
				{
					CommonObjectPool<SequenceList<float>>.Release(this.m_OriginalAttrs);
					this.m_OriginalAttrs = null;
				}
			}
		}

		// Token: 0x0600BE2D RID: 48685 RVA: 0x00279594 File Offset: 0x00277794
		public override void OnBattleEnd(XEntity entity)
		{
			base.OnBattleEnd(entity);
			bool flag = entity.IsDummy || entity.IsDead;
			if (!flag)
			{
				XSecurityBuffInfo xsecurityBuffInfo = XSecurityBuffInfo.TryGetStatistics(entity);
				bool flag2 = xsecurityBuffInfo == null;
				if (!flag2)
				{
					bool flag3 = this.m_AdditionalAttrs != null;
					if (flag3)
					{
						for (int i = this.m_AdditionalAttrs.Count - 1; i >= 0; i--)
						{
							bool flag4 = xsecurityBuffInfo != null;
							if (flag4)
							{
								xsecurityBuffInfo.OnAttributeChanged(entity.Attributes, this._buff, this.m_AdditionalAttrs[i].AttrID, this.m_AdditionalAttrs[i].AttrValue);
							}
						}
					}
					ISeqListRef<float> seqListRef = this.m_OriginalAttrs;
					bool flag5 = seqListRef == null;
					if (flag5)
					{
						seqListRef = this._buff.BuffInfo.BuffChangeAttribute;
					}
					for (int j = seqListRef.Count - 1; j >= 0; j--)
					{
						XAttributeDefine attr = (XAttributeDefine)seqListRef[j, 0];
						double num = (double)(-(double)seqListRef[j, 1]);
						bool flag6 = seqListRef[j, 2] != 0f && this.m_ConvertorDeltaValue.ContainsKey(j);
						if (flag6)
						{
							num = -this.m_ConvertorDeltaValue[j];
						}
						bool flag7 = xsecurityBuffInfo != null;
						if (flag7)
						{
							xsecurityBuffInfo.OnAttributeChanged(entity.Attributes, this._buff, attr, -num);
						}
					}
				}
			}
		}

		// Token: 0x0600BE2E RID: 48686 RVA: 0x00279710 File Offset: 0x00277910
		public override void OnAttributeChanged(XAttrChangeEventArgs e)
		{
			base.OnAttributeChanged(e);
			bool flag = this.m_Entity.IsDummy || this.m_Entity.IsDead;
			if (!flag)
			{
				bool bChanging = this.m_bChanging;
				if (!bChanging)
				{
					bool flag2 = !this.m_SetConvertor.Contains(e.AttrKey) || this.m_ConvertorDeltaValue.Count == 0;
					if (!flag2)
					{
						this.m_bChanging = true;
						ISeqListRef<float> seqListRef = this.m_OriginalAttrs;
						bool flag3 = seqListRef == null;
						if (flag3)
						{
							seqListRef = this._buff.BuffInfo.BuffChangeAttribute;
						}
						for (int i = 0; i < seqListRef.Count; i++)
						{
							bool flag4 = seqListRef[i, 2] == 0f;
							if (!flag4)
							{
								XAttributeDefine xattributeDefine = (XAttributeDefine)seqListRef[i, 2];
								bool flag5 = xattributeDefine != e.AttrKey;
								if (!flag5)
								{
									double num;
									bool flag6 = !this.m_ConvertorDeltaValue.TryGetValue(i, out num);
									if (!flag6)
									{
										double num2 = (double)seqListRef[i, 1];
										num2 *= this.m_Entity.Attributes.GetAttr(xattributeDefine);
										XAttributeDefine attrKey = (XAttributeDefine)seqListRef[i, 0];
										double num3 = num2 - num;
										Dictionary<int, double> convertorDeltaValue = this.m_ConvertorDeltaValue;
										int key = i;
										convertorDeltaValue[key] += num3;
										XBuffChangeAttribute.ChangeAttribute(this.m_Entity.Attributes, attrKey, num3);
									}
								}
							}
						}
						this.m_bChanging = false;
					}
				}
			}
		}

		// Token: 0x0600BE2F RID: 48687 RVA: 0x002798A4 File Offset: 0x00277AA4
		public static void ChangeAttribute(XAttributes attributes, XAttributeDefine attrKey, double attrValue)
		{
			bool flag = attributes == null || attributes.Entity == null;
			if (!flag)
			{
				XEntity entity = attributes.Entity;
				PercentWatcher percentWatcher = new PercentWatcher(attributes, attrKey, attrValue / 100.0);
				double num = XCombat.CheckChangeHPLimit(attrKey, attrValue, entity, true, true);
				bool flag2 = num == 0.0;
				if (!flag2)
				{
					XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
					@event.AttrKey = attrKey;
					@event.DeltaValue = num;
					@event.Firer = entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					percentWatcher.Check();
				}
			}
		}

		// Token: 0x04004DA2 RID: 19874
		private XBuff _buff = null;

		// Token: 0x04004DA3 RID: 19875
		private HashSet<XAttributeDefine> m_SetConvertor = new HashSet<XAttributeDefine>(default(XFastEnumIntEqualityComparer<XAttributeDefine>));

		// Token: 0x04004DA4 RID: 19876
		private Dictionary<int, double> m_ConvertorDeltaValue = new Dictionary<int, double>();

		// Token: 0x04004DA5 RID: 19877
		private SequenceList<float> m_OriginalAttrs = null;

		// Token: 0x04004DA6 RID: 19878
		private List<XAttrPair> m_AdditionalAttrs = null;

		// Token: 0x04004DA7 RID: 19879
		private bool m_bChanging;

		// Token: 0x04004DA8 RID: 19880
		private XEntity m_Entity;
	}
}
