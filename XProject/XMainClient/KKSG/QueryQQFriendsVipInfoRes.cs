using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002FC RID: 764
	[ProtoContract(Name = "QueryQQFriendsVipInfoRes")]
	[Serializable]
	public class QueryQQFriendsVipInfoRes : IExtensible
	{
		// Token: 0x17000CFC RID: 3324
		// (get) Token: 0x060029E0 RID: 10720 RVA: 0x0005138C File Offset: 0x0004F58C
		// (set) Token: 0x060029E1 RID: 10721 RVA: 0x000513B8 File Offset: 0x0004F5B8
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

		// Token: 0x17000CFD RID: 3325
		// (get) Token: 0x060029E2 RID: 10722 RVA: 0x000513C8 File Offset: 0x0004F5C8
		// (set) Token: 0x060029E3 RID: 10723 RVA: 0x000513E8 File Offset: 0x0004F5E8
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

		// Token: 0x060029E4 RID: 10724 RVA: 0x0005142C File Offset: 0x0004F62C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060029E5 RID: 10725 RVA: 0x00051444 File Offset: 0x0004F644
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000CFE RID: 3326
		// (get) Token: 0x060029E6 RID: 10726 RVA: 0x00051450 File Offset: 0x0004F650
		[ProtoMember(2, Name = "info", DataFormat = DataFormat.Default)]
		public List<FriendVipInfo> info
		{
			get
			{
				return this._info;
			}
		}

		// Token: 0x060029E7 RID: 10727 RVA: 0x00051468 File Offset: 0x0004F668
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A66 RID: 2662
		private ErrorCode? _result;

		// Token: 0x04000A67 RID: 2663
		private readonly List<FriendVipInfo> _info = new List<FriendVipInfo>();

		// Token: 0x04000A68 RID: 2664
		private IExtension extensionObject;
	}
}
