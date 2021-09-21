using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000605 RID: 1541
	[ProtoContract(Name = "PkRecordSubInfo")]
	[Serializable]
	public class PkRecordSubInfo : IExtensible
	{
		// Token: 0x17001D17 RID: 7447
		// (get) Token: 0x06005CD3 RID: 23763 RVA: 0x000B0E1C File Offset: 0x000AF01C
		// (set) Token: 0x06005CD4 RID: 23764 RVA: 0x000B0E48 File Offset: 0x000AF048
		[ProtoMember(1, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17001D18 RID: 7448
		// (get) Token: 0x06005CD5 RID: 23765 RVA: 0x000B0E58 File Offset: 0x000AF058
		// (set) Token: 0x06005CD6 RID: 23766 RVA: 0x000B0E78 File Offset: 0x000AF078
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06005CD7 RID: 23767 RVA: 0x000B0EBC File Offset: 0x000AF0BC
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06005CD8 RID: 23768 RVA: 0x000B0ED4 File Offset: 0x000AF0D4
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001D19 RID: 7449
		// (get) Token: 0x06005CD9 RID: 23769 RVA: 0x000B0EE0 File Offset: 0x000AF0E0
		// (set) Token: 0x06005CDA RID: 23770 RVA: 0x000B0F0C File Offset: 0x000AF10C
		[ProtoMember(2, IsRequired = false, Name = "rewardcount", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcount
		{
			get
			{
				return this._rewardcount ?? 0U;
			}
			set
			{
				this._rewardcount = new uint?(value);
			}
		}

		// Token: 0x17001D1A RID: 7450
		// (get) Token: 0x06005CDB RID: 23771 RVA: 0x000B0F1C File Offset: 0x000AF11C
		// (set) Token: 0x06005CDC RID: 23772 RVA: 0x000B0F3C File Offset: 0x000AF13C
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcountSpecified
		{
			get
			{
				return this._rewardcount != null;
			}
			set
			{
				bool flag = value == (this._rewardcount == null);
				if (flag)
				{
					this._rewardcount = (value ? new uint?(this.rewardcount) : null);
				}
			}
		}

		// Token: 0x06005CDD RID: 23773 RVA: 0x000B0F80 File Offset: 0x000AF180
		private bool ShouldSerializerewardcount()
		{
			return this.rewardcountSpecified;
		}

		// Token: 0x06005CDE RID: 23774 RVA: 0x000B0F98 File Offset: 0x000AF198
		private void Resetrewardcount()
		{
			this.rewardcountSpecified = false;
		}

		// Token: 0x17001D1B RID: 7451
		// (get) Token: 0x06005CDF RID: 23775 RVA: 0x000B0FA4 File Offset: 0x000AF1A4
		// (set) Token: 0x06005CE0 RID: 23776 RVA: 0x000B0FBC File Offset: 0x000AF1BC
		[ProtoMember(3, IsRequired = false, Name = "seasondata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkBaseHist seasondata
		{
			get
			{
				return this._seasondata;
			}
			set
			{
				this._seasondata = value;
			}
		}

		// Token: 0x17001D1C RID: 7452
		// (get) Token: 0x06005CE1 RID: 23777 RVA: 0x000B0FC8 File Offset: 0x000AF1C8
		[ProtoMember(4, Name = "recs", DataFormat = DataFormat.Default)]
		public List<PkOneRec> recs
		{
			get
			{
				return this._recs;
			}
		}

		// Token: 0x06005CE2 RID: 23778 RVA: 0x000B0FE0 File Offset: 0x000AF1E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400168E RID: 5774
		private uint? _point;

		// Token: 0x0400168F RID: 5775
		private uint? _rewardcount;

		// Token: 0x04001690 RID: 5776
		private PkBaseHist _seasondata = null;

		// Token: 0x04001691 RID: 5777
		private readonly List<PkOneRec> _recs = new List<PkOneRec>();

		// Token: 0x04001692 RID: 5778
		private IExtension extensionObject;
	}
}
