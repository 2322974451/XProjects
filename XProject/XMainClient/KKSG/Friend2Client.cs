using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B2 RID: 1458
	[ProtoContract(Name = "Friend2Client")]
	[Serializable]
	public class Friend2Client : IExtensible
	{
		// Token: 0x1700188C RID: 6284
		// (get) Token: 0x06004F8A RID: 20362 RVA: 0x0009741C File Offset: 0x0009561C
		// (set) Token: 0x06004F8B RID: 20363 RVA: 0x00097449 File Offset: 0x00095649
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x1700188D RID: 6285
		// (get) Token: 0x06004F8C RID: 20364 RVA: 0x00097458 File Offset: 0x00095658
		// (set) Token: 0x06004F8D RID: 20365 RVA: 0x00097478 File Offset: 0x00095678
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06004F8E RID: 20366 RVA: 0x000974BC File Offset: 0x000956BC
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06004F8F RID: 20367 RVA: 0x000974D4 File Offset: 0x000956D4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700188E RID: 6286
		// (get) Token: 0x06004F90 RID: 20368 RVA: 0x000974E0 File Offset: 0x000956E0
		// (set) Token: 0x06004F91 RID: 20369 RVA: 0x0009750C File Offset: 0x0009570C
		[ProtoMember(2, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700188F RID: 6287
		// (get) Token: 0x06004F92 RID: 20370 RVA: 0x0009751C File Offset: 0x0009571C
		// (set) Token: 0x06004F93 RID: 20371 RVA: 0x0009753C File Offset: 0x0009573C
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

		// Token: 0x06004F94 RID: 20372 RVA: 0x00097580 File Offset: 0x00095780
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06004F95 RID: 20373 RVA: 0x00097598 File Offset: 0x00095798
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x17001890 RID: 6288
		// (get) Token: 0x06004F96 RID: 20374 RVA: 0x000975A4 File Offset: 0x000957A4
		// (set) Token: 0x06004F97 RID: 20375 RVA: 0x000975D0 File Offset: 0x000957D0
		[ProtoMember(3, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17001891 RID: 6289
		// (get) Token: 0x06004F98 RID: 20376 RVA: 0x000975E0 File Offset: 0x000957E0
		// (set) Token: 0x06004F99 RID: 20377 RVA: 0x00097600 File Offset: 0x00095800
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06004F9A RID: 20378 RVA: 0x00097644 File Offset: 0x00095844
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06004F9B RID: 20379 RVA: 0x0009765C File Offset: 0x0009585C
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17001892 RID: 6290
		// (get) Token: 0x06004F9C RID: 20380 RVA: 0x00097668 File Offset: 0x00095868
		// (set) Token: 0x06004F9D RID: 20381 RVA: 0x00097694 File Offset: 0x00095894
		[ProtoMember(4, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		// Token: 0x17001893 RID: 6291
		// (get) Token: 0x06004F9E RID: 20382 RVA: 0x000976A4 File Offset: 0x000958A4
		// (set) Token: 0x06004F9F RID: 20383 RVA: 0x000976C4 File Offset: 0x000958C4
		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		// Token: 0x06004FA0 RID: 20384 RVA: 0x00097708 File Offset: 0x00095908
		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		// Token: 0x06004FA1 RID: 20385 RVA: 0x00097720 File Offset: 0x00095920
		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		// Token: 0x17001894 RID: 6292
		// (get) Token: 0x06004FA2 RID: 20386 RVA: 0x0009772C File Offset: 0x0009592C
		// (set) Token: 0x06004FA3 RID: 20387 RVA: 0x00097758 File Offset: 0x00095958
		[ProtoMember(5, IsRequired = false, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public uint viplevel
		{
			get
			{
				return this._viplevel ?? 0U;
			}
			set
			{
				this._viplevel = new uint?(value);
			}
		}

		// Token: 0x17001895 RID: 6293
		// (get) Token: 0x06004FA4 RID: 20388 RVA: 0x00097768 File Offset: 0x00095968
		// (set) Token: 0x06004FA5 RID: 20389 RVA: 0x00097788 File Offset: 0x00095988
		[XmlIgnore]
		[Browsable(false)]
		public bool viplevelSpecified
		{
			get
			{
				return this._viplevel != null;
			}
			set
			{
				bool flag = value == (this._viplevel == null);
				if (flag)
				{
					this._viplevel = (value ? new uint?(this.viplevel) : null);
				}
			}
		}

		// Token: 0x06004FA6 RID: 20390 RVA: 0x000977CC File Offset: 0x000959CC
		private bool ShouldSerializeviplevel()
		{
			return this.viplevelSpecified;
		}

		// Token: 0x06004FA7 RID: 20391 RVA: 0x000977E4 File Offset: 0x000959E4
		private void Resetviplevel()
		{
			this.viplevelSpecified = false;
		}

		// Token: 0x17001896 RID: 6294
		// (get) Token: 0x06004FA8 RID: 20392 RVA: 0x000977F0 File Offset: 0x000959F0
		// (set) Token: 0x06004FA9 RID: 20393 RVA: 0x0009781C File Offset: 0x00095A1C
		[ProtoMember(6, IsRequired = false, Name = "lastlogin", DataFormat = DataFormat.TwosComplement)]
		public uint lastlogin
		{
			get
			{
				return this._lastlogin ?? 0U;
			}
			set
			{
				this._lastlogin = new uint?(value);
			}
		}

		// Token: 0x17001897 RID: 6295
		// (get) Token: 0x06004FAA RID: 20394 RVA: 0x0009782C File Offset: 0x00095A2C
		// (set) Token: 0x06004FAB RID: 20395 RVA: 0x0009784C File Offset: 0x00095A4C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastloginSpecified
		{
			get
			{
				return this._lastlogin != null;
			}
			set
			{
				bool flag = value == (this._lastlogin == null);
				if (flag)
				{
					this._lastlogin = (value ? new uint?(this.lastlogin) : null);
				}
			}
		}

		// Token: 0x06004FAC RID: 20396 RVA: 0x00097890 File Offset: 0x00095A90
		private bool ShouldSerializelastlogin()
		{
			return this.lastloginSpecified;
		}

		// Token: 0x06004FAD RID: 20397 RVA: 0x000978A8 File Offset: 0x00095AA8
		private void Resetlastlogin()
		{
			this.lastloginSpecified = false;
		}

		// Token: 0x17001898 RID: 6296
		// (get) Token: 0x06004FAE RID: 20398 RVA: 0x000978B4 File Offset: 0x00095AB4
		// (set) Token: 0x06004FAF RID: 20399 RVA: 0x000978D5 File Offset: 0x00095AD5
		[ProtoMember(7, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17001899 RID: 6297
		// (get) Token: 0x06004FB0 RID: 20400 RVA: 0x000978E0 File Offset: 0x00095AE0
		// (set) Token: 0x06004FB1 RID: 20401 RVA: 0x000978FC File Offset: 0x00095AFC
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06004FB2 RID: 20402 RVA: 0x0009792C File Offset: 0x00095B2C
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06004FB3 RID: 20403 RVA: 0x00097944 File Offset: 0x00095B44
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700189A RID: 6298
		// (get) Token: 0x06004FB4 RID: 20404 RVA: 0x00097950 File Offset: 0x00095B50
		// (set) Token: 0x06004FB5 RID: 20405 RVA: 0x0009797C File Offset: 0x00095B7C
		[ProtoMember(8, IsRequired = false, Name = "roleaudioid", DataFormat = DataFormat.TwosComplement)]
		public uint roleaudioid
		{
			get
			{
				return this._roleaudioid ?? 0U;
			}
			set
			{
				this._roleaudioid = new uint?(value);
			}
		}

		// Token: 0x1700189B RID: 6299
		// (get) Token: 0x06004FB6 RID: 20406 RVA: 0x0009798C File Offset: 0x00095B8C
		// (set) Token: 0x06004FB7 RID: 20407 RVA: 0x000979AC File Offset: 0x00095BAC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleaudioidSpecified
		{
			get
			{
				return this._roleaudioid != null;
			}
			set
			{
				bool flag = value == (this._roleaudioid == null);
				if (flag)
				{
					this._roleaudioid = (value ? new uint?(this.roleaudioid) : null);
				}
			}
		}

		// Token: 0x06004FB8 RID: 20408 RVA: 0x000979F0 File Offset: 0x00095BF0
		private bool ShouldSerializeroleaudioid()
		{
			return this.roleaudioidSpecified;
		}

		// Token: 0x06004FB9 RID: 20409 RVA: 0x00097A08 File Offset: 0x00095C08
		private void Resetroleaudioid()
		{
			this.roleaudioidSpecified = false;
		}

		// Token: 0x1700189C RID: 6300
		// (get) Token: 0x06004FBA RID: 20410 RVA: 0x00097A14 File Offset: 0x00095C14
		// (set) Token: 0x06004FBB RID: 20411 RVA: 0x00097A40 File Offset: 0x00095C40
		[ProtoMember(9, IsRequired = false, Name = "audioid", DataFormat = DataFormat.TwosComplement)]
		public uint audioid
		{
			get
			{
				return this._audioid ?? 0U;
			}
			set
			{
				this._audioid = new uint?(value);
			}
		}

		// Token: 0x1700189D RID: 6301
		// (get) Token: 0x06004FBC RID: 20412 RVA: 0x00097A50 File Offset: 0x00095C50
		// (set) Token: 0x06004FBD RID: 20413 RVA: 0x00097A70 File Offset: 0x00095C70
		[XmlIgnore]
		[Browsable(false)]
		public bool audioidSpecified
		{
			get
			{
				return this._audioid != null;
			}
			set
			{
				bool flag = value == (this._audioid == null);
				if (flag)
				{
					this._audioid = (value ? new uint?(this.audioid) : null);
				}
			}
		}

		// Token: 0x06004FBE RID: 20414 RVA: 0x00097AB4 File Offset: 0x00095CB4
		private bool ShouldSerializeaudioid()
		{
			return this.audioidSpecified;
		}

		// Token: 0x06004FBF RID: 20415 RVA: 0x00097ACC File Offset: 0x00095CCC
		private void Resetaudioid()
		{
			this.audioidSpecified = false;
		}

		// Token: 0x1700189E RID: 6302
		// (get) Token: 0x06004FC0 RID: 20416 RVA: 0x00097AD8 File Offset: 0x00095CD8
		// (set) Token: 0x06004FC1 RID: 20417 RVA: 0x00097B04 File Offset: 0x00095D04
		[ProtoMember(10, IsRequired = false, Name = "degreelevel", DataFormat = DataFormat.TwosComplement)]
		public uint degreelevel
		{
			get
			{
				return this._degreelevel ?? 0U;
			}
			set
			{
				this._degreelevel = new uint?(value);
			}
		}

		// Token: 0x1700189F RID: 6303
		// (get) Token: 0x06004FC2 RID: 20418 RVA: 0x00097B14 File Offset: 0x00095D14
		// (set) Token: 0x06004FC3 RID: 20419 RVA: 0x00097B34 File Offset: 0x00095D34
		[XmlIgnore]
		[Browsable(false)]
		public bool degreelevelSpecified
		{
			get
			{
				return this._degreelevel != null;
			}
			set
			{
				bool flag = value == (this._degreelevel == null);
				if (flag)
				{
					this._degreelevel = (value ? new uint?(this.degreelevel) : null);
				}
			}
		}

		// Token: 0x06004FC4 RID: 20420 RVA: 0x00097B78 File Offset: 0x00095D78
		private bool ShouldSerializedegreelevel()
		{
			return this.degreelevelSpecified;
		}

		// Token: 0x06004FC5 RID: 20421 RVA: 0x00097B90 File Offset: 0x00095D90
		private void Resetdegreelevel()
		{
			this.degreelevelSpecified = false;
		}

		// Token: 0x170018A0 RID: 6304
		// (get) Token: 0x06004FC6 RID: 20422 RVA: 0x00097B9C File Offset: 0x00095D9C
		// (set) Token: 0x06004FC7 RID: 20423 RVA: 0x00097BC8 File Offset: 0x00095DC8
		[ProtoMember(11, IsRequired = false, Name = "degreeleft", DataFormat = DataFormat.TwosComplement)]
		public uint degreeleft
		{
			get
			{
				return this._degreeleft ?? 0U;
			}
			set
			{
				this._degreeleft = new uint?(value);
			}
		}

		// Token: 0x170018A1 RID: 6305
		// (get) Token: 0x06004FC8 RID: 20424 RVA: 0x00097BD8 File Offset: 0x00095DD8
		// (set) Token: 0x06004FC9 RID: 20425 RVA: 0x00097BF8 File Offset: 0x00095DF8
		[XmlIgnore]
		[Browsable(false)]
		public bool degreeleftSpecified
		{
			get
			{
				return this._degreeleft != null;
			}
			set
			{
				bool flag = value == (this._degreeleft == null);
				if (flag)
				{
					this._degreeleft = (value ? new uint?(this.degreeleft) : null);
				}
			}
		}

		// Token: 0x06004FCA RID: 20426 RVA: 0x00097C3C File Offset: 0x00095E3C
		private bool ShouldSerializedegreeleft()
		{
			return this.degreeleftSpecified;
		}

		// Token: 0x06004FCB RID: 20427 RVA: 0x00097C54 File Offset: 0x00095E54
		private void Resetdegreeleft()
		{
			this.degreeleftSpecified = false;
		}

		// Token: 0x170018A2 RID: 6306
		// (get) Token: 0x06004FCC RID: 20428 RVA: 0x00097C60 File Offset: 0x00095E60
		// (set) Token: 0x06004FCD RID: 20429 RVA: 0x00097C8C File Offset: 0x00095E8C
		[ProtoMember(12, IsRequired = false, Name = "daydegree", DataFormat = DataFormat.TwosComplement)]
		public uint daydegree
		{
			get
			{
				return this._daydegree ?? 0U;
			}
			set
			{
				this._daydegree = new uint?(value);
			}
		}

		// Token: 0x170018A3 RID: 6307
		// (get) Token: 0x06004FCE RID: 20430 RVA: 0x00097C9C File Offset: 0x00095E9C
		// (set) Token: 0x06004FCF RID: 20431 RVA: 0x00097CBC File Offset: 0x00095EBC
		[XmlIgnore]
		[Browsable(false)]
		public bool daydegreeSpecified
		{
			get
			{
				return this._daydegree != null;
			}
			set
			{
				bool flag = value == (this._daydegree == null);
				if (flag)
				{
					this._daydegree = (value ? new uint?(this.daydegree) : null);
				}
			}
		}

		// Token: 0x06004FD0 RID: 20432 RVA: 0x00097D00 File Offset: 0x00095F00
		private bool ShouldSerializedaydegree()
		{
			return this.daydegreeSpecified;
		}

		// Token: 0x06004FD1 RID: 20433 RVA: 0x00097D18 File Offset: 0x00095F18
		private void Resetdaydegree()
		{
			this.daydegreeSpecified = false;
		}

		// Token: 0x170018A4 RID: 6308
		// (get) Token: 0x06004FD2 RID: 20434 RVA: 0x00097D24 File Offset: 0x00095F24
		// (set) Token: 0x06004FD3 RID: 20435 RVA: 0x00097D50 File Offset: 0x00095F50
		[ProtoMember(13, IsRequired = false, Name = "receivegiftstate", DataFormat = DataFormat.TwosComplement)]
		public uint receivegiftstate
		{
			get
			{
				return this._receivegiftstate ?? 0U;
			}
			set
			{
				this._receivegiftstate = new uint?(value);
			}
		}

		// Token: 0x170018A5 RID: 6309
		// (get) Token: 0x06004FD4 RID: 20436 RVA: 0x00097D60 File Offset: 0x00095F60
		// (set) Token: 0x06004FD5 RID: 20437 RVA: 0x00097D80 File Offset: 0x00095F80
		[XmlIgnore]
		[Browsable(false)]
		public bool receivegiftstateSpecified
		{
			get
			{
				return this._receivegiftstate != null;
			}
			set
			{
				bool flag = value == (this._receivegiftstate == null);
				if (flag)
				{
					this._receivegiftstate = (value ? new uint?(this.receivegiftstate) : null);
				}
			}
		}

		// Token: 0x06004FD6 RID: 20438 RVA: 0x00097DC4 File Offset: 0x00095FC4
		private bool ShouldSerializereceivegiftstate()
		{
			return this.receivegiftstateSpecified;
		}

		// Token: 0x06004FD7 RID: 20439 RVA: 0x00097DDC File Offset: 0x00095FDC
		private void Resetreceivegiftstate()
		{
			this.receivegiftstateSpecified = false;
		}

		// Token: 0x170018A6 RID: 6310
		// (get) Token: 0x06004FD8 RID: 20440 RVA: 0x00097DE8 File Offset: 0x00095FE8
		// (set) Token: 0x06004FD9 RID: 20441 RVA: 0x00097E14 File Offset: 0x00096014
		[ProtoMember(14, IsRequired = false, Name = "sendgiftstate", DataFormat = DataFormat.TwosComplement)]
		public uint sendgiftstate
		{
			get
			{
				return this._sendgiftstate ?? 0U;
			}
			set
			{
				this._sendgiftstate = new uint?(value);
			}
		}

		// Token: 0x170018A7 RID: 6311
		// (get) Token: 0x06004FDA RID: 20442 RVA: 0x00097E24 File Offset: 0x00096024
		// (set) Token: 0x06004FDB RID: 20443 RVA: 0x00097E44 File Offset: 0x00096044
		[XmlIgnore]
		[Browsable(false)]
		public bool sendgiftstateSpecified
		{
			get
			{
				return this._sendgiftstate != null;
			}
			set
			{
				bool flag = value == (this._sendgiftstate == null);
				if (flag)
				{
					this._sendgiftstate = (value ? new uint?(this.sendgiftstate) : null);
				}
			}
		}

		// Token: 0x06004FDC RID: 20444 RVA: 0x00097E88 File Offset: 0x00096088
		private bool ShouldSerializesendgiftstate()
		{
			return this.sendgiftstateSpecified;
		}

		// Token: 0x06004FDD RID: 20445 RVA: 0x00097EA0 File Offset: 0x000960A0
		private void Resetsendgiftstate()
		{
			this.sendgiftstateSpecified = false;
		}

		// Token: 0x170018A8 RID: 6312
		// (get) Token: 0x06004FDE RID: 20446 RVA: 0x00097EAC File Offset: 0x000960AC
		// (set) Token: 0x06004FDF RID: 20447 RVA: 0x00097ED8 File Offset: 0x000960D8
		[ProtoMember(15, IsRequired = false, Name = "alldegree", DataFormat = DataFormat.TwosComplement)]
		public uint alldegree
		{
			get
			{
				return this._alldegree ?? 0U;
			}
			set
			{
				this._alldegree = new uint?(value);
			}
		}

		// Token: 0x170018A9 RID: 6313
		// (get) Token: 0x06004FE0 RID: 20448 RVA: 0x00097EE8 File Offset: 0x000960E8
		// (set) Token: 0x06004FE1 RID: 20449 RVA: 0x00097F08 File Offset: 0x00096108
		[XmlIgnore]
		[Browsable(false)]
		public bool alldegreeSpecified
		{
			get
			{
				return this._alldegree != null;
			}
			set
			{
				bool flag = value == (this._alldegree == null);
				if (flag)
				{
					this._alldegree = (value ? new uint?(this.alldegree) : null);
				}
			}
		}

		// Token: 0x06004FE2 RID: 20450 RVA: 0x00097F4C File Offset: 0x0009614C
		private bool ShouldSerializealldegree()
		{
			return this.alldegreeSpecified;
		}

		// Token: 0x06004FE3 RID: 20451 RVA: 0x00097F64 File Offset: 0x00096164
		private void Resetalldegree()
		{
			this.alldegreeSpecified = false;
		}

		// Token: 0x170018AA RID: 6314
		// (get) Token: 0x06004FE4 RID: 20452 RVA: 0x00097F70 File Offset: 0x00096170
		// (set) Token: 0x06004FE5 RID: 20453 RVA: 0x00097F9C File Offset: 0x0009619C
		[ProtoMember(16, IsRequired = false, Name = "receiveall", DataFormat = DataFormat.TwosComplement)]
		public uint receiveall
		{
			get
			{
				return this._receiveall ?? 0U;
			}
			set
			{
				this._receiveall = new uint?(value);
			}
		}

		// Token: 0x170018AB RID: 6315
		// (get) Token: 0x06004FE6 RID: 20454 RVA: 0x00097FAC File Offset: 0x000961AC
		// (set) Token: 0x06004FE7 RID: 20455 RVA: 0x00097FCC File Offset: 0x000961CC
		[XmlIgnore]
		[Browsable(false)]
		public bool receiveallSpecified
		{
			get
			{
				return this._receiveall != null;
			}
			set
			{
				bool flag = value == (this._receiveall == null);
				if (flag)
				{
					this._receiveall = (value ? new uint?(this.receiveall) : null);
				}
			}
		}

		// Token: 0x06004FE8 RID: 20456 RVA: 0x00098010 File Offset: 0x00096210
		private bool ShouldSerializereceiveall()
		{
			return this.receiveallSpecified;
		}

		// Token: 0x06004FE9 RID: 20457 RVA: 0x00098028 File Offset: 0x00096228
		private void Resetreceiveall()
		{
			this.receiveallSpecified = false;
		}

		// Token: 0x170018AC RID: 6316
		// (get) Token: 0x06004FEA RID: 20458 RVA: 0x00098034 File Offset: 0x00096234
		// (set) Token: 0x06004FEB RID: 20459 RVA: 0x00098055 File Offset: 0x00096255
		[ProtoMember(17, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x170018AD RID: 6317
		// (get) Token: 0x06004FEC RID: 20460 RVA: 0x00098060 File Offset: 0x00096260
		// (set) Token: 0x06004FED RID: 20461 RVA: 0x0009807C File Offset: 0x0009627C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x06004FEE RID: 20462 RVA: 0x000980AC File Offset: 0x000962AC
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06004FEF RID: 20463 RVA: 0x000980C4 File Offset: 0x000962C4
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x170018AE RID: 6318
		// (get) Token: 0x06004FF0 RID: 20464 RVA: 0x000980D0 File Offset: 0x000962D0
		// (set) Token: 0x06004FF1 RID: 20465 RVA: 0x000980FC File Offset: 0x000962FC
		[ProtoMember(18, IsRequired = false, Name = "receivetime", DataFormat = DataFormat.TwosComplement)]
		public uint receivetime
		{
			get
			{
				return this._receivetime ?? 0U;
			}
			set
			{
				this._receivetime = new uint?(value);
			}
		}

		// Token: 0x170018AF RID: 6319
		// (get) Token: 0x06004FF2 RID: 20466 RVA: 0x0009810C File Offset: 0x0009630C
		// (set) Token: 0x06004FF3 RID: 20467 RVA: 0x0009812C File Offset: 0x0009632C
		[XmlIgnore]
		[Browsable(false)]
		public bool receivetimeSpecified
		{
			get
			{
				return this._receivetime != null;
			}
			set
			{
				bool flag = value == (this._receivetime == null);
				if (flag)
				{
					this._receivetime = (value ? new uint?(this.receivetime) : null);
				}
			}
		}

		// Token: 0x06004FF4 RID: 20468 RVA: 0x00098170 File Offset: 0x00096370
		private bool ShouldSerializereceivetime()
		{
			return this.receivetimeSpecified;
		}

		// Token: 0x06004FF5 RID: 20469 RVA: 0x00098188 File Offset: 0x00096388
		private void Resetreceivetime()
		{
			this.receivetimeSpecified = false;
		}

		// Token: 0x170018B0 RID: 6320
		// (get) Token: 0x06004FF6 RID: 20470 RVA: 0x00098194 File Offset: 0x00096394
		// (set) Token: 0x06004FF7 RID: 20471 RVA: 0x000981C0 File Offset: 0x000963C0
		[ProtoMember(19, IsRequired = false, Name = "nickid", DataFormat = DataFormat.TwosComplement)]
		public uint nickid
		{
			get
			{
				return this._nickid ?? 0U;
			}
			set
			{
				this._nickid = new uint?(value);
			}
		}

		// Token: 0x170018B1 RID: 6321
		// (get) Token: 0x06004FF8 RID: 20472 RVA: 0x000981D0 File Offset: 0x000963D0
		// (set) Token: 0x06004FF9 RID: 20473 RVA: 0x000981F0 File Offset: 0x000963F0
		[XmlIgnore]
		[Browsable(false)]
		public bool nickidSpecified
		{
			get
			{
				return this._nickid != null;
			}
			set
			{
				bool flag = value == (this._nickid == null);
				if (flag)
				{
					this._nickid = (value ? new uint?(this.nickid) : null);
				}
			}
		}

		// Token: 0x06004FFA RID: 20474 RVA: 0x00098234 File Offset: 0x00096434
		private bool ShouldSerializenickid()
		{
			return this.nickidSpecified;
		}

		// Token: 0x06004FFB RID: 20475 RVA: 0x0009824C File Offset: 0x0009644C
		private void Resetnickid()
		{
			this.nickidSpecified = false;
		}

		// Token: 0x170018B2 RID: 6322
		// (get) Token: 0x06004FFC RID: 20476 RVA: 0x00098258 File Offset: 0x00096458
		// (set) Token: 0x06004FFD RID: 20477 RVA: 0x00098284 File Offset: 0x00096484
		[ProtoMember(20, IsRequired = false, Name = "titleid", DataFormat = DataFormat.TwosComplement)]
		public uint titleid
		{
			get
			{
				return this._titleid ?? 0U;
			}
			set
			{
				this._titleid = new uint?(value);
			}
		}

		// Token: 0x170018B3 RID: 6323
		// (get) Token: 0x06004FFE RID: 20478 RVA: 0x00098294 File Offset: 0x00096494
		// (set) Token: 0x06004FFF RID: 20479 RVA: 0x000982B4 File Offset: 0x000964B4
		[XmlIgnore]
		[Browsable(false)]
		public bool titleidSpecified
		{
			get
			{
				return this._titleid != null;
			}
			set
			{
				bool flag = value == (this._titleid == null);
				if (flag)
				{
					this._titleid = (value ? new uint?(this.titleid) : null);
				}
			}
		}

		// Token: 0x06005000 RID: 20480 RVA: 0x000982F8 File Offset: 0x000964F8
		private bool ShouldSerializetitleid()
		{
			return this.titleidSpecified;
		}

		// Token: 0x06005001 RID: 20481 RVA: 0x00098310 File Offset: 0x00096510
		private void Resettitleid()
		{
			this.titleidSpecified = false;
		}

		// Token: 0x170018B4 RID: 6324
		// (get) Token: 0x06005002 RID: 20482 RVA: 0x0009831C File Offset: 0x0009651C
		// (set) Token: 0x06005003 RID: 20483 RVA: 0x00098348 File Offset: 0x00096548
		[ProtoMember(21, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		// Token: 0x170018B5 RID: 6325
		// (get) Token: 0x06005004 RID: 20484 RVA: 0x00098358 File Offset: 0x00096558
		// (set) Token: 0x06005005 RID: 20485 RVA: 0x00098378 File Offset: 0x00096578
		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		// Token: 0x06005006 RID: 20486 RVA: 0x000983BC File Offset: 0x000965BC
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x06005007 RID: 20487 RVA: 0x000983D4 File Offset: 0x000965D4
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x170018B6 RID: 6326
		// (get) Token: 0x06005008 RID: 20488 RVA: 0x000983E0 File Offset: 0x000965E0
		// (set) Token: 0x06005009 RID: 20489 RVA: 0x0009840C File Offset: 0x0009660C
		[ProtoMember(22, IsRequired = false, Name = "mentortype", DataFormat = DataFormat.TwosComplement)]
		public EMentorRelationPosition mentortype
		{
			get
			{
				return this._mentortype ?? EMentorRelationPosition.EMentorPosMaster;
			}
			set
			{
				this._mentortype = new EMentorRelationPosition?(value);
			}
		}

		// Token: 0x170018B7 RID: 6327
		// (get) Token: 0x0600500A RID: 20490 RVA: 0x0009841C File Offset: 0x0009661C
		// (set) Token: 0x0600500B RID: 20491 RVA: 0x0009843C File Offset: 0x0009663C
		[XmlIgnore]
		[Browsable(false)]
		public bool mentortypeSpecified
		{
			get
			{
				return this._mentortype != null;
			}
			set
			{
				bool flag = value == (this._mentortype == null);
				if (flag)
				{
					this._mentortype = (value ? new EMentorRelationPosition?(this.mentortype) : null);
				}
			}
		}

		// Token: 0x0600500C RID: 20492 RVA: 0x00098480 File Offset: 0x00096680
		private bool ShouldSerializementortype()
		{
			return this.mentortypeSpecified;
		}

		// Token: 0x0600500D RID: 20493 RVA: 0x00098498 File Offset: 0x00096698
		private void Resetmentortype()
		{
			this.mentortypeSpecified = false;
		}

		// Token: 0x170018B8 RID: 6328
		// (get) Token: 0x0600500E RID: 20494 RVA: 0x000984A4 File Offset: 0x000966A4
		// (set) Token: 0x0600500F RID: 20495 RVA: 0x000984C5 File Offset: 0x000966C5
		[ProtoMember(23, IsRequired = false, Name = "openid", DataFormat = DataFormat.Default)]
		public string openid
		{
			get
			{
				return this._openid ?? "";
			}
			set
			{
				this._openid = value;
			}
		}

		// Token: 0x170018B9 RID: 6329
		// (get) Token: 0x06005010 RID: 20496 RVA: 0x000984D0 File Offset: 0x000966D0
		// (set) Token: 0x06005011 RID: 20497 RVA: 0x000984EC File Offset: 0x000966EC
		[XmlIgnore]
		[Browsable(false)]
		public bool openidSpecified
		{
			get
			{
				return this._openid != null;
			}
			set
			{
				bool flag = value == (this._openid == null);
				if (flag)
				{
					this._openid = (value ? this.openid : null);
				}
			}
		}

		// Token: 0x06005012 RID: 20498 RVA: 0x0009851C File Offset: 0x0009671C
		private bool ShouldSerializeopenid()
		{
			return this.openidSpecified;
		}

		// Token: 0x06005013 RID: 20499 RVA: 0x00098534 File Offset: 0x00096734
		private void Resetopenid()
		{
			this.openidSpecified = false;
		}

		// Token: 0x170018BA RID: 6330
		// (get) Token: 0x06005014 RID: 20500 RVA: 0x00098540 File Offset: 0x00096740
		// (set) Token: 0x06005015 RID: 20501 RVA: 0x00098561 File Offset: 0x00096761
		[ProtoMember(24, IsRequired = false, Name = "nickname", DataFormat = DataFormat.Default)]
		public string nickname
		{
			get
			{
				return this._nickname ?? "";
			}
			set
			{
				this._nickname = value;
			}
		}

		// Token: 0x170018BB RID: 6331
		// (get) Token: 0x06005016 RID: 20502 RVA: 0x0009856C File Offset: 0x0009676C
		// (set) Token: 0x06005017 RID: 20503 RVA: 0x00098588 File Offset: 0x00096788
		[XmlIgnore]
		[Browsable(false)]
		public bool nicknameSpecified
		{
			get
			{
				return this._nickname != null;
			}
			set
			{
				bool flag = value == (this._nickname == null);
				if (flag)
				{
					this._nickname = (value ? this.nickname : null);
				}
			}
		}

		// Token: 0x06005018 RID: 20504 RVA: 0x000985B8 File Offset: 0x000967B8
		private bool ShouldSerializenickname()
		{
			return this.nicknameSpecified;
		}

		// Token: 0x06005019 RID: 20505 RVA: 0x000985D0 File Offset: 0x000967D0
		private void Resetnickname()
		{
			this.nicknameSpecified = false;
		}

		// Token: 0x170018BC RID: 6332
		// (get) Token: 0x0600501A RID: 20506 RVA: 0x000985DC File Offset: 0x000967DC
		// (set) Token: 0x0600501B RID: 20507 RVA: 0x000985F4 File Offset: 0x000967F4
		[ProtoMember(25, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		// Token: 0x0600501C RID: 20508 RVA: 0x00098600 File Offset: 0x00096800
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400139E RID: 5022
		private ulong? _roleid;

		// Token: 0x0400139F RID: 5023
		private uint? _profession;

		// Token: 0x040013A0 RID: 5024
		private uint? _level;

		// Token: 0x040013A1 RID: 5025
		private uint? _powerpoint;

		// Token: 0x040013A2 RID: 5026
		private uint? _viplevel;

		// Token: 0x040013A3 RID: 5027
		private uint? _lastlogin;

		// Token: 0x040013A4 RID: 5028
		private string _name;

		// Token: 0x040013A5 RID: 5029
		private uint? _roleaudioid;

		// Token: 0x040013A6 RID: 5030
		private uint? _audioid;

		// Token: 0x040013A7 RID: 5031
		private uint? _degreelevel;

		// Token: 0x040013A8 RID: 5032
		private uint? _degreeleft;

		// Token: 0x040013A9 RID: 5033
		private uint? _daydegree;

		// Token: 0x040013AA RID: 5034
		private uint? _receivegiftstate;

		// Token: 0x040013AB RID: 5035
		private uint? _sendgiftstate;

		// Token: 0x040013AC RID: 5036
		private uint? _alldegree;

		// Token: 0x040013AD RID: 5037
		private uint? _receiveall;

		// Token: 0x040013AE RID: 5038
		private string _guildname;

		// Token: 0x040013AF RID: 5039
		private uint? _receivetime;

		// Token: 0x040013B0 RID: 5040
		private uint? _nickid;

		// Token: 0x040013B1 RID: 5041
		private uint? _titleid;

		// Token: 0x040013B2 RID: 5042
		private uint? _paymemberid;

		// Token: 0x040013B3 RID: 5043
		private EMentorRelationPosition? _mentortype;

		// Token: 0x040013B4 RID: 5044
		private string _openid;

		// Token: 0x040013B5 RID: 5045
		private string _nickname;

		// Token: 0x040013B6 RID: 5046
		private PayConsume _pre = null;

		// Token: 0x040013B7 RID: 5047
		private IExtension extensionObject;
	}
}
