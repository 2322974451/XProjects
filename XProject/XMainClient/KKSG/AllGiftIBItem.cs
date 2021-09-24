using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AllGiftIBItem")]
	[Serializable]
	public class AllGiftIBItem : IExtensible
	{

		[ProtoMember(1, Name = "gift", DataFormat = DataFormat.Default)]
		public List<GiftIbItem> gift
		{
			get
			{
				return this._gift;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GiftIbItem> _gift = new List<GiftIbItem>();

		private IExtension extensionObject;
	}
}
