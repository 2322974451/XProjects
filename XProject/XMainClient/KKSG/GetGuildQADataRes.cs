using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200016F RID: 367
	[ProtoContract(Name = "GetGuildQADataRes")]
	[Serializable]
	public class GetGuildQADataRes : IExtensible
	{
		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06001604 RID: 5636 RVA: 0x0002C238 File Offset: 0x0002A438
		// (set) Token: 0x06001605 RID: 5637 RVA: 0x0002C264 File Offset: 0x0002A464
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

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06001606 RID: 5638 RVA: 0x0002C274 File Offset: 0x0002A474
		// (set) Token: 0x06001607 RID: 5639 RVA: 0x0002C294 File Offset: 0x0002A494
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

		// Token: 0x06001608 RID: 5640 RVA: 0x0002C2D8 File Offset: 0x0002A4D8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001609 RID: 5641 RVA: 0x0002C2F0 File Offset: 0x0002A4F0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x0600160A RID: 5642 RVA: 0x0002C2FC File Offset: 0x0002A4FC
		// (set) Token: 0x0600160B RID: 5643 RVA: 0x0002C328 File Offset: 0x0002A528
		[ProtoMember(2, IsRequired = false, Name = "status", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x0600160C RID: 5644 RVA: 0x0002C338 File Offset: 0x0002A538
		// (set) Token: 0x0600160D RID: 5645 RVA: 0x0002C358 File Offset: 0x0002A558
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

		// Token: 0x0600160E RID: 5646 RVA: 0x0002C39C File Offset: 0x0002A59C
		private bool ShouldSerializestatus()
		{
			return this.statusSpecified;
		}

		// Token: 0x0600160F RID: 5647 RVA: 0x0002C3B4 File Offset: 0x0002A5B4
		private void Resetstatus()
		{
			this.statusSpecified = false;
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x06001610 RID: 5648 RVA: 0x0002C3C0 File Offset: 0x0002A5C0
		// (set) Token: 0x06001611 RID: 5649 RVA: 0x0002C3EC File Offset: 0x0002A5EC
		[ProtoMember(3, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x06001612 RID: 5650 RVA: 0x0002C3FC File Offset: 0x0002A5FC
		// (set) Token: 0x06001613 RID: 5651 RVA: 0x0002C41C File Offset: 0x0002A61C
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

		// Token: 0x06001614 RID: 5652 RVA: 0x0002C460 File Offset: 0x0002A660
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06001615 RID: 5653 RVA: 0x0002C478 File Offset: 0x0002A678
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x0002C484 File Offset: 0x0002A684
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000579 RID: 1401
		private ErrorCode? _result;

		// Token: 0x0400057A RID: 1402
		private uint? _status;

		// Token: 0x0400057B RID: 1403
		private uint? _time;

		// Token: 0x0400057C RID: 1404
		private IExtension extensionObject;
	}
}
