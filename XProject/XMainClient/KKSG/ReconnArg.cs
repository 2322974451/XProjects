using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000039 RID: 57
	[ProtoContract(Name = "ReconnArg")]
	[Serializable]
	public class ReconnArg : IExtensible
	{
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0000A164 File Offset: 0x00008364
		// (set) Token: 0x060003DF RID: 991 RVA: 0x0000A191 File Offset: 0x00008391
		[ProtoMember(1, IsRequired = false, Name = "session", DataFormat = DataFormat.TwosComplement)]
		public ulong session
		{
			get
			{
				return this._session ?? 0UL;
			}
			set
			{
				this._session = new ulong?(value);
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x0000A1A0 File Offset: 0x000083A0
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x0000A1C0 File Offset: 0x000083C0
		[XmlIgnore]
		[Browsable(false)]
		public bool sessionSpecified
		{
			get
			{
				return this._session != null;
			}
			set
			{
				bool flag = value == (this._session == null);
				if (flag)
				{
					this._session = (value ? new ulong?(this.session) : null);
				}
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000A204 File Offset: 0x00008404
		private bool ShouldSerializesession()
		{
			return this.sessionSpecified;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000A21C File Offset: 0x0000841C
		private void Resetsession()
		{
			this.sessionSpecified = false;
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x0000A228 File Offset: 0x00008428
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x0000A254 File Offset: 0x00008454
		[ProtoMember(2, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000A264 File Offset: 0x00008464
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x0000A284 File Offset: 0x00008484
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000A2C8 File Offset: 0x000084C8
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000A2E0 File Offset: 0x000084E0
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0000A2EC File Offset: 0x000084EC
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x0000A319 File Offset: 0x00008519
		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0000A328 File Offset: 0x00008528
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x0000A348 File Offset: 0x00008548
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

		// Token: 0x060003EE RID: 1006 RVA: 0x0000A38C File Offset: 0x0000858C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000A3A4 File Offset: 0x000085A4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000A3B0 File Offset: 0x000085B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000106 RID: 262
		private ulong? _session;

		// Token: 0x04000107 RID: 263
		private uint? _sceneid;

		// Token: 0x04000108 RID: 264
		private ulong? _roleid;

		// Token: 0x04000109 RID: 265
		private IExtension extensionObject;
	}
}
