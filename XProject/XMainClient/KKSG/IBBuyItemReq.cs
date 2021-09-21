using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F6 RID: 502
	[ProtoContract(Name = "IBBuyItemReq")]
	[Serializable]
	public class IBBuyItemReq : IExtensible
	{
		// Token: 0x170008F4 RID: 2292
		// (get) Token: 0x06001C9A RID: 7322 RVA: 0x000385B0 File Offset: 0x000367B0
		// (set) Token: 0x06001C9B RID: 7323 RVA: 0x000385DC File Offset: 0x000367DC
		[ProtoMember(1, IsRequired = false, Name = "goodsid", DataFormat = DataFormat.TwosComplement)]
		public uint goodsid
		{
			get
			{
				return this._goodsid ?? 0U;
			}
			set
			{
				this._goodsid = new uint?(value);
			}
		}

		// Token: 0x170008F5 RID: 2293
		// (get) Token: 0x06001C9C RID: 7324 RVA: 0x000385EC File Offset: 0x000367EC
		// (set) Token: 0x06001C9D RID: 7325 RVA: 0x0003860C File Offset: 0x0003680C
		[XmlIgnore]
		[Browsable(false)]
		public bool goodsidSpecified
		{
			get
			{
				return this._goodsid != null;
			}
			set
			{
				bool flag = value == (this._goodsid == null);
				if (flag)
				{
					this._goodsid = (value ? new uint?(this.goodsid) : null);
				}
			}
		}

		// Token: 0x06001C9E RID: 7326 RVA: 0x00038650 File Offset: 0x00036850
		private bool ShouldSerializegoodsid()
		{
			return this.goodsidSpecified;
		}

		// Token: 0x06001C9F RID: 7327 RVA: 0x00038668 File Offset: 0x00036868
		private void Resetgoodsid()
		{
			this.goodsidSpecified = false;
		}

		// Token: 0x170008F6 RID: 2294
		// (get) Token: 0x06001CA0 RID: 7328 RVA: 0x00038674 File Offset: 0x00036874
		// (set) Token: 0x06001CA1 RID: 7329 RVA: 0x000386A0 File Offset: 0x000368A0
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x170008F7 RID: 2295
		// (get) Token: 0x06001CA2 RID: 7330 RVA: 0x000386B0 File Offset: 0x000368B0
		// (set) Token: 0x06001CA3 RID: 7331 RVA: 0x000386D0 File Offset: 0x000368D0
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x00038714 File Offset: 0x00036914
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06001CA5 RID: 7333 RVA: 0x0003872C File Offset: 0x0003692C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x00038738 File Offset: 0x00036938
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400071E RID: 1822
		private uint? _goodsid;

		// Token: 0x0400071F RID: 1823
		private uint? _count;

		// Token: 0x04000720 RID: 1824
		private IExtension extensionObject;
	}
}
