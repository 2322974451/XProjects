using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BattleRewardChest")]
	[Serializable]
	public class BattleRewardChest : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "chestType", DataFormat = DataFormat.TwosComplement)]
		public int chestType
		{
			get
			{
				return this._chestType ?? 0;
			}
			set
			{
				this._chestType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chestTypeSpecified
		{
			get
			{
				return this._chestType != null;
			}
			set
			{
				bool flag = value == (this._chestType == null);
				if (flag)
				{
					this._chestType = (value ? new int?(this.chestType) : null);
				}
			}
		}

		private bool ShouldSerializechestType()
		{
			return this.chestTypeSpecified;
		}

		private void ResetchestType()
		{
			this.chestTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public int itemID
		{
			get
			{
				return this._itemID ?? 0;
			}
			set
			{
				this._itemID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new int?(this.itemID) : null);
				}
			}
		}

		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "itemCount", DataFormat = DataFormat.TwosComplement)]
		public int itemCount
		{
			get
			{
				return this._itemCount ?? 0;
			}
			set
			{
				this._itemCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemCountSpecified
		{
			get
			{
				return this._itemCount != null;
			}
			set
			{
				bool flag = value == (this._itemCount == null);
				if (flag)
				{
					this._itemCount = (value ? new int?(this.itemCount) : null);
				}
			}
		}

		private bool ShouldSerializeitemCount()
		{
			return this.itemCountSpecified;
		}

		private void ResetitemCount()
		{
			this.itemCountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isbind", DataFormat = DataFormat.Default)]
		public bool isbind
		{
			get
			{
				return this._isbind ?? false;
			}
			set
			{
				this._isbind = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isbindSpecified
		{
			get
			{
				return this._isbind != null;
			}
			set
			{
				bool flag = value == (this._isbind == null);
				if (flag)
				{
					this._isbind = (value ? new bool?(this.isbind) : null);
				}
			}
		}

		private bool ShouldSerializeisbind()
		{
			return this.isbindSpecified;
		}

		private void Resetisbind()
		{
			this.isbindSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _chestType;

		private int? _itemID;

		private int? _itemCount;

		private bool? _isbind;

		private IExtension extensionObject;
	}
}
