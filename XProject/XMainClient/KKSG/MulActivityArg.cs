using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000172 RID: 370
	[ProtoContract(Name = "MulActivityArg")]
	[Serializable]
	public class MulActivityArg : IExtensible
	{
		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06001630 RID: 5680 RVA: 0x0002C73C File Offset: 0x0002A93C
		// (set) Token: 0x06001631 RID: 5681 RVA: 0x0002C768 File Offset: 0x0002A968
		[ProtoMember(1, IsRequired = false, Name = "acid", DataFormat = DataFormat.TwosComplement)]
		public int acid
		{
			get
			{
				return this._acid ?? 0;
			}
			set
			{
				this._acid = new int?(value);
			}
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06001632 RID: 5682 RVA: 0x0002C778 File Offset: 0x0002A978
		// (set) Token: 0x06001633 RID: 5683 RVA: 0x0002C798 File Offset: 0x0002A998
		[XmlIgnore]
		[Browsable(false)]
		public bool acidSpecified
		{
			get
			{
				return this._acid != null;
			}
			set
			{
				bool flag = value == (this._acid == null);
				if (flag)
				{
					this._acid = (value ? new int?(this.acid) : null);
				}
			}
		}

		// Token: 0x06001634 RID: 5684 RVA: 0x0002C7DC File Offset: 0x0002A9DC
		private bool ShouldSerializeacid()
		{
			return this.acidSpecified;
		}

		// Token: 0x06001635 RID: 5685 RVA: 0x0002C7F4 File Offset: 0x0002A9F4
		private void Resetacid()
		{
			this.acidSpecified = false;
		}

		// Token: 0x06001636 RID: 5686 RVA: 0x0002C800 File Offset: 0x0002AA00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000583 RID: 1411
		private int? _acid;

		// Token: 0x04000584 RID: 1412
		private IExtension extensionObject;
	}
}
