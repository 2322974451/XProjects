using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002AC RID: 684
	[ProtoContract(Name = "UseGuildBuffArg")]
	[Serializable]
	public class UseGuildBuffArg : IExtensible
	{
		// Token: 0x17000BD6 RID: 3030
		// (get) Token: 0x06002612 RID: 9746 RVA: 0x0004A198 File Offset: 0x00048398
		// (set) Token: 0x06002613 RID: 9747 RVA: 0x0004A1C4 File Offset: 0x000483C4
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

		// Token: 0x17000BD7 RID: 3031
		// (get) Token: 0x06002614 RID: 9748 RVA: 0x0004A1D4 File Offset: 0x000483D4
		// (set) Token: 0x06002615 RID: 9749 RVA: 0x0004A1F4 File Offset: 0x000483F4
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

		// Token: 0x06002616 RID: 9750 RVA: 0x0004A238 File Offset: 0x00048438
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06002617 RID: 9751 RVA: 0x0004A250 File Offset: 0x00048450
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x17000BD8 RID: 3032
		// (get) Token: 0x06002618 RID: 9752 RVA: 0x0004A25C File Offset: 0x0004845C
		// (set) Token: 0x06002619 RID: 9753 RVA: 0x0004A289 File Offset: 0x00048489
		[ProtoMember(2, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17000BD9 RID: 3033
		// (get) Token: 0x0600261A RID: 9754 RVA: 0x0004A298 File Offset: 0x00048498
		// (set) Token: 0x0600261B RID: 9755 RVA: 0x0004A2B8 File Offset: 0x000484B8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x0600261C RID: 9756 RVA: 0x0004A2FC File Offset: 0x000484FC
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x0600261D RID: 9757 RVA: 0x0004A314 File Offset: 0x00048514
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x0600261E RID: 9758 RVA: 0x0004A320 File Offset: 0x00048520
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000971 RID: 2417
		private uint? _itemid;

		// Token: 0x04000972 RID: 2418
		private ulong? _guildid;

		// Token: 0x04000973 RID: 2419
		private IExtension extensionObject;
	}
}
