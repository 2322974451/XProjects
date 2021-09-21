using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000236 RID: 566
	[ProtoContract(Name = "HallIconPara")]
	[Serializable]
	public class HallIconPara : IExtensible
	{
		// Token: 0x170009CB RID: 2507
		// (get) Token: 0x06001F6F RID: 8047 RVA: 0x0003DA00 File Offset: 0x0003BC00
		// (set) Token: 0x06001F70 RID: 8048 RVA: 0x0003DA2C File Offset: 0x0003BC2C
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public HallIconState state
		{
			get
			{
				return this._state ?? HallIconState.HICONS_BEGIN;
			}
			set
			{
				this._state = new HallIconState?(value);
			}
		}

		// Token: 0x170009CC RID: 2508
		// (get) Token: 0x06001F71 RID: 8049 RVA: 0x0003DA3C File Offset: 0x0003BC3C
		// (set) Token: 0x06001F72 RID: 8050 RVA: 0x0003DA5C File Offset: 0x0003BC5C
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new HallIconState?(this.state) : null);
				}
			}
		}

		// Token: 0x06001F73 RID: 8051 RVA: 0x0003DAA0 File Offset: 0x0003BCA0
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06001F74 RID: 8052 RVA: 0x0003DAB8 File Offset: 0x0003BCB8
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170009CD RID: 2509
		// (get) Token: 0x06001F75 RID: 8053 RVA: 0x0003DAC4 File Offset: 0x0003BCC4
		// (set) Token: 0x06001F76 RID: 8054 RVA: 0x0003DAF0 File Offset: 0x0003BCF0
		[ProtoMember(2, IsRequired = false, Name = "systemid", DataFormat = DataFormat.TwosComplement)]
		public int systemid
		{
			get
			{
				return this._systemid ?? 0;
			}
			set
			{
				this._systemid = new int?(value);
			}
		}

		// Token: 0x170009CE RID: 2510
		// (get) Token: 0x06001F77 RID: 8055 RVA: 0x0003DB00 File Offset: 0x0003BD00
		// (set) Token: 0x06001F78 RID: 8056 RVA: 0x0003DB20 File Offset: 0x0003BD20
		[XmlIgnore]
		[Browsable(false)]
		public bool systemidSpecified
		{
			get
			{
				return this._systemid != null;
			}
			set
			{
				bool flag = value == (this._systemid == null);
				if (flag)
				{
					this._systemid = (value ? new int?(this.systemid) : null);
				}
			}
		}

		// Token: 0x06001F79 RID: 8057 RVA: 0x0003DB64 File Offset: 0x0003BD64
		private bool ShouldSerializesystemid()
		{
			return this.systemidSpecified;
		}

		// Token: 0x06001F7A RID: 8058 RVA: 0x0003DB7C File Offset: 0x0003BD7C
		private void Resetsystemid()
		{
			this.systemidSpecified = false;
		}

		// Token: 0x170009CF RID: 2511
		// (get) Token: 0x06001F7B RID: 8059 RVA: 0x0003DB88 File Offset: 0x0003BD88
		// (set) Token: 0x06001F7C RID: 8060 RVA: 0x0003DBA0 File Offset: 0x0003BDA0
		[ProtoMember(3, IsRequired = false, Name = "liveInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LiveIconData liveInfo
		{
			get
			{
				return this._liveInfo;
			}
			set
			{
				this._liveInfo = value;
			}
		}

		// Token: 0x06001F7D RID: 8061 RVA: 0x0003DBAC File Offset: 0x0003BDAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007D7 RID: 2007
		private HallIconState? _state;

		// Token: 0x040007D8 RID: 2008
		private int? _systemid;

		// Token: 0x040007D9 RID: 2009
		private LiveIconData _liveInfo = null;

		// Token: 0x040007DA RID: 2010
		private IExtension extensionObject;
	}
}
