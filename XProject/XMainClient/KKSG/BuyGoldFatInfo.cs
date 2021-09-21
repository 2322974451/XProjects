using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000054 RID: 84
	[ProtoContract(Name = "BuyGoldFatInfo")]
	[Serializable]
	public class BuyGoldFatInfo : IExtensible
	{
		// Token: 0x170001CD RID: 461
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0000D4D8 File Offset: 0x0000B6D8
		// (set) Token: 0x0600058E RID: 1422 RVA: 0x0000D504 File Offset: 0x0000B704
		[ProtoMember(1, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public uint day
		{
			get
			{
				return this._day ?? 0U;
			}
			set
			{
				this._day = new uint?(value);
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0000D514 File Offset: 0x0000B714
		// (set) Token: 0x06000590 RID: 1424 RVA: 0x0000D534 File Offset: 0x0000B734
		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new uint?(this.day) : null);
				}
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0000D578 File Offset: 0x0000B778
		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0000D590 File Offset: 0x0000B790
		private void Resetday()
		{
			this.daySpecified = false;
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0000D59C File Offset: 0x0000B79C
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x0000D5C8 File Offset: 0x0000B7C8
		[ProtoMember(2, IsRequired = false, Name = "BuyGoldCount", DataFormat = DataFormat.TwosComplement)]
		public int BuyGoldCount
		{
			get
			{
				return this._BuyGoldCount ?? 0;
			}
			set
			{
				this._BuyGoldCount = new int?(value);
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0000D5D8 File Offset: 0x0000B7D8
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x0000D5F8 File Offset: 0x0000B7F8
		[XmlIgnore]
		[Browsable(false)]
		public bool BuyGoldCountSpecified
		{
			get
			{
				return this._BuyGoldCount != null;
			}
			set
			{
				bool flag = value == (this._BuyGoldCount == null);
				if (flag)
				{
					this._BuyGoldCount = (value ? new int?(this.BuyGoldCount) : null);
				}
			}
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0000D63C File Offset: 0x0000B83C
		private bool ShouldSerializeBuyGoldCount()
		{
			return this.BuyGoldCountSpecified;
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0000D654 File Offset: 0x0000B854
		private void ResetBuyGoldCount()
		{
			this.BuyGoldCountSpecified = false;
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x0000D660 File Offset: 0x0000B860
		[ProtoMember(3, Name = "BuyFatigueCount", DataFormat = DataFormat.TwosComplement)]
		public List<int> BuyFatigueCount
		{
			get
			{
				return this._BuyFatigueCount;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0000D678 File Offset: 0x0000B878
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x0000D6A4 File Offset: 0x0000B8A4
		[ProtoMember(4, IsRequired = false, Name = "BuyDragonCount", DataFormat = DataFormat.TwosComplement)]
		public int BuyDragonCount
		{
			get
			{
				return this._BuyDragonCount ?? 0;
			}
			set
			{
				this._BuyDragonCount = new int?(value);
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0000D6B4 File Offset: 0x0000B8B4
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0000D6D4 File Offset: 0x0000B8D4
		[XmlIgnore]
		[Browsable(false)]
		public bool BuyDragonCountSpecified
		{
			get
			{
				return this._BuyDragonCount != null;
			}
			set
			{
				bool flag = value == (this._BuyDragonCount == null);
				if (flag)
				{
					this._BuyDragonCount = (value ? new int?(this.BuyDragonCount) : null);
				}
			}
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0000D718 File Offset: 0x0000B918
		private bool ShouldSerializeBuyDragonCount()
		{
			return this.BuyDragonCountSpecified;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0000D730 File Offset: 0x0000B930
		private void ResetBuyDragonCount()
		{
			this.BuyDragonCountSpecified = false;
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x0000D73C File Offset: 0x0000B93C
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x0000D754 File Offset: 0x0000B954
		[ProtoMember(5, IsRequired = false, Name = "backflow", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BackFlowBuy backflow
		{
			get
			{
				return this._backflow;
			}
			set
			{
				this._backflow = value;
			}
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x0000D760 File Offset: 0x0000B960
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400016B RID: 363
		private uint? _day;

		// Token: 0x0400016C RID: 364
		private int? _BuyGoldCount;

		// Token: 0x0400016D RID: 365
		private readonly List<int> _BuyFatigueCount = new List<int>();

		// Token: 0x0400016E RID: 366
		private int? _BuyDragonCount;

		// Token: 0x0400016F RID: 367
		private BackFlowBuy _backflow = null;

		// Token: 0x04000170 RID: 368
		private IExtension extensionObject;
	}
}
