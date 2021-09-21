using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200023D RID: 573
	[ProtoContract(Name = "ReqGuildLadderInfoRes")]
	[Serializable]
	public class ReqGuildLadderInfoRes : IExtensible
	{
		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x06001FD3 RID: 8147 RVA: 0x0003E610 File Offset: 0x0003C810
		// (set) Token: 0x06001FD4 RID: 8148 RVA: 0x0003E63C File Offset: 0x0003C83C
		[ProtoMember(1, IsRequired = false, Name = "lestRewardTimes", DataFormat = DataFormat.TwosComplement)]
		public uint lestRewardTimes
		{
			get
			{
				return this._lestRewardTimes ?? 0U;
			}
			set
			{
				this._lestRewardTimes = new uint?(value);
			}
		}

		// Token: 0x170009ED RID: 2541
		// (get) Token: 0x06001FD5 RID: 8149 RVA: 0x0003E64C File Offset: 0x0003C84C
		// (set) Token: 0x06001FD6 RID: 8150 RVA: 0x0003E66C File Offset: 0x0003C86C
		[XmlIgnore]
		[Browsable(false)]
		public bool lestRewardTimesSpecified
		{
			get
			{
				return this._lestRewardTimes != null;
			}
			set
			{
				bool flag = value == (this._lestRewardTimes == null);
				if (flag)
				{
					this._lestRewardTimes = (value ? new uint?(this.lestRewardTimes) : null);
				}
			}
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x0003E6B0 File Offset: 0x0003C8B0
		private bool ShouldSerializelestRewardTimes()
		{
			return this.lestRewardTimesSpecified;
		}

		// Token: 0x06001FD8 RID: 8152 RVA: 0x0003E6C8 File Offset: 0x0003C8C8
		private void ResetlestRewardTimes()
		{
			this.lestRewardTimesSpecified = false;
		}

		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x06001FD9 RID: 8153 RVA: 0x0003E6D4 File Offset: 0x0003C8D4
		[ProtoMember(2, Name = "roleRanks", DataFormat = DataFormat.Default)]
		public List<GuildLadderRoleRank> roleRanks
		{
			get
			{
				return this._roleRanks;
			}
		}

		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x06001FDA RID: 8154 RVA: 0x0003E6EC File Offset: 0x0003C8EC
		[ProtoMember(3, Name = "guildRanks", DataFormat = DataFormat.Default)]
		public List<GuildLadderRank> guildRanks
		{
			get
			{
				return this._guildRanks;
			}
		}

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x06001FDB RID: 8155 RVA: 0x0003E704 File Offset: 0x0003C904
		// (set) Token: 0x06001FDC RID: 8156 RVA: 0x0003E730 File Offset: 0x0003C930
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

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x06001FDD RID: 8157 RVA: 0x0003E740 File Offset: 0x0003C940
		// (set) Token: 0x06001FDE RID: 8158 RVA: 0x0003E760 File Offset: 0x0003C960
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

		// Token: 0x06001FDF RID: 8159 RVA: 0x0003E7A4 File Offset: 0x0003C9A4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001FE0 RID: 8160 RVA: 0x0003E7BC File Offset: 0x0003C9BC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x06001FE1 RID: 8161 RVA: 0x0003E7C8 File Offset: 0x0003C9C8
		// (set) Token: 0x06001FE2 RID: 8162 RVA: 0x0003E7F4 File Offset: 0x0003C9F4
		[ProtoMember(5, IsRequired = false, Name = "nowTime", DataFormat = DataFormat.TwosComplement)]
		public uint nowTime
		{
			get
			{
				return this._nowTime ?? 0U;
			}
			set
			{
				this._nowTime = new uint?(value);
			}
		}

		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x06001FE3 RID: 8163 RVA: 0x0003E804 File Offset: 0x0003CA04
		// (set) Token: 0x06001FE4 RID: 8164 RVA: 0x0003E824 File Offset: 0x0003CA24
		[XmlIgnore]
		[Browsable(false)]
		public bool nowTimeSpecified
		{
			get
			{
				return this._nowTime != null;
			}
			set
			{
				bool flag = value == (this._nowTime == null);
				if (flag)
				{
					this._nowTime = (value ? new uint?(this.nowTime) : null);
				}
			}
		}

		// Token: 0x06001FE5 RID: 8165 RVA: 0x0003E868 File Offset: 0x0003CA68
		private bool ShouldSerializenowTime()
		{
			return this.nowTimeSpecified;
		}

		// Token: 0x06001FE6 RID: 8166 RVA: 0x0003E880 File Offset: 0x0003CA80
		private void ResetnowTime()
		{
			this.nowTimeSpecified = false;
		}

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x06001FE7 RID: 8167 RVA: 0x0003E88C File Offset: 0x0003CA8C
		// (set) Token: 0x06001FE8 RID: 8168 RVA: 0x0003E8B8 File Offset: 0x0003CAB8
		[ProtoMember(6, IsRequired = false, Name = "lastTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastTime
		{
			get
			{
				return this._lastTime ?? 0U;
			}
			set
			{
				this._lastTime = new uint?(value);
			}
		}

		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x06001FE9 RID: 8169 RVA: 0x0003E8C8 File Offset: 0x0003CAC8
		// (set) Token: 0x06001FEA RID: 8170 RVA: 0x0003E8E8 File Offset: 0x0003CAE8
		[XmlIgnore]
		[Browsable(false)]
		public bool lastTimeSpecified
		{
			get
			{
				return this._lastTime != null;
			}
			set
			{
				bool flag = value == (this._lastTime == null);
				if (flag)
				{
					this._lastTime = (value ? new uint?(this.lastTime) : null);
				}
			}
		}

		// Token: 0x06001FEB RID: 8171 RVA: 0x0003E92C File Offset: 0x0003CB2C
		private bool ShouldSerializelastTime()
		{
			return this.lastTimeSpecified;
		}

		// Token: 0x06001FEC RID: 8172 RVA: 0x0003E944 File Offset: 0x0003CB44
		private void ResetlastTime()
		{
			this.lastTimeSpecified = false;
		}

		// Token: 0x06001FED RID: 8173 RVA: 0x0003E950 File Offset: 0x0003CB50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007F2 RID: 2034
		private uint? _lestRewardTimes;

		// Token: 0x040007F3 RID: 2035
		private readonly List<GuildLadderRoleRank> _roleRanks = new List<GuildLadderRoleRank>();

		// Token: 0x040007F4 RID: 2036
		private readonly List<GuildLadderRank> _guildRanks = new List<GuildLadderRank>();

		// Token: 0x040007F5 RID: 2037
		private ErrorCode? _errorcode;

		// Token: 0x040007F6 RID: 2038
		private uint? _nowTime;

		// Token: 0x040007F7 RID: 2039
		private uint? _lastTime;

		// Token: 0x040007F8 RID: 2040
		private IExtension extensionObject;
	}
}
