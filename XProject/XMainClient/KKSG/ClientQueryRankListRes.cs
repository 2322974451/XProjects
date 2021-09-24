using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ClientQueryRankListRes")]
	[Serializable]
	public class ClientQueryRankListRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "RankType", DataFormat = DataFormat.TwosComplement)]
		public uint RankType
		{
			get
			{
				return this._RankType ?? 0U;
			}
			set
			{
				this._RankType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RankTypeSpecified
		{
			get
			{
				return this._RankType != null;
			}
			set
			{
				bool flag = value == (this._RankType == null);
				if (flag)
				{
					this._RankType = (value ? new uint?(this.RankType) : null);
				}
			}
		}

		private bool ShouldSerializeRankType()
		{
			return this.RankTypeSpecified;
		}

		private void ResetRankType()
		{
			this.RankTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp ?? 0U;
			}
			set
			{
				this._TimeStamp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TimeStampSpecified
		{
			get
			{
				return this._TimeStamp != null;
			}
			set
			{
				bool flag = value == (this._TimeStamp == null);
				if (flag)
				{
					this._TimeStamp = (value ? new uint?(this.TimeStamp) : null);
				}
			}
		}

		private bool ShouldSerializeTimeStamp()
		{
			return this.TimeStampSpecified;
		}

		private void ResetTimeStamp()
		{
			this.TimeStampSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "RankList", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RankList RankList
		{
			get
			{
				return this._RankList;
			}
			set
			{
				this._RankList = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "RoleRankData", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RankData RoleRankData
		{
			get
			{
				return this._RoleRankData;
			}
			set
			{
				this._RoleRankData = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "RankAllCount", DataFormat = DataFormat.TwosComplement)]
		public uint RankAllCount
		{
			get
			{
				return this._RankAllCount ?? 0U;
			}
			set
			{
				this._RankAllCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool RankAllCountSpecified
		{
			get
			{
				return this._RankAllCount != null;
			}
			set
			{
				bool flag = value == (this._RankAllCount == null);
				if (flag)
				{
					this._RankAllCount = (value ? new uint?(this.RankAllCount) : null);
				}
			}
		}

		private bool ShouldSerializeRankAllCount()
		{
			return this.RankAllCountSpecified;
		}

		private void ResetRankAllCount()
		{
			this.RankAllCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _RankType;

		private uint? _TimeStamp;

		private RankList _RankList = null;

		private ErrorCode? _ErrorCode;

		private RankData _RoleRankData = null;

		private uint? _RankAllCount;

		private IExtension extensionObject;
	}
}
