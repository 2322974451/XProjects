using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DrawLotteryRes")]
	[Serializable]
	public class DrawLotteryRes : IExtensible
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

		[ProtoMember(2, Name = "Items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> Items
		{
			get
			{
				return this._Items;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "nextgoodcount", DataFormat = DataFormat.TwosComplement)]
		public uint nextgoodcount
		{
			get
			{
				return this._nextgoodcount ?? 0U;
			}
			set
			{
				this._nextgoodcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nextgoodcountSpecified
		{
			get
			{
				return this._nextgoodcount != null;
			}
			set
			{
				bool flag = value == (this._nextgoodcount == null);
				if (flag)
				{
					this._nextgoodcount = (value ? new uint?(this.nextgoodcount) : null);
				}
			}
		}

		private bool ShouldSerializenextgoodcount()
		{
			return this.nextgoodcountSpecified;
		}

		private void Resetnextgoodcount()
		{
			this.nextgoodcountSpecified = false;
		}

		[ProtoMember(4, Name = "spriteppt", DataFormat = DataFormat.TwosComplement)]
		public List<uint> spriteppt
		{
			get
			{
				return this._spriteppt;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<ItemBrief> _Items = new List<ItemBrief>();

		private uint? _nextgoodcount;

		private readonly List<uint> _spriteppt = new List<uint>();

		private IExtension extensionObject;
	}
}
