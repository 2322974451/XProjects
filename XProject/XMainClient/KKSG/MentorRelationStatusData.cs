using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D4 RID: 1748
	[ProtoContract(Name = "MentorRelationStatusData")]
	[Serializable]
	public class MentorRelationStatusData : IExtensible
	{
		// Token: 0x170024C8 RID: 9416
		// (get) Token: 0x0600742C RID: 29740 RVA: 0x000DE490 File Offset: 0x000DC690
		// (set) Token: 0x0600742D RID: 29741 RVA: 0x000DE4BC File Offset: 0x000DC6BC
		[ProtoMember(1, IsRequired = false, Name = "status", DataFormat = DataFormat.TwosComplement)]
		public uint status
		{
			get
			{
				return this._status ?? 0U;
			}
			set
			{
				this._status = new uint?(value);
			}
		}

		// Token: 0x170024C9 RID: 9417
		// (get) Token: 0x0600742E RID: 29742 RVA: 0x000DE4CC File Offset: 0x000DC6CC
		// (set) Token: 0x0600742F RID: 29743 RVA: 0x000DE4EC File Offset: 0x000DC6EC
		[XmlIgnore]
		[Browsable(false)]
		public bool statusSpecified
		{
			get
			{
				return this._status != null;
			}
			set
			{
				bool flag = value == (this._status == null);
				if (flag)
				{
					this._status = (value ? new uint?(this.status) : null);
				}
			}
		}

		// Token: 0x06007430 RID: 29744 RVA: 0x000DE530 File Offset: 0x000DC730
		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		// Token: 0x06007431 RID: 29745 RVA: 0x000DE548 File Offset: 0x000DC748
		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		// Token: 0x170024CA RID: 9418
		// (get) Token: 0x06007432 RID: 29746 RVA: 0x000DE554 File Offset: 0x000DC754
		// (set) Token: 0x06007433 RID: 29747 RVA: 0x000DE580 File Offset: 0x000DC780
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170024CB RID: 9419
		// (get) Token: 0x06007434 RID: 29748 RVA: 0x000DE590 File Offset: 0x000DC790
		// (set) Token: 0x06007435 RID: 29749 RVA: 0x000DE5B0 File Offset: 0x000DC7B0
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06007436 RID: 29750 RVA: 0x000DE5F4 File Offset: 0x000DC7F4
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007437 RID: 29751 RVA: 0x000DE60C File Offset: 0x000DC80C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06007438 RID: 29752 RVA: 0x000DE618 File Offset: 0x000DC818
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B9A RID: 7066
		private uint? _status;

		// Token: 0x04001B9B RID: 7067
		private uint? _time;

		// Token: 0x04001B9C RID: 7068
		private IExtension extensionObject;
	}
}
