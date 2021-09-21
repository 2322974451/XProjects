using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F4 RID: 1012
	[ProtoContract(Name = "IBGiftIcon")]
	[Serializable]
	public class IBGiftIcon : IExtensible
	{
		// Token: 0x1700107D RID: 4221
		// (get) Token: 0x0600359E RID: 13726 RVA: 0x00066BCC File Offset: 0x00064DCC
		// (set) Token: 0x0600359F RID: 13727 RVA: 0x00066BF8 File Offset: 0x00064DF8
		[ProtoMember(1, IsRequired = false, Name = "status", DataFormat = DataFormat.Default)]
		public bool status
		{
			get
			{
				return this._status ?? false;
			}
			set
			{
				this._status = new bool?(value);
			}
		}

		// Token: 0x1700107E RID: 4222
		// (get) Token: 0x060035A0 RID: 13728 RVA: 0x00066C08 File Offset: 0x00064E08
		// (set) Token: 0x060035A1 RID: 13729 RVA: 0x00066C28 File Offset: 0x00064E28
		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new bool?(this.status) : null);
				}
			}
		}

		// Token: 0x060035A2 RID: 13730 RVA: 0x00066C6C File Offset: 0x00064E6C
		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		// Token: 0x060035A3 RID: 13731 RVA: 0x00066C84 File Offset: 0x00064E84
		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		// Token: 0x060035A4 RID: 13732 RVA: 0x00066C90 File Offset: 0x00064E90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D54 RID: 3412
		private bool? _status;

		// Token: 0x04000D55 RID: 3413
		private IExtension extensionObject;
	}
}
