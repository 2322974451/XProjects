using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000141 RID: 321
	[ProtoContract(Name = "DoAddFriendArg")]
	[Serializable]
	public class DoAddFriendArg : IExtensible
	{
		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x060013DA RID: 5082 RVA: 0x000281BC File Offset: 0x000263BC
		// (set) Token: 0x060013DB RID: 5083 RVA: 0x000281E8 File Offset: 0x000263E8
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public FriendOpType op
		{
			get
			{
				return this._op ?? FriendOpType.Friend_AgreeApply;
			}
			set
			{
				this._op = new FriendOpType?(value);
			}
		}

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x060013DC RID: 5084 RVA: 0x000281F8 File Offset: 0x000263F8
		// (set) Token: 0x060013DD RID: 5085 RVA: 0x00028218 File Offset: 0x00026418
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new FriendOpType?(this.op) : null);
				}
			}
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x0002825C File Offset: 0x0002645C
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x060013DF RID: 5087 RVA: 0x00028274 File Offset: 0x00026474
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x060013E0 RID: 5088 RVA: 0x00028280 File Offset: 0x00026480
		[ProtoMember(2, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x00028298 File Offset: 0x00026498
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004EB RID: 1259
		private FriendOpType? _op;

		// Token: 0x040004EC RID: 1260
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x040004ED RID: 1261
		private IExtension extensionObject;
	}
}
