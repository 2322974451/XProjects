using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnchantActiveAttributeArg")]
	[Serializable]
	public class EnchantActiveAttributeArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "attrID", DataFormat = DataFormat.TwosComplement)]
		public uint attrID
		{
			get
			{
				return this._attrID ?? 0U;
			}
			set
			{
				this._attrID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool attrIDSpecified
		{
			get
			{
				return this._attrID != null;
			}
			set
			{
				bool flag = value == (this._attrID == null);
				if (flag)
				{
					this._attrID = (value ? new uint?(this.attrID) : null);
				}
			}
		}

		private bool ShouldSerializeattrID()
		{
			return this.attrIDSpecified;
		}

		private void ResetattrID()
		{
			this.attrIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private uint? _attrID;

		private IExtension extensionObject;
	}
}
