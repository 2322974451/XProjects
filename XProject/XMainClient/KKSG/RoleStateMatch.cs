using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F9 RID: 249
	[ProtoContract(Name = "RoleStateMatch")]
	[Serializable]
	public class RoleStateMatch : IExtensible
	{
		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x00020AFC File Offset: 0x0001ECFC
		// (set) Token: 0x06000FE7 RID: 4071 RVA: 0x00020B28 File Offset: 0x0001ED28
		[ProtoMember(1, IsRequired = false, Name = "IsMatching", DataFormat = DataFormat.Default)]
		public bool IsMatching
		{
			get
			{
				return this._IsMatching ?? false;
			}
			set
			{
				this._IsMatching = new bool?(value);
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06000FE8 RID: 4072 RVA: 0x00020B38 File Offset: 0x0001ED38
		// (set) Token: 0x06000FE9 RID: 4073 RVA: 0x00020B58 File Offset: 0x0001ED58
		[XmlIgnore]
		[Browsable(false)]
		public bool IsMatchingSpecified
		{
			get
			{
				return this._IsMatching != null;
			}
			set
			{
				bool flag = value == (this._IsMatching == null);
				if (flag)
				{
					this._IsMatching = (value ? new bool?(this.IsMatching) : null);
				}
			}
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x00020B9C File Offset: 0x0001ED9C
		private bool ShouldSerializeIsMatching()
		{
			return this.IsMatchingSpecified;
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x00020BB4 File Offset: 0x0001EDB4
		private void ResetIsMatching()
		{
			this.IsMatchingSpecified = false;
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06000FEC RID: 4076 RVA: 0x00020BC0 File Offset: 0x0001EDC0
		// (set) Token: 0x06000FED RID: 4077 RVA: 0x00020BEC File Offset: 0x0001EDEC
		[ProtoMember(2, IsRequired = false, Name = "stopmatchreason1", DataFormat = DataFormat.TwosComplement)]
		public StopMatchReason stopmatchreason1
		{
			get
			{
				return this._stopmatchreason1 ?? StopMatchReason.STOPMATCH_NONE;
			}
			set
			{
				this._stopmatchreason1 = new StopMatchReason?(value);
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06000FEE RID: 4078 RVA: 0x00020BFC File Offset: 0x0001EDFC
		// (set) Token: 0x06000FEF RID: 4079 RVA: 0x00020C1C File Offset: 0x0001EE1C
		[XmlIgnore]
		[Browsable(false)]
		public bool stopmatchreason1Specified
		{
			get
			{
				return this._stopmatchreason1 != null;
			}
			set
			{
				bool flag = value == (this._stopmatchreason1 == null);
				if (flag)
				{
					this._stopmatchreason1 = (value ? new StopMatchReason?(this.stopmatchreason1) : null);
				}
			}
		}

		// Token: 0x06000FF0 RID: 4080 RVA: 0x00020C60 File Offset: 0x0001EE60
		private bool ShouldSerializestopmatchreason1()
		{
			return this.stopmatchreason1Specified;
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x00020C78 File Offset: 0x0001EE78
		private void Resetstopmatchreason1()
		{
			this.stopmatchreason1Specified = false;
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x00020C84 File Offset: 0x0001EE84
		// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x00020CB0 File Offset: 0x0001EEB0
		[ProtoMember(3, IsRequired = false, Name = "matchtype", DataFormat = DataFormat.TwosComplement)]
		public KMatchType matchtype
		{
			get
			{
				return this._matchtype ?? KMatchType.KMT_NONE;
			}
			set
			{
				this._matchtype = new KMatchType?(value);
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x00020CC0 File Offset: 0x0001EEC0
		// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x00020CE0 File Offset: 0x0001EEE0
		[XmlIgnore]
		[Browsable(false)]
		public bool matchtypeSpecified
		{
			get
			{
				return this._matchtype != null;
			}
			set
			{
				bool flag = value == (this._matchtype == null);
				if (flag)
				{
					this._matchtype = (value ? new KMatchType?(this.matchtype) : null);
				}
			}
		}

		// Token: 0x06000FF6 RID: 4086 RVA: 0x00020D24 File Offset: 0x0001EF24
		private bool ShouldSerializematchtype()
		{
			return this.matchtypeSpecified;
		}

		// Token: 0x06000FF7 RID: 4087 RVA: 0x00020D3C File Offset: 0x0001EF3C
		private void Resetmatchtype()
		{
			this.matchtypeSpecified = false;
		}

		// Token: 0x06000FF8 RID: 4088 RVA: 0x00020D48 File Offset: 0x0001EF48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003F9 RID: 1017
		private bool? _IsMatching;

		// Token: 0x040003FA RID: 1018
		private StopMatchReason? _stopmatchreason1;

		// Token: 0x040003FB RID: 1019
		private KMatchType? _matchtype;

		// Token: 0x040003FC RID: 1020
		private IExtension extensionObject;
	}
}
