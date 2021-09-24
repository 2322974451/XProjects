using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAudioMgr : XSingleton<XAudioMgr>
	{

		public override bool Init()
		{
			GameObject gameObject = GameObject.Find("XGamePoint");
			this._fModBus = (gameObject.GetComponent("XFmodBus") as IXFmodBus);
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/ActionAudio", this._reader, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				foreach (KeyValuePair<string, ActionAudio.RowData> keyValuePair in this._reader.Table)
				{
					ActionAudio.RowData value = keyValuePair.Value;
					this.InnerInit(value.Prefab, value.Idle);
					this.InnerInit(value.Prefab, value.Move);
					this.InnerInit(value.Prefab, value.Freeze);
					this.InnerInit(value.Prefab, value.Charge);
					this.InnerInit(value.Prefab, value.Jump);
					this.InnerInit(value.Prefab, value.Fall);
					this.InnerInit(value.Prefab, value.Behit);
					this.InnerInit(value.Prefab, value.BehitFly);
					this.InnerInit(value.Prefab, value.BehitRoll);
					this.InnerInit(value.Prefab, value.Death);
					this.InnerInit(value.Prefab, value.BehitSuperArmor);
				}
				result = true;
			}
			return result;
		}

		public override void Uninit()
		{
			this._async_loader = null;
		}

		public void OnLeaveScene()
		{
		}

		public void SetSystemMute(bool mute)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetMainVolume((float)(mute ? 0 : 1));
			}
		}

		public void SetSystemVolume(float volume)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetMainVolume(volume);
			}
		}

		public void SetBGMVolume(bool state)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetBGMVolume((float)(state ? 1 : 0));
			}
		}

		public string GetFullSoundName(string strPrefab, string strValueInTable)
		{
			this._sound.Remove(6, this._sound.Length - 6);
			return this._sound.Append(strValueInTable).ToString();
		}

		public void StopSound(IXFmod iFmod)
		{
			bool flag = iFmod != null;
			if (flag)
			{
				iFmod.Destroy();
			}
		}

		public void PlaySound(IXFmod iFmod, AudioChannel channel, string eventname)
		{
			bool flag = iFmod != null;
			if (flag)
			{
				iFmod.StartEvent("event:/" + eventname, channel, true, "", 0f);
			}
		}

		public void PlaySound(XObject entity, AudioChannel channel, string eventname, Vector3 correctTo)
		{
			this.PlaySound(entity, channel, eventname, false, new XAudioExParam(correctTo));
		}

		public void StopSound(XObject entity, AudioChannel channel)
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				XPlaySoundArgs @event = XEventPool<XPlaySoundArgs>.GetEvent();
				@event.SoundAction = XPlaySoundArgs.Action.Stop;
				@event.SoundChannel = channel;
				@event.Firer = entity;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		public void PlaySound(XObject entity, AudioChannel channel, string eventname)
		{
			this.PlaySound(entity, channel, eventname, false, null);
		}

		public void PlaySound(XObject entity, AudioChannel channel, string eventname, bool bDepracatedPass, XAudioExParam param)
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				XPlaySoundArgs @event = XEventPool<XPlaySoundArgs>.GetEvent();
				@event.DepracatedPass = bDepracatedPass;
				@event.SoundAction = XPlaySoundArgs.Action.Play;
				@event.SoundChannel = channel;
				@event.EventName = eventname;
				@event.Firer = entity;
				@event.ExParam = param;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		public void PlaySound(XEntity entity, AudioChannel channel, XAudioStateDefine state)
		{
			this.PlaySound(entity, channel, state, false, null);
		}

		public void PlaySound(XEntity entity, AudioChannel channel, XAudioStateDefine state, bool bDepracatedPass, XAudioExParam param)
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				float delay = 0f;
				string[] audioTagByState = this.GetAudioTagByState(entity, state, out delay);
				bool flag2 = audioTagByState == null || audioTagByState.Length == 0;
				if (!flag2)
				{
					bool flag3 = audioTagByState.Length != 0;
					if (flag3)
					{
						XPlaySoundArgs @event = XEventPool<XPlaySoundArgs>.GetEvent();
						@event.DepracatedPass = bDepracatedPass;
						@event.SoundAction = XPlaySoundArgs.Action.Play;
						@event.SoundChannel = channel;
						@event.EventName = audioTagByState[0];
						@event.Firer = entity;
						@event.ExParam = param;
						XSingleton<XEventMgr>.singleton.FireEvent(@event, delay);
					}
					bool flag4 = audioTagByState.Length > 1;
					if (flag4)
					{
						XPlaySoundArgs event2 = XEventPool<XPlaySoundArgs>.GetEvent();
						event2.DepracatedPass = bDepracatedPass;
						event2.SoundAction = XPlaySoundArgs.Action.Play;
						event2.SoundChannel = this.GetAnotherChannel(channel);
						event2.EventName = audioTagByState[1];
						event2.Firer = entity;
						event2.ExParam = param;
						XSingleton<XEventMgr>.singleton.FireEvent(event2, delay);
					}
				}
			}
		}

		protected AudioChannel GetAnotherChannel(AudioChannel inChannel)
		{
			switch (inChannel)
			{
			case AudioChannel.Motion:
				return AudioChannel.Action;
			case AudioChannel.Action:
				return AudioChannel.Motion;
			case AudioChannel.Skill:
				return AudioChannel.Motion;
			}
			return AudioChannel.Motion;
		}

		public bool IsPlayingSound(XEntity entity, AudioChannel channel)
		{
			bool flag = entity.Audio != null;
			return flag && entity.Audio.IsPlaying(channel);
		}

		public string[] GetAudioTagByState(XEntity entity, XAudioStateDefine state, out float t)
		{
			string[] array = null;
			t = 0f;
			string key = entity.IsTransform ? entity.Transformer.Prefab : entity.Prefab;
			ActionAudio.RowData byPrefab = this._reader.GetByPrefab(key);
			bool flag = byPrefab != null;
			if (flag)
			{
				switch (state)
				{
				case XAudioStateDefine.XState_Audio_Idle:
					array = byPrefab.Idle;
					break;
				case XAudioStateDefine.XState_Audio_Move:
				{
					bool isMounted = entity.IsMounted;
					if (isMounted)
					{
						ActionAudio.RowData byPrefab2 = this._reader.GetByPrefab(entity.Mount.Prefab);
						bool flag2 = byPrefab2 != null;
						if (flag2)
						{
							array = byPrefab2.Move;
						}
					}
					else
					{
						array = byPrefab.Move;
					}
					break;
				}
				case XAudioStateDefine.XState_Audio_Jump:
					array = byPrefab.Jump;
					break;
				case XAudioStateDefine.XState_Audio_Fall:
					array = byPrefab.Fall;
					break;
				case XAudioStateDefine.XState_Audio_Freeze:
					array = byPrefab.Freeze;
					break;
				case XAudioStateDefine.XState_Audio_BeHit:
				{
					bool flag3 = entity.BeHit != null;
					if (flag3)
					{
						switch (entity.BeHit.CurrentStateinLogical)
						{
						case XBeHitState.Hit_Back:
							array = byPrefab.Behit;
							break;
						case XBeHitState.Hit_Fly:
							array = byPrefab.BehitFly;
							break;
						case XBeHitState.Hit_Roll:
							array = byPrefab.BehitRoll;
							break;
						}
					}
					break;
				}
				case XAudioStateDefine.XState_Audio_Death:
					array = byPrefab.Death;
					break;
				case XAudioStateDefine.XState_Audio_Charge:
					array = byPrefab.Charge;
					break;
				case XAudioStateDefine.XState_Audio_Bati:
					array = byPrefab.BehitSuperArmor;
					break;
				}
				bool flag4 = array != null && array.Length != 0;
				if (flag4)
				{
					t = 0f;
				}
			}
			return array;
		}

		private void InnerInit(string prefab, string[] clips)
		{
			bool flag = clips != null;
			if (flag)
			{
				for (int i = 0; i < clips.Length; i++)
				{
					bool flag2 = i == clips.Length - 1;
					if (flag2)
					{
						float num = 0f;
						bool flag3 = !float.TryParse(clips[i], out num);
						if (flag3)
						{
							clips[i] = this.GetFullSoundName(prefab, clips[i]);
						}
						break;
					}
					clips[i] = this.GetFullSoundName(prefab, clips[i]);
				}
			}
		}

		public void StoreAudioSource(GameObject go)
		{
		}

		public void StopUISound()
		{
			IXFmod fmodComponent = this.GetFmodComponent(XSingleton<XGameUI>.singleton.UIAudio);
			fmodComponent.Stop(AudioChannel.Action);
		}

		public void PlayUISound(string name, bool stopall = true, AudioChannel channel = AudioChannel.Action)
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				bool flag2 = this.bUseFMOD;
				if (flag2)
				{
					IXFmod fmodComponent = this.GetFmodComponent(XSingleton<XGameUI>.singleton.UIAudio);
					if (stopall)
					{
						fmodComponent.Stop(channel);
					}
					fmodComponent.StartEvent("event:/" + name, channel, true, "", 0f);
				}
			}
		}

		public void PlayBGM(string bgm)
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				bool flag2 = string.IsNullOrEmpty(bgm);
				if (!flag2)
				{
					GameObject gameObject = GameObject.Find("Scene");
					bool flag3 = gameObject == null;
					if (!flag3)
					{
						bool flag4 = this.bUseFMOD;
						if (flag4)
						{
							IXFmod fmodComponent = this.GetFmodComponent(gameObject);
							fmodComponent.StartEvent("event:/" + bgm, AudioChannel.Action, true, "", 0f);
						}
					}
				}
			}
		}

		public void ResumeBGM()
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				GameObject gameObject = GameObject.Find("Scene");
				bool flag2 = gameObject == null;
				if (!flag2)
				{
					bool flag3 = this.bUseFMOD;
					if (flag3)
					{
						IXFmod fmodComponent = this.GetFmodComponent(gameObject);
						fmodComponent.Play(AudioChannel.Action);
					}
				}
			}
		}

		public void PauseBGM()
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				GameObject gameObject = GameObject.Find("Scene");
				bool flag2 = gameObject == null;
				if (!flag2)
				{
					bool flag3 = this.bUseFMOD;
					if (flag3)
					{
						IXFmod fmodComponent = this.GetFmodComponent(gameObject);
						fmodComponent.Stop(AudioChannel.Action);
					}
				}
			}
		}

		public IXFmod GetFmodComponent(GameObject go)
		{
			IXFmod ixfmod = go.GetComponent("XFmod") as IXFmod;
			bool flag = ixfmod == null;
			if (flag)
			{
				ixfmod = (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.AddComponent(go, EComponentType.EXFmod) as IXFmod);
			}
			return ixfmod;
		}

		public void PlaySoundAt(Vector3 position, string bgm)
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				bool flag2 = string.IsNullOrEmpty(bgm);
				if (!flag2)
				{
					bool flag3 = this._fModBus != null;
					if (flag3)
					{
						this._fModBus.PlayOneShot("event:/" + bgm, position);
					}
				}
			}
		}

		public void SetBGMVolme(float vol)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetBGMVolume(vol);
			}
		}

		public void SetMscVolme(float vol)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetSFXVolume(vol);
			}
		}

		public void SetMainBusVolume(float volume)
		{
			this.SetBusStatuMute("bus:/MainGroupControl", volume);
		}

		public void SetBusStatuMute(string bus, float volume)
		{
			bool flag = !this.hasSound;
			if (!flag)
			{
				bool flag2 = this._fModBus != null;
				if (flag2)
				{
					this._fModBus.SetBusVolume(bus, volume);
				}
			}
		}

		public void StopSoundForCutscene()
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.StopVoice();
			}
			this.StopUISound();
		}

		private XTableAsyncLoader _async_loader = null;

		private ActionAudio _reader = new ActionAudio();

		private StringBuilder _sound = new StringBuilder("Audio/", 128);

		private IXFmodBus _fModBus = null;

		public bool bUseFMOD = true;

		public bool hasSound = true;
	}
}
