using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200014A RID: 330
	[ProtoContract(Name = "FriendGiftOpArg")]
	[Serializable]
	public class FriendGiftOpArg : IExtensible
	{
		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x06001432 RID: 5170 RVA: 0x00028BF0 File Offset: 0x00026DF0
		// (set) Token: 0x06001433 RID: 5171 RVA: 0x00028C1C File Offset: 0x00026E1C
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

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x06001434 RID: 5172 RVA: 0x00028C2C File Offset: 0x00026E2C
		// (set) Token: 0x06001435 RID: 5173 RVA: 0x00028C4C File Offset: 0x00026E4C
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

		// Token: 0x06001436 RID: 5174 RVA: 0x00028C90 File Offset: 0x00026E90
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06001437 RID: 5175 RVA: 0x00028CA8 File Offset: 0x00026EA8
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x06001438 RID: 5176 RVA: 0x00028CB4 File Offset: 0x00026EB4
		[ProtoMember(2, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x00028CCC File Offset: 0x00026ECC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000507 RID: 1287
		private FriendOpType? _op;

		// Token: 0x04000508 RID: 1288
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x04000509 RID: 1289
		private IExtension extensionObject;
	}
}
