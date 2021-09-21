using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000584 RID: 1412
	[ProtoContract(Name = "ItemBrief")]
	[Serializable]
	public class ItemBrief : IExtensible
	{
		// Token: 0x17001693 RID: 5779
		// (get) Token: 0x06004988 RID: 18824 RVA: 0x0008BC7C File Offset: 0x00089E7C
		// (set) Token: 0x06004989 RID: 18825 RVA: 0x0008BCA8 File Offset: 0x00089EA8
		[ProtoMember(1, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public uint itemID
		{
			get
			{
				return this._itemID ?? 0U;
			}
			set
			{
				this._itemID = new uint?(value);
			}
		}

		// Token: 0x17001694 RID: 5780
		// (get) Token: 0x0600498A RID: 18826 RVA: 0x0008BCB8 File Offset: 0x00089EB8
		// (set) Token: 0x0600498B RID: 18827 RVA: 0x0008BCD8 File Offset: 0x00089ED8
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new uint?(this.itemID) : null);
				}
			}
		}

		// Token: 0x0600498C RID: 18828 RVA: 0x0008BD1C File Offset: 0x00089F1C
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x0600498D RID: 18829 RVA: 0x0008BD34 File Offset: 0x00089F34
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x17001695 RID: 5781
		// (get) Token: 0x0600498E RID: 18830 RVA: 0x0008BD40 File Offset: 0x00089F40
		// (set) Token: 0x0600498F RID: 18831 RVA: 0x0008BD6C File Offset: 0x00089F6C
		[ProtoMember(2, IsRequired = false, Name = "itemCount", DataFormat = DataFormat.TwosComplement)]
		public uint itemCount
		{
			get
			{
				return this._itemCount ?? 0U;
			}
			set
			{
				this._itemCount = new uint?(value);
			}
		}

		// Token: 0x17001696 RID: 5782
		// (get) Token: 0x06004990 RID: 18832 RVA: 0x0008BD7C File Offset: 0x00089F7C
		// (set) Token: 0x06004991 RID: 18833 RVA: 0x0008BD9C File Offset: 0x00089F9C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemCountSpecified
		{
			get
			{
				return this._itemCount != null;
			}
			set
			{
				bool flag = value == (this._itemCount == null);
				if (flag)
				{
					this._itemCount = (value ? new uint?(this.itemCount) : null);
				}
			}
		}

		// Token: 0x06004992 RID: 18834 RVA: 0x0008BDE0 File Offset: 0x00089FE0
		private bool ShouldSerializeitemCount()
		{
			return this.itemCountSpecified;
		}

		// Token: 0x06004993 RID: 18835 RVA: 0x0008BDF8 File Offset: 0x00089FF8
		private void ResetitemCount()
		{
			this.itemCountSpecified = false;
		}

		// Token: 0x17001697 RID: 5783
		// (get) Token: 0x06004994 RID: 18836 RVA: 0x0008BE04 File Offset: 0x0008A004
		// (set) Token: 0x06004995 RID: 18837 RVA: 0x0008BE30 File Offset: 0x0008A030
		[ProtoMember(3, IsRequired = false, Name = "isbind", DataFormat = DataFormat.Default)]
		public bool isbind
		{
			get
			{
				return this._isbind ?? false;
			}
			set
			{
				this._isbind = new bool?(value);
			}
		}

		// Token: 0x17001698 RID: 5784
		// (get) Token: 0x06004996 RID: 18838 RVA: 0x0008BE40 File Offset: 0x0008A040
		// (set) Token: 0x06004997 RID: 18839 RVA: 0x0008BE60 File Offset: 0x0008A060
		[XmlIgnore]
		[Browsable(false)]
		public bool isbindSpecified
		{
			get
			{
				return this._isbind != null;
			}
			set
			{
				bool flag = value == (this._isbind == null);
				if (flag)
				{
					this._isbind = (value ? new bool?(this.isbind) : null);
				}
			}
		}

		// Token: 0x06004998 RID: 18840 RVA: 0x0008BEA4 File Offset: 0x0008A0A4
		private bool ShouldSerializeisbind()
		{
			return this.isbindSpecified;
		}

		// Token: 0x06004999 RID: 18841 RVA: 0x0008BEBC File Offset: 0x0008A0BC
		private void Resetisbind()
		{
			this.isbindSpecified = false;
		}

		// Token: 0x17001699 RID: 5785
		// (get) Token: 0x0600499A RID: 18842 RVA: 0x0008BEC8 File Offset: 0x0008A0C8
		// (set) Token: 0x0600499B RID: 18843 RVA: 0x0008BEF4 File Offset: 0x0008A0F4
		[ProtoMember(4, IsRequired = false, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public uint cooldown
		{
			get
			{
				return this._cooldown ?? 0U;
			}
			set
			{
				this._cooldown = new uint?(value);
			}
		}

		// Token: 0x1700169A RID: 5786
		// (get) Token: 0x0600499C RID: 18844 RVA: 0x0008BF04 File Offset: 0x0008A104
		// (set) Token: 0x0600499D RID: 18845 RVA: 0x0008BF24 File Offset: 0x0008A124
		[XmlIgnore]
		[Browsable(false)]
		public bool cooldownSpecified
		{
			get
			{
				return this._cooldown != null;
			}
			set
			{
				bool flag = value == (this._cooldown == null);
				if (flag)
				{
					this._cooldown = (value ? new uint?(this.cooldown) : null);
				}
			}
		}

		// Token: 0x0600499E RID: 18846 RVA: 0x0008BF68 File Offset: 0x0008A168
		private bool ShouldSerializecooldown()
		{
			return this.cooldownSpecified;
		}

		// Token: 0x0600499F RID: 18847 RVA: 0x0008BF80 File Offset: 0x0008A180
		private void Resetcooldown()
		{
			this.cooldownSpecified = false;
		}

		// Token: 0x060049A0 RID: 18848 RVA: 0x0008BF8C File Offset: 0x0008A18C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400125B RID: 4699
		private uint? _itemID;

		// Token: 0x0400125C RID: 4700
		private uint? _itemCount;

		// Token: 0x0400125D RID: 4701
		private bool? _isbind;

		// Token: 0x0400125E RID: 4702
		private uint? _cooldown;

		// Token: 0x0400125F RID: 4703
		private IExtension extensionObject;
	}
}
