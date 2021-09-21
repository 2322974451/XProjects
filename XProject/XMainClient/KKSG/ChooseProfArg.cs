using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000026 RID: 38
	[ProtoContract(Name = "ChooseProfArg")]
	[Serializable]
	public class ChooseProfArg : IExtensible
	{
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00007CA0 File Offset: 0x00005EA0
		// (set) Token: 0x060002AB RID: 683 RVA: 0x00007CCC File Offset: 0x00005ECC
		[ProtoMember(1, IsRequired = false, Name = "prof", DataFormat = DataFormat.TwosComplement)]
		public RoleType prof
		{
			get
			{
				return this._prof ?? RoleType.Role_INVALID;
			}
			set
			{
				this._prof = new RoleType?(value);
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00007CDC File Offset: 0x00005EDC
		// (set) Token: 0x060002AD RID: 685 RVA: 0x00007CFC File Offset: 0x00005EFC
		[XmlIgnore]
		[Browsable(false)]
		public bool profSpecified
		{
			get
			{
				return this._prof != null;
			}
			set
			{
				bool flag = value == (this._prof == null);
				if (flag)
				{
					this._prof = (value ? new RoleType?(this.prof) : null);
				}
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00007D40 File Offset: 0x00005F40
		private bool ShouldSerializeprof()
		{
			return this.profSpecified;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00007D58 File Offset: 0x00005F58
		private void Resetprof()
		{
			this.profSpecified = false;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00007D64 File Offset: 0x00005F64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000B4 RID: 180
		private RoleType? _prof;

		// Token: 0x040000B5 RID: 181
		private IExtension extensionObject;
	}
}
