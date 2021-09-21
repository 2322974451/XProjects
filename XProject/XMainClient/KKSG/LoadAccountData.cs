using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000009 RID: 9
	[ProtoContract(Name = "LoadAccountData")]
	[Serializable]
	public class LoadAccountData : IExtensible
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00003124 File Offset: 0x00001324
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00003145 File Offset: 0x00001345
		[ProtoMember(1, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00003150 File Offset: 0x00001350
		// (set) Token: 0x06000032 RID: 50 RVA: 0x0000316C File Offset: 0x0000136C
		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000319C File Offset: 0x0000139C
		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000031B4 File Offset: 0x000013B4
		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000031C0 File Offset: 0x000013C0
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000031DD File Offset: 0x000013DD
		[ProtoMember(2, IsRequired = false, Name = "role1", DataFormat = DataFormat.Default)]
		public byte[] role1
		{
			get
			{
				return this._role1 ?? null;
			}
			set
			{
				this._role1 = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000031E8 File Offset: 0x000013E8
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00003204 File Offset: 0x00001404
		[XmlIgnore]
		[Browsable(false)]
		public bool role1Specified
		{
			get
			{
				return this._role1 != null;
			}
			set
			{
				bool flag = value == (this._role1 == null);
				if (flag)
				{
					this._role1 = (value ? this.role1 : null);
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003234 File Offset: 0x00001434
		private bool ShouldSerializerole1()
		{
			return this.role1Specified;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000324C File Offset: 0x0000144C
		private void Resetrole1()
		{
			this.role1Specified = false;
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00003258 File Offset: 0x00001458
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00003275 File Offset: 0x00001475
		[ProtoMember(3, IsRequired = false, Name = "role2", DataFormat = DataFormat.Default)]
		public byte[] role2
		{
			get
			{
				return this._role2 ?? null;
			}
			set
			{
				this._role2 = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00003280 File Offset: 0x00001480
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000329C File Offset: 0x0000149C
		[XmlIgnore]
		[Browsable(false)]
		public bool role2Specified
		{
			get
			{
				return this._role2 != null;
			}
			set
			{
				bool flag = value == (this._role2 == null);
				if (flag)
				{
					this._role2 = (value ? this.role2 : null);
				}
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000032CC File Offset: 0x000014CC
		private bool ShouldSerializerole2()
		{
			return this.role2Specified;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000032E4 File Offset: 0x000014E4
		private void Resetrole2()
		{
			this.role2Specified = false;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000032F0 File Offset: 0x000014F0
		// (set) Token: 0x06000042 RID: 66 RVA: 0x0000330D File Offset: 0x0000150D
		[ProtoMember(4, IsRequired = false, Name = "role3", DataFormat = DataFormat.Default)]
		public byte[] role3
		{
			get
			{
				return this._role3 ?? null;
			}
			set
			{
				this._role3 = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00003318 File Offset: 0x00001518
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00003334 File Offset: 0x00001534
		[XmlIgnore]
		[Browsable(false)]
		public bool role3Specified
		{
			get
			{
				return this._role3 != null;
			}
			set
			{
				bool flag = value == (this._role3 == null);
				if (flag)
				{
					this._role3 = (value ? this.role3 : null);
				}
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003364 File Offset: 0x00001564
		private bool ShouldSerializerole3()
		{
			return this.role3Specified;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000337C File Offset: 0x0000157C
		private void Resetrole3()
		{
			this.role3Specified = false;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00003388 File Offset: 0x00001588
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000033A5 File Offset: 0x000015A5
		[ProtoMember(5, IsRequired = false, Name = "role4", DataFormat = DataFormat.Default)]
		public byte[] role4
		{
			get
			{
				return this._role4 ?? null;
			}
			set
			{
				this._role4 = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000033B0 File Offset: 0x000015B0
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000033CC File Offset: 0x000015CC
		[XmlIgnore]
		[Browsable(false)]
		public bool role4Specified
		{
			get
			{
				return this._role4 != null;
			}
			set
			{
				bool flag = value == (this._role4 == null);
				if (flag)
				{
					this._role4 = (value ? this.role4 : null);
				}
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000033FC File Offset: 0x000015FC
		private bool ShouldSerializerole4()
		{
			return this.role4Specified;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003414 File Offset: 0x00001614
		private void Resetrole4()
		{
			this.role4Specified = false;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00003420 File Offset: 0x00001620
		// (set) Token: 0x0600004E RID: 78 RVA: 0x0000344C File Offset: 0x0000164C
		[ProtoMember(6, IsRequired = false, Name = "selectSlot", DataFormat = DataFormat.TwosComplement)]
		public uint selectSlot
		{
			get
			{
				return this._selectSlot ?? 0U;
			}
			set
			{
				this._selectSlot = new uint?(value);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004F RID: 79 RVA: 0x0000345C File Offset: 0x0000165C
		// (set) Token: 0x06000050 RID: 80 RVA: 0x0000347C File Offset: 0x0000167C
		[XmlIgnore]
		[Browsable(false)]
		public bool selectSlotSpecified
		{
			get
			{
				return this._selectSlot != null;
			}
			set
			{
				bool flag = value == (this._selectSlot == null);
				if (flag)
				{
					this._selectSlot = (value ? new uint?(this.selectSlot) : null);
				}
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000034C0 File Offset: 0x000016C0
		private bool ShouldSerializeselectSlot()
		{
			return this.selectSlotSpecified;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000034D8 File Offset: 0x000016D8
		private void ResetselectSlot()
		{
			this.selectSlotSpecified = false;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000034E4 File Offset: 0x000016E4
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00003501 File Offset: 0x00001701
		[ProtoMember(7, IsRequired = false, Name = "role5", DataFormat = DataFormat.Default)]
		public byte[] role5
		{
			get
			{
				return this._role5 ?? null;
			}
			set
			{
				this._role5 = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000055 RID: 85 RVA: 0x0000350C File Offset: 0x0000170C
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00003528 File Offset: 0x00001728
		[XmlIgnore]
		[Browsable(false)]
		public bool role5Specified
		{
			get
			{
				return this._role5 != null;
			}
			set
			{
				bool flag = value == (this._role5 == null);
				if (flag)
				{
					this._role5 = (value ? this.role5 : null);
				}
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003558 File Offset: 0x00001758
		private bool ShouldSerializerole5()
		{
			return this.role5Specified;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003570 File Offset: 0x00001770
		private void Resetrole5()
		{
			this.role5Specified = false;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000357C File Offset: 0x0000177C
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00003599 File Offset: 0x00001799
		[ProtoMember(8, IsRequired = false, Name = "role6", DataFormat = DataFormat.Default)]
		public byte[] role6
		{
			get
			{
				return this._role6 ?? null;
			}
			set
			{
				this._role6 = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000035A4 File Offset: 0x000017A4
		// (set) Token: 0x0600005C RID: 92 RVA: 0x000035C0 File Offset: 0x000017C0
		[XmlIgnore]
		[Browsable(false)]
		public bool role6Specified
		{
			get
			{
				return this._role6 != null;
			}
			set
			{
				bool flag = value == (this._role6 == null);
				if (flag)
				{
					this._role6 = (value ? this.role6 : null);
				}
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000035F0 File Offset: 0x000017F0
		private bool ShouldSerializerole6()
		{
			return this.role6Specified;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003608 File Offset: 0x00001808
		private void Resetrole6()
		{
			this.role6Specified = false;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003614 File Offset: 0x00001814
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00003631 File Offset: 0x00001831
		[ProtoMember(9, IsRequired = false, Name = "role7", DataFormat = DataFormat.Default)]
		public byte[] role7
		{
			get
			{
				return this._role7 ?? null;
			}
			set
			{
				this._role7 = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000061 RID: 97 RVA: 0x0000363C File Offset: 0x0000183C
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00003658 File Offset: 0x00001858
		[XmlIgnore]
		[Browsable(false)]
		public bool role7Specified
		{
			get
			{
				return this._role7 != null;
			}
			set
			{
				bool flag = value == (this._role7 == null);
				if (flag)
				{
					this._role7 = (value ? this.role7 : null);
				}
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003688 File Offset: 0x00001888
		private bool ShouldSerializerole7()
		{
			return this.role7Specified;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000036A0 File Offset: 0x000018A0
		private void Resetrole7()
		{
			this.role7Specified = false;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000036AC File Offset: 0x000018AC
		// (set) Token: 0x06000066 RID: 102 RVA: 0x000036C9 File Offset: 0x000018C9
		[ProtoMember(10, IsRequired = false, Name = "role8", DataFormat = DataFormat.Default)]
		public byte[] role8
		{
			get
			{
				return this._role8 ?? null;
			}
			set
			{
				this._role8 = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000036D4 File Offset: 0x000018D4
		// (set) Token: 0x06000068 RID: 104 RVA: 0x000036F0 File Offset: 0x000018F0
		[XmlIgnore]
		[Browsable(false)]
		public bool role8Specified
		{
			get
			{
				return this._role8 != null;
			}
			set
			{
				bool flag = value == (this._role8 == null);
				if (flag)
				{
					this._role8 = (value ? this.role8 : null);
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003720 File Offset: 0x00001920
		private bool ShouldSerializerole8()
		{
			return this.role8Specified;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003738 File Offset: 0x00001938
		private void Resetrole8()
		{
			this.role8Specified = false;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00003744 File Offset: 0x00001944
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00003761 File Offset: 0x00001961
		[ProtoMember(11, IsRequired = false, Name = "role9", DataFormat = DataFormat.Default)]
		public byte[] role9
		{
			get
			{
				return this._role9 ?? null;
			}
			set
			{
				this._role9 = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000376C File Offset: 0x0000196C
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00003788 File Offset: 0x00001988
		[XmlIgnore]
		[Browsable(false)]
		public bool role9Specified
		{
			get
			{
				return this._role9 != null;
			}
			set
			{
				bool flag = value == (this._role9 == null);
				if (flag)
				{
					this._role9 = (value ? this.role9 : null);
				}
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000037B8 File Offset: 0x000019B8
		private bool ShouldSerializerole9()
		{
			return this.role9Specified;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000037D0 File Offset: 0x000019D0
		private void Resetrole9()
		{
			this.role9Specified = false;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000037DC File Offset: 0x000019DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000019 RID: 25
		private string _account;

		// Token: 0x0400001A RID: 26
		private byte[] _role1;

		// Token: 0x0400001B RID: 27
		private byte[] _role2;

		// Token: 0x0400001C RID: 28
		private byte[] _role3;

		// Token: 0x0400001D RID: 29
		private byte[] _role4;

		// Token: 0x0400001E RID: 30
		private uint? _selectSlot;

		// Token: 0x0400001F RID: 31
		private byte[] _role5;

		// Token: 0x04000020 RID: 32
		private byte[] _role6;

		// Token: 0x04000021 RID: 33
		private byte[] _role7;

		// Token: 0x04000022 RID: 34
		private byte[] _role8;

		// Token: 0x04000023 RID: 35
		private byte[] _role9;

		// Token: 0x04000024 RID: 36
		private IExtension extensionObject;
	}
}
