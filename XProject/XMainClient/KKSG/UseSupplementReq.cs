using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000EB RID: 235
	[ProtoContract(Name = "UseSupplementReq")]
	[Serializable]
	public class UseSupplementReq : IExtensible
	{
		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06000F05 RID: 3845 RVA: 0x0001F084 File Offset: 0x0001D284
		// (set) Token: 0x06000F06 RID: 3846 RVA: 0x0001F0B1 File Offset: 0x0001D2B1
		[ProtoMember(1, IsRequired = false, Name = "uniqueid", DataFormat = DataFormat.TwosComplement)]
		public ulong uniqueid
		{
			get
			{
				return this._uniqueid ?? 0UL;
			}
			set
			{
				this._uniqueid = new ulong?(value);
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06000F07 RID: 3847 RVA: 0x0001F0C0 File Offset: 0x0001D2C0
		// (set) Token: 0x06000F08 RID: 3848 RVA: 0x0001F0E0 File Offset: 0x0001D2E0
		[XmlIgnore]
		[Browsable(false)]
		public bool uniqueidSpecified
		{
			get
			{
				return this._uniqueid != null;
			}
			set
			{
				bool flag = value == (this._uniqueid == null);
				if (flag)
				{
					this._uniqueid = (value ? new ulong?(this.uniqueid) : null);
				}
			}
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x0001F124 File Offset: 0x0001D324
		private bool ShouldSerializeuniqueid()
		{
			return this.uniqueidSpecified;
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x0001F13C File Offset: 0x0001D33C
		private void Resetuniqueid()
		{
			this.uniqueidSpecified = false;
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000F0B RID: 3851 RVA: 0x0001F148 File Offset: 0x0001D348
		// (set) Token: 0x06000F0C RID: 3852 RVA: 0x0001F174 File Offset: 0x0001D374
		[ProtoMember(2, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x0001F184 File Offset: 0x0001D384
		// (set) Token: 0x06000F0E RID: 3854 RVA: 0x0001F1A4 File Offset: 0x0001D3A4
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

		// Token: 0x06000F0F RID: 3855 RVA: 0x0001F1E8 File Offset: 0x0001D3E8
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x0001F200 File Offset: 0x0001D400
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x0001F20C File Offset: 0x0001D40C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003C7 RID: 967
		private ulong? _uniqueid;

		// Token: 0x040003C8 RID: 968
		private uint? _itemid;

		// Token: 0x040003C9 RID: 969
		private IExtension extensionObject;
	}
}
