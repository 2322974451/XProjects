using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000091 RID: 145
	[ProtoContract(Name = "LeaveGuildRes")]
	[Serializable]
	public class LeaveGuildRes : IExtensible
	{
		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x0001459C File Offset: 0x0001279C
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x000145C8 File Offset: 0x000127C8
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

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x000145D8 File Offset: 0x000127D8
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x000145F8 File Offset: 0x000127F8
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

		// Token: 0x06000956 RID: 2390 RVA: 0x0001463C File Offset: 0x0001283C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00014654 File Offset: 0x00012854
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00014660 File Offset: 0x00012860
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400026E RID: 622
		private ErrorCode? _result;

		// Token: 0x0400026F RID: 623
		private IExtension extensionObject;
	}
}
