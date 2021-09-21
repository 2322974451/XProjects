using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000532 RID: 1330
	[ProtoContract(Name = "CrossGvgOperRes")]
	[Serializable]
	public class CrossGvgOperRes : IExtensible
	{
		// Token: 0x170014E8 RID: 5352
		// (get) Token: 0x0600445D RID: 17501 RVA: 0x000820E0 File Offset: 0x000802E0
		// (set) Token: 0x0600445E RID: 17502 RVA: 0x0008210C File Offset: 0x0008030C
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

		// Token: 0x170014E9 RID: 5353
		// (get) Token: 0x0600445F RID: 17503 RVA: 0x0008211C File Offset: 0x0008031C
		// (set) Token: 0x06004460 RID: 17504 RVA: 0x0008213C File Offset: 0x0008033C
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

		// Token: 0x06004461 RID: 17505 RVA: 0x00082180 File Offset: 0x00080380
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06004462 RID: 17506 RVA: 0x00082198 File Offset: 0x00080398
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06004463 RID: 17507 RVA: 0x000821A4 File Offset: 0x000803A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400110F RID: 4367
		private ErrorCode? _result;

		// Token: 0x04001110 RID: 4368
		private IExtension extensionObject;
	}
}
