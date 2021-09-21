using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000143 RID: 323
	[ProtoContract(Name = "FriendOpNotify")]
	[Serializable]
	public class FriendOpNotify : IExtensible
	{
		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x060013EC RID: 5100 RVA: 0x00028428 File Offset: 0x00026628
		// (set) Token: 0x060013ED RID: 5101 RVA: 0x00028454 File Offset: 0x00026654
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

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x060013EE RID: 5102 RVA: 0x00028464 File Offset: 0x00026664
		// (set) Token: 0x060013EF RID: 5103 RVA: 0x00028484 File Offset: 0x00026684
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

		// Token: 0x060013F0 RID: 5104 RVA: 0x000284C8 File Offset: 0x000266C8
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x000284E0 File Offset: 0x000266E0
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x060013F2 RID: 5106 RVA: 0x000284EC File Offset: 0x000266EC
		[ProtoMember(2, Name = "friendlist", DataFormat = DataFormat.Default)]
		public List<Friend2Client> friendlist
		{
			get
			{
				return this._friendlist;
			}
		}

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x060013F3 RID: 5107 RVA: 0x00028504 File Offset: 0x00026704
		[ProtoMember(3, Name = "applylist", DataFormat = DataFormat.Default)]
		public List<Friend2Client> applylist
		{
			get
			{
				return this._applylist;
			}
		}

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x060013F4 RID: 5108 RVA: 0x0002851C File Offset: 0x0002671C
		[ProtoMember(4, Name = "deletelist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> deletelist
		{
			get
			{
				return this._deletelist;
			}
		}

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x060013F5 RID: 5109 RVA: 0x00028534 File Offset: 0x00026734
		[ProtoMember(5, Name = "deleteapplylist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> deleteapplylist
		{
			get
			{
				return this._deleteapplylist;
			}
		}

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x060013F6 RID: 5110 RVA: 0x0002854C File Offset: 0x0002674C
		[ProtoMember(6, Name = "senderid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> senderid
		{
			get
			{
				return this._senderid;
			}
		}

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x060013F7 RID: 5111 RVA: 0x00028564 File Offset: 0x00026764
		// (set) Token: 0x060013F8 RID: 5112 RVA: 0x0002857C File Offset: 0x0002677C
		[ProtoMember(7, IsRequired = false, Name = "giftcount", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public FriendGift giftcount
		{
			get
			{
				return this._giftcount;
			}
			set
			{
				this._giftcount = value;
			}
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x060013F9 RID: 5113 RVA: 0x00028588 File Offset: 0x00026788
		[ProtoMember(8, Name = "receivedtime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> receivedtime
		{
			get
			{
				return this._receivedtime;
			}
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x000285A0 File Offset: 0x000267A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004F1 RID: 1265
		private FriendOpType? _op;

		// Token: 0x040004F2 RID: 1266
		private readonly List<Friend2Client> _friendlist = new List<Friend2Client>();

		// Token: 0x040004F3 RID: 1267
		private readonly List<Friend2Client> _applylist = new List<Friend2Client>();

		// Token: 0x040004F4 RID: 1268
		private readonly List<ulong> _deletelist = new List<ulong>();

		// Token: 0x040004F5 RID: 1269
		private readonly List<ulong> _deleteapplylist = new List<ulong>();

		// Token: 0x040004F6 RID: 1270
		private readonly List<ulong> _senderid = new List<ulong>();

		// Token: 0x040004F7 RID: 1271
		private FriendGift _giftcount = null;

		// Token: 0x040004F8 RID: 1272
		private readonly List<uint> _receivedtime = new List<uint>();

		// Token: 0x040004F9 RID: 1273
		private IExtension extensionObject;
	}
}
