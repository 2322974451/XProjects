using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffRegenerate : BuffEffect
	{

		public static bool TryCreate(CombatEffectHelper pEffectHelper, XBuff buff)
		{
			bool flag = pEffectHelper.BuffInfo.BuffDOT.Count == 0 && !pEffectHelper.bHasEffect(CombatEffectType.CET_Buff_DOTorHOT);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffRegenerate(buff));
				result = true;
			}
			return result;
		}

		public XBuffRegenerate(XBuff buff)
		{
			this._buff = buff;
			this._onTimeCb = new XTimerMgr.AccurateElapsedEventHandler(this.OnTimer);
		}

		private void ConvertSpecialBuff(DotTimeInfo info)
		{
			bool flag = info.attrID == XAttributeDefine.XAttr_MaxHP_Percent;
			if (flag)
			{
				info.attrID = XAttributeDefine.XAttr_CurrentHP_Basic;
				info.attrValue *= this._component.Entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total) / 100.0;
			}
		}

		private double _GetCasterAttr(XEntity caster, int attrID, int attrValue)
		{
			bool flag = caster != null && !caster.Deprecated;
			double result;
			if (flag)
			{
				result = caster.Attributes.GetAttr((XAttributeDefine)attrID) * (double)attrValue / 100.0;
			}
			else
			{
				result = 0.0;
			}
			return result;
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			bool isDummy = entity.IsDummy;
			if (!isDummy)
			{
				this._NextTime = float.MaxValue;
				this._StartTime = Time.time;
				this._component = entity.Buffs;
				XEntity xentity = null;
				SequenceList<float> sequenceList = null;
				SequenceList<int> sequenceList2 = null;
				bool flag = pEffectHelper.bHasEffect(CombatEffectType.CET_Buff_DOTorHOT);
				ISeqListRef<float> seqListRef;
				ISeqListRef<int> seqListRef2;
				if (flag)
				{
					sequenceList = CommonObjectPool<SequenceList<float>>.Get();
					sequenceList2 = CommonObjectPool<SequenceList<int>>.Get();
					sequenceList.Reset(3);
					sequenceList2.Reset(2);
					sequenceList.Append(this._buff.BuffInfo.BuffDOT, 3);
					sequenceList2.Append(this._buff.BuffInfo.BuffDOTValueFromCaster, 2);
					bool buffRegenerate = pEffectHelper.GetBuffRegenerate(sequenceList, sequenceList2);
					if (buffRegenerate)
					{
						seqListRef = sequenceList;
						seqListRef2 = sequenceList2;
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Data error when get dothot for buff ", this._buff.BuffInfo.BuffID.ToString(), null, null, null, null);
						seqListRef = this._buff.BuffInfo.BuffDOT;
						seqListRef2 = this._buff.BuffInfo.BuffDOTValueFromCaster;
						CommonObjectPool<SequenceList<int>>.Release(sequenceList2);
						CommonObjectPool<SequenceList<float>>.Release(sequenceList);
						sequenceList2 = null;
						sequenceList = null;
					}
				}
				else
				{
					seqListRef = this._buff.BuffInfo.BuffDOT;
					seqListRef2 = this._buff.BuffInfo.BuffDOTValueFromCaster;
				}
				int count = seqListRef.Count;
				bool flag2 = seqListRef2.Count == count;
				if (flag2)
				{
					xentity = XSingleton<XEntityMgr>.singleton.GetEntity(this._buff.CasterID);
					bool flag3 = sequenceList != null;
					if (flag3)
					{
						for (int i = 0; i < count; i++)
						{
							bool flag4 = sequenceList2[i, 0] != 0;
							if (flag4)
							{
								sequenceList[i, 1] = (float)this._GetCasterAttr(xentity, sequenceList2[i, 0], sequenceList2[i, 1]);
							}
						}
					}
				}
				bool flag5 = sequenceList != null;
				if (flag5)
				{
					pEffectHelper.Merge(sequenceList, 1);
					count = seqListRef.Count;
				}
				this._Dots = new List<DotTimeInfo>();
				for (int j = 0; j < count; j++)
				{
					DotTimeInfo dotTimeInfo = new DotTimeInfo();
					dotTimeInfo.attrID = (XAttributeDefine)seqListRef[j, 0];
					dotTimeInfo.attrValue = (double)seqListRef[j, 1];
					dotTimeInfo.interval = Math.Max(XSingleton<XGlobalConfig>.singleton.BuffMinRegenerateInterval * 1000f, seqListRef[j, 2]);
					dotTimeInfo.tickCount = 0;
					dotTimeInfo.totalCount = (int)(this._buff.BuffInfo.BuffDuration * 1000f / seqListRef[j, 2]);
					dotTimeInfo.timeleft = dotTimeInfo.interval;
					bool flag6 = xentity != null && sequenceList == null;
					if (flag6)
					{
						bool flag7 = seqListRef2[j, 0] != 0;
						if (flag7)
						{
							dotTimeInfo.attrValue = this._GetCasterAttr(xentity, seqListRef2[j, 0], seqListRef2[j, 1]);
						}
					}
					this.ConvertSpecialBuff(dotTimeInfo);
					this._Dots.Add(dotTimeInfo);
					this._NextTime = Math.Min(dotTimeInfo.timeleft, this._NextTime);
				}
				bool flag8 = sequenceList2 != null;
				if (flag8)
				{
					CommonObjectPool<SequenceList<int>>.Release(sequenceList2);
				}
				bool flag9 = sequenceList != null;
				if (flag9)
				{
					CommonObjectPool<SequenceList<float>>.Release(sequenceList);
				}
				this._TimeToken = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(this._NextTime * 0.001f, this._onTimeCb, null);
			}
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			bool isDummy = entity.IsDummy;
			if (!isDummy)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._TimeToken);
				bool flag = entity.IsDead || entity.Deprecated;
				if (!flag)
				{
					bool flag2 = !IsReplaced;
					if (flag2)
					{
						float time = Time.time;
						for (int i = 0; i < this._Dots.Count; i++)
						{
							DotTimeInfo dotTimeInfo = this._Dots[i];
							int num = Mathf.Min((int)((time - this._StartTime) * 1000f / dotTimeInfo.interval), dotTimeInfo.totalCount);
							for (int j = dotTimeInfo.tickCount; j < num; j++)
							{
								bool flag3 = dotTimeInfo.attrID == XAttributeDefine.XAttr_CurrentHP_Basic && dotTimeInfo.attrValue < 0.0;
								if (flag3)
								{
									XCombat.ProjectExternalDamage(-dotTimeInfo.attrValue, this._buff.CasterID, this._component.Entity, !this._buff.BuffInfo.DontShowText, 0);
								}
								else
								{
									XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
									@event.AttrKey = dotTimeInfo.attrID;
									@event.DeltaValue = dotTimeInfo.attrValue;
									@event.CasterID = this._buff.CasterID;
									@event.bShowHUD = !this._buff.BuffInfo.DontShowText;
									@event.Firer = this._component.Entity;
									XSingleton<XEventMgr>.singleton.FireEvent(@event);
								}
							}
						}
					}
				}
			}
		}

		public void OnTimer(object o, float delay)
		{
			float num = float.MaxValue;
			for (int i = 0; i < this._Dots.Count; i++)
			{
				DotTimeInfo dotTimeInfo = this._Dots[i];
				dotTimeInfo.timeleft -= this._NextTime + delay * 1000f;
				while (dotTimeInfo.tickCount <= dotTimeInfo.totalCount && dotTimeInfo.timeleft <= 0f)
				{
					dotTimeInfo.tickCount++;
					dotTimeInfo.timeleft += dotTimeInfo.interval;
					bool flag = dotTimeInfo.attrID == XAttributeDefine.XAttr_CurrentHP_Basic && dotTimeInfo.attrValue < 0.0;
					if (flag)
					{
						XCombat.ProjectExternalDamage(-dotTimeInfo.attrValue, this._buff.CasterID, this._component.Entity, !this._buff.BuffInfo.DontShowText, 0);
					}
					else
					{
						XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
						@event.AttrKey = dotTimeInfo.attrID;
						@event.DeltaValue = dotTimeInfo.attrValue;
						@event.CasterID = this._buff.CasterID;
						@event.bShowHUD = !this._buff.BuffInfo.DontShowText;
						@event.Firer = this._component.Entity;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
				}
				bool flag2 = dotTimeInfo.timeleft > 0f;
				if (flag2)
				{
					num = Math.Min(num, dotTimeInfo.timeleft);
				}
			}
			bool flag3 = base.bValid && num != float.MaxValue && num > 0f;
			if (flag3)
			{
				this._NextTime = num;
				this._TimeToken = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(this._NextTime * 0.001f, this._onTimeCb, o);
			}
		}

		private XBuff _buff = null;

		private XBuffComponent _component = null;

		private uint _TimeToken = 0U;

		private List<DotTimeInfo> _Dots = null;

		private float _StartTime;

		private float _NextTime;

		private XTimerMgr.AccurateElapsedEventHandler _onTimeCb = null;
	}
}
