using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200004C RID: 76
	[ProtoContract(Name = "BuyJadeSlotArg")]
	[Serializable]
	public class BuyJadeSlotArg : IExtensible
	{
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0000C7BC File Offset: 0x0000A9BC
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x0000C7E9 File Offset: 0x0000A9E9
		[ProtoMember(1, IsRequired = false, Name = "EquipUId", DataFormat = DataFormat.TwosComplement)]
		public ulong EquipUId
		{
			get
			{
				return this._EquipUId ?? 0UL;
			}
			set
			{
				this._EquipUId = new ulong?(value);
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0000C7F8 File Offset: 0x0000A9F8
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x0000C818 File Offset: 0x0000AA18
		[XmlIgnore]
		[Browsable(false)]
		public bool EquipUIdSpecified
		{
			get
			{
				return this._EquipUId != null;
			}
			set
			{
				bool flag = value == (this._EquipUId == null);
				if (flag)
				{
					this._EquipUId = (value ? new ulong?(this.EquipUId) : null);
				}
			}
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0000C85C File Offset: 0x0000AA5C
		private bool ShouldSerializeEquipUId()
		{
			return this.EquipUIdSpecified;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0000C874 File Offset: 0x0000AA74
		private void ResetEquipUId()
		{
			this.EquipUIdSpecified = false;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0000C880 File Offset: 0x0000AA80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000151 RID: 337
		private ulong? _EquipUId;

		// Token: 0x04000152 RID: 338
		private IExtension extensionObject;
	}
}
