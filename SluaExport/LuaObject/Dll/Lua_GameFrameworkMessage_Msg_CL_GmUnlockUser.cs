﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_GameFrameworkMessage_Msg_CL_GmUnlockUser : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ctor_s(IntPtr l) {
		try {
			GameFrameworkMessage.Msg_CL_GmUnlockUser o;
			o=new GameFrameworkMessage.Msg_CL_GmUnlockUser();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_m_AccountId(IntPtr l) {
		try {
			GameFrameworkMessage.Msg_CL_GmUnlockUser self=(GameFrameworkMessage.Msg_CL_GmUnlockUser)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.m_AccountId);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_m_AccountId(IntPtr l) {
		try {
			GameFrameworkMessage.Msg_CL_GmUnlockUser self=(GameFrameworkMessage.Msg_CL_GmUnlockUser)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.m_AccountId=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"GameFrameworkMessage.Msg_CL_GmUnlockUser");
		addMember(l,ctor_s);
		addMember(l,"m_AccountId",get_m_AccountId,set_m_AccountId,true);
		createTypeMetatable(l,null, typeof(GameFrameworkMessage.Msg_CL_GmUnlockUser));
	}
}
