using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000103 RID: 259
	[ProtoContract(Name = "BuyTeamSceneCountRet")]
	[Serializable]
	public class BuyTeamSceneCountRet : IExtensible
	{
		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06001095 RID: 4245 RVA: 0x00021FE4 File Offset: 0x000201E4
		// (set) Token: 0x06001096 RID: 4246 RVA: 0x00022010 File Offset: 0x00020210
		[ProtoMember(1, IsRequired = false, Name = "maxcount", DataFormat = DataFormat.TwosComplement)]
		public uint maxcount
		{
			get
			{
				return this._maxcount ?? 0U;
			}
			set
			{
				this._maxcount = new uint?(value);
			}
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06001097 RID: 4247 RVA: 0x00022020 File Offset: 0x00020220
		// (set) Token: 0x06001098 RID: 4248 RVA: 0x00022040 File Offset: 0x00020240
		[XmlIgnore]
		[Browsable(false)]
		public bool maxcountSpecified
		{
			get
			{
				return this._maxcount != null;
			}
			set
			{
				bool flag = value == (this._maxcount == null);
				if (flag)
				{
					this._maxcount = (value ? new uint?(this.maxcount) : null);
				}
			}
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x00022084 File Offset: 0x00020284
		private bool ShouldSerializemaxcount()
		{
			return this.maxcountSpecified;
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x0002209C File Offset: 0x0002029C
		private void Resetmaxcount()
		{
			this.maxcountSpecified = false;
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x0600109B RID: 4251 RVA: 0x000220A8 File Offset: 0x000202A8
		// (set) Token: 0x0600109C RID: 4252 RVA: 0x000220D4 File Offset: 0x000202D4
		[ProtoMember(2, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public uint buycount
		{
			get
			{
				return this._buycount ?? 0U;
			}
			set
			{
				this._buycount = new uint?(value);
			}
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x0600109D RID: 4253 RVA: 0x000220E4 File Offset: 0x000202E4
		// (set) Token: 0x0600109E RID: 4254 RVA: 0x00022104 File Offset: 0x00020304
		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new uint?(this.buycount) : null);
				}
			}
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x00022148 File Offset: 0x00020348
		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x00022160 File Offset: 0x00020360
		private void Resetbuycount()
		{
			this.buycountSpecified = false;
		}

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x060010A1 RID: 4257 RVA: 0x0002216C File Offset: 0x0002036C
		// (set) Token: 0x060010A2 RID: 4258 RVA: 0x00022198 File Offset: 0x00020398
		[ProtoMember(3, IsRequired = false, Name = "entercount", DataFormat = DataFormat.TwosComplement)]
		public uint entercount
		{
			get
			{
				return this._entercount ?? 0U;
			}
			set
			{
				this._entercount = new uint?(value);
			}
		}

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x060010A3 RID: 4259 RVA: 0x000221A8 File Offset: 0x000203A8
		// (set) Token: 0x060010A4 RID: 4260 RVA: 0x000221C8 File Offset: 0x000203C8
		[XmlIgnore]
		[Browsable(false)]
		public bool entercountSpecified
		{
			get
			{
				return this._entercount != null;
			}
			set
			{
				bool flag = value == (this._entercount == null);
				if (flag)
				{
					this._entercount = (value ? new uint?(this.entercount) : null);
				}
			}
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x0002220C File Offset: 0x0002040C
		private bool ShouldSerializeentercount()
		{
			return this.entercountSpecified;
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x00022224 File Offset: 0x00020424
		private void Resetentercount()
		{
			this.entercountSpecified = false;
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x060010A7 RID: 4263 RVA: 0x00022230 File Offset: 0x00020430
		// (set) Token: 0x060010A8 RID: 4264 RVA: 0x0002225C File Offset: 0x0002045C
		[ProtoMember(4, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x060010A9 RID: 4265 RVA: 0x0002226C File Offset: 0x0002046C
		// (set) Token: 0x060010AA RID: 4266 RVA: 0x0002228C File Offset: 0x0002048C
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x000222D0 File Offset: 0x000204D0
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x000222E8 File Offset: 0x000204E8
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x000222F4 File Offset: 0x000204F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000426 RID: 1062
		private uint? _maxcount;

		// Token: 0x04000427 RID: 1063
		private uint? _buycount;

		// Token: 0x04000428 RID: 1064
		private uint? _entercount;

		// Token: 0x04000429 RID: 1065
		private ErrorCode? _errcode;

		// Token: 0x0400042A RID: 1066
		private IExtension extensionObject;
	}
}
