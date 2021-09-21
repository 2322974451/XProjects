using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C5 RID: 1733
	[ProtoContract(Name = "GASaleHistory")]
	[Serializable]
	public class GASaleHistory : IExtensible
	{
		// Token: 0x17002419 RID: 9241
		// (get) Token: 0x06007209 RID: 29193 RVA: 0x000DA2F0 File Offset: 0x000D84F0
		// (set) Token: 0x0600720A RID: 29194 RVA: 0x000DA31C File Offset: 0x000D851C
		[ProtoMember(1, IsRequired = false, Name = "acttype", DataFormat = DataFormat.TwosComplement)]
		public int acttype
		{
			get
			{
				return this._acttype ?? 0;
			}
			set
			{
				this._acttype = new int?(value);
			}
		}

		// Token: 0x1700241A RID: 9242
		// (get) Token: 0x0600720B RID: 29195 RVA: 0x000DA32C File Offset: 0x000D852C
		// (set) Token: 0x0600720C RID: 29196 RVA: 0x000DA34C File Offset: 0x000D854C
		[XmlIgnore]
		[Browsable(false)]
		public bool acttypeSpecified
		{
			get
			{
				return this._acttype != null;
			}
			set
			{
				bool flag = value == (this._acttype == null);
				if (flag)
				{
					this._acttype = (value ? new int?(this.acttype) : null);
				}
			}
		}

		// Token: 0x0600720D RID: 29197 RVA: 0x000DA390 File Offset: 0x000D8590
		private bool ShouldSerializeacttype()
		{
			return this.acttypeSpecified;
		}

		// Token: 0x0600720E RID: 29198 RVA: 0x000DA3A8 File Offset: 0x000D85A8
		private void Resetacttype()
		{
			this.acttypeSpecified = false;
		}

		// Token: 0x1700241B RID: 9243
		// (get) Token: 0x0600720F RID: 29199 RVA: 0x000DA3B4 File Offset: 0x000D85B4
		// (set) Token: 0x06007210 RID: 29200 RVA: 0x000DA3E0 File Offset: 0x000D85E0
		[ProtoMember(2, IsRequired = false, Name = "saletime", DataFormat = DataFormat.TwosComplement)]
		public uint saletime
		{
			get
			{
				return this._saletime ?? 0U;
			}
			set
			{
				this._saletime = new uint?(value);
			}
		}

		// Token: 0x1700241C RID: 9244
		// (get) Token: 0x06007211 RID: 29201 RVA: 0x000DA3F0 File Offset: 0x000D85F0
		// (set) Token: 0x06007212 RID: 29202 RVA: 0x000DA410 File Offset: 0x000D8610
		[XmlIgnore]
		[Browsable(false)]
		public bool saletimeSpecified
		{
			get
			{
				return this._saletime != null;
			}
			set
			{
				bool flag = value == (this._saletime == null);
				if (flag)
				{
					this._saletime = (value ? new uint?(this.saletime) : null);
				}
			}
		}

		// Token: 0x06007213 RID: 29203 RVA: 0x000DA454 File Offset: 0x000D8654
		private bool ShouldSerializesaletime()
		{
			return this.saletimeSpecified;
		}

		// Token: 0x06007214 RID: 29204 RVA: 0x000DA46C File Offset: 0x000D866C
		private void Resetsaletime()
		{
			this.saletimeSpecified = false;
		}

		// Token: 0x1700241D RID: 9245
		// (get) Token: 0x06007215 RID: 29205 RVA: 0x000DA478 File Offset: 0x000D8678
		// (set) Token: 0x06007216 RID: 29206 RVA: 0x000DA4A4 File Offset: 0x000D86A4
		[ProtoMember(3, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x1700241E RID: 9246
		// (get) Token: 0x06007217 RID: 29207 RVA: 0x000DA4B4 File Offset: 0x000D86B4
		// (set) Token: 0x06007218 RID: 29208 RVA: 0x000DA4D4 File Offset: 0x000D86D4
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06007219 RID: 29209 RVA: 0x000DA518 File Offset: 0x000D8718
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x0600721A RID: 29210 RVA: 0x000DA530 File Offset: 0x000D8730
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x1700241F RID: 9247
		// (get) Token: 0x0600721B RID: 29211 RVA: 0x000DA53C File Offset: 0x000D873C
		// (set) Token: 0x0600721C RID: 29212 RVA: 0x000DA568 File Offset: 0x000D8768
		[ProtoMember(4, IsRequired = false, Name = "saleprice", DataFormat = DataFormat.TwosComplement)]
		public uint saleprice
		{
			get
			{
				return this._saleprice ?? 0U;
			}
			set
			{
				this._saleprice = new uint?(value);
			}
		}

		// Token: 0x17002420 RID: 9248
		// (get) Token: 0x0600721D RID: 29213 RVA: 0x000DA578 File Offset: 0x000D8778
		// (set) Token: 0x0600721E RID: 29214 RVA: 0x000DA598 File Offset: 0x000D8798
		[XmlIgnore]
		[Browsable(false)]
		public bool salepriceSpecified
		{
			get
			{
				return this._saleprice != null;
			}
			set
			{
				bool flag = value == (this._saleprice == null);
				if (flag)
				{
					this._saleprice = (value ? new uint?(this.saleprice) : null);
				}
			}
		}

		// Token: 0x0600721F RID: 29215 RVA: 0x000DA5DC File Offset: 0x000D87DC
		private bool ShouldSerializesaleprice()
		{
			return this.salepriceSpecified;
		}

		// Token: 0x06007220 RID: 29216 RVA: 0x000DA5F4 File Offset: 0x000D87F4
		private void Resetsaleprice()
		{
			this.salepriceSpecified = false;
		}

		// Token: 0x17002421 RID: 9249
		// (get) Token: 0x06007221 RID: 29217 RVA: 0x000DA600 File Offset: 0x000D8800
		// (set) Token: 0x06007222 RID: 29218 RVA: 0x000DA62C File Offset: 0x000D882C
		[ProtoMember(5, IsRequired = false, Name = "auctresult", DataFormat = DataFormat.TwosComplement)]
		public GuildAuctResultType auctresult
		{
			get
			{
				return this._auctresult ?? GuildAuctResultType.GA_RESULT_BUY_NOW;
			}
			set
			{
				this._auctresult = new GuildAuctResultType?(value);
			}
		}

		// Token: 0x17002422 RID: 9250
		// (get) Token: 0x06007223 RID: 29219 RVA: 0x000DA63C File Offset: 0x000D883C
		// (set) Token: 0x06007224 RID: 29220 RVA: 0x000DA65C File Offset: 0x000D885C
		[XmlIgnore]
		[Browsable(false)]
		public bool auctresultSpecified
		{
			get
			{
				return this._auctresult != null;
			}
			set
			{
				bool flag = value == (this._auctresult == null);
				if (flag)
				{
					this._auctresult = (value ? new GuildAuctResultType?(this.auctresult) : null);
				}
			}
		}

		// Token: 0x06007225 RID: 29221 RVA: 0x000DA6A0 File Offset: 0x000D88A0
		private bool ShouldSerializeauctresult()
		{
			return this.auctresultSpecified;
		}

		// Token: 0x06007226 RID: 29222 RVA: 0x000DA6B8 File Offset: 0x000D88B8
		private void Resetauctresult()
		{
			this.auctresultSpecified = false;
		}

		// Token: 0x06007227 RID: 29223 RVA: 0x000DA6C4 File Offset: 0x000D88C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B31 RID: 6961
		private int? _acttype;

		// Token: 0x04001B32 RID: 6962
		private uint? _saletime;

		// Token: 0x04001B33 RID: 6963
		private uint? _itemid;

		// Token: 0x04001B34 RID: 6964
		private uint? _saleprice;

		// Token: 0x04001B35 RID: 6965
		private GuildAuctResultType? _auctresult;

		// Token: 0x04001B36 RID: 6966
		private IExtension extensionObject;
	}
}
