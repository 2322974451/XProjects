using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000056 RID: 86
	[ProtoContract(Name = "SweepRes")]
	[Serializable]
	public class SweepRes : IExtensible
	{
		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0000DA00 File Offset: 0x0000BC00
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0000DA2C File Offset: 0x0000BC2C
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

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0000DA3C File Offset: 0x0000BC3C
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x0000DA5C File Offset: 0x0000BC5C
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

		// Token: 0x060005BC RID: 1468 RVA: 0x0000DAA0 File Offset: 0x0000BCA0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0000DAB8 File Offset: 0x0000BCB8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x0000DAC4 File Offset: 0x0000BCC4
		[ProtoMember(2, Name = "rewards", DataFormat = DataFormat.Default)]
		public List<SweepResult> rewards
		{
			get
			{
				return this._rewards;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x0000DADC File Offset: 0x0000BCDC
		// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0000DB08 File Offset: 0x0000BD08
		[ProtoMember(3, IsRequired = false, Name = "abyssleftcount", DataFormat = DataFormat.TwosComplement)]
		public int abyssleftcount
		{
			get
			{
				return this._abyssleftcount ?? 0;
			}
			set
			{
				this._abyssleftcount = new int?(value);
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0000DB18 File Offset: 0x0000BD18
		// (set) Token: 0x060005C2 RID: 1474 RVA: 0x0000DB38 File Offset: 0x0000BD38
		[XmlIgnore]
		[Browsable(false)]
		public bool abyssleftcountSpecified
		{
			get
			{
				return this._abyssleftcount != null;
			}
			set
			{
				bool flag = value == (this._abyssleftcount == null);
				if (flag)
				{
					this._abyssleftcount = (value ? new int?(this.abyssleftcount) : null);
				}
			}
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x0000DB7C File Offset: 0x0000BD7C
		private bool ShouldSerializeabyssleftcount()
		{
			return this.abyssleftcountSpecified;
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x0000DB94 File Offset: 0x0000BD94
		private void Resetabyssleftcount()
		{
			this.abyssleftcountSpecified = false;
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x0000DBA0 File Offset: 0x0000BDA0
		// (set) Token: 0x060005C6 RID: 1478 RVA: 0x0000DBCC File Offset: 0x0000BDCC
		[ProtoMember(4, IsRequired = false, Name = "isexpseal", DataFormat = DataFormat.Default)]
		public bool isexpseal
		{
			get
			{
				return this._isexpseal ?? false;
			}
			set
			{
				this._isexpseal = new bool?(value);
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0000DBDC File Offset: 0x0000BDDC
		// (set) Token: 0x060005C8 RID: 1480 RVA: 0x0000DBFC File Offset: 0x0000BDFC
		[XmlIgnore]
		[Browsable(false)]
		public bool isexpsealSpecified
		{
			get
			{
				return this._isexpseal != null;
			}
			set
			{
				bool flag = value == (this._isexpseal == null);
				if (flag)
				{
					this._isexpseal = (value ? new bool?(this.isexpseal) : null);
				}
			}
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x0000DC40 File Offset: 0x0000BE40
		private bool ShouldSerializeisexpseal()
		{
			return this.isexpsealSpecified;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0000DC58 File Offset: 0x0000BE58
		private void Resetisexpseal()
		{
			this.isexpsealSpecified = false;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0000DC64 File Offset: 0x0000BE64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000175 RID: 373
		private ErrorCode? _result;

		// Token: 0x04000176 RID: 374
		private readonly List<SweepResult> _rewards = new List<SweepResult>();

		// Token: 0x04000177 RID: 375
		private int? _abyssleftcount;

		// Token: 0x04000178 RID: 376
		private bool? _isexpseal;

		// Token: 0x04000179 RID: 377
		private IExtension extensionObject;
	}
}
