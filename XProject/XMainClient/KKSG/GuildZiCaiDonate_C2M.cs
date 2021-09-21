using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200053C RID: 1340
	[ProtoContract(Name = "GuildZiCaiDonate_C2M")]
	[Serializable]
	public class GuildZiCaiDonate_C2M : IExtensible
	{
		// Token: 0x170014FD RID: 5373
		// (get) Token: 0x060044A7 RID: 17575 RVA: 0x0008291C File Offset: 0x00080B1C
		// (set) Token: 0x060044A8 RID: 17576 RVA: 0x00082948 File Offset: 0x00080B48
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

		// Token: 0x170014FE RID: 5374
		// (get) Token: 0x060044A9 RID: 17577 RVA: 0x00082958 File Offset: 0x00080B58
		// (set) Token: 0x060044AA RID: 17578 RVA: 0x00082978 File Offset: 0x00080B78
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

		// Token: 0x060044AB RID: 17579 RVA: 0x000829BC File Offset: 0x00080BBC
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x060044AC RID: 17580 RVA: 0x000829D4 File Offset: 0x00080BD4
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x060044AD RID: 17581 RVA: 0x000829E0 File Offset: 0x00080BE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001126 RID: 4390
		private uint? _itemid;

		// Token: 0x04001127 RID: 4391
		private IExtension extensionObject;
	}
}
