using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XDeathComponent : XActionStateComponent<XRealDeadEventArgs>
	{

		public override uint ID
		{
			get
			{
				return XDeathComponent.uuID;
			}
		}

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

		public IXCurve CurveH
		{
			get
			{
				return this._curve_h;
			}
		}

		public IXCurve CurveV
		{
			get
			{
				return this._curve_v;
			}
		}

		public float LandTime
		{
			get
			{
				return this._land_time;
			}
		}

		public float LandMax
		{
			get
			{
				return this._land_max;
			}
		}

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

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(base.OnActionEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnRevived, new XComponent.XEventHandler(this.OnRevive));
		}

		public override void OnRejected(XStateDefine current)
		{
		}

		public override bool IsUsingCurve
		{
			get
			{
				return !base.IsFinished;
			}
		}

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

		public override string TriggerAnim(string pre)
		{
			this._presented = true;
			this._entity.Ator.CrossFade(this.PresentName, 0f, 0, 0f);
			return this.PresentName;
		}

		public override string PresentCommand
		{
			get
			{
				return "ToDeath";
			}
		}

		public override string PresentName
		{
			get
			{
				return "Death";
			}
		}

		public override bool ShouldBePresent
		{
			get
			{
				return !this._presented;
			}
		}

		public override int CollisionLayer
		{
			get
			{
				return LayerMask.NameToLayer("NoneEntity");
			}
		}

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

		private void OnFadeOut(object o)
		{
			XFadeOutEventArgs @event = XEventPool<XFadeOutEventArgs>.GetEvent();
			@event.Out = 1f;
			@event.Firer = this._entity;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Death");

		private bool _presented = false;

		private float _elapsed = 0f;

		private float _clip_len = 0f;

		private float _last_offset = 0f;

		private float _last_height = 0f;

		private float _deltaH = 0f;

		private float _land_time = 0f;

		private float _land_max = 0f;

		private Vector3 _step_dir = Vector3.forward;

		private IXCurve _curve_h = null;

		private IXCurve _curve_v = null;

		private XEntity _killer = null;

		private XFx _death_fx = null;

		private uint _fade_out_token = 0U;

		private uint _destory_token = 0U;
	}
}
