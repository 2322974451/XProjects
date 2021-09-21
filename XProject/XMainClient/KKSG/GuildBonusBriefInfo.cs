using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006EB RID: 1771
	[ProtoContract(Name = "GuildBonusBriefInfo")]
	[Serializable]
	public class GuildBonusBriefInfo : IExtensible
	{
		// Token: 0x1700258E RID: 9614
		// (get) Token: 0x0600769D RID: 30365 RVA: 0x000E2F08 File Offset: 0x000E1108
		// (set) Token: 0x0600769E RID: 30366 RVA: 0x000E2F34 File Offset: 0x000E1134
		[ProtoMember(1, IsRequired = false, Name = "bonusID", DataFormat = DataFormat.TwosComplement)]
		public uint bonusID
		{
			get
			{
				return this._bonusID ?? 0U;
			}
			set
			{
				this._bonusID = new uint?(value);
			}
		}

		// Token: 0x1700258F RID: 9615
		// (get) Token: 0x0600769F RID: 30367 RVA: 0x000E2F44 File Offset: 0x000E1144
		// (set) Token: 0x060076A0 RID: 30368 RVA: 0x000E2F64 File Offset: 0x000E1164
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusIDSpecified
		{
			get
			{
				return this._bonusID != null;
			}
			set
			{
				bool flag = value == (this._bonusID == null);
				if (flag)
				{
					this._bonusID = (value ? new uint?(this.bonusID) : null);
				}
			}
		}

		// Token: 0x060076A1 RID: 30369 RVA: 0x000E2FA8 File Offset: 0x000E11A8
		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		// Token: 0x060076A2 RID: 30370 RVA: 0x000E2FC0 File Offset: 0x000E11C0
		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		// Token: 0x17002590 RID: 9616
		// (get) Token: 0x060076A3 RID: 30371 RVA: 0x000E2FCC File Offset: 0x000E11CC
		// (set) Token: 0x060076A4 RID: 30372 RVA: 0x000E2FF8 File Offset: 0x000E11F8
		[ProtoMember(2, IsRequired = false, Name = "sendTime", DataFormat = DataFormat.TwosComplement)]
		public int sendTime
		{
			get
			{
				return this._sendTime ?? 0;
			}
			set
			{
				this._sendTime = new int?(value);
			}
		}

		// Token: 0x17002591 RID: 9617
		// (get) Token: 0x060076A5 RID: 30373 RVA: 0x000E3008 File Offset: 0x000E1208
		// (set) Token: 0x060076A6 RID: 30374 RVA: 0x000E3028 File Offset: 0x000E1228
		[XmlIgnore]
		[Browsable(false)]
		public bool sendTimeSpecified
		{
			get
			{
				return this._sendTime != null;
			}
			set
			{
				bool flag = value == (this._sendTime == null);
				if (flag)
				{
					this._sendTime = (value ? new int?(this.sendTime) : null);
				}
			}
		}

		// Token: 0x060076A7 RID: 30375 RVA: 0x000E306C File Offset: 0x000E126C
		private bool ShouldSerializesendTime()
		{
			return this.sendTimeSpecified;
		}

		// Token: 0x060076A8 RID: 30376 RVA: 0x000E3084 File Offset: 0x000E1284
		private void ResetsendTime()
		{
			this.sendTimeSpecified = false;
		}

		// Token: 0x060076A9 RID: 30377 RVA: 0x000E3090 File Offset: 0x000E1290
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C19 RID: 7193
		private uint? _bonusID;

		// Token: 0x04001C1A RID: 7194
		private int? _sendTime;

		// Token: 0x04001C1B RID: 7195
		private IExtension extensionObject;
	}
}
