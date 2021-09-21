using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000069 RID: 105
	[ProtoContract(Name = "ReviveCountdownInfo")]
	[Serializable]
	public class ReviveCountdownInfo : IExtensible
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x000100CC File Offset: 0x0000E2CC
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x000100F8 File Offset: 0x0000E2F8
		[ProtoMember(1, IsRequired = false, Name = "countdownTime", DataFormat = DataFormat.TwosComplement)]
		public int countdownTime
		{
			get
			{
				return this._countdownTime ?? 0;
			}
			set
			{
				this._countdownTime = new int?(value);
			}
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x00010108 File Offset: 0x0000E308
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x00010128 File Offset: 0x0000E328
		[XmlIgnore]
		[Browsable(false)]
		public bool countdownTimeSpecified
		{
			get
			{
				return this._countdownTime != null;
			}
			set
			{
				bool flag = value == (this._countdownTime == null);
				if (flag)
				{
					this._countdownTime = (value ? new int?(this.countdownTime) : null);
				}
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0001016C File Offset: 0x0000E36C
		private bool ShouldSerializecountdownTime()
		{
			return this.countdownTimeSpecified;
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00010184 File Offset: 0x0000E384
		private void ResetcountdownTime()
		{
			this.countdownTimeSpecified = false;
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x00010190 File Offset: 0x0000E390
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x000101BC File Offset: 0x0000E3BC
		[ProtoMember(2, IsRequired = false, Name = "revivecost", DataFormat = DataFormat.TwosComplement)]
		public uint revivecost
		{
			get
			{
				return this._revivecost ?? 0U;
			}
			set
			{
				this._revivecost = new uint?(value);
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x000101CC File Offset: 0x0000E3CC
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x000101EC File Offset: 0x0000E3EC
		[XmlIgnore]
		[Browsable(false)]
		public bool revivecostSpecified
		{
			get
			{
				return this._revivecost != null;
			}
			set
			{
				bool flag = value == (this._revivecost == null);
				if (flag)
				{
					this._revivecost = (value ? new uint?(this.revivecost) : null);
				}
			}
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x00010230 File Offset: 0x0000E430
		private bool ShouldSerializerevivecost()
		{
			return this.revivecostSpecified;
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00010248 File Offset: 0x0000E448
		private void Resetrevivecost()
		{
			this.revivecostSpecified = false;
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00010254 File Offset: 0x0000E454
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x00010280 File Offset: 0x0000E480
		[ProtoMember(3, IsRequired = false, Name = "revivecosttype", DataFormat = DataFormat.TwosComplement)]
		public uint revivecosttype
		{
			get
			{
				return this._revivecosttype ?? 0U;
			}
			set
			{
				this._revivecosttype = new uint?(value);
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00010290 File Offset: 0x0000E490
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x000102B0 File Offset: 0x0000E4B0
		[XmlIgnore]
		[Browsable(false)]
		public bool revivecosttypeSpecified
		{
			get
			{
				return this._revivecosttype != null;
			}
			set
			{
				bool flag = value == (this._revivecosttype == null);
				if (flag)
				{
					this._revivecosttype = (value ? new uint?(this.revivecosttype) : null);
				}
			}
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x000102F4 File Offset: 0x0000E4F4
		private bool ShouldSerializerevivecosttype()
		{
			return this.revivecosttypeSpecified;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0001030C File Offset: 0x0000E50C
		private void Resetrevivecosttype()
		{
			this.revivecosttypeSpecified = false;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00010318 File Offset: 0x0000E518
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001C3 RID: 451
		private int? _countdownTime;

		// Token: 0x040001C4 RID: 452
		private uint? _revivecost;

		// Token: 0x040001C5 RID: 453
		private uint? _revivecosttype;

		// Token: 0x040001C6 RID: 454
		private IExtension extensionObject;
	}
}
