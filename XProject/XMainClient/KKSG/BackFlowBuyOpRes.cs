using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BackFlowBuyOpRes")]
	[Serializable]
	public class BackFlowBuyOpRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "countleft", DataFormat = DataFormat.TwosComplement)]
		public int countleft
		{
			get
			{
				return this._countleft ?? 0;
			}
			set
			{
				this._countleft = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countleftSpecified
		{
			get
			{
				return this._countleft != null;
			}
			set
			{
				bool flag = value == (this._countleft == null);
				if (flag)
				{
					this._countleft = (value ? new int?(this.countleft) : null);
				}
			}
		}

		private bool ShouldSerializecountleft()
		{
			return this.countleftSpecified;
		}

		private void Resetcountleft()
		{
			this.countleftSpecified = false;
		}

		[ProtoMember(3, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "countmax", DataFormat = DataFormat.TwosComplement)]
		public int countmax
		{
			get
			{
				return this._countmax ?? 0;
			}
			set
			{
				this._countmax = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countmaxSpecified
		{
			get
			{
				return this._countmax != null;
			}
			set
			{
				bool flag = value == (this._countmax == null);
				if (flag)
				{
					this._countmax = (value ? new int?(this.countmax) : null);
				}
			}
		}

		private bool ShouldSerializecountmax()
		{
			return this.countmaxSpecified;
		}

		private void Resetcountmax()
		{
			this.countmaxSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "cost", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief cost
		{
			get
			{
				return this._cost;
			}
			set
			{
				this._cost = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private int? _countleft;

		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		private int? _countmax;

		private ItemBrief _cost = null;

		private IExtension extensionObject;
	}
}
