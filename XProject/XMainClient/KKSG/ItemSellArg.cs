using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200039B RID: 923
	[ProtoContract(Name = "ItemSellArg")]
	[Serializable]
	public class ItemSellArg : IExtensible
	{
		// Token: 0x17000F6C RID: 3948
		// (get) Token: 0x060031E9 RID: 12777 RVA: 0x000601E0 File Offset: 0x0005E3E0
		// (set) Token: 0x060031EA RID: 12778 RVA: 0x0006020D File Offset: 0x0005E40D
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

		// Token: 0x17000F6D RID: 3949
		// (get) Token: 0x060031EB RID: 12779 RVA: 0x0006021C File Offset: 0x0005E41C
		// (set) Token: 0x060031EC RID: 12780 RVA: 0x0006023C File Offset: 0x0005E43C
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

		// Token: 0x060031ED RID: 12781 RVA: 0x00060280 File Offset: 0x0005E480
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060031EE RID: 12782 RVA: 0x00060298 File Offset: 0x0005E498
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x060031EF RID: 12783 RVA: 0x000602A4 File Offset: 0x0005E4A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C63 RID: 3171
		private ulong? _uid;

		// Token: 0x04000C64 RID: 3172
		private IExtension extensionObject;
	}
}
