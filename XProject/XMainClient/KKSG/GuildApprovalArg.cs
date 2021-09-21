using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200008E RID: 142
	[ProtoContract(Name = "GuildApprovalArg")]
	[Serializable]
	public class GuildApprovalArg : IExtensible
	{
		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x0001422C File Offset: 0x0001242C
		// (set) Token: 0x06000935 RID: 2357 RVA: 0x00014259 File Offset: 0x00012459
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

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x00014268 File Offset: 0x00012468
		// (set) Token: 0x06000937 RID: 2359 RVA: 0x00014288 File Offset: 0x00012488
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

		// Token: 0x06000938 RID: 2360 RVA: 0x000142CC File Offset: 0x000124CC
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x000142E4 File Offset: 0x000124E4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x000142F0 File Offset: 0x000124F0
		// (set) Token: 0x0600093B RID: 2363 RVA: 0x0001431C File Offset: 0x0001251C
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x0001432C File Offset: 0x0001252C
		// (set) Token: 0x0600093D RID: 2365 RVA: 0x0001434C File Offset: 0x0001254C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x00014390 File Offset: 0x00012590
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x000143A8 File Offset: 0x000125A8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x000143B4 File Offset: 0x000125B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000267 RID: 615
		private ulong? _roleid;

		// Token: 0x04000268 RID: 616
		private int? _type;

		// Token: 0x04000269 RID: 617
		private IExtension extensionObject;
	}
}
