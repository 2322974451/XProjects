using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemForge")]
	[Serializable]
	public class ItemForge : IExtensible
	{

		[ProtoMember(1, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "unReplacedAttr", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AttributeInfo unReplacedAttr
		{
			get
			{
				return this._unReplacedAttr;
			}
			set
			{
				this._unReplacedAttr = value;
			}
		}

		[ProtoMember(3, Name = "haveAttrs", DataFormat = DataFormat.TwosComplement)]
		public List<uint> haveAttrs
		{
			get
			{
				return this._haveAttrs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		private AttributeInfo _unReplacedAttr = null;

		private readonly List<uint> _haveAttrs = new List<uint>();

		private IExtension extensionObject;
	}
}
