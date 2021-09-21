using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003CB RID: 971
	[ProtoContract(Name = "GetPlatformShareChestArg")]
	[Serializable]
	public class GetPlatformShareChestArg : IExtensible
	{
		// Token: 0x17000FEF RID: 4079
		// (get) Token: 0x060033BD RID: 13245 RVA: 0x00063520 File Offset: 0x00061720
		// (set) Token: 0x060033BE RID: 13246 RVA: 0x0006354C File Offset: 0x0006174C
		[ProtoMember(1, IsRequired = false, Name = "box_id", DataFormat = DataFormat.TwosComplement)]
		public uint box_id
		{
			get
			{
				return this._box_id ?? 0U;
			}
			set
			{
				this._box_id = new uint?(value);
			}
		}

		// Token: 0x17000FF0 RID: 4080
		// (get) Token: 0x060033BF RID: 13247 RVA: 0x0006355C File Offset: 0x0006175C
		// (set) Token: 0x060033C0 RID: 13248 RVA: 0x0006357C File Offset: 0x0006177C
		[XmlIgnore]
		[Browsable(false)]
		public bool box_idSpecified
		{
			get
			{
				return this._box_id != null;
			}
			set
			{
				bool flag = value == (this._box_id == null);
				if (flag)
				{
					this._box_id = (value ? new uint?(this.box_id) : null);
				}
			}
		}

		// Token: 0x060033C1 RID: 13249 RVA: 0x000635C0 File Offset: 0x000617C0
		private bool ShouldSerializebox_id()
		{
			return this.box_idSpecified;
		}

		// Token: 0x060033C2 RID: 13250 RVA: 0x000635D8 File Offset: 0x000617D8
		private void Resetbox_id()
		{
			this.box_idSpecified = false;
		}

		// Token: 0x17000FF1 RID: 4081
		// (get) Token: 0x060033C3 RID: 13251 RVA: 0x000635E4 File Offset: 0x000617E4
		// (set) Token: 0x060033C4 RID: 13252 RVA: 0x00063605 File Offset: 0x00061805
		[ProtoMember(2, IsRequired = false, Name = "open_key", DataFormat = DataFormat.Default)]
		public string open_key
		{
			get
			{
				return this._open_key ?? "";
			}
			set
			{
				this._open_key = value;
			}
		}

		// Token: 0x17000FF2 RID: 4082
		// (get) Token: 0x060033C5 RID: 13253 RVA: 0x00063610 File Offset: 0x00061810
		// (set) Token: 0x060033C6 RID: 13254 RVA: 0x0006362C File Offset: 0x0006182C
		[XmlIgnore]
		[Browsable(false)]
		public bool open_keySpecified
		{
			get
			{
				return this._open_key != null;
			}
			set
			{
				bool flag = value == (this._open_key == null);
				if (flag)
				{
					this._open_key = (value ? this.open_key : null);
				}
			}
		}

		// Token: 0x060033C7 RID: 13255 RVA: 0x0006365C File Offset: 0x0006185C
		private bool ShouldSerializeopen_key()
		{
			return this.open_keySpecified;
		}

		// Token: 0x060033C8 RID: 13256 RVA: 0x00063674 File Offset: 0x00061874
		private void Resetopen_key()
		{
			this.open_keySpecified = false;
		}

		// Token: 0x17000FF3 RID: 4083
		// (get) Token: 0x060033C9 RID: 13257 RVA: 0x00063680 File Offset: 0x00061880
		// (set) Token: 0x060033CA RID: 13258 RVA: 0x000636AC File Offset: 0x000618AC
		[ProtoMember(3, IsRequired = false, Name = "share_type", DataFormat = DataFormat.TwosComplement)]
		public uint share_type
		{
			get
			{
				return this._share_type ?? 0U;
			}
			set
			{
				this._share_type = new uint?(value);
			}
		}

		// Token: 0x17000FF4 RID: 4084
		// (get) Token: 0x060033CB RID: 13259 RVA: 0x000636BC File Offset: 0x000618BC
		// (set) Token: 0x060033CC RID: 13260 RVA: 0x000636DC File Offset: 0x000618DC
		[XmlIgnore]
		[Browsable(false)]
		public bool share_typeSpecified
		{
			get
			{
				return this._share_type != null;
			}
			set
			{
				bool flag = value == (this._share_type == null);
				if (flag)
				{
					this._share_type = (value ? new uint?(this.share_type) : null);
				}
			}
		}

		// Token: 0x060033CD RID: 13261 RVA: 0x00063720 File Offset: 0x00061920
		private bool ShouldSerializeshare_type()
		{
			return this.share_typeSpecified;
		}

		// Token: 0x060033CE RID: 13262 RVA: 0x00063738 File Offset: 0x00061938
		private void Resetshare_type()
		{
			this.share_typeSpecified = false;
		}

		// Token: 0x060033CF RID: 13263 RVA: 0x00063744 File Offset: 0x00061944
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CDC RID: 3292
		private uint? _box_id;

		// Token: 0x04000CDD RID: 3293
		private string _open_key;

		// Token: 0x04000CDE RID: 3294
		private uint? _share_type;

		// Token: 0x04000CDF RID: 3295
		private IExtension extensionObject;
	}
}
