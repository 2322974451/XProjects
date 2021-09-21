using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B9 RID: 1465
	[ProtoContract(Name = "ClientInfo")]
	[Serializable]
	public class ClientInfo : IExtensible
	{
		// Token: 0x1700191C RID: 6428
		// (get) Token: 0x06005145 RID: 20805 RVA: 0x0009A9F0 File Offset: 0x00098BF0
		// (set) Token: 0x06005146 RID: 20806 RVA: 0x0009AA1C File Offset: 0x00098C1C
		[ProtoMember(1, IsRequired = false, Name = "PlatID", DataFormat = DataFormat.TwosComplement)]
		public int PlatID
		{
			get
			{
				return this._PlatID ?? 0;
			}
			set
			{
				this._PlatID = new int?(value);
			}
		}

		// Token: 0x1700191D RID: 6429
		// (get) Token: 0x06005147 RID: 20807 RVA: 0x0009AA2C File Offset: 0x00098C2C
		// (set) Token: 0x06005148 RID: 20808 RVA: 0x0009AA4C File Offset: 0x00098C4C
		[XmlIgnore]
		[Browsable(false)]
		public bool PlatIDSpecified
		{
			get
			{
				return this._PlatID != null;
			}
			set
			{
				bool flag = value == (this._PlatID == null);
				if (flag)
				{
					this._PlatID = (value ? new int?(this.PlatID) : null);
				}
			}
		}

		// Token: 0x06005149 RID: 20809 RVA: 0x0009AA90 File Offset: 0x00098C90
		private bool ShouldSerializePlatID()
		{
			return this.PlatIDSpecified;
		}

		// Token: 0x0600514A RID: 20810 RVA: 0x0009AAA8 File Offset: 0x00098CA8
		private void ResetPlatID()
		{
			this.PlatIDSpecified = false;
		}

		// Token: 0x1700191E RID: 6430
		// (get) Token: 0x0600514B RID: 20811 RVA: 0x0009AAB4 File Offset: 0x00098CB4
		// (set) Token: 0x0600514C RID: 20812 RVA: 0x0009AAD5 File Offset: 0x00098CD5
		[ProtoMember(2, IsRequired = false, Name = "ClientVersion", DataFormat = DataFormat.Default)]
		public string ClientVersion
		{
			get
			{
				return this._ClientVersion ?? "";
			}
			set
			{
				this._ClientVersion = value;
			}
		}

		// Token: 0x1700191F RID: 6431
		// (get) Token: 0x0600514D RID: 20813 RVA: 0x0009AAE0 File Offset: 0x00098CE0
		// (set) Token: 0x0600514E RID: 20814 RVA: 0x0009AAFC File Offset: 0x00098CFC
		[XmlIgnore]
		[Browsable(false)]
		public bool ClientVersionSpecified
		{
			get
			{
				return this._ClientVersion != null;
			}
			set
			{
				bool flag = value == (this._ClientVersion == null);
				if (flag)
				{
					this._ClientVersion = (value ? this.ClientVersion : null);
				}
			}
		}

		// Token: 0x0600514F RID: 20815 RVA: 0x0009AB2C File Offset: 0x00098D2C
		private bool ShouldSerializeClientVersion()
		{
			return this.ClientVersionSpecified;
		}

		// Token: 0x06005150 RID: 20816 RVA: 0x0009AB44 File Offset: 0x00098D44
		private void ResetClientVersion()
		{
			this.ClientVersionSpecified = false;
		}

		// Token: 0x17001920 RID: 6432
		// (get) Token: 0x06005151 RID: 20817 RVA: 0x0009AB50 File Offset: 0x00098D50
		// (set) Token: 0x06005152 RID: 20818 RVA: 0x0009AB71 File Offset: 0x00098D71
		[ProtoMember(3, IsRequired = false, Name = "SystemSoftware", DataFormat = DataFormat.Default)]
		public string SystemSoftware
		{
			get
			{
				return this._SystemSoftware ?? "";
			}
			set
			{
				this._SystemSoftware = value;
			}
		}

		// Token: 0x17001921 RID: 6433
		// (get) Token: 0x06005153 RID: 20819 RVA: 0x0009AB7C File Offset: 0x00098D7C
		// (set) Token: 0x06005154 RID: 20820 RVA: 0x0009AB98 File Offset: 0x00098D98
		[XmlIgnore]
		[Browsable(false)]
		public bool SystemSoftwareSpecified
		{
			get
			{
				return this._SystemSoftware != null;
			}
			set
			{
				bool flag = value == (this._SystemSoftware == null);
				if (flag)
				{
					this._SystemSoftware = (value ? this.SystemSoftware : null);
				}
			}
		}

		// Token: 0x06005155 RID: 20821 RVA: 0x0009ABC8 File Offset: 0x00098DC8
		private bool ShouldSerializeSystemSoftware()
		{
			return this.SystemSoftwareSpecified;
		}

		// Token: 0x06005156 RID: 20822 RVA: 0x0009ABE0 File Offset: 0x00098DE0
		private void ResetSystemSoftware()
		{
			this.SystemSoftwareSpecified = false;
		}

		// Token: 0x17001922 RID: 6434
		// (get) Token: 0x06005157 RID: 20823 RVA: 0x0009ABEC File Offset: 0x00098DEC
		// (set) Token: 0x06005158 RID: 20824 RVA: 0x0009AC0D File Offset: 0x00098E0D
		[ProtoMember(4, IsRequired = false, Name = "SystemHardware", DataFormat = DataFormat.Default)]
		public string SystemHardware
		{
			get
			{
				return this._SystemHardware ?? "";
			}
			set
			{
				this._SystemHardware = value;
			}
		}

		// Token: 0x17001923 RID: 6435
		// (get) Token: 0x06005159 RID: 20825 RVA: 0x0009AC18 File Offset: 0x00098E18
		// (set) Token: 0x0600515A RID: 20826 RVA: 0x0009AC34 File Offset: 0x00098E34
		[XmlIgnore]
		[Browsable(false)]
		public bool SystemHardwareSpecified
		{
			get
			{
				return this._SystemHardware != null;
			}
			set
			{
				bool flag = value == (this._SystemHardware == null);
				if (flag)
				{
					this._SystemHardware = (value ? this.SystemHardware : null);
				}
			}
		}

		// Token: 0x0600515B RID: 20827 RVA: 0x0009AC64 File Offset: 0x00098E64
		private bool ShouldSerializeSystemHardware()
		{
			return this.SystemHardwareSpecified;
		}

		// Token: 0x0600515C RID: 20828 RVA: 0x0009AC7C File Offset: 0x00098E7C
		private void ResetSystemHardware()
		{
			this.SystemHardwareSpecified = false;
		}

		// Token: 0x17001924 RID: 6436
		// (get) Token: 0x0600515D RID: 20829 RVA: 0x0009AC88 File Offset: 0x00098E88
		// (set) Token: 0x0600515E RID: 20830 RVA: 0x0009ACA9 File Offset: 0x00098EA9
		[ProtoMember(5, IsRequired = false, Name = "TelecomOper", DataFormat = DataFormat.Default)]
		public string TelecomOper
		{
			get
			{
				return this._TelecomOper ?? "";
			}
			set
			{
				this._TelecomOper = value;
			}
		}

		// Token: 0x17001925 RID: 6437
		// (get) Token: 0x0600515F RID: 20831 RVA: 0x0009ACB4 File Offset: 0x00098EB4
		// (set) Token: 0x06005160 RID: 20832 RVA: 0x0009ACD0 File Offset: 0x00098ED0
		[XmlIgnore]
		[Browsable(false)]
		public bool TelecomOperSpecified
		{
			get
			{
				return this._TelecomOper != null;
			}
			set
			{
				bool flag = value == (this._TelecomOper == null);
				if (flag)
				{
					this._TelecomOper = (value ? this.TelecomOper : null);
				}
			}
		}

		// Token: 0x06005161 RID: 20833 RVA: 0x0009AD00 File Offset: 0x00098F00
		private bool ShouldSerializeTelecomOper()
		{
			return this.TelecomOperSpecified;
		}

		// Token: 0x06005162 RID: 20834 RVA: 0x0009AD18 File Offset: 0x00098F18
		private void ResetTelecomOper()
		{
			this.TelecomOperSpecified = false;
		}

		// Token: 0x17001926 RID: 6438
		// (get) Token: 0x06005163 RID: 20835 RVA: 0x0009AD24 File Offset: 0x00098F24
		// (set) Token: 0x06005164 RID: 20836 RVA: 0x0009AD45 File Offset: 0x00098F45
		[ProtoMember(6, IsRequired = false, Name = "Network", DataFormat = DataFormat.Default)]
		public string Network
		{
			get
			{
				return this._Network ?? "";
			}
			set
			{
				this._Network = value;
			}
		}

		// Token: 0x17001927 RID: 6439
		// (get) Token: 0x06005165 RID: 20837 RVA: 0x0009AD50 File Offset: 0x00098F50
		// (set) Token: 0x06005166 RID: 20838 RVA: 0x0009AD6C File Offset: 0x00098F6C
		[XmlIgnore]
		[Browsable(false)]
		public bool NetworkSpecified
		{
			get
			{
				return this._Network != null;
			}
			set
			{
				bool flag = value == (this._Network == null);
				if (flag)
				{
					this._Network = (value ? this.Network : null);
				}
			}
		}

		// Token: 0x06005167 RID: 20839 RVA: 0x0009AD9C File Offset: 0x00098F9C
		private bool ShouldSerializeNetwork()
		{
			return this.NetworkSpecified;
		}

		// Token: 0x06005168 RID: 20840 RVA: 0x0009ADB4 File Offset: 0x00098FB4
		private void ResetNetwork()
		{
			this.NetworkSpecified = false;
		}

		// Token: 0x17001928 RID: 6440
		// (get) Token: 0x06005169 RID: 20841 RVA: 0x0009ADC0 File Offset: 0x00098FC0
		// (set) Token: 0x0600516A RID: 20842 RVA: 0x0009ADEC File Offset: 0x00098FEC
		[ProtoMember(7, IsRequired = false, Name = "ScreenWidth", DataFormat = DataFormat.TwosComplement)]
		public int ScreenWidth
		{
			get
			{
				return this._ScreenWidth ?? 0;
			}
			set
			{
				this._ScreenWidth = new int?(value);
			}
		}

		// Token: 0x17001929 RID: 6441
		// (get) Token: 0x0600516B RID: 20843 RVA: 0x0009ADFC File Offset: 0x00098FFC
		// (set) Token: 0x0600516C RID: 20844 RVA: 0x0009AE1C File Offset: 0x0009901C
		[XmlIgnore]
		[Browsable(false)]
		public bool ScreenWidthSpecified
		{
			get
			{
				return this._ScreenWidth != null;
			}
			set
			{
				bool flag = value == (this._ScreenWidth == null);
				if (flag)
				{
					this._ScreenWidth = (value ? new int?(this.ScreenWidth) : null);
				}
			}
		}

		// Token: 0x0600516D RID: 20845 RVA: 0x0009AE60 File Offset: 0x00099060
		private bool ShouldSerializeScreenWidth()
		{
			return this.ScreenWidthSpecified;
		}

		// Token: 0x0600516E RID: 20846 RVA: 0x0009AE78 File Offset: 0x00099078
		private void ResetScreenWidth()
		{
			this.ScreenWidthSpecified = false;
		}

		// Token: 0x1700192A RID: 6442
		// (get) Token: 0x0600516F RID: 20847 RVA: 0x0009AE84 File Offset: 0x00099084
		// (set) Token: 0x06005170 RID: 20848 RVA: 0x0009AEB0 File Offset: 0x000990B0
		[ProtoMember(8, IsRequired = false, Name = "ScreenHight", DataFormat = DataFormat.TwosComplement)]
		public int ScreenHight
		{
			get
			{
				return this._ScreenHight ?? 0;
			}
			set
			{
				this._ScreenHight = new int?(value);
			}
		}

		// Token: 0x1700192B RID: 6443
		// (get) Token: 0x06005171 RID: 20849 RVA: 0x0009AEC0 File Offset: 0x000990C0
		// (set) Token: 0x06005172 RID: 20850 RVA: 0x0009AEE0 File Offset: 0x000990E0
		[XmlIgnore]
		[Browsable(false)]
		public bool ScreenHightSpecified
		{
			get
			{
				return this._ScreenHight != null;
			}
			set
			{
				bool flag = value == (this._ScreenHight == null);
				if (flag)
				{
					this._ScreenHight = (value ? new int?(this.ScreenHight) : null);
				}
			}
		}

		// Token: 0x06005173 RID: 20851 RVA: 0x0009AF24 File Offset: 0x00099124
		private bool ShouldSerializeScreenHight()
		{
			return this.ScreenHightSpecified;
		}

		// Token: 0x06005174 RID: 20852 RVA: 0x0009AF3C File Offset: 0x0009913C
		private void ResetScreenHight()
		{
			this.ScreenHightSpecified = false;
		}

		// Token: 0x1700192C RID: 6444
		// (get) Token: 0x06005175 RID: 20853 RVA: 0x0009AF48 File Offset: 0x00099148
		// (set) Token: 0x06005176 RID: 20854 RVA: 0x0009AF78 File Offset: 0x00099178
		[ProtoMember(9, IsRequired = false, Name = "Density", DataFormat = DataFormat.FixedSize)]
		public float Density
		{
			get
			{
				return this._Density ?? 0f;
			}
			set
			{
				this._Density = new float?(value);
			}
		}

		// Token: 0x1700192D RID: 6445
		// (get) Token: 0x06005177 RID: 20855 RVA: 0x0009AF88 File Offset: 0x00099188
		// (set) Token: 0x06005178 RID: 20856 RVA: 0x0009AFA8 File Offset: 0x000991A8
		[XmlIgnore]
		[Browsable(false)]
		public bool DensitySpecified
		{
			get
			{
				return this._Density != null;
			}
			set
			{
				bool flag = value == (this._Density == null);
				if (flag)
				{
					this._Density = (value ? new float?(this.Density) : null);
				}
			}
		}

		// Token: 0x06005179 RID: 20857 RVA: 0x0009AFEC File Offset: 0x000991EC
		private bool ShouldSerializeDensity()
		{
			return this.DensitySpecified;
		}

		// Token: 0x0600517A RID: 20858 RVA: 0x0009B004 File Offset: 0x00099204
		private void ResetDensity()
		{
			this.DensitySpecified = false;
		}

		// Token: 0x1700192E RID: 6446
		// (get) Token: 0x0600517B RID: 20859 RVA: 0x0009B010 File Offset: 0x00099210
		// (set) Token: 0x0600517C RID: 20860 RVA: 0x0009B031 File Offset: 0x00099231
		[ProtoMember(10, IsRequired = false, Name = "LoginChannel", DataFormat = DataFormat.Default)]
		public string LoginChannel
		{
			get
			{
				return this._LoginChannel ?? "";
			}
			set
			{
				this._LoginChannel = value;
			}
		}

		// Token: 0x1700192F RID: 6447
		// (get) Token: 0x0600517D RID: 20861 RVA: 0x0009B03C File Offset: 0x0009923C
		// (set) Token: 0x0600517E RID: 20862 RVA: 0x0009B058 File Offset: 0x00099258
		[XmlIgnore]
		[Browsable(false)]
		public bool LoginChannelSpecified
		{
			get
			{
				return this._LoginChannel != null;
			}
			set
			{
				bool flag = value == (this._LoginChannel == null);
				if (flag)
				{
					this._LoginChannel = (value ? this.LoginChannel : null);
				}
			}
		}

		// Token: 0x0600517F RID: 20863 RVA: 0x0009B088 File Offset: 0x00099288
		private bool ShouldSerializeLoginChannel()
		{
			return this.LoginChannelSpecified;
		}

		// Token: 0x06005180 RID: 20864 RVA: 0x0009B0A0 File Offset: 0x000992A0
		private void ResetLoginChannel()
		{
			this.LoginChannelSpecified = false;
		}

		// Token: 0x17001930 RID: 6448
		// (get) Token: 0x06005181 RID: 20865 RVA: 0x0009B0AC File Offset: 0x000992AC
		// (set) Token: 0x06005182 RID: 20866 RVA: 0x0009B0CD File Offset: 0x000992CD
		[ProtoMember(11, IsRequired = false, Name = "CpuHardware", DataFormat = DataFormat.Default)]
		public string CpuHardware
		{
			get
			{
				return this._CpuHardware ?? "";
			}
			set
			{
				this._CpuHardware = value;
			}
		}

		// Token: 0x17001931 RID: 6449
		// (get) Token: 0x06005183 RID: 20867 RVA: 0x0009B0D8 File Offset: 0x000992D8
		// (set) Token: 0x06005184 RID: 20868 RVA: 0x0009B0F4 File Offset: 0x000992F4
		[XmlIgnore]
		[Browsable(false)]
		public bool CpuHardwareSpecified
		{
			get
			{
				return this._CpuHardware != null;
			}
			set
			{
				bool flag = value == (this._CpuHardware == null);
				if (flag)
				{
					this._CpuHardware = (value ? this.CpuHardware : null);
				}
			}
		}

		// Token: 0x06005185 RID: 20869 RVA: 0x0009B124 File Offset: 0x00099324
		private bool ShouldSerializeCpuHardware()
		{
			return this.CpuHardwareSpecified;
		}

		// Token: 0x06005186 RID: 20870 RVA: 0x0009B13C File Offset: 0x0009933C
		private void ResetCpuHardware()
		{
			this.CpuHardwareSpecified = false;
		}

		// Token: 0x17001932 RID: 6450
		// (get) Token: 0x06005187 RID: 20871 RVA: 0x0009B148 File Offset: 0x00099348
		// (set) Token: 0x06005188 RID: 20872 RVA: 0x0009B174 File Offset: 0x00099374
		[ProtoMember(12, IsRequired = false, Name = "Memory", DataFormat = DataFormat.TwosComplement)]
		public int Memory
		{
			get
			{
				return this._Memory ?? 0;
			}
			set
			{
				this._Memory = new int?(value);
			}
		}

		// Token: 0x17001933 RID: 6451
		// (get) Token: 0x06005189 RID: 20873 RVA: 0x0009B184 File Offset: 0x00099384
		// (set) Token: 0x0600518A RID: 20874 RVA: 0x0009B1A4 File Offset: 0x000993A4
		[XmlIgnore]
		[Browsable(false)]
		public bool MemorySpecified
		{
			get
			{
				return this._Memory != null;
			}
			set
			{
				bool flag = value == (this._Memory == null);
				if (flag)
				{
					this._Memory = (value ? new int?(this.Memory) : null);
				}
			}
		}

		// Token: 0x0600518B RID: 20875 RVA: 0x0009B1E8 File Offset: 0x000993E8
		private bool ShouldSerializeMemory()
		{
			return this.MemorySpecified;
		}

		// Token: 0x0600518C RID: 20876 RVA: 0x0009B200 File Offset: 0x00099400
		private void ResetMemory()
		{
			this.MemorySpecified = false;
		}

		// Token: 0x17001934 RID: 6452
		// (get) Token: 0x0600518D RID: 20877 RVA: 0x0009B20C File Offset: 0x0009940C
		// (set) Token: 0x0600518E RID: 20878 RVA: 0x0009B22D File Offset: 0x0009942D
		[ProtoMember(13, IsRequired = false, Name = "GLRender", DataFormat = DataFormat.Default)]
		public string GLRender
		{
			get
			{
				return this._GLRender ?? "";
			}
			set
			{
				this._GLRender = value;
			}
		}

		// Token: 0x17001935 RID: 6453
		// (get) Token: 0x0600518F RID: 20879 RVA: 0x0009B238 File Offset: 0x00099438
		// (set) Token: 0x06005190 RID: 20880 RVA: 0x0009B254 File Offset: 0x00099454
		[XmlIgnore]
		[Browsable(false)]
		public bool GLRenderSpecified
		{
			get
			{
				return this._GLRender != null;
			}
			set
			{
				bool flag = value == (this._GLRender == null);
				if (flag)
				{
					this._GLRender = (value ? this.GLRender : null);
				}
			}
		}

		// Token: 0x06005191 RID: 20881 RVA: 0x0009B284 File Offset: 0x00099484
		private bool ShouldSerializeGLRender()
		{
			return this.GLRenderSpecified;
		}

		// Token: 0x06005192 RID: 20882 RVA: 0x0009B29C File Offset: 0x0009949C
		private void ResetGLRender()
		{
			this.GLRenderSpecified = false;
		}

		// Token: 0x17001936 RID: 6454
		// (get) Token: 0x06005193 RID: 20883 RVA: 0x0009B2A8 File Offset: 0x000994A8
		// (set) Token: 0x06005194 RID: 20884 RVA: 0x0009B2C9 File Offset: 0x000994C9
		[ProtoMember(14, IsRequired = false, Name = "GLVersion", DataFormat = DataFormat.Default)]
		public string GLVersion
		{
			get
			{
				return this._GLVersion ?? "";
			}
			set
			{
				this._GLVersion = value;
			}
		}

		// Token: 0x17001937 RID: 6455
		// (get) Token: 0x06005195 RID: 20885 RVA: 0x0009B2D4 File Offset: 0x000994D4
		// (set) Token: 0x06005196 RID: 20886 RVA: 0x0009B2F0 File Offset: 0x000994F0
		[XmlIgnore]
		[Browsable(false)]
		public bool GLVersionSpecified
		{
			get
			{
				return this._GLVersion != null;
			}
			set
			{
				bool flag = value == (this._GLVersion == null);
				if (flag)
				{
					this._GLVersion = (value ? this.GLVersion : null);
				}
			}
		}

		// Token: 0x06005197 RID: 20887 RVA: 0x0009B320 File Offset: 0x00099520
		private bool ShouldSerializeGLVersion()
		{
			return this.GLVersionSpecified;
		}

		// Token: 0x06005198 RID: 20888 RVA: 0x0009B338 File Offset: 0x00099538
		private void ResetGLVersion()
		{
			this.GLVersionSpecified = false;
		}

		// Token: 0x17001938 RID: 6456
		// (get) Token: 0x06005199 RID: 20889 RVA: 0x0009B344 File Offset: 0x00099544
		// (set) Token: 0x0600519A RID: 20890 RVA: 0x0009B365 File Offset: 0x00099565
		[ProtoMember(15, IsRequired = false, Name = "DeviceId", DataFormat = DataFormat.Default)]
		public string DeviceId
		{
			get
			{
				return this._DeviceId ?? "";
			}
			set
			{
				this._DeviceId = value;
			}
		}

		// Token: 0x17001939 RID: 6457
		// (get) Token: 0x0600519B RID: 20891 RVA: 0x0009B370 File Offset: 0x00099570
		// (set) Token: 0x0600519C RID: 20892 RVA: 0x0009B38C File Offset: 0x0009958C
		[XmlIgnore]
		[Browsable(false)]
		public bool DeviceIdSpecified
		{
			get
			{
				return this._DeviceId != null;
			}
			set
			{
				bool flag = value == (this._DeviceId == null);
				if (flag)
				{
					this._DeviceId = (value ? this.DeviceId : null);
				}
			}
		}

		// Token: 0x0600519D RID: 20893 RVA: 0x0009B3BC File Offset: 0x000995BC
		private bool ShouldSerializeDeviceId()
		{
			return this.DeviceIdSpecified;
		}

		// Token: 0x0600519E RID: 20894 RVA: 0x0009B3D4 File Offset: 0x000995D4
		private void ResetDeviceId()
		{
			this.DeviceIdSpecified = false;
		}

		// Token: 0x1700193A RID: 6458
		// (get) Token: 0x0600519F RID: 20895 RVA: 0x0009B3E0 File Offset: 0x000995E0
		// (set) Token: 0x060051A0 RID: 20896 RVA: 0x0009B401 File Offset: 0x00099601
		[ProtoMember(16, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700193B RID: 6459
		// (get) Token: 0x060051A1 RID: 20897 RVA: 0x0009B40C File Offset: 0x0009960C
		// (set) Token: 0x060051A2 RID: 20898 RVA: 0x0009B428 File Offset: 0x00099628
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

		// Token: 0x060051A3 RID: 20899 RVA: 0x0009B458 File Offset: 0x00099658
		private bool ShouldSerializeip()
		{
			return this.ipSpecified;
		}

		// Token: 0x060051A4 RID: 20900 RVA: 0x0009B470 File Offset: 0x00099670
		private void Resetip()
		{
			this.ipSpecified = false;
		}

		// Token: 0x1700193C RID: 6460
		// (get) Token: 0x060051A5 RID: 20901 RVA: 0x0009B47C File Offset: 0x0009967C
		// (set) Token: 0x060051A6 RID: 20902 RVA: 0x0009B49D File Offset: 0x0009969D
		[ProtoMember(17, IsRequired = false, Name = "pf", DataFormat = DataFormat.Default)]
		public string pf
		{
			get
			{
				return this._pf ?? "";
			}
			set
			{
				this._pf = value;
			}
		}

		// Token: 0x1700193D RID: 6461
		// (get) Token: 0x060051A7 RID: 20903 RVA: 0x0009B4A8 File Offset: 0x000996A8
		// (set) Token: 0x060051A8 RID: 20904 RVA: 0x0009B4C4 File Offset: 0x000996C4
		[XmlIgnore]
		[Browsable(false)]
		public bool pfSpecified
		{
			get
			{
				return this._pf != null;
			}
			set
			{
				bool flag = value == (this._pf == null);
				if (flag)
				{
					this._pf = (value ? this.pf : null);
				}
			}
		}

		// Token: 0x060051A9 RID: 20905 RVA: 0x0009B4F4 File Offset: 0x000996F4
		private bool ShouldSerializepf()
		{
			return this.pfSpecified;
		}

		// Token: 0x060051AA RID: 20906 RVA: 0x0009B50C File Offset: 0x0009970C
		private void Resetpf()
		{
			this.pfSpecified = false;
		}

		// Token: 0x1700193E RID: 6462
		// (get) Token: 0x060051AB RID: 20907 RVA: 0x0009B518 File Offset: 0x00099718
		// (set) Token: 0x060051AC RID: 20908 RVA: 0x0009B544 File Offset: 0x00099744
		[ProtoMember(18, IsRequired = false, Name = "starttype", DataFormat = DataFormat.TwosComplement)]
		public StartUpType starttype
		{
			get
			{
				return this._starttype ?? StartUpType.StartUp_Normal;
			}
			set
			{
				this._starttype = new StartUpType?(value);
			}
		}

		// Token: 0x1700193F RID: 6463
		// (get) Token: 0x060051AD RID: 20909 RVA: 0x0009B554 File Offset: 0x00099754
		// (set) Token: 0x060051AE RID: 20910 RVA: 0x0009B574 File Offset: 0x00099774
		[XmlIgnore]
		[Browsable(false)]
		public bool starttypeSpecified
		{
			get
			{
				return this._starttype != null;
			}
			set
			{
				bool flag = value == (this._starttype == null);
				if (flag)
				{
					this._starttype = (value ? new StartUpType?(this.starttype) : null);
				}
			}
		}

		// Token: 0x060051AF RID: 20911 RVA: 0x0009B5B8 File Offset: 0x000997B8
		private bool ShouldSerializestarttype()
		{
			return this.starttypeSpecified;
		}

		// Token: 0x060051B0 RID: 20912 RVA: 0x0009B5D0 File Offset: 0x000997D0
		private void Resetstarttype()
		{
			this.starttypeSpecified = false;
		}

		// Token: 0x17001940 RID: 6464
		// (get) Token: 0x060051B1 RID: 20913 RVA: 0x0009B5DC File Offset: 0x000997DC
		// (set) Token: 0x060051B2 RID: 20914 RVA: 0x0009B5FD File Offset: 0x000997FD
		[ProtoMember(19, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		// Token: 0x17001941 RID: 6465
		// (get) Token: 0x060051B3 RID: 20915 RVA: 0x0009B608 File Offset: 0x00099808
		// (set) Token: 0x060051B4 RID: 20916 RVA: 0x0009B624 File Offset: 0x00099824
		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		// Token: 0x060051B5 RID: 20917 RVA: 0x0009B654 File Offset: 0x00099854
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x060051B6 RID: 20918 RVA: 0x0009B66C File Offset: 0x0009986C
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x17001942 RID: 6466
		// (get) Token: 0x060051B7 RID: 20919 RVA: 0x0009B678 File Offset: 0x00099878
		// (set) Token: 0x060051B8 RID: 20920 RVA: 0x0009B6A4 File Offset: 0x000998A4
		[ProtoMember(20, IsRequired = false, Name = "logintype", DataFormat = DataFormat.TwosComplement)]
		public LoginType logintype
		{
			get
			{
				return this._logintype ?? LoginType.LOGIN_PASSWORD;
			}
			set
			{
				this._logintype = new LoginType?(value);
			}
		}

		// Token: 0x17001943 RID: 6467
		// (get) Token: 0x060051B9 RID: 20921 RVA: 0x0009B6B4 File Offset: 0x000998B4
		// (set) Token: 0x060051BA RID: 20922 RVA: 0x0009B6D4 File Offset: 0x000998D4
		[XmlIgnore]
		[Browsable(false)]
		public bool logintypeSpecified
		{
			get
			{
				return this._logintype != null;
			}
			set
			{
				bool flag = value == (this._logintype == null);
				if (flag)
				{
					this._logintype = (value ? new LoginType?(this.logintype) : null);
				}
			}
		}

		// Token: 0x060051BB RID: 20923 RVA: 0x0009B718 File Offset: 0x00099918
		private bool ShouldSerializelogintype()
		{
			return this.logintypeSpecified;
		}

		// Token: 0x060051BC RID: 20924 RVA: 0x0009B730 File Offset: 0x00099930
		private void Resetlogintype()
		{
			this.logintypeSpecified = false;
		}

		// Token: 0x060051BD RID: 20925 RVA: 0x0009B73C File Offset: 0x0009993C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040013EE RID: 5102
		private int? _PlatID;

		// Token: 0x040013EF RID: 5103
		private string _ClientVersion;

		// Token: 0x040013F0 RID: 5104
		private string _SystemSoftware;

		// Token: 0x040013F1 RID: 5105
		private string _SystemHardware;

		// Token: 0x040013F2 RID: 5106
		private string _TelecomOper;

		// Token: 0x040013F3 RID: 5107
		private string _Network;

		// Token: 0x040013F4 RID: 5108
		private int? _ScreenWidth;

		// Token: 0x040013F5 RID: 5109
		private int? _ScreenHight;

		// Token: 0x040013F6 RID: 5110
		private float? _Density;

		// Token: 0x040013F7 RID: 5111
		private string _LoginChannel;

		// Token: 0x040013F8 RID: 5112
		private string _CpuHardware;

		// Token: 0x040013F9 RID: 5113
		private int? _Memory;

		// Token: 0x040013FA RID: 5114
		private string _GLRender;

		// Token: 0x040013FB RID: 5115
		private string _GLVersion;

		// Token: 0x040013FC RID: 5116
		private string _DeviceId;

		// Token: 0x040013FD RID: 5117
		private string _ip;

		// Token: 0x040013FE RID: 5118
		private string _pf;

		// Token: 0x040013FF RID: 5119
		private StartUpType? _starttype;

		// Token: 0x04001400 RID: 5120
		private string _token;

		// Token: 0x04001401 RID: 5121
		private LoginType? _logintype;

		// Token: 0x04001402 RID: 5122
		private IExtension extensionObject;
	}
}
