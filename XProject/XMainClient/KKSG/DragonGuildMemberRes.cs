using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004BA RID: 1210
	[ProtoContract(Name = "DragonGuildMemberRes")]
	[Serializable]
	public class DragonGuildMemberRes : IExtensible
	{
		// Token: 0x1700134B RID: 4939
		// (get) Token: 0x06003EFE RID: 16126 RVA: 0x000781C0 File Offset: 0x000763C0
		// (set) Token: 0x06003EFF RID: 16127 RVA: 0x000781EC File Offset: 0x000763EC
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

		// Token: 0x1700134C RID: 4940
		// (get) Token: 0x06003F00 RID: 16128 RVA: 0x000781FC File Offset: 0x000763FC
		// (set) Token: 0x06003F01 RID: 16129 RVA: 0x0007821C File Offset: 0x0007641C
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

		// Token: 0x06003F02 RID: 16130 RVA: 0x00078260 File Offset: 0x00076460
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003F03 RID: 16131 RVA: 0x00078278 File Offset: 0x00076478
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700134D RID: 4941
		// (get) Token: 0x06003F04 RID: 16132 RVA: 0x00078284 File Offset: 0x00076484
		[ProtoMember(2, Name = "members", DataFormat = DataFormat.Default)]
		public List<DragonGuildMembersInfo> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x06003F05 RID: 16133 RVA: 0x0007829C File Offset: 0x0007649C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FAC RID: 4012
		private ErrorCode? _result;

		// Token: 0x04000FAD RID: 4013
		private readonly List<DragonGuildMembersInfo> _members = new List<DragonGuildMembersInfo>();

		// Token: 0x04000FAE RID: 4014
		private IExtension extensionObject;
	}
}
