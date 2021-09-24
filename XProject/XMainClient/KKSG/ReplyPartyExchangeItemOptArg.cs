using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReplyPartyExchangeItemOptArg")]
	[Serializable]
	public class ReplyPartyExchangeItemOptArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "operate_type", DataFormat = DataFormat.TwosComplement)]
		public uint operate_type
		{
			get
			{
				return this._operate_type ?? 0U;
			}
			set
			{
				this._operate_type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool operate_typeSpecified
		{
			get
			{
				return this._operate_type != null;
			}
			set
			{
				bool flag = value == (this._operate_type == null);
				if (flag)
				{
					this._operate_type = (value ? new uint?(this.operate_type) : null);
				}
			}
		}

		private bool ShouldSerializeoperate_type()
		{
			return this.operate_typeSpecified;
		}

		private void Resetoperate_type()
		{
			this.operate_typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "lauch_role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong lauch_role_id
		{
			get
			{
				return this._lauch_role_id ?? 0UL;
			}
			set
			{
				this._lauch_role_id = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_role_idSpecified
		{
			get
			{
				return this._lauch_role_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_role_id == null);
				if (flag)
				{
					this._lauch_role_id = (value ? new ulong?(this.lauch_role_id) : null);
				}
			}
		}

		private bool ShouldSerializelauch_role_id()
		{
			return this.lauch_role_idSpecified;
		}

		private void Resetlauch_role_id()
		{
			this.lauch_role_idSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _operate_type;

		private ulong? _lauch_role_id;

		private IExtension extensionObject;
	}
}
