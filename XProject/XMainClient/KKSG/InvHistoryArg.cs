using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000166 RID: 358
	[ProtoContract(Name = "InvHistoryArg")]
	[Serializable]
	public class InvHistoryArg : IExtensible
	{
		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x0600159D RID: 5533 RVA: 0x0002B65C File Offset: 0x0002985C
		// (set) Token: 0x0600159E RID: 5534 RVA: 0x0002B688 File Offset: 0x00029888
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public InvHReqType type
		{
			get
			{
				return this._type ?? InvHReqType.INVH_REQ_UNF_LIST;
			}
			set
			{
				this._type = new InvHReqType?(value);
			}
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x0600159F RID: 5535 RVA: 0x0002B698 File Offset: 0x00029898
		// (set) Token: 0x060015A0 RID: 5536 RVA: 0x0002B6B8 File Offset: 0x000298B8
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
					this._type = (value ? new InvHReqType?(this.type) : null);
				}
			}
		}

		// Token: 0x060015A1 RID: 5537 RVA: 0x0002B6FC File Offset: 0x000298FC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x0002B714 File Offset: 0x00029914
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x0002B720 File Offset: 0x00029920
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000561 RID: 1377
		private InvHReqType? _type;

		// Token: 0x04000562 RID: 1378
		private IExtension extensionObject;
	}
}
