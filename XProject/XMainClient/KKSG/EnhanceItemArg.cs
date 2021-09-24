using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnhanceItemArg")]
	[Serializable]
	public class EnhanceItemArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "UniqueItemId", DataFormat = DataFormat.TwosComplement)]
		public ulong UniqueItemId
		{
			get
			{
				return this._UniqueItemId ?? 0UL;
			}
			set
			{
				this._UniqueItemId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool UniqueItemIdSpecified
		{
			get
			{
				return this._UniqueItemId != null;
			}
			set
			{
				bool flag = value == (this._UniqueItemId == null);
				if (flag)
				{
					this._UniqueItemId = (value ? new ulong?(this.UniqueItemId) : null);
				}
			}
		}

		private bool ShouldSerializeUniqueItemId()
		{
			return this.UniqueItemIdSpecified;
		}

		private void ResetUniqueItemId()
		{
			this.UniqueItemIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ProtectType", DataFormat = DataFormat.TwosComplement)]
		public uint ProtectType
		{
			get
			{
				return this._ProtectType ?? 0U;
			}
			set
			{
				this._ProtectType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ProtectTypeSpecified
		{
			get
			{
				return this._ProtectType != null;
			}
			set
			{
				bool flag = value == (this._ProtectType == null);
				if (flag)
				{
					this._ProtectType = (value ? new uint?(this.ProtectType) : null);
				}
			}
		}

		private bool ShouldSerializeProtectType()
		{
			return this.ProtectTypeSpecified;
		}

		private void ResetProtectType()
		{
			this.ProtectTypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _UniqueItemId;

		private uint? _ProtectType;

		private IExtension extensionObject;
	}
}
