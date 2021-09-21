using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x02000068 RID: 104
	public interface ILuaNetwork : IXInterface
	{
		// Token: 0x0600034F RID: 847
		void InitLua(int rpcCache);

		// Token: 0x06000350 RID: 848
		bool LuaRigsterPtc(uint type, bool copyBuffer);

		// Token: 0x06000351 RID: 849
		void LuaRegistDispacher(List<uint> types);

		// Token: 0x06000352 RID: 850
		void LuaRigsterRPC(uint _type, bool copyBuffer, DelLuaRespond _onRes, DelLuaError _onError);

		// Token: 0x06000353 RID: 851
		bool LuaSendPtc(uint _type, byte[] _reqBuff);

		// Token: 0x06000354 RID: 852
		bool LuaSendRPC(uint _type, byte[] _reqBuff, DelLuaRespond _onRes, DelLuaError _onError);
	}
}
