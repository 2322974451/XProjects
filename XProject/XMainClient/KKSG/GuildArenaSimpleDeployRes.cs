using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A6 RID: 422
	[ProtoContract(Name = "GuildArenaSimpleDeployRes")]
	[Serializable]
	public class GuildArenaSimpleDeployRes : IExtensible
	{
		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x060018FB RID: 6395 RVA: 0x00031A74 File Offset: 0x0002FC74
		[ProtoMember(1, Name = "fightunit", DataFormat = DataFormat.Default)]
		public List<GuildDarenaUnit> fightunit
		{
			get
			{
				return this._fightunit;
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x060018FC RID: 6396 RVA: 0x00031A8C File Offset: 0x0002FC8C
		// (set) Token: 0x060018FD RID: 6397 RVA: 0x00031AB8 File Offset: 0x0002FCB8
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x060018FE RID: 6398 RVA: 0x00031AC8 File Offset: 0x0002FCC8
		// (set) Token: 0x060018FF RID: 6399 RVA: 0x00031AE8 File Offset: 0x0002FCE8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x00031B2C File Offset: 0x0002FD2C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x00031B44 File Offset: 0x0002FD44
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x00031B50 File Offset: 0x0002FD50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000632 RID: 1586
		private readonly List<GuildDarenaUnit> _fightunit = new List<GuildDarenaUnit>();

		// Token: 0x04000633 RID: 1587
		private ErrorCode? _errorcode;

		// Token: 0x04000634 RID: 1588
		private IExtension extensionObject;
	}
}
