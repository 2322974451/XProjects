using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000058 RID: 88
	[ProtoContract(Name = "ReviveRes")]
	[Serializable]
	public class ReviveRes : IExtensible
	{
		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x0000DE74 File Offset: 0x0000C074
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x0000DEA0 File Offset: 0x0000C0A0
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

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x0000DEB0 File Offset: 0x0000C0B0
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x0000DED0 File Offset: 0x0000C0D0
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

		// Token: 0x060005E1 RID: 1505 RVA: 0x0000DF14 File Offset: 0x0000C114
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0000DF2C File Offset: 0x0000C12C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x0000DF38 File Offset: 0x0000C138
		[ProtoMember(2, Name = "bufflist", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bufflist
		{
			get
			{
				return this._bufflist;
			}
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0000DF50 File Offset: 0x0000C150
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400017E RID: 382
		private ErrorCode? _result;

		// Token: 0x0400017F RID: 383
		private readonly List<uint> _bufflist = new List<uint>();

		// Token: 0x04000180 RID: 384
		private IExtension extensionObject;
	}
}
