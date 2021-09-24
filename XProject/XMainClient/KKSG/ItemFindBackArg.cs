using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemFindBackArg")]
	[Serializable]
	public class ItemFindBackArg : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "backType", DataFormat = DataFormat.TwosComplement)]
		public int backType
		{
			get
			{
				return this._backType ?? 0;
			}
			set
			{
				this._backType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool backTypeSpecified
		{
			get
			{
				return this._backType != null;
			}
			set
			{
				bool flag = value == (this._backType == null);
				if (flag)
				{
					this._backType = (value ? new int?(this.backType) : null);
				}
			}
		}

		private bool ShouldSerializebackType()
		{
			return this.backTypeSpecified;
		}

		private void ResetbackType()
		{
			this.backTypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ItemFindBackType? _id;

		private int? _findBackCount;

		private int? _backType;

		private IExtension extensionObject;
	}
}
