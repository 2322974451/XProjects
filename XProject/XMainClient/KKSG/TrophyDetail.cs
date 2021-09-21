using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F5 RID: 1525
	[ProtoContract(Name = "TrophyDetail")]
	[Serializable]
	public class TrophyDetail : IExtensible
	{
		// Token: 0x17001C5F RID: 7263
		// (get) Token: 0x06005ABE RID: 23230 RVA: 0x000ACC68 File Offset: 0x000AAE68
		// (set) Token: 0x06005ABF RID: 23231 RVA: 0x000ACC94 File Offset: 0x000AAE94
		[ProtoMember(1, IsRequired = false, Name = "tropy_order", DataFormat = DataFormat.TwosComplement)]
		public uint tropy_order
		{
			get
			{
				return this._tropy_order ?? 0U;
			}
			set
			{
				this._tropy_order = new uint?(value);
			}
		}

		// Token: 0x17001C60 RID: 7264
		// (get) Token: 0x06005AC0 RID: 23232 RVA: 0x000ACCA4 File Offset: 0x000AAEA4
		// (set) Token: 0x06005AC1 RID: 23233 RVA: 0x000ACCC4 File Offset: 0x000AAEC4
		[XmlIgnore]
		[Browsable(false)]
		public bool tropy_orderSpecified
		{
			get
			{
				return this._tropy_order != null;
			}
			set
			{
				bool flag = value == (this._tropy_order == null);
				if (flag)
				{
					this._tropy_order = (value ? new uint?(this.tropy_order) : null);
				}
			}
		}

		// Token: 0x06005AC2 RID: 23234 RVA: 0x000ACD08 File Offset: 0x000AAF08
		private bool ShouldSerializetropy_order()
		{
			return this.tropy_orderSpecified;
		}

		// Token: 0x06005AC3 RID: 23235 RVA: 0x000ACD20 File Offset: 0x000AAF20
		private void Resettropy_order()
		{
			this.tropy_orderSpecified = false;
		}

		// Token: 0x17001C61 RID: 7265
		// (get) Token: 0x06005AC4 RID: 23236 RVA: 0x000ACD2C File Offset: 0x000AAF2C
		// (set) Token: 0x06005AC5 RID: 23237 RVA: 0x000ACD58 File Offset: 0x000AAF58
		[ProtoMember(2, IsRequired = false, Name = "trophy_time", DataFormat = DataFormat.TwosComplement)]
		public uint trophy_time
		{
			get
			{
				return this._trophy_time ?? 0U;
			}
			set
			{
				this._trophy_time = new uint?(value);
			}
		}

		// Token: 0x17001C62 RID: 7266
		// (get) Token: 0x06005AC6 RID: 23238 RVA: 0x000ACD68 File Offset: 0x000AAF68
		// (set) Token: 0x06005AC7 RID: 23239 RVA: 0x000ACD88 File Offset: 0x000AAF88
		[XmlIgnore]
		[Browsable(false)]
		public bool trophy_timeSpecified
		{
			get
			{
				return this._trophy_time != null;
			}
			set
			{
				bool flag = value == (this._trophy_time == null);
				if (flag)
				{
					this._trophy_time = (value ? new uint?(this.trophy_time) : null);
				}
			}
		}

		// Token: 0x06005AC8 RID: 23240 RVA: 0x000ACDCC File Offset: 0x000AAFCC
		private bool ShouldSerializetrophy_time()
		{
			return this.trophy_timeSpecified;
		}

		// Token: 0x06005AC9 RID: 23241 RVA: 0x000ACDE4 File Offset: 0x000AAFE4
		private void Resettrophy_time()
		{
			this.trophy_timeSpecified = false;
		}

		// Token: 0x06005ACA RID: 23242 RVA: 0x000ACDF0 File Offset: 0x000AAFF0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001614 RID: 5652
		private uint? _tropy_order;

		// Token: 0x04001615 RID: 5653
		private uint? _trophy_time;

		// Token: 0x04001616 RID: 5654
		private IExtension extensionObject;
	}
}
