using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200016D RID: 365
	[ProtoContract(Name = "OpenGuildQARes")]
	[Serializable]
	public class OpenGuildQARes : IExtensible
	{
		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x060015FA RID: 5626 RVA: 0x0002C134 File Offset: 0x0002A334
		// (set) Token: 0x060015FB RID: 5627 RVA: 0x0002C160 File Offset: 0x0002A360
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

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x060015FC RID: 5628 RVA: 0x0002C170 File Offset: 0x0002A370
		// (set) Token: 0x060015FD RID: 5629 RVA: 0x0002C190 File Offset: 0x0002A390
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

		// Token: 0x060015FE RID: 5630 RVA: 0x0002C1D4 File Offset: 0x0002A3D4
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x0002C1EC File Offset: 0x0002A3EC
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x0002C1F8 File Offset: 0x0002A3F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000576 RID: 1398
		private ErrorCode? _result;

		// Token: 0x04000577 RID: 1399
		private IExtension extensionObject;
	}
}
