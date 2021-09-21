using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200002F RID: 47
	[ProtoContract(Name = "EnhanceItemArg")]
	[Serializable]
	public class EnhanceItemArg : IExtensible
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00008DB0 File Offset: 0x00006FB0
		// (set) Token: 0x06000338 RID: 824 RVA: 0x00008DDD File Offset: 0x00006FDD
		[ProtoMember(1, IsRequired = false, Name = "UniqueItemId", DataFormat = DataFormat.TwosComplement)]
		public ulong UniqueItemId
		{
			get
			{
				return this._UniqueItemId ?? 0UL;
			}
			set
			{
				this._UniqueItemId = new ulong?(value);
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000339 RID: 825 RVA: 0x00008DEC File Offset: 0x00006FEC
		// (set) Token: 0x0600033A RID: 826 RVA: 0x00008E0C File Offset: 0x0000700C
		[XmlIgnore]
		[Browsable(false)]
		public bool UniqueItemIdSpecified
		{
			get
			{
				return this._UniqueItemId != null;
			}
			set
			{
				bool flag = value == (this._UniqueItemId == null);
				if (flag)
				{
					this._UniqueItemId = (value ? new ulong?(this.UniqueItemId) : null);
				}
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00008E50 File Offset: 0x00007050
		private bool ShouldSerializeUniqueItemId()
		{
			return this.UniqueItemIdSpecified;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00008E68 File Offset: 0x00007068
		private void ResetUniqueItemId()
		{
			this.UniqueItemIdSpecified = false;
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600033D RID: 829 RVA: 0x00008E74 File Offset: 0x00007074
		// (set) Token: 0x0600033E RID: 830 RVA: 0x00008EA0 File Offset: 0x000070A0
		[ProtoMember(2, IsRequired = false, Name = "ProtectType", DataFormat = DataFormat.TwosComplement)]
		public uint ProtectType
		{
			get
			{
				return this._ProtectType ?? 0U;
			}
			set
			{
				this._ProtectType = new uint?(value);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600033F RID: 831 RVA: 0x00008EB0 File Offset: 0x000070B0
		// (set) Token: 0x06000340 RID: 832 RVA: 0x00008ED0 File Offset: 0x000070D0
		[XmlIgnore]
		[Browsable(false)]
		public bool ProtectTypeSpecified
		{
			get
			{
				return this._ProtectType != null;
			}
			set
			{
				bool flag = value == (this._ProtectType == null);
				if (flag)
				{
					this._ProtectType = (value ? new uint?(this.ProtectType) : null);
				}
			}
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00008F14 File Offset: 0x00007114
		private bool ShouldSerializeProtectType()
		{
			return this.ProtectTypeSpecified;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00008F2C File Offset: 0x0000712C
		private void ResetProtectType()
		{
			this.ProtectTypeSpecified = false;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00008F38 File Offset: 0x00007138
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000D9 RID: 217
		private ulong? _UniqueItemId;

		// Token: 0x040000DA RID: 218
		private uint? _ProtectType;

		// Token: 0x040000DB RID: 219
		private IExtension extensionObject;
	}
}
