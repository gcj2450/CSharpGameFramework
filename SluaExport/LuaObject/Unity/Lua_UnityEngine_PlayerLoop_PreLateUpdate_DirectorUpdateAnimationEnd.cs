﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_PreLateUpdate_DirectorUpdateAnimationEnd : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ctor_s(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.PreLateUpdate.DirectorUpdateAnimationEnd o;
			o=new UnityEngine.PlayerLoop.PreLateUpdate.DirectorUpdateAnimationEnd();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.PreLateUpdate.DirectorUpdateAnimationEnd");
		addMember(l,ctor_s);
		createTypeMetatable(l,null, typeof(UnityEngine.PlayerLoop.PreLateUpdate.DirectorUpdateAnimationEnd),typeof(System.ValueType));
	}
}
