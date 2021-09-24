using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemArtifact")]
	[Serializable]
	public class ItemArtifact : IExtensible
	{

		[ProtoMember(1, Name = "unReplacedAttr", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> unReplacedAttr
		{
			get
			{
				return this._unReplacedAttr;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<AttributeInfo> _unReplacedAttr = new List<AttributeInfo>();

		private IExtension extensionObject;
	}
}
