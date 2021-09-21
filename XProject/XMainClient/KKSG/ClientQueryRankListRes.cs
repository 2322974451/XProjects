using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000034 RID: 52
	[ProtoContract(Name = "ClientQueryRankListRes")]
	[Serializable]
	public class ClientQueryRankListRes : IExtensible
	{
		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000396 RID: 918 RVA: 0x0000996C File Offset: 0x00007B6C
		// (set) Token: 0x06000397 RID: 919 RVA: 0x00009998 File Offset: 0x00007B98
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

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000398 RID: 920 RVA: 0x000099A8 File Offset: 0x00007BA8
		// (set) Token: 0x06000399 RID: 921 RVA: 0x000099C8 File Offset: 0x00007BC8
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

		// Token: 0x0600039A RID: 922 RVA: 0x00009A0C File Offset: 0x00007C0C
		private bool ShouldSerializeRankType()
		{
			return this.RankTypeSpecified;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00009A24 File Offset: 0x00007C24
		private void ResetRankType()
		{
			this.RankTypeSpecified = false;
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00009A30 File Offset: 0x00007C30
		// (set) Token: 0x0600039D RID: 925 RVA: 0x00009A5C File Offset: 0x00007C5C
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

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00009A6C File Offset: 0x00007C6C
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00009A8C File Offset: 0x00007C8C
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

		// Token: 0x060003A0 RID: 928 RVA: 0x00009AD0 File Offset: 0x00007CD0
		private bool ShouldSerializeTimeStamp()
		{
			return this.TimeStampSpecified;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00009AE8 File Offset: 0x00007CE8
		private void ResetTimeStamp()
		{
			this.TimeStampSpecified = false;
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00009AF4 File Offset: 0x00007CF4
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x00009B0C File Offset: 0x00007D0C
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

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x00009B18 File Offset: 0x00007D18
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x00009B44 File Offset: 0x00007D44
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

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x00009B54 File Offset: 0x00007D54
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x00009B74 File Offset: 0x00007D74
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

		// Token: 0x060003A8 RID: 936 RVA: 0x00009BB8 File Offset: 0x00007DB8
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00009BD0 File Offset: 0x00007DD0
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00009BDC File Offset: 0x00007DDC
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00009BF4 File Offset: 0x00007DF4
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

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00009C00 File Offset: 0x00007E00
		// (set) Token: 0x060003AD RID: 941 RVA: 0x00009C2C File Offset: 0x00007E2C
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

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00009C3C File Offset: 0x00007E3C
		// (set) Token: 0x060003AF RID: 943 RVA: 0x00009C5C File Offset: 0x00007E5C
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

		// Token: 0x060003B0 RID: 944 RVA: 0x00009CA0 File Offset: 0x00007EA0
		private bool ShouldSerializeRankAllCount()
		{
			return this.RankAllCountSpecified;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00009CB8 File Offset: 0x00007EB8
		private void ResetRankAllCount()
		{
			this.RankAllCountSpecified = false;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00009CC4 File Offset: 0x00007EC4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000F2 RID: 242
		private uint? _RankType;

		// Token: 0x040000F3 RID: 243
		private uint? _TimeStamp;

		// Token: 0x040000F4 RID: 244
		private RankList _RankList = null;

		// Token: 0x040000F5 RID: 245
		private ErrorCode? _ErrorCode;

		// Token: 0x040000F6 RID: 246
		private RankData _RoleRankData = null;

		// Token: 0x040000F7 RID: 247
		private uint? _RankAllCount;

		// Token: 0x040000F8 RID: 248
		private IExtension extensionObject;
	}
}
