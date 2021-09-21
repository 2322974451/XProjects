using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200013F RID: 319
	[ProtoContract(Name = "PvpBattleEndData")]
	[Serializable]
	public class PvpBattleEndData : IExtensible
	{
		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x060013AB RID: 5035 RVA: 0x00027BE0 File Offset: 0x00025DE0
		// (set) Token: 0x060013AC RID: 5036 RVA: 0x00027C0C File Offset: 0x00025E0C
		[ProtoMember(1, IsRequired = false, Name = "wingroup", DataFormat = DataFormat.TwosComplement)]
		public int wingroup
		{
			get
			{
				return this._wingroup ?? 0;
			}
			set
			{
				this._wingroup = new int?(value);
			}
		}

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x060013AD RID: 5037 RVA: 0x00027C1C File Offset: 0x00025E1C
		// (set) Token: 0x060013AE RID: 5038 RVA: 0x00027C3C File Offset: 0x00025E3C
		[XmlIgnore]
		[Browsable(false)]
		public bool wingroupSpecified
		{
			get
			{
				return this._wingroup != null;
			}
			set
			{
				bool flag = value == (this._wingroup == null);
				if (flag)
				{
					this._wingroup = (value ? new int?(this.wingroup) : null);
				}
			}
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x00027C80 File Offset: 0x00025E80
		private bool ShouldSerializewingroup()
		{
			return this.wingroupSpecified;
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x00027C98 File Offset: 0x00025E98
		private void Resetwingroup()
		{
			this.wingroupSpecified = false;
		}

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x060013B1 RID: 5041 RVA: 0x00027CA4 File Offset: 0x00025EA4
		// (set) Token: 0x060013B2 RID: 5042 RVA: 0x00027CD0 File Offset: 0x00025ED0
		[ProtoMember(2, IsRequired = false, Name = "isAllEnd", DataFormat = DataFormat.Default)]
		public bool isAllEnd
		{
			get
			{
				return this._isAllEnd ?? false;
			}
			set
			{
				this._isAllEnd = new bool?(value);
			}
		}

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x060013B3 RID: 5043 RVA: 0x00027CE0 File Offset: 0x00025EE0
		// (set) Token: 0x060013B4 RID: 5044 RVA: 0x00027D00 File Offset: 0x00025F00
		[XmlIgnore]
		[Browsable(false)]
		public bool isAllEndSpecified
		{
			get
			{
				return this._isAllEnd != null;
			}
			set
			{
				bool flag = value == (this._isAllEnd == null);
				if (flag)
				{
					this._isAllEnd = (value ? new bool?(this.isAllEnd) : null);
				}
			}
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x00027D44 File Offset: 0x00025F44
		private bool ShouldSerializeisAllEnd()
		{
			return this.isAllEndSpecified;
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x00027D5C File Offset: 0x00025F5C
		private void ResetisAllEnd()
		{
			this.isAllEndSpecified = false;
		}

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x060013B7 RID: 5047 RVA: 0x00027D68 File Offset: 0x00025F68
		// (set) Token: 0x060013B8 RID: 5048 RVA: 0x00027D94 File Offset: 0x00025F94
		[ProtoMember(3, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public PVP_ONEGAMEEND_REASON reason
		{
			get
			{
				return this._reason ?? PVP_ONEGAMEEND_REASON.PVP_OGE_LEADER_DIE;
			}
			set
			{
				this._reason = new PVP_ONEGAMEEND_REASON?(value);
			}
		}

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x060013B9 RID: 5049 RVA: 0x00027DA4 File Offset: 0x00025FA4
		// (set) Token: 0x060013BA RID: 5050 RVA: 0x00027DC4 File Offset: 0x00025FC4
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
					this._reason = (value ? new PVP_ONEGAMEEND_REASON?(this.reason) : null);
				}
			}
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x00027E08 File Offset: 0x00026008
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x00027E20 File Offset: 0x00026020
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x00027E2C File Offset: 0x0002602C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004E1 RID: 1249
		private int? _wingroup;

		// Token: 0x040004E2 RID: 1250
		private bool? _isAllEnd;

		// Token: 0x040004E3 RID: 1251
		private PVP_ONEGAMEEND_REASON? _reason;

		// Token: 0x040004E4 RID: 1252
		private IExtension extensionObject;
	}
}
