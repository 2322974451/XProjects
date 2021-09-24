using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IBGiftHistAllItem")]
	[Serializable]
	public class IBGiftHistAllItem : IExtensible
	{

		[ProtoMember(1, Name = "allitem", DataFormat = DataFormat.Default)]
		public List<IBGiftHistItem> allitem
		{
			get
			{
				return this._allitem;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<IBGiftHistItem> _allitem = new List<IBGiftHistItem>();

		private IExtension extensionObject;
	}
}
