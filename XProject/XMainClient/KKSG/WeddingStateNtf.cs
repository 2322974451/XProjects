using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeddingStateNtf")]
	[Serializable]
	public class WeddingStateNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public WeddingState state
		{
			get
			{
				return this._state ?? WeddingState.WeddingState_Prepare;
			}
			set
			{
				this._state = new WeddingState?(value);
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
					this._state = (value ? new WeddingState?(this.state) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "happyness", DataFormat = DataFormat.TwosComplement)]
		public uint happyness
		{
			get
			{
				return this._happyness ?? 0U;
			}
			set
			{
				this._happyness = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool happynessSpecified
		{
			get
			{
				return this._happyness != null;
			}
			set
			{
				bool flag = value == (this._happyness == null);
				if (flag)
				{
					this._happyness = (value ? new uint?(this.happyness) : null);
				}
			}
		}

		private bool ShouldSerializehappyness()
		{
			return this.happynessSpecified;
		}

		private void Resethappyness()
		{
			this.happynessSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "vows", DataFormat = DataFormat.Default)]
		public bool vows
		{
			get
			{
				return this._vows ?? false;
			}
			set
			{
				this._vows = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vowsSpecified
		{
			get
			{
				return this._vows != null;
			}
			set
			{
				bool flag = value == (this._vows == null);
				if (flag)
				{
					this._vows = (value ? new bool?(this.vows) : null);
				}
			}
		}

		private bool ShouldSerializevows()
		{
			return this.vowsSpecified;
		}

		private void Resetvows()
		{
			this.vowsSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private WeddingState? _state;

		private uint? _lefttime;

		private uint? _happyness;

		private bool? _vows;

		private IExtension extensionObject;
	}
}
