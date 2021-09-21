using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000437 RID: 1079
	[ProtoContract(Name = "LoginReconnectReqRes")]
	[Serializable]
	public class LoginReconnectReqRes : IExtensible
	{
		// Token: 0x17001183 RID: 4483
		// (get) Token: 0x06003908 RID: 14600 RVA: 0x0006D20C File Offset: 0x0006B40C
		// (set) Token: 0x06003909 RID: 14601 RVA: 0x0006D238 File Offset: 0x0006B438
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

		// Token: 0x17001184 RID: 4484
		// (get) Token: 0x0600390A RID: 14602 RVA: 0x0006D248 File Offset: 0x0006B448
		// (set) Token: 0x0600390B RID: 14603 RVA: 0x0006D268 File Offset: 0x0006B468
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

		// Token: 0x0600390C RID: 14604 RVA: 0x0006D2AC File Offset: 0x0006B4AC
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600390D RID: 14605 RVA: 0x0006D2C4 File Offset: 0x0006B4C4
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600390E RID: 14606 RVA: 0x0006D2D0 File Offset: 0x0006B4D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E27 RID: 3623
		private ErrorCode? _result;

		// Token: 0x04000E28 RID: 3624
		private IExtension extensionObject;
	}
}
