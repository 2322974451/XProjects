using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200013A RID: 314
	[ProtoContract(Name = "AgreeQARes")]
	[Serializable]
	public class AgreeQARes : IExtensible
	{
		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x0600132F RID: 4911 RVA: 0x00026D04 File Offset: 0x00024F04
		// (set) Token: 0x06001330 RID: 4912 RVA: 0x00026D30 File Offset: 0x00024F30
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

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06001331 RID: 4913 RVA: 0x00026D40 File Offset: 0x00024F40
		// (set) Token: 0x06001332 RID: 4914 RVA: 0x00026D60 File Offset: 0x00024F60
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

		// Token: 0x06001333 RID: 4915 RVA: 0x00026DA4 File Offset: 0x00024FA4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x00026DBC File Offset: 0x00024FBC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x00026DC8 File Offset: 0x00024FC8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004C9 RID: 1225
		private ErrorCode? _result;

		// Token: 0x040004CA RID: 1226
		private IExtension extensionObject;
	}
}
