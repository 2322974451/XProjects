using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryShopItemRes")]
	[Serializable]
	public class QueryShopItemRes : IExtensible
	{

		[ProtoMember(1, Name = "ShopItem", DataFormat = DataFormat.Default)]
		public List<ShopItem> ShopItem
		{
			get
			{
				return this._ShopItem;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "refreshcount", DataFormat = DataFormat.TwosComplement)]
		public uint refreshcount
		{
			get
			{
				return this._refreshcount ?? 0U;
			}
			set
			{
				this._refreshcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool refreshcountSpecified
		{
			get
			{
				return this._refreshcount != null;
			}
			set
			{
				bool flag = value == (this._refreshcount == null);
				if (flag)
				{
					this._refreshcount = (value ? new uint?(this.refreshcount) : null);
				}
			}
		}

		private bool ShouldSerializerefreshcount()
		{
			return this.refreshcountSpecified;
		}

		private void Resetrefreshcount()
		{
			this.refreshcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "cooklevel", DataFormat = DataFormat.TwosComplement)]
		public uint cooklevel
		{
			get
			{
				return this._cooklevel ?? 0U;
			}
			set
			{
				this._cooklevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cooklevelSpecified
		{
			get
			{
				return this._cooklevel != null;
			}
			set
			{
				bool flag = value == (this._cooklevel == null);
				if (flag)
				{
					this._cooklevel = (value ? new uint?(this.cooklevel) : null);
				}
			}
		}

		private bool ShouldSerializecooklevel()
		{
			return this.cooklevelSpecified;
		}

		private void Resetcooklevel()
		{
			this.cooklevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ShopItem> _ShopItem = new List<ShopItem>();

		private ErrorCode? _errorcode;

		private uint? _refreshcount;

		private uint? _cooklevel;

		private IExtension extensionObject;
	}
}
