using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffAuraCheck : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.AuraAddBuffID.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffAuraCheck(buff));
				result = true;
			}
			return result;
		}

		public XBuffAuraCheck(XBuff buff)
		{
			this._buff = buff;
			this._type = (XBuffAuraCheck.ShapeType)this._GetParam(0);
			this._startTime = this._GetParam(1);
			this._interval = Mathf.Max(XSingleton<XGlobalConfig>.singleton.BuffMinAuraInterval, this._GetParam(2));
			short[] effectGroup = buff.BuffInfo.EffectGroup;
			this._timeCb = new XTimerMgr.ElapsedEventHandler(this.OnTimer);
			bool flag = effectGroup != null;
			if (flag)
			{
				for (int i = 0; i < effectGroup.Length; i++)
				{
					bool flag2 = effectGroup[i] == -1;
					if (flag2)
					{
						this.m_effectexcept = true;
					}
					else
					{
						bool flag3 = effectGroup[i] == -2;
						if (flag3)
						{
							this.m_effectexcept = true;
							this.m_effectexceptself = true;
						}
						else
						{
							bool flag4 = this._EffectGroups == null;
							if (flag4)
							{
								this._EffectGroups = new HashSet<uint>();
							}
							this._EffectGroups.Add((uint)effectGroup[i]);
						}
					}
				}
			}
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
			XBuffAuraCheck.ShapeType type = this._type;
			if (type != XBuffAuraCheck.ShapeType.BACT_CIRCLE)
			{
				if (type == XBuffAuraCheck.ShapeType.BACT_RECTANGLE)
				{
					this._halfWidth = this._GetParam(3) / 2f;
					this._halfHeight = this._GetParam(4) / 2f;
					this._halfExclusiveWidth = this._GetParam(5) / 2f;
					this._halfExclusiveHeight = this._GetParam(6) / 2f;
				}
			}
			else
			{
				float num = this._GetParam(3);
				num += pEffectHelper.GetBuffAuraRadius();
				this._sqrRadius = num * num;
				float num2 = this._GetParam(4);
				this._sqrExclusiveRadius = num2 * num2;
			}
			bool flag = this._entity == null || this._entity.IsDummy;
			if (flag)
			{
				this._EffectGroups = null;
			}
			else
			{
				bool effectexcept = this.m_effectexcept;
				if (effectexcept)
				{
					bool effectexceptself = this.m_effectexceptself;
					if (effectexceptself)
					{
						bool flag2 = this._EffectGroups == null;
						if (flag2)
						{
							this._EffectGroups = new HashSet<uint>();
						}
						this._EffectGroups.Add(this._entity.Attributes.FightGroup);
					}
				}
				else
				{
					bool flag3 = this._EffectGroups == null;
					if (flag3)
					{
						this._EffectGroups = new HashSet<uint>();
					}
					bool flag4 = this._EffectGroups.Count == 0;
					if (flag4)
					{
						this._EffectGroups.Add(this._entity.Attributes.FightGroup);
					}
				}
			}
			bool flag5 = this._startTime <= 0f;
			if (flag5)
			{
				this._timeCb(null);
			}
			else
			{
				this._TimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._startTime, this._timeCb, null);
			}
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._TimeToken);
		}

		public void OnTimer(object o)
		{
			bool isDummy = this._entity.IsDummy;
			if (isDummy)
			{
				this._AddBuffs(this._entity);
			}
			else
			{
				List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
				Vector3 forward = this._entity.MoveObj.Forward;
				Vector3 vector = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward, 90f, true);
				Vector3 position = this._entity.MoveObj.Position;
				for (int i = 0; i < all.Count; i++)
				{
					XEntity xentity = all[i];
					bool flag = xentity.IsDead || xentity.Deprecated;
					if (!flag)
					{
						bool flag2 = xentity.Attributes == null || !this._CanAttack(xentity.Attributes.FightGroup);
						if (!flag2)
						{
							XBuffAuraCheck.ShapeType type = this._type;
							if (type != XBuffAuraCheck.ShapeType.BACT_CIRCLE)
							{
								if (type == XBuffAuraCheck.ShapeType.BACT_RECTANGLE)
								{
									Vector3 vector2 = xentity.MoveObj.Position - position;
									bool flag3 = this._halfWidth > 0f || this._halfExclusiveWidth > 0f;
									if (flag3)
									{
										float num = Math.Abs(Vector3.Dot(vector2, forward));
										bool flag4 = this._halfWidth > 0f && num > this._halfWidth;
										if (flag4)
										{
											goto IL_284;
										}
										bool flag5 = this._halfExclusiveWidth > 0f && num < this._halfExclusiveWidth;
										if (flag5)
										{
											goto IL_284;
										}
									}
									bool flag6 = this._halfHeight > 0f || this._halfExclusiveHeight > 0f;
									if (flag6)
									{
										float num2 = Math.Abs(Vector3.Dot(vector2, vector));
										bool flag7 = this._halfHeight > 0f && num2 > this._halfHeight;
										if (flag7)
										{
											goto IL_284;
										}
										bool flag8 = this._halfExclusiveHeight > 0f && num2 < this._halfExclusiveHeight;
										if (flag8)
										{
											goto IL_284;
										}
									}
								}
							}
							else
							{
								bool flag9 = this._sqrRadius > 0f || this._sqrExclusiveRadius > 0f;
								if (flag9)
								{
									float num3 = Vector3.SqrMagnitude(position - xentity.MoveObj.Position);
									bool flag10 = this._sqrRadius > 0f && num3 > this._sqrRadius;
									if (flag10)
									{
										goto IL_284;
									}
									bool flag11 = this._sqrExclusiveRadius > 0f && num3 < this._sqrExclusiveRadius;
									if (flag11)
									{
										goto IL_284;
									}
								}
							}
							this._AddBuffs(xentity);
						}
					}
					IL_284:;
				}
				bool bValid = base.bValid;
				if (bValid)
				{
					this._TimeToken = XSingleton<XTimerMgr>.singleton.SetTimer(this._interval, this._timeCb, o);
				}
			}
		}

		private void _AddBuffs(XEntity entity)
		{
			for (int i = 0; i < this._buff.BuffInfo.AuraAddBuffID.Count; i++)
			{
				XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
				@event.xBuffDesc.BuffID = this._buff.BuffInfo.AuraAddBuffID[i, 0];
				@event.xBuffDesc.BuffLevel = this._buff.BuffInfo.AuraAddBuffID[i, 1];
				@event.Firer = entity;
				@event.xBuffDesc.CasterID = this._buff.CasterID;
				@event.xBuffDesc.SkillID = this._buff.SkillID;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		private bool _CanAttack(uint fightGroup)
		{
			bool effectexcept = this.m_effectexcept;
			bool result;
			if (effectexcept)
			{
				result = (this._EffectGroups == null || !this._EffectGroups.Contains(fightGroup));
			}
			else
			{
				result = (this._EffectGroups != null && this._EffectGroups.Contains(fightGroup));
			}
			return result;
		}

		private float _GetParam(int index)
		{
			bool flag = this._buff.BuffInfo.AuraParams == null || this._buff.BuffInfo.AuraParams.Length <= index;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				result = this._buff.BuffInfo.AuraParams[index];
			}
			return result;
		}

		private XBuff _buff = null;

		private XEntity _entity = null;

		private XBuffAuraCheck.ShapeType _type = XBuffAuraCheck.ShapeType.BACT_CIRCLE;

		private bool m_effectexcept = false;

		private bool m_effectexceptself = false;

		private float _sqrRadius = 0f;

		private float _sqrExclusiveRadius = 0f;

		private float _halfWidth = 0f;

		private float _halfHeight = 0f;

		private float _halfExclusiveWidth = 0f;

		private float _halfExclusiveHeight = 0f;

		private float _startTime = 0f;

		private float _interval = 0f;

		private uint _TimeToken = 0U;

		private HashSet<uint> _EffectGroups = null;

		private XTimerMgr.ElapsedEventHandler _timeCb = null;

		private enum ShapeType
		{

			BACT_CIRCLE,

			BACT_RECTANGLE
		}
	}
}
