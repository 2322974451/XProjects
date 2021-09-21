using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000613 RID: 1555
	[ProtoContract(Name = "LoginRecord")]
	[Serializable]
	public class LoginRecord : IExtensible
	{
		// Token: 0x17001D85 RID: 7557
		// (get) Token: 0x06005E1B RID: 24091 RVA: 0x000B3620 File Offset: 0x000B1820
		// (set) Token: 0x06005E1C RID: 24092 RVA: 0x000B364C File Offset: 0x000B184C
		[ProtoMember(1, IsRequired = false, Name = "loginDayCount", DataFormat = DataFormat.TwosComplement)]
		public uint loginDayCount
		{
			get
			{
				return this._loginDayCount ?? 0U;
			}
			set
			{
				this._loginDayCount = new uint?(value);
			}
		}

		// Token: 0x17001D86 RID: 7558
		// (get) Token: 0x06005E1D RID: 24093 RVA: 0x000B365C File Offset: 0x000B185C
		// (set) Token: 0x06005E1E RID: 24094 RVA: 0x000B367C File Offset: 0x000B187C
		[XmlIgnore]
		[Browsable(false)]
		public bool loginDayCountSpecified
		{
			get
			{
				return this._loginDayCount != null;
			}
			set
			{
				bool flag = value == (this._loginDayCount == null);
				if (flag)
				{
					this._loginDayCount = (value ? new uint?(this.loginDayCount) : null);
				}
			}
		}

		// Token: 0x06005E1F RID: 24095 RVA: 0x000B36C0 File Offset: 0x000B18C0
		private bool ShouldSerializeloginDayCount()
		{
			return this.loginDayCountSpecified;
		}

		// Token: 0x06005E20 RID: 24096 RVA: 0x000B36D8 File Offset: 0x000B18D8
		private void ResetloginDayCount()
		{
			this.loginDayCountSpecified = false;
		}

		// Token: 0x17001D87 RID: 7559
		// (get) Token: 0x06005E21 RID: 24097 RVA: 0x000B36E4 File Offset: 0x000B18E4
		// (set) Token: 0x06005E22 RID: 24098 RVA: 0x000B3710 File Offset: 0x000B1910
		[ProtoMember(2, IsRequired = false, Name = "logindayforloginreward", DataFormat = DataFormat.TwosComplement)]
		public uint logindayforloginreward
		{
			get
			{
				return this._logindayforloginreward ?? 0U;
			}
			set
			{
				this._logindayforloginreward = new uint?(value);
			}
		}

		// Token: 0x17001D88 RID: 7560
		// (get) Token: 0x06005E23 RID: 24099 RVA: 0x000B3720 File Offset: 0x000B1920
		// (set) Token: 0x06005E24 RID: 24100 RVA: 0x000B3740 File Offset: 0x000B1940
		[XmlIgnore]
		[Browsable(false)]
		public bool logindayforloginrewardSpecified
		{
			get
			{
				return this._logindayforloginreward != null;
			}
			set
			{
				bool flag = value == (this._logindayforloginreward == null);
				if (flag)
				{
					this._logindayforloginreward = (value ? new uint?(this.logindayforloginreward) : null);
				}
			}
		}

		// Token: 0x06005E25 RID: 24101 RVA: 0x000B3784 File Offset: 0x000B1984
		private bool ShouldSerializelogindayforloginreward()
		{
			return this.logindayforloginrewardSpecified;
		}

		// Token: 0x06005E26 RID: 24102 RVA: 0x000B379C File Offset: 0x000B199C
		private void Resetlogindayforloginreward()
		{
			this.logindayforloginrewardSpecified = false;
		}

		// Token: 0x17001D89 RID: 7561
		// (get) Token: 0x06005E27 RID: 24103 RVA: 0x000B37A8 File Offset: 0x000B19A8
		// (set) Token: 0x06005E28 RID: 24104 RVA: 0x000B37D4 File Offset: 0x000B19D4
		[ProtoMember(3, IsRequired = false, Name = "lastUpdateDay", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateDay
		{
			get
			{
				return this._lastUpdateDay ?? 0U;
			}
			set
			{
				this._lastUpdateDay = new uint?(value);
			}
		}

		// Token: 0x17001D8A RID: 7562
		// (get) Token: 0x06005E29 RID: 24105 RVA: 0x000B37E4 File Offset: 0x000B19E4
		// (set) Token: 0x06005E2A RID: 24106 RVA: 0x000B3804 File Offset: 0x000B1A04
		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateDaySpecified
		{
			get
			{
				return this._lastUpdateDay != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateDay == null);
				if (flag)
				{
					this._lastUpdateDay = (value ? new uint?(this.lastUpdateDay) : null);
				}
			}
		}

		// Token: 0x06005E2B RID: 24107 RVA: 0x000B3848 File Offset: 0x000B1A48
		private bool ShouldSerializelastUpdateDay()
		{
			return this.lastUpdateDaySpecified;
		}

		// Token: 0x06005E2C RID: 24108 RVA: 0x000B3860 File Offset: 0x000B1A60
		private void ResetlastUpdateDay()
		{
			this.lastUpdateDaySpecified = false;
		}

		// Token: 0x17001D8B RID: 7563
		// (get) Token: 0x06005E2D RID: 24109 RVA: 0x000B386C File Offset: 0x000B1A6C
		// (set) Token: 0x06005E2E RID: 24110 RVA: 0x000B3898 File Offset: 0x000B1A98
		[ProtoMember(4, IsRequired = false, Name = "lrostate", DataFormat = DataFormat.TwosComplement)]
		public int lrostate
		{
			get
			{
				return this._lrostate ?? 0;
			}
			set
			{
				this._lrostate = new int?(value);
			}
		}

		// Token: 0x17001D8C RID: 7564
		// (get) Token: 0x06005E2F RID: 24111 RVA: 0x000B38A8 File Offset: 0x000B1AA8
		// (set) Token: 0x06005E30 RID: 24112 RVA: 0x000B38C8 File Offset: 0x000B1AC8
		[XmlIgnore]
		[Browsable(false)]
		public bool lrostateSpecified
		{
			get
			{
				return this._lrostate != null;
			}
			set
			{
				bool flag = value == (this._lrostate == null);
				if (flag)
				{
					this._lrostate = (value ? new int?(this.lrostate) : null);
				}
			}
		}

		// Token: 0x06005E31 RID: 24113 RVA: 0x000B390C File Offset: 0x000B1B0C
		private bool ShouldSerializelrostate()
		{
			return this.lrostateSpecified;
		}

		// Token: 0x06005E32 RID: 24114 RVA: 0x000B3924 File Offset: 0x000B1B24
		private void Resetlrostate()
		{
			this.lrostateSpecified = false;
		}

		// Token: 0x17001D8D RID: 7565
		// (get) Token: 0x06005E33 RID: 24115 RVA: 0x000B3930 File Offset: 0x000B1B30
		[ProtoMember(5, Name = "loginRewards", DataFormat = DataFormat.Default)]
		public List<LoginReward> loginRewards
		{
			get
			{
				return this._loginRewards;
			}
		}

		// Token: 0x06005E34 RID: 24116 RVA: 0x000B3948 File Offset: 0x000B1B48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016DB RID: 5851
		private uint? _loginDayCount;

		// Token: 0x040016DC RID: 5852
		private uint? _logindayforloginreward;

		// Token: 0x040016DD RID: 5853
		private uint? _lastUpdateDay;

		// Token: 0x040016DE RID: 5854
		private int? _lrostate;

		// Token: 0x040016DF RID: 5855
		private readonly List<LoginReward> _loginRewards = new List<LoginReward>();

		// Token: 0x040016E0 RID: 5856
		private IExtension extensionObject;
	}
}
