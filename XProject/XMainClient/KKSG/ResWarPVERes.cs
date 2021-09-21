using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B0 RID: 688
	[ProtoContract(Name = "ResWarPVERes")]
	[Serializable]
	public class ResWarPVERes : IExtensible
	{
		// Token: 0x17000BF5 RID: 3061
		// (get) Token: 0x0600266A RID: 9834 RVA: 0x0004AC5C File Offset: 0x00048E5C
		// (set) Token: 0x0600266B RID: 9835 RVA: 0x0004AC88 File Offset: 0x00048E88
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000BF6 RID: 3062
		// (get) Token: 0x0600266C RID: 9836 RVA: 0x0004AC98 File Offset: 0x00048E98
		// (set) Token: 0x0600266D RID: 9837 RVA: 0x0004ACB8 File Offset: 0x00048EB8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x0600266E RID: 9838 RVA: 0x0004ACFC File Offset: 0x00048EFC
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600266F RID: 9839 RVA: 0x0004AD14 File Offset: 0x00048F14
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06002670 RID: 9840 RVA: 0x0004AD20 File Offset: 0x00048F20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000988 RID: 2440
		private ErrorCode? _error;

		// Token: 0x04000989 RID: 2441
		private IExtension extensionObject;
	}
}
