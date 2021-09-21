using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D1 RID: 1745
	[ProtoContract(Name = "JoinLargeRoomReply")]
	[Serializable]
	public class JoinLargeRoomReply : IExtensible
	{
		// Token: 0x170024A5 RID: 9381
		// (get) Token: 0x060073C2 RID: 29634 RVA: 0x000DD7C4 File Offset: 0x000DB9C4
		// (set) Token: 0x060073C3 RID: 29635 RVA: 0x000DD7E5 File Offset: 0x000DB9E5
		[ProtoMember(1, IsRequired = false, Name = "url", DataFormat = DataFormat.Default)]
		public string url
		{
			get
			{
				return this._url ?? "";
			}
			set
			{
				this._url = value;
			}
		}

		// Token: 0x170024A6 RID: 9382
		// (get) Token: 0x060073C4 RID: 29636 RVA: 0x000DD7F0 File Offset: 0x000DB9F0
		// (set) Token: 0x060073C5 RID: 29637 RVA: 0x000DD80C File Offset: 0x000DBA0C
		[XmlIgnore]
		[Browsable(false)]
		public bool urlSpecified
		{
			get
			{
				return this._url != null;
			}
			set
			{
				bool flag = value == (this._url == null);
				if (flag)
				{
					this._url = (value ? this.url : null);
				}
			}
		}

		// Token: 0x060073C6 RID: 29638 RVA: 0x000DD83C File Offset: 0x000DBA3C
		private bool ShouldSerializeurl()
		{
			return this.urlSpecified;
		}

		// Token: 0x060073C7 RID: 29639 RVA: 0x000DD854 File Offset: 0x000DBA54
		private void Reseturl()
		{
			this.urlSpecified = false;
		}

		// Token: 0x170024A7 RID: 9383
		// (get) Token: 0x060073C8 RID: 29640 RVA: 0x000DD860 File Offset: 0x000DBA60
		// (set) Token: 0x060073C9 RID: 29641 RVA: 0x000DD88C File Offset: 0x000DBA8C
		[ProtoMember(2, IsRequired = false, Name = "key", DataFormat = DataFormat.TwosComplement)]
		public uint key
		{
			get
			{
				return this._key ?? 0U;
			}
			set
			{
				this._key = new uint?(value);
			}
		}

		// Token: 0x170024A8 RID: 9384
		// (get) Token: 0x060073CA RID: 29642 RVA: 0x000DD89C File Offset: 0x000DBA9C
		// (set) Token: 0x060073CB RID: 29643 RVA: 0x000DD8BC File Offset: 0x000DBABC
		[XmlIgnore]
		[Browsable(false)]
		public bool keySpecified
		{
			get
			{
				return this._key != null;
			}
			set
			{
				bool flag = value == (this._key == null);
				if (flag)
				{
					this._key = (value ? new uint?(this.key) : null);
				}
			}
		}

		// Token: 0x060073CC RID: 29644 RVA: 0x000DD900 File Offset: 0x000DBB00
		private bool ShouldSerializekey()
		{
			return this.keySpecified;
		}

		// Token: 0x060073CD RID: 29645 RVA: 0x000DD918 File Offset: 0x000DBB18
		private void Resetkey()
		{
			this.keySpecified = false;
		}

		// Token: 0x170024A9 RID: 9385
		// (get) Token: 0x060073CE RID: 29646 RVA: 0x000DD924 File Offset: 0x000DBB24
		// (set) Token: 0x060073CF RID: 29647 RVA: 0x000DD950 File Offset: 0x000DBB50
		[ProtoMember(3, IsRequired = false, Name = "bussniessid", DataFormat = DataFormat.TwosComplement)]
		public uint bussniessid
		{
			get
			{
				return this._bussniessid ?? 0U;
			}
			set
			{
				this._bussniessid = new uint?(value);
			}
		}

		// Token: 0x170024AA RID: 9386
		// (get) Token: 0x060073D0 RID: 29648 RVA: 0x000DD960 File Offset: 0x000DBB60
		// (set) Token: 0x060073D1 RID: 29649 RVA: 0x000DD980 File Offset: 0x000DBB80
		[XmlIgnore]
		[Browsable(false)]
		public bool bussniessidSpecified
		{
			get
			{
				return this._bussniessid != null;
			}
			set
			{
				bool flag = value == (this._bussniessid == null);
				if (flag)
				{
					this._bussniessid = (value ? new uint?(this.bussniessid) : null);
				}
			}
		}

		// Token: 0x060073D2 RID: 29650 RVA: 0x000DD9C4 File Offset: 0x000DBBC4
		private bool ShouldSerializebussniessid()
		{
			return this.bussniessidSpecified;
		}

		// Token: 0x060073D3 RID: 29651 RVA: 0x000DD9DC File Offset: 0x000DBBDC
		private void Resetbussniessid()
		{
			this.bussniessidSpecified = false;
		}

		// Token: 0x170024AB RID: 9387
		// (get) Token: 0x060073D4 RID: 29652 RVA: 0x000DD9E8 File Offset: 0x000DBBE8
		// (set) Token: 0x060073D5 RID: 29653 RVA: 0x000DDA15 File Offset: 0x000DBC15
		[ProtoMember(4, IsRequired = false, Name = "roomid", DataFormat = DataFormat.TwosComplement)]
		public ulong roomid
		{
			get
			{
				return this._roomid ?? 0UL;
			}
			set
			{
				this._roomid = new ulong?(value);
			}
		}

		// Token: 0x170024AC RID: 9388
		// (get) Token: 0x060073D6 RID: 29654 RVA: 0x000DDA24 File Offset: 0x000DBC24
		// (set) Token: 0x060073D7 RID: 29655 RVA: 0x000DDA44 File Offset: 0x000DBC44
		[XmlIgnore]
		[Browsable(false)]
		public bool roomidSpecified
		{
			get
			{
				return this._roomid != null;
			}
			set
			{
				bool flag = value == (this._roomid == null);
				if (flag)
				{
					this._roomid = (value ? new ulong?(this.roomid) : null);
				}
			}
		}

		// Token: 0x060073D8 RID: 29656 RVA: 0x000DDA88 File Offset: 0x000DBC88
		private bool ShouldSerializeroomid()
		{
			return this.roomidSpecified;
		}

		// Token: 0x060073D9 RID: 29657 RVA: 0x000DDAA0 File Offset: 0x000DBCA0
		private void Resetroomid()
		{
			this.roomidSpecified = false;
		}

		// Token: 0x170024AD RID: 9389
		// (get) Token: 0x060073DA RID: 29658 RVA: 0x000DDAAC File Offset: 0x000DBCAC
		// (set) Token: 0x060073DB RID: 29659 RVA: 0x000DDAD9 File Offset: 0x000DBCD9
		[ProtoMember(5, IsRequired = false, Name = "roomkey", DataFormat = DataFormat.TwosComplement)]
		public ulong roomkey
		{
			get
			{
				return this._roomkey ?? 0UL;
			}
			set
			{
				this._roomkey = new ulong?(value);
			}
		}

		// Token: 0x170024AE RID: 9390
		// (get) Token: 0x060073DC RID: 29660 RVA: 0x000DDAE8 File Offset: 0x000DBCE8
		// (set) Token: 0x060073DD RID: 29661 RVA: 0x000DDB08 File Offset: 0x000DBD08
		[XmlIgnore]
		[Browsable(false)]
		public bool roomkeySpecified
		{
			get
			{
				return this._roomkey != null;
			}
			set
			{
				bool flag = value == (this._roomkey == null);
				if (flag)
				{
					this._roomkey = (value ? new ulong?(this.roomkey) : null);
				}
			}
		}

		// Token: 0x060073DE RID: 29662 RVA: 0x000DDB4C File Offset: 0x000DBD4C
		private bool ShouldSerializeroomkey()
		{
			return this.roomkeySpecified;
		}

		// Token: 0x060073DF RID: 29663 RVA: 0x000DDB64 File Offset: 0x000DBD64
		private void Resetroomkey()
		{
			this.roomkeySpecified = false;
		}

		// Token: 0x170024AF RID: 9391
		// (get) Token: 0x060073E0 RID: 29664 RVA: 0x000DDB70 File Offset: 0x000DBD70
		// (set) Token: 0x060073E1 RID: 29665 RVA: 0x000DDB9C File Offset: 0x000DBD9C
		[ProtoMember(6, IsRequired = false, Name = "memberid", DataFormat = DataFormat.TwosComplement)]
		public uint memberid
		{
			get
			{
				return this._memberid ?? 0U;
			}
			set
			{
				this._memberid = new uint?(value);
			}
		}

		// Token: 0x170024B0 RID: 9392
		// (get) Token: 0x060073E2 RID: 29666 RVA: 0x000DDBAC File Offset: 0x000DBDAC
		// (set) Token: 0x060073E3 RID: 29667 RVA: 0x000DDBCC File Offset: 0x000DBDCC
		[XmlIgnore]
		[Browsable(false)]
		public bool memberidSpecified
		{
			get
			{
				return this._memberid != null;
			}
			set
			{
				bool flag = value == (this._memberid == null);
				if (flag)
				{
					this._memberid = (value ? new uint?(this.memberid) : null);
				}
			}
		}

		// Token: 0x060073E4 RID: 29668 RVA: 0x000DDC10 File Offset: 0x000DBE10
		private bool ShouldSerializememberid()
		{
			return this.memberidSpecified;
		}

		// Token: 0x060073E5 RID: 29669 RVA: 0x000DDC28 File Offset: 0x000DBE28
		private void Resetmemberid()
		{
			this.memberidSpecified = false;
		}

		// Token: 0x170024B1 RID: 9393
		// (get) Token: 0x060073E6 RID: 29670 RVA: 0x000DDC34 File Offset: 0x000DBE34
		// (set) Token: 0x060073E7 RID: 29671 RVA: 0x000DDC61 File Offset: 0x000DBE61
		[ProtoMember(7, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170024B2 RID: 9394
		// (get) Token: 0x060073E8 RID: 29672 RVA: 0x000DDC70 File Offset: 0x000DBE70
		// (set) Token: 0x060073E9 RID: 29673 RVA: 0x000DDC90 File Offset: 0x000DBE90
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

		// Token: 0x060073EA RID: 29674 RVA: 0x000DDCD4 File Offset: 0x000DBED4
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060073EB RID: 29675 RVA: 0x000DDCEC File Offset: 0x000DBEEC
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170024B3 RID: 9395
		// (get) Token: 0x060073EC RID: 29676 RVA: 0x000DDCF8 File Offset: 0x000DBEF8
		// (set) Token: 0x060073ED RID: 29677 RVA: 0x000DDD24 File Offset: 0x000DBF24
		[ProtoMember(8, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		// Token: 0x170024B4 RID: 9396
		// (get) Token: 0x060073EE RID: 29678 RVA: 0x000DDD34 File Offset: 0x000DBF34
		// (set) Token: 0x060073EF RID: 29679 RVA: 0x000DDD54 File Offset: 0x000DBF54
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		// Token: 0x060073F0 RID: 29680 RVA: 0x000DDD98 File Offset: 0x000DBF98
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x060073F1 RID: 29681 RVA: 0x000DDDB0 File Offset: 0x000DBFB0
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x060073F2 RID: 29682 RVA: 0x000DDDBC File Offset: 0x000DBFBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B84 RID: 7044
		private string _url;

		// Token: 0x04001B85 RID: 7045
		private uint? _key;

		// Token: 0x04001B86 RID: 7046
		private uint? _bussniessid;

		// Token: 0x04001B87 RID: 7047
		private ulong? _roomid;

		// Token: 0x04001B88 RID: 7048
		private ulong? _roomkey;

		// Token: 0x04001B89 RID: 7049
		private uint? _memberid;

		// Token: 0x04001B8A RID: 7050
		private ulong? _roleid;

		// Token: 0x04001B8B RID: 7051
		private uint? _param;

		// Token: 0x04001B8C RID: 7052
		private IExtension extensionObject;
	}
}
