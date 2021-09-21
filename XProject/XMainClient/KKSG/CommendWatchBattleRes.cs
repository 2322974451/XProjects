using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000182 RID: 386
	[ProtoContract(Name = "CommendWatchBattleRes")]
	[Serializable]
	public class CommendWatchBattleRes : IExtensible
	{
		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x06001746 RID: 5958 RVA: 0x0002E860 File Offset: 0x0002CA60
		// (set) Token: 0x06001747 RID: 5959 RVA: 0x0002E88C File Offset: 0x0002CA8C
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x06001748 RID: 5960 RVA: 0x0002E89C File Offset: 0x0002CA9C
		// (set) Token: 0x06001749 RID: 5961 RVA: 0x0002E8BC File Offset: 0x0002CABC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0002E900 File Offset: 0x0002CB00
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600174B RID: 5963 RVA: 0x0002E918 File Offset: 0x0002CB18
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x0002E924 File Offset: 0x0002CB24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005C2 RID: 1474
		private ErrorCode? _error;

		// Token: 0x040005C3 RID: 1475
		private IExtension extensionObject;
	}
}
