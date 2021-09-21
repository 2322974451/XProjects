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
	// Token: 0x02000DA9 RID: 3497
	internal class XAudioMgr : XSingleton<XAudioMgr>
	{
		// Token: 0x0600BDB2 RID: 48562 RVA: 0x0027701C File Offset: 0x0027521C
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

		// Token: 0x0600BDB3 RID: 48563 RVA: 0x002771CC File Offset: 0x002753CC
		public override void Uninit()
		{
			this._async_loader = null;
		}

		// Token: 0x0600BDB4 RID: 48564 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnLeaveScene()
		{
		}

		// Token: 0x0600BDB5 RID: 48565 RVA: 0x002771D8 File Offset: 0x002753D8
		public void SetSystemMute(bool mute)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetMainVolume((float)(mute ? 0 : 1));
			}
		}

		// Token: 0x0600BDB6 RID: 48566 RVA: 0x00277208 File Offset: 0x00275408
		public void SetSystemVolume(float volume)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetMainVolume(volume);
			}
		}

		// Token: 0x0600BDB7 RID: 48567 RVA: 0x00277230 File Offset: 0x00275430
		public void SetBGMVolume(bool state)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetBGMVolume((float)(state ? 1 : 0));
			}
		}

		// Token: 0x0600BDB8 RID: 48568 RVA: 0x00277260 File Offset: 0x00275460
		public string GetFullSoundName(string strPrefab, string strValueInTable)
		{
			this._sound.Remove(6, this._sound.Length - 6);
			return this._sound.Append(strValueInTable).ToString();
		}

		// Token: 0x0600BDB9 RID: 48569 RVA: 0x002772A0 File Offset: 0x002754A0
		public void StopSound(IXFmod iFmod)
		{
			bool flag = iFmod != null;
			if (flag)
			{
				iFmod.Destroy();
			}
		}

		// Token: 0x0600BDBA RID: 48570 RVA: 0x002772C0 File Offset: 0x002754C0
		public void PlaySound(IXFmod iFmod, AudioChannel channel, string eventname)
		{
			bool flag = iFmod != null;
			if (flag)
			{
				iFmod.StartEvent("event:/" + eventname, channel, true, "", 0f);
			}
		}

		// Token: 0x0600BDBB RID: 48571 RVA: 0x002772F4 File Offset: 0x002754F4
		public void PlaySound(XObject entity, AudioChannel channel, string eventname, Vector3 correctTo)
		{
			this.PlaySound(entity, channel, eventname, false, new XAudioExParam(correctTo));
		}

		// Token: 0x0600BDBC RID: 48572 RVA: 0x0027730C File Offset: 0x0027550C
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

		// Token: 0x0600BDBD RID: 48573 RVA: 0x00277353 File Offset: 0x00275553
		public void PlaySound(XObject entity, AudioChannel channel, string eventname)
		{
			this.PlaySound(entity, channel, eventname, false, null);
		}

		// Token: 0x0600BDBE RID: 48574 RVA: 0x00277364 File Offset: 0x00275564
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

		// Token: 0x0600BDBF RID: 48575 RVA: 0x002773C5 File Offset: 0x002755C5
		public void PlaySound(XEntity entity, AudioChannel channel, XAudioStateDefine state)
		{
			this.PlaySound(entity, channel, state, false, null);
		}

		// Token: 0x0600BDC0 RID: 48576 RVA: 0x002773D4 File Offset: 0x002755D4
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

		// Token: 0x0600BDC1 RID: 48577 RVA: 0x002774DC File Offset: 0x002756DC
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

		// Token: 0x0600BDC2 RID: 48578 RVA: 0x00277518 File Offset: 0x00275718
		public bool IsPlayingSound(XEntity entity, AudioChannel channel)
		{
			bool flag = entity.Audio != null;
			return flag && entity.Audio.IsPlaying(channel);
		}

		// Token: 0x0600BDC3 RID: 48579 RVA: 0x00277548 File Offset: 0x00275748
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

		// Token: 0x0600BDC4 RID: 48580 RVA: 0x002776C8 File Offset: 0x002758C8
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

		// Token: 0x0600BDC5 RID: 48581 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void StoreAudioSource(GameObject go)
		{
		}

		// Token: 0x0600BDC6 RID: 48582 RVA: 0x0027773C File Offset: 0x0027593C
		public void StopUISound()
		{
			IXFmod fmodComponent = this.GetFmodComponent(XSingleton<XGameUI>.singleton.UIAudio);
			fmodComponent.Stop(AudioChannel.Action);
		}

		// Token: 0x0600BDC7 RID: 48583 RVA: 0x00277764 File Offset: 0x00275964
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

		// Token: 0x0600BDC8 RID: 48584 RVA: 0x002777D0 File Offset: 0x002759D0
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

		// Token: 0x0600BDC9 RID: 48585 RVA: 0x0027784C File Offset: 0x00275A4C
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

		// Token: 0x0600BDCA RID: 48586 RVA: 0x002778A4 File Offset: 0x00275AA4
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

		// Token: 0x0600BDCB RID: 48587 RVA: 0x002778FC File Offset: 0x00275AFC
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

		// Token: 0x0600BDCC RID: 48588 RVA: 0x00277940 File Offset: 0x00275B40
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

		// Token: 0x0600BDCD RID: 48589 RVA: 0x00277990 File Offset: 0x00275B90
		public void SetBGMVolme(float vol)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetBGMVolume(vol);
			}
		}

		// Token: 0x0600BDCE RID: 48590 RVA: 0x002779B8 File Offset: 0x00275BB8
		public void SetMscVolme(float vol)
		{
			bool flag = this._fModBus != null;
			if (flag)
			{
				this._fModBus.SetSFXVolume(vol);
			}
		}

		// Token: 0x0600BDCF RID: 48591 RVA: 0x002779E0 File Offset: 0x00275BE0
		public void SetMainBusVolume(float volume)
		{
			this.SetBusStatuMute("bus:/MainGroupControl", volume);
		}

		// Token: 0x0600BDD0 RID: 48592 RVA: 0x002779F0 File Offset: 0x00275BF0
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

		// Token: 0x0600BDD1 RID: 48593 RVA: 0x00277A28 File Offset: 0x00275C28
		public void StopSoundForCutscene()
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.StopVoice();
			}
			this.StopUISound();
		}

		// Token: 0x04004D56 RID: 19798
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x04004D57 RID: 19799
		private ActionAudio _reader = new ActionAudio();

		// Token: 0x04004D58 RID: 19800
		private StringBuilder _sound = new StringBuilder("Audio/", 128);

		// Token: 0x04004D59 RID: 19801
		private IXFmodBus _fModBus = null;

		// Token: 0x04004D5A RID: 19802
		public bool bUseFMOD = true;

		// Token: 0x04004D5B RID: 19803
		public bool hasSound = true;
	}
}
