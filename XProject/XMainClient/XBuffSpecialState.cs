using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DB6 RID: 3510
	internal class XBuffSpecialState : BuffEffect
	{
		// Token: 0x0600BE38 RID: 48696 RVA: 0x0027A1B0 File Offset: 0x002783B0
		static XBuffSpecialState()
		{
			XBuffSpecialState._buffHandler[XBuffType.XBuffType_Bati] = new XBuffSpecialState.SpecialBuffHandler(XBuffSpecialState.OnBati);
			XBuffSpecialState._buffHandler[XBuffType.XBuffType_Immortal] = new XBuffSpecialState.SpecialBuffHandler(XBuffSpecialState.OnImmortal);
			XBuffSpecialState._buffHandler[XBuffType.XBuffType_CantDie] = new XBuffSpecialState.SpecialBuffHandler(XBuffSpecialState.OnCantDie);
			XBuffSpecialState._buffHandler[XBuffType.XBuffType_Shield] = new XBuffSpecialState.SpecialBuffHandler(XBuffSpecialState.OnShield);
			XBuffSpecialState._buffHandler[XBuffType.XBuffType_Trapped] = new XBuffSpecialState.SpecialBuffHandler(XBuffSpecialState.OnTrapped);
		}

		// Token: 0x0600BE39 RID: 48697 RVA: 0x0027A250 File Offset: 0x00278450
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.BuffState == null || rowData.BuffState.Length == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < rowData.BuffState.Length; i++)
				{
					buff.AddEffect(new XBuffSpecialState(buff, (XBuffType)rowData.BuffState[i]));
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600BE3A RID: 48698 RVA: 0x0027A2AC File Offset: 0x002784AC
		public XBuffSpecialState(XBuff buff, XBuffType state)
		{
			this._buffType = state;
			this._buff = buff;
		}

		// Token: 0x17003354 RID: 13140
		// (get) Token: 0x0600BE3B RID: 48699 RVA: 0x0027A2D4 File Offset: 0x002784D4
		public override XBuffEffectPrioriy Priority
		{
			get
			{
				switch (this._buffType)
				{
				case XBuffType.XBuffType_Immortal:
					return XBuffEffectPrioriy.BEP_SpecialState_Immortal;
				case XBuffType.XBuffType_CantDie:
					return XBuffEffectPrioriy.BEP_SpecialState_CantDie;
				case XBuffType.XBuffType_Shield:
					return XBuffEffectPrioriy.BEP_SpecialState_Shield;
				case XBuffType.XBuffType_Trapped:
					return XBuffEffectPrioriy.BEP_SpecialState_Trapped;
				}
				return XBuffEffectPrioriy.BEP_START;
			}
		}

		// Token: 0x0600BE3C RID: 48700 RVA: 0x0027A320 File Offset: 0x00278520
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			bool isDummy = entity.IsDummy;
			if (!isDummy)
			{
				XBuffType buffType = this._buffType;
				if (buffType != XBuffType.XBuffType_Transform && buffType != XBuffType.XBuffType_Scale)
				{
					entity.Buffs.IncBuffState(this._buffType, this._buff.BuffInfo.StateParam);
				}
				else
				{
					entity.Buffs.IncBuffState(this._buffType, this._buff.ID);
				}
				XBuffType buffType2 = this._buffType;
				if (buffType2 != XBuffType.XBuffType_Freeze)
				{
					switch (buffType2)
					{
					case XBuffType.XBuffType_Trapped:
						XBuffSpecialState.TryToggleTrapUI(entity, this._buff.UIBuff, true);
						break;
					case XBuffType.XBuffType_Silencing:
					case XBuffType.XBuffType_Puzzled:
						break;
					case XBuffType.XBuffType_Transform:
					{
						bool flag = XBuffSpecialState.TryTransform(entity, this._buff.ID, this._buff.BuffInfo.StateParam, true) == XBuffSpecialState.SpecialStateResult.SSR_Success;
						if (flag)
						{
							entity.Buffs.MakeSingleEffect(this._buff);
						}
						break;
					}
					case XBuffType.XBuffType_Stealth:
						XBuffSpecialState.TryStealth(entity, this._buff.UIBuff, true);
						break;
					default:
						if (buffType2 == XBuffType.XBuffType_Scale)
						{
							bool flag2 = XBuffSpecialState.TryScale(entity, this._buff.UIBuff, true) == XBuffSpecialState.SpecialStateResult.SSR_Success;
							if (flag2)
							{
								entity.Buffs.MakeSingleEffect(this._buff);
							}
						}
						break;
					}
				}
				else
				{
					XHitData xhitData = new XHitData();
					xhitData.State = XBeHitState.Hit_Freezed;
					xhitData.FreezeDuration = this._buff.Duration;
					xhitData.FreezePresent = false;
					XFreezeEventArgs @event = XEventPool<XFreezeEventArgs>.GetEvent();
					@event.HitData = xhitData;
					@event.Dir = entity.EngineObject.Forward;
					@event.Firer = entity;
					this._token = XSingleton<XCommon>.singleton.UniqueToken;
					@event.Token = this._token;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
		}

		// Token: 0x0600BE3D RID: 48701 RVA: 0x0027A4EC File Offset: 0x002786EC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			bool isDummy = entity.IsDummy;
			if (!isDummy)
			{
				XBuffType buffType = this._buffType;
				if (buffType <= XBuffType.XBuffType_Freeze)
				{
					if (buffType != XBuffType.XBuffType_Immortal)
					{
						if (buffType == XBuffType.XBuffType_Freeze)
						{
							bool flag = !IsReplaced;
							if (flag)
							{
								XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(this._buff.CasterID);
								bool flag2 = entity2 != null && !entity2.Deprecated;
								if (flag2)
								{
									XSecurityBuffInfo xsecurityBuffInfo = XSecurityBuffInfo.TryGetStatistics(entity2);
									bool flag3 = xsecurityBuffInfo != null;
									if (flag3)
									{
										xsecurityBuffInfo.OnFreeze(this._buff);
									}
								}
								bool flag4 = entity.Machine.ActionToken == this._token;
								if (flag4)
								{
									entity.Machine.ForceToDefaultState(false);
								}
							}
						}
					}
					else
					{
						bool flag5 = !IsReplaced;
						if (flag5)
						{
							XSecurityBuffInfo xsecurityBuffInfo2 = XSecurityBuffInfo.TryGetStatistics(entity);
							bool flag6 = xsecurityBuffInfo2 != null;
							if (flag6)
							{
								xsecurityBuffInfo2.OnImmortal(this._buff);
							}
						}
					}
				}
				else
				{
					switch (buffType)
					{
					case XBuffType.XBuffType_Trapped:
					{
						bool flag7 = !IsReplaced;
						if (flag7)
						{
							XBuffSpecialState.TryToggleTrapUI(entity, this._buff.UIBuff, false);
						}
						break;
					}
					case XBuffType.XBuffType_Silencing:
					case XBuffType.XBuffType_Puzzled:
						break;
					case XBuffType.XBuffType_Transform:
					{
						bool flag8 = !IsReplaced;
						if (flag8)
						{
							bool flag9 = this._buff.BuffInfo.StateParam > 0 || !entity.IsDead;
							if (flag9)
							{
								XBuffSpecialState.TryTransform(entity, this._buff.ID, this._buff.BuffInfo.StateParam, false);
							}
						}
						break;
					}
					case XBuffType.XBuffType_Stealth:
						XBuffSpecialState.TryStealth(entity, this._buff.UIBuff, false);
						break;
					default:
						if (buffType == XBuffType.XBuffType_Scale)
						{
							bool flag10 = !IsReplaced;
							if (flag10)
							{
								XBuffSpecialState.TryScale(entity, this._buff.UIBuff, false);
							}
						}
						break;
					}
				}
				bool flag11 = this._buffType == XBuffType.XBuffType_Transform;
				if (flag11)
				{
					entity.Buffs.DecBuffState(this._buffType, this._buff.ID);
				}
				else
				{
					entity.Buffs.DecBuffState(this._buffType, this._buff.BuffInfo.StateParam);
				}
			}
		}

		// Token: 0x0600BE3E RID: 48702 RVA: 0x0027A708 File Offset: 0x00278908
		public override void OnBattleEnd(XEntity entity)
		{
			base.OnBattleEnd(entity);
			bool isDummy = entity.IsDummy;
			if (!isDummy)
			{
				XBuffType buffType = this._buffType;
				if (buffType != XBuffType.XBuffType_Immortal)
				{
					if (buffType == XBuffType.XBuffType_Freeze)
					{
						XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(this._buff.CasterID);
						bool flag = entity2 != null && !entity2.Deprecated;
						if (flag)
						{
							XSecurityBuffInfo xsecurityBuffInfo = XSecurityBuffInfo.TryGetStatistics(entity2);
							bool flag2 = xsecurityBuffInfo != null;
							if (flag2)
							{
								xsecurityBuffInfo.OnFreeze(this._buff);
							}
						}
					}
				}
				else
				{
					XSecurityBuffInfo xsecurityBuffInfo2 = XSecurityBuffInfo.TryGetStatistics(entity);
					bool flag3 = xsecurityBuffInfo2 != null;
					if (flag3)
					{
						xsecurityBuffInfo2.OnImmortal(this._buff);
					}
				}
			}
		}

		// Token: 0x0600BE3F RID: 48703 RVA: 0x0027A7B8 File Offset: 0x002789B8
		public override void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = XBuffSpecialState._buffHandler.ContainsKey(this._buffType);
			if (flag)
			{
				XBuffSpecialState._buffHandler[this._buffType](this, rawInput, result);
			}
		}

		// Token: 0x0600BE40 RID: 48704 RVA: 0x0027A7F5 File Offset: 0x002789F5
		private static void OnBati(XBuffSpecialState buffEffect, HurtInfo rawInput, ProjectDamageResult result)
		{
			result.SetResult(ProjectResultType.PJRES_BATI);
		}

		// Token: 0x0600BE41 RID: 48705 RVA: 0x0027A800 File Offset: 0x00278A00
		private static void OnImmortal(XBuffSpecialState buffEffect, HurtInfo rawInput, ProjectDamageResult result)
		{
			result.SetResult(ProjectResultType.PJRES_IMMORTAL);
			result.Value = 0.0;
		}

		// Token: 0x0600BE42 RID: 48706 RVA: 0x0027A81B File Offset: 0x00278A1B
		private static void OnCantDie(XBuffSpecialState buffEffect, HurtInfo rawInput, ProjectDamageResult result)
		{
			result.Value = -XBuffSpecialState.GetCantDieDamage(-result.Value, rawInput.Target.Attributes);
		}

		// Token: 0x0600BE43 RID: 48707 RVA: 0x0027A840 File Offset: 0x00278A40
		private static void OnShield(XBuffSpecialState buffEffect, HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = result.Value > 0.0;
			if (flag)
			{
				double absorbDamage = -buffEffect._buff.ChangeBuffHP(-result.Value);
				result.AbsorbDamage = absorbDamage;
			}
		}

		// Token: 0x0600BE44 RID: 48708 RVA: 0x0027A884 File Offset: 0x00278A84
		private static void OnTrapped(XBuffSpecialState buffEffect, HurtInfo rawInput, ProjectDamageResult result)
		{
			bool flag = result.Value > 0.0;
			if (flag)
			{
				bool flag2 = rawInput.Caster != null && rawInput.Caster.Attributes != null;
				if (flag2)
				{
					bool flag3 = !XFightGroupDocument.IsOpponent(rawInput.Target.Attributes.FightGroup, rawInput.Caster.Attributes.FightGroup);
					if (flag3)
					{
						double num = -buffEffect._buff.ChangeBuffHP(-result.Value);
						result.Value = 0.0;
					}
				}
			}
		}

		// Token: 0x0600BE45 RID: 48709 RVA: 0x0027A91C File Offset: 0x00278B1C
		public static double GetCantDieDamage(double originalDeltaValue, XAttributes attributes)
		{
			double attr = attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
			bool flag = attr + originalDeltaValue <= 0.0;
			double result;
			if (flag)
			{
				result = Math.Min(-(attr - 1.0), 0.0);
			}
			else
			{
				result = originalDeltaValue;
			}
			return result;
		}

		// Token: 0x0600BE46 RID: 48710 RVA: 0x0027A96C File Offset: 0x00278B6C
		public static double GetActualChangeAttr(XAttributeDefine attr, double deltaValue, XEntity entity, bool bIgnoreImmortal = false, bool bForceCantDie = false)
		{
			bool flag = attr == XAttributeDefine.XAttr_CurrentHP_Basic && deltaValue < 0.0;
			double result;
			if (flag)
			{
				XAttributes attributes = entity.Attributes;
				bool flag2 = !bIgnoreImmortal && attributes.BuffState.IsBuffStateOn(XBuffType.XBuffType_Immortal);
				if (flag2)
				{
					result = 0.0;
				}
				else
				{
					bool flag3 = attributes.BuffState.IsBuffStateOn(XBuffType.XBuffType_CantDie) || bForceCantDie;
					if (flag3)
					{
						result = XBuffSpecialState.GetCantDieDamage(deltaValue, attributes);
					}
					else
					{
						result = deltaValue;
					}
				}
			}
			else
			{
				result = deltaValue;
			}
			return result;
		}

		// Token: 0x0600BE47 RID: 48711 RVA: 0x0027A9E8 File Offset: 0x00278BE8
		public static XBuffSpecialState.SpecialStateResult TryTransform(XEntity entity, int buffID, int transformID, bool bTransform)
		{
			bool flag = entity == null || transformID == 0 || entity.Attributes == null;
			XBuffSpecialState.SpecialStateResult result;
			if (flag)
			{
				result = XBuffSpecialState.SpecialStateResult.SSR_Error;
			}
			else
			{
				bool flag2 = entity.Attributes.BuffState.GetStateParam(XBuffType.XBuffType_Transform) != buffID;
				if (flag2)
				{
					result = XBuffSpecialState.SpecialStateResult.SSR_NoEffect;
				}
				else
				{
					if (bTransform)
					{
						entity.OnTransform((uint)Math.Abs(transformID));
					}
					else
					{
						entity.OnTransform(0U);
					}
					bool flag3 = bTransform && entity.IsPlayer && XBuffComponent.TransformBuffsChangeOutlook.Contains(buffID);
					if (flag3)
					{
						XTransformDocument.TryReqLeftTime();
					}
					result = XBuffSpecialState.SpecialStateResult.SSR_Success;
				}
			}
			return result;
		}

		// Token: 0x0600BE48 RID: 48712 RVA: 0x0027AA78 File Offset: 0x00278C78
		public static XBuffSpecialState.SpecialStateResult TryScale(XEntity entity, UIBuffInfo buff, bool bScale)
		{
			bool flag = entity == null || buff == null || entity.Attributes == null;
			XBuffSpecialState.SpecialStateResult result;
			if (flag)
			{
				result = XBuffSpecialState.SpecialStateResult.SSR_Error;
			}
			else
			{
				bool flag2 = (long)entity.Attributes.BuffState.GetStateParam(XBuffType.XBuffType_Scale) != (long)((ulong)buff.buffID);
				if (flag2)
				{
					result = XBuffSpecialState.SpecialStateResult.SSR_NoEffect;
				}
				else
				{
					if (bScale)
					{
						entity.OnScale((uint)buff.buffInfo.StateParam);
					}
					else
					{
						entity.OnScale(0U);
					}
					bool flag3 = bScale && entity.IsPlayer && XBuffComponent.TransformBuffsChangeOutlook.Contains((int)buff.buffID);
					if (flag3)
					{
						XTransformDocument.TryReqLeftTime();
					}
					result = XBuffSpecialState.SpecialStateResult.SSR_Success;
				}
			}
			return result;
		}

		// Token: 0x0600BE49 RID: 48713 RVA: 0x0027AB1C File Offset: 0x00278D1C
		public static void TryToggleTrapUI(XEntity entity, UIBuffInfo buff, bool bOpen)
		{
			bool flag = entity == null || entity.Buffs == null || buff == null || buff.buffInfo == null;
			if (!flag)
			{
				bool flag2 = buff.buffInfo.BuffState != null && entity.Buffs.IsBuffStateOn(XBuffType.XBuffType_Trapped);
				if (flag2)
				{
					for (int i = 0; i < buff.buffInfo.BuffState.Length; i++)
					{
						bool flag3 = buff.buffInfo.BuffState[i] == 6;
						if (flag3)
						{
							bool flag4 = entity.BillBoard != null;
							if (flag4)
							{
								entity.BillBoard.SetFreezeBuffState(bOpen ? buff : null);
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600BE4A RID: 48714 RVA: 0x0027ABC8 File Offset: 0x00278DC8
		public static void TryStealth(XEntity entity, UIBuffInfo buff, bool bOpen)
		{
			bool flag = entity == null || entity.Buffs == null || buff == null || buff.buffInfo == null;
			if (!flag)
			{
				bool flag2 = buff.buffInfo.BuffState != null && entity.Buffs.GetBuffStateCounter(XBuffType.XBuffType_Stealth) == 1;
				if (flag2)
				{
					for (int i = 0; i < buff.buffInfo.BuffState.Length; i++)
					{
						bool flag3 = buff.buffInfo.BuffState[i] == 10;
						if (flag3)
						{
							bool flag4 = XSingleton<XEntityMgr>.singleton.IsAlly(entity);
							if (flag4)
							{
								entity.OnFade(!bOpen, 0.5f, true, BillBoardHideType.Stealth);
							}
							else
							{
								entity.OnFade(!bOpen, 0.5f, false, BillBoardHideType.Stealth);
								if (bOpen)
								{
									entity.Buffs.ClearBuffFx();
								}
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x04004DB6 RID: 19894
		private XBuffType _buffType = XBuffType.XBuffType_Max;

		// Token: 0x04004DB7 RID: 19895
		private XBuff _buff = null;

		// Token: 0x04004DB8 RID: 19896
		private long _token;

		// Token: 0x04004DB9 RID: 19897
		private static Dictionary<XBuffType, XBuffSpecialState.SpecialBuffHandler> _buffHandler = new Dictionary<XBuffType, XBuffSpecialState.SpecialBuffHandler>(default(XFastEnumIntEqualityComparer<XBuffType>));

		// Token: 0x020019BE RID: 6590
		// (Invoke) Token: 0x0601106F RID: 69743
		private delegate void SpecialBuffHandler(XBuffSpecialState buffEffect, HurtInfo rawInput, ProjectDamageResult result);

		// Token: 0x020019BF RID: 6591
		public enum SpecialStateResult
		{
			// Token: 0x04007FBB RID: 32699
			SSR_Success,
			// Token: 0x04007FBC RID: 32700
			SSR_Error,
			// Token: 0x04007FBD RID: 32701
			SSR_NoEffect
		}
	}
}
