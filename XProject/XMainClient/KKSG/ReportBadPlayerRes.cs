using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200040C RID: 1036
	[ProtoContract(Name = "ReportBadPlayerRes")]
	[Serializable]
	public class ReportBadPlayerRes : IExtensible
	{
		// Token: 0x170010F6 RID: 4342
		// (get) Token: 0x06003729 RID: 14121 RVA: 0x00069A98 File Offset: 0x00067C98
		// (set) Token: 0x0600372A RID: 14122 RVA: 0x00069AC4 File Offset: 0x00067CC4
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

		// Token: 0x170010F7 RID: 4343
		// (get) Token: 0x0600372B RID: 14123 RVA: 0x00069AD4 File Offset: 0x00067CD4
		// (set) Token: 0x0600372C RID: 14124 RVA: 0x00069AF4 File Offset: 0x00067CF4
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

		// Token: 0x0600372D RID: 14125 RVA: 0x00069B38 File Offset: 0x00067D38
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600372E RID: 14126 RVA: 0x00069B50 File Offset: 0x00067D50
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600372F RID: 14127 RVA: 0x00069B5C File Offset: 0x00067D5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DAD RID: 3501
		private ErrorCode? _result;

		// Token: 0x04000DAE RID: 3502
		private IExtension extensionObject;
	}
}
