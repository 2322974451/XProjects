using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PushConfig")]
	[Serializable]
	public class PushConfig : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "forbid", DataFormat = DataFormat.Default)]
		public bool forbid
		{
			get
			{
				return this._forbid ?? false;
			}
			set
			{
				this._forbid = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool forbidSpecified
		{
			get
			{
				return this._forbid != null;
			}
			set
			{
				bool flag = value == (this._forbid == null);
				if (flag)
				{
					this._forbid = (value ? new bool?(this.forbid) : null);
				}
			}
		}

		private bool ShouldSerializeforbid()
		{
			return this.forbidSpecified;
		}

		private void Resetforbid()
		{
			this.forbidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private bool? _forbid;

		private IExtension extensionObject;
	}
}
