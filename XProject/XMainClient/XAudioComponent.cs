using System;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FBA RID: 4026
	internal class XAudioComponent : XComponent
	{
		// Token: 0x170036A5 RID: 13989
		// (get) Token: 0x0600D13A RID: 53562 RVA: 0x00306AC8 File Offset: 0x00304CC8
		public override uint ID
		{
			get
			{
				return XAudioComponent.uuID;
			}
		}

		// Token: 0x0600D13B RID: 53563 RVA: 0x00306AE0 File Offset: 0x00304CE0
		private static void _Init(XGameObject gameObject, object o, int commandID)
		{
			XAudioComponent xaudioComponent = o as XAudioComponent;
			xaudioComponent.cachedGo = gameObject.Get();
			xaudioComponent.InitEmitter();
		}

		// Token: 0x0600D13C RID: 53564 RVA: 0x00306B08 File Offset: 0x00304D08
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

		// Token: 0x0600D13D RID: 53565 RVA: 0x00306B68 File Offset: 0x00304D68
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			bool flag = this._entity != null && this._entity.EngineObject != null;
			if (flag)
			{
				this._entity.EngineObject.CallCommand(XAudioComponent._initCb, this, -1, false);
			}
		}

		// Token: 0x0600D13E RID: 53566 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Attached()
		{
		}

		// Token: 0x0600D13F RID: 53567 RVA: 0x00306BB4 File Offset: 0x00304DB4
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_PlaySound, new XComponent.XEventHandler(this.Play));
		}

		// Token: 0x0600D140 RID: 53568 RVA: 0x00306BCC File Offset: 0x00304DCC
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

		// Token: 0x0600D141 RID: 53569 RVA: 0x00306C1C File Offset: 0x00304E1C
		public void StopChannel(AudioChannel channel)
		{
			bool flag = this._emitter != null;
			if (flag)
			{
				this._emitter.Stop(channel);
			}
		}

		// Token: 0x0600D142 RID: 53570 RVA: 0x00306C44 File Offset: 0x00304E44
		public bool IsPlaying(AudioChannel channel)
		{
			bool flag = this._emitter != null;
			return flag && this._emitter.IsPlaying(channel);
		}

		// Token: 0x0600D143 RID: 53571 RVA: 0x00306C74 File Offset: 0x00304E74
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

		// Token: 0x0600D144 RID: 53572 RVA: 0x00306CD0 File Offset: 0x00304ED0
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

		// Token: 0x04005EB1 RID: 24241
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Audio");

		// Token: 0x04005EB2 RID: 24242
		private IXFmod _emitter = null;

		// Token: 0x04005EB3 RID: 24243
		private static CommandCallback _initCb = new CommandCallback(XAudioComponent._Init);

		// Token: 0x04005EB4 RID: 24244
		private GameObject cachedGo;
	}
}
