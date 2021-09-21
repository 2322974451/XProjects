using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC9 RID: 4041
	internal sealed class XDeathComponent : XActionStateComponent<XRealDeadEventArgs>
	{
		// Token: 0x170036BA RID: 14010
		// (get) Token: 0x0600D214 RID: 53780 RVA: 0x0030F72C File Offset: 0x0030D92C
		public override uint ID
		{
			get
			{
				return XDeathComponent.uuID;
			}
		}

		// Token: 0x170036BB RID: 14011
		// (get) Token: 0x0600D215 RID: 53781 RVA: 0x0030F744 File Offset: 0x0030D944
		// (set) Token: 0x0600D216 RID: 53782 RVA: 0x0030F75C File Offset: 0x0030D95C
		public float ClipLen
		{
			get
			{
				return this._clip_len;
			}
			set
			{
				this._clip_len = value;
			}
		}

		// Token: 0x170036BC RID: 14012
		// (get) Token: 0x0600D217 RID: 53783 RVA: 0x0030F768 File Offset: 0x0030D968
		public IXCurve CurveH
		{
			get
			{
				return this._curve_h;
			}
		}

		// Token: 0x170036BD RID: 14013
		// (get) Token: 0x0600D218 RID: 53784 RVA: 0x0030F780 File Offset: 0x0030D980
		public IXCurve CurveV
		{
			get
			{
				return this._curve_v;
			}
		}

		// Token: 0x170036BE RID: 14014
		// (get) Token: 0x0600D219 RID: 53785 RVA: 0x0030F798 File Offset: 0x0030D998
		public float LandTime
		{
			get
			{
				return this._land_time;
			}
		}

		// Token: 0x170036BF RID: 14015
		// (get) Token: 0x0600D21A RID: 53786 RVA: 0x0030F7B0 File Offset: 0x0030D9B0
		public float LandMax
		{
			get
			{
				return this._land_max;
			}
		}

		// Token: 0x0600D21B RID: 53787 RVA: 0x0030F7C8 File Offset: 0x0030D9C8
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._selfState = XStateDefine.XState_Death;
			bool isNotEmptyObject = this._entity.EngineObject.IsNotEmptyObject;
			if (isNotEmptyObject)
			{
				bool flag = string.IsNullOrEmpty(this._entity.Present.PresentLib.Death);
				if (flag)
				{
					this._clip_len = 0f;
				}
				else
				{
					this._clip_len = 1f;
					bool flag2 = this._entity.Present.PresentLib.DeathCurve != null && this._entity.Present.PresentLib.DeathCurve.Length != 0;
					if (flag2)
					{
						IXCurve curve = XSingleton<XResourceLoaderMgr>.singleton.GetCurve(this._entity.Present.CurvePrefix + this._entity.Present.PresentLib.DeathCurve[0]);
						IXCurve curve2 = XSingleton<XResourceLoaderMgr>.singleton.GetCurve(this._entity.Present.CurvePrefix + this._entity.Present.PresentLib.DeathCurve[1]);
						this._curve_h = curve;
						this._curve_v = curve2;
						this._land_time = curve.GetLandValue();
						this._land_max = curve.GetMaxValue();
					}
				}
			}
		}

		// Token: 0x0600D21C RID: 53788 RVA: 0x0030F910 File Offset: 0x0030DB10
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this._clip_len = 0f;
			this._curve_h = null;
			this._curve_v = null;
			this._land_time = 0f;
			this._land_max = 0f;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fade_out_token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._destory_token);
		}

		// Token: 0x0600D21D RID: 53789 RVA: 0x0030F976 File Offset: 0x0030DB76
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(base.OnActionEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnRevived, new XComponent.XEventHandler(this.OnRevive));
		}

		// Token: 0x0600D21E RID: 53790 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRejected(XStateDefine current)
		{
		}

		// Token: 0x170036C0 RID: 14016
		// (get) Token: 0x0600D21F RID: 53791 RVA: 0x0030F9A4 File Offset: 0x0030DBA4
		public override bool IsUsingCurve
		{
			get
			{
				return !base.IsFinished;
			}
		}

		// Token: 0x0600D220 RID: 53792 RVA: 0x0030F9C0 File Offset: 0x0030DBC0
		protected override void Cancel(XStateDefine next)
		{
			bool flag = this._death_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._death_fx, true);
			}
			this._death_fx = null;
			this._killer = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._fade_out_token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._destory_token);
		}

		// Token: 0x0600D221 RID: 53793 RVA: 0x0030FA20 File Offset: 0x0030DC20
		private bool OnRevive(XEventArgs e)
		{
			bool flag = this._entity.Machine.Current == XStateDefine.XState_Death;
			if (flag)
			{
				this._entity.Machine.ForceToDefaultState(true);
			}
			this._presented = false;
			return true;
		}

		// Token: 0x0600D222 RID: 53794 RVA: 0x0030FA68 File Offset: 0x0030DC68
		protected override void ActionUpdate(float deltaTime)
		{
			bool presented = this._presented;
			if (presented)
			{
				XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
				this._elapsed += deltaTime;
				bool flag = xentity.Death.CurveV == null || xentity.Death.CurveH == null;
				if (!flag)
				{
					float num = xentity.Death.CurveV.Evaluate(this._elapsed) * xentity.Scale;
					float num2 = xentity.Death.CurveH.Evaluate(this._elapsed) * xentity.Scale;
					Vector3 vector = this._step_dir * (num - this._last_offset);
					float x = vector.x;
					float num3 = num2 - this._last_height;
					float z = vector.z;
					this._last_height = num2;
					this._last_offset = num;
					float num4 = XSingleton<XCommon>.singleton.IsLess(this._elapsed, xentity.Death.LandTime) ? (-(this._deltaH / xentity.Death.LandTime) * deltaTime) : (-Mathf.Sqrt(x * x + z * z));
					bool flag2 = this._elapsed < xentity.Death.LandTime;
					if (flag2)
					{
						this._entity.DisableGravity();
					}
					this._entity.ApplyMove(x, num3 + num4, z);
				}
			}
		}

		// Token: 0x0600D223 RID: 53795 RVA: 0x0030FBEC File Offset: 0x0030DDEC
		public override string TriggerAnim(string pre)
		{
			this._presented = true;
			this._entity.Ator.CrossFade(this.PresentName, 0f, 0, 0f);
			return this.PresentName;
		}

		// Token: 0x170036C1 RID: 14017
		// (get) Token: 0x0600D224 RID: 53796 RVA: 0x0030FC30 File Offset: 0x0030DE30
		public override string PresentCommand
		{
			get
			{
				return "ToDeath";
			}
		}

		// Token: 0x170036C2 RID: 14018
		// (get) Token: 0x0600D225 RID: 53797 RVA: 0x0030FC48 File Offset: 0x0030DE48
		public override string PresentName
		{
			get
			{
				return "Death";
			}
		}

		// Token: 0x170036C3 RID: 14019
		// (get) Token: 0x0600D226 RID: 53798 RVA: 0x0030FC60 File Offset: 0x0030DE60
		public override bool ShouldBePresent
		{
			get
			{
				return !this._presented;
			}
		}

		// Token: 0x170036C4 RID: 14020
		// (get) Token: 0x0600D227 RID: 53799 RVA: 0x0030FC7C File Offset: 0x0030DE7C
		public override int CollisionLayer
		{
			get
			{
				return LayerMask.NameToLayer("NoneEntity");
			}
		}

		// Token: 0x0600D228 RID: 53800 RVA: 0x0030FC98 File Offset: 0x0030DE98
		protected override bool OnGetEvent(XRealDeadEventArgs e, XStateDefine last)
		{
			this._killer = e.Killer;
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			bool flag = xentity.Death.ClipLen > 0f;
			if (flag)
			{
				xentity.Death.ClipLen = xentity.OverrideAnimClipGetLength("Death", xentity.Present.ActionPrefix + xentity.Present.PresentLib.Death, false);
			}
			return true;
		}

		// Token: 0x0600D229 RID: 53801 RVA: 0x0030FD28 File Offset: 0x0030DF28
		protected override void Begin()
		{
			XEntity xentity = this._entity.IsTransform ? this._entity.Transformer : this._entity;
			this._entity.Net.KillIdle();
			bool flag = !this._entity.IsRole && xentity.Death.ClipLen > 0f;
			if (flag)
			{
				this._fade_out_token = XSingleton<XTimerMgr>.singleton.SetTimer(xentity.Death.ClipLen, new XTimerMgr.ElapsedEventHandler(this.OnFadeOut), null);
			}
			bool flag2 = !this._entity.IsPuppet && !XQualitySetting.GetQuality(EFun.ELowEffect);
			if (flag2)
			{
				bool flag3 = !XEntity.FilterFx(this._entity, XFxMgr.FilterFxDis0);
				if (flag3)
				{
					this._death_fx = XSingleton<XFxMgr>.singleton.CreateFx(string.IsNullOrEmpty(xentity.Present.PresentLib.DeathFx) ? "Effects/FX_Particle/NPC/xiaobing_die" : xentity.Present.PresentLib.DeathFx, null, true);
					this._death_fx.Play(this._entity.EngineObject, Vector3.zero, Vector3.one, 1f, true, false, "", 0f);
				}
			}
			XSingleton<XAudioMgr>.singleton.PlaySound(xentity, AudioChannel.Motion, XAudioStateDefine.XState_Audio_Death);
			bool flag4 = xentity.Death.CurveV != null;
			if (flag4)
			{
				this._step_dir = (XEntity.ValideEntity(this._killer) ? ((xentity.Death.LandMax > 0f) ? XSingleton<XCommon>.singleton.Horizontal(this._entity.EngineObject.Position - this._killer.EngineObject.Position) : (-this._entity.EngineObject.Forward)) : ((xentity.Death.LandMax > 0f) ? XSingleton<XCommon>.singleton.Horizontal(this._entity.EngineObject.Position - XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position) : (-this._entity.EngineObject.Forward)));
				Vector3 pos = this._entity.EngineObject.Position + xentity.Death.CurveV.Evaluate(xentity.Death.LandTime) * this._entity.Scale * this._step_dir;
				float num = 0f;
				bool flag5 = XSingleton<XScene>.singleton.TryGetTerrainY(pos, out num);
				if (flag5)
				{
					this._deltaH = this._entity.EngineObject.Position.y - num;
				}
				else
				{
					this._deltaH = 0f;
				}
				bool flag6 = this._deltaH < 0f;
				if (flag6)
				{
					this._deltaH = 0f;
				}
			}
			this._last_offset = 0f;
			this._last_height = 0f;
			this._elapsed = 0f;
			this._entity.Dying();
			bool flag7 = !this._entity.IsRole;
			if (flag7)
			{
				bool flag8 = xentity.Death.ClipLen > 0f;
				if (flag8)
				{
					this._destory_token = XSingleton<XTimerMgr>.singleton.SetTimer(xentity.Death.ClipLen + 1f, new XTimerMgr.ElapsedEventHandler(this.OnDestroy), null);
				}
				else
				{
					this.OnDestroy(null);
				}
			}
		}

		// Token: 0x0600D22A RID: 53802 RVA: 0x003100A0 File Offset: 0x0030E2A0
		private void OnFadeOut(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = 1f;
			@event.Firer = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600D22B RID: 53803 RVA: 0x003100D8 File Offset: 0x0030E2D8
		private void OnDestroy(object o)
		{
			bool flag = this._death_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._death_fx, true);
			}
			this._death_fx = null;
			this._entity.Died();
		}

		// Token: 0x04005F4D RID: 24397
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Death");

		// Token: 0x04005F4E RID: 24398
		private bool _presented = false;

		// Token: 0x04005F4F RID: 24399
		private float _elapsed = 0f;

		// Token: 0x04005F50 RID: 24400
		private float _clip_len = 0f;

		// Token: 0x04005F51 RID: 24401
		private float _last_offset = 0f;

		// Token: 0x04005F52 RID: 24402
		private float _last_height = 0f;

		// Token: 0x04005F53 RID: 24403
		private float _deltaH = 0f;

		// Token: 0x04005F54 RID: 24404
		private float _land_time = 0f;

		// Token: 0x04005F55 RID: 24405
		private float _land_max = 0f;

		// Token: 0x04005F56 RID: 24406
		private Vector3 _step_dir = Vector3.forward;

		// Token: 0x04005F57 RID: 24407
		private IXCurve _curve_h = null;

		// Token: 0x04005F58 RID: 24408
		private IXCurve _curve_v = null;

		// Token: 0x04005F59 RID: 24409
		private XEntity _killer = null;

		// Token: 0x04005F5A RID: 24410
		private XFx _death_fx = null;

		// Token: 0x04005F5B RID: 24411
		private uint _fade_out_token = 0U;

		// Token: 0x04005F5C RID: 24412
		private uint _destory_token = 0U;
	}
}
