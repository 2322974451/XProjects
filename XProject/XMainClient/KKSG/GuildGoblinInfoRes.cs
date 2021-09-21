using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000DF RID: 223
	[ProtoContract(Name = "GuildGoblinInfoRes")]
	[Serializable]
	public class GuildGoblinInfoRes : IExtensible
	{
		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000E45 RID: 3653 RVA: 0x0001D9A0 File Offset: 0x0001BBA0
		// (set) Token: 0x06000E46 RID: 3654 RVA: 0x0001D9CC File Offset: 0x0001BBCC
		[ProtoMember(1, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000E47 RID: 3655 RVA: 0x0001D9DC File Offset: 0x0001BBDC
		// (set) Token: 0x06000E48 RID: 3656 RVA: 0x0001D9FC File Offset: 0x0001BBFC
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x0001DA40 File Offset: 0x0001BC40
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x0001DA58 File Offset: 0x0001BC58
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000E4B RID: 3659 RVA: 0x0001DA64 File Offset: 0x0001BC64
		// (set) Token: 0x06000E4C RID: 3660 RVA: 0x0001DA90 File Offset: 0x0001BC90
		[ProtoMember(2, IsRequired = false, Name = "leftEnterCount", DataFormat = DataFormat.TwosComplement)]
		public int leftEnterCount
		{
			get
			{
				return this._leftEnterCount ?? 0;
			}
			set
			{
				this._leftEnterCount = new int?(value);
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000E4D RID: 3661 RVA: 0x0001DAA0 File Offset: 0x0001BCA0
		// (set) Token: 0x06000E4E RID: 3662 RVA: 0x0001DAC0 File Offset: 0x0001BCC0
		[XmlIgnore]
		[Browsable(false)]
		public bool leftEnterCountSpecified
		{
			get
			{
				return this._leftEnterCount != null;
			}
			set
			{
				bool flag = value == (this._leftEnterCount == null);
				if (flag)
				{
					this._leftEnterCount = (value ? new int?(this.leftEnterCount) : null);
				}
			}
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x0001DB04 File Offset: 0x0001BD04
		private bool ShouldSerializeleftEnterCount()
		{
			return this.leftEnterCountSpecified;
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x0001DB1C File Offset: 0x0001BD1C
		private void ResetleftEnterCount()
		{
			this.leftEnterCountSpecified = false;
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x0001DB28 File Offset: 0x0001BD28
		// (set) Token: 0x06000E52 RID: 3666 RVA: 0x0001DB54 File Offset: 0x0001BD54
		[ProtoMember(3, IsRequired = false, Name = "guildTotalKillCount", DataFormat = DataFormat.TwosComplement)]
		public int guildTotalKillCount
		{
			get
			{
				return this._guildTotalKillCount ?? 0;
			}
			set
			{
				this._guildTotalKillCount = new int?(value);
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x0001DB64 File Offset: 0x0001BD64
		// (set) Token: 0x06000E54 RID: 3668 RVA: 0x0001DB84 File Offset: 0x0001BD84
		[XmlIgnore]
		[Browsable(false)]
		public bool guildTotalKillCountSpecified
		{
			get
			{
				return this._guildTotalKillCount != null;
			}
			set
			{
				bool flag = value == (this._guildTotalKillCount == null);
				if (flag)
				{
					this._guildTotalKillCount = (value ? new int?(this.guildTotalKillCount) : null);
				}
			}
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x0001DBC8 File Offset: 0x0001BDC8
		private bool ShouldSerializeguildTotalKillCount()
		{
			return this.guildTotalKillCountSpecified;
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x0001DBE0 File Offset: 0x0001BDE0
		private void ResetguildTotalKillCount()
		{
			this.guildTotalKillCountSpecified = false;
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x0001DBEC File Offset: 0x0001BDEC
		[ProtoMember(4, Name = "memberRankInfo", DataFormat = DataFormat.Default)]
		public List<GuildGoblinRoleKillInfo> memberRankInfo
		{
			get
			{
				return this._memberRankInfo;
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06000E58 RID: 3672 RVA: 0x0001DC04 File Offset: 0x0001BE04
		// (set) Token: 0x06000E59 RID: 3673 RVA: 0x0001DC30 File Offset: 0x0001BE30
		[ProtoMember(5, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06000E5A RID: 3674 RVA: 0x0001DC40 File Offset: 0x0001BE40
		// (set) Token: 0x06000E5B RID: 3675 RVA: 0x0001DC60 File Offset: 0x0001BE60
		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x0001DCA4 File Offset: 0x0001BEA4
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x0001DCBC File Offset: 0x0001BEBC
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x0001DCC8 File Offset: 0x0001BEC8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000397 RID: 919
		private int? _level;

		// Token: 0x04000398 RID: 920
		private int? _leftEnterCount;

		// Token: 0x04000399 RID: 921
		private int? _guildTotalKillCount;

		// Token: 0x0400039A RID: 922
		private readonly List<GuildGoblinRoleKillInfo> _memberRankInfo = new List<GuildGoblinRoleKillInfo>();

		// Token: 0x0400039B RID: 923
		private ErrorCode? _errorCode;

		// Token: 0x0400039C RID: 924
		private IExtension extensionObject;
	}
}
