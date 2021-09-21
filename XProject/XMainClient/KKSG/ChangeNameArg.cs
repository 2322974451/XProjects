using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F8 RID: 760
	[ProtoContract(Name = "ChangeNameArg")]
	[Serializable]
	public class ChangeNameArg : IExtensible
	{
		// Token: 0x17000CF1 RID: 3313
		// (get) Token: 0x060029B9 RID: 10681 RVA: 0x00050F48 File Offset: 0x0004F148
		// (set) Token: 0x060029BA RID: 10682 RVA: 0x00050F69 File Offset: 0x0004F169
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000CF2 RID: 3314
		// (get) Token: 0x060029BB RID: 10683 RVA: 0x00050F74 File Offset: 0x0004F174
		// (set) Token: 0x060029BC RID: 10684 RVA: 0x00050F90 File Offset: 0x0004F190
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x060029BD RID: 10685 RVA: 0x00050FC0 File Offset: 0x0004F1C0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060029BE RID: 10686 RVA: 0x00050FD8 File Offset: 0x0004F1D8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17000CF3 RID: 3315
		// (get) Token: 0x060029BF RID: 10687 RVA: 0x00050FE4 File Offset: 0x0004F1E4
		// (set) Token: 0x060029C0 RID: 10688 RVA: 0x00051010 File Offset: 0x0004F210
		[ProtoMember(2, IsRequired = false, Name = "iscostitem", DataFormat = DataFormat.Default)]
		public bool iscostitem
		{
			get
			{
				return this._iscostitem ?? false;
			}
			set
			{
				this._iscostitem = new bool?(value);
			}
		}

		// Token: 0x17000CF4 RID: 3316
		// (get) Token: 0x060029C1 RID: 10689 RVA: 0x00051020 File Offset: 0x0004F220
		// (set) Token: 0x060029C2 RID: 10690 RVA: 0x00051040 File Offset: 0x0004F240
		[XmlIgnore]
		[Browsable(false)]
		public bool iscostitemSpecified
		{
			get
			{
				return this._iscostitem != null;
			}
			set
			{
				bool flag = value == (this._iscostitem == null);
				if (flag)
				{
					this._iscostitem = (value ? new bool?(this.iscostitem) : null);
				}
			}
		}

		// Token: 0x060029C3 RID: 10691 RVA: 0x00051084 File Offset: 0x0004F284
		private bool ShouldSerializeiscostitem()
		{
			return this.iscostitemSpecified;
		}

		// Token: 0x060029C4 RID: 10692 RVA: 0x0005109C File Offset: 0x0004F29C
		private void Resetiscostitem()
		{
			this.iscostitemSpecified = false;
		}

		// Token: 0x060029C5 RID: 10693 RVA: 0x000510A8 File Offset: 0x0004F2A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A5C RID: 2652
		private string _name;

		// Token: 0x04000A5D RID: 2653
		private bool? _iscostitem;

		// Token: 0x04000A5E RID: 2654
		private IExtension extensionObject;
	}
}
