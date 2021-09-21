using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200054F RID: 1359
	[ProtoContract(Name = "BuyJadeSlotNewArg")]
	[Serializable]
	public class BuyJadeSlotNewArg : IExtensible
	{
		// Token: 0x17001541 RID: 5441
		// (get) Token: 0x06004590 RID: 17808 RVA: 0x000843B0 File Offset: 0x000825B0
		// (set) Token: 0x06004591 RID: 17809 RVA: 0x000843D1 File Offset: 0x000825D1
		[ProtoMember(1, IsRequired = false, Name = "EquipUId", DataFormat = DataFormat.Default)]
		public string EquipUId
		{
			get
			{
				return this._EquipUId ?? "";
			}
			set
			{
				this._EquipUId = value;
			}
		}

		// Token: 0x17001542 RID: 5442
		// (get) Token: 0x06004592 RID: 17810 RVA: 0x000843DC File Offset: 0x000825DC
		// (set) Token: 0x06004593 RID: 17811 RVA: 0x000843F8 File Offset: 0x000825F8
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
					this._EquipUId = (value ? this.EquipUId : null);
				}
			}
		}

		// Token: 0x06004594 RID: 17812 RVA: 0x00084428 File Offset: 0x00082628
		private bool ShouldSerializeEquipUId()
		{
			return this.EquipUIdSpecified;
		}

		// Token: 0x06004595 RID: 17813 RVA: 0x00084440 File Offset: 0x00082640
		private void ResetEquipUId()
		{
			this.EquipUIdSpecified = false;
		}

		// Token: 0x06004596 RID: 17814 RVA: 0x0008444C File Offset: 0x0008264C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400115E RID: 4446
		private string _EquipUId;

		// Token: 0x0400115F RID: 4447
		private IExtension extensionObject;
	}
}
