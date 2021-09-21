using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C7 RID: 711
	[ProtoContract(Name = "JustDanceArg")]
	[Serializable]
	public class JustDanceArg : IExtensible
	{
		// Token: 0x17000C36 RID: 3126
		// (get) Token: 0x06002745 RID: 10053 RVA: 0x0004C5A8 File Offset: 0x0004A7A8
		// (set) Token: 0x06002746 RID: 10054 RVA: 0x0004C5D4 File Offset: 0x0004A7D4
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000C37 RID: 3127
		// (get) Token: 0x06002747 RID: 10055 RVA: 0x0004C5E4 File Offset: 0x0004A7E4
		// (set) Token: 0x06002748 RID: 10056 RVA: 0x0004C604 File Offset: 0x0004A804
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06002749 RID: 10057 RVA: 0x0004C648 File Offset: 0x0004A848
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600274A RID: 10058 RVA: 0x0004C660 File Offset: 0x0004A860
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000C38 RID: 3128
		// (get) Token: 0x0600274B RID: 10059 RVA: 0x0004C66C File Offset: 0x0004A86C
		// (set) Token: 0x0600274C RID: 10060 RVA: 0x0004C698 File Offset: 0x0004A898
		[ProtoMember(2, IsRequired = false, Name = "danceid", DataFormat = DataFormat.TwosComplement)]
		public uint danceid
		{
			get
			{
				return this._danceid ?? 0U;
			}
			set
			{
				this._danceid = new uint?(value);
			}
		}

		// Token: 0x17000C39 RID: 3129
		// (get) Token: 0x0600274D RID: 10061 RVA: 0x0004C6A8 File Offset: 0x0004A8A8
		// (set) Token: 0x0600274E RID: 10062 RVA: 0x0004C6C8 File Offset: 0x0004A8C8
		[XmlIgnore]
		[Browsable(false)]
		public bool danceidSpecified
		{
			get
			{
				return this._danceid != null;
			}
			set
			{
				bool flag = value == (this._danceid == null);
				if (flag)
				{
					this._danceid = (value ? new uint?(this.danceid) : null);
				}
			}
		}

		// Token: 0x0600274F RID: 10063 RVA: 0x0004C70C File Offset: 0x0004A90C
		private bool ShouldSerializedanceid()
		{
			return this.danceidSpecified;
		}

		// Token: 0x06002750 RID: 10064 RVA: 0x0004C724 File Offset: 0x0004A924
		private void Resetdanceid()
		{
			this.danceidSpecified = false;
		}

		// Token: 0x06002751 RID: 10065 RVA: 0x0004C730 File Offset: 0x0004A930
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009C5 RID: 2501
		private uint? _type;

		// Token: 0x040009C6 RID: 2502
		private uint? _danceid;

		// Token: 0x040009C7 RID: 2503
		private IExtension extensionObject;
	}
}
