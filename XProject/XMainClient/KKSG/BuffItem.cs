using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuffItem")]
	[Serializable]
	public class BuffItem : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "expiretime", DataFormat = DataFormat.TwosComplement)]
		public uint expiretime
		{
			get
			{
				return this._expiretime ?? 0U;
			}
			set
			{
				this._expiretime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expiretimeSpecified
		{
			get
			{
				return this._expiretime != null;
			}
			set
			{
				bool flag = value == (this._expiretime == null);
				if (flag)
				{
					this._expiretime = (value ? new uint?(this.expiretime) : null);
				}
			}
		}

		private bool ShouldSerializeexpiretime()
		{
			return this.expiretimeSpecified;
		}

		private void Resetexpiretime()
		{
			this.expiretimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _itemid;

		private uint? _itemcount;

		private uint? _expiretime;

		private IExtension extensionObject;
	}
}
