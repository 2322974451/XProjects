using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpecialStateNtf")]
	[Serializable]
	public class SpecialStateNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
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
					this._state = (value ? new uint?(this.state) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "effectmask", DataFormat = DataFormat.TwosComplement)]
		public uint effectmask
		{
			get
			{
				return this._effectmask ?? 0U;
			}
			set
			{
				this._effectmask = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool effectmaskSpecified
		{
			get
			{
				return this._effectmask != null;
			}
			set
			{
				bool flag = value == (this._effectmask == null);
				if (flag)
				{
					this._effectmask = (value ? new uint?(this.effectmask) : null);
				}
			}
		}

		private bool ShouldSerializeeffectmask()
		{
			return this.effectmaskSpecified;
		}

		private void Reseteffectmask()
		{
			this.effectmaskSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _state;

		private uint? _effectmask;

		private ulong? _uid;

		private IExtension extensionObject;
	}
}
