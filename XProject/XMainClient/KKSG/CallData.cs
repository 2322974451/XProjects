using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002EB RID: 747
	[ProtoContract(Name = "CallData")]
	[Serializable]
	public class CallData : IExtensible
	{
		// Token: 0x17000CBE RID: 3262
		// (get) Token: 0x0600290B RID: 10507 RVA: 0x0004FB14 File Offset: 0x0004DD14
		// (set) Token: 0x0600290C RID: 10508 RVA: 0x0004FB40 File Offset: 0x0004DD40
		[ProtoMember(1, IsRequired = false, Name = "skillid", DataFormat = DataFormat.TwosComplement)]
		public uint skillid
		{
			get
			{
				return this._skillid ?? 0U;
			}
			set
			{
				this._skillid = new uint?(value);
			}
		}

		// Token: 0x17000CBF RID: 3263
		// (get) Token: 0x0600290D RID: 10509 RVA: 0x0004FB50 File Offset: 0x0004DD50
		// (set) Token: 0x0600290E RID: 10510 RVA: 0x0004FB70 File Offset: 0x0004DD70
		[XmlIgnore]
		[Browsable(false)]
		public bool skillidSpecified
		{
			get
			{
				return this._skillid != null;
			}
			set
			{
				bool flag = value == (this._skillid == null);
				if (flag)
				{
					this._skillid = (value ? new uint?(this.skillid) : null);
				}
			}
		}

		// Token: 0x0600290F RID: 10511 RVA: 0x0004FBB4 File Offset: 0x0004DDB4
		private bool ShouldSerializeskillid()
		{
			return this.skillidSpecified;
		}

		// Token: 0x06002910 RID: 10512 RVA: 0x0004FBCC File Offset: 0x0004DDCC
		private void Resetskillid()
		{
			this.skillidSpecified = false;
		}

		// Token: 0x17000CC0 RID: 3264
		// (get) Token: 0x06002911 RID: 10513 RVA: 0x0004FBD8 File Offset: 0x0004DDD8
		// (set) Token: 0x06002912 RID: 10514 RVA: 0x0004FC04 File Offset: 0x0004DE04
		[ProtoMember(2, IsRequired = false, Name = "sequence", DataFormat = DataFormat.TwosComplement)]
		public int sequence
		{
			get
			{
				return this._sequence ?? 0;
			}
			set
			{
				this._sequence = new int?(value);
			}
		}

		// Token: 0x17000CC1 RID: 3265
		// (get) Token: 0x06002913 RID: 10515 RVA: 0x0004FC14 File Offset: 0x0004DE14
		// (set) Token: 0x06002914 RID: 10516 RVA: 0x0004FC34 File Offset: 0x0004DE34
		[XmlIgnore]
		[Browsable(false)]
		public bool sequenceSpecified
		{
			get
			{
				return this._sequence != null;
			}
			set
			{
				bool flag = value == (this._sequence == null);
				if (flag)
				{
					this._sequence = (value ? new int?(this.sequence) : null);
				}
			}
		}

		// Token: 0x06002915 RID: 10517 RVA: 0x0004FC78 File Offset: 0x0004DE78
		private bool ShouldSerializesequence()
		{
			return this.sequenceSpecified;
		}

		// Token: 0x06002916 RID: 10518 RVA: 0x0004FC90 File Offset: 0x0004DE90
		private void Resetsequence()
		{
			this.sequenceSpecified = false;
		}

		// Token: 0x17000CC2 RID: 3266
		// (get) Token: 0x06002917 RID: 10519 RVA: 0x0004FC9C File Offset: 0x0004DE9C
		// (set) Token: 0x06002918 RID: 10520 RVA: 0x0004FCC8 File Offset: 0x0004DEC8
		[ProtoMember(3, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public int slot
		{
			get
			{
				return this._slot ?? 0;
			}
			set
			{
				this._slot = new int?(value);
			}
		}

		// Token: 0x17000CC3 RID: 3267
		// (get) Token: 0x06002919 RID: 10521 RVA: 0x0004FCD8 File Offset: 0x0004DED8
		// (set) Token: 0x0600291A RID: 10522 RVA: 0x0004FCF8 File Offset: 0x0004DEF8
		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new int?(this.slot) : null);
				}
			}
		}

		// Token: 0x0600291B RID: 10523 RVA: 0x0004FD3C File Offset: 0x0004DF3C
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x0600291C RID: 10524 RVA: 0x0004FD54 File Offset: 0x0004DF54
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x17000CC4 RID: 3268
		// (get) Token: 0x0600291D RID: 10525 RVA: 0x0004FD60 File Offset: 0x0004DF60
		// (set) Token: 0x0600291E RID: 10526 RVA: 0x0004FD8C File Offset: 0x0004DF8C
		[ProtoMember(4, IsRequired = false, Name = "leftrunningtime", DataFormat = DataFormat.TwosComplement)]
		public int leftrunningtime
		{
			get
			{
				return this._leftrunningtime ?? 0;
			}
			set
			{
				this._leftrunningtime = new int?(value);
			}
		}

		// Token: 0x17000CC5 RID: 3269
		// (get) Token: 0x0600291F RID: 10527 RVA: 0x0004FD9C File Offset: 0x0004DF9C
		// (set) Token: 0x06002920 RID: 10528 RVA: 0x0004FDBC File Offset: 0x0004DFBC
		[XmlIgnore]
		[Browsable(false)]
		public bool leftrunningtimeSpecified
		{
			get
			{
				return this._leftrunningtime != null;
			}
			set
			{
				bool flag = value == (this._leftrunningtime == null);
				if (flag)
				{
					this._leftrunningtime = (value ? new int?(this.leftrunningtime) : null);
				}
			}
		}

		// Token: 0x06002921 RID: 10529 RVA: 0x0004FE00 File Offset: 0x0004E000
		private bool ShouldSerializeleftrunningtime()
		{
			return this.leftrunningtimeSpecified;
		}

		// Token: 0x06002922 RID: 10530 RVA: 0x0004FE18 File Offset: 0x0004E018
		private void Resetleftrunningtime()
		{
			this.leftrunningtimeSpecified = false;
		}

		// Token: 0x17000CC6 RID: 3270
		// (get) Token: 0x06002923 RID: 10531 RVA: 0x0004FE24 File Offset: 0x0004E024
		// (set) Token: 0x06002924 RID: 10532 RVA: 0x0004FE50 File Offset: 0x0004E050
		[ProtoMember(5, IsRequired = false, Name = "onsyntonic", DataFormat = DataFormat.Default)]
		public bool onsyntonic
		{
			get
			{
				return this._onsyntonic ?? false;
			}
			set
			{
				this._onsyntonic = new bool?(value);
			}
		}

		// Token: 0x17000CC7 RID: 3271
		// (get) Token: 0x06002925 RID: 10533 RVA: 0x0004FE60 File Offset: 0x0004E060
		// (set) Token: 0x06002926 RID: 10534 RVA: 0x0004FE80 File Offset: 0x0004E080
		[XmlIgnore]
		[Browsable(false)]
		public bool onsyntonicSpecified
		{
			get
			{
				return this._onsyntonic != null;
			}
			set
			{
				bool flag = value == (this._onsyntonic == null);
				if (flag)
				{
					this._onsyntonic = (value ? new bool?(this.onsyntonic) : null);
				}
			}
		}

		// Token: 0x06002927 RID: 10535 RVA: 0x0004FEC4 File Offset: 0x0004E0C4
		private bool ShouldSerializeonsyntonic()
		{
			return this.onsyntonicSpecified;
		}

		// Token: 0x06002928 RID: 10536 RVA: 0x0004FEDC File Offset: 0x0004E0DC
		private void Resetonsyntonic()
		{
			this.onsyntonicSpecified = false;
		}

		// Token: 0x06002929 RID: 10537 RVA: 0x0004FEE8 File Offset: 0x0004E0E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A34 RID: 2612
		private uint? _skillid;

		// Token: 0x04000A35 RID: 2613
		private int? _sequence;

		// Token: 0x04000A36 RID: 2614
		private int? _slot;

		// Token: 0x04000A37 RID: 2615
		private int? _leftrunningtime;

		// Token: 0x04000A38 RID: 2616
		private bool? _onsyntonic;

		// Token: 0x04000A39 RID: 2617
		private IExtension extensionObject;
	}
}
