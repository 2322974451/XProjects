using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000086 RID: 134
	[ProtoContract(Name = "FetchChapterChestArg")]
	[Serializable]
	public class FetchChapterChestArg : IExtensible
	{
		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x00013740 File Offset: 0x00011940
		// (set) Token: 0x060008D7 RID: 2263 RVA: 0x0001376C File Offset: 0x0001196C
		[ProtoMember(1, IsRequired = false, Name = "chapterID", DataFormat = DataFormat.TwosComplement)]
		public int chapterID
		{
			get
			{
				return this._chapterID ?? 0;
			}
			set
			{
				this._chapterID = new int?(value);
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x0001377C File Offset: 0x0001197C
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x0001379C File Offset: 0x0001199C
		[XmlIgnore]
		[Browsable(false)]
		public bool chapterIDSpecified
		{
			get
			{
				return this._chapterID != null;
			}
			set
			{
				bool flag = value == (this._chapterID == null);
				if (flag)
				{
					this._chapterID = (value ? new int?(this.chapterID) : null);
				}
			}
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000137E0 File Offset: 0x000119E0
		private bool ShouldSerializechapterID()
		{
			return this.chapterIDSpecified;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x000137F8 File Offset: 0x000119F8
		private void ResetchapterID()
		{
			this.chapterIDSpecified = false;
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x060008DC RID: 2268 RVA: 0x00013804 File Offset: 0x00011A04
		// (set) Token: 0x060008DD RID: 2269 RVA: 0x00013830 File Offset: 0x00011A30
		[ProtoMember(2, IsRequired = false, Name = "chestID", DataFormat = DataFormat.TwosComplement)]
		public int chestID
		{
			get
			{
				return this._chestID ?? 0;
			}
			set
			{
				this._chestID = new int?(value);
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060008DE RID: 2270 RVA: 0x00013840 File Offset: 0x00011A40
		// (set) Token: 0x060008DF RID: 2271 RVA: 0x00013860 File Offset: 0x00011A60
		[XmlIgnore]
		[Browsable(false)]
		public bool chestIDSpecified
		{
			get
			{
				return this._chestID != null;
			}
			set
			{
				bool flag = value == (this._chestID == null);
				if (flag)
				{
					this._chestID = (value ? new int?(this.chestID) : null);
				}
			}
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x000138A4 File Offset: 0x00011AA4
		private bool ShouldSerializechestID()
		{
			return this.chestIDSpecified;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x000138BC File Offset: 0x00011ABC
		private void ResetchestID()
		{
			this.chestIDSpecified = false;
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x000138C8 File Offset: 0x00011AC8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000248 RID: 584
		private int? _chapterID;

		// Token: 0x04000249 RID: 585
		private int? _chestID;

		// Token: 0x0400024A RID: 586
		private IExtension extensionObject;
	}
}
