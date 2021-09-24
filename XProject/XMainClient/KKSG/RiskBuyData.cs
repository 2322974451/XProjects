using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskBuyData")]
	[Serializable]
	public class RiskBuyData : IExtensible
	{

		[ProtoMember(1, Name = "rewardItems", DataFormat = DataFormat.Default)]
		public List<ItemBrief> rewardItems
		{
			get
			{
				return this._rewardItems;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "cost", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief cost
		{
			get
			{
				return this._cost;
			}
			set
			{
				this._cost = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ItemBrief> _rewardItems = new List<ItemBrief>();

		private ItemBrief _cost = null;

		private IExtension extensionObject;
	}
}
