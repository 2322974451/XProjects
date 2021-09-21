using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E3 RID: 995
	[ProtoContract(Name = "GetSkyCraftRecordRes")]
	[Serializable]
	public class GetSkyCraftRecordRes : IExtensible
	{
		// Token: 0x17001048 RID: 4168
		// (get) Token: 0x060034ED RID: 13549 RVA: 0x00065758 File Offset: 0x00063958
		// (set) Token: 0x060034EE RID: 13550 RVA: 0x00065784 File Offset: 0x00063984
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17001049 RID: 4169
		// (get) Token: 0x060034EF RID: 13551 RVA: 0x00065794 File Offset: 0x00063994
		// (set) Token: 0x060034F0 RID: 13552 RVA: 0x000657B4 File Offset: 0x000639B4
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x060034F1 RID: 13553 RVA: 0x000657F8 File Offset: 0x000639F8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060034F2 RID: 13554 RVA: 0x00065810 File Offset: 0x00063A10
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700104A RID: 4170
		// (get) Token: 0x060034F3 RID: 13555 RVA: 0x0006581C File Offset: 0x00063A1C
		// (set) Token: 0x060034F4 RID: 13556 RVA: 0x00065848 File Offset: 0x00063A48
		[ProtoMember(2, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		// Token: 0x1700104B RID: 4171
		// (get) Token: 0x060034F5 RID: 13557 RVA: 0x00065858 File Offset: 0x00063A58
		// (set) Token: 0x060034F6 RID: 13558 RVA: 0x00065878 File Offset: 0x00063A78
		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		// Token: 0x060034F7 RID: 13559 RVA: 0x000658BC File Offset: 0x00063ABC
		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		// Token: 0x060034F8 RID: 13560 RVA: 0x000658D4 File Offset: 0x00063AD4
		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		// Token: 0x1700104C RID: 4172
		// (get) Token: 0x060034F9 RID: 13561 RVA: 0x000658E0 File Offset: 0x00063AE0
		// (set) Token: 0x060034FA RID: 13562 RVA: 0x0006590C File Offset: 0x00063B0C
		[ProtoMember(3, IsRequired = false, Name = "losenum", DataFormat = DataFormat.TwosComplement)]
		public uint losenum
		{
			get
			{
				return this._losenum ?? 0U;
			}
			set
			{
				this._losenum = new uint?(value);
			}
		}

		// Token: 0x1700104D RID: 4173
		// (get) Token: 0x060034FB RID: 13563 RVA: 0x0006591C File Offset: 0x00063B1C
		// (set) Token: 0x060034FC RID: 13564 RVA: 0x0006593C File Offset: 0x00063B3C
		[XmlIgnore]
		[Browsable(false)]
		public bool losenumSpecified
		{
			get
			{
				return this._losenum != null;
			}
			set
			{
				bool flag = value == (this._losenum == null);
				if (flag)
				{
					this._losenum = (value ? new uint?(this.losenum) : null);
				}
			}
		}

		// Token: 0x060034FD RID: 13565 RVA: 0x00065980 File Offset: 0x00063B80
		private bool ShouldSerializelosenum()
		{
			return this.losenumSpecified;
		}

		// Token: 0x060034FE RID: 13566 RVA: 0x00065998 File Offset: 0x00063B98
		private void Resetlosenum()
		{
			this.losenumSpecified = false;
		}

		// Token: 0x1700104E RID: 4174
		// (get) Token: 0x060034FF RID: 13567 RVA: 0x000659A4 File Offset: 0x00063BA4
		// (set) Token: 0x06003500 RID: 13568 RVA: 0x000659D4 File Offset: 0x00063BD4
		[ProtoMember(4, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
		public float winrate
		{
			get
			{
				return this._winrate ?? 0f;
			}
			set
			{
				this._winrate = new float?(value);
			}
		}

		// Token: 0x1700104F RID: 4175
		// (get) Token: 0x06003501 RID: 13569 RVA: 0x000659E4 File Offset: 0x00063BE4
		// (set) Token: 0x06003502 RID: 13570 RVA: 0x00065A04 File Offset: 0x00063C04
		[XmlIgnore]
		[Browsable(false)]
		public bool winrateSpecified
		{
			get
			{
				return this._winrate != null;
			}
			set
			{
				bool flag = value == (this._winrate == null);
				if (flag)
				{
					this._winrate = (value ? new float?(this.winrate) : null);
				}
			}
		}

		// Token: 0x06003503 RID: 13571 RVA: 0x00065A48 File Offset: 0x00063C48
		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		// Token: 0x06003504 RID: 13572 RVA: 0x00065A60 File Offset: 0x00063C60
		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		// Token: 0x17001050 RID: 4176
		// (get) Token: 0x06003505 RID: 13573 RVA: 0x00065A6C File Offset: 0x00063C6C
		// (set) Token: 0x06003506 RID: 13574 RVA: 0x00065A98 File Offset: 0x00063C98
		[ProtoMember(5, IsRequired = false, Name = "max_continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint max_continuewin
		{
			get
			{
				return this._max_continuewin ?? 0U;
			}
			set
			{
				this._max_continuewin = new uint?(value);
			}
		}

		// Token: 0x17001051 RID: 4177
		// (get) Token: 0x06003507 RID: 13575 RVA: 0x00065AA8 File Offset: 0x00063CA8
		// (set) Token: 0x06003508 RID: 13576 RVA: 0x00065AC8 File Offset: 0x00063CC8
		[XmlIgnore]
		[Browsable(false)]
		public bool max_continuewinSpecified
		{
			get
			{
				return this._max_continuewin != null;
			}
			set
			{
				bool flag = value == (this._max_continuewin == null);
				if (flag)
				{
					this._max_continuewin = (value ? new uint?(this.max_continuewin) : null);
				}
			}
		}

		// Token: 0x06003509 RID: 13577 RVA: 0x00065B0C File Offset: 0x00063D0C
		private bool ShouldSerializemax_continuewin()
		{
			return this.max_continuewinSpecified;
		}

		// Token: 0x0600350A RID: 13578 RVA: 0x00065B24 File Offset: 0x00063D24
		private void Resetmax_continuewin()
		{
			this.max_continuewinSpecified = false;
		}

		// Token: 0x17001052 RID: 4178
		// (get) Token: 0x0600350B RID: 13579 RVA: 0x00065B30 File Offset: 0x00063D30
		// (set) Token: 0x0600350C RID: 13580 RVA: 0x00065B5C File Offset: 0x00063D5C
		[ProtoMember(6, IsRequired = false, Name = "max_continuelose", DataFormat = DataFormat.TwosComplement)]
		public uint max_continuelose
		{
			get
			{
				return this._max_continuelose ?? 0U;
			}
			set
			{
				this._max_continuelose = new uint?(value);
			}
		}

		// Token: 0x17001053 RID: 4179
		// (get) Token: 0x0600350D RID: 13581 RVA: 0x00065B6C File Offset: 0x00063D6C
		// (set) Token: 0x0600350E RID: 13582 RVA: 0x00065B8C File Offset: 0x00063D8C
		[XmlIgnore]
		[Browsable(false)]
		public bool max_continueloseSpecified
		{
			get
			{
				return this._max_continuelose != null;
			}
			set
			{
				bool flag = value == (this._max_continuelose == null);
				if (flag)
				{
					this._max_continuelose = (value ? new uint?(this.max_continuelose) : null);
				}
			}
		}

		// Token: 0x0600350F RID: 13583 RVA: 0x00065BD0 File Offset: 0x00063DD0
		private bool ShouldSerializemax_continuelose()
		{
			return this.max_continueloseSpecified;
		}

		// Token: 0x06003510 RID: 13584 RVA: 0x00065BE8 File Offset: 0x00063DE8
		private void Resetmax_continuelose()
		{
			this.max_continueloseSpecified = false;
		}

		// Token: 0x17001054 RID: 4180
		// (get) Token: 0x06003511 RID: 13585 RVA: 0x00065BF4 File Offset: 0x00063DF4
		[ProtoMember(7, Name = "records", DataFormat = DataFormat.Default)]
		public List<SkyCraftBattleRecord> records
		{
			get
			{
				return this._records;
			}
		}

		// Token: 0x06003512 RID: 13586 RVA: 0x00065C0C File Offset: 0x00063E0C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D24 RID: 3364
		private ErrorCode? _result;

		// Token: 0x04000D25 RID: 3365
		private uint? _winnum;

		// Token: 0x04000D26 RID: 3366
		private uint? _losenum;

		// Token: 0x04000D27 RID: 3367
		private float? _winrate;

		// Token: 0x04000D28 RID: 3368
		private uint? _max_continuewin;

		// Token: 0x04000D29 RID: 3369
		private uint? _max_continuelose;

		// Token: 0x04000D2A RID: 3370
		private readonly List<SkyCraftBattleRecord> _records = new List<SkyCraftBattleRecord>();

		// Token: 0x04000D2B RID: 3371
		private IExtension extensionObject;
	}
}
