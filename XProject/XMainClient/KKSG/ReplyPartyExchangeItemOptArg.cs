using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000401 RID: 1025
	[ProtoContract(Name = "ReplyPartyExchangeItemOptArg")]
	[Serializable]
	public class ReplyPartyExchangeItemOptArg : IExtensible
	{
		// Token: 0x170010C8 RID: 4296
		// (get) Token: 0x0600368D RID: 13965 RVA: 0x00068808 File Offset: 0x00066A08
		// (set) Token: 0x0600368E RID: 13966 RVA: 0x00068834 File Offset: 0x00066A34
		[ProtoMember(1, IsRequired = false, Name = "operate_type", DataFormat = DataFormat.TwosComplement)]
		public uint operate_type
		{
			get
			{
				return this._operate_type ?? 0U;
			}
			set
			{
				this._operate_type = new uint?(value);
			}
		}

		// Token: 0x170010C9 RID: 4297
		// (get) Token: 0x0600368F RID: 13967 RVA: 0x00068844 File Offset: 0x00066A44
		// (set) Token: 0x06003690 RID: 13968 RVA: 0x00068864 File Offset: 0x00066A64
		[XmlIgnore]
		[Browsable(false)]
		public bool operate_typeSpecified
		{
			get
			{
				return this._operate_type != null;
			}
			set
			{
				bool flag = value == (this._operate_type == null);
				if (flag)
				{
					this._operate_type = (value ? new uint?(this.operate_type) : null);
				}
			}
		}

		// Token: 0x06003691 RID: 13969 RVA: 0x000688A8 File Offset: 0x00066AA8
		private bool ShouldSerializeoperate_type()
		{
			return this.operate_typeSpecified;
		}

		// Token: 0x06003692 RID: 13970 RVA: 0x000688C0 File Offset: 0x00066AC0
		private void Resetoperate_type()
		{
			this.operate_typeSpecified = false;
		}

		// Token: 0x170010CA RID: 4298
		// (get) Token: 0x06003693 RID: 13971 RVA: 0x000688CC File Offset: 0x00066ACC
		// (set) Token: 0x06003694 RID: 13972 RVA: 0x000688F9 File Offset: 0x00066AF9
		[ProtoMember(2, IsRequired = false, Name = "lauch_role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong lauch_role_id
		{
			get
			{
				return this._lauch_role_id ?? 0UL;
			}
			set
			{
				this._lauch_role_id = new ulong?(value);
			}
		}

		// Token: 0x170010CB RID: 4299
		// (get) Token: 0x06003695 RID: 13973 RVA: 0x00068908 File Offset: 0x00066B08
		// (set) Token: 0x06003696 RID: 13974 RVA: 0x00068928 File Offset: 0x00066B28
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_role_idSpecified
		{
			get
			{
				return this._lauch_role_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_role_id == null);
				if (flag)
				{
					this._lauch_role_id = (value ? new ulong?(this.lauch_role_id) : null);
				}
			}
		}

		// Token: 0x06003697 RID: 13975 RVA: 0x0006896C File Offset: 0x00066B6C
		private bool ShouldSerializelauch_role_id()
		{
			return this.lauch_role_idSpecified;
		}

		// Token: 0x06003698 RID: 13976 RVA: 0x00068984 File Offset: 0x00066B84
		private void Resetlauch_role_id()
		{
			this.lauch_role_idSpecified = false;
		}

		// Token: 0x06003699 RID: 13977 RVA: 0x00068990 File Offset: 0x00066B90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D8A RID: 3466
		private uint? _operate_type;

		// Token: 0x04000D8B RID: 3467
		private ulong? _lauch_role_id;

		// Token: 0x04000D8C RID: 3468
		private IExtension extensionObject;
	}
}
