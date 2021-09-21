using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200050C RID: 1292
	[ProtoContract(Name = "ActivatePreShowRes")]
	[Serializable]
	public class ActivatePreShowRes : IExtensible
	{
		// Token: 0x1700145E RID: 5214
		// (get) Token: 0x06004294 RID: 17044 RVA: 0x0007EB84 File Offset: 0x0007CD84
		// (set) Token: 0x06004295 RID: 17045 RVA: 0x0007EBB0 File Offset: 0x0007CDB0
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

		// Token: 0x1700145F RID: 5215
		// (get) Token: 0x06004296 RID: 17046 RVA: 0x0007EBC0 File Offset: 0x0007CDC0
		// (set) Token: 0x06004297 RID: 17047 RVA: 0x0007EBE0 File Offset: 0x0007CDE0
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

		// Token: 0x06004298 RID: 17048 RVA: 0x0007EC24 File Offset: 0x0007CE24
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06004299 RID: 17049 RVA: 0x0007EC3C File Offset: 0x0007CE3C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600429A RID: 17050 RVA: 0x0007EC48 File Offset: 0x0007CE48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400109B RID: 4251
		private ErrorCode? _result;

		// Token: 0x0400109C RID: 4252
		private IExtension extensionObject;
	}
}
