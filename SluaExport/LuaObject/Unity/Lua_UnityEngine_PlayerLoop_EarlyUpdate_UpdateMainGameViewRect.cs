﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_EarlyUpdate_UpdateMainGameViewRect : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ctor_s(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.EarlyUpdate.UpdateMainGameViewRect o;
			o=new UnityEngine.PlayerLoop.EarlyUpdate.UpdateMainGameViewRect();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.PlayerLoop.EarlyUpdate.UpdateMainGameViewRect");
		addMember(l,ctor_s);
		createTypeMetatable(l,null, typeof(UnityEngine.PlayerLoop.EarlyUpdate.UpdateMainGameViewRect),typeof(System.ValueType));
	}
}
