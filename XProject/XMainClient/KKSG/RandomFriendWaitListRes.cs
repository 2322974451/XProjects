using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200007D RID: 125
	[ProtoContract(Name = "RandomFriendWaitListRes")]
	[Serializable]
	public class RandomFriendWaitListRes : IExtensible
	{
		// Token: 0x1700029F RID: 671
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x00012174 File Offset: 0x00010374
		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x0001218C File Offset: 0x0001038C
		[ProtoMember(2, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public List<uint> profession
		{
			get
			{
				return this._profession;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x000121A4 File Offset: 0x000103A4
		[ProtoMember(3, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x000121BC File Offset: 0x000103BC
		[ProtoMember(4, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public List<uint> level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000823 RID: 2083 RVA: 0x000121D4 File Offset: 0x000103D4
		[ProtoMember(5, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public List<uint> powerpoint
		{
			get
			{
				return this._powerpoint;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x000121EC File Offset: 0x000103EC
		[ProtoMember(6, Name = "viplevel", DataFormat = DataFormat.TwosComplement)]
		public List<uint> viplevel
		{
			get
			{
				return this._viplevel;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x00012204 File Offset: 0x00010404
		// (set) Token: 0x06000826 RID: 2086 RVA: 0x00012230 File Offset: 0x00010430
		[ProtoMember(7, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x00012240 File Offset: 0x00010440
		// (set) Token: 0x06000828 RID: 2088 RVA: 0x00012260 File Offset: 0x00010460
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x000122A4 File Offset: 0x000104A4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x000122BC File Offset: 0x000104BC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x000122C8 File Offset: 0x000104C8
		[ProtoMember(8, Name = "lastlogin", DataFormat = DataFormat.TwosComplement)]
		public List<uint> lastlogin
		{
			get
			{
				return this._lastlogin;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x000122E0 File Offset: 0x000104E0
		[ProtoMember(9, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> guildid
		{
			get
			{
				return this._guildid;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x000122F8 File Offset: 0x000104F8
		[ProtoMember(10, Name = "guildname", DataFormat = DataFormat.Default)]
		public List<string> guildname
		{
			get
			{
				return this._guildname;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x00012310 File Offset: 0x00010510
		[ProtoMember(11, Name = "nickid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> nickid
		{
			get
			{
				return this._nickid;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x00012328 File Offset: 0x00010528
		[ProtoMember(12, Name = "titleid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> titleid
		{
			get
			{
				return this._titleid;
			}
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x00012340 File Offset: 0x00010540
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400020D RID: 525
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x0400020E RID: 526
		private readonly List<uint> _profession = new List<uint>();

		// Token: 0x0400020F RID: 527
		private readonly List<string> _name = new List<string>();

		// Token: 0x04000210 RID: 528
		private readonly List<uint> _level = new List<uint>();

		// Token: 0x04000211 RID: 529
		private readonly List<uint> _powerpoint = new List<uint>();

		// Token: 0x04000212 RID: 530
		private readonly List<uint> _viplevel = new List<uint>();

		// Token: 0x04000213 RID: 531
		private ErrorCode? _errorcode;

		// Token: 0x04000214 RID: 532
		private readonly List<uint> _lastlogin = new List<uint>();

		// Token: 0x04000215 RID: 533
		private readonly List<ulong> _guildid = new List<ulong>();

		// Token: 0x04000216 RID: 534
		private readonly List<string> _guildname = new List<string>();

		// Token: 0x04000217 RID: 535
		private readonly List<uint> _nickid = new List<uint>();

		// Token: 0x04000218 RID: 536
		private readonly List<uint> _titleid = new List<uint>();

		// Token: 0x04000219 RID: 537
		private IExtension extensionObject;
	}
}
