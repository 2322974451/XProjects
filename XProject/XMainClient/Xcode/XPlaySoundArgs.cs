using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPlaySoundArgs : XEventArgs
	{

		public XPlaySoundArgs()
		{
			this._eDefine = XEventDefine.XEvent_PlaySound;
			this.SoundChannel = AudioChannel.Motion;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.SoundAction = XPlaySoundArgs.Action.Stop;
			this.SoundChannel = AudioChannel.Motion;
			this.EventName = null;
			this.Position = Vector3.zero;
			this.ExParam = null;
			XEventPool<XPlaySoundArgs>.Recycle(this);
		}

		public XPlaySoundArgs.Action SoundAction { get; set; }

		public AudioChannel SoundChannel { get; set; }

		public string EventName { get; set; }

		public XAudioExParam ExParam { get; set; }

		public Vector3 Position = Vector3.zero;

		public enum Action
		{

			Play,

			Pause,

			Stop
		}
	}
}
