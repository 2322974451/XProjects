using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000230 RID: 560
	[ProtoContract(Name = "IdipPunishInfo")]
	[Serializable]
	public class IdipPunishInfo : IExtensible
	{
		// Token: 0x170009B9 RID: 2489
		// (get) Token: 0x06001F2D RID: 7981 RVA: 0x0003D24C File Offset: 0x0003B44C
		// (set) Token: 0x06001F2E RID: 7982 RVA: 0x0003D278 File Offset: 0x0003B478
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x170009BA RID: 2490
		// (get) Token: 0x06001F2F RID: 7983 RVA: 0x0003D288 File Offset: 0x0003B488
		// (set) Token: 0x06001F30 RID: 7984 RVA: 0x0003D2A8 File Offset: 0x0003B4A8
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x06001F31 RID: 7985 RVA: 0x0003D2EC File Offset: 0x0003B4EC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001F32 RID: 7986 RVA: 0x0003D304 File Offset: 0x0003B504
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170009BB RID: 2491
		// (get) Token: 0x06001F33 RID: 7987 RVA: 0x0003D310 File Offset: 0x0003B510
		// (set) Token: 0x06001F34 RID: 7988 RVA: 0x0003D33C File Offset: 0x0003B53C
		[ProtoMember(2, IsRequired = false, Name = "endTime", DataFormat = DataFormat.TwosComplement)]
		public int endTime
		{
			get
			{
				return this._endTime ?? 0;
			}
			set
			{
				this._endTime = new int?(value);
			}
		}

		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06001F35 RID: 7989 RVA: 0x0003D34C File Offset: 0x0003B54C
		// (set) Token: 0x06001F36 RID: 7990 RVA: 0x0003D36C File Offset: 0x0003B56C
		[XmlIgnore]
		[Browsable(false)]
		public bool endTimeSpecified
		{
			get
			{
				return this._endTime != null;
			}
			set
			{
				bool flag = value == (this._endTime == null);
				if (flag)
				{
					this._endTime = (value ? new int?(this.endTime) : null);
				}
			}
		}

		// Token: 0x06001F37 RID: 7991 RVA: 0x0003D3B0 File Offset: 0x0003B5B0
		private bool ShouldSerializeendTime()
		{
			return this.endTimeSpecified;
		}

		// Token: 0x06001F38 RID: 7992 RVA: 0x0003D3C8 File Offset: 0x0003B5C8
		private void ResetendTime()
		{
			this.endTimeSpecified = false;
		}

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x06001F39 RID: 7993 RVA: 0x0003D3D4 File Offset: 0x0003B5D4
		// (set) Token: 0x06001F3A RID: 7994 RVA: 0x0003D400 File Offset: 0x0003B600
		[ProtoMember(3, IsRequired = false, Name = "banTime", DataFormat = DataFormat.TwosComplement)]
		public int banTime
		{
			get
			{
				return this._banTime ?? 0;
			}
			set
			{
				this._banTime = new int?(value);
			}
		}

		// Token: 0x170009BE RID: 2494
		// (get) Token: 0x06001F3B RID: 7995 RVA: 0x0003D410 File Offset: 0x0003B610
		// (set) Token: 0x06001F3C RID: 7996 RVA: 0x0003D430 File Offset: 0x0003B630
		[XmlIgnore]
		[Browsable(false)]
		public bool banTimeSpecified
		{
			get
			{
				return this._banTime != null;
			}
			set
			{
				bool flag = value == (this._banTime == null);
				if (flag)
				{
					this._banTime = (value ? new int?(this.banTime) : null);
				}
			}
		}

		// Token: 0x06001F3D RID: 7997 RVA: 0x0003D474 File Offset: 0x0003B674
		private bool ShouldSerializebanTime()
		{
			return this.banTimeSpecified;
		}

		// Token: 0x06001F3E RID: 7998 RVA: 0x0003D48C File Offset: 0x0003B68C
		private void ResetbanTime()
		{
			this.banTimeSpecified = false;
		}

		// Token: 0x170009BF RID: 2495
		// (get) Token: 0x06001F3F RID: 7999 RVA: 0x0003D498 File Offset: 0x0003B698
		// (set) Token: 0x06001F40 RID: 8000 RVA: 0x0003D4C4 File Offset: 0x0003B6C4
		[ProtoMember(4, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		// Token: 0x170009C0 RID: 2496
		// (get) Token: 0x06001F41 RID: 8001 RVA: 0x0003D4D4 File Offset: 0x0003B6D4
		// (set) Token: 0x06001F42 RID: 8002 RVA: 0x0003D4F4 File Offset: 0x0003B6F4
		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		// Token: 0x06001F43 RID: 8003 RVA: 0x0003D538 File Offset: 0x0003B738
		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		// Token: 0x06001F44 RID: 8004 RVA: 0x0003D550 File Offset: 0x0003B750
		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		// Token: 0x06001F45 RID: 8005 RVA: 0x0003D55C File Offset: 0x0003B75C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007C8 RID: 1992
		private int? _type;

		// Token: 0x040007C9 RID: 1993
		private int? _endTime;

		// Token: 0x040007CA RID: 1994
		private int? _banTime;

		// Token: 0x040007CB RID: 1995
		private int? _leftTime;

		// Token: 0x040007CC RID: 1996
		private IExtension extensionObject;
	}
}
