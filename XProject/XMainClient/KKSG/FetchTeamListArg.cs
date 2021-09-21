using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200005D RID: 93
	[ProtoContract(Name = "FetchTeamListArg")]
	[Serializable]
	public class FetchTeamListArg : IExtensible
	{
		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x0000E650 File Offset: 0x0000C850
		[ProtoMember(1, Name = "categoryID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> categoryID
		{
			get
			{
				return this._categoryID;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000620 RID: 1568 RVA: 0x0000E668 File Offset: 0x0000C868
		// (set) Token: 0x06000621 RID: 1569 RVA: 0x0000E694 File Offset: 0x0000C894
		[ProtoMember(2, IsRequired = false, Name = "expID", DataFormat = DataFormat.TwosComplement)]
		public uint expID
		{
			get
			{
				return this._expID ?? 0U;
			}
			set
			{
				this._expID = new uint?(value);
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x0000E6A4 File Offset: 0x0000C8A4
		// (set) Token: 0x06000623 RID: 1571 RVA: 0x0000E6C4 File Offset: 0x0000C8C4
		[XmlIgnore]
		[Browsable(false)]
		public bool expIDSpecified
		{
			get
			{
				return this._expID != null;
			}
			set
			{
				bool flag = value == (this._expID == null);
				if (flag)
				{
					this._expID = (value ? new uint?(this.expID) : null);
				}
			}
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0000E708 File Offset: 0x0000C908
		private bool ShouldSerializeexpID()
		{
			return this.expIDSpecified;
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0000E720 File Offset: 0x0000C920
		private void ResetexpID()
		{
			this.expIDSpecified = false;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0000E72C File Offset: 0x0000C92C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400018E RID: 398
		private readonly List<uint> _categoryID = new List<uint>();

		// Token: 0x0400018F RID: 399
		private uint? _expID;

		// Token: 0x04000190 RID: 400
		private IExtension extensionObject;
	}
}
