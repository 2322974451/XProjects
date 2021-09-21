using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000412 RID: 1042
	[ProtoContract(Name = "ReturnSmeltStoneArg")]
	[Serializable]
	public class ReturnSmeltStoneArg : IExtensible
	{
		// Token: 0x1700110B RID: 4363
		// (get) Token: 0x06003772 RID: 14194 RVA: 0x0006A2DC File Offset: 0x000684DC
		// (set) Token: 0x06003773 RID: 14195 RVA: 0x0006A309 File Offset: 0x00068509
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

		// Token: 0x1700110C RID: 4364
		// (get) Token: 0x06003774 RID: 14196 RVA: 0x0006A318 File Offset: 0x00068518
		// (set) Token: 0x06003775 RID: 14197 RVA: 0x0006A338 File Offset: 0x00068538
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

		// Token: 0x06003776 RID: 14198 RVA: 0x0006A37C File Offset: 0x0006857C
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06003777 RID: 14199 RVA: 0x0006A394 File Offset: 0x00068594
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x06003778 RID: 14200 RVA: 0x0006A3A0 File Offset: 0x000685A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DBE RID: 3518
		private ulong? _uid;

		// Token: 0x04000DBF RID: 3519
		private IExtension extensionObject;
	}
}
