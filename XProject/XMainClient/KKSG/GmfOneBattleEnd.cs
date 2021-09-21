using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200019B RID: 411
	[ProtoContract(Name = "GmfOneBattleEnd")]
	[Serializable]
	public class GmfOneBattleEnd : IExtensible
	{
		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x0600189A RID: 6298 RVA: 0x00030FEC File Offset: 0x0002F1EC
		// (set) Token: 0x0600189B RID: 6299 RVA: 0x00031018 File Offset: 0x0002F218
		[ProtoMember(1, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public GMFFailReason reason
		{
			get
			{
				return this._reason ?? GMFFailReason.GMF_FAIL_NONE;
			}
			set
			{
				this._reason = new GMFFailReason?(value);
			}
		}

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x0600189C RID: 6300 RVA: 0x00031028 File Offset: 0x0002F228
		// (set) Token: 0x0600189D RID: 6301 RVA: 0x00031048 File Offset: 0x0002F248
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
					this._reason = (value ? new GMFFailReason?(this.reason) : null);
				}
			}
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x0003108C File Offset: 0x0002F28C
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x000310A4 File Offset: 0x0002F2A4
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x060018A0 RID: 6304 RVA: 0x000310B0 File Offset: 0x0002F2B0
		// (set) Token: 0x060018A1 RID: 6305 RVA: 0x000310C8 File Offset: 0x0002F2C8
		[ProtoMember(2, IsRequired = false, Name = "winrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfRoleBrief winrole
		{
			get
			{
				return this._winrole;
			}
			set
			{
				this._winrole = value;
			}
		}

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x060018A2 RID: 6306 RVA: 0x000310D4 File Offset: 0x0002F2D4
		// (set) Token: 0x060018A3 RID: 6307 RVA: 0x000310EC File Offset: 0x0002F2EC
		[ProtoMember(3, IsRequired = false, Name = "loselrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfRoleBrief loselrole
		{
			get
			{
				return this._loselrole;
			}
			set
			{
				this._loselrole = value;
			}
		}

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x060018A4 RID: 6308 RVA: 0x000310F8 File Offset: 0x0002F2F8
		// (set) Token: 0x060018A5 RID: 6309 RVA: 0x00031110 File Offset: 0x0002F310
		[ProtoMember(4, IsRequired = false, Name = "winguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief winguild
		{
			get
			{
				return this._winguild;
			}
			set
			{
				this._winguild = value;
			}
		}

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x060018A6 RID: 6310 RVA: 0x0003111C File Offset: 0x0002F31C
		// (set) Token: 0x060018A7 RID: 6311 RVA: 0x00031134 File Offset: 0x0002F334
		[ProtoMember(5, IsRequired = false, Name = "loseguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief loseguild
		{
			get
			{
				return this._loseguild;
			}
			set
			{
				this._loseguild = value;
			}
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00031140 File Offset: 0x0002F340
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000614 RID: 1556
		private GMFFailReason? _reason;

		// Token: 0x04000615 RID: 1557
		private GmfRoleBrief _winrole = null;

		// Token: 0x04000616 RID: 1558
		private GmfRoleBrief _loselrole = null;

		// Token: 0x04000617 RID: 1559
		private GmfGuildBrief _winguild = null;

		// Token: 0x04000618 RID: 1560
		private GmfGuildBrief _loseguild = null;

		// Token: 0x04000619 RID: 1561
		private IExtension extensionObject;
	}
}
