using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200060C RID: 1548
	[ProtoContract(Name = "CampTaskInfo2DB")]
	[Serializable]
	public class CampTaskInfo2DB : IExtensible
	{
		// Token: 0x17001D3D RID: 7485
		// (get) Token: 0x06005D45 RID: 23877 RVA: 0x000B1BA0 File Offset: 0x000AFDA0
		// (set) Token: 0x06005D46 RID: 23878 RVA: 0x000B1BCC File Offset: 0x000AFDCC
		[ProtoMember(1, IsRequired = false, Name = "resetTime", DataFormat = DataFormat.TwosComplement)]
		public int resetTime
		{
			get
			{
				return this._resetTime ?? 0;
			}
			set
			{
				this._resetTime = new int?(value);
			}
		}

		// Token: 0x17001D3E RID: 7486
		// (get) Token: 0x06005D47 RID: 23879 RVA: 0x000B1BDC File Offset: 0x000AFDDC
		// (set) Token: 0x06005D48 RID: 23880 RVA: 0x000B1BFC File Offset: 0x000AFDFC
		[XmlIgnore]
		[Browsable(false)]
		public bool resetTimeSpecified
		{
			get
			{
				return this._resetTime != null;
			}
			set
			{
				bool flag = value == (this._resetTime == null);
				if (flag)
				{
					this._resetTime = (value ? new int?(this.resetTime) : null);
				}
			}
		}

		// Token: 0x06005D49 RID: 23881 RVA: 0x000B1C40 File Offset: 0x000AFE40
		private bool ShouldSerializeresetTime()
		{
			return this.resetTimeSpecified;
		}

		// Token: 0x06005D4A RID: 23882 RVA: 0x000B1C58 File Offset: 0x000AFE58
		private void ResetresetTime()
		{
			this.resetTimeSpecified = false;
		}

		// Token: 0x17001D3F RID: 7487
		// (get) Token: 0x06005D4B RID: 23883 RVA: 0x000B1C64 File Offset: 0x000AFE64
		[ProtoMember(2, Name = "infos", DataFormat = DataFormat.Default)]
		public List<CampTaskInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x17001D40 RID: 7488
		// (get) Token: 0x06005D4C RID: 23884 RVA: 0x000B1C7C File Offset: 0x000AFE7C
		// (set) Token: 0x06005D4D RID: 23885 RVA: 0x000B1CA8 File Offset: 0x000AFEA8
		[ProtoMember(3, IsRequired = false, Name = "refreshTimes", DataFormat = DataFormat.TwosComplement)]
		public int refreshTimes
		{
			get
			{
				return this._refreshTimes ?? 0;
			}
			set
			{
				this._refreshTimes = new int?(value);
			}
		}

		// Token: 0x17001D41 RID: 7489
		// (get) Token: 0x06005D4E RID: 23886 RVA: 0x000B1CB8 File Offset: 0x000AFEB8
		// (set) Token: 0x06005D4F RID: 23887 RVA: 0x000B1CD8 File Offset: 0x000AFED8
		[XmlIgnore]
		[Browsable(false)]
		public bool refreshTimesSpecified
		{
			get
			{
				return this._refreshTimes != null;
			}
			set
			{
				bool flag = value == (this._refreshTimes == null);
				if (flag)
				{
					this._refreshTimes = (value ? new int?(this.refreshTimes) : null);
				}
			}
		}

		// Token: 0x06005D50 RID: 23888 RVA: 0x000B1D1C File Offset: 0x000AFF1C
		private bool ShouldSerializerefreshTimes()
		{
			return this.refreshTimesSpecified;
		}

		// Token: 0x06005D51 RID: 23889 RVA: 0x000B1D34 File Offset: 0x000AFF34
		private void ResetrefreshTimes()
		{
			this.refreshTimesSpecified = false;
		}

		// Token: 0x17001D42 RID: 7490
		// (get) Token: 0x06005D52 RID: 23890 RVA: 0x000B1D40 File Offset: 0x000AFF40
		// (set) Token: 0x06005D53 RID: 23891 RVA: 0x000B1D6C File Offset: 0x000AFF6C
		[ProtoMember(4, IsRequired = false, Name = "rewardTimes", DataFormat = DataFormat.TwosComplement)]
		public int rewardTimes
		{
			get
			{
				return this._rewardTimes ?? 0;
			}
			set
			{
				this._rewardTimes = new int?(value);
			}
		}

		// Token: 0x17001D43 RID: 7491
		// (get) Token: 0x06005D54 RID: 23892 RVA: 0x000B1D7C File Offset: 0x000AFF7C
		// (set) Token: 0x06005D55 RID: 23893 RVA: 0x000B1D9C File Offset: 0x000AFF9C
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardTimesSpecified
		{
			get
			{
				return this._rewardTimes != null;
			}
			set
			{
				bool flag = value == (this._rewardTimes == null);
				if (flag)
				{
					this._rewardTimes = (value ? new int?(this.rewardTimes) : null);
				}
			}
		}

		// Token: 0x06005D56 RID: 23894 RVA: 0x000B1DE0 File Offset: 0x000AFFE0
		private bool ShouldSerializerewardTimes()
		{
			return this.rewardTimesSpecified;
		}

		// Token: 0x06005D57 RID: 23895 RVA: 0x000B1DF8 File Offset: 0x000AFFF8
		private void ResetrewardTimes()
		{
			this.rewardTimesSpecified = false;
		}

		// Token: 0x17001D44 RID: 7492
		// (get) Token: 0x06005D58 RID: 23896 RVA: 0x000B1E04 File Offset: 0x000B0004
		// (set) Token: 0x06005D59 RID: 23897 RVA: 0x000B1E30 File Offset: 0x000B0030
		[ProtoMember(5, IsRequired = false, Name = "rewardTime", DataFormat = DataFormat.TwosComplement)]
		public int rewardTime
		{
			get
			{
				return this._rewardTime ?? 0;
			}
			set
			{
				this._rewardTime = new int?(value);
			}
		}

		// Token: 0x17001D45 RID: 7493
		// (get) Token: 0x06005D5A RID: 23898 RVA: 0x000B1E40 File Offset: 0x000B0040
		// (set) Token: 0x06005D5B RID: 23899 RVA: 0x000B1E60 File Offset: 0x000B0060
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardTimeSpecified
		{
			get
			{
				return this._rewardTime != null;
			}
			set
			{
				bool flag = value == (this._rewardTime == null);
				if (flag)
				{
					this._rewardTime = (value ? new int?(this.rewardTime) : null);
				}
			}
		}

		// Token: 0x06005D5C RID: 23900 RVA: 0x000B1EA4 File Offset: 0x000B00A4
		private bool ShouldSerializerewardTime()
		{
			return this.rewardTimeSpecified;
		}

		// Token: 0x06005D5D RID: 23901 RVA: 0x000B1EBC File Offset: 0x000B00BC
		private void ResetrewardTime()
		{
			this.rewardTimeSpecified = false;
		}

		// Token: 0x06005D5E RID: 23902 RVA: 0x000B1EC8 File Offset: 0x000B00C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016AC RID: 5804
		private int? _resetTime;

		// Token: 0x040016AD RID: 5805
		private readonly List<CampTaskInfo> _infos = new List<CampTaskInfo>();

		// Token: 0x040016AE RID: 5806
		private int? _refreshTimes;

		// Token: 0x040016AF RID: 5807
		private int? _rewardTimes;

		// Token: 0x040016B0 RID: 5808
		private int? _rewardTime;

		// Token: 0x040016B1 RID: 5809
		private IExtension extensionObject;
	}
}
