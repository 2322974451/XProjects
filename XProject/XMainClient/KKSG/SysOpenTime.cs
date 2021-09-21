using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200066D RID: 1645
	[ProtoContract(Name = "SysOpenTime")]
	[Serializable]
	public class SysOpenTime : IExtensible
	{
		// Token: 0x17002106 RID: 8454
		// (get) Token: 0x06006873 RID: 26739 RVA: 0x000C7A20 File Offset: 0x000C5C20
		// (set) Token: 0x06006874 RID: 26740 RVA: 0x000C7A4C File Offset: 0x000C5C4C
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public int id
		{
			get
			{
				return this._id ?? 0;
			}
			set
			{
				this._id = new int?(value);
			}
		}

		// Token: 0x17002107 RID: 8455
		// (get) Token: 0x06006875 RID: 26741 RVA: 0x000C7A5C File Offset: 0x000C5C5C
		// (set) Token: 0x06006876 RID: 26742 RVA: 0x000C7A7C File Offset: 0x000C5C7C
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new int?(this.id) : null);
				}
			}
		}

		// Token: 0x06006877 RID: 26743 RVA: 0x000C7AC0 File Offset: 0x000C5CC0
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06006878 RID: 26744 RVA: 0x000C7AD8 File Offset: 0x000C5CD8
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17002108 RID: 8456
		// (get) Token: 0x06006879 RID: 26745 RVA: 0x000C7AE4 File Offset: 0x000C5CE4
		// (set) Token: 0x0600687A RID: 26746 RVA: 0x000C7B10 File Offset: 0x000C5D10
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public int time
		{
			get
			{
				return this._time ?? 0;
			}
			set
			{
				this._time = new int?(value);
			}
		}

		// Token: 0x17002109 RID: 8457
		// (get) Token: 0x0600687B RID: 26747 RVA: 0x000C7B20 File Offset: 0x000C5D20
		// (set) Token: 0x0600687C RID: 26748 RVA: 0x000C7B40 File Offset: 0x000C5D40
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new int?(this.time) : null);
				}
			}
		}

		// Token: 0x0600687D RID: 26749 RVA: 0x000C7B84 File Offset: 0x000C5D84
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600687E RID: 26750 RVA: 0x000C7B9C File Offset: 0x000C5D9C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x0600687F RID: 26751 RVA: 0x000C7BA8 File Offset: 0x000C5DA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001936 RID: 6454
		private int? _id;

		// Token: 0x04001937 RID: 6455
		private int? _time;

		// Token: 0x04001938 RID: 6456
		private IExtension extensionObject;
	}
}
