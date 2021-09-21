using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000353 RID: 851
	[ProtoContract(Name = "AudioAuthKeyArg")]
	[Serializable]
	public class AudioAuthKeyArg : IExtensible
	{
		// Token: 0x17000E75 RID: 3701
		// (get) Token: 0x06002E9C RID: 11932 RVA: 0x0005A128 File Offset: 0x00058328
		// (set) Token: 0x06002E9D RID: 11933 RVA: 0x0005A149 File Offset: 0x00058349
		[ProtoMember(1, IsRequired = false, Name = "open_id", DataFormat = DataFormat.Default)]
		public string open_id
		{
			get
			{
				return this._open_id ?? "";
			}
			set
			{
				this._open_id = value;
			}
		}

		// Token: 0x17000E76 RID: 3702
		// (get) Token: 0x06002E9E RID: 11934 RVA: 0x0005A154 File Offset: 0x00058354
		// (set) Token: 0x06002E9F RID: 11935 RVA: 0x0005A170 File Offset: 0x00058370
		[XmlIgnore]
		[Browsable(false)]
		public bool open_idSpecified
		{
			get
			{
				return this._open_id != null;
			}
			set
			{
				bool flag = value == (this._open_id == null);
				if (flag)
				{
					this._open_id = (value ? this.open_id : null);
				}
			}
		}

		// Token: 0x06002EA0 RID: 11936 RVA: 0x0005A1A0 File Offset: 0x000583A0
		private bool ShouldSerializeopen_id()
		{
			return this.open_idSpecified;
		}

		// Token: 0x06002EA1 RID: 11937 RVA: 0x0005A1B8 File Offset: 0x000583B8
		private void Resetopen_id()
		{
			this.open_idSpecified = false;
		}

		// Token: 0x17000E77 RID: 3703
		// (get) Token: 0x06002EA2 RID: 11938 RVA: 0x0005A1C4 File Offset: 0x000583C4
		// (set) Token: 0x06002EA3 RID: 11939 RVA: 0x0005A1E5 File Offset: 0x000583E5
		[ProtoMember(2, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
		public string ip
		{
			get
			{
				return this._ip ?? "";
			}
			set
			{
				this._ip = value;
			}
		}

		// Token: 0x17000E78 RID: 3704
		// (get) Token: 0x06002EA4 RID: 11940 RVA: 0x0005A1F0 File Offset: 0x000583F0
		// (set) Token: 0x06002EA5 RID: 11941 RVA: 0x0005A20C File Offset: 0x0005840C
		[XmlIgnore]
		[Browsable(false)]
		public bool ipSpecified
		{
			get
			{
				return this._ip != null;
			}
			set
			{
				bool flag = value == (this._ip == null);
				if (flag)
				{
					this._ip = (value ? this.ip : null);
				}
			}
		}

		// Token: 0x06002EA6 RID: 11942 RVA: 0x0005A23C File Offset: 0x0005843C
		private bool ShouldSerializeip()
		{
			return this.ipSpecified;
		}

		// Token: 0x06002EA7 RID: 11943 RVA: 0x0005A254 File Offset: 0x00058454
		private void Resetip()
		{
			this.ipSpecified = false;
		}

		// Token: 0x06002EA8 RID: 11944 RVA: 0x0005A260 File Offset: 0x00058460
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B93 RID: 2963
		private string _open_id;

		// Token: 0x04000B94 RID: 2964
		private string _ip;

		// Token: 0x04000B95 RID: 2965
		private IExtension extensionObject;
	}
}
