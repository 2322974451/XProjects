using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "OutLookEquip")]
	[Serializable]
	public class OutLookEquip : IExtensible
	{

		[ProtoMember(1, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		[ProtoMember(2, Name = "enhancelevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> enhancelevel
		{
			get
			{
				return this._enhancelevel;
			}
		}

		[ProtoMember(3, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public List<uint> slot
		{
			get
			{
				return this._slot;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "enhancemaster", DataFormat = DataFormat.TwosComplement)]
		public uint enhancemaster
		{
			get
			{
				return this._enhancemaster ?? 0U;
			}
			set
			{
				this._enhancemaster = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enhancemasterSpecified
		{
			get
			{
				return this._enhancemaster != null;
			}
			set
			{
				bool flag = value == (this._enhancemaster == null);
				if (flag)
				{
					this._enhancemaster = (value ? new uint?(this.enhancemaster) : null);
				}
			}
		}

		private bool ShouldSerializeenhancemaster()
		{
			return this.enhancemasterSpecified;
		}

		private void Resetenhancemaster()
		{
			this.enhancemasterSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<uint> _itemid = new List<uint>();

		private readonly List<uint> _enhancelevel = new List<uint>();

		private readonly List<uint> _slot = new List<uint>();

		private uint? _enhancemaster;

		private IExtension extensionObject;
	}
}
