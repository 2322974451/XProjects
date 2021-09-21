using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000396 RID: 918
	[ProtoContract(Name = "MidasExceptionInfo")]
	[Serializable]
	public class MidasExceptionInfo : IExtensible
	{
		// Token: 0x17000F55 RID: 3925
		// (get) Token: 0x0600319C RID: 12700 RVA: 0x0005F8A4 File Offset: 0x0005DAA4
		// (set) Token: 0x0600319D RID: 12701 RVA: 0x0005F8D0 File Offset: 0x0005DAD0
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000F56 RID: 3926
		// (get) Token: 0x0600319E RID: 12702 RVA: 0x0005F8E0 File Offset: 0x0005DAE0
		// (set) Token: 0x0600319F RID: 12703 RVA: 0x0005F900 File Offset: 0x0005DB00
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x060031A0 RID: 12704 RVA: 0x0005F944 File Offset: 0x0005DB44
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060031A1 RID: 12705 RVA: 0x0005F95C File Offset: 0x0005DB5C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060031A2 RID: 12706 RVA: 0x0005F968 File Offset: 0x0005DB68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C52 RID: 3154
		private ErrorCode? _result;

		// Token: 0x04000C53 RID: 3155
		private IExtension extensionObject;
	}
}
