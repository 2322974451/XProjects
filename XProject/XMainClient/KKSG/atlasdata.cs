using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000631 RID: 1585
	[ProtoContract(Name = "atlasdata")]
	[Serializable]
	public class atlasdata : IExtensible
	{
		// Token: 0x17001EA5 RID: 7845
		// (get) Token: 0x0600615E RID: 24926 RVA: 0x000B9BC8 File Offset: 0x000B7DC8
		// (set) Token: 0x0600615F RID: 24927 RVA: 0x000B9BF4 File Offset: 0x000B7DF4
		[ProtoMember(1, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public uint groupid
		{
			get
			{
				return this._groupid ?? 0U;
			}
			set
			{
				this._groupid = new uint?(value);
			}
		}

		// Token: 0x17001EA6 RID: 7846
		// (get) Token: 0x06006160 RID: 24928 RVA: 0x000B9C04 File Offset: 0x000B7E04
		// (set) Token: 0x06006161 RID: 24929 RVA: 0x000B9C24 File Offset: 0x000B7E24
		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new uint?(this.groupid) : null);
				}
			}
		}

		// Token: 0x06006162 RID: 24930 RVA: 0x000B9C68 File Offset: 0x000B7E68
		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		// Token: 0x06006163 RID: 24931 RVA: 0x000B9C80 File Offset: 0x000B7E80
		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		// Token: 0x17001EA7 RID: 7847
		// (get) Token: 0x06006164 RID: 24932 RVA: 0x000B9C8C File Offset: 0x000B7E8C
		// (set) Token: 0x06006165 RID: 24933 RVA: 0x000B9CB8 File Offset: 0x000B7EB8
		[ProtoMember(2, IsRequired = false, Name = "finishid", DataFormat = DataFormat.TwosComplement)]
		public uint finishid
		{
			get
			{
				return this._finishid ?? 0U;
			}
			set
			{
				this._finishid = new uint?(value);
			}
		}

		// Token: 0x17001EA8 RID: 7848
		// (get) Token: 0x06006166 RID: 24934 RVA: 0x000B9CC8 File Offset: 0x000B7EC8
		// (set) Token: 0x06006167 RID: 24935 RVA: 0x000B9CE8 File Offset: 0x000B7EE8
		[XmlIgnore]
		[Browsable(false)]
		public bool finishidSpecified
		{
			get
			{
				return this._finishid != null;
			}
			set
			{
				bool flag = value == (this._finishid == null);
				if (flag)
				{
					this._finishid = (value ? new uint?(this.finishid) : null);
				}
			}
		}

		// Token: 0x06006168 RID: 24936 RVA: 0x000B9D2C File Offset: 0x000B7F2C
		private bool ShouldSerializefinishid()
		{
			return this.finishidSpecified;
		}

		// Token: 0x06006169 RID: 24937 RVA: 0x000B9D44 File Offset: 0x000B7F44
		private void Resetfinishid()
		{
			this.finishidSpecified = false;
		}

		// Token: 0x0600616A RID: 24938 RVA: 0x000B9D50 File Offset: 0x000B7F50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017A2 RID: 6050
		private uint? _groupid;

		// Token: 0x040017A3 RID: 6051
		private uint? _finishid;

		// Token: 0x040017A4 RID: 6052
		private IExtension extensionObject;
	}
}
