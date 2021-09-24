using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XCombinedSkill : XArtsSkill
	{

		public override int SkillType
		{
			get
			{
				return 3;
			}
		}

		public override XSkillCore MainCore
		{
			get
			{
				return this._main_core;
			}
		}

		public override void Initialize(XEntity firer)
		{
			base.Initialize(firer);
			this._combined_token.debugName = "XCombinedSkill._combined_token";
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._combined_token, 16, 0);
		}

		public override void Uninitialize()
		{
			base.Uninitialize();
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._combined_token);
		}

		protected override bool InnerProcessTimer(object param, int id)
		{
			bool flag = !base.InnerProcessTimer(param, id);
			if (flag)
			{
				bool flag2 = id == 25;
				if (flag2)
				{
					this.Combined(param);
					return true;
				}
			}
			return false;
		}

		public override uint GetCombinedId()
		{
			return (uint)this._combined_id;
		}

		public override void TriggerAnim()
		{
			bool flag = this._firer.Ator != null;
			if (flag)
			{
				float normalizedTime = this.MainCore.Soul.Combined[this._combined_id].At / base.Core.Soul.Time;
				this._firer.Ator.Play(XSkillData.CombinedOverrideMap[this._combined_id], 1, normalizedTime);
			}
		}

		public void ShutDown()
		{
			this._shut_down = true;
		}

		protected override void FireEvents()
		{
			float at = this.MainCore.Soul.Combined[this._combined_id].At;
			bool flag = this._data.Result != null;
			if (flag)
			{
				for (int i = 0; i < this._data.Result.Count; i++)
				{
					bool flag2 = this._data.Result[i].LongAttackEffect || !XSingleton<XGame>.singleton.SyncMode || !this._demonstration;
					if (flag2)
					{
						XResultData xresultData = this._data.Result[i];
						int result_time = this._result_time;
						this._result_time = result_time + 1;
						xresultData.Token = result_time;
						bool flag3 = this._data.Result[i].At >= at;
						if (flag3)
						{
							float num = this._data.Result[i].At - at;
							base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(num * this._time_scale, this._TimerCallback, this._data.Result[i], XArtsSkill.EArtsSkillTimerCb.EOnResult), true);
						}
					}
				}
			}
			bool flag4 = this._data.Charge != null;
			if (flag4)
			{
				for (int j = 0; j < this._data.Charge.Count; j++)
				{
					float num2 = this._data.Charge[j].Using_Curve ? 0f : this._data.Charge[j].At;
					bool flag5 = num2 >= at;
					if (flag5)
					{
						base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((num2 - at) * this._time_scale, this._TimerCallback, this._data.Charge[j], XArtsSkill.EArtsSkillTimerCb.ECharge), true);
					}
					else
					{
						int o = (int)((at - num2) * 1000f) << 16 | j;
						base.ChargeTo(o);
					}
				}
			}
			bool flag6 = !XSingleton<XGame>.singleton.SyncMode || this._demonstration;
			if (flag6)
			{
				bool flag7 = !this._demonstration;
				if (flag7)
				{
					bool flag8 = this._data.Manipulation != null;
					if (flag8)
					{
						for (int k = 0; k < this._data.Manipulation.Count; k++)
						{
							bool flag9 = this._data.Manipulation[k].At >= at;
							if (flag9)
							{
								base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Manipulation[k].At * this._time_scale, this._TimerCallback, this._data.Manipulation[k], XArtsSkill.EArtsSkillTimerCb.EManipulate), true);
							}
						}
					}
				}
				bool flag10 = this._data.Mob != null;
				if (flag10)
				{
					for (int l = 0; l < this._data.Mob.Count; l++)
					{
						bool flag11 = this._data.Mob[l].TemplateID > 0 && this._data.Mob[l].At >= at;
						if (flag11)
						{
							base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this._data.Mob[l].At * this._time_scale, this._TimerCallback, this._data.Mob[l], XArtsSkill.EArtsSkillTimerCb.EMob), true);
						}
					}
				}
			}
			bool override_Presentation = this.MainCore.Soul.Combined[this._combined_id].Override_Presentation;
			if (override_Presentation)
			{
				bool flag12 = this._data.Fx != null && !this._firer.MobShield;
				if (flag12)
				{
					for (int m = 0; m < this._data.Fx.Count; m++)
					{
						bool flag13 = !this._data.Fx[m].Shield || !XSingleton<XInput>.singleton.FxShield(this._firer);
						if (flag13)
						{
							bool flag14 = this._data.Fx[m].At >= at;
							if (flag14)
							{
								base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((this._data.Fx[m].At - at) * this._time_scale, this._TimerCallback, this._data.Fx[m], XArtsSkill.EArtsSkillTimerCb.EFx), false);
							}
						}
					}
				}
				bool flag15 = this._data.Audio != null && this._firer.IsVisible && !this._firer.MobShield;
				if (flag15)
				{
					for (int n = 0; n < this._data.Audio.Count; n++)
					{
						bool flag16 = this._data.Audio[n].At >= at;
						if (flag16)
						{
							base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((this._data.Audio[n].At - at) * this._time_scale, this._TimerCallback, this._data.Audio[n], XArtsSkill.EArtsSkillTimerCb.EAudio), false);
						}
					}
				}
				bool flag17 = this._demonstration || this._firer.IsPlayer || this._firer.IsBoss;
				if (flag17)
				{
					bool flag18 = this._data.CameraEffect != null;
					if (flag18)
					{
						for (int num3 = 0; num3 < this._data.CameraEffect.Count; num3++)
						{
							bool flag19 = this._data.CameraEffect[num3].At >= at;
							if (flag19)
							{
								base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((this._data.CameraEffect[num3].At - at) * this._time_scale, this._TimerCallback, this._data.CameraEffect[num3], XArtsSkill.EArtsSkillTimerCb.EShake), false);
							}
						}
					}
					bool flag20 = this._demonstration || this._firer.IsPlayer;
					if (flag20)
					{
						bool flag21 = this._data.CameraMotion != null && !string.IsNullOrEmpty(this._data.CameraMotion.Motion3D);
						if (flag21)
						{
							bool flag22 = this._data.CameraMotion.At >= at;
							if (flag22)
							{
								base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((this._data.CameraMotion.At - at) * this._time_scale, this._TimerCallback, this._core, XArtsSkill.EArtsSkillTimerCb.ECameraMotion), false);
							}
						}
						bool flag23 = this._data.CameraPostEffect != null;
						if (flag23)
						{
							bool flag24 = !this._demonstration && !string.IsNullOrEmpty(this._data.CameraPostEffect.Effect);
							if (flag24)
							{
								bool flag25 = this._data.CameraPostEffect.At >= at;
								if (flag25)
								{
									base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((this._data.CameraPostEffect.At - at) * this._time_scale, this._TimerCallback, this._core, XArtsSkill.EArtsSkillTimerCb.ECameraPostEffect), false);
									base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((this._data.CameraPostEffect.End - at) * this._time_scale, this._TimerCallback, this._core, XArtsSkill.EArtsSkillTimerCb.EEndCameraPostEffect), false);
								}
							}
						}
					}
				}
			}
			bool flag26 = this._data.Warning != null;
			if (flag26)
			{
				for (int num4 = 0; num4 < this._data.Warning.Count; num4++)
				{
					bool flag27 = this._data.Warning[num4].At >= at;
					if (flag27)
					{
						base.AddedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>((this._data.Warning[num4].At - at) * this._time_scale, this._TimerCallback, this._data.Warning[num4], XArtsSkill.EArtsSkillTimerCb.EWarning), false);
					}
				}
			}
		}

		protected override bool Present()
		{
			bool shut_down = this._shut_down;
			bool result;
			if (shut_down)
			{
				result = !XSingleton<XCommon>.singleton.IsGreater(this._timeElapsed, this._shut_down_elapsed * this._time_scale);
			}
			else
			{
				result = base.Present();
			}
			return result;
		}

		public void CombinedStop(bool cleanUp)
		{
			bool combined_set_camera_effect = this._combined_set_camera_effect;
			if (combined_set_camera_effect)
			{
				XCameraMotionEndEventArgs @event = XEventPool<XCameraMotionEndEventArgs>.GetEvent();
				@event.Target = this._firer;
				@event.Firer = this._affect_camera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this._affect_camera.Ator.speed = 1f;
				bool flag = this._firer.IsPlayer && this._end_solo_effect;
				if (flag)
				{
					XSingleton<XScene>.singleton.GameCamera.TrySolo();
				}
			}
			this._end_solo_effect = false;
			this._combined_set_camera_effect = false;
			bool combined_set_camera_shake = this._combined_set_camera_shake;
			if (combined_set_camera_shake)
			{
				XCameraShakeEventArgs event2 = XEventPool<XCameraShakeEventArgs>.GetEvent();
				event2.Effect = null;
				event2.Firer = this._affect_camera;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
			this._combined_set_camera_shake = false;
			bool demonstration = this._demonstration;
			if (demonstration)
			{
				XAttackShowEndArgs event3 = XEventPool<XAttackShowEndArgs>.GetEvent();
				event3.ForceQuit = false;
				event3.Firer = this._firer;
				XSingleton<XEventMgr>.singleton.FireEvent(event3);
			}
			for (int i = 0; i < this._combined_fx.Count; i++)
			{
				XFx fx = this._combined_fx[i] as XFx;
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, cleanUp);
			}
			XSingleton<XAudioMgr>.singleton.StopSound(this._firer, AudioChannel.SkillCombine);
			bool flag2 = this.MainCore.Soul.Logical != null;
			if (flag2)
			{
				bool flag3 = this.MainCore.PreservedStrength > 0;
				if (flag3)
				{
					base.PreservedSEnd(null);
				}
				bool flag4 = this.MainCore.Soul.Logical.QTEData != null && this.MainCore.Soul.Logical.QTEData.Count != 0;
				if (flag4)
				{
					base.QTEOff(null);
				}
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this._combine_token);
			this._combined_fx.Clear();
			bool flag5 = this.MainCore.Soul.CameraPostEffect != null;
			if (flag5)
			{
				bool flag6 = !this._demonstration && !string.IsNullOrEmpty(this.MainCore.Soul.CameraPostEffect.Effect);
				if (flag6)
				{
					this.MainCore.EndCameraPostEffect();
				}
				bool flag7 = !this._demonstration && this.MainCore.Soul.CameraPostEffect.SolidBlack;
				if (flag7)
				{
					this._affect_camera.SolidCancel();
				}
			}
			bool combined_set_not_selected = this._combined_set_not_selected;
			if (combined_set_not_selected)
			{
				this._firer.CanSelected = true;
			}
			this._combined_set_not_selected = false;
		}

		private void MainCoreStart()
		{
			this._result_time = 0;
			this._shut_down = false;
			this._combined_set_camera_effect = false;
			this._combined_set_camera_shake = false;
			this._combined_set_not_selected = false;
			bool flag = this.MainCore.Soul.Logical != null && this.MainCore.Soul.Logical.QTEData != null;
			if (flag)
			{
				for (int i = 0; i < this.MainCore.Soul.Logical.QTEData.Count; i++)
				{
					bool flag2 = this._firer.QTE != null && this.MainCore.Soul.Logical.QTEData[i].QTE != 0;
					if (flag2)
					{
						this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Logical.QTEData[i].At * this._time_scale, this._TimerCallback, this.MainCore.Soul.Logical.QTEData[i].QTE, XArtsSkill.EArtsSkillTimerCb.EQTEOn));
						this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Logical.QTEData[i].End * this._time_scale, this._TimerCallback, this.MainCore.Soul.Logical.QTEData[i].QTE, XArtsSkill.EArtsSkillTimerCb.EQTEOff));
					}
				}
			}
			bool flag3 = this.MainCore.Soul.Logical != null;
			if (flag3)
			{
				bool flag4 = this.MainCore.Soul.Logical != null && this.MainCore.Soul.Logical.Not_Selected_End > 0f;
				if (flag4)
				{
					this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Logical.Not_Selected_At * this._time_scale, this._TimerCallback, this.MainCore, XArtsSkill.EArtsSkillTimerCb.ENotSelected));
					this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Logical.Not_Selected_End * this._time_scale, this._TimerCallback, null, XArtsSkill.EArtsSkillTimerCb.ENotSelected));
				}
				bool flag5 = this.MainCore.PreservedStrength > 0;
				if (flag5)
				{
					this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Logical.PreservedAt * this._time_scale, this._TimerCallback, this.MainCore.PreservedStrength, XArtsSkill.EArtsSkillTimerCb.EPreservedSAt));
					this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Logical.PreservedEndAt * this._time_scale, this._TimerCallback, null, XArtsSkill.EArtsSkillTimerCb.EPreservedSEnd));
				}
				bool flag6 = !XSingleton<XGame>.singleton.SyncMode && !string.IsNullOrEmpty(this.MainCore.Soul.Logical.Exstring);
				if (flag6)
				{
					this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Logical.Exstring_At * this._time_scale, this._TimerCallback, this.MainCore.Soul.Logical.Exstring, XArtsSkill.EArtsSkillTimerCb.EExString));
				}
			}
			bool flag7 = this.MainCore.Soul.Fx != null && this._firer.IsVisible && !this._firer.MobShield;
			if (flag7)
			{
				for (int j = 0; j < this.MainCore.Soul.Fx.Count; j++)
				{
					bool flag8 = !this.MainCore.Soul.Fx[j].Shield || !XSingleton<XInput>.singleton.FxShield(this._firer);
					if (flag8)
					{
						this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Fx[j].At * this._time_scale, this._TimerCallback, this.MainCore.Soul.Fx[j], XArtsSkill.EArtsSkillTimerCb.EFx));
					}
				}
			}
			bool flag9 = this.MainCore.Soul.Audio != null && !this._firer.MobShield;
			if (flag9)
			{
				for (int k = 0; k < this.MainCore.Soul.Audio.Count; k++)
				{
					this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.Audio[k].At * this._time_scale, this._TimerCallback, this.MainCore.Soul.Audio[k], XArtsSkill.EArtsSkillTimerCb.EAudio));
				}
			}
			bool flag10 = this._firer.IsPlayer || this._firer.IsBoss;
			if (flag10)
			{
				bool flag11 = this.MainCore.Soul.CameraEffect != null;
				if (flag11)
				{
					for (int l = 0; l < this.MainCore.Soul.CameraEffect.Count; l++)
					{
						this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.CameraEffect[l].At * this._time_scale, this._TimerCallback, this.MainCore.Soul.CameraEffect[l], XArtsSkill.EArtsSkillTimerCb.EShake));
					}
				}
				bool isPlayer = this._firer.IsPlayer;
				if (isPlayer)
				{
					bool flag12 = this.MainCore.Soul.CameraMotion != null && !string.IsNullOrEmpty(this.MainCore.Soul.CameraMotion.Motion);
					if (flag12)
					{
						this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.CameraMotion.At * this._time_scale, this._TimerCallback, this.MainCore, XArtsSkill.EArtsSkillTimerCb.ECameraMotion));
					}
					bool flag13 = this.MainCore.Soul.CameraPostEffect != null;
					if (flag13)
					{
						bool flag14 = !this._demonstration && !string.IsNullOrEmpty(this.MainCore.Soul.CameraPostEffect.Effect);
						if (flag14)
						{
							this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.CameraPostEffect.At * this._time_scale, this._TimerCallback, this.MainCore, XArtsSkill.EArtsSkillTimerCb.ECameraPostEffect));
							this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.CameraPostEffect.End * this._time_scale, this._TimerCallback, this.MainCore, XArtsSkill.EArtsSkillTimerCb.EEndCameraPostEffect));
						}
						bool flag15 = !this._demonstration && this.MainCore.Soul.CameraPostEffect.SolidBlack;
						if (flag15)
						{
							this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.CameraPostEffect.Solid_At * this._time_scale, this._TimerCallback, this.MainCore, XArtsSkill.EArtsSkillTimerCb.ESolidBlack));
							this.AddedCombinedTimerToken(XSingleton<XTimerMgr>.singleton.SetTimer<XArtsSkill.EArtsSkillTimerCb>(this.MainCore.Soul.CameraPostEffect.Solid_End * this._time_scale, this._TimerCallback, null, XArtsSkill.EArtsSkillTimerCb.ESolidBlack));
						}
					}
				}
			}
			bool suppressPlayer = this.MainCore.Soul.Logical.SuppressPlayer;
			if (suppressPlayer)
			{
				XSingleton<XEntityMgr>.singleton.DummilizePlayer(true);
			}
		}

		protected override bool Launch(XSkillCore core)
		{
			bool flag = core.Soul.Combined.Count > 0;
			bool result;
			if (flag)
			{
				this._main_core = core;
				this.MainCore.Execute(this);
				this.MainCoreStart();
				this.Combined(0);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void CombinedKillTimerAll()
		{
			for (int i = 0; i < this._combined_token.Count; i++)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._combined_token[i]);
			}
			this._combined_token.Clear();
		}

		private void Combined(object param)
		{
			this._combined_id = (int)param;
			XSkillCore skill = this._skillmgr.GetSkill(XSingleton<XCommon>.singleton.XHash(this.MainCore.Soul.Combined[this._combined_id].Name));
			bool flag = skill != null;
			if (flag)
			{
				bool flag2 = this._combined_id > 0;
				if (flag2)
				{
					bool flag3 = this._stop_method != null;
					if (flag3)
					{
						this._stop_method(this);
					}
					bool shut_down = this._shut_down;
					if (shut_down)
					{
						this._shut_down_elapsed = 0f;
						for (int i = 0; i < this._combined_id; i++)
						{
							XSkillCore skill2 = this._skillmgr.GetSkill(XSingleton<XCommon>.singleton.XHash(this.MainCore.Soul.Combined[i].Name));
							this._shut_down_elapsed += ((skill2 != null) ? skill2.Soul.Time : 0f);
						}
						return;
					}
					XEntity target = this._demonstration ? null : base.Target;
					base.Puppetize(false);
					this._target = target;
					this._firer.Skill.TagTrigger();
					bool flag4 = this._firer.Ator != null;
					if (flag4)
					{
						this._firer.Ator.speed = 0f;
					}
					base.AnimInit = false;
				}
				this._core = skill;
				this._data = this._core.Soul;
				bool flag5 = this._combined_id + 1 < this.MainCore.Soul.Combined.Count;
				if (flag5)
				{
					this._combine_token = XSingleton<XTimerMgr>.singleton.SetTimer<XCombinedSkill.ECombinedSkillTimerCb>((this.MainCore.Soul.Combined[this._combined_id].End - this.MainCore.Soul.Combined[this._combined_id].At) * this._time_scale, this._TimerCallback, this._combined_id + 1, XCombinedSkill.ECombinedSkillTimerCb.ECombined);
				}
			}
		}

		public void AddedCombinedTimerToken(uint token)
		{
			this._combined_token.Add(token);
		}

		private XSkillCore _main_core = null;

		private int _combined_id = 0;

		private uint _combine_token = 0U;

		private int _result_time = 0;

		private bool _shut_down = false;

		private float _shut_down_elapsed = 0f;

		private SmallBuffer<uint> _combined_token;

		private enum ECombinedSkillTimerCb
		{

			ECombined = 25,

			ECombinedSkillNum
		}
	}
}
