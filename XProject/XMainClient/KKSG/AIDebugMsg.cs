using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001CA RID: 458
	[ProtoContract(Name = "AIDebugMsg")]
	[Serializable]
	public class AIDebugMsg : IExtensible
	{
		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x06001AD0 RID: 6864 RVA: 0x0003512C File Offset: 0x0003332C
		// (set) Token: 0x06001AD1 RID: 6865 RVA: 0x00035158 File Offset: 0x00033358
		[ProtoMember(1, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x06001AD2 RID: 6866 RVA: 0x00035168 File Offset: 0x00033368
		// (set) Token: 0x06001AD3 RID: 6867 RVA: 0x00035188 File Offset: 0x00033388
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x06001AD4 RID: 6868 RVA: 0x000351CC File Offset: 0x000333CC
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06001AD5 RID: 6869 RVA: 0x000351E4 File Offset: 0x000333E4
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x06001AD6 RID: 6870 RVA: 0x000351F0 File Offset: 0x000333F0
		// (set) Token: 0x06001AD7 RID: 6871 RVA: 0x00035211 File Offset: 0x00033411
		[ProtoMember(2, IsRequired = false, Name = "msg", DataFormat = DataFormat.Default)]
		public string msg
		{
			get
			{
				return this._msg ?? "";
			}
			set
			{
				this._msg = value;
			}
		}

		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x06001AD8 RID: 6872 RVA: 0x0003521C File Offset: 0x0003341C
		// (set) Token: 0x06001AD9 RID: 6873 RVA: 0x00035238 File Offset: 0x00033438
		[XmlIgnore]
		[Browsable(false)]
		public bool msgSpecified
		{
			get
			{
				return this._msg != null;
			}
			set
			{
				bool flag = value == (this._msg == null);
				if (flag)
				{
					this._msg = (value ? this.msg : null);
				}
			}
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x00035268 File Offset: 0x00033468
		private bool ShouldSerializemsg()
		{
			return this.msgSpecified;
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x00035280 File Offset: 0x00033480
		private void Resetmsg()
		{
			this.msgSpecified = false;
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x0003528C File Offset: 0x0003348C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006AB RID: 1707
		private int? _level;

		// Token: 0x040006AC RID: 1708
		private string _msg;

		// Token: 0x040006AD RID: 1709
		private IExtension extensionObject;
	}
}
