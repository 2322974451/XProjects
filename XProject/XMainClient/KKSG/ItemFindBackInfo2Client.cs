using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemFindBackInfo2Client")]
	[Serializable]
	public class ItemFindBackInfo2Client : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ItemFindBackType id
		{
			get
			{
				return this._id ?? ItemFindBackType.TOWER;
			}
			set
			{
				this._id = new ItemFindBackType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ItemFindBackType?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "findBackCount", DataFormat = DataFormat.TwosComplement)]
		public int findBackCount
		{
			get
			{
				return this._findBackCount ?? 0;
			}
			set
			{
				this._findBackCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool findBackCountSpecified
		{
			get
			{
				return this._findBackCount != null;
			}
			set
			{
				bool flag = value == (this._findBackCount == null);
				if (flag)
				{
					this._findBackCount = (value ? new int?(this.findBackCount) : null);
				}
			}
		}

		private bool ShouldSerializefindBackCount()
		{
			return this.findBackCountSpecified;
		}

		private void ResetfindBackCount()
		{
			this.findBackCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "dragonCoinCost", DataFormat = DataFormat.TwosComplement)]
		public int dragonCoinCost
		{
			get
			{
				return this._dragonCoinCost ?? 0;
			}
			set
			{
				this._dragonCoinCost = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonCoinCostSpecified
		{
			get
			{
				return this._dragonCoinCost != null;
			}
			set
			{
				bool flag = value == (this._dragonCoinCost == null);
				if (flag)
				{
					this._dragonCoinCost = (value ? new int?(this.dragonCoinCost) : null);
				}
			}
		}

		private bool ShouldSerializedragonCoinCost()
		{
			return this.dragonCoinCostSpecified;
		}

		private void ResetdragonCoinCost()
		{
			this.dragonCoinCostSpecified = false;
		}

		[ProtoMember(4, Name = "dragonCoinFindBackItems", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dragonCoinFindBackItems
		{
			get
			{
				return this._dragonCoinFindBackItems;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "goldCoinCost", DataFormat = DataFormat.TwosComplement)]
		public int goldCoinCost
		{
			get
			{
				return this._goldCoinCost ?? 0;
			}
			set
			{
				this._goldCoinCost = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool goldCoinCostSpecified
		{
			get
			{
				return this._goldCoinCost != null;
			}
			set
			{
				bool flag = value == (this._goldCoinCost == null);
				if (flag)
				{
					this._goldCoinCost = (value ? new int?(this.goldCoinCost) : null);
				}
			}
		}

		private bool ShouldSerializegoldCoinCost()
		{
			return this.goldCoinCostSpecified;
		}

		private void ResetgoldCoinCost()
		{
			this.goldCoinCostSpecified = false;
		}

		[ProtoMember(6, Name = "goldCoinFindBackItems", DataFormat = DataFormat.Default)]
		public List<ItemBrief> goldCoinFindBackItems
		{
			get
			{
				return this._goldCoinFindBackItems;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "dayTime", DataFormat = DataFormat.TwosComplement)]
		public int dayTime
		{
			get
			{
				return this._dayTime ?? 0;
			}
			set
			{
				this._dayTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dayTimeSpecified
		{
			get
			{
				return this._dayTime != null;
			}
			set
			{
				bool flag = value == (this._dayTime == null);
				if (flag)
				{
					this._dayTime = (value ? new int?(this.dayTime) : null);
				}
			}
		}

		private bool ShouldSerializedayTime()
		{
			return this.dayTimeSpecified;
		}

		private void ResetdayTime()
		{
			this.dayTimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "roleLevel", DataFormat = DataFormat.TwosComplement)]
		public int roleLevel
		{
			get
			{
				return this._roleLevel ?? 0;
			}
			set
			{
				this._roleLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleLevelSpecified
		{
			get
			{
				return this._roleLevel != null;
			}
			set
			{
				bool flag = value == (this._roleLevel == null);
				if (flag)
				{
					this._roleLevel = (value ? new int?(this.roleLevel) : null);
				}
			}
		}

		private bool ShouldSerializeroleLevel()
		{
			return this.roleLevelSpecified;
		}

		private void ResetroleLevel()
		{
			this.roleLevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ItemFindBackType? _id;

		private int? _findBackCount;

		private int? _dragonCoinCost;

		private readonly List<ItemBrief> _dragonCoinFindBackItems = new List<ItemBrief>();

		private int? _goldCoinCost;

		private readonly List<ItemBrief> _goldCoinFindBackItems = new List<ItemBrief>();

		private int? _dayTime;

		private int? _roleLevel;

		private IExtension extensionObject;
	}
}
