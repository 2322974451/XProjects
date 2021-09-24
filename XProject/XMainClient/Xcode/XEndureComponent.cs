using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XEndureComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XEndureComponent.uuID;
			}
		}

		static XEndureComponent()
		{
			IXCurve curve = XSingleton<XResourceLoaderMgr>.singleton.GetCurve(XEndureComponent._endure_curve);
			XEndureComponent._curve_v = curve;
			XEndureComponent._total = XEndureComponent._curve_v.GetTime(XEndureComponent._curve_v.length - 1);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Endure, new XComponent.XEventHandler(this.OnEndure));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._bEndure = false;
			this._last_offset = 0f;
			this._delta_x = 0f;
			this._delta_z = 0f;
			this._delta_cumulation_x = 0f;
			this._delta_cumulation_z = 0f;
		}

		public override void OnDetachFromHost()
		{
			bool flag = this._fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
				this._fx = null;
			}
			bool flag2 = this._hit_fx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._hit_fx, true);
				this._hit_fx = null;
			}
			base.OnDetachFromHost();
		}

		public override void Attached()
		{
			base.Attached();
			this.woo = (this._entity.GetXComponent(XWoozyComponent.uuID) as XWoozyComponent);
		}

		private bool OnEndure(XEventArgs e)
		{
			XEndureEventArgs xendureEventArgs = e as XEndureEventArgs;
			this.PlayFx(xendureEventArgs.Fx, true, ref this._fx);
			bool flag = !string.IsNullOrEmpty(this._entity.Present.PresentLib.HitFx);
			if (flag)
			{
				this.PlayFx(this._entity.Present.PresentLib.HitFx, true, ref this._hit_fx);
			}
			XSingleton<XAudioMgr>.singleton.PlaySound(this._entity, AudioChannel.Behit, XAudioStateDefine.XState_Audio_Bati, false, (xendureEventArgs.HitFrom == null) ? null : new XAudioExParam(xendureEventArgs.HitFrom));
			bool bEndure = this._bEndure;
			bool result;
			if (bEndure)
			{
				result = true;
			}
			else
			{
				this._bEndure = true;
				this._elapsed = 0f;
				this._direction = xendureEventArgs.Dir;
				this._delta_cumulation_x = 0f;
				this._delta_cumulation_z = 0f;
				result = true;
			}
			return result;
		}

		public override void Update(float fDeltaT)
		{
			bool bEndure = this._bEndure;
			if (bEndure)
			{
				this._elapsed += fDeltaT;
				bool flag = this._elapsed > XEndureComponent._total;
				if (flag)
				{
					this._elapsed = XEndureComponent._total;
					bool flag2 = this._fx != null;
					if (flag2)
					{
						XSingleton<XFxMgr>.singleton.DestroyFx(this._fx, true);
						this._fx = null;
					}
					bool flag3 = this._hit_fx != null;
					if (flag3)
					{
						XSingleton<XFxMgr>.singleton.DestroyFx(this._hit_fx, true);
						this._hit_fx = null;
					}
					bool flag4 = !this._entity.IsRole;
					if (flag4)
					{
						this.MoveImpl(new Vector3(-this._delta_cumulation_x, 0f, -this._delta_cumulation_z));
					}
					this._delta_cumulation_x = 0f;
					this._delta_cumulation_z = 0f;
					this._bEndure = false;
				}
				else
				{
					bool flag5 = !this._entity.IsRole;
					if (flag5)
					{
						this.CalcDeltaPos();
						this.MoveImpl(new Vector3(this._delta_x, 0f, this._delta_z));
					}
				}
			}
		}

		private void MoveImpl(Vector3 delta)
		{
			bool flag = this.woo != null && this.woo.InTransfer;
			if (!flag)
			{
				float num = 0f;
				Vector3 vector = this._entity.MoveObj.Position + delta;
				bool flag2 = this._entity.Fly == null && XSingleton<XScene>.singleton.TryGetTerrainY(vector, out num) && num >= 0f;
				if (flag2)
				{
					bool flag3 = XSingleton<XScene>.singleton.CheckDynamicBlock(this._entity.MoveObj.Position, vector);
					if (flag3)
					{
						bool flag4 = !this._entity.GravityDisabled;
						if (flag4)
						{
							vector.y = num + ((this._entity.MoveObj != null && this._entity.MoveObj.EnableCC) ? 0.25f : 0.05f);
							this._entity.MoveObj.Position = vector;
							bool flag5 = this._entity.MoveObj != null;
							if (flag5)
							{
								this._entity.MoveObj.Move(Vector3.down);
							}
						}
						else
						{
							this._entity.MoveObj.Position = vector;
						}
						this._delta_cumulation_x += delta.x;
						this._delta_cumulation_z += delta.z;
					}
				}
			}
		}

		private void CalcDeltaPos()
		{
			float num = XEndureComponent._curve_v.Evaluate(this._elapsed);
			Vector3 vector = this._direction * (num - this._last_offset);
			this._delta_x = vector.x;
			this._delta_z = vector.z;
			this._last_offset = num;
		}

		private void PlayFx(string fx, bool follow, ref XFx xfx)
		{
			bool flag = fx == null || fx.Length == 0;
			if (!flag)
			{
				bool flag2 = xfx != null && xfx.FxName != fx;
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
					xfx = null;
				}
				bool flag3 = XEntity.FilterFx(this._entity, XFxMgr.FilterFxDis0);
				if (!flag3)
				{
					bool flag4 = xfx == null;
					if (flag4)
					{
						xfx = XSingleton<XFxMgr>.singleton.CreateFx(fx, null, true);
					}
					xfx.DelayDestroy = 0.5f;
					xfx.Play(this._entity.EngineObject, Vector3.zero, Vector3.one, 1f, follow, false, "", this._entity.Height * 0.5f);
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Endure");

		private static readonly string _endure_curve = "Curve/Endure_forward";

		private static IXCurve _curve_v = null;

		private static float _total = 0f;

		private float _last_offset = 0f;

		private float _delta_x = 0f;

		private float _delta_z = 0f;

		private float _delta_cumulation_x = 0f;

		private float _delta_cumulation_z = 0f;

		private float _elapsed = 0f;

		private bool _bEndure = false;

		private XFx _fx = null;

		private XFx _hit_fx = null;

		private Vector3 _direction = Vector3.zero;

		private XWoozyComponent woo = null;
	}
}
