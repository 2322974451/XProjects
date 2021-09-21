using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000031 RID: 49
	[ProtoContract(Name = "QuerySceneDayCountArg")]
	[Serializable]
	public class QuerySceneDayCountArg : IExtensible
	{
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00009164 File Offset: 0x00007364
		[ProtoMember(1, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> groupid
		{
			get
			{
				return this._groupid;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000356 RID: 854 RVA: 0x0000917C File Offset: 0x0000737C
		// (set) Token: 0x06000357 RID: 855 RVA: 0x000091A8 File Offset: 0x000073A8
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000358 RID: 856 RVA: 0x000091B8 File Offset: 0x000073B8
		// (set) Token: 0x06000359 RID: 857 RVA: 0x000091D8 File Offset: 0x000073D8
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

		// Token: 0x0600035A RID: 858 RVA: 0x0000921C File Offset: 0x0000741C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00009234 File Offset: 0x00007434
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00009240 File Offset: 0x00007440
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000E1 RID: 225
		private readonly List<uint> _groupid = new List<uint>();

		// Token: 0x040000E2 RID: 226
		private uint? _type;

		// Token: 0x040000E3 RID: 227
		private IExtension extensionObject;
	}
}
