using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000100 RID: 256
	[ProtoContract(Name = "MailOpArg")]
	[Serializable]
	public class MailOpArg : IExtensible
	{
		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x0600107B RID: 4219 RVA: 0x00021CF4 File Offset: 0x0001FEF4
		// (set) Token: 0x0600107C RID: 4220 RVA: 0x00021D20 File Offset: 0x0001FF20
		[ProtoMember(1, IsRequired = false, Name = "optype", DataFormat = DataFormat.TwosComplement)]
		public uint optype
		{
			get
			{
				return this._optype ?? 0U;
			}
			set
			{
				this._optype = new uint?(value);
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x0600107D RID: 4221 RVA: 0x00021D30 File Offset: 0x0001FF30
		// (set) Token: 0x0600107E RID: 4222 RVA: 0x00021D50 File Offset: 0x0001FF50
		[XmlIgnore]
		[Browsable(false)]
		public bool optypeSpecified
		{
			get
			{
				return this._optype != null;
			}
			set
			{
				bool flag = value == (this._optype == null);
				if (flag)
				{
					this._optype = (value ? new uint?(this.optype) : null);
				}
			}
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x00021D94 File Offset: 0x0001FF94
		private bool ShouldSerializeoptype()
		{
			return this.optypeSpecified;
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x00021DAC File Offset: 0x0001FFAC
		private void Resetoptype()
		{
			this.optypeSpecified = false;
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06001081 RID: 4225 RVA: 0x00021DB8 File Offset: 0x0001FFB8
		[ProtoMember(2, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uid
		{
			get
			{
				return this._uid;
			}
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x00021DD0 File Offset: 0x0001FFD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400041E RID: 1054
		private uint? _optype;

		// Token: 0x0400041F RID: 1055
		private readonly List<ulong> _uid = new List<ulong>();

		// Token: 0x04000420 RID: 1056
		private IExtension extensionObject;
	}
}
