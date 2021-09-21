using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000165 RID: 357
	[ProtoContract(Name = "InviteRufuse")]
	[Serializable]
	public class InviteRufuse : IExtensible
	{
		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x06001595 RID: 5525 RVA: 0x0002B5A0 File Offset: 0x000297A0
		// (set) Token: 0x06001596 RID: 5526 RVA: 0x0002B5C1 File Offset: 0x000297C1
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x06001597 RID: 5527 RVA: 0x0002B5CC File Offset: 0x000297CC
		// (set) Token: 0x06001598 RID: 5528 RVA: 0x0002B5E8 File Offset: 0x000297E8
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0002B618 File Offset: 0x00029818
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x0002B630 File Offset: 0x00029830
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x0002B63C File Offset: 0x0002983C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400055F RID: 1375
		private string _name;

		// Token: 0x04000560 RID: 1376
		private IExtension extensionObject;
	}
}
