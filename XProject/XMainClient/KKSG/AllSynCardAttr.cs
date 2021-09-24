using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AllSynCardAttr")]
	[Serializable]
	public class AllSynCardAttr : IExtensible
	{

		[ProtoMember(1, Name = "allAttrs", DataFormat = DataFormat.Default)]
		public List<SynCardAttr> allAttrs
		{
			get
			{
				return this._allAttrs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SynCardAttr> _allAttrs = new List<SynCardAttr>();

		private IExtension extensionObject;
	}
}
