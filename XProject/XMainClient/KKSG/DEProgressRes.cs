using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000205 RID: 517
	[ProtoContract(Name = "DEProgressRes")]
	[Serializable]
	public class DEProgressRes : IExtensible
	{
		// Token: 0x1700092A RID: 2346
		// (get) Token: 0x06001D40 RID: 7488 RVA: 0x00039928 File Offset: 0x00037B28
		[ProtoMember(1, Name = "allpro", DataFormat = DataFormat.Default)]
		public List<DEProgress> allpro
		{
			get
			{
				return this._allpro;
			}
		}

		// Token: 0x1700092B RID: 2347
		// (get) Token: 0x06001D41 RID: 7489 RVA: 0x00039940 File Offset: 0x00037B40
		// (set) Token: 0x06001D42 RID: 7490 RVA: 0x0003996C File Offset: 0x00037B6C
		[ProtoMember(2, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public int allcount
		{
			get
			{
				return this._allcount ?? 0;
			}
			set
			{
				this._allcount = new int?(value);
			}
		}

		// Token: 0x1700092C RID: 2348
		// (get) Token: 0x06001D43 RID: 7491 RVA: 0x0003997C File Offset: 0x00037B7C
		// (set) Token: 0x06001D44 RID: 7492 RVA: 0x0003999C File Offset: 0x00037B9C
		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new int?(this.allcount) : null);
				}
			}
		}

		// Token: 0x06001D45 RID: 7493 RVA: 0x000399E0 File Offset: 0x00037BE0
		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		// Token: 0x06001D46 RID: 7494 RVA: 0x000399F8 File Offset: 0x00037BF8
		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		// Token: 0x1700092D RID: 2349
		// (get) Token: 0x06001D47 RID: 7495 RVA: 0x00039A04 File Offset: 0x00037C04
		// (set) Token: 0x06001D48 RID: 7496 RVA: 0x00039A30 File Offset: 0x00037C30
		[ProtoMember(3, IsRequired = false, Name = "leftcount", DataFormat = DataFormat.TwosComplement)]
		public int leftcount
		{
			get
			{
				return this._leftcount ?? 0;
			}
			set
			{
				this._leftcount = new int?(value);
			}
		}

		// Token: 0x1700092E RID: 2350
		// (get) Token: 0x06001D49 RID: 7497 RVA: 0x00039A40 File Offset: 0x00037C40
		// (set) Token: 0x06001D4A RID: 7498 RVA: 0x00039A60 File Offset: 0x00037C60
		[XmlIgnore]
		[Browsable(false)]
		public bool leftcountSpecified
		{
			get
			{
				return this._leftcount != null;
			}
			set
			{
				bool flag = value == (this._leftcount == null);
				if (flag)
				{
					this._leftcount = (value ? new int?(this.leftcount) : null);
				}
			}
		}

		// Token: 0x06001D4B RID: 7499 RVA: 0x00039AA4 File Offset: 0x00037CA4
		private bool ShouldSerializeleftcount()
		{
			return this.leftcountSpecified;
		}

		// Token: 0x06001D4C RID: 7500 RVA: 0x00039ABC File Offset: 0x00037CBC
		private void Resetleftcount()
		{
			this.leftcountSpecified = false;
		}

		// Token: 0x1700092F RID: 2351
		// (get) Token: 0x06001D4D RID: 7501 RVA: 0x00039AC8 File Offset: 0x00037CC8
		// (set) Token: 0x06001D4E RID: 7502 RVA: 0x00039AF4 File Offset: 0x00037CF4
		[ProtoMember(4, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000930 RID: 2352
		// (get) Token: 0x06001D4F RID: 7503 RVA: 0x00039B04 File Offset: 0x00037D04
		// (set) Token: 0x06001D50 RID: 7504 RVA: 0x00039B24 File Offset: 0x00037D24
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06001D51 RID: 7505 RVA: 0x00039B68 File Offset: 0x00037D68
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001D52 RID: 7506 RVA: 0x00039B80 File Offset: 0x00037D80
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x17000931 RID: 2353
		// (get) Token: 0x06001D53 RID: 7507 RVA: 0x00039B8C File Offset: 0x00037D8C
		// (set) Token: 0x06001D54 RID: 7508 RVA: 0x00039BB8 File Offset: 0x00037DB8
		[ProtoMember(5, IsRequired = false, Name = "serverseallevel", DataFormat = DataFormat.TwosComplement)]
		public uint serverseallevel
		{
			get
			{
				return this._serverseallevel ?? 0U;
			}
			set
			{
				this._serverseallevel = new uint?(value);
			}
		}

		// Token: 0x17000932 RID: 2354
		// (get) Token: 0x06001D55 RID: 7509 RVA: 0x00039BC8 File Offset: 0x00037DC8
		// (set) Token: 0x06001D56 RID: 7510 RVA: 0x00039BE8 File Offset: 0x00037DE8
		[XmlIgnore]
		[Browsable(false)]
		public bool serverseallevelSpecified
		{
			get
			{
				return this._serverseallevel != null;
			}
			set
			{
				bool flag = value == (this._serverseallevel == null);
				if (flag)
				{
					this._serverseallevel = (value ? new uint?(this.serverseallevel) : null);
				}
			}
		}

		// Token: 0x06001D57 RID: 7511 RVA: 0x00039C2C File Offset: 0x00037E2C
		private bool ShouldSerializeserverseallevel()
		{
			return this.serverseallevelSpecified;
		}

		// Token: 0x06001D58 RID: 7512 RVA: 0x00039C44 File Offset: 0x00037E44
		private void Resetserverseallevel()
		{
			this.serverseallevelSpecified = false;
		}

		// Token: 0x06001D59 RID: 7513 RVA: 0x00039C50 File Offset: 0x00037E50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400074F RID: 1871
		private readonly List<DEProgress> _allpro = new List<DEProgress>();

		// Token: 0x04000750 RID: 1872
		private int? _allcount;

		// Token: 0x04000751 RID: 1873
		private int? _leftcount;

		// Token: 0x04000752 RID: 1874
		private ErrorCode? _errcode;

		// Token: 0x04000753 RID: 1875
		private uint? _serverseallevel;

		// Token: 0x04000754 RID: 1876
		private IExtension extensionObject;
	}
}
