using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemRandAttr")]
	[Serializable]
	public class ItemRandAttr : IExtensible
	{

		[ProtoMember(1, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		private IExtension extensionObject;
	}
}
