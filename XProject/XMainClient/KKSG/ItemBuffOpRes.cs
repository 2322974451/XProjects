using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemBuffOpRes")]
	[Serializable]
	public class ItemBuffOpRes : IExtensible
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

		[ProtoMember(2, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		[ProtoMember(3, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemcount
		{
			get
			{
				return this._itemcount;
			}
		}

		[ProtoMember(4, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> buffid
		{
			get
			{
				return this._buffid;
			}
		}

		[ProtoMember(5, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> lefttime
		{
			get
			{
				return this._lefttime;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<uint> _itemid = new List<uint>();

		private readonly List<uint> _itemcount = new List<uint>();

		private readonly List<uint> _buffid = new List<uint>();

		private readonly List<uint> _lefttime = new List<uint>();

		private IExtension extensionObject;
	}
}
