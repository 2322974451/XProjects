using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F2 RID: 498
	[ProtoContract(Name = "ItemFindBackArg")]
	[Serializable]
	public class ItemFindBackArg : IExtensible
	{
		// Token: 0x170008E6 RID: 2278
		// (get) Token: 0x06001C68 RID: 7272 RVA: 0x00037FD4 File Offset: 0x000361D4
		// (set) Token: 0x06001C69 RID: 7273 RVA: 0x00038000 File Offset: 0x00036200
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ItemFindBackType id
		{
			get
			{
				return this._id ?? ItemFindBackType.TOWER;
			}
			set
			{
				this._id = new ItemFindBackType?(value);
			}
		}

		// Token: 0x170008E7 RID: 2279
		// (get) Token: 0x06001C6A RID: 7274 RVA: 0x00038010 File Offset: 0x00036210
		// (set) Token: 0x06001C6B RID: 7275 RVA: 0x00038030 File Offset: 0x00036230
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
					this._id = (value ? new ItemFindBackType?(this.id) : null);
				}
			}
		}

		// Token: 0x06001C6C RID: 7276 RVA: 0x00038074 File Offset: 0x00036274
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06001C6D RID: 7277 RVA: 0x0003808C File Offset: 0x0003628C
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170008E8 RID: 2280
		// (get) Token: 0x06001C6E RID: 7278 RVA: 0x00038098 File Offset: 0x00036298
		// (set) Token: 0x06001C6F RID: 7279 RVA: 0x000380C4 File Offset: 0x000362C4
		[ProtoMember(2, IsRequired = false, Name = "findBackCount", DataFormat = DataFormat.TwosComplement)]
		public int findBackCount
		{
			get
			{
				return this._findBackCount ?? 0;
			}
			set
			{
				this._findBackCount = new int?(value);
			}
		}

		// Token: 0x170008E9 RID: 2281
		// (get) Token: 0x06001C70 RID: 7280 RVA: 0x000380D4 File Offset: 0x000362D4
		// (set) Token: 0x06001C71 RID: 7281 RVA: 0x000380F4 File Offset: 0x000362F4
		[XmlIgnore]
		[Browsable(false)]
		public bool findBackCountSpecified
		{
			get
			{
				return this._findBackCount != null;
			}
			set
			{
				bool flag = value == (this._findBackCount == null);
				if (flag)
				{
					this._findBackCount = (value ? new int?(this.findBackCount) : null);
				}
			}
		}

		// Token: 0x06001C72 RID: 7282 RVA: 0x00038138 File Offset: 0x00036338
		private bool ShouldSerializefindBackCount()
		{
			return this.findBackCountSpecified;
		}

		// Token: 0x06001C73 RID: 7283 RVA: 0x00038150 File Offset: 0x00036350
		private void ResetfindBackCount()
		{
			this.findBackCountSpecified = false;
		}

		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x06001C74 RID: 7284 RVA: 0x0003815C File Offset: 0x0003635C
		// (set) Token: 0x06001C75 RID: 7285 RVA: 0x00038188 File Offset: 0x00036388
		[ProtoMember(3, IsRequired = false, Name = "backType", DataFormat = DataFormat.TwosComplement)]
		public int backType
		{
			get
			{
				return this._backType ?? 0;
			}
			set
			{
				this._backType = new int?(value);
			}
		}

		// Token: 0x170008EB RID: 2283
		// (get) Token: 0x06001C76 RID: 7286 RVA: 0x00038198 File Offset: 0x00036398
		// (set) Token: 0x06001C77 RID: 7287 RVA: 0x000381B8 File Offset: 0x000363B8
		[XmlIgnore]
		[Browsable(false)]
		public bool backTypeSpecified
		{
			get
			{
				return this._backType != null;
			}
			set
			{
				bool flag = value == (this._backType == null);
				if (flag)
				{
					this._backType = (value ? new int?(this.backType) : null);
				}
			}
		}

		// Token: 0x06001C78 RID: 7288 RVA: 0x000381FC File Offset: 0x000363FC
		private bool ShouldSerializebackType()
		{
			return this.backTypeSpecified;
		}

		// Token: 0x06001C79 RID: 7289 RVA: 0x00038214 File Offset: 0x00036414
		private void ResetbackType()
		{
			this.backTypeSpecified = false;
		}

		// Token: 0x06001C7A RID: 7290 RVA: 0x00038220 File Offset: 0x00036420
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000713 RID: 1811
		private ItemFindBackType? _id;

		// Token: 0x04000714 RID: 1812
		private int? _findBackCount;

		// Token: 0x04000715 RID: 1813
		private int? _backType;

		// Token: 0x04000716 RID: 1814
		private IExtension extensionObject;
	}
}
