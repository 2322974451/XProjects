using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F8 RID: 504
	[ProtoContract(Name = "IBQueryItemRes")]
	[Serializable]
	public class IBQueryItemRes : IExtensible
	{
		// Token: 0x170008FA RID: 2298
		// (get) Token: 0x06001CB0 RID: 7344 RVA: 0x0003885C File Offset: 0x00036A5C
		// (set) Token: 0x06001CB1 RID: 7345 RVA: 0x00038888 File Offset: 0x00036A88
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170008FB RID: 2299
		// (get) Token: 0x06001CB2 RID: 7346 RVA: 0x00038898 File Offset: 0x00036A98
		// (set) Token: 0x06001CB3 RID: 7347 RVA: 0x000388B8 File Offset: 0x00036AB8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06001CB4 RID: 7348 RVA: 0x000388FC File Offset: 0x00036AFC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001CB5 RID: 7349 RVA: 0x00038914 File Offset: 0x00036B14
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170008FC RID: 2300
		// (get) Token: 0x06001CB6 RID: 7350 RVA: 0x00038920 File Offset: 0x00036B20
		[ProtoMember(2, Name = "iteminfo", DataFormat = DataFormat.Default)]
		public List<IBShopItemInfo> iteminfo
		{
			get
			{
				return this._iteminfo;
			}
		}

		// Token: 0x170008FD RID: 2301
		// (get) Token: 0x06001CB7 RID: 7351 RVA: 0x00038938 File Offset: 0x00036B38
		[ProtoMember(3, Name = "newproducts", DataFormat = DataFormat.TwosComplement)]
		public List<uint> newproducts
		{
			get
			{
				return this._newproducts;
			}
		}

		// Token: 0x170008FE RID: 2302
		// (get) Token: 0x06001CB8 RID: 7352 RVA: 0x00038950 File Offset: 0x00036B50
		// (set) Token: 0x06001CB9 RID: 7353 RVA: 0x0003897C File Offset: 0x00036B7C
		[ProtoMember(4, IsRequired = false, Name = "viptab", DataFormat = DataFormat.Default)]
		public bool viptab
		{
			get
			{
				return this._viptab ?? false;
			}
			set
			{
				this._viptab = new bool?(value);
			}
		}

		// Token: 0x170008FF RID: 2303
		// (get) Token: 0x06001CBA RID: 7354 RVA: 0x0003898C File Offset: 0x00036B8C
		// (set) Token: 0x06001CBB RID: 7355 RVA: 0x000389AC File Offset: 0x00036BAC
		[XmlIgnore]
		[Browsable(false)]
		public bool viptabSpecified
		{
			get
			{
				return this._viptab != null;
			}
			set
			{
				bool flag = value == (this._viptab == null);
				if (flag)
				{
					this._viptab = (value ? new bool?(this.viptab) : null);
				}
			}
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x000389F0 File Offset: 0x00036BF0
		private bool ShouldSerializeviptab()
		{
			return this.viptabSpecified;
		}

		// Token: 0x06001CBD RID: 7357 RVA: 0x00038A08 File Offset: 0x00036C08
		private void Resetviptab()
		{
			this.viptabSpecified = false;
		}

		// Token: 0x06001CBE RID: 7358 RVA: 0x00038A14 File Offset: 0x00036C14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000723 RID: 1827
		private ErrorCode? _errorcode;

		// Token: 0x04000724 RID: 1828
		private readonly List<IBShopItemInfo> _iteminfo = new List<IBShopItemInfo>();

		// Token: 0x04000725 RID: 1829
		private readonly List<uint> _newproducts = new List<uint>();

		// Token: 0x04000726 RID: 1830
		private bool? _viptab;

		// Token: 0x04000727 RID: 1831
		private IExtension extensionObject;
	}
}
