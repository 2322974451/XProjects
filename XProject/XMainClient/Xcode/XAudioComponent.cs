using System;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAudioComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XAudioComponent.uuID;
			}
		}

		private static void _Init(XGameObject gameObject, object o, int commandID)
		{
			XAudioComponent xaudioComponent = o as XAudioComponent;
			xaudioComponent.cachedGo = gameObject.Get();
			xaudioComponent.InitEmitter();
		}

		private void InitEmitter()
		{
			bool flag = this._emitter != null && this.cachedGo != null;
			if (flag)
			{
				Rigidbody rigidbody = null;
				bool flag2 = this.cachedGo != null;
				if (flag2)
				{
					rigidbody = this.cachedGo.GetComponent<Rigidbody>();
				}
				this._emitter.Init(this.cachedGo, rigidbody);
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			bool flag = this._entity != null && this._entity.EngineObject != null;
			if (flag)
			{
				this._entity.EngineObject.CallCommand(XAudioComponent._initCb, this, -1, false);
			}
		}

		public override void Attached()
		{
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_PlaySound, new XComponent.XEventHandler(this.Play));
		}

		public override void OnDetachFromHost()
		{
			bool flag = this._emitter != null;
			if (flag)
			{
				this._emitter.Destroy();
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ReturnClass(EClassType.ERuntimeFMOD, this._emitter);
				this._emitter = null;
			}
			base.OnDetachFromHost();
		}

		public void StopChannel(AudioChannel channel)
		{
			bool flag = this._emitter != null;
			if (flag)
			{
				this._emitter.Stop(channel);
			}
		}

		public bool IsPlaying(AudioChannel channel)
		{
			bool flag = this._emitter != null;
			return flag && this._emitter.IsPlaying(channel);
		}

		public void Set3DPos(Vector3 pos)
		{
			bool flag = this._host == null;
			if (!flag)
			{
				bool flag2 = this._emitter == null;
				if (flag2)
				{
					this._emitter = (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CreateClass(EClassType.ERuntimeFMOD) as IXFmod);
					this.InitEmitter();
				}
				this._emitter.Update3DAttributes(pos, AudioChannel.Action);
			}
		}

		protected bool Play(XEventArgs e)
		{
			XPlaySoundArgs xplaySoundArgs = e as XPlaySoundArgs;
			XPlaySoundArgs.Action soundAction = xplaySoundArgs.SoundAction;
			AudioChannel soundChannel = xplaySoundArgs.SoundChannel;
			bool bUseFMOD = XSingleton<XAudioMgr>.singleton.bUseFMOD;
			if (bUseFMOD)
			{
				bool flag = this._emitter == null;
				if (flag)
				{
					this._emitter = (XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CreateClass(EClassType.ERuntimeFMOD) as IXFmod);
					this.InitEmitter();
				}
				XPlaySoundArgs.Action action = soundAction;
				if (action != XPlaySoundArgs.Action.Play)
				{
					if (action == XPlaySoundArgs.Action.Stop)
					{
						this._emitter.Stop(soundChannel);
					}
				}
				else
				{
					bool flag2 = soundChannel == AudioChannel.Behit;
					if (flag2)
					{
						bool flag3 = xplaySoundArgs.ExParam != null && XEntity.ValideEntity(xplaySoundArgs.ExParam._caster) && xplaySoundArgs.ExParam._caster.IsRole;
						if (flag3)
						{
							float value = xplaySoundArgs.ExParam._caster.TypeID % 10U;
							this._emitter.StartEvent("event:/" + xplaySoundArgs.EventName, soundChannel, false, "attacktype", value);
							goto IL_24F;
						}
					}
					bool flag4 = this._entity != null && this._entity.IsPlayer && (soundChannel == AudioChannel.Skill || soundChannel == AudioChannel.SkillCombine);
					if (flag4)
					{
						this._emitter.Update3DAttributes(XSingleton<XScene>.singleton.GameCamera.CameraTrans.position, AudioChannel.Action);
					}
					else
					{
						bool flag5 = this._entity != null && this._entity.IsDummy;
						if (flag5)
						{
							this._emitter.Update3DAttributes(XSingleton<XScene>.singleton.GameCamera.CameraTrans.position, AudioChannel.Action);
						}
					}
					bool flag6 = xplaySoundArgs.ExParam != null && xplaySoundArgs.ExParam._3dPos != Vector3.zero;
					if (flag6)
					{
						this._emitter.Update3DAttributes(xplaySoundArgs.ExParam._3dPos, AudioChannel.Action);
					}
					bool flag7 = xplaySoundArgs.ExParam != null && !string.IsNullOrEmpty(xplaySoundArgs.ExParam._fmodParam);
					if (flag7)
					{
						this._emitter.StartEvent("event:/" + xplaySoundArgs.EventName, soundChannel, true, xplaySoundArgs.ExParam._fmodParam, xplaySoundArgs.ExParam._fmodValue);
					}
					else
					{
						this._emitter.StartEvent("event:/" + xplaySoundArgs.EventName, soundChannel, true, "", 0f);
					}
				}
				IL_24F:;
			}
			return true;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Audio");

		private IXFmod _emitter = null;

		private static CommandCallback _initCb = new CommandCallback(XAudioComponent._Init);

		private GameObject cachedGo;
	}
}
