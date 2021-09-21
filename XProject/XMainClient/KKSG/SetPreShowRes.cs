using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004ED RID: 1261
	[ProtoContract(Name = "SetPreShowRes")]
	[Serializable]
	public class SetPreShowRes : IExtensible
	{
		// Token: 0x170013E9 RID: 5097
		// (get) Token: 0x06004117 RID: 16663 RVA: 0x0007BEE4 File Offset: 0x0007A0E4
		// (set) Token: 0x06004118 RID: 16664 RVA: 0x0007BF10 File Offset: 0x0007A110
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

		// Token: 0x170013EA RID: 5098
		// (get) Token: 0x06004119 RID: 16665 RVA: 0x0007BF20 File Offset: 0x0007A120
		// (set) Token: 0x0600411A RID: 16666 RVA: 0x0007BF40 File Offset: 0x0007A140
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

		// Token: 0x0600411B RID: 16667 RVA: 0x0007BF84 File Offset: 0x0007A184
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600411C RID: 16668 RVA: 0x0007BF9C File Offset: 0x0007A19C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600411D RID: 16669 RVA: 0x0007BFA8 File Offset: 0x0007A1A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001038 RID: 4152
		private ErrorCode? _result;

		// Token: 0x04001039 RID: 4153
		private IExtension extensionObject;
	}
}
