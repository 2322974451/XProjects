using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C3 RID: 451
	[ProtoContract(Name = "PayCardAwardArg")]
	[Serializable]
	public class PayCardAwardArg : IExtensible
	{
		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x06001A2B RID: 6699 RVA: 0x00033D08 File Offset: 0x00031F08
		// (set) Token: 0x06001A2C RID: 6700 RVA: 0x00033D34 File Offset: 0x00031F34
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x06001A2D RID: 6701 RVA: 0x00033D44 File Offset: 0x00031F44
		// (set) Token: 0x06001A2E RID: 6702 RVA: 0x00033D64 File Offset: 0x00031F64
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

		// Token: 0x06001A2F RID: 6703 RVA: 0x00033DA8 File Offset: 0x00031FA8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x00033DC0 File Offset: 0x00031FC0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x00033DCC File Offset: 0x00031FCC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000683 RID: 1667
		private int? _type;

		// Token: 0x04000684 RID: 1668
		private IExtension extensionObject;
	}
}
