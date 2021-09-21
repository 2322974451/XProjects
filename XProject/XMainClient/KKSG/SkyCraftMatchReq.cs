using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003DA RID: 986
	[ProtoContract(Name = "SkyCraftMatchReq")]
	[Serializable]
	public class SkyCraftMatchReq : IExtensible
	{
		// Token: 0x17001022 RID: 4130
		// (get) Token: 0x0600346E RID: 13422 RVA: 0x000648F4 File Offset: 0x00062AF4
		// (set) Token: 0x0600346F RID: 13423 RVA: 0x00064920 File Offset: 0x00062B20
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public SkyCraftMatchReqTpe type
		{
			get
			{
				return this._type ?? SkyCraftMatchReqTpe.SCMR_Match;
			}
			set
			{
				this._type = new SkyCraftMatchReqTpe?(value);
			}
		}

		// Token: 0x17001023 RID: 4131
		// (get) Token: 0x06003470 RID: 13424 RVA: 0x00064930 File Offset: 0x00062B30
		// (set) Token: 0x06003471 RID: 13425 RVA: 0x00064950 File Offset: 0x00062B50
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
					this._type = (value ? new SkyCraftMatchReqTpe?(this.type) : null);
				}
			}
		}

		// Token: 0x06003472 RID: 13426 RVA: 0x00064994 File Offset: 0x00062B94
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003473 RID: 13427 RVA: 0x000649AC File Offset: 0x00062BAC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06003474 RID: 13428 RVA: 0x000649B8 File Offset: 0x00062BB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D06 RID: 3334
		private SkyCraftMatchReqTpe? _type;

		// Token: 0x04000D07 RID: 3335
		private IExtension extensionObject;
	}
}
