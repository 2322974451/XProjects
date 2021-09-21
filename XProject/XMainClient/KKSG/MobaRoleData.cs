using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000719 RID: 1817
	[ProtoContract(Name = "MobaRoleData")]
	[Serializable]
	public class MobaRoleData : IExtensible
	{
		// Token: 0x17002736 RID: 10038
		// (get) Token: 0x06007BB7 RID: 31671 RVA: 0x000EC7CC File Offset: 0x000EA9CC
		// (set) Token: 0x06007BB8 RID: 31672 RVA: 0x000EC7F9 File Offset: 0x000EA9F9
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17002737 RID: 10039
		// (get) Token: 0x06007BB9 RID: 31673 RVA: 0x000EC808 File Offset: 0x000EAA08
		// (set) Token: 0x06007BBA RID: 31674 RVA: 0x000EC828 File Offset: 0x000EAA28
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06007BBB RID: 31675 RVA: 0x000EC86C File Offset: 0x000EAA6C
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06007BBC RID: 31676 RVA: 0x000EC884 File Offset: 0x000EAA84
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17002738 RID: 10040
		// (get) Token: 0x06007BBD RID: 31677 RVA: 0x000EC890 File Offset: 0x000EAA90
		// (set) Token: 0x06007BBE RID: 31678 RVA: 0x000EC8B1 File Offset: 0x000EAAB1
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002739 RID: 10041
		// (get) Token: 0x06007BBF RID: 31679 RVA: 0x000EC8BC File Offset: 0x000EAABC
		// (set) Token: 0x06007BC0 RID: 31680 RVA: 0x000EC8D8 File Offset: 0x000EAAD8
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06007BC1 RID: 31681 RVA: 0x000EC908 File Offset: 0x000EAB08
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007BC2 RID: 31682 RVA: 0x000EC920 File Offset: 0x000EAB20
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700273A RID: 10042
		// (get) Token: 0x06007BC3 RID: 31683 RVA: 0x000EC92C File Offset: 0x000EAB2C
		// (set) Token: 0x06007BC4 RID: 31684 RVA: 0x000EC960 File Offset: 0x000EAB60
		[ProtoMember(3, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public double exp
		{
			get
			{
				return this._exp ?? 0.0;
			}
			set
			{
				this._exp = new double?(value);
			}
		}

		// Token: 0x1700273B RID: 10043
		// (get) Token: 0x06007BC5 RID: 31685 RVA: 0x000EC970 File Offset: 0x000EAB70
		// (set) Token: 0x06007BC6 RID: 31686 RVA: 0x000EC990 File Offset: 0x000EAB90
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new double?(this.exp) : null);
				}
			}
		}

		// Token: 0x06007BC7 RID: 31687 RVA: 0x000EC9D4 File Offset: 0x000EABD4
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x06007BC8 RID: 31688 RVA: 0x000EC9EC File Offset: 0x000EABEC
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x1700273C RID: 10044
		// (get) Token: 0x06007BC9 RID: 31689 RVA: 0x000EC9F8 File Offset: 0x000EABF8
		// (set) Token: 0x06007BCA RID: 31690 RVA: 0x000ECA24 File Offset: 0x000EAC24
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x1700273D RID: 10045
		// (get) Token: 0x06007BCB RID: 31691 RVA: 0x000ECA34 File Offset: 0x000EAC34
		// (set) Token: 0x06007BCC RID: 31692 RVA: 0x000ECA54 File Offset: 0x000EAC54
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
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06007BCD RID: 31693 RVA: 0x000ECA98 File Offset: 0x000EAC98
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007BCE RID: 31694 RVA: 0x000ECAB0 File Offset: 0x000EACB0
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x1700273E RID: 10046
		// (get) Token: 0x06007BCF RID: 31695 RVA: 0x000ECABC File Offset: 0x000EACBC
		// (set) Token: 0x06007BD0 RID: 31696 RVA: 0x000ECAE8 File Offset: 0x000EACE8
		[ProtoMember(5, IsRequired = false, Name = "upgradeNum", DataFormat = DataFormat.TwosComplement)]
		public uint upgradeNum
		{
			get
			{
				return this._upgradeNum ?? 0U;
			}
			set
			{
				this._upgradeNum = new uint?(value);
			}
		}

		// Token: 0x1700273F RID: 10047
		// (get) Token: 0x06007BD1 RID: 31697 RVA: 0x000ECAF8 File Offset: 0x000EACF8
		// (set) Token: 0x06007BD2 RID: 31698 RVA: 0x000ECB18 File Offset: 0x000EAD18
		[XmlIgnore]
		[Browsable(false)]
		public bool upgradeNumSpecified
		{
			get
			{
				return this._upgradeNum != null;
			}
			set
			{
				bool flag = value == (this._upgradeNum == null);
				if (flag)
				{
					this._upgradeNum = (value ? new uint?(this.upgradeNum) : null);
				}
			}
		}

		// Token: 0x06007BD3 RID: 31699 RVA: 0x000ECB5C File Offset: 0x000EAD5C
		private bool ShouldSerializeupgradeNum()
		{
			return this.upgradeNumSpecified;
		}

		// Token: 0x06007BD4 RID: 31700 RVA: 0x000ECB74 File Offset: 0x000EAD74
		private void ResetupgradeNum()
		{
			this.upgradeNumSpecified = false;
		}

		// Token: 0x17002740 RID: 10048
		// (get) Token: 0x06007BD5 RID: 31701 RVA: 0x000ECB80 File Offset: 0x000EAD80
		// (set) Token: 0x06007BD6 RID: 31702 RVA: 0x000ECBAC File Offset: 0x000EADAC
		[ProtoMember(6, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		// Token: 0x17002741 RID: 10049
		// (get) Token: 0x06007BD7 RID: 31703 RVA: 0x000ECBBC File Offset: 0x000EADBC
		// (set) Token: 0x06007BD8 RID: 31704 RVA: 0x000ECBDC File Offset: 0x000EADDC
		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		// Token: 0x06007BD9 RID: 31705 RVA: 0x000ECC20 File Offset: 0x000EAE20
		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		// Token: 0x06007BDA RID: 31706 RVA: 0x000ECC38 File Offset: 0x000EAE38
		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		// Token: 0x17002742 RID: 10050
		// (get) Token: 0x06007BDB RID: 31707 RVA: 0x000ECC44 File Offset: 0x000EAE44
		// (set) Token: 0x06007BDC RID: 31708 RVA: 0x000ECC70 File Offset: 0x000EAE70
		[ProtoMember(7, IsRequired = false, Name = "killNum", DataFormat = DataFormat.TwosComplement)]
		public uint killNum
		{
			get
			{
				return this._killNum ?? 0U;
			}
			set
			{
				this._killNum = new uint?(value);
			}
		}

		// Token: 0x17002743 RID: 10051
		// (get) Token: 0x06007BDD RID: 31709 RVA: 0x000ECC80 File Offset: 0x000EAE80
		// (set) Token: 0x06007BDE RID: 31710 RVA: 0x000ECCA0 File Offset: 0x000EAEA0
		[XmlIgnore]
		[Browsable(false)]
		public bool killNumSpecified
		{
			get
			{
				return this._killNum != null;
			}
			set
			{
				bool flag = value == (this._killNum == null);
				if (flag)
				{
					this._killNum = (value ? new uint?(this.killNum) : null);
				}
			}
		}

		// Token: 0x06007BDF RID: 31711 RVA: 0x000ECCE4 File Offset: 0x000EAEE4
		private bool ShouldSerializekillNum()
		{
			return this.killNumSpecified;
		}

		// Token: 0x06007BE0 RID: 31712 RVA: 0x000ECCFC File Offset: 0x000EAEFC
		private void ResetkillNum()
		{
			this.killNumSpecified = false;
		}

		// Token: 0x17002744 RID: 10052
		// (get) Token: 0x06007BE1 RID: 31713 RVA: 0x000ECD08 File Offset: 0x000EAF08
		// (set) Token: 0x06007BE2 RID: 31714 RVA: 0x000ECD34 File Offset: 0x000EAF34
		[ProtoMember(8, IsRequired = false, Name = "deathNum", DataFormat = DataFormat.TwosComplement)]
		public uint deathNum
		{
			get
			{
				return this._deathNum ?? 0U;
			}
			set
			{
				this._deathNum = new uint?(value);
			}
		}

		// Token: 0x17002745 RID: 10053
		// (get) Token: 0x06007BE3 RID: 31715 RVA: 0x000ECD44 File Offset: 0x000EAF44
		// (set) Token: 0x06007BE4 RID: 31716 RVA: 0x000ECD64 File Offset: 0x000EAF64
		[XmlIgnore]
		[Browsable(false)]
		public bool deathNumSpecified
		{
			get
			{
				return this._deathNum != null;
			}
			set
			{
				bool flag = value == (this._deathNum == null);
				if (flag)
				{
					this._deathNum = (value ? new uint?(this.deathNum) : null);
				}
			}
		}

		// Token: 0x06007BE5 RID: 31717 RVA: 0x000ECDA8 File Offset: 0x000EAFA8
		private bool ShouldSerializedeathNum()
		{
			return this.deathNumSpecified;
		}

		// Token: 0x06007BE6 RID: 31718 RVA: 0x000ECDC0 File Offset: 0x000EAFC0
		private void ResetdeathNum()
		{
			this.deathNumSpecified = false;
		}

		// Token: 0x17002746 RID: 10054
		// (get) Token: 0x06007BE7 RID: 31719 RVA: 0x000ECDCC File Offset: 0x000EAFCC
		// (set) Token: 0x06007BE8 RID: 31720 RVA: 0x000ECDF8 File Offset: 0x000EAFF8
		[ProtoMember(9, IsRequired = false, Name = "assistNum", DataFormat = DataFormat.TwosComplement)]
		public uint assistNum
		{
			get
			{
				return this._assistNum ?? 0U;
			}
			set
			{
				this._assistNum = new uint?(value);
			}
		}

		// Token: 0x17002747 RID: 10055
		// (get) Token: 0x06007BE9 RID: 31721 RVA: 0x000ECE08 File Offset: 0x000EB008
		// (set) Token: 0x06007BEA RID: 31722 RVA: 0x000ECE28 File Offset: 0x000EB028
		[XmlIgnore]
		[Browsable(false)]
		public bool assistNumSpecified
		{
			get
			{
				return this._assistNum != null;
			}
			set
			{
				bool flag = value == (this._assistNum == null);
				if (flag)
				{
					this._assistNum = (value ? new uint?(this.assistNum) : null);
				}
			}
		}

		// Token: 0x06007BEB RID: 31723 RVA: 0x000ECE6C File Offset: 0x000EB06C
		private bool ShouldSerializeassistNum()
		{
			return this.assistNumSpecified;
		}

		// Token: 0x06007BEC RID: 31724 RVA: 0x000ECE84 File Offset: 0x000EB084
		private void ResetassistNum()
		{
			this.assistNumSpecified = false;
		}

		// Token: 0x17002748 RID: 10056
		// (get) Token: 0x06007BED RID: 31725 RVA: 0x000ECE90 File Offset: 0x000EB090
		// (set) Token: 0x06007BEE RID: 31726 RVA: 0x000ECEBC File Offset: 0x000EB0BC
		[ProtoMember(10, IsRequired = false, Name = "attackLevel", DataFormat = DataFormat.TwosComplement)]
		public uint attackLevel
		{
			get
			{
				return this._attackLevel ?? 0U;
			}
			set
			{
				this._attackLevel = new uint?(value);
			}
		}

		// Token: 0x17002749 RID: 10057
		// (get) Token: 0x06007BEF RID: 31727 RVA: 0x000ECECC File Offset: 0x000EB0CC
		// (set) Token: 0x06007BF0 RID: 31728 RVA: 0x000ECEEC File Offset: 0x000EB0EC
		[XmlIgnore]
		[Browsable(false)]
		public bool attackLevelSpecified
		{
			get
			{
				return this._attackLevel != null;
			}
			set
			{
				bool flag = value == (this._attackLevel == null);
				if (flag)
				{
					this._attackLevel = (value ? new uint?(this.attackLevel) : null);
				}
			}
		}

		// Token: 0x06007BF1 RID: 31729 RVA: 0x000ECF30 File Offset: 0x000EB130
		private bool ShouldSerializeattackLevel()
		{
			return this.attackLevelSpecified;
		}

		// Token: 0x06007BF2 RID: 31730 RVA: 0x000ECF48 File Offset: 0x000EB148
		private void ResetattackLevel()
		{
			this.attackLevelSpecified = false;
		}

		// Token: 0x1700274A RID: 10058
		// (get) Token: 0x06007BF3 RID: 31731 RVA: 0x000ECF54 File Offset: 0x000EB154
		// (set) Token: 0x06007BF4 RID: 31732 RVA: 0x000ECF80 File Offset: 0x000EB180
		[ProtoMember(11, IsRequired = false, Name = "defenseLevel", DataFormat = DataFormat.TwosComplement)]
		public uint defenseLevel
		{
			get
			{
				return this._defenseLevel ?? 0U;
			}
			set
			{
				this._defenseLevel = new uint?(value);
			}
		}

		// Token: 0x1700274B RID: 10059
		// (get) Token: 0x06007BF5 RID: 31733 RVA: 0x000ECF90 File Offset: 0x000EB190
		// (set) Token: 0x06007BF6 RID: 31734 RVA: 0x000ECFB0 File Offset: 0x000EB1B0
		[XmlIgnore]
		[Browsable(false)]
		public bool defenseLevelSpecified
		{
			get
			{
				return this._defenseLevel != null;
			}
			set
			{
				bool flag = value == (this._defenseLevel == null);
				if (flag)
				{
					this._defenseLevel = (value ? new uint?(this.defenseLevel) : null);
				}
			}
		}

		// Token: 0x06007BF7 RID: 31735 RVA: 0x000ECFF4 File Offset: 0x000EB1F4
		private bool ShouldSerializedefenseLevel()
		{
			return this.defenseLevelSpecified;
		}

		// Token: 0x06007BF8 RID: 31736 RVA: 0x000ED00C File Offset: 0x000EB20C
		private void ResetdefenseLevel()
		{
			this.defenseLevelSpecified = false;
		}

		// Token: 0x1700274C RID: 10060
		// (get) Token: 0x06007BF9 RID: 31737 RVA: 0x000ED018 File Offset: 0x000EB218
		// (set) Token: 0x06007BFA RID: 31738 RVA: 0x000ED044 File Offset: 0x000EB244
		[ProtoMember(12, IsRequired = false, Name = "reviveTime", DataFormat = DataFormat.TwosComplement)]
		public uint reviveTime
		{
			get
			{
				return this._reviveTime ?? 0U;
			}
			set
			{
				this._reviveTime = new uint?(value);
			}
		}

		// Token: 0x1700274D RID: 10061
		// (get) Token: 0x06007BFB RID: 31739 RVA: 0x000ED054 File Offset: 0x000EB254
		// (set) Token: 0x06007BFC RID: 31740 RVA: 0x000ED074 File Offset: 0x000EB274
		[XmlIgnore]
		[Browsable(false)]
		public bool reviveTimeSpecified
		{
			get
			{
				return this._reviveTime != null;
			}
			set
			{
				bool flag = value == (this._reviveTime == null);
				if (flag)
				{
					this._reviveTime = (value ? new uint?(this.reviveTime) : null);
				}
			}
		}

		// Token: 0x06007BFD RID: 31741 RVA: 0x000ED0B8 File Offset: 0x000EB2B8
		private bool ShouldSerializereviveTime()
		{
			return this.reviveTimeSpecified;
		}

		// Token: 0x06007BFE RID: 31742 RVA: 0x000ED0D0 File Offset: 0x000EB2D0
		private void ResetreviveTime()
		{
			this.reviveTimeSpecified = false;
		}

		// Token: 0x06007BFF RID: 31743 RVA: 0x000ED0DC File Offset: 0x000EB2DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D2F RID: 7471
		private ulong? _uid;

		// Token: 0x04001D30 RID: 7472
		private string _name;

		// Token: 0x04001D31 RID: 7473
		private double? _exp;

		// Token: 0x04001D32 RID: 7474
		private uint? _level;

		// Token: 0x04001D33 RID: 7475
		private uint? _upgradeNum;

		// Token: 0x04001D34 RID: 7476
		private uint? _heroid;

		// Token: 0x04001D35 RID: 7477
		private uint? _killNum;

		// Token: 0x04001D36 RID: 7478
		private uint? _deathNum;

		// Token: 0x04001D37 RID: 7479
		private uint? _assistNum;

		// Token: 0x04001D38 RID: 7480
		private uint? _attackLevel;

		// Token: 0x04001D39 RID: 7481
		private uint? _defenseLevel;

		// Token: 0x04001D3A RID: 7482
		private uint? _reviveTime;

		// Token: 0x04001D3B RID: 7483
		private IExtension extensionObject;
	}
}
