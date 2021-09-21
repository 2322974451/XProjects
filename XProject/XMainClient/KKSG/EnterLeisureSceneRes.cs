using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200051C RID: 1308
	[ProtoContract(Name = "EnterLeisureSceneRes")]
	[Serializable]
	public class EnterLeisureSceneRes : IExtensible
	{
		// Token: 0x17001489 RID: 5257
		// (get) Token: 0x06004333 RID: 17203 RVA: 0x0007FD74 File Offset: 0x0007DF74
		// (set) Token: 0x06004334 RID: 17204 RVA: 0x0007FDA0 File Offset: 0x0007DFA0
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

		// Token: 0x1700148A RID: 5258
		// (get) Token: 0x06004335 RID: 17205 RVA: 0x0007FDB0 File Offset: 0x0007DFB0
		// (set) Token: 0x06004336 RID: 17206 RVA: 0x0007FDD0 File Offset: 0x0007DFD0
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

		// Token: 0x06004337 RID: 17207 RVA: 0x0007FE14 File Offset: 0x0007E014
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004338 RID: 17208 RVA: 0x0007FE2C File Offset: 0x0007E02C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06004339 RID: 17209 RVA: 0x0007FE38 File Offset: 0x0007E038
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010C1 RID: 4289
		private ErrorCode? _errorcode;

		// Token: 0x040010C2 RID: 4290
		private IExtension extensionObject;
	}
}
