using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetActivityChestRes")]
	[Serializable]
	public class GetActivityChestRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ChestGetInfo", DataFormat = DataFormat.TwosComplement)]
		public uint ChestGetInfo
		{
			get
			{
				return this._ChestGetInfo ?? 0U;
			}
			set
			{
				this._ChestGetInfo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ChestGetInfoSpecified
		{
			get
			{
				return this._ChestGetInfo != null;
			}
			set
			{
				bool flag = value == (this._ChestGetInfo == null);
				if (flag)
				{
					this._ChestGetInfo = (value ? new uint?(this.ChestGetInfo) : null);
				}
			}
		}

		private bool ShouldSerializeChestGetInfo()
		{
			return this.ChestGetInfoSpecified;
		}

		private void ResetChestGetInfo()
		{
			this.ChestGetInfoSpecified = false;
		}

		[ProtoMember(3, Name = "ItemId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ItemId
		{
			get
			{
				return this._ItemId;
			}
		}

		[ProtoMember(4, Name = "ItemCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ItemCount
		{
			get
			{
				return this._ItemCount;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ErrorCode;

		private uint? _ChestGetInfo;

		private readonly List<uint> _ItemId = new List<uint>();

		private readonly List<uint> _ItemCount = new List<uint>();

		private IExtension extensionObject;
	}
}
