using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003CF RID: 975
	[ProtoContract(Name = "LoginActivityRes")]
	[Serializable]
	public class LoginActivityRes : IExtensible
	{
		// Token: 0x17001001 RID: 4097
		// (get) Token: 0x060033FB RID: 13307 RVA: 0x00063C20 File Offset: 0x00061E20
		[ProtoMember(1, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17001002 RID: 4098
		// (get) Token: 0x060033FC RID: 13308 RVA: 0x00063C38 File Offset: 0x00061E38
		// (set) Token: 0x060033FD RID: 13309 RVA: 0x00063C64 File Offset: 0x00061E64
		[ProtoMember(2, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001003 RID: 4099
		// (get) Token: 0x060033FE RID: 13310 RVA: 0x00063C74 File Offset: 0x00061E74
		// (set) Token: 0x060033FF RID: 13311 RVA: 0x00063C94 File Offset: 0x00061E94
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

		// Token: 0x06003400 RID: 13312 RVA: 0x00063CD8 File Offset: 0x00061ED8
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06003401 RID: 13313 RVA: 0x00063CF0 File Offset: 0x00061EF0
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06003402 RID: 13314 RVA: 0x00063CFC File Offset: 0x00061EFC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CE9 RID: 3305
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04000CEA RID: 3306
		private ErrorCode? _errcode;

		// Token: 0x04000CEB RID: 3307
		private IExtension extensionObject;
	}
}
