using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HorseReConnectRes")]
	[Serializable]
	public class HorseReConnectRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HorseRank rank
		{
			get
			{
				return this._rank;
			}
			set
			{
				this._rank = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "selfarrive", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HorseFinal selfarrive
		{
			get
			{
				return this._selfarrive;
			}
			set
			{
				this._selfarrive = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "otherreach", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HorseAnimation otherreach
		{
			get
			{
				return this._otherreach;
			}
			set
			{
				this._otherreach = value;
			}
		}

		[ProtoMember(5, Name = "item", DataFormat = DataFormat.Default)]
		public List<DoodadItemAddNtf> item
		{
			get
			{
				return this._item;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private HorseRank _rank = null;

		private HorseFinal _selfarrive = null;

		private HorseAnimation _otherreach = null;

		private readonly List<DoodadItemAddNtf> _item = new List<DoodadItemAddNtf>();

		private IExtension extensionObject;
	}
}
