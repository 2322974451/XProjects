using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200028F RID: 655
	[ProtoContract(Name = "OpenGardenFarmlandRes")]
	[Serializable]
	public class OpenGardenFarmlandRes : IExtensible
	{
		// Token: 0x17000B70 RID: 2928
		// (get) Token: 0x060024CA RID: 9418 RVA: 0x00047C20 File Offset: 0x00045E20
		// (set) Token: 0x060024CB RID: 9419 RVA: 0x00047C4C File Offset: 0x00045E4C
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

		// Token: 0x17000B71 RID: 2929
		// (get) Token: 0x060024CC RID: 9420 RVA: 0x00047C5C File Offset: 0x00045E5C
		// (set) Token: 0x060024CD RID: 9421 RVA: 0x00047C7C File Offset: 0x00045E7C
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

		// Token: 0x060024CE RID: 9422 RVA: 0x00047CC0 File Offset: 0x00045EC0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x00047CD8 File Offset: 0x00045ED8
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x00047CE4 File Offset: 0x00045EE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000915 RID: 2325
		private ErrorCode? _result;

		// Token: 0x04000916 RID: 2326
		private IExtension extensionObject;
	}
}
