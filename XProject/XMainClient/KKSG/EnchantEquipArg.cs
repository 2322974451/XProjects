using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000302 RID: 770
	[ProtoContract(Name = "EnchantEquipArg")]
	[Serializable]
	public class EnchantEquipArg : IExtensible
	{
		// Token: 0x17000D0C RID: 3340
		// (get) Token: 0x06002A18 RID: 10776 RVA: 0x000519C4 File Offset: 0x0004FBC4
		// (set) Token: 0x06002A19 RID: 10777 RVA: 0x000519F1 File Offset: 0x0004FBF1
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000D0D RID: 3341
		// (get) Token: 0x06002A1A RID: 10778 RVA: 0x00051A00 File Offset: 0x0004FC00
		// (set) Token: 0x06002A1B RID: 10779 RVA: 0x00051A20 File Offset: 0x0004FC20
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

		// Token: 0x06002A1C RID: 10780 RVA: 0x00051A64 File Offset: 0x0004FC64
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06002A1D RID: 10781 RVA: 0x00051A7C File Offset: 0x0004FC7C
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x17000D0E RID: 3342
		// (get) Token: 0x06002A1E RID: 10782 RVA: 0x00051A88 File Offset: 0x0004FC88
		// (set) Token: 0x06002A1F RID: 10783 RVA: 0x00051AB4 File Offset: 0x0004FCB4
		[ProtoMember(2, IsRequired = false, Name = "enchantid", DataFormat = DataFormat.TwosComplement)]
		public uint enchantid
		{
			get
			{
				return this._enchantid ?? 0U;
			}
			set
			{
				this._enchantid = new uint?(value);
			}
		}

		// Token: 0x17000D0F RID: 3343
		// (get) Token: 0x06002A20 RID: 10784 RVA: 0x00051AC4 File Offset: 0x0004FCC4
		// (set) Token: 0x06002A21 RID: 10785 RVA: 0x00051AE4 File Offset: 0x0004FCE4
		[XmlIgnore]
		[Browsable(false)]
		public bool enchantidSpecified
		{
			get
			{
				return this._enchantid != null;
			}
			set
			{
				bool flag = value == (this._enchantid == null);
				if (flag)
				{
					this._enchantid = (value ? new uint?(this.enchantid) : null);
				}
			}
		}

		// Token: 0x06002A22 RID: 10786 RVA: 0x00051B28 File Offset: 0x0004FD28
		private bool ShouldSerializeenchantid()
		{
			return this.enchantidSpecified;
		}

		// Token: 0x06002A23 RID: 10787 RVA: 0x00051B40 File Offset: 0x0004FD40
		private void Resetenchantid()
		{
			this.enchantidSpecified = false;
		}

		// Token: 0x06002A24 RID: 10788 RVA: 0x00051B4C File Offset: 0x0004FD4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A75 RID: 2677
		private ulong? _uid;

		// Token: 0x04000A76 RID: 2678
		private uint? _enchantid;

		// Token: 0x04000A77 RID: 2679
		private IExtension extensionObject;
	}
}
