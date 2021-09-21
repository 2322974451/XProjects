using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000BB RID: 187
	[ProtoContract(Name = "GetGuildBonusDetailInfoResult")]
	[Serializable]
	public class GetGuildBonusDetailInfoResult : IExtensible
	{
		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x0001A54C File Offset: 0x0001874C
		// (set) Token: 0x06000C7E RID: 3198 RVA: 0x0001A564 File Offset: 0x00018764
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

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x0001A570 File Offset: 0x00018770
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x0001A591 File Offset: 0x00018791
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

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0001A59C File Offset: 0x0001879C
		// (set) Token: 0x06000C82 RID: 3202 RVA: 0x0001A5B8 File Offset: 0x000187B8
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

		// Token: 0x06000C83 RID: 3203 RVA: 0x0001A5E8 File Offset: 0x000187E8
		private bool ShouldSerializecontent()
		{
			return this.contentSpecified;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0001A600 File Offset: 0x00018800
		private void Resetcontent()
		{
			this.contentSpecified = false;
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x0001A60C File Offset: 0x0001880C
		[ProtoMember(3, Name = "getBonusRoleList", DataFormat = DataFormat.Default)]
		public List<GetGuildBonusInfo> getBonusRoleList
		{
			get
			{
				return this._getBonusRoleList;
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000C86 RID: 3206 RVA: 0x0001A624 File Offset: 0x00018824
		// (set) Token: 0x06000C87 RID: 3207 RVA: 0x0001A650 File Offset: 0x00018850
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

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000C88 RID: 3208 RVA: 0x0001A660 File Offset: 0x00018860
		// (set) Token: 0x06000C89 RID: 3209 RVA: 0x0001A680 File Offset: 0x00018880
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

		// Token: 0x06000C8A RID: 3210 RVA: 0x0001A6C4 File Offset: 0x000188C4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x0001A6DC File Offset: 0x000188DC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000C8C RID: 3212 RVA: 0x0001A6E8 File Offset: 0x000188E8
		// (set) Token: 0x06000C8D RID: 3213 RVA: 0x0001A714 File Offset: 0x00018914
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

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000C8E RID: 3214 RVA: 0x0001A724 File Offset: 0x00018924
		// (set) Token: 0x06000C8F RID: 3215 RVA: 0x0001A744 File Offset: 0x00018944
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

		// Token: 0x06000C90 RID: 3216 RVA: 0x0001A788 File Offset: 0x00018988
		private bool ShouldSerializebonusNum()
		{
			return this.bonusNumSpecified;
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x0001A7A0 File Offset: 0x000189A0
		private void ResetbonusNum()
		{
			this.bonusNumSpecified = false;
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x0001A7AC File Offset: 0x000189AC
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x0001A7D8 File Offset: 0x000189D8
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

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000C94 RID: 3220 RVA: 0x0001A7E8 File Offset: 0x000189E8
		// (set) Token: 0x06000C95 RID: 3221 RVA: 0x0001A808 File Offset: 0x00018A08
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

		// Token: 0x06000C96 RID: 3222 RVA: 0x0001A84C File Offset: 0x00018A4C
		private bool ShouldSerializebonusContentType()
		{
			return this.bonusContentTypeSpecified;
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x0001A864 File Offset: 0x00018A64
		private void ResetbonusContentType()
		{
			this.bonusContentTypeSpecified = false;
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000C98 RID: 3224 RVA: 0x0001A870 File Offset: 0x00018A70
		// (set) Token: 0x06000C99 RID: 3225 RVA: 0x0001A89D File Offset: 0x00018A9D
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

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000C9A RID: 3226 RVA: 0x0001A8AC File Offset: 0x00018AAC
		// (set) Token: 0x06000C9B RID: 3227 RVA: 0x0001A8CC File Offset: 0x00018ACC
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

		// Token: 0x06000C9C RID: 3228 RVA: 0x0001A910 File Offset: 0x00018B10
		private bool ShouldSerializeleaderID()
		{
			return this.leaderIDSpecified;
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x0001A928 File Offset: 0x00018B28
		private void ResetleaderID()
		{
			this.leaderIDSpecified = false;
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000C9E RID: 3230 RVA: 0x0001A934 File Offset: 0x00018B34
		// (set) Token: 0x06000C9F RID: 3231 RVA: 0x0001A961 File Offset: 0x00018B61
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

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x0001A970 File Offset: 0x00018B70
		// (set) Token: 0x06000CA1 RID: 3233 RVA: 0x0001A990 File Offset: 0x00018B90
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

		// Token: 0x06000CA2 RID: 3234 RVA: 0x0001A9D4 File Offset: 0x00018BD4
		private bool ShouldSerializeluckestID()
		{
			return this.luckestIDSpecified;
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x0001A9EC File Offset: 0x00018BEC
		private void ResetluckestID()
		{
			this.luckestIDSpecified = false;
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000CA4 RID: 3236 RVA: 0x0001A9F8 File Offset: 0x00018BF8
		// (set) Token: 0x06000CA5 RID: 3237 RVA: 0x0001AA24 File Offset: 0x00018C24
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

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x0001AA34 File Offset: 0x00018C34
		// (set) Token: 0x06000CA7 RID: 3239 RVA: 0x0001AA54 File Offset: 0x00018C54
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

		// Token: 0x06000CA8 RID: 3240 RVA: 0x0001AA98 File Offset: 0x00018C98
		private bool ShouldSerializecanThank()
		{
			return this.canThankSpecified;
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x0001AAB0 File Offset: 0x00018CB0
		private void ResetcanThank()
		{
			this.canThankSpecified = false;
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x0001AABC File Offset: 0x00018CBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400031D RID: 797
		private GuildBonusAppear _bonusInfo = null;

		// Token: 0x0400031E RID: 798
		private string _content;

		// Token: 0x0400031F RID: 799
		private readonly List<GetGuildBonusInfo> _getBonusRoleList = new List<GetGuildBonusInfo>();

		// Token: 0x04000320 RID: 800
		private ErrorCode? _errorcode;

		// Token: 0x04000321 RID: 801
		private uint? _bonusNum;

		// Token: 0x04000322 RID: 802
		private uint? _bonusContentType;

		// Token: 0x04000323 RID: 803
		private ulong? _leaderID;

		// Token: 0x04000324 RID: 804
		private ulong? _luckestID;

		// Token: 0x04000325 RID: 805
		private bool? _canThank;

		// Token: 0x04000326 RID: 806
		private IExtension extensionObject;
	}
}
