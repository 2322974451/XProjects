using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200063F RID: 1599
	[ProtoContract(Name = "IdipPunishData")]
	[Serializable]
	public class IdipPunishData : IExtensible
	{
		// Token: 0x17001F47 RID: 8007
		// (get) Token: 0x0600633E RID: 25406 RVA: 0x000BD6CC File Offset: 0x000BB8CC
		// (set) Token: 0x0600633F RID: 25407 RVA: 0x000BD6F8 File Offset: 0x000BB8F8
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

		// Token: 0x17001F48 RID: 8008
		// (get) Token: 0x06006340 RID: 25408 RVA: 0x000BD708 File Offset: 0x000BB908
		// (set) Token: 0x06006341 RID: 25409 RVA: 0x000BD728 File Offset: 0x000BB928
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

		// Token: 0x06006342 RID: 25410 RVA: 0x000BD76C File Offset: 0x000BB96C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06006343 RID: 25411 RVA: 0x000BD784 File Offset: 0x000BB984
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001F49 RID: 8009
		// (get) Token: 0x06006344 RID: 25412 RVA: 0x000BD790 File Offset: 0x000BB990
		// (set) Token: 0x06006345 RID: 25413 RVA: 0x000BD7BC File Offset: 0x000BB9BC
		[ProtoMember(2, IsRequired = false, Name = "punishTime", DataFormat = DataFormat.TwosComplement)]
		public int punishTime
		{
			get
			{
				return this._punishTime ?? 0;
			}
			set
			{
				this._punishTime = new int?(value);
			}
		}

		// Token: 0x17001F4A RID: 8010
		// (get) Token: 0x06006346 RID: 25414 RVA: 0x000BD7CC File Offset: 0x000BB9CC
		// (set) Token: 0x06006347 RID: 25415 RVA: 0x000BD7EC File Offset: 0x000BB9EC
		[XmlIgnore]
		[Browsable(false)]
		public bool punishTimeSpecified
		{
			get
			{
				return this._punishTime != null;
			}
			set
			{
				bool flag = value == (this._punishTime == null);
				if (flag)
				{
					this._punishTime = (value ? new int?(this.punishTime) : null);
				}
			}
		}

		// Token: 0x06006348 RID: 25416 RVA: 0x000BD830 File Offset: 0x000BBA30
		private bool ShouldSerializepunishTime()
		{
			return this.punishTimeSpecified;
		}

		// Token: 0x06006349 RID: 25417 RVA: 0x000BD848 File Offset: 0x000BBA48
		private void ResetpunishTime()
		{
			this.punishTimeSpecified = false;
		}

		// Token: 0x17001F4B RID: 8011
		// (get) Token: 0x0600634A RID: 25418 RVA: 0x000BD854 File Offset: 0x000BBA54
		// (set) Token: 0x0600634B RID: 25419 RVA: 0x000BD880 File Offset: 0x000BBA80
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

		// Token: 0x17001F4C RID: 8012
		// (get) Token: 0x0600634C RID: 25420 RVA: 0x000BD890 File Offset: 0x000BBA90
		// (set) Token: 0x0600634D RID: 25421 RVA: 0x000BD8B0 File Offset: 0x000BBAB0
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

		// Token: 0x0600634E RID: 25422 RVA: 0x000BD8F4 File Offset: 0x000BBAF4
		private bool ShouldSerializebanTime()
		{
			return this.banTimeSpecified;
		}

		// Token: 0x0600634F RID: 25423 RVA: 0x000BD90C File Offset: 0x000BBB0C
		private void ResetbanTime()
		{
			this.banTimeSpecified = false;
		}

		// Token: 0x17001F4D RID: 8013
		// (get) Token: 0x06006350 RID: 25424 RVA: 0x000BD918 File Offset: 0x000BBB18
		// (set) Token: 0x06006351 RID: 25425 RVA: 0x000BD939 File Offset: 0x000BBB39
		[ProtoMember(4, IsRequired = false, Name = "reason", DataFormat = DataFormat.Default)]
		public string reason
		{
			get
			{
				return this._reason ?? "";
			}
			set
			{
				this._reason = value;
			}
		}

		// Token: 0x17001F4E RID: 8014
		// (get) Token: 0x06006352 RID: 25426 RVA: 0x000BD944 File Offset: 0x000BBB44
		// (set) Token: 0x06006353 RID: 25427 RVA: 0x000BD960 File Offset: 0x000BBB60
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
					this._reason = (value ? this.reason : null);
				}
			}
		}

		// Token: 0x06006354 RID: 25428 RVA: 0x000BD990 File Offset: 0x000BBB90
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x06006355 RID: 25429 RVA: 0x000BD9A8 File Offset: 0x000BBBA8
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x06006356 RID: 25430 RVA: 0x000BD9B4 File Offset: 0x000BBBB4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400180B RID: 6155
		private int? _type;

		// Token: 0x0400180C RID: 6156
		private int? _punishTime;

		// Token: 0x0400180D RID: 6157
		private int? _banTime;

		// Token: 0x0400180E RID: 6158
		private string _reason;

		// Token: 0x0400180F RID: 6159
		private IExtension extensionObject;
	}
}
