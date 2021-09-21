using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200015F RID: 351
	[ProtoContract(Name = "FMBRes")]
	[Serializable]
	public class FMBRes : IExtensible
	{
		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06001561 RID: 5473 RVA: 0x0002AFD0 File Offset: 0x000291D0
		// (set) Token: 0x06001562 RID: 5474 RVA: 0x0002AFFC File Offset: 0x000291FC
		[ProtoMember(1, IsRequired = false, Name = "refuse", DataFormat = DataFormat.Default)]
		public bool refuse
		{
			get
			{
				return this._refuse ?? false;
			}
			set
			{
				this._refuse = new bool?(value);
			}
		}

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06001563 RID: 5475 RVA: 0x0002B00C File Offset: 0x0002920C
		// (set) Token: 0x06001564 RID: 5476 RVA: 0x0002B02C File Offset: 0x0002922C
		[XmlIgnore]
		[Browsable(false)]
		public bool refuseSpecified
		{
			get
			{
				return this._refuse != null;
			}
			set
			{
				bool flag = value == (this._refuse == null);
				if (flag)
				{
					this._refuse = (value ? new bool?(this.refuse) : null);
				}
			}
		}

		// Token: 0x06001565 RID: 5477 RVA: 0x0002B070 File Offset: 0x00029270
		private bool ShouldSerializerefuse()
		{
			return this.refuseSpecified;
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x0002B088 File Offset: 0x00029288
		private void Resetrefuse()
		{
			this.refuseSpecified = false;
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x0002B094 File Offset: 0x00029294
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400054F RID: 1359
		private bool? _refuse;

		// Token: 0x04000550 RID: 1360
		private IExtension extensionObject;
	}
}
