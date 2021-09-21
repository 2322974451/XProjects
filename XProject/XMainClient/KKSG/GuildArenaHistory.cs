using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006CB RID: 1739
	[ProtoContract(Name = "GuildArenaHistory")]
	[Serializable]
	public class GuildArenaHistory : IExtensible
	{
		// Token: 0x17002462 RID: 9314
		// (get) Token: 0x060072EE RID: 29422 RVA: 0x000DBE54 File Offset: 0x000DA054
		// (set) Token: 0x060072EF RID: 29423 RVA: 0x000DBE75 File Offset: 0x000DA075
		[ProtoMember(1, IsRequired = false, Name = "first", DataFormat = DataFormat.Default)]
		public string first
		{
			get
			{
				return this._first ?? "";
			}
			set
			{
				this._first = value;
			}
		}

		// Token: 0x17002463 RID: 9315
		// (get) Token: 0x060072F0 RID: 29424 RVA: 0x000DBE80 File Offset: 0x000DA080
		// (set) Token: 0x060072F1 RID: 29425 RVA: 0x000DBE9C File Offset: 0x000DA09C
		[XmlIgnore]
		[Browsable(false)]
		public bool firstSpecified
		{
			get
			{
				return this._first != null;
			}
			set
			{
				bool flag = value == (this._first == null);
				if (flag)
				{
					this._first = (value ? this.first : null);
				}
			}
		}

		// Token: 0x060072F2 RID: 29426 RVA: 0x000DBECC File Offset: 0x000DA0CC
		private bool ShouldSerializefirst()
		{
			return this.firstSpecified;
		}

		// Token: 0x060072F3 RID: 29427 RVA: 0x000DBEE4 File Offset: 0x000DA0E4
		private void Resetfirst()
		{
			this.firstSpecified = false;
		}

		// Token: 0x17002464 RID: 9316
		// (get) Token: 0x060072F4 RID: 29428 RVA: 0x000DBEF0 File Offset: 0x000DA0F0
		// (set) Token: 0x060072F5 RID: 29429 RVA: 0x000DBF11 File Offset: 0x000DA111
		[ProtoMember(2, IsRequired = false, Name = "second", DataFormat = DataFormat.Default)]
		public string second
		{
			get
			{
				return this._second ?? "";
			}
			set
			{
				this._second = value;
			}
		}

		// Token: 0x17002465 RID: 9317
		// (get) Token: 0x060072F6 RID: 29430 RVA: 0x000DBF1C File Offset: 0x000DA11C
		// (set) Token: 0x060072F7 RID: 29431 RVA: 0x000DBF38 File Offset: 0x000DA138
		[XmlIgnore]
		[Browsable(false)]
		public bool secondSpecified
		{
			get
			{
				return this._second != null;
			}
			set
			{
				bool flag = value == (this._second == null);
				if (flag)
				{
					this._second = (value ? this.second : null);
				}
			}
		}

		// Token: 0x060072F8 RID: 29432 RVA: 0x000DBF68 File Offset: 0x000DA168
		private bool ShouldSerializesecond()
		{
			return this.secondSpecified;
		}

		// Token: 0x060072F9 RID: 29433 RVA: 0x000DBF80 File Offset: 0x000DA180
		private void Resetsecond()
		{
			this.secondSpecified = false;
		}

		// Token: 0x060072FA RID: 29434 RVA: 0x000DBF8C File Offset: 0x000DA18C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B5C RID: 7004
		private string _first;

		// Token: 0x04001B5D RID: 7005
		private string _second;

		// Token: 0x04001B5E RID: 7006
		private IExtension extensionObject;
	}
}
