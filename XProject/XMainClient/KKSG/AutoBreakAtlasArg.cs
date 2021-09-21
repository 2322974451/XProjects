using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001FB RID: 507
	[ProtoContract(Name = "AutoBreakAtlasArg")]
	[Serializable]
	public class AutoBreakAtlasArg : IExtensible
	{
		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06001CD0 RID: 7376 RVA: 0x00038C10 File Offset: 0x00036E10
		[ProtoMember(1, Name = "quilts", DataFormat = DataFormat.TwosComplement)]
		public List<uint> quilts
		{
			get
			{
				return this._quilts;
			}
		}

		// Token: 0x17000905 RID: 2309
		// (get) Token: 0x06001CD1 RID: 7377 RVA: 0x00038C28 File Offset: 0x00036E28
		// (set) Token: 0x06001CD2 RID: 7378 RVA: 0x00038C54 File Offset: 0x00036E54
		[ProtoMember(2, IsRequired = false, Name = "groupId", DataFormat = DataFormat.TwosComplement)]
		public uint groupId
		{
			get
			{
				return this._groupId ?? 0U;
			}
			set
			{
				this._groupId = new uint?(value);
			}
		}

		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x06001CD3 RID: 7379 RVA: 0x00038C64 File Offset: 0x00036E64
		// (set) Token: 0x06001CD4 RID: 7380 RVA: 0x00038C84 File Offset: 0x00036E84
		[XmlIgnore]
		[Browsable(false)]
		public bool groupIdSpecified
		{
			get
			{
				return this._groupId != null;
			}
			set
			{
				bool flag = value == (this._groupId == null);
				if (flag)
				{
					this._groupId = (value ? new uint?(this.groupId) : null);
				}
			}
		}

		// Token: 0x06001CD5 RID: 7381 RVA: 0x00038CC8 File Offset: 0x00036EC8
		private bool ShouldSerializegroupId()
		{
			return this.groupIdSpecified;
		}

		// Token: 0x06001CD6 RID: 7382 RVA: 0x00038CE0 File Offset: 0x00036EE0
		private void ResetgroupId()
		{
			this.groupIdSpecified = false;
		}

		// Token: 0x06001CD7 RID: 7383 RVA: 0x00038CEC File Offset: 0x00036EEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400072C RID: 1836
		private readonly List<uint> _quilts = new List<uint>();

		// Token: 0x0400072D RID: 1837
		private uint? _groupId;

		// Token: 0x0400072E RID: 1838
		private IExtension extensionObject;
	}
}
