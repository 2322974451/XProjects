using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaSignalBroadcastData")]
	[Serializable]
	public class MobaSignalBroadcastData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "posxz", DataFormat = DataFormat.TwosComplement)]
		public uint posxz
		{
			get
			{
				return this._posxz ?? 0U;
			}
			set
			{
				this._posxz = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool posxzSpecified
		{
			get
			{
				return this._posxz != null;
			}
			set
			{
				bool flag = value == (this._posxz == null);
				if (flag)
				{
					this._posxz = (value ? new uint?(this.posxz) : null);
				}
			}
		}

		private bool ShouldSerializeposxz()
		{
			return this.posxzSpecified;
		}

		private void Resetposxz()
		{
			this.posxzSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private ulong? _uid;

		private uint? _posxz;

		private IExtension extensionObject;
	}
}
