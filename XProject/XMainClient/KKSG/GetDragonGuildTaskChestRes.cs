using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetDragonGuildTaskChestRes")]
	[Serializable]
	public class GetDragonGuildTaskChestRes : IExtensible
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
		public List<ulong> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		[ProtoMember(3, Name = "itemCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemCount
		{
			get
			{
				return this._itemCount;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "guildexp", DataFormat = DataFormat.TwosComplement)]
		public uint guildexp
		{
			get
			{
				return this._guildexp ?? 0U;
			}
			set
			{
				this._guildexp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildexpSpecified
		{
			get
			{
				return this._guildexp != null;
			}
			set
			{
				bool flag = value == (this._guildexp == null);
				if (flag)
				{
					this._guildexp = (value ? new uint?(this.guildexp) : null);
				}
			}
		}

		private bool ShouldSerializeguildexp()
		{
			return this.guildexpSpecified;
		}

		private void Resetguildexp()
		{
			this.guildexpSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<ulong> _itemid = new List<ulong>();

		private readonly List<uint> _itemCount = new List<uint>();

		private uint? _guildexp;

		private IExtension extensionObject;
	}
}
