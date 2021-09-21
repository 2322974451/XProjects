using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000497 RID: 1175
	[ProtoContract(Name = "ShareReportData")]
	[Serializable]
	public class ShareReportData : IExtensible
	{
		// Token: 0x170012C3 RID: 4803
		// (get) Token: 0x06003D34 RID: 15668 RVA: 0x00074D3C File Offset: 0x00072F3C
		// (set) Token: 0x06003D35 RID: 15669 RVA: 0x00074D68 File Offset: 0x00072F68
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

		// Token: 0x170012C4 RID: 4804
		// (get) Token: 0x06003D36 RID: 15670 RVA: 0x00074D78 File Offset: 0x00072F78
		// (set) Token: 0x06003D37 RID: 15671 RVA: 0x00074D98 File Offset: 0x00072F98
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

		// Token: 0x06003D38 RID: 15672 RVA: 0x00074DDC File Offset: 0x00072FDC
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06003D39 RID: 15673 RVA: 0x00074DF4 File Offset: 0x00072FF4
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x170012C5 RID: 4805
		// (get) Token: 0x06003D3A RID: 15674 RVA: 0x00074E00 File Offset: 0x00073000
		// (set) Token: 0x06003D3B RID: 15675 RVA: 0x00074E2C File Offset: 0x0007302C
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x170012C6 RID: 4806
		// (get) Token: 0x06003D3C RID: 15676 RVA: 0x00074E3C File Offset: 0x0007303C
		// (set) Token: 0x06003D3D RID: 15677 RVA: 0x00074E5C File Offset: 0x0007305C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x06003D3E RID: 15678 RVA: 0x00074EA0 File Offset: 0x000730A0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003D3F RID: 15679 RVA: 0x00074EB8 File Offset: 0x000730B8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003D40 RID: 15680 RVA: 0x00074EC4 File Offset: 0x000730C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F3F RID: 3903
		private int? _op;

		// Token: 0x04000F40 RID: 3904
		private int? _type;

		// Token: 0x04000F41 RID: 3905
		private IExtension extensionObject;
	}
}
