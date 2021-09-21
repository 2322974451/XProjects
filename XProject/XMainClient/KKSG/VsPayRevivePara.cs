using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000548 RID: 1352
	[ProtoContract(Name = "VsPayRevivePara")]
	[Serializable]
	public class VsPayRevivePara : IExtensible
	{
		// Token: 0x17001520 RID: 5408
		// (get) Token: 0x06004520 RID: 17696 RVA: 0x000836FC File Offset: 0x000818FC
		// (set) Token: 0x06004521 RID: 17697 RVA: 0x00083728 File Offset: 0x00081928
		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x17001521 RID: 5409
		// (get) Token: 0x06004522 RID: 17698 RVA: 0x00083738 File Offset: 0x00081938
		// (set) Token: 0x06004523 RID: 17699 RVA: 0x00083758 File Offset: 0x00081958
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06004524 RID: 17700 RVA: 0x0008379C File Offset: 0x0008199C
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06004525 RID: 17701 RVA: 0x000837B4 File Offset: 0x000819B4
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17001522 RID: 5410
		// (get) Token: 0x06004526 RID: 17702 RVA: 0x000837C0 File Offset: 0x000819C0
		// (set) Token: 0x06004527 RID: 17703 RVA: 0x000837EC File Offset: 0x000819EC
		[ProtoMember(2, IsRequired = false, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public uint itemcount
		{
			get
			{
				return this._itemcount ?? 0U;
			}
			set
			{
				this._itemcount = new uint?(value);
			}
		}

		// Token: 0x17001523 RID: 5411
		// (get) Token: 0x06004528 RID: 17704 RVA: 0x000837FC File Offset: 0x000819FC
		// (set) Token: 0x06004529 RID: 17705 RVA: 0x0008381C File Offset: 0x00081A1C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemcountSpecified
		{
			get
			{
				return this._itemcount != null;
			}
			set
			{
				bool flag = value == (this._itemcount == null);
				if (flag)
				{
					this._itemcount = (value ? new uint?(this.itemcount) : null);
				}
			}
		}

		// Token: 0x0600452A RID: 17706 RVA: 0x00083860 File Offset: 0x00081A60
		private bool ShouldSerializeitemcount()
		{
			return this.itemcountSpecified;
		}

		// Token: 0x0600452B RID: 17707 RVA: 0x00083878 File Offset: 0x00081A78
		private void Resetitemcount()
		{
			this.itemcountSpecified = false;
		}

		// Token: 0x0600452C RID: 17708 RVA: 0x00083884 File Offset: 0x00081A84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001146 RID: 4422
		private uint? _itemid;

		// Token: 0x04001147 RID: 4423
		private uint? _itemcount;

		// Token: 0x04001148 RID: 4424
		private IExtension extensionObject;
	}
}
