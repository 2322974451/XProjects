using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A1 RID: 1185
	[ProtoContract(Name = "BackFlowBuyOpArg")]
	[Serializable]
	public class BackFlowBuyOpArg : IExtensible
	{
		// Token: 0x170012E6 RID: 4838
		// (get) Token: 0x06003DAA RID: 15786 RVA: 0x00075ADC File Offset: 0x00073CDC
		// (set) Token: 0x06003DAB RID: 15787 RVA: 0x00075B08 File Offset: 0x00073D08
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public int op
		{
			get
			{
				return this._op ?? 0;
			}
			set
			{
				this._op = new int?(value);
			}
		}

		// Token: 0x170012E7 RID: 4839
		// (get) Token: 0x06003DAC RID: 15788 RVA: 0x00075B18 File Offset: 0x00073D18
		// (set) Token: 0x06003DAD RID: 15789 RVA: 0x00075B38 File Offset: 0x00073D38
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new int?(this.op) : null);
				}
			}
		}

		// Token: 0x06003DAE RID: 15790 RVA: 0x00075B7C File Offset: 0x00073D7C
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06003DAF RID: 15791 RVA: 0x00075B94 File Offset: 0x00073D94
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x06003DB0 RID: 15792 RVA: 0x00075BA0 File Offset: 0x00073DA0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F5D RID: 3933
		private int? _op;

		// Token: 0x04000F5E RID: 3934
		private IExtension extensionObject;
	}
}
