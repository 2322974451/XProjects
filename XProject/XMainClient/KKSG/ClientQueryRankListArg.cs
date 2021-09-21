using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000033 RID: 51
	[ProtoContract(Name = "ClientQueryRankListArg")]
	[Serializable]
	public class ClientQueryRankListArg : IExtensible
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600036A RID: 874 RVA: 0x000093D8 File Offset: 0x000075D8
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00009404 File Offset: 0x00007604
		[ProtoMember(1, IsRequired = false, Name = "RankType", DataFormat = DataFormat.TwosComplement)]
		public uint RankType
		{
			get
			{
				return this._RankType ?? 0U;
			}
			set
			{
				this._RankType = new uint?(value);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00009414 File Offset: 0x00007614
		// (set) Token: 0x0600036D RID: 877 RVA: 0x00009434 File Offset: 0x00007634
		[XmlIgnore]
		[Browsable(false)]
		public bool RankTypeSpecified
		{
			get
			{
				return this._RankType != null;
			}
			set
			{
				bool flag = value == (this._RankType == null);
				if (flag)
				{
					this._RankType = (value ? new uint?(this.RankType) : null);
				}
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00009478 File Offset: 0x00007678
		private bool ShouldSerializeRankType()
		{
			return this.RankTypeSpecified;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00009490 File Offset: 0x00007690
		private void ResetRankType()
		{
			this.RankTypeSpecified = false;
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000370 RID: 880 RVA: 0x0000949C File Offset: 0x0000769C
		// (set) Token: 0x06000371 RID: 881 RVA: 0x000094C8 File Offset: 0x000076C8
		[ProtoMember(2, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp ?? 0U;
			}
			set
			{
				this._TimeStamp = new uint?(value);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000372 RID: 882 RVA: 0x000094D8 File Offset: 0x000076D8
		// (set) Token: 0x06000373 RID: 883 RVA: 0x000094F8 File Offset: 0x000076F8
		[XmlIgnore]
		[Browsable(false)]
		public bool TimeStampSpecified
		{
			get
			{
				return this._TimeStamp != null;
			}
			set
			{
				bool flag = value == (this._TimeStamp == null);
				if (flag)
				{
					this._TimeStamp = (value ? new uint?(this.TimeStamp) : null);
				}
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000953C File Offset: 0x0000773C
		private bool ShouldSerializeTimeStamp()
		{
			return this.TimeStampSpecified;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00009554 File Offset: 0x00007754
		private void ResetTimeStamp()
		{
			this.TimeStampSpecified = false;
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000376 RID: 886 RVA: 0x00009560 File Offset: 0x00007760
		// (set) Token: 0x06000377 RID: 887 RVA: 0x0000958C File Offset: 0x0000778C
		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0000959C File Offset: 0x0000779C
		// (set) Token: 0x06000379 RID: 889 RVA: 0x000095BC File Offset: 0x000077BC
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00009600 File Offset: 0x00007800
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00009618 File Offset: 0x00007818
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600037C RID: 892 RVA: 0x00009624 File Offset: 0x00007824
		// (set) Token: 0x0600037D RID: 893 RVA: 0x00009651 File Offset: 0x00007851
		[ProtoMember(4, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600037E RID: 894 RVA: 0x00009660 File Offset: 0x00007860
		// (set) Token: 0x0600037F RID: 895 RVA: 0x00009680 File Offset: 0x00007880
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000096C4 File Offset: 0x000078C4
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x000096DC File Offset: 0x000078DC
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000382 RID: 898 RVA: 0x000096E8 File Offset: 0x000078E8
		// (set) Token: 0x06000383 RID: 899 RVA: 0x00009714 File Offset: 0x00007914
		[ProtoMember(5, IsRequired = false, Name = "firstPassID", DataFormat = DataFormat.TwosComplement)]
		public int firstPassID
		{
			get
			{
				return this._firstPassID ?? 0;
			}
			set
			{
				this._firstPassID = new int?(value);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000384 RID: 900 RVA: 0x00009724 File Offset: 0x00007924
		// (set) Token: 0x06000385 RID: 901 RVA: 0x00009744 File Offset: 0x00007944
		[XmlIgnore]
		[Browsable(false)]
		public bool firstPassIDSpecified
		{
			get
			{
				return this._firstPassID != null;
			}
			set
			{
				bool flag = value == (this._firstPassID == null);
				if (flag)
				{
					this._firstPassID = (value ? new int?(this.firstPassID) : null);
				}
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00009788 File Offset: 0x00007988
		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x000097A0 File Offset: 0x000079A0
		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000388 RID: 904 RVA: 0x000097AC File Offset: 0x000079AC
		// (set) Token: 0x06000389 RID: 905 RVA: 0x000097D8 File Offset: 0x000079D8
		[ProtoMember(6, IsRequired = false, Name = "sendPunishData", DataFormat = DataFormat.TwosComplement)]
		public uint sendPunishData
		{
			get
			{
				return this._sendPunishData ?? 0U;
			}
			set
			{
				this._sendPunishData = new uint?(value);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600038A RID: 906 RVA: 0x000097E8 File Offset: 0x000079E8
		// (set) Token: 0x0600038B RID: 907 RVA: 0x00009808 File Offset: 0x00007A08
		[XmlIgnore]
		[Browsable(false)]
		public bool sendPunishDataSpecified
		{
			get
			{
				return this._sendPunishData != null;
			}
			set
			{
				bool flag = value == (this._sendPunishData == null);
				if (flag)
				{
					this._sendPunishData = (value ? new uint?(this.sendPunishData) : null);
				}
			}
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000984C File Offset: 0x00007A4C
		private bool ShouldSerializesendPunishData()
		{
			return this.sendPunishDataSpecified;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00009864 File Offset: 0x00007A64
		private void ResetsendPunishData()
		{
			this.sendPunishDataSpecified = false;
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00009870 File Offset: 0x00007A70
		// (set) Token: 0x0600038F RID: 911 RVA: 0x0000989C File Offset: 0x00007A9C
		[ProtoMember(7, IsRequired = false, Name = "onlySelfData", DataFormat = DataFormat.Default)]
		public bool onlySelfData
		{
			get
			{
				return this._onlySelfData ?? false;
			}
			set
			{
				this._onlySelfData = new bool?(value);
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000390 RID: 912 RVA: 0x000098AC File Offset: 0x00007AAC
		// (set) Token: 0x06000391 RID: 913 RVA: 0x000098CC File Offset: 0x00007ACC
		[XmlIgnore]
		[Browsable(false)]
		public bool onlySelfDataSpecified
		{
			get
			{
				return this._onlySelfData != null;
			}
			set
			{
				bool flag = value == (this._onlySelfData == null);
				if (flag)
				{
					this._onlySelfData = (value ? new bool?(this.onlySelfData) : null);
				}
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00009910 File Offset: 0x00007B10
		private bool ShouldSerializeonlySelfData()
		{
			return this.onlySelfDataSpecified;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00009928 File Offset: 0x00007B28
		private void ResetonlySelfData()
		{
			this.onlySelfDataSpecified = false;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00009934 File Offset: 0x00007B34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000EA RID: 234
		private uint? _RankType;

		// Token: 0x040000EB RID: 235
		private uint? _TimeStamp;

		// Token: 0x040000EC RID: 236
		private uint? _profession;

		// Token: 0x040000ED RID: 237
		private ulong? _guildid;

		// Token: 0x040000EE RID: 238
		private int? _firstPassID;

		// Token: 0x040000EF RID: 239
		private uint? _sendPunishData;

		// Token: 0x040000F0 RID: 240
		private bool? _onlySelfData;

		// Token: 0x040000F1 RID: 241
		private IExtension extensionObject;
	}
}
