using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemChanged")]
	[Serializable]
	public class ItemChanged : IExtensible
	{

		[ProtoMember(1, Name = "NewItems", DataFormat = DataFormat.Default)]
		public List<Item> NewItems
		{
			get
			{
				return this._NewItems;
			}
		}

		[ProtoMember(2, Name = "AttrChangeItems", DataFormat = DataFormat.Default)]
		public List<Item> AttrChangeItems
		{
			get
			{
				return this._AttrChangeItems;
			}
		}

		[ProtoMember(3, Name = "RemoveItems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> RemoveItems
		{
			get
			{
				return this._RemoveItems;
			}
		}

		[ProtoMember(4, Name = "SwapItems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> SwapItems
		{
			get
			{
				return this._SwapItems;
			}
		}

		[ProtoMember(5, Name = "ChangeItems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> ChangeItems
		{
			get
			{
				return this._ChangeItems;
			}
		}

		[ProtoMember(6, Name = "VirtualItemID", DataFormat = DataFormat.TwosComplement)]
		public List<int> VirtualItemID
		{
			get
			{
				return this._VirtualItemID;
			}
		}

		[ProtoMember(7, Name = "VirtualItemCount", DataFormat = DataFormat.TwosComplement)]
		public List<long> VirtualItemCount
		{
			get
			{
				return this._VirtualItemCount;
			}
		}

		[ProtoMember(8, Name = "recyleadditems", DataFormat = DataFormat.Default)]
		public List<Item> recyleadditems
		{
			get
			{
				return this._recyleadditems;
			}
		}

		[ProtoMember(9, Name = "recylechangeitems", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> recylechangeitems
		{
			get
			{
				return this._recylechangeitems;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "IsRearrange", DataFormat = DataFormat.Default)]
		public bool IsRearrange
		{
			get
			{
				return this._IsRearrange ?? false;
			}
			set
			{
				this._IsRearrange = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IsRearrangeSpecified
		{
			get
			{
				return this._IsRearrange != null;
			}
			set
			{
				bool flag = value == (this._IsRearrange == null);
				if (flag)
				{
					this._IsRearrange = (value ? new bool?(this.IsRearrange) : null);
				}
			}
		}

		private bool ShouldSerializeIsRearrange()
		{
			return this.IsRearrangeSpecified;
		}

		private void ResetIsRearrange()
		{
			this.IsRearrangeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<Item> _NewItems = new List<Item>();

		private readonly List<Item> _AttrChangeItems = new List<Item>();

		private readonly List<ulong> _RemoveItems = new List<ulong>();

		private readonly List<ulong> _SwapItems = new List<ulong>();

		private readonly List<ulong> _ChangeItems = new List<ulong>();

		private readonly List<int> _VirtualItemID = new List<int>();

		private readonly List<long> _VirtualItemCount = new List<long>();

		private readonly List<Item> _recyleadditems = new List<Item>();

		private readonly List<ulong> _recylechangeitems = new List<ulong>();

		private bool? _IsRearrange;

		private IExtension extensionObject;
	}
}
