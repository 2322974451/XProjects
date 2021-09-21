using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200003E RID: 62
	[ProtoContract(Name = "UseItemRes")]
	[Serializable]
	public class UseItemRes : IExtensible
	{
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x0000AC6C File Offset: 0x00008E6C
		// (set) Token: 0x06000439 RID: 1081 RVA: 0x0000AC98 File Offset: 0x00008E98
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x0000ACA8 File Offset: 0x00008EA8
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x0000ACC8 File Offset: 0x00008EC8
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x0000AD0C File Offset: 0x00008F0C
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x0000AD24 File Offset: 0x00008F24
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x0000AD30 File Offset: 0x00008F30
		[ProtoMember(2, Name = "ResultItems", DataFormat = DataFormat.Default)]
		public List<ItemBrief> ResultItems
		{
			get
			{
				return this._ResultItems;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0000AD48 File Offset: 0x00008F48
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x0000AD75 File Offset: 0x00008F75
		[ProtoMember(3, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000AD84 File Offset: 0x00008F84
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x0000ADA4 File Offset: 0x00008FA4
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

		// Token: 0x06000443 RID: 1091 RVA: 0x0000ADE8 File Offset: 0x00008FE8
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x0000AE00 File Offset: 0x00009000
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000AE0C File Offset: 0x0000900C
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x0000AE24 File Offset: 0x00009024
		[ProtoMember(4, IsRequired = false, Name = "expand", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BagExpandData expand
		{
			get
			{
				return this._expand;
			}
			set
			{
				this._expand = value;
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000AE30 File Offset: 0x00009030
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400011A RID: 282
		private ErrorCode? _ErrorCode;

		// Token: 0x0400011B RID: 283
		private readonly List<ItemBrief> _ResultItems = new List<ItemBrief>();

		// Token: 0x0400011C RID: 284
		private ulong? _uid;

		// Token: 0x0400011D RID: 285
		private BagExpandData _expand = null;

		// Token: 0x0400011E RID: 286
		private IExtension extensionObject;
	}
}
