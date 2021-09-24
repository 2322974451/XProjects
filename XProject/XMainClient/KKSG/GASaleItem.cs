using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GASaleItem")]
	[Serializable]
	public class GASaleItem : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "acttype", DataFormat = DataFormat.TwosComplement)]
		public int acttype
		{
			get
			{
				return this._acttype ?? 0;
			}
			set
			{
				this._acttype = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool acttypeSpecified
		{
			get
			{
				return this._acttype != null;
			}
			set
			{
				bool flag = value == (this._acttype == null);
				if (flag)
				{
					this._acttype = (value ? new int?(this.acttype) : null);
				}
			}
		}

		private bool ShouldSerializeacttype()
		{
			return this.acttypeSpecified;
		}

		private void Resetacttype()
		{
			this.acttypeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "auctroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong auctroleid
		{
			get
			{
				return this._auctroleid ?? 0UL;
			}
			set
			{
				this._auctroleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool auctroleidSpecified
		{
			get
			{
				return this._auctroleid != null;
			}
			set
			{
				bool flag = value == (this._auctroleid == null);
				if (flag)
				{
					this._auctroleid = (value ? new ulong?(this.auctroleid) : null);
				}
			}
		}

		private bool ShouldSerializeauctroleid()
		{
			return this.auctroleidSpecified;
		}

		private void Resetauctroleid()
		{
			this.auctroleidSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "curauctprice", DataFormat = DataFormat.TwosComplement)]
		public uint curauctprice
		{
			get
			{
				return this._curauctprice ?? 0U;
			}
			set
			{
				this._curauctprice = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curauctpriceSpecified
		{
			get
			{
				return this._curauctprice != null;
			}
			set
			{
				bool flag = value == (this._curauctprice == null);
				if (flag)
				{
					this._curauctprice = (value ? new uint?(this.curauctprice) : null);
				}
			}
		}

		private bool ShouldSerializecurauctprice()
		{
			return this.curauctpriceSpecified;
		}

		private void Resetcurauctprice()
		{
			this.curauctpriceSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "maxprice", DataFormat = DataFormat.TwosComplement)]
		public uint maxprice
		{
			get
			{
				return this._maxprice ?? 0U;
			}
			set
			{
				this._maxprice = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxpriceSpecified
		{
			get
			{
				return this._maxprice != null;
			}
			set
			{
				bool flag = value == (this._maxprice == null);
				if (flag)
				{
					this._maxprice = (value ? new uint?(this.maxprice) : null);
				}
			}
		}

		private bool ShouldSerializemaxprice()
		{
			return this.maxpriceSpecified;
		}

		private void Resetmaxprice()
		{
			this.maxpriceSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "display", DataFormat = DataFormat.Default)]
		public bool display
		{
			get
			{
				return this._display ?? false;
			}
			set
			{
				this._display = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool displaySpecified
		{
			get
			{
				return this._display != null;
			}
			set
			{
				bool flag = value == (this._display == null);
				if (flag)
				{
					this._display = (value ? new bool?(this.display) : null);
				}
			}
		}

		private bool ShouldSerializedisplay()
		{
			return this.displaySpecified;
		}

		private void Resetdisplay()
		{
			this.displaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private int? _acttype;

		private uint? _itemid;

		private ulong? _auctroleid;

		private uint? _curauctprice;

		private uint? _maxprice;

		private uint? _lefttime;

		private bool? _display;

		private IExtension extensionObject;
	}
}
