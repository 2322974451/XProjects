using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200066C RID: 1644
	[ProtoContract(Name = "RoleSystem")]
	[Serializable]
	public class RoleSystem : IExtensible
	{
		// Token: 0x17002101 RID: 8449
		// (get) Token: 0x06006864 RID: 26724 RVA: 0x000C78B8 File Offset: 0x000C5AB8
		// (set) Token: 0x06006865 RID: 26725 RVA: 0x000C78D5 File Offset: 0x000C5AD5
		[ProtoMember(1, IsRequired = false, Name = "system", DataFormat = DataFormat.Default)]
		public byte[] system
		{
			get
			{
				return this._system ?? null;
			}
			set
			{
				this._system = value;
			}
		}

		// Token: 0x17002102 RID: 8450
		// (get) Token: 0x06006866 RID: 26726 RVA: 0x000C78E0 File Offset: 0x000C5AE0
		// (set) Token: 0x06006867 RID: 26727 RVA: 0x000C78FC File Offset: 0x000C5AFC
		[XmlIgnore]
		[Browsable(false)]
		public bool systemSpecified
		{
			get
			{
				return this._system != null;
			}
			set
			{
				bool flag = value == (this._system == null);
				if (flag)
				{
					this._system = (value ? this.system : null);
				}
			}
		}

		// Token: 0x06006868 RID: 26728 RVA: 0x000C792C File Offset: 0x000C5B2C
		private bool ShouldSerializesystem()
		{
			return this.systemSpecified;
		}

		// Token: 0x06006869 RID: 26729 RVA: 0x000C7944 File Offset: 0x000C5B44
		private void Resetsystem()
		{
			this.systemSpecified = false;
		}

		// Token: 0x17002103 RID: 8451
		// (get) Token: 0x0600686A RID: 26730 RVA: 0x000C7950 File Offset: 0x000C5B50
		// (set) Token: 0x0600686B RID: 26731 RVA: 0x000C796D File Offset: 0x000C5B6D
		[ProtoMember(2, IsRequired = false, Name = "firsttime", DataFormat = DataFormat.Default)]
		public byte[] firsttime
		{
			get
			{
				return this._firsttime ?? null;
			}
			set
			{
				this._firsttime = value;
			}
		}

		// Token: 0x17002104 RID: 8452
		// (get) Token: 0x0600686C RID: 26732 RVA: 0x000C7978 File Offset: 0x000C5B78
		// (set) Token: 0x0600686D RID: 26733 RVA: 0x000C7994 File Offset: 0x000C5B94
		[XmlIgnore]
		[Browsable(false)]
		public bool firsttimeSpecified
		{
			get
			{
				return this._firsttime != null;
			}
			set
			{
				bool flag = value == (this._firsttime == null);
				if (flag)
				{
					this._firsttime = (value ? this.firsttime : null);
				}
			}
		}

		// Token: 0x0600686E RID: 26734 RVA: 0x000C79C4 File Offset: 0x000C5BC4
		private bool ShouldSerializefirsttime()
		{
			return this.firsttimeSpecified;
		}

		// Token: 0x0600686F RID: 26735 RVA: 0x000C79DC File Offset: 0x000C5BDC
		private void Resetfirsttime()
		{
			this.firsttimeSpecified = false;
		}

		// Token: 0x17002105 RID: 8453
		// (get) Token: 0x06006870 RID: 26736 RVA: 0x000C79E8 File Offset: 0x000C5BE8
		[ProtoMember(3, Name = "opentime", DataFormat = DataFormat.Default)]
		public List<SysOpenTime> opentime
		{
			get
			{
				return this._opentime;
			}
		}

		// Token: 0x06006871 RID: 26737 RVA: 0x000C7A00 File Offset: 0x000C5C00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001932 RID: 6450
		private byte[] _system;

		// Token: 0x04001933 RID: 6451
		private byte[] _firsttime;

		// Token: 0x04001934 RID: 6452
		private readonly List<SysOpenTime> _opentime = new List<SysOpenTime>();

		// Token: 0x04001935 RID: 6453
		private IExtension extensionObject;
	}
}
