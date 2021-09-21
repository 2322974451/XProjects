using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000124 RID: 292
	[ProtoContract(Name = "LoginRewardRet")]
	[Serializable]
	public class LoginRewardRet : IExtensible
	{
		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06001210 RID: 4624 RVA: 0x00024B90 File Offset: 0x00022D90
		[ProtoMember(1, Name = "rewards", DataFormat = DataFormat.Default)]
		public List<LoginReward> rewards
		{
			get
			{
				return this._rewards;
			}
		}

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06001211 RID: 4625 RVA: 0x00024BA8 File Offset: 0x00022DA8
		// (set) Token: 0x06001212 RID: 4626 RVA: 0x00024BD4 File Offset: 0x00022DD4
		[ProtoMember(2, IsRequired = false, Name = "open", DataFormat = DataFormat.Default)]
		public bool open
		{
			get
			{
				return this._open ?? false;
			}
			set
			{
				this._open = new bool?(value);
			}
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06001213 RID: 4627 RVA: 0x00024BE4 File Offset: 0x00022DE4
		// (set) Token: 0x06001214 RID: 4628 RVA: 0x00024C04 File Offset: 0x00022E04
		[XmlIgnore]
		[Browsable(false)]
		public bool openSpecified
		{
			get
			{
				return this._open != null;
			}
			set
			{
				bool flag = value == (this._open == null);
				if (flag)
				{
					this._open = (value ? new bool?(this.open) : null);
				}
			}
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x00024C48 File Offset: 0x00022E48
		private bool ShouldSerializeopen()
		{
			return this.openSpecified;
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x00024C60 File Offset: 0x00022E60
		private void Resetopen()
		{
			this.openSpecified = false;
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06001217 RID: 4631 RVA: 0x00024C6C File Offset: 0x00022E6C
		// (set) Token: 0x06001218 RID: 4632 RVA: 0x00024C98 File Offset: 0x00022E98
		[ProtoMember(3, IsRequired = false, Name = "logindayforreward", DataFormat = DataFormat.TwosComplement)]
		public uint logindayforreward
		{
			get
			{
				return this._logindayforreward ?? 0U;
			}
			set
			{
				this._logindayforreward = new uint?(value);
			}
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06001219 RID: 4633 RVA: 0x00024CA8 File Offset: 0x00022EA8
		// (set) Token: 0x0600121A RID: 4634 RVA: 0x00024CC8 File Offset: 0x00022EC8
		[XmlIgnore]
		[Browsable(false)]
		public bool logindayforrewardSpecified
		{
			get
			{
				return this._logindayforreward != null;
			}
			set
			{
				bool flag = value == (this._logindayforreward == null);
				if (flag)
				{
					this._logindayforreward = (value ? new uint?(this.logindayforreward) : null);
				}
			}
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x00024D0C File Offset: 0x00022F0C
		private bool ShouldSerializelogindayforreward()
		{
			return this.logindayforrewardSpecified;
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x00024D24 File Offset: 0x00022F24
		private void Resetlogindayforreward()
		{
			this.logindayforrewardSpecified = false;
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x0600121D RID: 4637 RVA: 0x00024D30 File Offset: 0x00022F30
		// (set) Token: 0x0600121E RID: 4638 RVA: 0x00024D5C File Offset: 0x00022F5C
		[ProtoMember(4, IsRequired = false, Name = "sectoday", DataFormat = DataFormat.TwosComplement)]
		public uint sectoday
		{
			get
			{
				return this._sectoday ?? 0U;
			}
			set
			{
				this._sectoday = new uint?(value);
			}
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x0600121F RID: 4639 RVA: 0x00024D6C File Offset: 0x00022F6C
		// (set) Token: 0x06001220 RID: 4640 RVA: 0x00024D8C File Offset: 0x00022F8C
		[XmlIgnore]
		[Browsable(false)]
		public bool sectodaySpecified
		{
			get
			{
				return this._sectoday != null;
			}
			set
			{
				bool flag = value == (this._sectoday == null);
				if (flag)
				{
					this._sectoday = (value ? new uint?(this.sectoday) : null);
				}
			}
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x00024DD0 File Offset: 0x00022FD0
		private bool ShouldSerializesectoday()
		{
			return this.sectodaySpecified;
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x00024DE8 File Offset: 0x00022FE8
		private void Resetsectoday()
		{
			this.sectodaySpecified = false;
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x00024DF4 File Offset: 0x00022FF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000486 RID: 1158
		private readonly List<LoginReward> _rewards = new List<LoginReward>();

		// Token: 0x04000487 RID: 1159
		private bool? _open;

		// Token: 0x04000488 RID: 1160
		private uint? _logindayforreward;

		// Token: 0x04000489 RID: 1161
		private uint? _sectoday;

		// Token: 0x0400048A RID: 1162
		private IExtension extensionObject;
	}
}
