using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D7 RID: 215
	[ProtoContract(Name = "TeamInvite")]
	[Serializable]
	public class TeamInvite : IExtensible
	{
		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000DBF RID: 3519 RVA: 0x0001CA0C File Offset: 0x0001AC0C
		// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x0001CA38 File Offset: 0x0001AC38
		[ProtoMember(1, IsRequired = false, Name = "inviteID", DataFormat = DataFormat.TwosComplement)]
		public uint inviteID
		{
			get
			{
				return this._inviteID ?? 0U;
			}
			set
			{
				this._inviteID = new uint?(value);
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x0001CA48 File Offset: 0x0001AC48
		// (set) Token: 0x06000DC2 RID: 3522 RVA: 0x0001CA68 File Offset: 0x0001AC68
		[XmlIgnore]
		[Browsable(false)]
		public bool inviteIDSpecified
		{
			get
			{
				return this._inviteID != null;
			}
			set
			{
				bool flag = value == (this._inviteID == null);
				if (flag)
				{
					this._inviteID = (value ? new uint?(this.inviteID) : null);
				}
			}
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x0001CAAC File Offset: 0x0001ACAC
		private bool ShouldSerializeinviteID()
		{
			return this.inviteIDSpecified;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x0001CAC4 File Offset: 0x0001ACC4
		private void ResetinviteID()
		{
			this.inviteIDSpecified = false;
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x0001CAD0 File Offset: 0x0001ACD0
		// (set) Token: 0x06000DC6 RID: 3526 RVA: 0x0001CAFC File Offset: 0x0001ACFC
		[ProtoMember(2, IsRequired = false, Name = "invTime", DataFormat = DataFormat.TwosComplement)]
		public uint invTime
		{
			get
			{
				return this._invTime ?? 0U;
			}
			set
			{
				this._invTime = new uint?(value);
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x0001CB0C File Offset: 0x0001AD0C
		// (set) Token: 0x06000DC8 RID: 3528 RVA: 0x0001CB2C File Offset: 0x0001AD2C
		[XmlIgnore]
		[Browsable(false)]
		public bool invTimeSpecified
		{
			get
			{
				return this._invTime != null;
			}
			set
			{
				bool flag = value == (this._invTime == null);
				if (flag)
				{
					this._invTime = (value ? new uint?(this.invTime) : null);
				}
			}
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x0001CB70 File Offset: 0x0001AD70
		private bool ShouldSerializeinvTime()
		{
			return this.invTimeSpecified;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x0001CB88 File Offset: 0x0001AD88
		private void ResetinvTime()
		{
			this.invTimeSpecified = false;
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000DCB RID: 3531 RVA: 0x0001CB94 File Offset: 0x0001AD94
		// (set) Token: 0x06000DCC RID: 3532 RVA: 0x0001CBC1 File Offset: 0x0001ADC1
		[ProtoMember(3, IsRequired = false, Name = "invguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong invguildid
		{
			get
			{
				return this._invguildid ?? 0UL;
			}
			set
			{
				this._invguildid = new ulong?(value);
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x0001CBD0 File Offset: 0x0001ADD0
		// (set) Token: 0x06000DCE RID: 3534 RVA: 0x0001CBF0 File Offset: 0x0001ADF0
		[XmlIgnore]
		[Browsable(false)]
		public bool invguildidSpecified
		{
			get
			{
				return this._invguildid != null;
			}
			set
			{
				bool flag = value == (this._invguildid == null);
				if (flag)
				{
					this._invguildid = (value ? new ulong?(this.invguildid) : null);
				}
			}
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x0001CC34 File Offset: 0x0001AE34
		private bool ShouldSerializeinvguildid()
		{
			return this.invguildidSpecified;
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x0001CC4C File Offset: 0x0001AE4C
		private void Resetinvguildid()
		{
			this.invguildidSpecified = false;
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x0001CC58 File Offset: 0x0001AE58
		// (set) Token: 0x06000DD2 RID: 3538 RVA: 0x0001CC85 File Offset: 0x0001AE85
		[ProtoMember(4, IsRequired = false, Name = "invdragonguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong invdragonguildid
		{
			get
			{
				return this._invdragonguildid ?? 0UL;
			}
			set
			{
				this._invdragonguildid = new ulong?(value);
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x0001CC94 File Offset: 0x0001AE94
		// (set) Token: 0x06000DD4 RID: 3540 RVA: 0x0001CCB4 File Offset: 0x0001AEB4
		[XmlIgnore]
		[Browsable(false)]
		public bool invdragonguildidSpecified
		{
			get
			{
				return this._invdragonguildid != null;
			}
			set
			{
				bool flag = value == (this._invdragonguildid == null);
				if (flag)
				{
					this._invdragonguildid = (value ? new ulong?(this.invdragonguildid) : null);
				}
			}
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x0001CCF8 File Offset: 0x0001AEF8
		private bool ShouldSerializeinvdragonguildid()
		{
			return this.invdragonguildidSpecified;
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x0001CD10 File Offset: 0x0001AF10
		private void Resetinvdragonguildid()
		{
			this.invdragonguildidSpecified = false;
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x0001CD1C File Offset: 0x0001AF1C
		// (set) Token: 0x06000DD8 RID: 3544 RVA: 0x0001CD49 File Offset: 0x0001AF49
		[ProtoMember(5, IsRequired = false, Name = "invfromroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong invfromroleid
		{
			get
			{
				return this._invfromroleid ?? 0UL;
			}
			set
			{
				this._invfromroleid = new ulong?(value);
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x0001CD58 File Offset: 0x0001AF58
		// (set) Token: 0x06000DDA RID: 3546 RVA: 0x0001CD78 File Offset: 0x0001AF78
		[XmlIgnore]
		[Browsable(false)]
		public bool invfromroleidSpecified
		{
			get
			{
				return this._invfromroleid != null;
			}
			set
			{
				bool flag = value == (this._invfromroleid == null);
				if (flag)
				{
					this._invfromroleid = (value ? new ulong?(this.invfromroleid) : null);
				}
			}
		}

		// Token: 0x06000DDB RID: 3547 RVA: 0x0001CDBC File Offset: 0x0001AFBC
		private bool ShouldSerializeinvfromroleid()
		{
			return this.invfromroleidSpecified;
		}

		// Token: 0x06000DDC RID: 3548 RVA: 0x0001CDD4 File Offset: 0x0001AFD4
		private void Resetinvfromroleid()
		{
			this.invfromroleidSpecified = false;
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000DDD RID: 3549 RVA: 0x0001CDE0 File Offset: 0x0001AFE0
		// (set) Token: 0x06000DDE RID: 3550 RVA: 0x0001CE0D File Offset: 0x0001B00D
		[ProtoMember(6, IsRequired = false, Name = "invtoroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong invtoroleid
		{
			get
			{
				return this._invtoroleid ?? 0UL;
			}
			set
			{
				this._invtoroleid = new ulong?(value);
			}
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06000DDF RID: 3551 RVA: 0x0001CE1C File Offset: 0x0001B01C
		// (set) Token: 0x06000DE0 RID: 3552 RVA: 0x0001CE3C File Offset: 0x0001B03C
		[XmlIgnore]
		[Browsable(false)]
		public bool invtoroleidSpecified
		{
			get
			{
				return this._invtoroleid != null;
			}
			set
			{
				bool flag = value == (this._invtoroleid == null);
				if (flag)
				{
					this._invtoroleid = (value ? new ulong?(this.invtoroleid) : null);
				}
			}
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x0001CE80 File Offset: 0x0001B080
		private bool ShouldSerializeinvtoroleid()
		{
			return this.invtoroleidSpecified;
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x0001CE98 File Offset: 0x0001B098
		private void Resetinvtoroleid()
		{
			this.invtoroleidSpecified = false;
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x0001CEA4 File Offset: 0x0001B0A4
		// (set) Token: 0x06000DE4 RID: 3556 RVA: 0x0001CEC5 File Offset: 0x0001B0C5
		[ProtoMember(7, IsRequired = false, Name = "invfromrolename", DataFormat = DataFormat.Default)]
		public string invfromrolename
		{
			get
			{
				return this._invfromrolename ?? "";
			}
			set
			{
				this._invfromrolename = value;
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x0001CED0 File Offset: 0x0001B0D0
		// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x0001CEEC File Offset: 0x0001B0EC
		[XmlIgnore]
		[Browsable(false)]
		public bool invfromrolenameSpecified
		{
			get
			{
				return this._invfromrolename != null;
			}
			set
			{
				bool flag = value == (this._invfromrolename == null);
				if (flag)
				{
					this._invfromrolename = (value ? this.invfromrolename : null);
				}
			}
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x0001CF1C File Offset: 0x0001B11C
		private bool ShouldSerializeinvfromrolename()
		{
			return this.invfromrolenameSpecified;
		}

		// Token: 0x06000DE8 RID: 3560 RVA: 0x0001CF34 File Offset: 0x0001B134
		private void Resetinvfromrolename()
		{
			this.invfromrolenameSpecified = false;
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x0001CF40 File Offset: 0x0001B140
		// (set) Token: 0x06000DEA RID: 3562 RVA: 0x0001CF58 File Offset: 0x0001B158
		[ProtoMember(8, IsRequired = false, Name = "teambrief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamBrief teambrief
		{
			get
			{
				return this._teambrief;
			}
			set
			{
				this._teambrief = value;
			}
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x0001CF64 File Offset: 0x0001B164
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000377 RID: 887
		private uint? _inviteID;

		// Token: 0x04000378 RID: 888
		private uint? _invTime;

		// Token: 0x04000379 RID: 889
		private ulong? _invguildid;

		// Token: 0x0400037A RID: 890
		private ulong? _invdragonguildid;

		// Token: 0x0400037B RID: 891
		private ulong? _invfromroleid;

		// Token: 0x0400037C RID: 892
		private ulong? _invtoroleid;

		// Token: 0x0400037D RID: 893
		private string _invfromrolename;

		// Token: 0x0400037E RID: 894
		private TeamBrief _teambrief = null;

		// Token: 0x0400037F RID: 895
		private IExtension extensionObject;
	}
}
