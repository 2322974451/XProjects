using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000484 RID: 1156
	[ProtoContract(Name = "WeddingEventNtf")]
	[Serializable]
	public class WeddingEventNtf : IExtensible
	{
		// Token: 0x17001283 RID: 4739
		// (get) Token: 0x06003C5C RID: 15452 RVA: 0x000734C4 File Offset: 0x000716C4
		// (set) Token: 0x06003C5D RID: 15453 RVA: 0x000734F0 File Offset: 0x000716F0
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingOperType type
		{
			get
			{
				return this._type ?? WeddingOperType.WeddingOper_Flower;
			}
			set
			{
				this._type = new WeddingOperType?(value);
			}
		}

		// Token: 0x17001284 RID: 4740
		// (get) Token: 0x06003C5E RID: 15454 RVA: 0x00073500 File Offset: 0x00071700
		// (set) Token: 0x06003C5F RID: 15455 RVA: 0x00073520 File Offset: 0x00071720
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new WeddingOperType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003C60 RID: 15456 RVA: 0x00073564 File Offset: 0x00071764
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003C61 RID: 15457 RVA: 0x0007357C File Offset: 0x0007177C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001285 RID: 4741
		// (get) Token: 0x06003C62 RID: 15458 RVA: 0x00073588 File Offset: 0x00071788
		// (set) Token: 0x06003C63 RID: 15459 RVA: 0x000735B5 File Offset: 0x000717B5
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

		// Token: 0x17001286 RID: 4742
		// (get) Token: 0x06003C64 RID: 15460 RVA: 0x000735C4 File Offset: 0x000717C4
		// (set) Token: 0x06003C65 RID: 15461 RVA: 0x000735E4 File Offset: 0x000717E4
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

		// Token: 0x06003C66 RID: 15462 RVA: 0x00073628 File Offset: 0x00071828
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003C67 RID: 15463 RVA: 0x00073640 File Offset: 0x00071840
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001287 RID: 4743
		// (get) Token: 0x06003C68 RID: 15464 RVA: 0x0007364C File Offset: 0x0007184C
		// (set) Token: 0x06003C69 RID: 15465 RVA: 0x0007366D File Offset: 0x0007186D
		[ProtoMember(3, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x17001288 RID: 4744
		// (get) Token: 0x06003C6A RID: 15466 RVA: 0x00073678 File Offset: 0x00071878
		// (set) Token: 0x06003C6B RID: 15467 RVA: 0x00073694 File Offset: 0x00071894
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06003C6C RID: 15468 RVA: 0x000736C4 File Offset: 0x000718C4
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06003C6D RID: 15469 RVA: 0x000736DC File Offset: 0x000718DC
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x17001289 RID: 4745
		// (get) Token: 0x06003C6E RID: 15470 RVA: 0x000736E8 File Offset: 0x000718E8
		// (set) Token: 0x06003C6F RID: 15471 RVA: 0x00073714 File Offset: 0x00071914
		[ProtoMember(4, IsRequired = false, Name = "total_num", DataFormat = DataFormat.TwosComplement)]
		public uint total_num
		{
			get
			{
				return this._total_num ?? 0U;
			}
			set
			{
				this._total_num = new uint?(value);
			}
		}

		// Token: 0x1700128A RID: 4746
		// (get) Token: 0x06003C70 RID: 15472 RVA: 0x00073724 File Offset: 0x00071924
		// (set) Token: 0x06003C71 RID: 15473 RVA: 0x00073744 File Offset: 0x00071944
		[XmlIgnore]
		[Browsable(false)]
		public bool total_numSpecified
		{
			get
			{
				return this._total_num != null;
			}
			set
			{
				bool flag = value == (this._total_num == null);
				if (flag)
				{
					this._total_num = (value ? new uint?(this.total_num) : null);
				}
			}
		}

		// Token: 0x06003C72 RID: 15474 RVA: 0x00073788 File Offset: 0x00071988
		private bool ShouldSerializetotal_num()
		{
			return this.total_numSpecified;
		}

		// Token: 0x06003C73 RID: 15475 RVA: 0x000737A0 File Offset: 0x000719A0
		private void Resettotal_num()
		{
			this.total_numSpecified = false;
		}

		// Token: 0x06003C74 RID: 15476 RVA: 0x000737AC File Offset: 0x000719AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F08 RID: 3848
		private WeddingOperType? _type;

		// Token: 0x04000F09 RID: 3849
		private ulong? _roleid;

		// Token: 0x04000F0A RID: 3850
		private string _rolename;

		// Token: 0x04000F0B RID: 3851
		private uint? _total_num;

		// Token: 0x04000F0C RID: 3852
		private IExtension extensionObject;
	}
}
