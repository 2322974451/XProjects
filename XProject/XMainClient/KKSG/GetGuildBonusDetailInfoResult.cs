using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetGuildBonusDetailInfoResult")]
	[Serializable]
	public class GetGuildBonusDetailInfoResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "bonusInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GuildBonusAppear bonusInfo
		{
			get
			{
				return this._bonusInfo;
			}
			set
			{
				this._bonusInfo = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "content", DataFormat = DataFormat.Default)]
		public string content
		{
			get
			{
				return this._content ?? "";
			}
			set
			{
				this._content = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool contentSpecified
		{
			get
			{
				return this._content != null;
			}
			set
			{
				bool flag = value == (this._content == null);
				if (flag)
				{
					this._content = (value ? this.content : null);
				}
			}
		}

		private bool ShouldSerializecontent()
		{
			return this.contentSpecified;
		}

		private void Resetcontent()
		{
			this.contentSpecified = false;
		}

		[ProtoMember(3, Name = "getBonusRoleList", DataFormat = DataFormat.Default)]
		public List<GetGuildBonusInfo> getBonusRoleList
		{
			get
			{
				return this._getBonusRoleList;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "bonusNum", DataFormat = DataFormat.TwosComplement)]
		public uint bonusNum
		{
			get
			{
				return this._bonusNum ?? 0U;
			}
			set
			{
				this._bonusNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusNumSpecified
		{
			get
			{
				return this._bonusNum != null;
			}
			set
			{
				bool flag = value == (this._bonusNum == null);
				if (flag)
				{
					this._bonusNum = (value ? new uint?(this.bonusNum) : null);
				}
			}
		}

		private bool ShouldSerializebonusNum()
		{
			return this.bonusNumSpecified;
		}

		private void ResetbonusNum()
		{
			this.bonusNumSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "bonusContentType", DataFormat = DataFormat.TwosComplement)]
		public uint bonusContentType
		{
			get
			{
				return this._bonusContentType ?? 0U;
			}
			set
			{
				this._bonusContentType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusContentTypeSpecified
		{
			get
			{
				return this._bonusContentType != null;
			}
			set
			{
				bool flag = value == (this._bonusContentType == null);
				if (flag)
				{
					this._bonusContentType = (value ? new uint?(this.bonusContentType) : null);
				}
			}
		}

		private bool ShouldSerializebonusContentType()
		{
			return this.bonusContentTypeSpecified;
		}

		private void ResetbonusContentType()
		{
			this.bonusContentTypeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "leaderID", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderID
		{
			get
			{
				return this._leaderID ?? 0UL;
			}
			set
			{
				this._leaderID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderIDSpecified
		{
			get
			{
				return this._leaderID != null;
			}
			set
			{
				bool flag = value == (this._leaderID == null);
				if (flag)
				{
					this._leaderID = (value ? new ulong?(this.leaderID) : null);
				}
			}
		}

		private bool ShouldSerializeleaderID()
		{
			return this.leaderIDSpecified;
		}

		private void ResetleaderID()
		{
			this.leaderIDSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "luckestID", DataFormat = DataFormat.TwosComplement)]
		public ulong luckestID
		{
			get
			{
				return this._luckestID ?? 0UL;
			}
			set
			{
				this._luckestID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool luckestIDSpecified
		{
			get
			{
				return this._luckestID != null;
			}
			set
			{
				bool flag = value == (this._luckestID == null);
				if (flag)
				{
					this._luckestID = (value ? new ulong?(this.luckestID) : null);
				}
			}
		}

		private bool ShouldSerializeluckestID()
		{
			return this.luckestIDSpecified;
		}

		private void ResetluckestID()
		{
			this.luckestIDSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "canThank", DataFormat = DataFormat.Default)]
		public bool canThank
		{
			get
			{
				return this._canThank ?? false;
			}
			set
			{
				this._canThank = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canThankSpecified
		{
			get
			{
				return this._canThank != null;
			}
			set
			{
				bool flag = value == (this._canThank == null);
				if (flag)
				{
					this._canThank = (value ? new bool?(this.canThank) : null);
				}
			}
		}

		private bool ShouldSerializecanThank()
		{
			return this.canThankSpecified;
		}

		private void ResetcanThank()
		{
			this.canThankSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GuildBonusAppear _bonusInfo = null;

		private string _content;

		private readonly List<GetGuildBonusInfo> _getBonusRoleList = new List<GetGuildBonusInfo>();

		private ErrorCode? _errorcode;

		private uint? _bonusNum;

		private uint? _bonusContentType;

		private ulong? _leaderID;

		private ulong? _luckestID;

		private bool? _canThank;

		private IExtension extensionObject;
	}
}
