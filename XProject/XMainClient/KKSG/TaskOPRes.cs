using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000023 RID: 35
	[ProtoContract(Name = "TaskOPRes")]
	[Serializable]
	public class TaskOPRes : IExtensible
	{
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000286 RID: 646 RVA: 0x0000786C File Offset: 0x00005A6C
		// (set) Token: 0x06000287 RID: 647 RVA: 0x00007898 File Offset: 0x00005A98
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.Default)]
		public bool result
		{
			get
			{
				return this._result ?? false;
			}
			set
			{
				this._result = new bool?(value);
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000288 RID: 648 RVA: 0x000078A8 File Offset: 0x00005AA8
		// (set) Token: 0x06000289 RID: 649 RVA: 0x000078C8 File Offset: 0x00005AC8
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
					this._result = (value ? new bool?(this.result) : null);
				}
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000790C File Offset: 0x00005B0C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00007924 File Offset: 0x00005B24
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00007930 File Offset: 0x00005B30
		// (set) Token: 0x0600028D RID: 653 RVA: 0x0000795C File Offset: 0x00005B5C
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000796C File Offset: 0x00005B6C
		// (set) Token: 0x0600028F RID: 655 RVA: 0x0000798C File Offset: 0x00005B8C
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

		// Token: 0x06000290 RID: 656 RVA: 0x000079D0 File Offset: 0x00005BD0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x000079E8 File Offset: 0x00005BE8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000079F4 File Offset: 0x00005BF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000AC RID: 172
		private bool? _result;

		// Token: 0x040000AD RID: 173
		private ErrorCode? _errorcode;

		// Token: 0x040000AE RID: 174
		private IExtension extensionObject;
	}
}
