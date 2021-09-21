using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200016A RID: 362
	[ProtoContract(Name = "IdentifyEmblemArg")]
	[Serializable]
	public class IdentifyEmblemArg : IExtensible
	{
		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x060015E8 RID: 5608 RVA: 0x0002BF4C File Offset: 0x0002A14C
		// (set) Token: 0x060015E9 RID: 5609 RVA: 0x0002BF79 File Offset: 0x0002A179
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

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x060015EA RID: 5610 RVA: 0x0002BF88 File Offset: 0x0002A188
		// (set) Token: 0x060015EB RID: 5611 RVA: 0x0002BFA8 File Offset: 0x0002A1A8
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

		// Token: 0x060015EC RID: 5612 RVA: 0x0002BFEC File Offset: 0x0002A1EC
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x0002C004 File Offset: 0x0002A204
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x0002C010 File Offset: 0x0002A210
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000571 RID: 1393
		private ulong? _uid;

		// Token: 0x04000572 RID: 1394
		private IExtension extensionObject;
	}
}
