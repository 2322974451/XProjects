using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000169 RID: 361
	[ProtoContract(Name = "StartBattleFailedRes")]
	[Serializable]
	public class StartBattleFailedRes : IExtensible
	{
		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x060015DA RID: 5594 RVA: 0x0002BDA4 File Offset: 0x00029FA4
		// (set) Token: 0x060015DB RID: 5595 RVA: 0x0002BDD1 File Offset: 0x00029FD1
		[ProtoMember(1, IsRequired = false, Name = "proUserID", DataFormat = DataFormat.TwosComplement)]
		public ulong proUserID
		{
			get
			{
				return this._proUserID ?? 0UL;
			}
			set
			{
				this._proUserID = new ulong?(value);
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x060015DC RID: 5596 RVA: 0x0002BDE0 File Offset: 0x00029FE0
		// (set) Token: 0x060015DD RID: 5597 RVA: 0x0002BE00 File Offset: 0x0002A000
		[XmlIgnore]
		[Browsable(false)]
		public bool proUserIDSpecified
		{
			get
			{
				return this._proUserID != null;
			}
			set
			{
				bool flag = value == (this._proUserID == null);
				if (flag)
				{
					this._proUserID = (value ? new ulong?(this.proUserID) : null);
				}
			}
		}

		// Token: 0x060015DE RID: 5598 RVA: 0x0002BE44 File Offset: 0x0002A044
		private bool ShouldSerializeproUserID()
		{
			return this.proUserIDSpecified;
		}

		// Token: 0x060015DF RID: 5599 RVA: 0x0002BE5C File Offset: 0x0002A05C
		private void ResetproUserID()
		{
			this.proUserIDSpecified = false;
		}

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x060015E0 RID: 5600 RVA: 0x0002BE68 File Offset: 0x0002A068
		// (set) Token: 0x060015E1 RID: 5601 RVA: 0x0002BE94 File Offset: 0x0002A094
		[ProtoMember(2, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode reason
		{
			get
			{
				return this._reason ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._reason = new ErrorCode?(value);
			}
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x060015E2 RID: 5602 RVA: 0x0002BEA4 File Offset: 0x0002A0A4
		// (set) Token: 0x060015E3 RID: 5603 RVA: 0x0002BEC4 File Offset: 0x0002A0C4
		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? new ErrorCode?(this.reason) : null);
				}
			}
		}

		// Token: 0x060015E4 RID: 5604 RVA: 0x0002BF08 File Offset: 0x0002A108
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x0002BF20 File Offset: 0x0002A120
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x060015E6 RID: 5606 RVA: 0x0002BF2C File Offset: 0x0002A12C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400056E RID: 1390
		private ulong? _proUserID;

		// Token: 0x0400056F RID: 1391
		private ErrorCode? _reason;

		// Token: 0x04000570 RID: 1392
		private IExtension extensionObject;
	}
}
