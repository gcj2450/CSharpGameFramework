﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_ProtoBuf_ProtoAfterDeserializationAttribute : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ctor_s(IntPtr l) {
		try {
			ProtoBuf.ProtoAfterDeserializationAttribute o;
			o=new ProtoBuf.ProtoAfterDeserializationAttribute();
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
		getTypeTable(l,"ProtoBuf.ProtoAfterDeserializationAttribute");
		addMember(l,ctor_s);
		createTypeMetatable(l,null, typeof(ProtoBuf.ProtoAfterDeserializationAttribute),typeof(System.Attribute));
	}
}
