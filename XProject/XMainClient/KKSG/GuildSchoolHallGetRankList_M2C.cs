using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200053E RID: 1342
	[ProtoContract(Name = "GuildSchoolHallGetRankList_M2C")]
	[Serializable]
	public class GuildSchoolHallGetRankList_M2C : IExtensible
	{
		// Token: 0x170014FF RID: 5375
		// (get) Token: 0x060044B1 RID: 17585 RVA: 0x00082A34 File Offset: 0x00080C34
		[ProtoMember(1, Name = "unranklist", DataFormat = DataFormat.Default)]
		public List<GuildSchoolHallRankData> unranklist
		{
			get
			{
				return this._unranklist;
			}
		}

		// Token: 0x17001500 RID: 5376
		// (get) Token: 0x060044B2 RID: 17586 RVA: 0x00082A4C File Offset: 0x00080C4C
		// (set) Token: 0x060044B3 RID: 17587 RVA: 0x00082A78 File Offset: 0x00080C78
		[ProtoMember(2, IsRequired = false, Name = "guildweeklyschoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint guildweeklyschoolpoint
		{
			get
			{
				return this._guildweeklyschoolpoint ?? 0U;
			}
			set
			{
				this._guildweeklyschoolpoint = new uint?(value);
			}
		}

		// Token: 0x17001501 RID: 5377
		// (get) Token: 0x060044B4 RID: 17588 RVA: 0x00082A88 File Offset: 0x00080C88
		// (set) Token: 0x060044B5 RID: 17589 RVA: 0x00082AA8 File Offset: 0x00080CA8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildweeklyschoolpointSpecified
		{
			get
			{
				return this._guildweeklyschoolpoint != null;
			}
			set
			{
				bool flag = value == (this._guildweeklyschoolpoint == null);
				if (flag)
				{
					this._guildweeklyschoolpoint = (value ? new uint?(this.guildweeklyschoolpoint) : null);
				}
			}
		}

		// Token: 0x060044B6 RID: 17590 RVA: 0x00082AEC File Offset: 0x00080CEC
		private bool ShouldSerializeguildweeklyschoolpoint()
		{
			return this.guildweeklyschoolpointSpecified;
		}

		// Token: 0x060044B7 RID: 17591 RVA: 0x00082B04 File Offset: 0x00080D04
		private void Resetguildweeklyschoolpoint()
		{
			this.guildweeklyschoolpointSpecified = false;
		}

		// Token: 0x17001502 RID: 5378
		// (get) Token: 0x060044B8 RID: 17592 RVA: 0x00082B10 File Offset: 0x00080D10
		// (set) Token: 0x060044B9 RID: 17593 RVA: 0x00082B3C File Offset: 0x00080D3C
		[ProtoMember(3, IsRequired = false, Name = "guildweeklyhallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint guildweeklyhallpoint
		{
			get
			{
				return this._guildweeklyhallpoint ?? 0U;
			}
			set
			{
				this._guildweeklyhallpoint = new uint?(value);
			}
		}

		// Token: 0x17001503 RID: 5379
		// (get) Token: 0x060044BA RID: 17594 RVA: 0x00082B4C File Offset: 0x00080D4C
		// (set) Token: 0x060044BB RID: 17595 RVA: 0x00082B6C File Offset: 0x00080D6C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildweeklyhallpointSpecified
		{
			get
			{
				return this._guildweeklyhallpoint != null;
			}
			set
			{
				bool flag = value == (this._guildweeklyhallpoint == null);
				if (flag)
				{
					this._guildweeklyhallpoint = (value ? new uint?(this.guildweeklyhallpoint) : null);
				}
			}
		}

		// Token: 0x060044BC RID: 17596 RVA: 0x00082BB0 File Offset: 0x00080DB0
		private bool ShouldSerializeguildweeklyhallpoint()
		{
			return this.guildweeklyhallpointSpecified;
		}

		// Token: 0x060044BD RID: 17597 RVA: 0x00082BC8 File Offset: 0x00080DC8
		private void Resetguildweeklyhallpoint()
		{
			this.guildweeklyhallpointSpecified = false;
		}

		// Token: 0x17001504 RID: 5380
		// (get) Token: 0x060044BE RID: 17598 RVA: 0x00082BD4 File Offset: 0x00080DD4
		// (set) Token: 0x060044BF RID: 17599 RVA: 0x00082C00 File Offset: 0x00080E00
		[ProtoMember(4, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		// Token: 0x17001505 RID: 5381
		// (get) Token: 0x060044C0 RID: 17600 RVA: 0x00082C10 File Offset: 0x00080E10
		// (set) Token: 0x060044C1 RID: 17601 RVA: 0x00082C30 File Offset: 0x00080E30
		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		// Token: 0x060044C2 RID: 17602 RVA: 0x00082C74 File Offset: 0x00080E74
		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		// Token: 0x060044C3 RID: 17603 RVA: 0x00082C8C File Offset: 0x00080E8C
		private void Resetec()
		{
			this.ecSpecified = false;
		}

		// Token: 0x17001506 RID: 5382
		// (get) Token: 0x060044C4 RID: 17604 RVA: 0x00082C98 File Offset: 0x00080E98
		// (set) Token: 0x060044C5 RID: 17605 RVA: 0x00082CC4 File Offset: 0x00080EC4
		[ProtoMember(5, IsRequired = false, Name = "guildweeklyhuntingcount", DataFormat = DataFormat.TwosComplement)]
		public uint guildweeklyhuntingcount
		{
			get
			{
				return this._guildweeklyhuntingcount ?? 0U;
			}
			set
			{
				this._guildweeklyhuntingcount = new uint?(value);
			}
		}

		// Token: 0x17001507 RID: 5383
		// (get) Token: 0x060044C6 RID: 17606 RVA: 0x00082CD4 File Offset: 0x00080ED4
		// (set) Token: 0x060044C7 RID: 17607 RVA: 0x00082CF4 File Offset: 0x00080EF4
		[XmlIgnore]
		[Browsable(false)]
		public bool guildweeklyhuntingcountSpecified
		{
			get
			{
				return this._guildweeklyhuntingcount != null;
			}
			set
			{
				bool flag = value == (this._guildweeklyhuntingcount == null);
				if (flag)
				{
					this._guildweeklyhuntingcount = (value ? new uint?(this.guildweeklyhuntingcount) : null);
				}
			}
		}

		// Token: 0x060044C8 RID: 17608 RVA: 0x00082D38 File Offset: 0x00080F38
		private bool ShouldSerializeguildweeklyhuntingcount()
		{
			return this.guildweeklyhuntingcountSpecified;
		}

		// Token: 0x060044C9 RID: 17609 RVA: 0x00082D50 File Offset: 0x00080F50
		private void Resetguildweeklyhuntingcount()
		{
			this.guildweeklyhuntingcountSpecified = false;
		}

		// Token: 0x17001508 RID: 5384
		// (get) Token: 0x060044CA RID: 17610 RVA: 0x00082D5C File Offset: 0x00080F5C
		// (set) Token: 0x060044CB RID: 17611 RVA: 0x00082D88 File Offset: 0x00080F88
		[ProtoMember(6, IsRequired = false, Name = "guildweeklydonatecount", DataFormat = DataFormat.TwosComplement)]
		public uint guildweeklydonatecount
		{
			get
			{
				return this._guildweeklydonatecount ?? 0U;
			}
			set
			{
				this._guildweeklydonatecount = new uint?(value);
			}
		}

		// Token: 0x17001509 RID: 5385
		// (get) Token: 0x060044CC RID: 17612 RVA: 0x00082D98 File Offset: 0x00080F98
		// (set) Token: 0x060044CD RID: 17613 RVA: 0x00082DB8 File Offset: 0x00080FB8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildweeklydonatecountSpecified
		{
			get
			{
				return this._guildweeklydonatecount != null;
			}
			set
			{
				bool flag = value == (this._guildweeklydonatecount == null);
				if (flag)
				{
					this._guildweeklydonatecount = (value ? new uint?(this.guildweeklydonatecount) : null);
				}
			}
		}

		// Token: 0x060044CE RID: 17614 RVA: 0x00082DFC File Offset: 0x00080FFC
		private bool ShouldSerializeguildweeklydonatecount()
		{
			return this.guildweeklydonatecountSpecified;
		}

		// Token: 0x060044CF RID: 17615 RVA: 0x00082E14 File Offset: 0x00081014
		private void Resetguildweeklydonatecount()
		{
			this.guildweeklydonatecountSpecified = false;
		}

		// Token: 0x060044D0 RID: 17616 RVA: 0x00082E20 File Offset: 0x00081020
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001129 RID: 4393
		private readonly List<GuildSchoolHallRankData> _unranklist = new List<GuildSchoolHallRankData>();

		// Token: 0x0400112A RID: 4394
		private uint? _guildweeklyschoolpoint;

		// Token: 0x0400112B RID: 4395
		private uint? _guildweeklyhallpoint;

		// Token: 0x0400112C RID: 4396
		private ErrorCode? _ec;

		// Token: 0x0400112D RID: 4397
		private uint? _guildweeklyhuntingcount;

		// Token: 0x0400112E RID: 4398
		private uint? _guildweeklydonatecount;

		// Token: 0x0400112F RID: 4399
		private IExtension extensionObject;
	}
}
