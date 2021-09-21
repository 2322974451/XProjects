using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B4 RID: 1204
	[ProtoContract(Name = "DragonGuildApprovalRes")]
	[Serializable]
	public class DragonGuildApprovalRes : IExtensible
	{
		// Token: 0x1700133F RID: 4927
		// (get) Token: 0x06003ECE RID: 16078 RVA: 0x00077CA4 File Offset: 0x00075EA4
		// (set) Token: 0x06003ECF RID: 16079 RVA: 0x00077CD0 File Offset: 0x00075ED0
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

		// Token: 0x17001340 RID: 4928
		// (get) Token: 0x06003ED0 RID: 16080 RVA: 0x00077CE0 File Offset: 0x00075EE0
		// (set) Token: 0x06003ED1 RID: 16081 RVA: 0x00077D00 File Offset: 0x00075F00
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

		// Token: 0x06003ED2 RID: 16082 RVA: 0x00077D44 File Offset: 0x00075F44
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003ED3 RID: 16083 RVA: 0x00077D5C File Offset: 0x00075F5C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06003ED4 RID: 16084 RVA: 0x00077D68 File Offset: 0x00075F68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FA0 RID: 4000
		private ErrorCode? _result;

		// Token: 0x04000FA1 RID: 4001
		private IExtension extensionObject;
	}
}
