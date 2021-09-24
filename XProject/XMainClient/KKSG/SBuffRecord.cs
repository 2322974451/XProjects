using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SBuffRecord")]
	[Serializable]
	public class SBuffRecord : IExtensible
	{

		[ProtoMember(1, Name = "buffs", DataFormat = DataFormat.Default)]
		public List<Buff> buffs
		{
			get
			{
				return this._buffs;
			}
		}

		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<BuffItem> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "transbuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public STransformBuff transbuff
		{
			get
			{
				return this._transbuff;
			}
			set
			{
				this._transbuff = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "smallbuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public STransformBuff smallbuff
		{
			get
			{
				return this._smallbuff;
			}
			set
			{
				this._smallbuff = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<Buff> _buffs = new List<Buff>();

		private readonly List<BuffItem> _items = new List<BuffItem>();

		private STransformBuff _transbuff = null;

		private STransformBuff _smallbuff = null;

		private IExtension extensionObject;
	}
}
