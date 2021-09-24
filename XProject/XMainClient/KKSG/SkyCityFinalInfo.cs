using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityFinalInfo")]
	[Serializable]
	public class SkyCityFinalInfo : IExtensible
	{

		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<SkyCityFinalBaseInfo> info
		{
			get
			{
				return this._info;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public uint floor
		{
			get
			{
				return this._floor ?? 0U;
			}
			set
			{
				this._floor = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new uint?(this.floor) : null);
				}
			}
		}

		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		[ProtoMember(3, Name = "item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> item
		{
			get
			{
				return this._item;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<SkyCityFinalBaseInfo> _info = new List<SkyCityFinalBaseInfo>();

		private uint? _floor;

		private readonly List<ItemBrief> _item = new List<ItemBrief>();

		private bool? _ismvp;

		private IExtension extensionObject;
	}
}
