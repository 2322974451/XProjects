using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004C4 RID: 1220
	[ProtoContract(Name = "BuyDragonGuildShopItemArg")]
	[Serializable]
	public class BuyDragonGuildShopItemArg : IExtensible
	{
		// Token: 0x17001376 RID: 4982
		// (get) Token: 0x06003F81 RID: 16257 RVA: 0x00079108 File Offset: 0x00077308
		// (set) Token: 0x06003F82 RID: 16258 RVA: 0x00079134 File Offset: 0x00077334
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17001377 RID: 4983
		// (get) Token: 0x06003F83 RID: 16259 RVA: 0x00079144 File Offset: 0x00077344
		// (set) Token: 0x06003F84 RID: 16260 RVA: 0x00079164 File Offset: 0x00077364
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06003F85 RID: 16261 RVA: 0x000791A8 File Offset: 0x000773A8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06003F86 RID: 16262 RVA: 0x000791C0 File Offset: 0x000773C0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001378 RID: 4984
		// (get) Token: 0x06003F87 RID: 16263 RVA: 0x000791CC File Offset: 0x000773CC
		// (set) Token: 0x06003F88 RID: 16264 RVA: 0x000791F8 File Offset: 0x000773F8
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17001379 RID: 4985
		// (get) Token: 0x06003F89 RID: 16265 RVA: 0x00079208 File Offset: 0x00077408
		// (set) Token: 0x06003F8A RID: 16266 RVA: 0x00079228 File Offset: 0x00077428
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06003F8B RID: 16267 RVA: 0x0007926C File Offset: 0x0007746C
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06003F8C RID: 16268 RVA: 0x00079284 File Offset: 0x00077484
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06003F8D RID: 16269 RVA: 0x00079290 File Offset: 0x00077490
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FD0 RID: 4048
		private uint? _id;

		// Token: 0x04000FD1 RID: 4049
		private uint? _count;

		// Token: 0x04000FD2 RID: 4050
		private IExtension extensionObject;
	}
}
