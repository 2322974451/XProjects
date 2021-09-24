using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XBeHitComponent : XActionStateComponent<XBeHitEventArgs>
	{

		public override uint ID
		{
			get
			{
				return XBeHitComponent.uuID;
			}
		}

		public override string TriggerAnim(string pre)
		{
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			bool flag = this._hit_data != null && !string.IsNullOrEmpty(this._hit_data.Fx);
			if (flag)
			{
				this.PlayHitFx(this._hit_data.Fx, this._hit_data.Fx_Follow, this._hit_data.Fx_StickToGround, ref this._hit_fx);
			}
			bool flag2 = !string.IsNullOrEmpty(xentity.Present.PresentLib.HitFx);
			if (flag2)
			{
				this.PlayHitFx(xentity.Present.PresentLib.HitFx, true, false, ref this._hit_hit_fx);
			}
			bool flag3 = xentity.Ator != null;
			if (flag3)
			{
				xentity.Ator.Play("Present", 0);
			}
			return "ToBeHit";
		}

		public override bool IsUsingCurve
		{
			get
			{
				return !base.IsFinished && this._hit_data.CurveUsing;
			}
		}

		public float TimeSpan
		{
			get
			{
				return this._total_time;
			}
		}

		public XBeHitState CurrentStateinLogical
		{
			get
			{
				return this._current_default_state;
			}
		}

		public bool HasFlyPresent
		{
			get
			{
				return this._bHasFlyPresent;
			}
		}

		public bool HasRollPresent
		{
			get
			{
				return this._bHasRollPresent;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_BeHit;
			this._clips = new string[16];
			this._landing_overrided = false;
		}

		public override void OnDetachFromHost()
		{
			this.DestroyFx(ref this._hit_fx);
			this.DestroyFx(ref this._hit_hit_fx);
			this.DestroyFx(ref this._hit_land_fx);
			bool flag = this._clips != null;
			if (flag)
			{
				this._clips = null;
			}
			base.OnDetachFromHost();
		}

		public override void Attached()
		{
			this._bHasFlyPresent = (this._entity.Present.PresentLib.HitFly != null && this._entity.Present.PresentLib.HitFly.Length != 0);
			this._bHasRollPresent = (this._entity.Present.PresentLib.Hit_Roll != null && this._entity.Present.PresentLib.Hit_Roll.Length != 0);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_BeHit, new XComponent.XEventHandler(base.OnActionEvent));
		}

		protected override void ActionUpdate(float deltaTime)
		{
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			bool flag = base.IsFinished || xentity.Ator == null;
			if (!flag)
			{
				float elapsed = this._elapsed;
				this._elapsed += deltaTime;
				switch (this._phase)
				{
				case XBeHitPhase.Hit_Present:
				{
					bool flag2 = (this._bChange_to_fly || this._current_default_state == XBeHitState.Hit_Fly) && xentity.BeHit.HasFlyPresent;
					bool flag3 = flag2 && !this._landing_overrided;
					if (flag3)
					{
						xentity.OverrideAnimClip("HitLanding", xentity.BeHit.SaveGetClip(12), false, false);
						this._landing_overrided = true;
					}
					bool flag4 = this._elapsed > this._present_straight;
					if (flag4)
					{
						this._elapsed = this._present_straight;
						bool flag5 = flag2;
						if (flag5)
						{
							xentity.Ator.SetTrigger("ToBeHit_Landing");
							this._phase = XBeHitPhase.Hit_Landing;
							this._bHit_Down = true;
							this._bHit_Bounce = false;
							bool flag6 = xentity.EngineObject.Position.y < XSingleton<XScene>.singleton.TerrainY(xentity.EngineObject.Position) + 0.25f;
							if (flag6)
							{
								this.PlayHitFx("Effects/FX_Particle/Roles/Lzg_Ty/Ty_dd", true, true, ref this._hit_land_fx);
							}
							xentity.Ator.speed = 1f;
						}
						else
						{
							xentity.Ator.SetTrigger("ToBeHit_Hard");
							this._phase = XBeHitPhase.Hit_Hard;
							xentity.Ator.speed = (this._bLoop_Hard ? 1f : (this._hart_time / this._hard_straight));
						}
						this.TrytoTirggerQTE(false);
					}
					this.CalcDeltaPos(Time.deltaTime, elapsed);
					float num = -(this._deltaH / this._present_straight) * Time.deltaTime;
					bool flag7 = this._offset < 0f && XEntity.ValideEntity(this._hit_from);
					if (flag7)
					{
						float num2 = Mathf.Sqrt(this._delta_x * this._delta_x + this._delta_z * this._delta_z);
						float magnitude = (this._hit_from.EngineObject.Position - xentity.EngineObject.Position).magnitude;
						bool flag8 = (double)num2 > (double)magnitude - 0.5;
						if (flag8)
						{
							this._delta_x = 0f;
							this._delta_z = 0f;
						}
					}
					this._entity.ApplyMove(this._delta_x, this._delta_y + num, this._delta_z);
					bool flag9 = flag2;
					if (flag9)
					{
						this._entity.DisableGravity();
					}
					break;
				}
				case XBeHitPhase.Hit_Landing:
				{
					bool flag10 = !this._bHit_Bounce;
					if (flag10)
					{
						bool flag11 = this._elapsed > this._present_straight + this._land_time;
						if (flag11)
						{
							this._bHit_Bounce = true;
							bool flag12 = this._elapsed <= this._present_straight + this._land_time + this._bounce_time;
							if (flag12)
							{
								this.TrytoTirggerQTE(false);
							}
						}
					}
					bool bHit_Bounce = this._bHit_Bounce;
					if (bHit_Bounce)
					{
						bool flag13 = this._elapsed > this._present_straight + this._land_time + this._bounce_time;
						if (flag13)
						{
							xentity.Ator.SetTrigger("ToBeHit_Hard");
							this._phase = XBeHitPhase.Hit_Hard;
							xentity.Ator.speed = (this._bLoop_Hard ? 1f : (this._hart_time / this._hard_straight));
							this._bHit_Bounce = false;
							this.TrytoTirggerQTE(false);
						}
					}
					break;
				}
				case XBeHitPhase.Hit_Hard:
				{
					bool flag14 = this._elapsed > this._present_straight + this._land_time + this._bounce_time + this._hard_straight;
					if (flag14)
					{
						xentity.Ator.SetTrigger("ToBeHit_GetUp");
						this._phase = XBeHitPhase.Hit_GetUp;
						xentity.Ator.speed = 1f;
						this.TrytoTirggerQTE(false);
					}
					break;
				}
				case XBeHitPhase.Hit_GetUp:
				{
					bool flag15 = this._elapsed > this._total_time - this._getup_time * 0.7f;
					if (flag15)
					{
						this._bHit_Down = false;
					}
					bool flag16 = this._elapsed > this._total_time;
					if (flag16)
					{
						xentity.Ator.speed = 1f;
						base.Finish();
					}
					break;
				}
				}
			}
		}

		public override int CollisionLayer
		{
			get
			{
				XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
				return (xentity.IsPlayer || xentity.IsBoss) ? xentity.DefaultLayer : 14;
			}
		}

		public override bool ShouldBePresent
		{
			get
			{
				return false;
			}
		}

		public bool LaidOnGround()
		{
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			return xentity.Machine.Current == this._selfState && this._bHit_Down;
		}

		protected override void Cancel(XStateDefine next)
		{
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			this._elapsed = 0f;
			this._rticalV = 0f;
			this._gravity = 0f;
			this._deltaH = 0f;
			bool flag = xentity.Ator != null;
			if (flag)
			{
				xentity.Ator.speed = 1f;
			}
			this._curve_h = null;
			this._curve_v = null;
			this._hit_data = null;
			this._hit_from = null;
			this.DestroyFx(ref this._hit_fx);
			this.DestroyFx(ref this._hit_hit_fx);
			this.DestroyFx(ref this._hit_land_fx);
			this.TrytoTirggerQTE(true);
		}

		protected override bool OnGetEvent(XBeHitEventArgs e, XStateDefine last)
		{
			this._bHit_Down = false;
			this._bHit_Bounce = false;
			this._hit_data = e.HitData;
			this._hit_from = e.HitFrom;
			this._hit_direction = XSingleton<XCommon>.singleton.Horizontal(e.HitDirection);
			this._bChange_to_fly = e.ForceToFlyHit;
			this._hard_time_factor = ((e.Paralyze > 0f) ? e.Paralyze : 1f);
			return true;
		}

		public string SaveGetClip(int idx)
		{
			bool flag = this._clips[idx] == null;
			if (flag)
			{
				switch (idx)
				{
				case 0:
				case 1:
				case 2:
					this._clips[idx] = this._entity.Present.ActionPrefix + this._entity.Present.PresentLib.Hit_f[idx];
					break;
				case 3:
				case 4:
				case 5:
					this._clips[idx] = this._entity.Present.ActionPrefix + this._entity.Present.PresentLib.Hit_l[idx % 3];
					break;
				case 6:
				case 7:
				case 8:
					this._clips[idx] = this._entity.Present.ActionPrefix + this._entity.Present.PresentLib.Hit_r[idx % 3];
					break;
				case 9:
				case 10:
				case 11:
					this._clips[idx] = this._entity.Present.ActionPrefix + this._entity.Present.PresentLib.Hit_Roll[idx % 3];
					break;
				case 12:
					this._clips[idx] = this._entity.Present.ActionPrefix + this._entity.Present.PresentLib.HitFly[XFastEnumIntEqualityComparer<XBeHitPhase>.ToInt(XBeHitPhase.Hit_Landing)];
					break;
				case 13:
					this._clips[idx] = this._entity.Present.ActionPrefix + this._entity.Present.PresentLib.HitFly[XFastEnumIntEqualityComparer<XBeHitPhase>.ToInt(XBeHitPhase.Hit_Present)];
					break;
				case 14:
					this._clips[idx] = this._entity.Present.ActionPrefix + this._entity.Present.PresentLib.HitFly[XFastEnumIntEqualityComparer<XBeHitPhase>.ToInt(XBeHitPhase.Hit_Hard)];
					break;
				case 15:
					this._clips[idx] = this._entity.Present.ActionPrefix + this._entity.Present.PresentLib.HitFly[XFastEnumIntEqualityComparer<XBeHitPhase>.ToInt(XBeHitPhase.Hit_GetUp)];
					break;
				}
			}
			return this._clips[idx];
		}

		private void Prepare()
		{
			this._start_idx = 0;
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			switch (this._current_default_state)
			{
			case XBeHitState.Hit_Back:
			{
				bool bChange_to_fly = this._bChange_to_fly;
				if (bChange_to_fly)
				{
					bool flag = !xentity.BeHit.HasFlyPresent;
					if (flag)
					{
						this._start_idx = 3;
					}
					else
					{
						this._start_idx = 13;
					}
				}
				else
				{
					switch (this._hit_data.State_Animation)
					{
					case XBeHitState_Animation.Hit_Back_Front:
						this._start_idx = 0;
						break;
					case XBeHitState_Animation.Hit_Back_Left:
						this._start_idx = 3;
						break;
					case XBeHitState_Animation.Hit_Back_Right:
						this._start_idx = 6;
						break;
					}
				}
				break;
			}
			case XBeHitState.Hit_Fly:
			{
				bool flag2 = !xentity.BeHit.HasFlyPresent;
				if (flag2)
				{
					this._start_idx = 3;
				}
				else
				{
					this._start_idx = 13;
				}
				break;
			}
			case XBeHitState.Hit_Roll:
			{
				bool bChange_to_fly2 = this._bChange_to_fly;
				if (bChange_to_fly2)
				{
					bool flag3 = !xentity.BeHit.HasFlyPresent;
					if (flag3)
					{
						this._start_idx = 3;
					}
					else
					{
						this._start_idx = 13;
					}
				}
				else
				{
					bool flag4 = !xentity.BeHit.HasRollPresent;
					if (flag4)
					{
						this._start_idx = 3;
					}
					else
					{
						this._start_idx = 9;
					}
				}
				break;
			}
			}
			XAnimationClip xanimationClip;
			xentity.OverrideAnimClipGetClip("PresentStraight", xentity.BeHit.SaveGetClip(this._start_idx), false, true, out xanimationClip);
			XAnimationClip xanimationClip2;
			xentity.OverrideAnimClipGetClip("HardStraight", xentity.BeHit.SaveGetClip(this._start_idx + 1), false, false, out xanimationClip2);
			xentity.OverrideAnimClip("GetUp", xentity.BeHit.SaveGetClip(this._start_idx + 2), false, false);
			this._land_time = (((this._bChange_to_fly || this._current_default_state == XBeHitState.Hit_Fly) && xentity.BeHit.HasFlyPresent) ? xentity.Present.PresentLib.HitFly_Bounce_GetUp[0] : 0f);
			this._bounce_time = (((this._bChange_to_fly || this._current_default_state == XBeHitState.Hit_Fly) && xentity.BeHit.HasFlyPresent) ? xentity.Present.PresentLib.HitFly_Bounce_GetUp[1] : 0f);
			this._getup_time = (((this._bChange_to_fly || this._current_default_state == XBeHitState.Hit_Fly) && xentity.BeHit.HasFlyPresent) ? xentity.Present.PresentLib.HitFly_Bounce_GetUp[2] : ((this._current_default_state == XBeHitState.Hit_Roll && xentity.BeHit.HasRollPresent) ? xentity.Present.PresentLib.HitRoll_Recover : xentity.Present.PresentLib.HitBack_Recover[0]));
			bool flag5 = xanimationClip2 != null;
			if (flag5)
			{
				this._hart_time = xanimationClip2.length;
				this._bLoop_Hard = (xanimationClip2.clip.wrapMode == (WrapMode)2);
			}
			bool flag6 = xanimationClip != null;
			if (flag6)
			{
				this._clip0Length = xanimationClip.length;
			}
			bool flag7 = this._hit_data.CurveUsing && xentity.Present.PresentLib.HitCurves != null;
			if (flag7)
			{
				IXCurve ixcurve = ((this._bChange_to_fly || this._current_default_state == XBeHitState.Hit_Fly) && xentity.BeHit.HasFlyPresent) ? XSingleton<XResourceLoaderMgr>.singleton.GetCurve(xentity.Present.CurvePrefix + xentity.Present.PresentLib.HitCurves[4]) : null;
				IXCurve ixcurve2 = ((this._bChange_to_fly || this._current_default_state == XBeHitState.Hit_Fly) && xentity.BeHit.HasFlyPresent) ? XSingleton<XResourceLoaderMgr>.singleton.GetCurve(xentity.Present.CurvePrefix + xentity.Present.PresentLib.HitCurves[3]) : ((this._current_default_state == XBeHitState.Hit_Roll && xentity.BeHit.HasRollPresent) ? XSingleton<XResourceLoaderMgr>.singleton.GetCurve(xentity.Present.CurvePrefix + xentity.Present.PresentLib.HitCurves[5]) : ((this._current_default_state == XBeHitState.Hit_Back) ? XSingleton<XResourceLoaderMgr>.singleton.GetCurve(xentity.Present.CurvePrefix + xentity.Present.PresentLib.HitCurves[XFastEnumIntEqualityComparer<XBeHitState_Animation>.ToInt(this._hit_data.State_Animation)]) : XSingleton<XResourceLoaderMgr>.singleton.GetCurve(xentity.Present.CurvePrefix + xentity.Present.PresentLib.HitCurves[0])));
				this._curve_h = ((ixcurve != null) ? ixcurve : null);
				this._curve_v = ixcurve2;
				this._curve_height_scale = ((ixcurve == null || ixcurve.GetMaxValue() == 0f) ? 1f : (this._height / ixcurve.GetMaxValue()));
				this._curve_offset_scale = ((ixcurve2.GetMaxValue() == 0f) ? 1f : (this._offset / ixcurve2.GetMaxValue()));
			}
		}

		protected override void Begin()
		{
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			this._current_default_state = this._hit_data.State;
			this._present_straight = (this._bChange_to_fly ? (this._hit_data.Additional_Using_Default ? XSingleton<XGlobalConfig>.singleton.Hit_PresentStraight : this._hit_data.Additional_Hit_Time_Present_Straight) : this._hit_data.Time_Present_Straight);
			this._hard_straight = (this._bChange_to_fly ? (this._hit_data.Additional_Using_Default ? XSingleton<XGlobalConfig>.singleton.Hit_HardStraight : this._hit_data.Additional_Hit_Time_Hard_Straight) : this._hit_data.Time_Hard_Straight);
			this._offset = (this._bChange_to_fly ? (this._hit_data.Additional_Using_Default ? XSingleton<XGlobalConfig>.singleton.Hit_Offset : this._hit_data.Additional_Hit_Offset) : this._hit_data.Offset);
			this._height = (this._bChange_to_fly ? (this._hit_data.Additional_Using_Default ? XSingleton<XGlobalConfig>.singleton.Hit_Height : this._hit_data.Additional_Hit_Height) : this._hit_data.Height);
			this._present_straight = (XSingleton<XGame>.singleton.SyncMode ? this._present_straight : XSingleton<XCommon>.singleton.GetFloatingValue(this._present_straight, this._hit_data.Random_Range));
			this._offset = (XSingleton<XGame>.singleton.SyncMode ? this._offset : XSingleton<XCommon>.singleton.GetFloatingValue(this._offset, this._hit_data.Random_Range));
			this._height = (XSingleton<XGame>.singleton.SyncMode ? this._height : XSingleton<XCommon>.singleton.GetFloatingValue(this._height, this._hit_data.Random_Range));
			float num = 1f;
			float num2 = 1f;
			float num3 = 1f;
			float num4 = 1f;
			switch (this._current_default_state)
			{
			case XBeHitState.Hit_Back:
			{
				bool bChange_to_fly = this._bChange_to_fly;
				if (bChange_to_fly)
				{
					bool flag = xentity.Present.PresentLib.HitFlyOffsetTimeScale != null;
					if (flag)
					{
						num = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[0] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[0]);
						num2 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[1] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[1]);
						num3 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[2] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[2]);
						num4 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[3] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[3]);
					}
				}
				else
				{
					bool flag2 = xentity.Present.PresentLib.HitBackOffsetTimeScale != null;
					if (flag2)
					{
						num = ((xentity.Present.PresentLib.HitBackOffsetTimeScale[0] == 0f) ? 1f : xentity.Present.PresentLib.HitBackOffsetTimeScale[0]);
						num3 = ((xentity.Present.PresentLib.HitBackOffsetTimeScale[1] == 0f) ? 1f : xentity.Present.PresentLib.HitBackOffsetTimeScale[1]);
						num4 = ((xentity.Present.PresentLib.HitBackOffsetTimeScale[2] == 0f) ? 1f : xentity.Present.PresentLib.HitBackOffsetTimeScale[2]);
					}
				}
				break;
			}
			case XBeHitState.Hit_Fly:
			{
				bool flag3 = xentity.Present.PresentLib.HitFlyOffsetTimeScale != null;
				if (flag3)
				{
					num = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[0] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[0]);
					num2 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[1] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[1]);
					num3 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[2] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[2]);
					num4 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[3] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[3]);
				}
				break;
			}
			case XBeHitState.Hit_Roll:
			{
				bool bChange_to_fly2 = this._bChange_to_fly;
				if (bChange_to_fly2)
				{
					bool flag4 = xentity.Present.PresentLib.HitFlyOffsetTimeScale != null;
					if (flag4)
					{
						num = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[0] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[0]);
						num2 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[1] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[1]);
						num3 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[2] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[2]);
						num4 = ((xentity.Present.PresentLib.HitFlyOffsetTimeScale[3] == 0f) ? 1f : xentity.Present.PresentLib.HitFlyOffsetTimeScale[3]);
					}
				}
				else
				{
					bool flag5 = xentity.Present.PresentLib.HitRollOffsetTimeScale != null;
					if (flag5)
					{
						num = ((xentity.Present.PresentLib.HitRollOffsetTimeScale[0] == 0f) ? 1f : xentity.Present.PresentLib.HitRollOffsetTimeScale[0]);
						num3 = ((xentity.Present.PresentLib.HitRollOffsetTimeScale[1] == 0f) ? 1f : xentity.Present.PresentLib.HitRollOffsetTimeScale[1]);
						num4 = ((xentity.Present.PresentLib.HitRollOffsetTimeScale[2] == 0f) ? 1f : xentity.Present.PresentLib.HitRollOffsetTimeScale[2]);
					}
				}
				break;
			}
			}
			this._present_straight *= num3;
			this._hard_straight = this._hard_straight * num4 * this._hard_time_factor;
			bool flag6 = this._bChange_to_fly || this._current_default_state == XBeHitState.Hit_Fly;
			if (flag6)
			{
				this._height *= num2;
			}
			this._offset *= num;
			this.Prepare();
			this._total_time = this._present_straight + this._land_time + this._bounce_time + this._hard_straight + this._getup_time;
			this._pos.x = xentity.EngineObject.Position.x;
			this._pos.y = xentity.EngineObject.Position.z;
			Vector3 vector = xentity.EngineObject.Position + this._hit_direction * this._offset;
			float num5 = 0f;
			bool flag7 = XSingleton<XScene>.singleton.TryGetTerrainY(vector, out num5);
			if (flag7)
			{
				this._deltaH = xentity.EngineObject.Position.y - ((xentity.Fly != null) ? (num5 + xentity.Fly.CurrentHeight) : num5);
			}
			else
			{
				this._deltaH = 0f;
			}
			bool flag8 = this._deltaH < 0f;
			if (flag8)
			{
				this._deltaH = 0f;
			}
			this._des.x = vector.x;
			this._des.y = vector.z;
			bool curveUsing = this._hit_data.CurveUsing;
			if (curveUsing)
			{
				this._curve_height_time_scale = ((this._curve_h == null) ? 1f : (this._present_straight / this._curve_h.GetTime(this._curve_h.length - 1)));
				this._curve_offset_time_scale = this._present_straight / this._curve_v.GetTime(this._curve_v.length - 1);
				this._last_offset = 0f;
				this._last_height = 0f;
			}
			else
			{
				this._factor = XSingleton<XCommon>.singleton.GetSmoothFactor((this._pos - this._des).magnitude, this._present_straight, 0.01f);
				this._rticalV = ((this._bChange_to_fly || this._current_default_state == XBeHitState.Hit_Fly) ? (this._height * 4f / this._present_straight) : 0f);
				this._gravity = this._rticalV / this._present_straight * 2f;
			}
			XSingleton<XAudioMgr>.singleton.PlaySound(xentity, AudioChannel.Behit, XAudioStateDefine.XState_Audio_BeHit, false, (this._hit_from == null) ? null : new XAudioExParam(this._hit_from));
			this._elapsed = 0f;
			this._phase = XBeHitPhase.Hit_Present;
			this.TrytoTirggerQTE(false);
			bool flag9 = xentity.Ator != null;
			if (flag9)
			{
				xentity.Ator.speed = this._clip0Length / this._present_straight;
			}
			this._entity.Machine.TriggerPresent();
		}

		private void PlayHitFx(string fx, bool follow, bool sticky, ref XFx xfx)
		{
			bool mobShield = this._entity.MobShield;
			if (!mobShield)
			{
				XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
				bool flag = !xentity.IsRole && XQualitySetting.GetQuality(EFun.ELowEffect);
				if (!flag)
				{
					bool flag2 = xfx != null && xfx.FxName != fx;
					if (flag2)
					{
						this.DestroyFx(ref xfx);
					}
					bool flag3 = XEntity.FilterFx(this._entity, XFxMgr.FilterFxDis0);
					if (!flag3)
					{
						bool flag4 = Time.realtimeSinceStartup - XFxMgr.lastBehitFxTime < XFxMgr.minBehitFxTime || XFxMgr.currentBeHitFx >= XFxMgr.maxBehitFx;
						if (!flag4)
						{
							bool flag5 = xfx == null;
							if (flag5)
							{
								xfx = XSingleton<XFxMgr>.singleton.CreateFx(fx, null, true);
							}
							XFxMgr.lastBehitFxTime = Time.realtimeSinceStartup;
							XFxMgr.currentBeHitFx++;
							Vector3 offset = sticky ? Vector3.zero : (Vector3.up * (xentity.Height * 0.5f));
							xfx.Play(xentity.EngineObject, offset, Vector3.one, 1f, follow, sticky, "", 0f);
						}
					}
				}
			}
		}

		private void DestroyFx(ref XFx xfx)
		{
			bool flag = xfx != null;
			if (flag)
			{
				XFxMgr.currentBeHitFx--;
				bool flag2 = XFxMgr.currentBeHitFx < 0;
				if (flag2)
				{
					XFxMgr.currentBeHitFx = 0;
				}
				XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
				xfx = null;
			}
		}

		private void CalcDeltaPos(float deltaTime, float last_elapsed)
		{
			Vector2 vector = Vector2.zero;
			bool curveUsing = this._hit_data.CurveUsing;
			float delta_y;
			if (curveUsing)
			{
				float time = this._elapsed / this._curve_offset_time_scale;
				float time2 = this._elapsed / this._curve_height_time_scale;
				float num = this._curve_v.Evaluate(time) * this._curve_offset_scale;
				float num2 = (this._curve_h == null) ? 0f : (this._curve_h.Evaluate(time2) * this._curve_height_scale);
				Vector3 vector2 = this._hit_direction * (num - this._last_offset);
				vector.x = vector2.x;
				vector.y = vector2.z;
				delta_y = num2 - this._last_height;
				this._last_height = num2;
				this._last_offset = num;
			}
			else
			{
				XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
				float num3 = this._rticalV - this._gravity * last_elapsed;
				float num4 = this._rticalV - this._gravity * this._elapsed;
				delta_y = (num3 + num4) / 2f * deltaTime;
				this._pos.x = xentity.EngineObject.Position.x;
				this._pos.y = xentity.EngineObject.Position.z;
				vector = (this._des - this._pos) * Mathf.Min(1f, this._factor * deltaTime);
			}
			this._delta_x = vector.x;
			this._delta_y = delta_y;
			this._delta_z = vector.y;
		}

		public override string PresentCommand
		{
			get
			{
				return "ToBeHit";
			}
		}

		public override string PresentName
		{
			get
			{
				string result;
				switch (this._phase)
				{
				case XBeHitPhase.Hit_Present:
					result = "Present";
					break;
				case XBeHitPhase.Hit_Landing:
					result = "HitLanding";
					break;
				case XBeHitPhase.Hit_Hard:
					result = "Hard";
					break;
				case XBeHitPhase.Hit_GetUp:
					result = "GetUp";
					break;
				default:
					result = "BeHit";
					break;
				}
				return result;
			}
		}

		public XQTEState GetQTESpecificPhase()
		{
			XQTEState result = XQTEState.QTE_None;
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			switch (this._phase)
			{
			case XBeHitPhase.Hit_Present:
				switch (this._current_default_state)
				{
				case XBeHitState.Hit_Back:
					result = ((this._bChange_to_fly && xentity.BeHit.HasFlyPresent) ? XQTEState.QTE_HitFlyPresent : XQTEState.QTE_HitBackPresent);
					break;
				case XBeHitState.Hit_Fly:
					result = (xentity.BeHit.HasFlyPresent ? XQTEState.QTE_HitFlyPresent : XQTEState.QTE_HitBackPresent);
					break;
				case XBeHitState.Hit_Roll:
					result = ((this._bChange_to_fly && xentity.BeHit.HasFlyPresent) ? XQTEState.QTE_HitFlyPresent : (xentity.BeHit.HasRollPresent ? XQTEState.QTE_HitRollPresent : XQTEState.QTE_HitBackPresent));
					break;
				}
				break;
			case XBeHitPhase.Hit_Landing:
				result = (this._bHit_Bounce ? XQTEState.QTE_HitFlyBounce : XQTEState.QTE_HitFlyLand);
				break;
			case XBeHitPhase.Hit_Hard:
				switch (this._current_default_state)
				{
				case XBeHitState.Hit_Back:
					result = ((this._bChange_to_fly && xentity.BeHit.HasFlyPresent) ? XQTEState.QTE_HitFlyStraight : XQTEState.QTE_HitBackStraight);
					break;
				case XBeHitState.Hit_Fly:
					result = (xentity.BeHit.HasFlyPresent ? XQTEState.QTE_HitFlyStraight : XQTEState.QTE_HitBackStraight);
					break;
				case XBeHitState.Hit_Roll:
					result = ((this._bChange_to_fly && xentity.BeHit.HasFlyPresent) ? XQTEState.QTE_HitFlyStraight : (xentity.BeHit.HasRollPresent ? XQTEState.QTE_HitRollStraight : XQTEState.QTE_HitBackStraight));
					break;
				}
				break;
			case XBeHitPhase.Hit_GetUp:
				switch (this._current_default_state)
				{
				case XBeHitState.Hit_Back:
					result = ((this._bChange_to_fly && xentity.BeHit.HasFlyPresent) ? XQTEState.QTE_HitFlyGetUp : XQTEState.QTE_HitBackGetUp);
					break;
				case XBeHitState.Hit_Fly:
					result = (xentity.BeHit.HasFlyPresent ? XQTEState.QTE_HitFlyGetUp : XQTEState.QTE_HitBackGetUp);
					break;
				case XBeHitState.Hit_Roll:
					result = ((this._bChange_to_fly && xentity.BeHit.HasFlyPresent) ? XQTEState.QTE_HitFlyGetUp : (xentity.BeHit.HasRollPresent ? XQTEState.QTE_HitRollGetUp : XQTEState.QTE_HitBackGetUp));
					break;
				}
				break;
			}
			return result;
		}

		private void TrytoTirggerQTE(bool bEnd = false)
		{
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			bool flag = !xentity.Destroying && xentity.QTE != null;
			if (flag)
			{
				XQTEState xqtestate = XQTEState.QTE_None;
				bool flag2 = !bEnd;
				if (flag2)
				{
					xqtestate = this.GetQTESpecificPhase();
					bool flag3 = this._last_set_qte > XQTEState.QTE_None;
					if (flag3)
					{
						XSkillQTEEventArgs @event = XEventPool<XSkillQTEEventArgs>.GetEvent();
						@event.Firer = xentity;
						@event.On = false;
						@event.State = (uint)XFastEnumIntEqualityComparer<XQTEState>.ToInt(this._last_set_qte);
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
					this._last_set_qte = xqtestate;
				}
				else
				{
					this._last_set_qte = XQTEState.QTE_None;
				}
				XSkillQTEEventArgs event2 = XEventPool<XSkillQTEEventArgs>.GetEvent();
				event2.Firer = xentity;
				event2.On = !bEnd;
				event2.State = (uint)XFastEnumIntEqualityComparer<XQTEState>.ToInt(xqtestate);
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BeHit_Presentation");

		private int _start_idx = 0;

		private Vector2 _pos = Vector2.zero;

		private Vector2 _des = Vector2.zero;

		private XBeHitState _current_default_state = XBeHitState.Hit_Back;

		private XBeHitPhase _phase = XBeHitPhase.Hit_Present;

		private XQTEState _last_set_qte = XQTEState.QTE_None;

		private float _last_offset = 0f;

		private float _last_height = 0f;

		private float _delta_x = 0f;

		private float _delta_y = 0f;

		private float _delta_z = 0f;

		private float _deltaH = 0f;

		private float _land_time = 0f;

		private float _bounce_time = 0f;

		private float _getup_time = 0f;

		private float _hart_time = 0f;

		private float _gravity = 0f;

		private float _rticalV = 0f;

		private float _factor = 0f;

		private float _elapsed = 0f;

		private bool _bChange_to_fly = false;

		private bool _bHit_Down = false;

		private bool _bHit_Bounce = false;

		private bool _bLoop_Hard = false;

		private bool _bHasFlyPresent = false;

		private bool _bHasRollPresent = false;

		private bool _landing_overrided = false;

		private float _total_time = 0f;

		private float _present_straight = 1f;

		private float _hard_straight = 1f;

		private float _height = 0f;

		private float _offset = 0f;

		private string[] _clips = null;

		private float _clip0Length = 0f;

		private XFx _hit_fx = null;

		private XFx _hit_hit_fx = null;

		private XFx _hit_land_fx = null;

		private IXCurve _curve_h = null;

		private IXCurve _curve_v = null;

		private float _curve_height_scale = 1f;

		private float _curve_offset_scale = 1f;

		private float _curve_height_time_scale = 1f;

		private float _curve_offset_time_scale = 1f;

		private float _hard_time_factor = 1f;

		private XHitData _hit_data = null;

		private Vector3 _hit_direction = Vector3.forward;

		private XEntity _hit_from = null;
	}
}
