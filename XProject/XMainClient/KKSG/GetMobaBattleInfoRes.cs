using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000444 RID: 1092
	[ProtoContract(Name = "GetMobaBattleInfoRes")]
	[Serializable]
	public class GetMobaBattleInfoRes : IExtensible
	{
		// Token: 0x170011A9 RID: 4521
		// (get) Token: 0x0600398D RID: 14733 RVA: 0x0006E168 File Offset: 0x0006C368
		// (set) Token: 0x0600398E RID: 14734 RVA: 0x0006E194 File Offset: 0x0006C394
		[ProtoMember(1, IsRequired = false, Name = "winthisweek", DataFormat = DataFormat.TwosComplement)]
		public uint winthisweek
		{
			get
			{
				return this._winthisweek ?? 0U;
			}
			set
			{
				this._winthisweek = new uint?(value);
			}
		}

		// Token: 0x170011AA RID: 4522
		// (get) Token: 0x0600398F RID: 14735 RVA: 0x0006E1A4 File Offset: 0x0006C3A4
		// (set) Token: 0x06003990 RID: 14736 RVA: 0x0006E1C4 File Offset: 0x0006C3C4
		[XmlIgnore]
		[Browsable(false)]
		public bool winthisweekSpecified
		{
			get
			{
				return this._winthisweek != null;
			}
			set
			{
				bool flag = value == (this._winthisweek == null);
				if (flag)
				{
					this._winthisweek = (value ? new uint?(this.winthisweek) : null);
				}
			}
		}

		// Token: 0x06003991 RID: 14737 RVA: 0x0006E208 File Offset: 0x0006C408
		private bool ShouldSerializewinthisweek()
		{
			return this.winthisweekSpecified;
		}

		// Token: 0x06003992 RID: 14738 RVA: 0x0006E220 File Offset: 0x0006C420
		private void Resetwinthisweek()
		{
			this.winthisweekSpecified = false;
		}

		// Token: 0x170011AB RID: 4523
		// (get) Token: 0x06003993 RID: 14739 RVA: 0x0006E22C File Offset: 0x0006C42C
		// (set) Token: 0x06003994 RID: 14740 RVA: 0x0006E258 File Offset: 0x0006C458
		[ProtoMember(2, IsRequired = false, Name = "weekprize", DataFormat = DataFormat.TwosComplement)]
		public uint weekprize
		{
			get
			{
				return this._weekprize ?? 0U;
			}
			set
			{
				this._weekprize = new uint?(value);
			}
		}

		// Token: 0x170011AC RID: 4524
		// (get) Token: 0x06003995 RID: 14741 RVA: 0x0006E268 File Offset: 0x0006C468
		// (set) Token: 0x06003996 RID: 14742 RVA: 0x0006E288 File Offset: 0x0006C488
		[XmlIgnore]
		[Browsable(false)]
		public bool weekprizeSpecified
		{
			get
			{
				return this._weekprize != null;
			}
			set
			{
				bool flag = value == (this._weekprize == null);
				if (flag)
				{
					this._weekprize = (value ? new uint?(this.weekprize) : null);
				}
			}
		}

		// Token: 0x06003997 RID: 14743 RVA: 0x0006E2CC File Offset: 0x0006C4CC
		private bool ShouldSerializeweekprize()
		{
			return this.weekprizeSpecified;
		}

		// Token: 0x06003998 RID: 14744 RVA: 0x0006E2E4 File Offset: 0x0006C4E4
		private void Resetweekprize()
		{
			this.weekprizeSpecified = false;
		}

		// Token: 0x170011AD RID: 4525
		// (get) Token: 0x06003999 RID: 14745 RVA: 0x0006E2F0 File Offset: 0x0006C4F0
		// (set) Token: 0x0600399A RID: 14746 RVA: 0x0006E31C File Offset: 0x0006C51C
		[ProtoMember(3, IsRequired = false, Name = "getnextweekprize", DataFormat = DataFormat.Default)]
		public bool getnextweekprize
		{
			get
			{
				return this._getnextweekprize ?? false;
			}
			set
			{
				this._getnextweekprize = new bool?(value);
			}
		}

		// Token: 0x170011AE RID: 4526
		// (get) Token: 0x0600399B RID: 14747 RVA: 0x0006E32C File Offset: 0x0006C52C
		// (set) Token: 0x0600399C RID: 14748 RVA: 0x0006E34C File Offset: 0x0006C54C
		[XmlIgnore]
		[Browsable(false)]
		public bool getnextweekprizeSpecified
		{
			get
			{
				return this._getnextweekprize != null;
			}
			set
			{
				bool flag = value == (this._getnextweekprize == null);
				if (flag)
				{
					this._getnextweekprize = (value ? new bool?(this.getnextweekprize) : null);
				}
			}
		}

		// Token: 0x0600399D RID: 14749 RVA: 0x0006E390 File Offset: 0x0006C590
		private bool ShouldSerializegetnextweekprize()
		{
			return this.getnextweekprizeSpecified;
		}

		// Token: 0x0600399E RID: 14750 RVA: 0x0006E3A8 File Offset: 0x0006C5A8
		private void Resetgetnextweekprize()
		{
			this.getnextweekprizeSpecified = false;
		}

		// Token: 0x0600399F RID: 14751 RVA: 0x0006E3B4 File Offset: 0x0006C5B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E49 RID: 3657
		private uint? _winthisweek;

		// Token: 0x04000E4A RID: 3658
		private uint? _weekprize;

		// Token: 0x04000E4B RID: 3659
		private bool? _getnextweekprize;

		// Token: 0x04000E4C RID: 3660
		private IExtension extensionObject;
	}
}
