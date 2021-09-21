using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D4 RID: 980
	[ProtoContract(Name = "ArenaStarReqArg")]
	[Serializable]
	public class ArenaStarReqArg : IExtensible
	{
		// Token: 0x1700100C RID: 4108
		// (get) Token: 0x06003424 RID: 13348 RVA: 0x0006405C File Offset: 0x0006225C
		// (set) Token: 0x06003425 RID: 13349 RVA: 0x00064088 File Offset: 0x00062288
		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public ArenaStarReqType reqtype
		{
			get
			{
				return this._reqtype ?? ArenaStarReqType.ASRT_ROLEDATA;
			}
			set
			{
				this._reqtype = new ArenaStarReqType?(value);
			}
		}

		// Token: 0x1700100D RID: 4109
		// (get) Token: 0x06003426 RID: 13350 RVA: 0x00064098 File Offset: 0x00062298
		// (set) Token: 0x06003427 RID: 13351 RVA: 0x000640B8 File Offset: 0x000622B8
		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new ArenaStarReqType?(this.reqtype) : null);
				}
			}
		}

		// Token: 0x06003428 RID: 13352 RVA: 0x000640FC File Offset: 0x000622FC
		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		// Token: 0x06003429 RID: 13353 RVA: 0x00064114 File Offset: 0x00062314
		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		// Token: 0x1700100E RID: 4110
		// (get) Token: 0x0600342A RID: 13354 RVA: 0x00064120 File Offset: 0x00062320
		// (set) Token: 0x0600342B RID: 13355 RVA: 0x0006414D File Offset: 0x0006234D
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x1700100F RID: 4111
		// (get) Token: 0x0600342C RID: 13356 RVA: 0x0006415C File Offset: 0x0006235C
		// (set) Token: 0x0600342D RID: 13357 RVA: 0x0006417C File Offset: 0x0006237C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x0600342E RID: 13358 RVA: 0x000641C0 File Offset: 0x000623C0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600342F RID: 13359 RVA: 0x000641D8 File Offset: 0x000623D8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001010 RID: 4112
		// (get) Token: 0x06003430 RID: 13360 RVA: 0x000641E4 File Offset: 0x000623E4
		// (set) Token: 0x06003431 RID: 13361 RVA: 0x00064210 File Offset: 0x00062410
		[ProtoMember(3, IsRequired = false, Name = "zantype", DataFormat = DataFormat.TwosComplement)]
		public ArenaStarType zantype
		{
			get
			{
				return this._zantype ?? ArenaStarType.AST_PK;
			}
			set
			{
				this._zantype = new ArenaStarType?(value);
			}
		}

		// Token: 0x17001011 RID: 4113
		// (get) Token: 0x06003432 RID: 13362 RVA: 0x00064220 File Offset: 0x00062420
		// (set) Token: 0x06003433 RID: 13363 RVA: 0x00064240 File Offset: 0x00062440
		[XmlIgnore]
		[Browsable(false)]
		public bool zantypeSpecified
		{
			get
			{
				return this._zantype != null;
			}
			set
			{
				bool flag = value == (this._zantype == null);
				if (flag)
				{
					this._zantype = (value ? new ArenaStarType?(this.zantype) : null);
				}
			}
		}

		// Token: 0x06003434 RID: 13364 RVA: 0x00064284 File Offset: 0x00062484
		private bool ShouldSerializezantype()
		{
			return this.zantypeSpecified;
		}

		// Token: 0x06003435 RID: 13365 RVA: 0x0006429C File Offset: 0x0006249C
		private void Resetzantype()
		{
			this.zantypeSpecified = false;
		}

		// Token: 0x06003436 RID: 13366 RVA: 0x000642A8 File Offset: 0x000624A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CF4 RID: 3316
		private ArenaStarReqType? _reqtype;

		// Token: 0x04000CF5 RID: 3317
		private ulong? _roleid;

		// Token: 0x04000CF6 RID: 3318
		private ArenaStarType? _zantype;

		// Token: 0x04000CF7 RID: 3319
		private IExtension extensionObject;
	}
}
