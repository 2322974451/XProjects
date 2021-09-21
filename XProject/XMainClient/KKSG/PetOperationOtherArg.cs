using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000433 RID: 1075
	[ProtoContract(Name = "PetOperationOtherArg")]
	[Serializable]
	public class PetOperationOtherArg : IExtensible
	{
		// Token: 0x17001178 RID: 4472
		// (get) Token: 0x060038E0 RID: 14560 RVA: 0x0006CD84 File Offset: 0x0006AF84
		// (set) Token: 0x060038E1 RID: 14561 RVA: 0x0006CDB0 File Offset: 0x0006AFB0
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public PetOtherOp op
		{
			get
			{
				return this._op ?? PetOtherOp.DoPetPairRide;
			}
			set
			{
				this._op = new PetOtherOp?(value);
			}
		}

		// Token: 0x17001179 RID: 4473
		// (get) Token: 0x060038E2 RID: 14562 RVA: 0x0006CDC0 File Offset: 0x0006AFC0
		// (set) Token: 0x060038E3 RID: 14563 RVA: 0x0006CDE0 File Offset: 0x0006AFE0
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
					this._op = (value ? new PetOtherOp?(this.op) : null);
				}
			}
		}

		// Token: 0x060038E4 RID: 14564 RVA: 0x0006CE24 File Offset: 0x0006B024
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x060038E5 RID: 14565 RVA: 0x0006CE3C File Offset: 0x0006B03C
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x1700117A RID: 4474
		// (get) Token: 0x060038E6 RID: 14566 RVA: 0x0006CE48 File Offset: 0x0006B048
		// (set) Token: 0x060038E7 RID: 14567 RVA: 0x0006CE75 File Offset: 0x0006B075
		[ProtoMember(2, IsRequired = false, Name = "otherroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong otherroleid
		{
			get
			{
				return this._otherroleid ?? 0UL;
			}
			set
			{
				this._otherroleid = new ulong?(value);
			}
		}

		// Token: 0x1700117B RID: 4475
		// (get) Token: 0x060038E8 RID: 14568 RVA: 0x0006CE84 File Offset: 0x0006B084
		// (set) Token: 0x060038E9 RID: 14569 RVA: 0x0006CEA4 File Offset: 0x0006B0A4
		[XmlIgnore]
		[Browsable(false)]
		public bool otherroleidSpecified
		{
			get
			{
				return this._otherroleid != null;
			}
			set
			{
				bool flag = value == (this._otherroleid == null);
				if (flag)
				{
					this._otherroleid = (value ? new ulong?(this.otherroleid) : null);
				}
			}
		}

		// Token: 0x060038EA RID: 14570 RVA: 0x0006CEE8 File Offset: 0x0006B0E8
		private bool ShouldSerializeotherroleid()
		{
			return this.otherroleidSpecified;
		}

		// Token: 0x060038EB RID: 14571 RVA: 0x0006CF00 File Offset: 0x0006B100
		private void Resetotherroleid()
		{
			this.otherroleidSpecified = false;
		}

		// Token: 0x060038EC RID: 14572 RVA: 0x0006CF0C File Offset: 0x0006B10C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E1D RID: 3613
		private PetOtherOp? _op;

		// Token: 0x04000E1E RID: 3614
		private ulong? _otherroleid;

		// Token: 0x04000E1F RID: 3615
		private IExtension extensionObject;
	}
}
