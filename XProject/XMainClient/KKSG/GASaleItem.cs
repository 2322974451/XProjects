using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C4 RID: 1732
	[ProtoContract(Name = "GASaleItem")]
	[Serializable]
	public class GASaleItem : IExtensible
	{
		// Token: 0x17002409 RID: 9225
		// (get) Token: 0x060071D7 RID: 29143 RVA: 0x000D9CB0 File Offset: 0x000D7EB0
		// (set) Token: 0x060071D8 RID: 29144 RVA: 0x000D9CDD File Offset: 0x000D7EDD
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x1700240A RID: 9226
		// (get) Token: 0x060071D9 RID: 29145 RVA: 0x000D9CEC File Offset: 0x000D7EEC
		// (set) Token: 0x060071DA RID: 29146 RVA: 0x000D9D0C File Offset: 0x000D7F0C
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x060071DB RID: 29147 RVA: 0x000D9D50 File Offset: 0x000D7F50
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060071DC RID: 29148 RVA: 0x000D9D68 File Offset: 0x000D7F68
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x1700240B RID: 9227
		// (get) Token: 0x060071DD RID: 29149 RVA: 0x000D9D74 File Offset: 0x000D7F74
		// (set) Token: 0x060071DE RID: 29150 RVA: 0x000D9DA0 File Offset: 0x000D7FA0
		[ProtoMember(2, IsRequired = false, Name = "acttype", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700240C RID: 9228
		// (get) Token: 0x060071DF RID: 29151 RVA: 0x000D9DB0 File Offset: 0x000D7FB0
		// (set) Token: 0x060071E0 RID: 29152 RVA: 0x000D9DD0 File Offset: 0x000D7FD0
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

		// Token: 0x060071E1 RID: 29153 RVA: 0x000D9E14 File Offset: 0x000D8014
		private bool ShouldSerializeacttype()
		{
			return this.acttypeSpecified;
		}

		// Token: 0x060071E2 RID: 29154 RVA: 0x000D9E2C File Offset: 0x000D802C
		private void Resetacttype()
		{
			this.acttypeSpecified = false;
		}

		// Token: 0x1700240D RID: 9229
		// (get) Token: 0x060071E3 RID: 29155 RVA: 0x000D9E38 File Offset: 0x000D8038
		// (set) Token: 0x060071E4 RID: 29156 RVA: 0x000D9E64 File Offset: 0x000D8064
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

		// Token: 0x1700240E RID: 9230
		// (get) Token: 0x060071E5 RID: 29157 RVA: 0x000D9E74 File Offset: 0x000D8074
		// (set) Token: 0x060071E6 RID: 29158 RVA: 0x000D9E94 File Offset: 0x000D8094
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

		// Token: 0x060071E7 RID: 29159 RVA: 0x000D9ED8 File Offset: 0x000D80D8
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x060071E8 RID: 29160 RVA: 0x000D9EF0 File Offset: 0x000D80F0
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x1700240F RID: 9231
		// (get) Token: 0x060071E9 RID: 29161 RVA: 0x000D9EFC File Offset: 0x000D80FC
		// (set) Token: 0x060071EA RID: 29162 RVA: 0x000D9F29 File Offset: 0x000D8129
		[ProtoMember(4, IsRequired = false, Name = "auctroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong auctroleid
		{
			get
			{
				return this._auctroleid ?? 0UL;
			}
			set
			{
				this._auctroleid = new ulong?(value);
			}
		}

		// Token: 0x17002410 RID: 9232
		// (get) Token: 0x060071EB RID: 29163 RVA: 0x000D9F38 File Offset: 0x000D8138
		// (set) Token: 0x060071EC RID: 29164 RVA: 0x000D9F58 File Offset: 0x000D8158
		[XmlIgnore]
		[Browsable(false)]
		public bool auctroleidSpecified
		{
			get
			{
				return this._auctroleid != null;
			}
			set
			{
				bool flag = value == (this._auctroleid == null);
				if (flag)
				{
					this._auctroleid = (value ? new ulong?(this.auctroleid) : null);
				}
			}
		}

		// Token: 0x060071ED RID: 29165 RVA: 0x000D9F9C File Offset: 0x000D819C
		private bool ShouldSerializeauctroleid()
		{
			return this.auctroleidSpecified;
		}

		// Token: 0x060071EE RID: 29166 RVA: 0x000D9FB4 File Offset: 0x000D81B4
		private void Resetauctroleid()
		{
			this.auctroleidSpecified = false;
		}

		// Token: 0x17002411 RID: 9233
		// (get) Token: 0x060071EF RID: 29167 RVA: 0x000D9FC0 File Offset: 0x000D81C0
		// (set) Token: 0x060071F0 RID: 29168 RVA: 0x000D9FEC File Offset: 0x000D81EC
		[ProtoMember(5, IsRequired = false, Name = "curauctprice", DataFormat = DataFormat.TwosComplement)]
		public uint curauctprice
		{
			get
			{
				return this._curauctprice ?? 0U;
			}
			set
			{
				this._curauctprice = new uint?(value);
			}
		}

		// Token: 0x17002412 RID: 9234
		// (get) Token: 0x060071F1 RID: 29169 RVA: 0x000D9FFC File Offset: 0x000D81FC
		// (set) Token: 0x060071F2 RID: 29170 RVA: 0x000DA01C File Offset: 0x000D821C
		[XmlIgnore]
		[Browsable(false)]
		public bool curauctpriceSpecified
		{
			get
			{
				return this._curauctprice != null;
			}
			set
			{
				bool flag = value == (this._curauctprice == null);
				if (flag)
				{
					this._curauctprice = (value ? new uint?(this.curauctprice) : null);
				}
			}
		}

		// Token: 0x060071F3 RID: 29171 RVA: 0x000DA060 File Offset: 0x000D8260
		private bool ShouldSerializecurauctprice()
		{
			return this.curauctpriceSpecified;
		}

		// Token: 0x060071F4 RID: 29172 RVA: 0x000DA078 File Offset: 0x000D8278
		private void Resetcurauctprice()
		{
			this.curauctpriceSpecified = false;
		}

		// Token: 0x17002413 RID: 9235
		// (get) Token: 0x060071F5 RID: 29173 RVA: 0x000DA084 File Offset: 0x000D8284
		// (set) Token: 0x060071F6 RID: 29174 RVA: 0x000DA0B0 File Offset: 0x000D82B0
		[ProtoMember(6, IsRequired = false, Name = "maxprice", DataFormat = DataFormat.TwosComplement)]
		public uint maxprice
		{
			get
			{
				return this._maxprice ?? 0U;
			}
			set
			{
				this._maxprice = new uint?(value);
			}
		}

		// Token: 0x17002414 RID: 9236
		// (get) Token: 0x060071F7 RID: 29175 RVA: 0x000DA0C0 File Offset: 0x000D82C0
		// (set) Token: 0x060071F8 RID: 29176 RVA: 0x000DA0E0 File Offset: 0x000D82E0
		[XmlIgnore]
		[Browsable(false)]
		public bool maxpriceSpecified
		{
			get
			{
				return this._maxprice != null;
			}
			set
			{
				bool flag = value == (this._maxprice == null);
				if (flag)
				{
					this._maxprice = (value ? new uint?(this.maxprice) : null);
				}
			}
		}

		// Token: 0x060071F9 RID: 29177 RVA: 0x000DA124 File Offset: 0x000D8324
		private bool ShouldSerializemaxprice()
		{
			return this.maxpriceSpecified;
		}

		// Token: 0x060071FA RID: 29178 RVA: 0x000DA13C File Offset: 0x000D833C
		private void Resetmaxprice()
		{
			this.maxpriceSpecified = false;
		}

		// Token: 0x17002415 RID: 9237
		// (get) Token: 0x060071FB RID: 29179 RVA: 0x000DA148 File Offset: 0x000D8348
		// (set) Token: 0x060071FC RID: 29180 RVA: 0x000DA174 File Offset: 0x000D8374
		[ProtoMember(7, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17002416 RID: 9238
		// (get) Token: 0x060071FD RID: 29181 RVA: 0x000DA184 File Offset: 0x000D8384
		// (set) Token: 0x060071FE RID: 29182 RVA: 0x000DA1A4 File Offset: 0x000D83A4
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x060071FF RID: 29183 RVA: 0x000DA1E8 File Offset: 0x000D83E8
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06007200 RID: 29184 RVA: 0x000DA200 File Offset: 0x000D8400
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x17002417 RID: 9239
		// (get) Token: 0x06007201 RID: 29185 RVA: 0x000DA20C File Offset: 0x000D840C
		// (set) Token: 0x06007202 RID: 29186 RVA: 0x000DA238 File Offset: 0x000D8438
		[ProtoMember(8, IsRequired = false, Name = "display", DataFormat = DataFormat.Default)]
		public bool display
		{
			get
			{
				return this._display ?? false;
			}
			set
			{
				this._display = new bool?(value);
			}
		}

		// Token: 0x17002418 RID: 9240
		// (get) Token: 0x06007203 RID: 29187 RVA: 0x000DA248 File Offset: 0x000D8448
		// (set) Token: 0x06007204 RID: 29188 RVA: 0x000DA268 File Offset: 0x000D8468
		[XmlIgnore]
		[Browsable(false)]
		public bool displaySpecified
		{
			get
			{
				return this._display != null;
			}
			set
			{
				bool flag = value == (this._display == null);
				if (flag)
				{
					this._display = (value ? new bool?(this.display) : null);
				}
			}
		}

		// Token: 0x06007205 RID: 29189 RVA: 0x000DA2AC File Offset: 0x000D84AC
		private bool ShouldSerializedisplay()
		{
			return this.displaySpecified;
		}

		// Token: 0x06007206 RID: 29190 RVA: 0x000DA2C4 File Offset: 0x000D84C4
		private void Resetdisplay()
		{
			this.displaySpecified = false;
		}

		// Token: 0x06007207 RID: 29191 RVA: 0x000DA2D0 File Offset: 0x000D84D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B28 RID: 6952
		private ulong? _uid;

		// Token: 0x04001B29 RID: 6953
		private int? _acttype;

		// Token: 0x04001B2A RID: 6954
		private uint? _itemid;

		// Token: 0x04001B2B RID: 6955
		private ulong? _auctroleid;

		// Token: 0x04001B2C RID: 6956
		private uint? _curauctprice;

		// Token: 0x04001B2D RID: 6957
		private uint? _maxprice;

		// Token: 0x04001B2E RID: 6958
		private uint? _lefttime;

		// Token: 0x04001B2F RID: 6959
		private bool? _display;

		// Token: 0x04001B30 RID: 6960
		private IExtension extensionObject;
	}
}
