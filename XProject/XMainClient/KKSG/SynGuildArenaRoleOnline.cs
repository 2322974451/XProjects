using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001AF RID: 431
	[ProtoContract(Name = "SynGuildArenaRoleOnline")]
	[Serializable]
	public class SynGuildArenaRoleOnline : IExtensible
	{
		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x0600196C RID: 6508 RVA: 0x00032798 File Offset: 0x00030998
		// (set) Token: 0x0600196D RID: 6509 RVA: 0x000327C5 File Offset: 0x000309C5
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

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x0600196E RID: 6510 RVA: 0x000327D4 File Offset: 0x000309D4
		// (set) Token: 0x0600196F RID: 6511 RVA: 0x000327F4 File Offset: 0x000309F4
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

		// Token: 0x06001970 RID: 6512 RVA: 0x00032838 File Offset: 0x00030A38
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x00032850 File Offset: 0x00030A50
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x06001972 RID: 6514 RVA: 0x0003285C File Offset: 0x00030A5C
		// (set) Token: 0x06001973 RID: 6515 RVA: 0x00032888 File Offset: 0x00030A88
		[ProtoMember(2, IsRequired = false, Name = "online", DataFormat = DataFormat.Default)]
		public bool online
		{
			get
			{
				return this._online ?? false;
			}
			set
			{
				this._online = new bool?(value);
			}
		}

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x06001974 RID: 6516 RVA: 0x00032898 File Offset: 0x00030A98
		// (set) Token: 0x06001975 RID: 6517 RVA: 0x000328B8 File Offset: 0x00030AB8
		[XmlIgnore]
		[Browsable(false)]
		public bool onlineSpecified
		{
			get
			{
				return this._online != null;
			}
			set
			{
				bool flag = value == (this._online == null);
				if (flag)
				{
					this._online = (value ? new bool?(this.online) : null);
				}
			}
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x000328FC File Offset: 0x00030AFC
		private bool ShouldSerializeonline()
		{
			return this.onlineSpecified;
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x00032914 File Offset: 0x00030B14
		private void Resetonline()
		{
			this.onlineSpecified = false;
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x00032920 File Offset: 0x00030B20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000651 RID: 1617
		private ulong? _roleid;

		// Token: 0x04000652 RID: 1618
		private bool? _online;

		// Token: 0x04000653 RID: 1619
		private IExtension extensionObject;
	}
}
