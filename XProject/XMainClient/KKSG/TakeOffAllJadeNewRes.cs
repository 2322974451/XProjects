using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000552 RID: 1362
	[ProtoContract(Name = "TakeOffAllJadeNewRes")]
	[Serializable]
	public class TakeOffAllJadeNewRes : IExtensible
	{
		// Token: 0x17001547 RID: 5447
		// (get) Token: 0x060045A8 RID: 17832 RVA: 0x0008460C File Offset: 0x0008280C
		// (set) Token: 0x060045A9 RID: 17833 RVA: 0x00084638 File Offset: 0x00082838
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

		// Token: 0x17001548 RID: 5448
		// (get) Token: 0x060045AA RID: 17834 RVA: 0x00084648 File Offset: 0x00082848
		// (set) Token: 0x060045AB RID: 17835 RVA: 0x00084668 File Offset: 0x00082868
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

		// Token: 0x060045AC RID: 17836 RVA: 0x000846AC File Offset: 0x000828AC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060045AD RID: 17837 RVA: 0x000846C4 File Offset: 0x000828C4
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060045AE RID: 17838 RVA: 0x000846D0 File Offset: 0x000828D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001164 RID: 4452
		private ErrorCode? _errorcode;

		// Token: 0x04001165 RID: 4453
		private IExtension extensionObject;
	}
}
