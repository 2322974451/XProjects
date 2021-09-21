using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B2 RID: 434
	[ProtoContract(Name = "FriendQueryReportNew")]
	[Serializable]
	public class FriendQueryReportNew : IExtensible
	{
		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x06001991 RID: 6545 RVA: 0x00032BF8 File Offset: 0x00030DF8
		// (set) Token: 0x06001992 RID: 6546 RVA: 0x00032C24 File Offset: 0x00030E24
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

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06001993 RID: 6547 RVA: 0x00032C34 File Offset: 0x00030E34
		// (set) Token: 0x06001994 RID: 6548 RVA: 0x00032C54 File Offset: 0x00030E54
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

		// Token: 0x06001995 RID: 6549 RVA: 0x00032C98 File Offset: 0x00030E98
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x00032CB0 File Offset: 0x00030EB0
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x06001997 RID: 6551 RVA: 0x00032CBC File Offset: 0x00030EBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400065A RID: 1626
		private FriendOpType? _op;

		// Token: 0x0400065B RID: 1627
		private IExtension extensionObject;
	}
}
