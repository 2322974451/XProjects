using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001BE RID: 446
	[ProtoContract(Name = "JoinRoomReply")]
	[Serializable]
	public class JoinRoomReply : IExtensible
	{
		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x060019E8 RID: 6632 RVA: 0x0003359C File Offset: 0x0003179C
		// (set) Token: 0x060019E9 RID: 6633 RVA: 0x000335BD File Offset: 0x000317BD
		[ProtoMember(1, IsRequired = false, Name = "url1", DataFormat = DataFormat.Default)]
		public string url1
		{
			get
			{
				return this._url1 ?? "";
			}
			set
			{
				this._url1 = value;
			}
		}

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x060019EA RID: 6634 RVA: 0x000335C8 File Offset: 0x000317C8
		// (set) Token: 0x060019EB RID: 6635 RVA: 0x000335E4 File Offset: 0x000317E4
		[XmlIgnore]
		[Browsable(false)]
		public bool url1Specified
		{
			get
			{
				return this._url1 != null;
			}
			set
			{
				bool flag = value == (this._url1 == null);
				if (flag)
				{
					this._url1 = (value ? this.url1 : null);
				}
			}
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x00033614 File Offset: 0x00031814
		private bool ShouldSerializeurl1()
		{
			return this.url1Specified;
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x0003362C File Offset: 0x0003182C
		private void Reseturl1()
		{
			this.url1Specified = false;
		}

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x060019EE RID: 6638 RVA: 0x00033638 File Offset: 0x00031838
		// (set) Token: 0x060019EF RID: 6639 RVA: 0x00033659 File Offset: 0x00031859
		[ProtoMember(2, IsRequired = false, Name = "url2", DataFormat = DataFormat.Default)]
		public string url2
		{
			get
			{
				return this._url2 ?? "";
			}
			set
			{
				this._url2 = value;
			}
		}

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x060019F0 RID: 6640 RVA: 0x00033664 File Offset: 0x00031864
		// (set) Token: 0x060019F1 RID: 6641 RVA: 0x00033680 File Offset: 0x00031880
		[XmlIgnore]
		[Browsable(false)]
		public bool url2Specified
		{
			get
			{
				return this._url2 != null;
			}
			set
			{
				bool flag = value == (this._url2 == null);
				if (flag)
				{
					this._url2 = (value ? this.url2 : null);
				}
			}
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x000336B0 File Offset: 0x000318B0
		private bool ShouldSerializeurl2()
		{
			return this.url2Specified;
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x000336C8 File Offset: 0x000318C8
		private void Reseturl2()
		{
			this.url2Specified = false;
		}

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x060019F4 RID: 6644 RVA: 0x000336D4 File Offset: 0x000318D4
		// (set) Token: 0x060019F5 RID: 6645 RVA: 0x000336F5 File Offset: 0x000318F5
		[ProtoMember(3, IsRequired = false, Name = "url3", DataFormat = DataFormat.Default)]
		public string url3
		{
			get
			{
				return this._url3 ?? "";
			}
			set
			{
				this._url3 = value;
			}
		}

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x060019F6 RID: 6646 RVA: 0x00033700 File Offset: 0x00031900
		// (set) Token: 0x060019F7 RID: 6647 RVA: 0x0003371C File Offset: 0x0003191C
		[XmlIgnore]
		[Browsable(false)]
		public bool url3Specified
		{
			get
			{
				return this._url3 != null;
			}
			set
			{
				bool flag = value == (this._url3 == null);
				if (flag)
				{
					this._url3 = (value ? this.url3 : null);
				}
			}
		}

		// Token: 0x060019F8 RID: 6648 RVA: 0x0003374C File Offset: 0x0003194C
		private bool ShouldSerializeurl3()
		{
			return this.url3Specified;
		}

		// Token: 0x060019F9 RID: 6649 RVA: 0x00033764 File Offset: 0x00031964
		private void Reseturl3()
		{
			this.url3Specified = false;
		}

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x060019FA RID: 6650 RVA: 0x00033770 File Offset: 0x00031970
		// (set) Token: 0x060019FB RID: 6651 RVA: 0x0003379D File Offset: 0x0003199D
		[ProtoMember(4, IsRequired = false, Name = "roomID", DataFormat = DataFormat.TwosComplement)]
		public long roomID
		{
			get
			{
				return this._roomID ?? 0L;
			}
			set
			{
				this._roomID = new long?(value);
			}
		}

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x060019FC RID: 6652 RVA: 0x000337AC File Offset: 0x000319AC
		// (set) Token: 0x060019FD RID: 6653 RVA: 0x000337CC File Offset: 0x000319CC
		[XmlIgnore]
		[Browsable(false)]
		public bool roomIDSpecified
		{
			get
			{
				return this._roomID != null;
			}
			set
			{
				bool flag = value == (this._roomID == null);
				if (flag)
				{
					this._roomID = (value ? new long?(this.roomID) : null);
				}
			}
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x00033810 File Offset: 0x00031A10
		private bool ShouldSerializeroomID()
		{
			return this.roomIDSpecified;
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x00033828 File Offset: 0x00031A28
		private void ResetroomID()
		{
			this.roomIDSpecified = false;
		}

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x06001A00 RID: 6656 RVA: 0x00033834 File Offset: 0x00031A34
		// (set) Token: 0x06001A01 RID: 6657 RVA: 0x00033861 File Offset: 0x00031A61
		[ProtoMember(5, IsRequired = false, Name = "roomKey", DataFormat = DataFormat.TwosComplement)]
		public long roomKey
		{
			get
			{
				return this._roomKey ?? 0L;
			}
			set
			{
				this._roomKey = new long?(value);
			}
		}

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x06001A02 RID: 6658 RVA: 0x00033870 File Offset: 0x00031A70
		// (set) Token: 0x06001A03 RID: 6659 RVA: 0x00033890 File Offset: 0x00031A90
		[XmlIgnore]
		[Browsable(false)]
		public bool roomKeySpecified
		{
			get
			{
				return this._roomKey != null;
			}
			set
			{
				bool flag = value == (this._roomKey == null);
				if (flag)
				{
					this._roomKey = (value ? new long?(this.roomKey) : null);
				}
			}
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x000338D4 File Offset: 0x00031AD4
		private bool ShouldSerializeroomKey()
		{
			return this.roomKeySpecified;
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x000338EC File Offset: 0x00031AEC
		private void ResetroomKey()
		{
			this.roomKeySpecified = false;
		}

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x06001A06 RID: 6662 RVA: 0x000338F8 File Offset: 0x00031AF8
		// (set) Token: 0x06001A07 RID: 6663 RVA: 0x00033924 File Offset: 0x00031B24
		[ProtoMember(6, IsRequired = false, Name = "memberID", DataFormat = DataFormat.TwosComplement)]
		public int memberID
		{
			get
			{
				return this._memberID ?? 0;
			}
			set
			{
				this._memberID = new int?(value);
			}
		}

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x06001A08 RID: 6664 RVA: 0x00033934 File Offset: 0x00031B34
		// (set) Token: 0x06001A09 RID: 6665 RVA: 0x00033954 File Offset: 0x00031B54
		[XmlIgnore]
		[Browsable(false)]
		public bool memberIDSpecified
		{
			get
			{
				return this._memberID != null;
			}
			set
			{
				bool flag = value == (this._memberID == null);
				if (flag)
				{
					this._memberID = (value ? new int?(this.memberID) : null);
				}
			}
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x00033998 File Offset: 0x00031B98
		private bool ShouldSerializememberID()
		{
			return this.memberIDSpecified;
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x000339B0 File Offset: 0x00031BB0
		private void ResetmemberID()
		{
			this.memberIDSpecified = false;
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x000339BC File Offset: 0x00031BBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000673 RID: 1651
		private string _url1;

		// Token: 0x04000674 RID: 1652
		private string _url2;

		// Token: 0x04000675 RID: 1653
		private string _url3;

		// Token: 0x04000676 RID: 1654
		private long? _roomID;

		// Token: 0x04000677 RID: 1655
		private long? _roomKey;

		// Token: 0x04000678 RID: 1656
		private int? _memberID;

		// Token: 0x04000679 RID: 1657
		private IExtension extensionObject;
	}
}
