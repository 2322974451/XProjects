using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000134 RID: 308
	[ProtoContract(Name = "PvpArg")]
	[Serializable]
	public class PvpArg : IExtensible
	{
		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x060012DC RID: 4828 RVA: 0x00026378 File Offset: 0x00024578
		// (set) Token: 0x060012DD RID: 4829 RVA: 0x000263A4 File Offset: 0x000245A4
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public PvpReqType type
		{
			get
			{
				return this._type ?? PvpReqType.PVP_REQ_IN_MATCH;
			}
			set
			{
				this._type = new PvpReqType?(value);
			}
		}

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x060012DE RID: 4830 RVA: 0x000263B4 File Offset: 0x000245B4
		// (set) Token: 0x060012DF RID: 4831 RVA: 0x000263D4 File Offset: 0x000245D4
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
					this._type = (value ? new PvpReqType?(this.type) : null);
				}
			}
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x00026418 File Offset: 0x00024618
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x00026430 File Offset: 0x00024630
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x0002643C File Offset: 0x0002463C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004B5 RID: 1205
		private PvpReqType? _type;

		// Token: 0x040004B6 RID: 1206
		private IExtension extensionObject;
	}
}
