using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B5 RID: 437
	[ProtoContract(Name = "GmfWaitOtherArg")]
	[Serializable]
	public class GmfWaitOtherArg : IExtensible
	{
		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x060019AA RID: 6570 RVA: 0x00032ED0 File Offset: 0x000310D0
		// (set) Token: 0x060019AB RID: 6571 RVA: 0x00032EFC File Offset: 0x000310FC
		[ProtoMember(1, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x060019AC RID: 6572 RVA: 0x00032F0C File Offset: 0x0003110C
		// (set) Token: 0x060019AD RID: 6573 RVA: 0x00032F2C File Offset: 0x0003112C
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x00032F70 File Offset: 0x00031170
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x00032F88 File Offset: 0x00031188
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x060019B0 RID: 6576 RVA: 0x00032F94 File Offset: 0x00031194
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000661 RID: 1633
		private uint? _lefttime;

		// Token: 0x04000662 RID: 1634
		private IExtension extensionObject;
	}
}
