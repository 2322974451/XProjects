using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QTEOperation")]
	[Serializable]
	public class QTEOperation : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "monsterid", DataFormat = DataFormat.TwosComplement)]
		public ulong monsterid
		{
			get
			{
				return this._monsterid ?? 0UL;
			}
			set
			{
				this._monsterid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool monsteridSpecified
		{
			get
			{
				return this._monsterid != null;
			}
			set
			{
				bool flag = value == (this._monsterid == null);
				if (flag)
				{
					this._monsterid = (value ? new ulong?(this.monsterid) : null);
				}
			}
		}

		private bool ShouldSerializemonsterid()
		{
			return this.monsteridSpecified;
		}

		private void Resetmonsterid()
		{
			this.monsteridSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private ulong? _monsterid;

		private IExtension extensionObject;
	}
}
