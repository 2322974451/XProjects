using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000027 RID: 39
	[ProtoContract(Name = "ChooseProfRes")]
	[Serializable]
	public class ChooseProfRes : IExtensible
	{
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00007D84 File Offset: 0x00005F84
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x00007DB0 File Offset: 0x00005FB0
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00007DC0 File Offset: 0x00005FC0
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x00007DE0 File Offset: 0x00005FE0
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00007E24 File Offset: 0x00006024
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00007E3C File Offset: 0x0000603C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00007E48 File Offset: 0x00006048
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000B6 RID: 182
		private ErrorCode? _errorcode;

		// Token: 0x040000B7 RID: 183
		private IExtension extensionObject;
	}
}
