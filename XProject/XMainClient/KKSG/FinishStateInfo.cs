using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FinishStateInfo")]
	[Serializable]
	public class FinishStateInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public SceneFinishState state
		{
			get
			{
				return this._state ?? SceneFinishState.SCENE_FINISH_NONE;
			}
			set
			{
				this._state = new SceneFinishState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new SceneFinishState?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "countdown", DataFormat = DataFormat.TwosComplement)]
		public int countdown
		{
			get
			{
				return this._countdown ?? 0;
			}
			set
			{
				this._countdown = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countdownSpecified
		{
			get
			{
				return this._countdown != null;
			}
			set
			{
				bool flag = value == (this._countdown == null);
				if (flag)
				{
					this._countdown = (value ? new int?(this.countdown) : null);
				}
			}
		}

		private bool ShouldSerializecountdown()
		{
			return this.countdownSpecified;
		}

		private void Resetcountdown()
		{
			this.countdownSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private SceneFinishState? _state;

		private int? _countdown;

		private IExtension extensionObject;
	}
}
